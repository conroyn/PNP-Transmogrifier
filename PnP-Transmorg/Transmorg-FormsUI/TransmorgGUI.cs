using Lib_Transmorg;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using Transmorg_FormsUI.Properties;

namespace Transmorg_FormsUI
{
    public partial class TransmorgGUI : Form
    {

        public enum ProgramState
        {
            NoFilesOpen = 0,
            OnlySourcePnP,
            ProjectOpenNoChanges,
            ProjectChanged
        }

        public TransmorgGUI()
        {
            InitializeComponent();
            string[] args = Environment.GetCommandLineArgs();
            string path = string.Empty;
            foreach (string arg in args)
            {
                if (arg.ToLower().EndsWith(".tmog"))
                {
                    path = arg;
                    break;
                }
            }
            if (path != string.Empty)
            {
                OpenProjectOnStart(path);
            }
            //Enable double buffering to avoid aweful redraw speed
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dg_ProjectItems, new object[] { true });
        }

        Project project = new Project();
        //List<Conflict> conflicts = new List<Conflict>();
        ProgramState programState = ProgramState.NoFilesOpen;
        string projectPath = string.Empty;


        public void SetProgramState(ProgramState state)
        {
            programState = state;
            SetGuiState();
        }

        public void SetGuiState()
        {
            switch (programState)
            {
                case ProgramState.NoFilesOpen:
                    this.Text = "PnP Transmogrifier";
                    loadPnPCSVToolStripMenuItem.Enabled = true;
                    loadLibraryToolStripMenuItem.Enabled = false;
                    loadProjectToolStripMenuItem.Enabled = true;
                    projectSettingsToolStripMenuItem.Enabled = false;
                    saveProjectToolStripMenuItem.Enabled = false;
                    exportToolStripMenuItem.Enabled = false;
                    textBox1.Enabled = false;
                    break;
                case ProgramState.OnlySourcePnP:
                    this.Text = "PnP Transmogrifier - Unsaved New Project";
                    loadPnPCSVToolStripMenuItem.Enabled = true;
                    loadLibraryToolStripMenuItem.Enabled = true;
                    loadProjectToolStripMenuItem.Enabled = true;
                    projectSettingsToolStripMenuItem.Enabled = true;
                    saveProjectToolStripMenuItem.Enabled = true;
                    exportToolStripMenuItem.Enabled = false;
                    textBox1.Enabled = true;
                    break;
                case ProgramState.ProjectChanged:
                    this.Text = "PnP Transmogrifier - * " + projectPath;
                    loadPnPCSVToolStripMenuItem.Enabled = true;
                    loadLibraryToolStripMenuItem.Enabled = true;
                    loadProjectToolStripMenuItem.Enabled = true;
                    projectSettingsToolStripMenuItem.Enabled = true;
                    saveProjectToolStripMenuItem.Enabled = true;
                    exportToolStripMenuItem.Enabled = (project.Conflicts.Count == 0);
                    textBox1.Enabled = true;
                    break;
                case ProgramState.ProjectOpenNoChanges:
                    this.Text = "PnP Transmogrifier - " + projectPath;
                    loadPnPCSVToolStripMenuItem.Enabled = true;
                    loadLibraryToolStripMenuItem.Enabled = true;
                    loadProjectToolStripMenuItem.Enabled = true;
                    projectSettingsToolStripMenuItem.Enabled = true;
                    saveProjectToolStripMenuItem.Enabled = true;
                    exportToolStripMenuItem.Enabled = (project.Conflicts.Count == 0);
                    textBox1.Enabled = true;
                    break;
            }
            if (project.Conflicts.Count > 0)
            {
                statuslabel.Text = project.Conflicts.Count.ToString() + " Conflicts";
                statuslabel.Image = Resources._512px_Cross_red_circle;
            }
            else
            {
                statuslabel.Text = "No Conflicts";
                statuslabel.Image = Resources.Eo_circle_green_checkmark;
            }
        }

        private void TransmorgGUI_Load(object sender, EventArgs e)
        {
            tstb_version.Text = "V " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            SetGuiState();
        }

        private void TransmorgGUI_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (programState == ProgramState.ProjectChanged || programState == ProgramState.OnlySourcePnP)
            {
                SaveProjectAs();
            }
        }

        private void dg_ProjectItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void statuslabel_Click(object sender, EventArgs e)
        {
            //Check and correct part conflicts
            if (project.Conflicts.Count > 0)
            {
                ResolveConflicts();
            }
            else
            {
                ChangePart();
            }
        }

        private void loadPnPCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadPnPFile();
        }

        private void loadLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open Library
            OpenLibrary();
        }

        private void loadProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open Project
            OpenProject();
        }

        private void projectSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Save project, if new project do save project as
            project.Description = textBox1.Text;
            SaveProject();
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Save project as
            project.Description = textBox1.Text;
            SaveProjectAs();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Start Export to CSV
        }

        private void nozzleSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Nozzle Settings
            OpenNozzleSettings();
        }

        private void OpenNozzleSettings()
        {
            using (NozzleSettingsWindow nozzleWindow = new NozzleSettingsWindow())
            {
                nozzleWindow.project = project;
                nozzleWindow.ShowDialog();
                if (nozzleWindow.changed)
                {
                    SetProgramState(ProgramState.ProjectChanged);
                }
                if (project.GroupPartsWithNozzles(out _))
                {
                    //Calculate PnP Placement to display head usage in main window
                    CheckAndGetPnPLines(out _);
                    dg_ProjectItems.Refresh();
                }
            }
        }

        private void panelSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PCB and Panel Settings
            using (PcbAndPanelWindow pcbWindow = new PcbAndPanelWindow())
            {
                pcbWindow.project = project;
                pcbWindow.ShowDialog();
                if (pcbWindow.ProjectModified)
                {
                    SetProgramState(ProgramState.ProjectChanged);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Change Part
            ChangePart();
        }

        private void ChangePart()
        {
            using (ConflictResolver partChanger = new ConflictResolver())
            {
                partChanger.project = project;
                partChanger.PartChangeMode = true;
                partChanger.ShowDialog();
                if (partChanger.ChangesMade)
                {
                    SetProgramState(ProgramState.ProjectChanged);
                }
            }
        }

        //Open File FLow
        public void LoadPnPFile()
        {
            if (programState != ProgramState.NoFilesOpen)
            {
                DialogResult saveCurrent = MessageBox.Show("Do you want to save the current project?", "Save Project", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (saveCurrent == DialogResult.Yes)
                {
                    SaveProjectAs();
                }
                else if (saveCurrent == DialogResult.Cancel)
                {
                    return;
                }
                DialogResult newProject = MessageBox.Show("Do you want to start a new project and discard the current parts library?", "New Project?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (newProject == DialogResult.Yes)
                {
                    project = new Project();
                    projectPath = string.Empty;
                    SetProgramState(ProgramState.NoFilesOpen);
                    project.Conflicts.Clear();
                }
                else if (newProject == DialogResult.Cancel)
                {
                    return;
                }
            }
            if (ImportPnPFile())
            {
                if (project.Library.LibParts.Count > 0)
                {
                    DialogResult applyLibrary = MessageBox.Show("The project contains a parts library. Do you want to apply this library? (No discards the library)", "Use Project Library?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (applyLibrary == DialogResult.Yes)
                    {
                        ApplyLibrary();
                        SetProgramState(ProgramState.ProjectChanged);
                    }
                    else
                    {
                        project.Library = new Library();
                        SetProgramState(ProgramState.OnlySourcePnP);
                        project.Conflicts.Clear();
                    }
                }
                else
                {
                    project.Library = new Library();
                    SetProgramState(ProgramState.OnlySourcePnP);
                    project.Conflicts.Clear();
                }
            }


        }

        public bool ImportPnPFile()
        {
            bool result = false;

            string path = string.Empty;

            //Open source PnP file
            using (PnPFileOpenForm openForm = new PnPFileOpenForm())
            {
                openForm.ShowDialog();
                result = (!openForm.cancel) && (openForm.InputCsvMapping != null);
                if (result)
                {
                    path = openForm.FilePath;
                    string csv;
                    using (var fstream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var reader = new StreamReader(fstream))
                        csv = reader.ReadToEnd();
                    try
                    {
                        result = project.ImportCsv(csv, openForm.InputCsvMapping);
                        if (!result) MessageBox.Show("Failed to parse CSV file. Check format", "CSV Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            project.Parts = project.Parts.OrderBy(part => ProjectExtensionMethods.PadNumbers(part.Designator)).ToList();
                        }
                        dg_ProjectItems.DataSource = project.Parts;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading CSV File: " + ex.ToString(), "CSV Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }

            return result;
        }

        //Open Library flow

        public void OpenLibrary()
        {
            if (project.Library != null && project.Library.PartLibraryPath != string.Empty)
            {
                if (File.Exists(project.Library.PartLibraryPath))
                {
                    DialogResult result = MessageBox.Show("Project already contains a parts Library, over write with new library file?", "Over wrtie Library file?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result != DialogResult.Yes)
                    {
                        return;
                    }
                }
            }
            string filePath = string.Empty;
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                fileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = fileDialog.FileName;
                    if (File.Exists(filePath))
                    {
                        bool import = project.ImportLibraryFile(filePath);
                        SetProgramState(ProgramState.ProjectChanged);
                        if (import)
                        {
                            //project.Library.PartLibraryPath = filePath;
                            ApplyLibrary();
                        }
                    }
                }
            }
        }

        //Apply Library Flow
        public void ApplyLibrary()
        {
            project.Conflicts = project.ApplyLibraryOverwrite(project.Library);
            SetProgramState(ProgramState.ProjectChanged);
            if (project.Conflicts.Count > 0)
            {
                DialogResult result = MessageBox.Show("Part conflicts detected when applying Library file. View and resolve now?", "Resolve conflicts now?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ResolveConflicts();
                }
            }

        }

        public void ResolveConflicts()
        {
            using (ConflictResolver resolverWindow = new ConflictResolver())
            {
                resolverWindow.project = project;
                resolverWindow.conflicts = project.Conflicts;
                resolverWindow.ShowDialog();
                if (resolverWindow.ChangesMade)
                {
                    SetProgramState(ProgramState.ProjectChanged);
                }
            }
        }

        public void OpenProject()
        {
            if (programState == ProgramState.OnlySourcePnP || programState == ProgramState.ProjectChanged)
            {
                DialogResult result = MessageBox.Show("Do you want to save the current project?", "Save Current Project?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SaveProjectAs();
                }
            }
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                fileDialog.Filter = "Transmorg files (*.tmog)|*.tmog|All files (*.*)|*.*";
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    projectPath = fileDialog.FileName;
                    try
                    {
                        try
                        {
                            using FileStream readFile = File.Open(projectPath, FileMode.Open);
                            using var decompressor = new GZipStream(readFile, CompressionMode.Decompress);
                            using StreamReader decompressedReader = new StreamReader(decompressor);
                            string json = decompressedReader.ReadToEnd();
                            project = JsonSerializer.Deserialize<Project>(json);
                        }
                        catch
                        {
                            //Possibly older project format that is uncompressed
                            project = JsonSerializer.Deserialize<Project>(File.ReadAllText(projectPath));
                        }
                        dg_ProjectItems.DataSource = project.Parts;
                        textBox1.Text = project.Description;
                        SetProgramState(ProgramState.ProjectOpenNoChanges);
                    }
                    catch
                    {
                        MessageBox.Show("Error opening project. File may be corrupted or in wrong format", "Project Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        project = new Project();
                        projectPath = string.Empty;
                        SetProgramState(ProgramState.NoFilesOpen);
                    }
                }
            }

        }

        public void OpenProjectOnStart(string path)
        {
            try
            {
                projectPath = path;
                project = JsonSerializer.Deserialize<Project>(File.ReadAllText(projectPath));
                SetProgramState(ProgramState.ProjectOpenNoChanges);
                dg_ProjectItems.DataSource = project.Parts;
            }
            catch
            {
                MessageBox.Show("Error opening project. File may be corrupted or in wrong format", "Project Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                project = new Project();
                projectPath = string.Empty;
                SetProgramState(ProgramState.NoFilesOpen);
            }
        }

        //Save Project Flow
        public void SaveProject()
        {
            if (projectPath == string.Empty)
            {
                SaveProjectAs();
            }
            else
            {
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;
                string json = JsonSerializer.Serialize(project, options);
                if (File.Exists(projectPath))
                {
                    File.Delete(projectPath);
                }
                using FileStream saveFileStream = File.Create(projectPath);
                using var compressor = new GZipStream(saveFileStream, CompressionMode.Compress);
                using StreamWriter writer = new StreamWriter(compressor);
                writer.Write(json);
                //File.WriteAllText(projectPath, json);
                SetProgramState(ProgramState.ProjectOpenNoChanges);
            }
        }

        public void SaveProjectAs()
        {
            using (SaveFileDialog fileDialog = new SaveFileDialog())
            {
                if (projectPath == string.Empty)
                {
                    fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }
                else
                {
                    fileDialog.InitialDirectory = Directory.GetParent(projectPath).ToString();
                }

                fileDialog.Filter = "Transmorg files (*.tmog)|*.tmog|All files (*.*)|*.*";
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    projectPath = fileDialog.FileName;
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.WriteIndented = true;

                    string json = JsonSerializer.Serialize(project, options);
                    if (File.Exists(projectPath))
                    {
                        File.Delete(projectPath);
                    }
                    using FileStream saveFileStream = File.Create(projectPath);
                    using var compressor = new GZipStream(saveFileStream, CompressionMode.Compress);
                    using StreamWriter writer = new StreamWriter(compressor);
                    writer.Write(json);
                    //File.WriteAllText(projectPath, json);
                    SetProgramState(ProgramState.ProjectOpenNoChanges);
                }
            }

        }

        /// <summary>
        /// A pretty terrible way of doing this, should really be triggered by changes to the
        /// project rather than on a timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (project != null)
            {
                if (project.Conflicts != null)
                {
                    if (project.Conflicts.Count > 0)
                    {
                        changePartMenuItem.Enabled = false;
                        statuslabel.Text = project.Conflicts.Count.ToString() + " Part Conflicts";
                        statuslabel.Image = Resources._512px_Cross_red_circle;
                    }
                    else
                    {
                        changePartMenuItem.Enabled = true;
                        statuslabel.Text = "No Conflicts";
                        statuslabel.Image = Resources.Eo_circle_green_checkmark;
                    }
                }
                if (project.Pcb != null)
                {
                    lb_pcbSize.Text = "PCB: " + project.Pcb.SizeX.ToString("N2") + "mm x " + project.Pcb.SizeY.ToString("N2") + "mm x " + project.Pcb.Thickness.ToString("N2") + "mm";
                    if (project.Pcb.Panalized)
                    {
                        lb_panel.Text = "Panel: " + project.Pcb.PanelCountX.ToString() + " x " + project.Pcb.PanelCountY.ToString();
                    }
                    else
                    {
                        lb_panel.Text = "Panel: None";
                    }

                    if (project.Parts.Count > 0)
                    {
                        if (project.Parts.Any(item => item.CenterX > project.Pcb.SizeX) ||
                            project.Parts.Any(item => item.CenterY > project.Pcb.SizeY))
                        {
                            tsl_partLocCheck.Text = "Part(s) Located outside PCB area, check PCB dimensions";
                            tsl_partLocCheck.Image = Resources._512px_Cross_red_circle;
                        }
                        else
                        {
                            tsl_partLocCheck.Text = "All parts inside PCB area";
                            tsl_partLocCheck.Image = Resources.Eo_circle_green_checkmark;
                        }
                    }
                    else
                    {
                        tsl_partLocCheck.Text = "";
                        tsl_partLocCheck.Image = null;
                    }
                }
                if (programState == ProgramState.ProjectOpenNoChanges || programState == ProgramState.ProjectChanged)
                {
                    ts_NozzleStatus.Visible = true;
                    if (!project.GroupPartsWithNozzles(out _))
                    {
                        ts_NozzleStatus.Text = "Invalid nozzle settings";
                        ts_NozzleStatus.Image = Resources._512px_Cross_red_circle;
                    }
                    else
                    {
                        ts_NozzleStatus.Text = "Nozzles OK";
                        ts_NozzleStatus.Image = Resources.Eo_circle_green_checkmark;
                    }
                }
                else
                {
                    ts_NozzleStatus.Visible = false;
                }

                lb_totalParts.Text = "Total Parts: " + project.Parts.Count.ToString();
                lb_placeParts.Text = "Place Parts: " + project.Parts.FindAll(item => item.Skip == false).FindAll(item => item.Layer == PcbLayer.TOP).Count.ToString();
                lb_skipParts.Text = "Skip Parts: " + project.Parts.FindAll(item => item.Skip == true).Count.ToString();
                if (project.NozzleSet != null)
                {
                    lb_nozzleSet.Text = "Nozzles: " + project.NozzleSet.Head1.ToString() + ", " + project.NozzleSet.Head2.ToString() + ", " + project.NozzleSet.Holder1.ToString() + ", " + project.NozzleSet.Holder2.ToString();
                }

            }
            else
            {
                statuslabel.Text = "Ready";
                statuslabel.Image = Resources.Eo_circle_green_checkmark;
            }

        }

        private void tsl_partLocCheck_Click(object sender, EventArgs e)
        {
            List<Part> offPcb = new List<Part>();
            foreach (Part part in project.Parts)
            {
                if (!offPcb.Contains(part))
                {
                    if (part.CenterX > project.Pcb.SizeX)
                    {
                        offPcb.Add(part);
                    }
                }
                if (!offPcb.Contains(part))
                {
                    if (part.CenterY > project.Pcb.SizeY)
                    {
                        offPcb.Add(part);
                    }
                }
            }
            DialogResult = DialogResult.None;
            if (offPcb.Count == 0) return;
            else if (offPcb.Count <= 10)
            {
                StringBuilder messageSb = new StringBuilder();
                messageSb.AppendLine(offPcb.Count.ToString() + " parts located outside PCB area.");
                messageSb.AppendLine("PCB size: " + project.Pcb.SizeX.ToString("N4") + "mm X " + project.Pcb.SizeY.ToString("N4") + " mm");
                messageSb.AppendLine("Parts outside PCB:");
                for (int i = 0; i < offPcb.Count; i++)
                {
                    messageSb.AppendLine("Part " + (i + 1).ToString() + offPcb[i].Designator + " X: " + offPcb[i].CenterX.ToString("N4") + " mm Y: " + offPcb[i].CenterY.ToString("N4"));
                }
                messageSb.AppendLine("Copy list to clipboard?");
                DialogResult = MessageBox.Show(messageSb.ToString(), "Parts outside PCB", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            else
            {
                StringBuilder messageSb = new StringBuilder();
                messageSb.AppendLine(offPcb.Count.ToString() + " parts located outside PCB area.");
                messageSb.AppendLine("PCB size: " + project.Pcb.SizeX.ToString("N4") + "mm X " + project.Pcb.SizeY.ToString("N4") + " mm");
                messageSb.AppendLine("Copy list to clipboard?");
                DialogResult = MessageBox.Show(messageSb.ToString(), "Parts outside PCB", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            if (DialogResult == DialogResult.Yes)
            {
                StringBuilder partsSb = new StringBuilder();
                partsSb.AppendLine("Designator,CenterX,CenterY");
                foreach (Part part in offPcb)
                {
                    partsSb.AppendLine(part.Designator + "," + part.CenterX.ToString() + "," + part.CenterY.ToString());
                }
                Clipboard.SetText(partsSb.ToString());
            }
        }

        private void exportMenuItem2_Click(object sender, EventArgs e)
        {
            ExportNoPlaceCsv();
        }

        private void ExportNoPlaceCsv()
        {
            using (SaveFileDialog fileDialog = new SaveFileDialog())
            {
                if (projectPath == string.Empty)
                {
                    fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }
                else
                {
                    fileDialog.InitialDirectory = Directory.GetParent(projectPath).ToString();
                }

                fileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fpath = fileDialog.FileName;

                    if (File.Exists(fpath))
                    {
                        File.Delete(fpath);
                    }
                    using (StreamWriter fileWriter = new StreamWriter(File.OpenWrite(fpath)))
                    {
                        fileWriter.WriteLine("Designator,PartNumber,Description,Feeder");
                        foreach (Part part in project.Parts)
                        {
                            if (part.Skip)
                            {
                                fileWriter.WriteLine(part.Designator + "," + part.PartNumber + "," + part.MachineDescription + "," + part.FeederNumber.ToString());
                            }
                        }
                        fileWriter.Flush();
                        fileWriter.Close();
                    }

                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SetProgramState(ProgramState.ProjectChanged);
        }

        private void exportMenuItem1_Click(object sender, EventArgs e)
        {
            ExportPickAndPlace();
            dg_ProjectItems.Refresh();
        }

        private void ExportPickAndPlace()
        {
            string fpath = GetPickAndPlacePath();
            if (fpath == string.Empty) return;
            string PnPData = CheckAndGetPnPLines(out List<NozzleChange> NozzleChanges);
            if (PnPData == "") return;

            //Open File
            if (File.Exists(fpath))
            {
                File.Delete(fpath);
            }
            using (StreamWriter fileWriter = new StreamWriter(File.OpenWrite(fpath)))
            {
                //Write Header
                fileWriter.WriteLine(ProjectExtensionMethods.GetNeodenHeader());
                fileWriter.WriteLine(ProjectExtensionMethods.GetNeodenBlankRow());
                //Write Panel info
                fileWriter.WriteLine(project.Pcb.ToCsvLine());
                fileWriter.WriteLine(ProjectExtensionMethods.GetNeodenBlankRow());
                fileWriter.WriteLine(ProjectExtensionMethods.GetNeodenFiducialRow());
                fileWriter.WriteLine(ProjectExtensionMethods.GetNeodenBlankRow());
                //Write Tool changes
                foreach (NozzleChange NozzleChange in NozzleChanges)
                {
                    fileWriter.WriteLine(NozzleChange.ToCsvLine());
                }
                fileWriter.WriteLine(ProjectExtensionMethods.GetNeodenBlankRow());
                //Write PnP data
                fileWriter.Write(PnPData);

                fileWriter.Flush();
                fileWriter.Close();
            }
            MessageBox.Show("Export Done!", "PnP Export Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string CheckAndGetPnPLines(out List<NozzleChange> nozzleChanges) 
        {
            nozzleChanges = new List<NozzleChange>();
            if (!project.GroupPartsWithNozzles(out _))
            {
                MessageBox.Show("The project contains unplacable parts due to the current nozzle selections. Check and update nozzle settings", "Nozzle Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            NozzleTracker nozzleTracker = new NozzleTracker(project.NozzleSet.GetLocationsList());
            List<PhysicalNozzle>? HeadNozzles = nozzleTracker.GetHeadNozzles();
            if (HeadNozzles == null)
            {
                MessageBox.Show("No Head Nozzles specified. Check and correct nozzles settings", "Nozzle Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            return project.GetPnPLines(out nozzleChanges);
        }

        private string GetPickAndPlacePath()
        {
            string fpath = string.Empty;
            using (SaveFileDialog fileDialog = new SaveFileDialog())
            {
                if (projectPath == string.Empty)
                {
                    fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }
                else
                {
                    fileDialog.InitialDirectory = Directory.GetParent(projectPath).ToString();
                }

                fileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    fpath = fileDialog.FileName;
                }
            }
            return fpath;
        }

        private void ts_NozzleStatus_Click(object sender, EventArgs e)
        {
            OpenNozzleSettings();
        }
    }
}