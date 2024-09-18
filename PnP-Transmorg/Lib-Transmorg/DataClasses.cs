using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;

namespace Lib_Transmorg
{
    /// <summary>
    /// IMPORTANT: all coordinates and dimensions should be asumed to be mm and degrees
    /// </summary>

    public enum NeodenNozzles
    {
        Unset = -1,
        None = 0,
        CN030 = 1,
        CN040 = 2,
        CN065 = 3,
        CN100 = 4,
        CN140 = 5,
        CN220 = 6,
        CN400 = 7,
        CN750 = 8,
        YX01 = 9,
        YX02 = 10,
        YX03 = 11,
        YX04 = 12,
        YX05 = 13,
        YX06 = 14,
        YXOther = 15
    }

    public enum MachineNozzleLocations
    {
        Head1=1,
        Head2=2,
        Station1,
        Station2,
        Station3
    }

    public class NozzleChange
    {
        public MachineNozzleLocations Head;
        public MachineNozzleLocations DropStation;
        public MachineNozzleLocations PickStation;
        //public NeodenNozzles HeadNozzleRef;
        //public NeodenNozzles NextNozzleRef;
        public bool Enabled = false;
        public int BeforeComponant;
        public string ToCsvLine()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("NozzleChange,");
            if(Enabled) sb.Append("ON,");
            else sb.Append("OFF,");
            sb.Append("BeforeComponent," + BeforeComponant.ToString() + ",");
            sb.Append(Head.ToString() + ",");
            sb.Append("Drop," + DropStation.ToString() + ",");
            sb.Append("PickUp," + PickStation.ToString() + ",,,,");
            return sb.ToString();
        }
    }

    public class PhysicalNozzle
    {
        public NeodenNozzles Nozzle;
        public MachineNozzleLocations Location;
    }

    public class NozzleTracker
    {
        List<PhysicalNozzle> Nozzles;
        public NozzleTracker(List<PhysicalNozzle> Nozzles)
        {
            this.Nozzles = Nozzles;
        }

        public List<PhysicalNozzle>? GetHeadNozzles()
        {
            List<PhysicalNozzle> HeadNozzles =  new List<PhysicalNozzle>();
            HeadNozzles.Add(Nozzles.First(item => item.Location == MachineNozzleLocations.Head1));
            HeadNozzles.Add(Nozzles.First(item => item.Location == MachineNozzleLocations.Head2));
            if (HeadNozzles.Any(item => item == null)) return null;
            else return HeadNozzles;
        }

        public List<PhysicalNozzle>? GetStationNozzles()
        {
            List<PhysicalNozzle> StationNozzles = new List<PhysicalNozzle>();
            StationNozzles.Add(Nozzles.First(item => item.Location == MachineNozzleLocations.Station1));
            StationNozzles.Add(Nozzles.First(item => item.Location == MachineNozzleLocations.Station2));
            StationNozzles.Add(Nozzles.First(item => item.Location == MachineNozzleLocations.Station3));
            StationNozzles.RemoveAll(item => item.Nozzle == NeodenNozzles.None);
            StationNozzles.RemoveAll(item => item.Nozzle == NeodenNozzles.Unset);
            return StationNozzles;
        }

        public NozzleChange? GetNozzleChange(NeodenNozzles currentNozzle, NeodenNozzles nextNozzle, int beforeComponant)
        {
            MachineNozzleLocations currentLocation = Nozzles.First(item => item.Nozzle == currentNozzle && item.Location<=MachineNozzleLocations.Head2).Location;
            MachineNozzleLocations nextLocation = Nozzles.First(item => item.Nozzle == nextNozzle && item.Location>=MachineNozzleLocations.Station1).Location;
            //if(currentLocation == nextLocation) return null;
            //if(currentLocation != MachineNozzleLocations.Head1 ||  currentLocation != MachineNozzleLocations.Head2) return null;
            MachineNozzleLocations dropLocation = Nozzles.First(item => item.Nozzle == NeodenNozzles.None).Location;
            if(dropLocation == MachineNozzleLocations.Head1 ||  dropLocation == MachineNozzleLocations.Head2) { return null; }
            NozzleChange nozzleChange = new NozzleChange
            {
                Head = currentLocation,
                DropStation = dropLocation,
                PickStation = nextLocation,
                BeforeComponant = beforeComponant,
                Enabled = true
                //HeadNozzleRef = currentNozzle,
                //NextNozzleRef = nextNozzle
            };

            Nozzles.First(item => item.Location == currentLocation).Location = dropLocation;
            Nozzles.First(item => item.Location == nextLocation).Location = currentLocation;
            Nozzles.First(item => item.Nozzle == NeodenNozzles.None).Location = nextLocation;

            return nozzleChange;
        }
    }


    public class InputCsvMapping
    {
        public bool QuotedValues { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LinesToSkip { get; set; }
        public string DesignatorHeader { get; set; }
        public string DesignDescriptionHeader { get; set; }
        public string PartNumHeader { get; set; }
        public string MidXHeader { get; set; }
        public string MidYHeader { get; set; }
        public string RotationHeader { get; set; }
        public string HeightHeader { get; set; }
        public string LayerHeader { get; set; }
        public double XCenterOffset { get; set; }
        public double YCenterOffset { get; set; }
        
        public InputCsvMapping()
        {
            Name = string.Empty;
            Description = string.Empty;
            LinesToSkip = 0;
            DesignatorHeader = string.Empty;
            DesignDescriptionHeader = string.Empty;
            PartNumHeader = string.Empty;
            MidXHeader = string.Empty;
            MidYHeader = string.Empty;
            RotationHeader = string.Empty;
            HeightHeader = string.Empty;
            LayerHeader = string.Empty;
            XCenterOffset = 0;
            YCenterOffset = 0;
        }
    }

    public enum MachineHead
    {
        Head1,
        Head2,
        Holder1,
        Holder2
    }

    public class NeodenNozzleSet
    {
        public string Name { get; set; }
        public NeodenNozzles Head1 { get; set; }
        public NeodenNozzles Head2 { get; set; }
        public NeodenNozzles Holder1 { get; set; }
        public NeodenNozzles Holder2 { get; set; }
        public NeodenNozzleSet()
        {
            Name = string.Empty;
        }

        public List<PhysicalNozzle> GetLocationsList()
        {
            List<PhysicalNozzle> locations = new List<PhysicalNozzle>();
            locations.Add(new PhysicalNozzle
            {
                Location = MachineNozzleLocations.Head1,
                Nozzle = Head1
            });
            locations.Add(new PhysicalNozzle
            {
                Location = MachineNozzleLocations.Head2,
                Nozzle = Head2
            });
            locations.Add(new PhysicalNozzle
            {
                Location = MachineNozzleLocations.Station1,
                Nozzle = Holder1
            });
            locations.Add(new PhysicalNozzle
            {
                Location = MachineNozzleLocations.Station2,
                Nozzle = Holder2
            });
            locations.Add(new PhysicalNozzle
            {
                Location = MachineNozzleLocations.Station3,
                Nozzle = NeodenNozzles.None
            });
            return locations;
        }
    }

    public enum PcbLayer
    {
        TOP,
        BOTTOM
    }

    public enum PlacementHead
    {
        Unset = -1,
        Both = 0,
        Head1 = 1,
        Head2 = 2,
    }

    public enum PlacementMode
    {
        Unset = -1,
        Blind = 0,
        Camera = 1,
        Vacuum = 2,
        CamAndVac = 3,
        BigIcCam = 4
    }

    public enum DoublePick
    {
        Never,
        SameHeadOnly,
        AllowMixedHeads
    }

    public class Part
    {
        public string PartNumber { get; set; }
        public string LibPartNumber { get; set; }
        public string Designator { get; set; }
        public string MachineDescription { get; set; }
        public string DesignDescription { get; set; }
        public string PackageName { get; set; }
        public PcbLayer Layer { get; set; }
        public NeodenNozzles OptimalNozzle { get; set; }
        public NeodenNozzles AlternateNozzle { get; set; }
        public PlacementHead Head { get; set; }
        public PlacementMode Mode { get; set; }
        public int PlacementOrder { get; set; }
        public int PlacementSpeed { get; set; }
        public double CenterX { get; set; }
        public double CenterY { get; set; }
        public double Rotation { get; set; } //Maybe this can be an int?
        public double PartHeight { get; set; }
        public double PickHeight { get; set; }
        public double PlaceHeight { get; set;}
        public int FeederNumber { get; set; }
        public bool Skip { get; set; }

        public Part()
        {
            PartNumber = string.Empty;
            LibPartNumber = string.Empty;
            Designator = string.Empty;
            MachineDescription = string.Empty;
            DesignDescription = string.Empty;
            PackageName = string.Empty;
            FeederNumber = -1;
            OptimalNozzle = NeodenNozzles.Unset;
            AlternateNozzle = NeodenNozzles.Unset;
        }

        public string ToCsvLine(Pcb pcb)
        {
            var sb = new StringBuilder();
            sb.Append(Designator + "," +MachineDescription + "," + PackageName + ",");
            double centerX_tf;
            double centerY_tf;
            if(pcb.PanelRailY > 0)
            {
                centerX_tf = CenterX + pcb.PanelRailY + pcb.PanelMouseBiteX;
            }
            else
            {
                centerX_tf = CenterX;
            }
            if(pcb.PanelRailX > 0)
            {
                centerY_tf = CenterY + pcb.PanelRailX + pcb.PanelMouseBiteY;
            }
            else
            {
                centerY_tf = CenterY;
            }
            //Placement speed sanity checks
            if (PlacementSpeed <= 0) PlacementSpeed = 100;
            else if (PlacementSpeed < 5) PlacementSpeed = 5;
            else if (PlacementSpeed > 100) PlacementSpeed = 100;
            sb.Append(centerX_tf.ToString("N4") + "," + centerY_tf.ToString("N4") + ",");
            sb.Append(Rotation + ",");
            sb.Append(((int)Head).ToString() + "," + FeederNumber + "," + PlacementSpeed.ToString() + ",");
            sb.Append(PickHeight.ToString("N4") + "," + ((pcb.Thickness - 1.6 ) + PartHeight).ToString("N4") + ",");
            sb.Append(((int)Mode).ToString() + ",");
            if (Skip) sb.Append("1");
            else sb.Append("0");
            return sb.ToString();
        }

        public void ApplyLibPart(LibPart libpart)
        {
            LibPartNumber = libpart.PartNumber;
            MachineDescription = libpart.Description;
            PackageName = libpart.Package;
            OptimalNozzle = libpart.OptimalNozzle;
            AlternateNozzle = libpart.AlternateNozzle;
            FeederNumber = libpart.FeederNumber;
            Mode = libpart.Mode;
            PickHeight = libpart.PickHeight;
            MachineDescription = libpart.Description;
            PlacementSpeed = libpart.PlacementSpeed;
            Skip = false;
        }
    }

    public enum CompareStatus
    {
        Matches,
        MisMatch,
        BlankPart   //No Library part has been applied to a part yet
    }

    public class PartCompare
    {
        public CompareStatus Status { get; set; }
        public List<CompareMismatch> CompareMismatch { get; set; }

        public PartCompare(Part part, LibPart libPart)
        {
            CompareMismatch = new List<CompareMismatch>();
            if (part.MachineDescription == string.Empty || 
                part.PackageName == string.Empty ||
                part.OptimalNozzle == NeodenNozzles.Unset ||
                part.AlternateNozzle == NeodenNozzles.Unset ||
                part.FeederNumber == -1 ||
                part.Mode == PlacementMode.Unset
                )
            {
                Status = CompareStatus.BlankPart;
            }
            else
            {
                if (part.PartNumber != libPart.PartNumber)
                {
                    CompareMismatch.Add(new CompareMismatch()
                    {
                        Property = "Part Number",
                        PartExisting = part.PartNumber,
                        LibExisting = libPart.PartNumber
                    });
                }
                if (part.MachineDescription != libPart.Description)
                {
                    CompareMismatch.Add(new CompareMismatch()
                    {
                        Property = "Description",
                        PartExisting = part.MachineDescription,
                        LibExisting = libPart.Description
                    });
                }
                if (part.PackageName != libPart.Package)
                {
                    CompareMismatch.Add(new CompareMismatch()
                    {
                        Property = "Package",
                        PartExisting = part.PackageName,
                        LibExisting = libPart.Package
                    });
                }
                if (part.OptimalNozzle != libPart.OptimalNozzle)
                {
                    CompareMismatch.Add(new CompareMismatch()
                    {
                        Property = "Optimal Nozzle",
                        PartExisting = part.OptimalNozzle.ToString(),
                        LibExisting = libPart.OptimalNozzle.ToString()
                    });
                }
                if (part.AlternateNozzle != libPart.AlternateNozzle)
                {
                    CompareMismatch.Add(new CompareMismatch()
                    {
                        Property = "Alternate Nozzle",
                        PartExisting = part.AlternateNozzle.ToString(),
                        LibExisting = libPart.AlternateNozzle.ToString()
                    });
                }
                if (part.FeederNumber != libPart.FeederNumber)
                {
                    CompareMismatch.Add(new CompareMismatch()
                    {
                        Property = "Feeder Number",
                        PartExisting = part.FeederNumber.ToString(),
                        LibExisting= libPart.FeederNumber.ToString()
                    });
                }
                if(part.PickHeight != libPart.PickHeight)
                {
                    CompareMismatch.Add(new CompareMismatch()
                    {
                        Property = "Pick Height",
                        PartExisting = part.PickHeight.ToString("N4"),
                        LibExisting = libPart.PickHeight.ToString("N4")
                    });
                }
                if(part.PlacementSpeed != libPart.PlacementSpeed)
                {
                    CompareMismatch.Add(new CompareMismatch()
                    {
                        Property = "Placement Speed",
                        PartExisting = part.PlacementSpeed.ToString(),
                        LibExisting = libPart.PlacementSpeed.ToString()
                    });
                }
                if(CompareMismatch.Count != 0)
                {
                    Status = CompareStatus.Matches;
                }
                else
                {
                    Status = CompareStatus.MisMatch;
                }
            }
        }
    }

    public class CompareMismatch
    {
        public string Property { get; set; }
        public string PartExisting { get; set; }
        public string LibExisting { get; set; }
        public CompareMismatch()
        {
            Property = string.Empty;
            PartExisting = string.Empty;
            LibExisting = string.Empty;
        }
    }

    public class Pcb
    {
        public string Name { get; set; }
        public PcbLayer layer { get; set; }
        public double SizeX { get; set; }
        public double SizeY { get; set; }
        public double Thickness { get; set; }
        public double PanelRailX { get; set; }
        public double PanelRailY { get; set;}
        public double PanelMouseBiteX { get; set; }
        public double PanelMouseBiteY { get; set; }
        public bool Panalized { get; set; }
        public int PanelCountX { get; set; }
        public int PanelCountY { get; set; }
        public Pcb()
        {
            Name = string.Empty;
        }

        public string ToCsvLine()
        {
            if (!Panalized)
            {
                return "PanelizedPCB,UnitLength,0,UnitWidth,0,Rows,1,Columns,1,,,,";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("PanelizedPCB,UnitLength,");
                sb.Append((SizeX + PanelMouseBiteX).ToString());
                sb.Append(",UnitWidth,");
                sb.Append((SizeY + PanelMouseBiteY).ToString());
                sb.Append(",Rows,");
                sb.Append(PanelCountX).ToString();
                sb.Append(",Columns,");
                sb.Append(PanelCountY).ToString();
                sb.Append(",,,,");
                return sb.ToString();
            }
        }
    }

    public class LibPart
    {
        public string PartNumber { get; set; }
        public string Package { get; set; }
        public string Description { get; set; }
        public NeodenNozzles OptimalNozzle { get; set; }
        public NeodenNozzles AlternateNozzle { get; set; }
        public int Stock { get; set; }
        public int PlacementSpeed { get; set; }
        public int FeederNumber { get; set; }
        public double PickHeight { get; set; }
        public PlacementMode Mode { get; set; }

        public LibPart()
        {
            PartNumber = string.Empty;
            Package = string.Empty;
            Description = string.Empty;
        }
    }
    
    public class Library
    {
        public string Name { get; set; }
        public string PartLibraryPath { get; set; }
        public List<LibPart> LibParts { get; set; }
        public Library()
        {
            LibParts = new List<LibPart>();
            Name = string.Empty;
            PartLibraryPath = string.Empty;
        }
    }

    [JsonDerivedType(typeof(Conflict), typeDiscriminator: "baseConflict")]
    [JsonDerivedType(typeof(NotFound), typeDiscriminator: "notFound")]
    [JsonDerivedType(typeof(OverWrite), typeDiscriminator: "overWrite")]
    [JsonDerivedType(typeof(MultipleOptions), typeDiscriminator: "multipleOptions")]
    public class Conflict
    {
        public Part? Part { get; set; }
        public LibPart? Solution { get; set; }
        public bool SkipAsSolution { get; set; }

        public virtual bool ApplyResolution()
        {
            if(Part != null && Solution!= null)
            {
                if (SkipAsSolution)
                {
                    Part.Skip = true;
                }
                else
                {
                    Part.ApplyLibPart(Solution);
                }
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }

    public class NotFound : Conflict
    {

    }

    public class OverWrite : Conflict
    {
        public bool OverWriteExisting { get; set; }
        public PartCompare? CompareDetails { get; set; }
        //Should only be used when 
        public bool DoNothing { get; set; }

        public override bool ApplyResolution()
        {
            if (Part != null)
            {
                if (SkipAsSolution)
                {
                    Part.Skip = true;
                }
                else if (Solution != null && !DoNothing)
                {
                    Part.ApplyLibPart(Solution);
                    return true;
                }
                return DoNothing;
            }
            else
            {
                return false;
            }

        }
    }

   public class MultipleOptions : Conflict
    {
        public List<LibPart> LibOptions { get; set; }
        public MultipleOptions()
        {
            LibOptions = new List<LibPart>();
        }
    }

    public class ChangePart : MultipleOptions { }

    public partial class Project
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Library Library { get; set; }
        public Pcb Pcb { get; set; }
        public List<Part> Parts { get; set; }
        public List<Conflict> Conflicts { get; set; }
        public NeodenNozzleSet NozzleSet { get; set; }
        public Project()
        {
            Name = string.Empty;
            Description = string.Empty;
            Parts = new List<Part>();
            Pcb = new Pcb();
            Library = new Library();
            Conflicts = new List<Conflict>();
            NozzleSet = new NeodenNozzleSet();
        }
    }

}