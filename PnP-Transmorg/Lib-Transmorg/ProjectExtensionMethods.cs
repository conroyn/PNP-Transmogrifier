using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lib_Transmorg
{
    public static class ProjectExtensionMethods
    {
        public static string SanitizeQuotedCsv(this List<string> lines)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string line in lines)
            {
                string[] parts = line.Split("\"");
                for(int i = 1; i < parts.Length; i += 2)
                {
                    if (i > parts.Length - 1) break;
                    if (parts[i] != string.Empty)
                    {
                        parts[i] = parts[i].Replace(",", " ");
                    }
                }
                sb.AppendLine(string.Concat(parts));
            }
            return sb.ToString();
        }

        public static bool ImportCsv(this Project project, string csv, InputCsvMapping mapping)
        {
            bool result = false;
            List<Part> newparts = new List<Part>();
            List<string> lines = Regex.Split(csv, "\r\n|\r|\n").Skip(mapping.LinesToSkip).ToList();
            string cleanedCsv;
            if (mapping.QuotedValues)
            {
                cleanedCsv = lines.SanitizeQuotedCsv();
            }
            else
            {
                cleanedCsv = string.Join(Environment.NewLine, lines.ToArray());
            }

            int DesignatorIndex = -1;
            int DescriptionIndex = -1;
            int PartNumIndex = -1;
            int MidXIndex = -1;
            int MidYIndex = -1;
            int RotationIndex = -1;
            int HeightIndex = -1;
            int LayerIndex = -1;

            string[] CleanedLines = cleanedCsv.Split(Environment.NewLine);
                
            string[]? header = CleanedLines[0].Split(',');
            if (header == null) return false;
            for (int i = 0; i < header.Length; i++)
            {
                if (header[i].Contains(mapping.PartNumHeader)) PartNumIndex = i;
                else if (header[i].Contains(mapping.DesignatorHeader)) DesignatorIndex = i;
                else if (header[i].Contains(mapping.DesignDescriptionHeader)) DescriptionIndex = i;
                else if (header[i].Contains(mapping.MidXHeader)) MidXIndex = i;
                else if (header[i].Contains(mapping.MidYHeader)) MidYIndex = i;
                else if (header[i].Contains(mapping.RotationHeader)) RotationIndex = i;
                else if (header[i].Contains(mapping.HeightHeader)) HeightIndex = i;
                else if (header[i].Contains(mapping.LayerHeader)) LayerIndex = i;
            }

            if ((DesignatorIndex < 0) || (PartNumIndex < 0) || (DescriptionIndex < 0) ||(MidXIndex < 0) || (MidYIndex < 0) || (RotationIndex < 0) || (HeightIndex < 0) || (LayerIndex < 0))
            {
                string errorMsg = string.Format("Expected header(s) not parsed. Check csv mapping and header offset. " +
                    "Indexes found (-1 indicates not found) -> Designator Index: {0} PartNumber Index {1} Description Index: {2} MidX Index: {3} MidY Index: {4} Rotation Index: {5} Height Index: {6} Layer Index: {7}",
                    DesignatorIndex, PartNumIndex, DescriptionIndex,MidXIndex, MidYIndex, RotationIndex, HeightIndex, LayerIndex);
                throw new FormatException(errorMsg);
            }

            for(int i = 1; i<CleanedLines.Length; i++)
            {
                string[]? line = CleanedLines[i].Split(',');
                if (line.Count() <= 1) continue;
                Part part = new Part();
                part.Designator = line[DesignatorIndex];
                part.PartNumber = line[PartNumIndex];
                part.DesignDescription = line[DescriptionIndex];
                part.CenterX = Convert.ToDouble(line[MidXIndex]);
                part.CenterX = part.CenterX - mapping.XCenterOffset;
                part.CenterY = Convert.ToDouble(line[MidYIndex]);
                part.CenterY = part.CenterY - mapping.YCenterOffset;
                part.Rotation = Convert.ToDouble(line[RotationIndex]);
                try
                {
                    part.PartHeight = Convert.ToDouble(line[HeightIndex]);
                }
                catch
                {
                    part.PartHeight = 0;
                }
                if (line[LayerIndex].ToUpper().Contains(PcbLayer.TOP.ToString()))
                {
                    part.Layer = PcbLayer.TOP;
                }
                else
                {
                    part.Layer = PcbLayer.BOTTOM;
                }
                //Default Skip part until library is loaded and we known what feeder to pick from
                part.Skip = true;
                newparts.Add(part);
            }
            result = true;
            

            if (result)
            {
                project.Parts = newparts;
            }
            return result;
        }

        public static bool ImportLibraryFile(this Project project, string path)
        {
            Library library = new Library();
            bool result = library.LoadLibraryFile(path);
            if (result)
            {
                project.Library = library;
            }

            return result;
        }


        //Returns list of NotFound and MultipleOption results
        public static List<Conflict> ApplyLibraryOverwrite(this Project project, Library library)
        {
            List<Conflict> conflicts = new List<Conflict>();
            foreach(Part part in project.Parts)
            {
                List<LibPart> matches = library.LibParts.FindAll(s => (s.PartNumber == part.PartNumber) && (s.FeederNumber != -1));
                switch (matches.Count)
                {
                    case 0:
                        conflicts.Add(new NotFound()
                        {
                            Part = part,
                            Solution = null
                        });
                        break;
                    case 1:
                        part.ApplyLibPart(matches[0]);
                        break;
                    default:
                        part.Skip = false;
                        conflicts.Add(new MultipleOptions()
                        {
                            Part = part,
                            Solution = null,
                            LibOptions = matches
                        });
                    break;
                }
            }
            project.Library = library;
            return conflicts;
        }

        //Checks for existing parameters in project parts instead of blindly overwrting
        //Returns NotFound, MultipleOptions, and OverWrite
        public static List<Conflict> ApplyLibraryChecks(this Project project, Library library)
        {
            List<Conflict> conflicts = new List<Conflict>();
            foreach (Part part in project.Parts)
            {
                List<LibPart> matches = library.LibParts.FindAll(s => (s.PartNumber == part.PartNumber) && (s.FeederNumber != -1));
                switch (matches.Count)
                {
                    case 0:
                        conflicts.Add(new NotFound()
                        {
                            Part = part,
                            Solution = null
                        });
                        break;
                    case 1:
                        PartCompare compare = new PartCompare(part, matches[0]);
                        if(compare.Status == CompareStatus.MisMatch)
                        {
                            conflicts.Add(new OverWrite()
                            {
                                Part = part,
                                Solution = matches[0],
                                CompareDetails = compare
                            });
                        }
                        else
                        {
                            part.ApplyLibPart(matches[0]);
                        }
                        break;
                    default:
                        conflicts.Add(new MultipleOptions()
                        {
                            Part = part,
                            Solution = null,
                            LibOptions = matches
                        });
                        break;
                }
            }
            project.Library = library;
            return conflicts;
        }

        public static Part GetDummyPart(PlacementHead head, int FeederNum = 80, double centerX = 0, double centerY = 0)
        {
            Part dummyPart = new Part();
            dummyPart.Designator = "GL0";
            dummyPart.MachineDescription = "Nozzle Change Dummy Part";
            dummyPart.Head = head;
            dummyPart.CenterX= centerX;
            dummyPart.CenterY= centerY;
            dummyPart.Rotation = 0;
            dummyPart.FeederNumber = FeederNum;
            dummyPart.PickHeight = 10;
            dummyPart.PlaceHeight = 0;
            dummyPart.PartHeight = 10;
            dummyPart.Mode = PlacementMode.Blind;
            dummyPart.Layer = PcbLayer.TOP;
            dummyPart.LibPartNumber = "NONE";
            dummyPart.PartNumber = "NONE";
            dummyPart.PackageName = "DUMMY PART";
            dummyPart.Skip = false;
            return dummyPart;
        }

        public static string PadNumbers(string input)
        {
            return Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(10, '0'));
        }

        public static bool GroupPartsWithNozzles(this Project project, out List<Part>[] Nozzles)
        {
            bool valid = true;
            List<Part>[] NozzleUse = new List<Part>[Enum.GetNames(typeof(NeodenNozzles)).Length];
            for (int i = 0; i < NozzleUse.Length; i++)
            {
                NozzleUse[i] = new List<Part>();
            }
            Nozzles = NozzleUse;
            List<NeodenNozzles> nozzles = new List<NeodenNozzles>();

            if (project.NozzleSet.Head1 > 0) nozzles.Add(project.NozzleSet.Head1);
            if (project.NozzleSet.Head2 > 0) nozzles.Add(project.NozzleSet.Head2);
            if (project.NozzleSet.Holder1 > 0) nozzles.Add(project.NozzleSet.Holder1);
            if (project.NozzleSet.Holder2 > 0) nozzles.Add(project.NozzleSet.Holder2);

            foreach (Part part in project.Parts)
            {
                if (part.Skip || part.Layer != PcbLayer.TOP)
                {
                    continue;
                }
                else
                {
                    if (nozzles.Contains(part.OptimalNozzle))
                    {
                        NozzleUse[(int)part.OptimalNozzle].Add(part);
                    }
                    else if (nozzles.Contains(part.AlternateNozzle))
                    {
                        NozzleUse[(int)part.AlternateNozzle].Add(part);
                    }
                    else if (part.OptimalNozzle != NeodenNozzles.Unset)
                    {
                        valid = false;
                        NozzleUse[(int)part.OptimalNozzle].Add(part);
                    }

                }

            }
            return valid;
        }

        public static string GetNeodenHeader()
        {
            return "NEODEN,YY1,P&P FILE,,,,,,,,,,";
        }
        public static string GetNeodenBlankRow()
        {
            return ",,,,,,,,,,,,";
        }
        public static string GetNeodenFiducialRow()
        {
            return "Fiducial,1-X,0,1-Y,0,OverallOffsetX,0.0,OverallOffsetY,0.0,,,,";
        }
        
        public static string GetPnPLines(this Project project, out List<NozzleChange> NozzleChanges)
        {
            List<Part>[] parts;
            project.GroupPartsWithNozzles(out parts);
            NozzleChanges = new List<NozzleChange>();
            if (!project.GroupPartsWithNozzles(out _))
            {
                throw new Exception("The project contains unplacable parts due to the current nozzle selections. Check and update nozzle settings");
            }
            NozzleTracker nozzleTracker = new NozzleTracker(project.NozzleSet.GetLocationsList());
            List<PhysicalNozzle>? HeadNozzles = nozzleTracker.GetHeadNozzles();
            if (HeadNozzles == null)
            {
                throw new Exception("No Head Nozzles specified. Check and correct nozzles settings");
            }

            StringBuilder partsCsv = new StringBuilder();
            partsCsv.AppendLine("Designator,Comment,Footprint,Mid X(mm),Mid Y(mm) ,Rotation,Head ,FeederNo,Mount Speed(%),Pick Height(mm),Place Height(mm),Mode,Skip");
            int PartCount = 1;

            //Check heads and select initial set of parts, group parts by feeder location
            bool sameHead;
            List<Part> evenParts = new List<Part>();
            List<Part> oddParts = new List<Part>();
            if (HeadNozzles.Count == 1)
            {
                sameHead = false;
                evenParts = parts[(int)HeadNozzles[0].Nozzle].OrderBy(part => part.FeederNumber).ToList();
                oddParts = new List<Part>();
            }
            else
            {
                sameHead = HeadNozzles[0].Nozzle == HeadNozzles[1].Nozzle;
                evenParts = parts[(int)HeadNozzles[0].Nozzle].OrderBy(part => part.FeederNumber).ToList();
                oddParts = parts[(int)HeadNozzles[1].Nozzle].OrderBy(part => part.FeederNumber).ToList();
            }
            bool doubleHead;
            int limit = 0;

            //Iterate until all parts placed, each loop completes when one or both head nozzles have placed all available parts
            while (parts.Any(parts => parts.Count > 0))
            {
                //If parts remaining, do nozzle switch and loop
                //When out of parts for a head, select new nozzle by most parts
                //If initial head nozzle has no parts, switch out for a nozzle that does have parts
                List<PhysicalNozzle>? stationNozzles = nozzleTracker.GetStationNozzles();
                if ((sameHead && evenParts.Count == limit) || (evenParts.Count == limit && oddParts.Count == limit))
                {
                    int head_index = 0;
                    //Change both heads
                    bool second_change = false;
                    foreach (PhysicalNozzle nozzle in stationNozzles)
                    {
                        if (parts[(int)nozzle.Nozzle].Count > 0)
                        {
                            if (second_change)
                            {
                                //Insert dummy part so nozzle change actually happens
                                Part dummyPart = ProjectExtensionMethods.GetDummyPart((PlacementHead)HeadNozzles[head_index].Nozzle);
                                partsCsv.AppendLine(dummyPart.ToCsvLine(project.Pcb));
                                PartCount++;
                            }
                            NozzleChange nozzleChange = nozzleTracker.GetNozzleChange(HeadNozzles[head_index].Nozzle, nozzle.Nozzle, PartCount);
                            if (nozzleChange != null)
                            {
                                NozzleChanges.Add(nozzleChange);
                                head_index++;
                                second_change = true;
                            }
                            else
                            {
                                throw new Exception("Nozzle change failed!");
                            }
                        }
                    }
                }
                else if (evenParts.Count == limit)
                {
                    //change head[0]
                    int max_parts = 0;
                    NeodenNozzles NozzleToChange = NeodenNozzles.Unset;
                    foreach (PhysicalNozzle nozzle in stationNozzles)
                    {
                        if (parts[(int)nozzle.Nozzle].Count > max_parts)
                        {
                            max_parts = parts[(int)nozzle.Nozzle].Count;
                            NozzleToChange = nozzle.Nozzle;
                        }
                    }
                    if (max_parts > 0)
                    {
                        NozzleChange nozzleChange = nozzleTracker.GetNozzleChange(HeadNozzles[0].Nozzle, NozzleToChange, PartCount);
                        if (nozzleChange != null)
                        {
                            NozzleChanges.Add(nozzleChange);
                        }
                        else
                        {
                            throw new Exception("Nozzle change failed!");
                        }
                    }

                }
                else if (oddParts.Count == limit)
                {
                    //change head[1]
                    int max_parts = 0;
                    NeodenNozzles NozzleToChange = NeodenNozzles.Unset;
                    foreach (PhysicalNozzle nozzle in stationNozzles)
                    {
                        if (parts[(int)nozzle.Nozzle].Count > max_parts)
                        {
                            max_parts = parts[(int)nozzle.Nozzle].Count;
                            NozzleToChange = nozzle.Nozzle;
                        }
                    }
                    if (max_parts > 0)
                    {
                        if (max_parts > 0)
                        {
                            NozzleChange nozzleChange = nozzleTracker.GetNozzleChange(HeadNozzles[1].Nozzle, NozzleToChange, PartCount);
                            if (nozzleChange != null)
                            {
                                NozzleChanges.Add(nozzleChange);
                            }
                            else
                            {
                                throw new Exception("Nozzle change failed!");
                            }
                        }
                    }
                }
                else if (limit == 0)
                {
                    //Continue, first loop and no nozzles changes were needed
                }
                else
                {
                    throw new Exception("Should not be here, part placement stopped before end");
                }

                //Get New head set and list(s) of parts to place on this iteration
                HeadNozzles = nozzleTracker.GetHeadNozzles();
                //Setup pick list
                if (HeadNozzles.Count == 1)
                {
                    sameHead = false;
                    evenParts = parts[(int)HeadNozzles[0].Nozzle].OrderBy(part => part.FeederNumber).ToList();
                    oddParts = new List<Part>();
                }
                else
                {
                    sameHead = HeadNozzles[0].Nozzle == HeadNozzles[1].Nozzle;
                    evenParts = parts[(int)HeadNozzles[0].Nozzle].OrderBy(part => part.FeederNumber).ToList();
                    oddParts = parts[(int)HeadNozzles[1].Nozzle].OrderBy(part => part.FeederNumber).ToList();
                }

                if (sameHead)
                {
                    limit = evenParts.Count;
                    doubleHead = true;
                }
                else
                {
                    if (evenParts.Count == 0 || oddParts.Count == 0)
                    {
                        doubleHead = false;
                        if (evenParts.Count < oddParts.Count) limit = oddParts.Count;
                        else limit = evenParts.Count;
                    }
                    else
                    {
                        doubleHead = true;
                        if (evenParts.Count > oddParts.Count) limit = oddParts.Count;
                        else limit = evenParts.Count;
                    }

                }

                //Place Parts
                for (int i = 0; i < limit; i++)
                {
                    if (sameHead)
                    {
                        evenParts[i].Head = PlacementHead.Both;
                        evenParts[i].PlacementOrder = PartCount;
                        partsCsv.AppendLine(evenParts[i].ToCsvLine(project.Pcb));
                        parts[(int)HeadNozzles[0].Nozzle].Remove(evenParts[i]);
                        PartCount++;
                    }
                    else if (doubleHead)
                    {
                        evenParts[i].Head = (PlacementHead)HeadNozzles[0].Location;
                        evenParts[i].PlacementOrder = PartCount;
                        partsCsv.AppendLine(evenParts[i].ToCsvLine(project.Pcb));
                        parts[(int)HeadNozzles[0].Nozzle].Remove(evenParts[i]);
                        PartCount++;

                        oddParts[i].Head = (PlacementHead)HeadNozzles[1].Location;
                        oddParts[i].PlacementOrder = PartCount;
                        partsCsv.AppendLine(oddParts[i].ToCsvLine(project.Pcb));
                        parts[(int)HeadNozzles[1].Nozzle].Remove(oddParts[i]);
                        PartCount++;
                    }
                    //Single Pick mode, intended for finishing out builds
                    else
                    {
                        if (evenParts.Count > 0)
                        {
                            evenParts[i].Head = (PlacementHead)HeadNozzles[0].Location;
                            evenParts[i].PlacementOrder = PartCount;
                            partsCsv.AppendLine(evenParts[i].ToCsvLine(project.Pcb));
                            parts[(int)HeadNozzles[0].Nozzle].Remove(evenParts[i]);
                            PartCount++;
                        }
                        else
                        {
                            oddParts[i].Head = (PlacementHead)HeadNozzles[1].Location;
                            oddParts[i].PlacementOrder = PartCount;
                            partsCsv.AppendLine(oddParts[i].ToCsvLine(project.Pcb));
                            parts[(int)HeadNozzles[1].Nozzle].Remove(oddParts[i]);
                            PartCount++;
                        }
                    }
                }


            }

            if (NozzleChanges.Count > 0)
            {
                //Reverse part changes so machine is in original state at end
                for (int i = NozzleChanges.Count - 1; i >= 0; i--)
                {
                    //NozzleChange dummy = nozzleTracker.GetNozzleChange(NozzleChanges[i].NextNozzleRef, NozzleChanges[i].HeadNozzleRef, PartCount);
                    NozzleChange dummy = new NozzleChange
                    {
                        Head = NozzleChanges[i].Head,
                        DropStation = NozzleChanges[i].PickStation,
                        PickStation = NozzleChanges[i].DropStation,
                        BeforeComponant = PartCount,
                        Enabled = true
                    };
                    NozzleChanges.Add(dummy);
                    //Insert dummy part
                    Part dummyPart = ProjectExtensionMethods.GetDummyPart((PlacementHead)NozzleChanges[i].Head);
                    partsCsv.AppendLine(dummyPart.ToCsvLine(project.Pcb));
                    PartCount++;
                }
            }

            for (int i = 0; i < (4 - NozzleChanges.Count); i++)
            {
                NozzleChanges.Add(new NozzleChange
                {
                    Enabled = false,
                    Head = MachineNozzleLocations.Head1,
                    DropStation = MachineNozzleLocations.Station1,
                    PickStation = MachineNozzleLocations.Station2,
                    BeforeComponant = 0
                });
            }

            return partsCsv.ToString();
        }
    }
}
