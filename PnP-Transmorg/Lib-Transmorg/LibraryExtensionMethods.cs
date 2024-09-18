using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Transmorg
{
    public static class LibraryExtensionMethods
    {
        public readonly static string PartNumHeader = "Part Number";
        public readonly static string PackageHeader = "Package";
        public readonly static string OptNozzleHeader = "Optimal Nozzle";
        public readonly static string AltNozzleHeader = "Alternate Nozzle";
        public readonly static string StockHeader = "Stock";
        public readonly static string FeederHeader = "FeederNo";
        public readonly static string ModeHeader = "Mode";
        public readonly static string PickHeightHeader = "PickHeight";
        public readonly static string DescHeader = "Description";
        public readonly static string SpeedHeader = "PlacementSpeed";

        public static bool ImportCsv(this Library library, string csv)
        {
            bool result = false;
            List<LibPart> parts = new List<LibPart>();

            string[] lines = csv.Split(Environment.NewLine);

            int PartNumIndex = -1;
            int PackageIndex = -1;
            int OptIndex = -1;
            int AltIndex = -1;
            int StockIndex = -1;
            int FeederIndex = -1;
            int ModeIndex = -1;
            int PickHeightIndex = -1;
            int DescIndex = -1;
            int SpeedIndex = -1;
            string[]? header = lines[0].Split(',');
            if (header == null) return false;

            for(int i = 0; i< header.Length; i++)
            {
                if (header[i].Contains(PartNumHeader)) PartNumIndex = i;
                else if (header[i].Contains(PackageHeader)) PackageIndex = i;
                else if (header[i].Contains(OptNozzleHeader)) OptIndex = i;
                else if (header[i].Contains(AltNozzleHeader))  AltIndex = i;
                else if (header[i].Contains(StockHeader)) StockIndex = i;
                else if (header[i].Contains(FeederHeader)) FeederIndex = i;
                else if (header[i].Contains(ModeHeader)) ModeIndex = i;
                else if (header[i].Contains(PickHeightHeader)) PickHeightIndex = i;
                else if (header[i].Contains(DescHeader)) DescIndex = i;
                else if (header[i].Contains(SpeedHeader)) SpeedIndex = i;
            }
            if((PartNumIndex <0 )||
                (PackageIndex <0 ) ||
                (OptIndex <0 ) ||
                (AltIndex <0 ) ||
                (StockIndex <0 ) ||
                (FeederIndex <0 ) ||
                (ModeIndex <0 ) ||
                (PickHeightIndex <0 ) ||
                (DescIndex <0 ))
            {
                string errorMsg = string.Format("Expected header(s) not parsed. Check csv mapping and header offset. " +
                    "Indexes found (-1 indicates not found) -> PartNumber Index {0} Package Index: {1} Optimal Nozzle Index: {2} Alternate Nozzle Index: {3} Stock Index: {4} Feeder Index: {5} Mode Index: {6} Pick Height Index: {7}, Description Index: {8}",
                    PartNumIndex, PackageIndex, OptIndex, AltIndex, StockIndex, FeederIndex, ModeIndex, PickHeightIndex, DescIndex);
                throw new FormatException(errorMsg);
            }
            int line_count = 2;
            for(int i = 1; i<lines.Length; i++)
            {
                if (!lines[i].Contains(","))
                {
                    continue;
                }
                string[]? line = lines[i].Split(',');
                if (line == null ) return false;
                LibPart part = new LibPart();
                try
                {
                    part.PartNumber = line[PartNumIndex];
                    part.Package = line[PackageIndex];
                    part.OptimalNozzle = (NeodenNozzles)Enum.Parse(typeof(NeodenNozzles), line[OptIndex]);
                    part.AlternateNozzle = (NeodenNozzles)Enum.Parse(typeof(NeodenNozzles), line[AltIndex]);
                    part.Stock = int.Parse(line[StockIndex]);
                    part.FeederNumber = int.Parse(line[FeederIndex]);
                    part.PickHeight = double.Parse(line[PickHeightIndex]);
                    part.Mode = (PlacementMode)int.Parse(line[ModeIndex]);
                    part.Description = line[DescIndex];
                    if (SpeedIndex != -1)
                    {
                        part.PlacementSpeed = int.Parse(line[SpeedIndex]);
                        if (part.PlacementSpeed < 0) part.PlacementSpeed = 100;
                        else if (part.PlacementSpeed < 5) part.PlacementSpeed = 5;
                        else if (part.PlacementSpeed > 100) part.PlacementSpeed = 100;
                        {
                            
                        }
                    }
                    else
                    {
                        part.PlacementSpeed = 100;
                    }
                    parts.Add(part);
                }
                catch (Exception e)
                {
                    throw new Exception("Parsing exception at library CSV line" + line_count.ToString() +". Inner exception: " + e.ToString());
                }
                line_count++;
            }
            result = true;
            
            if (result)
            {
                library.LibParts = parts;
            }

            return result;
        }

        public static bool LoadLibraryFile(this Library library, string path)
        {
            if (!File.Exists(path))
            {
                return false;
            }
            string csv;
            using (var fstream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(fstream))
            csv = reader.ReadToEnd();
            bool result = library.ImportCsv(csv);
            if (result)
            {
                library.PartLibraryPath = path;
                library.Name = Path.GetFileName(path);
            }
            return result;
            
        }
    }
}
