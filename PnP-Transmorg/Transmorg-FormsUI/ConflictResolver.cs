using Lib_Transmorg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transmorg_FormsUI
{
    public partial class ConflictResolver : Form
    {
        public List<Conflict> conflicts = null;
        public Project project = null;
        public bool PartChangeMode = false;
        private List<LibPart> Options;
        private int Option_Index = 0;
        public int Conflict_Index = 0;
        bool ShowLibraryOptions = false;
        public bool ChangesMade = false;
        public ConflictResolver()
        {
            InitializeComponent();
            Options = new List<LibPart>();
        }

        private void cb_SkipPart_CheckedChanged(object sender, EventArgs e)
        {
            gb_LibOption.Enabled = !cb_SkipPart.Checked;
            btn_ShowLibrary.Enabled = !cb_SkipPart.Checked;
            btn_libLast.Enabled = !cb_SkipPart.Checked;
            btn_libNext.Enabled = !cb_SkipPart.Checked;
            cb_LibOptions.Enabled = !cb_SkipPart.Checked;
            if (!cb_SkipPart.Checked)
            {
                if (!(Options.Count > 0))
                {
                    ShowLibraryOptions = true;
                    ToggleShowLibraryOptions(ShowLibraryOptions);
                }
            }
        }

        private void ConflictResolver_Load(object sender, EventArgs e)
        {
            if (PartChangeMode)
            {
                this.Text = "Part Changer";
                btn_ShowLibrary.Visible = false;
                groupBox1.Text = "Part Changer";
                conflicts = new List<Conflict>();
                foreach (Part part in project.Parts)
                {
                    conflicts.Add(new ChangePart
                    {
                        Part = part,
                        SkipAsSolution = part.Skip,
                        LibOptions = project.Library.LibParts
                    });
                }
            }

            conflicts.RemoveAll(item => item == null);
            if (conflicts.Count > 0)
            {
                PopulateConflictDropDown();
                //CycleConflict();
            }
            else
            {
                this.Close();
            }
        }

        private void PopulateConflictDropDown()
        {
            cb_ConflictSelector.Items.Clear();
            for (int i = 0; i < conflicts.Count; i++)
            {
                cb_ConflictSelector.Items.Add(conflicts[i].Part.Designator + " - " + (i + 1).ToString());
            }
            cb_ConflictSelector.SelectedIndex = Conflict_Index;
        }

        private void CycleConflict()
        {
            tb_ConflictCounter.Text = (Conflict_Index + 1).ToString() + "/" + conflicts.Count.ToString();

            Options = new List<LibPart>();
            if (conflicts[Conflict_Index].GetType() == typeof(MultipleOptions) || conflicts[Conflict_Index].GetType() == typeof(ChangePart))
            {
                Options.AddRange(((MultipleOptions)conflicts[Conflict_Index]).LibOptions);
            }
            else if (conflicts[Conflict_Index].Solution != null)
            {
                Options.Add(conflicts[Conflict_Index].Solution);
            }
            cb_LibOptions.Items.Clear();
            for (int i = 0; i < Options.Count; i++)
            {
                cb_LibOptions.Items.Add(Options[i].PartNumber + " - " + (i + 1).ToString());
            }

            tb_conflictType.Text = conflicts[Conflict_Index].GetType().Name;

            //Populate Part Info
            tb_PartDesig.Text = conflicts[Conflict_Index].Part.Designator;
            tb_PartNum.Text = conflicts[Conflict_Index].Part.PartNumber;
            tb_PartLibPartNum.Text = conflicts[Conflict_Index].Part.LibPartNumber;
            tb_designDesc.Text = conflicts[Conflict_Index].Part.DesignDescription;
            tb_assignedLibPartDesc.Text = conflicts[Conflict_Index].Part.MachineDescription;
            tb_PartFeederNum.Text = conflicts[Conflict_Index].Part.FeederNumber.ToString();
            tb_PartHeight.Text = conflicts[Conflict_Index].Part.PlaceHeight.ToString("N2") + "mm";
            tb_PlaceX.Text = conflicts[Conflict_Index].Part.CenterX.ToString("N4") + "mm";
            tb_PlaceY.Text = conflicts[Conflict_Index].Part.CenterY.ToString("N4") + "mm";
            tb_Rotation.Text = conflicts[Conflict_Index].Part.Rotation.ToString();

            cb_SkipPart.Checked = conflicts[Conflict_Index].Part.Skip;

            //Populate Library Option Info
            Option_Index = 0;
            cb_LibOptions.Text = string.Empty;
            if (Options.Count > 0)
            {
                cb_LibOptions.SelectedIndex = Option_Index;
                cb_SkipPart.Enabled = true;
            }
            else
            {
                CycleOption();
                cb_SkipPart.Enabled = false;
            }
        }

        private void CycleOption()
        {
            if (Options.Count > 0)
            {
                if (Options.Count == 1)
                {
                    tb_LibOptionCount.Text = "1/1";
                    btn_libNext.Enabled = false;
                    btn_libLast.Enabled = false;
                }
                else
                {
                    tb_LibOptionCount.Text = (Option_Index + 1).ToString() + "/" + Options.Count.ToString();
                    btn_libNext.Enabled = true;
                    btn_libLast.Enabled = true;
                }
                if (Option_Index >= Options.Count)
                {
                    Option_Index = Options.Count - 1;
                }
                if (Options[Option_Index] != null)
                {
                    tb_libOptionPartNum.Text = Options[Option_Index].PartNumber;
                    tb_libPartDesc.Text = Options[Option_Index].Description;
                    tb_LibPackage.Text = Options[Option_Index].Package;
                    tb_LibFeeder.Text = Options[Option_Index].FeederNumber.ToString();
                    tb_LibPickHeight.Text = Options[Option_Index].PickHeight.ToString() + "mm";
                    tb_libOptNozzleSize.Text = Options[Option_Index].OptimalNozzle.ToString();
                    tb_LibAltNozzleSize.Text = Options[Option_Index].AlternateNozzle.ToString();
                    tb_libPlacementMode.Text = Options[Option_Index].Mode.ToString();
                }
                else
                {
                    tb_libOptionPartNum.Text = "";
                    tb_libPartDesc.Text = "";
                    tb_LibPackage.Text = "";
                    tb_LibFeeder.Text = "";
                    tb_LibPickHeight.Text = "";
                    tb_libOptNozzleSize.Text = "";
                    tb_LibAltNozzleSize.Text = "";
                    tb_libPlacementMode.Text = "";
                }
            }
            else
            {
                tb_LibOptionCount.Text = "";
                btn_libNext.Enabled = false;
                btn_libLast.Enabled = false;

                tb_libOptionPartNum.Text = "";
                tb_libPartDesc.Text = "";
                tb_LibPackage.Text = "";
                tb_LibFeeder.Text = "";
                tb_LibPickHeight.Text = "";
                tb_libOptNozzleSize.Text = "";
                tb_LibAltNozzleSize.Text = "";
                tb_libPlacementMode.Text = "";
            }
        }

        private void btn_last_Click(object sender, EventArgs e)
        {
            if (conflicts.Count > 0)
            {
                Conflict_Index--;
                if (Conflict_Index < 0)
                {
                    Conflict_Index = conflicts.Count - 1;
                }
            }
            else
            {
                Conflict_Index = 0;
            }
            ShowLibraryOptions = false;
            btn_ShowLibrary.Text = "Pick From Library";
            cb_ConflictSelector.SelectedIndex = Conflict_Index;
            //CycleConflict();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (conflicts.Count > 0)
            {
                Conflict_Index++;
                if (Conflict_Index >= conflicts.Count)
                {
                    Conflict_Index = 0;
                }
            }
            else
            {
                Conflict_Index = 0;
            }
            ShowLibraryOptions = false;
            btn_ShowLibrary.Text = "Pick From Library";
            cb_ConflictSelector.SelectedIndex = Conflict_Index;
            //CycleConflict();
        }

        private void btn_libLast_Click(object sender, EventArgs e)
        {
            if (Options.Count > 0)
            {
                Option_Index--;
                if (Option_Index < 0)
                {
                    Option_Index = Options.Count - 1;
                }
            }
            else
            {
                Option_Index = 0;
            }
            if (Options.Count > 0)
            {
                cb_LibOptions.SelectedIndex = Option_Index;
            }
            else
            {
                CycleOption();
            }
        }

        private void btn_libNext_Click(object sender, EventArgs e)
        {
            if (Options.Count > 0)
            {
                Option_Index++;
                if (Option_Index >= Options.Count)
                {
                    Option_Index = 0;
                }
            }
            else
            {
                Option_Index = 0;
            }
            if (Options.Count > 0)
            {
                cb_LibOptions.SelectedIndex = Option_Index;
            }
            else
            {
                CycleOption();
            }
        }

        private void btn_ShowLibrary_Click(object sender, EventArgs e)
        {
            ShowLibraryOptions = !ShowLibraryOptions;
            ToggleShowLibraryOptions(ShowLibraryOptions);
        }

        private void ToggleShowLibraryOptions(bool show)
        {
            if (show)
            {
                int suggested_count = Options.Count;
                Options.Clear();
                Options.AddRange(project.Library.LibParts);
                cb_LibOptions.Items.Clear();
                for (int i = 0; i < Options.Count; i++)
                {
                    cb_LibOptions.Items.Add(Options[i].PartNumber + " - " + (i + 1).ToString());
                }
                Option_Index = 0;
                cb_LibOptions.SelectedIndex = Option_Index;
                //CycleOption();
                if (suggested_count > 0)
                {
                    btn_ShowLibrary.Text = "Pick From Suggested";
                }
                else
                {
                    btn_ShowLibrary.Text = "Pick From Library";
                    btn_ShowLibrary.Enabled = false;
                }

            }
            else
            {
                Options.Clear();
                CycleConflict();
                btn_ShowLibrary.Text = "Pick From Library";
            }
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            ChangesMade = true;
            List<Part> parts = project.Parts.FindAll(s => s.PartNumber == conflicts[Conflict_Index].Part.PartNumber).ToList();
            if (cb_applyAll.Checked)
            {
                foreach (Part part in parts)
                {
                    if (cb_SkipPart.Checked)
                    {
                        part.Skip = true;
                    }
                    else
                    {
                        part.ApplyLibPart(Options[Option_Index]);
                    }

                }
                if (!PartChangeMode)
                {
                    conflicts.RemoveAll(s => s.Part.PartNumber == conflicts[Conflict_Index].Part.PartNumber);
                }
            }
            else
            {
                //This shouldn't ever be null, if it is something really got screwed up in the project or project file
                Part? part = parts.FindAll(s => s.Designator == conflicts[Conflict_Index].Part.Designator).FindAll(s => s.CenterX == conflicts[Conflict_Index].Part.CenterX).Find(s => s.CenterY == conflicts[Conflict_Index].Part.CenterY);
                if (cb_SkipPart.Checked)
                {
                    part.Skip = true;
                }
                else
                {
                    part.ApplyLibPart(Options[Option_Index]);
                }
                if (!PartChangeMode)
                {
                    conflicts.RemoveAt(Conflict_Index);
                }
            }
            if (!PartChangeMode)
            {
                Conflict_Index--;
                if (Conflict_Index >= conflicts.Count)
                {
                    Conflict_Index = conflicts.Count - 1;
                }
                else if (Conflict_Index < 0)
                {
                    Conflict_Index = 0;
                }
                if (conflicts.Count <= 0)
                {
                    MessageBox.Show("All conflicts resolved!", "Conflicts resolved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    PopulateConflictDropDown();
                }
            }
            else
            {
                CycleConflict();
            }
        }

        private void cb_ConflictSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conflict_Index = cb_ConflictSelector.SelectedIndex;
            CycleConflict();
        }

        private void cb_LibOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            Option_Index = cb_LibOptions.SelectedIndex;
            CycleOption();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
