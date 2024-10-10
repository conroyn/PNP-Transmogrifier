namespace Transmorg_FormsUI
{
    partial class TransmorgGUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransmorgGUI));
            contextMenuStrip1 = new ContextMenuStrip(components);
            contextMenuStrip2 = new ContextMenuStrip(components);
            contextMenuStrip3 = new ContextMenuStrip(components);
            option1ToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            statuslabel = new ToolStripStatusLabel();
            ts_NozzleStatus = new ToolStripStatusLabel();
            tsl_partLocCheck = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            loadPnPCSVToolStripMenuItem = new ToolStripMenuItem();
            loadLibraryToolStripMenuItem = new ToolStripMenuItem();
            loadProjectToolStripMenuItem = new ToolStripMenuItem();
            projectSettingsToolStripMenuItem = new ToolStripMenuItem();
            panelSettingsToolStripMenuItem = new ToolStripMenuItem();
            nozzleSettingsToolStripMenuItem = new ToolStripMenuItem();
            placementSettingsMenuItem = new ToolStripMenuItem();
            changePartMenuItem = new ToolStripMenuItem();
            saveProjectToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem1 = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            exportMenuItem1 = new ToolStripMenuItem();
            exportMenuItem2 = new ToolStripMenuItem();
            tstb_version = new ToolStripTextBox();
            gb_PcbDetails = new GroupBox();
            lb_nozzleSet = new Label();
            lb_skipParts = new Label();
            lb_placeParts = new Label();
            lb_totalParts = new Label();
            lb_panel = new Label();
            lb_pcbSize = new Label();
            projectBindingSource = new BindingSource(components);
            dg_ProjectItems = new DataGridView();
            designatorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            skipDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            PlacementOrder = new DataGridViewTextBoxColumn();
            partNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            libPartNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DesignDescription = new DataGridViewTextBoxColumn();
            MachineDescription = new DataGridViewTextBoxColumn();
            packageNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            layerDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            optimalNozzleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            alternateNozzleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            headDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            centerXDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            centerYDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            rotationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            partHeightDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pickHeightDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            placeHeightDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            feederNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            partBindingSource2 = new BindingSource(components);
            partBindingSource1 = new BindingSource(components);
            partsBindingSource = new BindingSource(components);
            partBindingSource = new BindingSource(components);
            textBox1 = new TextBox();
            label4 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            contextMenuStrip3.SuspendLayout();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            gb_PcbDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)projectBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dg_ProjectItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)partBindingSource2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)partBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)partsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)partBindingSource).BeginInit();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.ImageScalingSize = new Size(20, 20);
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // contextMenuStrip3
            // 
            contextMenuStrip3.ImageScalingSize = new Size(20, 20);
            contextMenuStrip3.Items.AddRange(new ToolStripItem[] { option1ToolStripMenuItem });
            contextMenuStrip3.Name = "contextMenuStrip3";
            contextMenuStrip3.Size = new Size(121, 26);
            // 
            // option1ToolStripMenuItem
            // 
            option1ToolStripMenuItem.Name = "option1ToolStripMenuItem";
            option1ToolStripMenuItem.Size = new Size(120, 22);
            option1ToolStripMenuItem.Text = "Option 1";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { statuslabel, ts_NozzleStatus, tsl_partLocCheck });
            statusStrip1.Location = new Point(0, 518);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(874, 25);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // statuslabel
            // 
            statuslabel.Image = Properties.Resources.Eo_circle_green_checkmark;
            statuslabel.Name = "statuslabel";
            statuslabel.Size = new Size(59, 20);
            statuslabel.Text = "Ready";
            statuslabel.Click += statuslabel_Click;
            // 
            // ts_NozzleStatus
            // 
            ts_NozzleStatus.Name = "ts_NozzleStatus";
            ts_NozzleStatus.Size = new Size(12, 20);
            ts_NozzleStatus.Text = "-";
            ts_NozzleStatus.Click += ts_NozzleStatus_Click;
            // 
            // tsl_partLocCheck
            // 
            tsl_partLocCheck.Name = "tsl_partLocCheck";
            tsl_partLocCheck.Size = new Size(12, 20);
            tsl_partLocCheck.Text = "-";
            tsl_partLocCheck.Click += tsl_partLocCheck_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { loadPnPCSVToolStripMenuItem, loadLibraryToolStripMenuItem, loadProjectToolStripMenuItem, projectSettingsToolStripMenuItem, saveProjectToolStripMenuItem, exportToolStripMenuItem, tstb_version });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(874, 28);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // loadPnPCSVToolStripMenuItem
            // 
            loadPnPCSVToolStripMenuItem.Image = Properties.Resources.FolderOpenRed;
            loadPnPCSVToolStripMenuItem.Name = "loadPnPCSVToolStripMenuItem";
            loadPnPCSVToolStripMenuItem.Size = new Size(92, 24);
            loadPnPCSVToolStripMenuItem.Text = "Open PnP";
            loadPnPCSVToolStripMenuItem.ToolTipText = "Open Pick and Place CSV file from ECAD tool";
            loadPnPCSVToolStripMenuItem.Click += loadPnPCSVToolStripMenuItem_Click;
            // 
            // loadLibraryToolStripMenuItem
            // 
            loadLibraryToolStripMenuItem.Image = Properties.Resources.FolderOpenTeal;
            loadLibraryToolStripMenuItem.Name = "loadLibraryToolStripMenuItem";
            loadLibraryToolStripMenuItem.Size = new Size(107, 24);
            loadLibraryToolStripMenuItem.Text = "Open Library";
            loadLibraryToolStripMenuItem.ToolTipText = "Open Part Library File";
            loadLibraryToolStripMenuItem.Click += loadLibraryToolStripMenuItem_Click;
            // 
            // loadProjectToolStripMenuItem
            // 
            loadProjectToolStripMenuItem.Image = Properties.Resources.OpenProjectFolder;
            loadProjectToolStripMenuItem.Name = "loadProjectToolStripMenuItem";
            loadProjectToolStripMenuItem.Size = new Size(108, 24);
            loadProjectToolStripMenuItem.Text = "Open Project";
            loadProjectToolStripMenuItem.ToolTipText = "Open Project File";
            loadProjectToolStripMenuItem.Click += loadProjectToolStripMenuItem_Click;
            // 
            // projectSettingsToolStripMenuItem
            // 
            projectSettingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { panelSettingsToolStripMenuItem, nozzleSettingsToolStripMenuItem, placementSettingsMenuItem, changePartMenuItem });
            projectSettingsToolStripMenuItem.Image = Properties.Resources.Settings;
            projectSettingsToolStripMenuItem.Name = "projectSettingsToolStripMenuItem";
            projectSettingsToolStripMenuItem.Size = new Size(98, 24);
            projectSettingsToolStripMenuItem.Text = "Parameters";
            projectSettingsToolStripMenuItem.Click += projectSettingsToolStripMenuItem_Click;
            // 
            // panelSettingsToolStripMenuItem
            // 
            panelSettingsToolStripMenuItem.Image = Properties.Resources.Grid;
            panelSettingsToolStripMenuItem.Name = "panelSettingsToolStripMenuItem";
            panelSettingsToolStripMenuItem.Size = new Size(175, 22);
            panelSettingsToolStripMenuItem.Text = "PCB and Panel";
            panelSettingsToolStripMenuItem.Click += panelSettingsToolStripMenuItem_Click;
            // 
            // nozzleSettingsToolStripMenuItem
            // 
            nozzleSettingsToolStripMenuItem.Image = Properties.Resources.ConePreview_flipped;
            nozzleSettingsToolStripMenuItem.Name = "nozzleSettingsToolStripMenuItem";
            nozzleSettingsToolStripMenuItem.Size = new Size(175, 22);
            nozzleSettingsToolStripMenuItem.Text = "Nozzles";
            nozzleSettingsToolStripMenuItem.Click += nozzleSettingsToolStripMenuItem_Click;
            // 
            // placementSettingsMenuItem
            // 
            placementSettingsMenuItem.Enabled = false;
            placementSettingsMenuItem.Image = Properties.Resources.CustomActionEditor;
            placementSettingsMenuItem.Name = "placementSettingsMenuItem";
            placementSettingsMenuItem.Size = new Size(175, 22);
            placementSettingsMenuItem.Text = "Placement Settings";
            placementSettingsMenuItem.Visible = false;
            // 
            // changePartMenuItem
            // 
            changePartMenuItem.Image = Properties.Resources.QuickReplace;
            changePartMenuItem.Name = "changePartMenuItem";
            changePartMenuItem.Size = new Size(175, 22);
            changePartMenuItem.Text = "Change Part";
            changePartMenuItem.Click += toolStripMenuItem1_Click;
            // 
            // saveProjectToolStripMenuItem
            // 
            saveProjectToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, saveToolStripMenuItem1 });
            saveProjectToolStripMenuItem.Image = Properties.Resources.SaveAll;
            saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            saveProjectToolStripMenuItem.Size = new Size(103, 24);
            saveProjectToolStripMenuItem.Text = "Save Project";
            saveProjectToolStripMenuItem.ToolTipText = "Save Project FIle";
            saveProjectToolStripMenuItem.Click += saveProjectToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = Properties.Resources.Save1;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(117, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem1
            // 
            saveToolStripMenuItem1.Image = Properties.Resources.SaveAs;
            saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            saveToolStripMenuItem1.Size = new Size(117, 22);
            saveToolStripMenuItem1.Text = "Save As ";
            saveToolStripMenuItem1.Click += saveToolStripMenuItem1_Click;
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportMenuItem1, exportMenuItem2 });
            exportToolStripMenuItem.Image = Properties.Resources.SaveTable;
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(96, 24);
            exportToolStripMenuItem.Text = "Export CSV";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // exportMenuItem1
            // 
            exportMenuItem1.Image = Properties.Resources.BuildSolution;
            exportMenuItem1.Name = "exportMenuItem1";
            exportMenuItem1.Size = new Size(150, 22);
            exportMenuItem1.Text = "Pick and Place";
            exportMenuItem1.Click += exportMenuItem1_Click;
            // 
            // exportMenuItem2
            // 
            exportMenuItem2.Image = Properties.Resources.BuildSelection;
            exportMenuItem2.Name = "exportMenuItem2";
            exportMenuItem2.Size = new Size(150, 22);
            exportMenuItem2.Text = "No Place List";
            exportMenuItem2.Click += exportMenuItem2_Click;
            // 
            // tstb_version
            // 
            tstb_version.Alignment = ToolStripItemAlignment.Right;
            tstb_version.Name = "tstb_version";
            tstb_version.ReadOnly = true;
            tstb_version.Size = new Size(100, 24);
            tstb_version.TextBoxTextAlign = HorizontalAlignment.Center;
            // 
            // gb_PcbDetails
            // 
            gb_PcbDetails.Controls.Add(lb_nozzleSet);
            gb_PcbDetails.Controls.Add(lb_skipParts);
            gb_PcbDetails.Controls.Add(lb_placeParts);
            gb_PcbDetails.Controls.Add(lb_totalParts);
            gb_PcbDetails.Controls.Add(lb_panel);
            gb_PcbDetails.Controls.Add(lb_pcbSize);
            gb_PcbDetails.Location = new Point(12, 27);
            gb_PcbDetails.Name = "gb_PcbDetails";
            gb_PcbDetails.Size = new Size(339, 116);
            gb_PcbDetails.TabIndex = 5;
            gb_PcbDetails.TabStop = false;
            gb_PcbDetails.Text = "Project Summary";
            // 
            // lb_nozzleSet
            // 
            lb_nozzleSet.AutoSize = true;
            lb_nozzleSet.Location = new Point(25, 95);
            lb_nozzleSet.Name = "lb_nozzleSet";
            lb_nozzleSet.Size = new Size(53, 15);
            lb_nozzleSet.TabIndex = 5;
            lb_nozzleSet.Text = "Nozzles: ";
            // 
            // lb_skipParts
            // 
            lb_skipParts.AutoSize = true;
            lb_skipParts.Location = new Point(16, 80);
            lb_skipParts.Name = "lb_skipParts";
            lb_skipParts.Size = new Size(64, 15);
            lb_skipParts.TabIndex = 4;
            lb_skipParts.Text = "Skip Parts: ";
            // 
            // lb_placeParts
            // 
            lb_placeParts.AutoSize = true;
            lb_placeParts.Location = new Point(10, 65);
            lb_placeParts.Name = "lb_placeParts";
            lb_placeParts.Size = new Size(70, 15);
            lb_placeParts.TabIndex = 3;
            lb_placeParts.Text = "Place Parts: ";
            // 
            // lb_totalParts
            // 
            lb_totalParts.AutoSize = true;
            lb_totalParts.Location = new Point(11, 50);
            lb_totalParts.Name = "lb_totalParts";
            lb_totalParts.Size = new Size(68, 15);
            lb_totalParts.TabIndex = 2;
            lb_totalParts.Text = "Total Parts: ";
            // 
            // lb_panel
            // 
            lb_panel.AutoSize = true;
            lb_panel.Location = new Point(40, 35);
            lb_panel.Name = "lb_panel";
            lb_panel.Size = new Size(42, 15);
            lb_panel.TabIndex = 1;
            lb_panel.Text = "Panel: ";
            // 
            // lb_pcbSize
            // 
            lb_pcbSize.AutoSize = true;
            lb_pcbSize.Location = new Point(48, 20);
            lb_pcbSize.Name = "lb_pcbSize";
            lb_pcbSize.Size = new Size(35, 15);
            lb_pcbSize.TabIndex = 0;
            lb_pcbSize.Text = "PCB: ";
            // 
            // projectBindingSource
            // 
            projectBindingSource.DataSource = typeof(Lib_Transmorg.Project);
            // 
            // dg_ProjectItems
            // 
            dg_ProjectItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dg_ProjectItems.AutoGenerateColumns = false;
            dg_ProjectItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_ProjectItems.Columns.AddRange(new DataGridViewColumn[] { designatorDataGridViewTextBoxColumn, skipDataGridViewCheckBoxColumn, PlacementOrder, partNumberDataGridViewTextBoxColumn, libPartNumberDataGridViewTextBoxColumn, DesignDescription, MachineDescription, packageNameDataGridViewTextBoxColumn, layerDataGridViewTextBoxColumn, optimalNozzleDataGridViewTextBoxColumn, alternateNozzleDataGridViewTextBoxColumn, headDataGridViewTextBoxColumn, centerXDataGridViewTextBoxColumn, centerYDataGridViewTextBoxColumn, rotationDataGridViewTextBoxColumn, partHeightDataGridViewTextBoxColumn, pickHeightDataGridViewTextBoxColumn, placeHeightDataGridViewTextBoxColumn, feederNumberDataGridViewTextBoxColumn });
            dg_ProjectItems.DataSource = partBindingSource2;
            dg_ProjectItems.Location = new Point(12, 149);
            dg_ProjectItems.Name = "dg_ProjectItems";
            dg_ProjectItems.ReadOnly = true;
            dg_ProjectItems.RowHeadersWidth = 51;
            dg_ProjectItems.Size = new Size(850, 369);
            dg_ProjectItems.TabIndex = 8;
            dg_ProjectItems.CellContentClick += dg_ProjectItems_CellContentClick;
            // 
            // designatorDataGridViewTextBoxColumn
            // 
            designatorDataGridViewTextBoxColumn.DataPropertyName = "Designator";
            designatorDataGridViewTextBoxColumn.HeaderText = "Designator";
            designatorDataGridViewTextBoxColumn.MinimumWidth = 6;
            designatorDataGridViewTextBoxColumn.Name = "designatorDataGridViewTextBoxColumn";
            designatorDataGridViewTextBoxColumn.ReadOnly = true;
            designatorDataGridViewTextBoxColumn.Width = 125;
            // 
            // skipDataGridViewCheckBoxColumn
            // 
            skipDataGridViewCheckBoxColumn.DataPropertyName = "Skip";
            skipDataGridViewCheckBoxColumn.HeaderText = "Skip";
            skipDataGridViewCheckBoxColumn.MinimumWidth = 6;
            skipDataGridViewCheckBoxColumn.Name = "skipDataGridViewCheckBoxColumn";
            skipDataGridViewCheckBoxColumn.ReadOnly = true;
            skipDataGridViewCheckBoxColumn.Width = 125;
            // 
            // PlacementOrder
            // 
            PlacementOrder.DataPropertyName = "PlacementOrder";
            PlacementOrder.HeaderText = "PlacementOrder";
            PlacementOrder.Name = "PlacementOrder";
            PlacementOrder.ReadOnly = true;
            // 
            // partNumberDataGridViewTextBoxColumn
            // 
            partNumberDataGridViewTextBoxColumn.DataPropertyName = "PartNumber";
            partNumberDataGridViewTextBoxColumn.HeaderText = "PartNumber";
            partNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            partNumberDataGridViewTextBoxColumn.Name = "partNumberDataGridViewTextBoxColumn";
            partNumberDataGridViewTextBoxColumn.ReadOnly = true;
            partNumberDataGridViewTextBoxColumn.Width = 125;
            // 
            // libPartNumberDataGridViewTextBoxColumn
            // 
            libPartNumberDataGridViewTextBoxColumn.DataPropertyName = "LibPartNumber";
            libPartNumberDataGridViewTextBoxColumn.HeaderText = "LibPartNumber";
            libPartNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            libPartNumberDataGridViewTextBoxColumn.Name = "libPartNumberDataGridViewTextBoxColumn";
            libPartNumberDataGridViewTextBoxColumn.ReadOnly = true;
            libPartNumberDataGridViewTextBoxColumn.Width = 125;
            // 
            // DesignDescription
            // 
            DesignDescription.DataPropertyName = "DesignDescription";
            DesignDescription.HeaderText = "DesignDescription";
            DesignDescription.Name = "DesignDescription";
            DesignDescription.ReadOnly = true;
            // 
            // MachineDescription
            // 
            MachineDescription.DataPropertyName = "MachineDescription";
            MachineDescription.HeaderText = "MachineDescription";
            MachineDescription.Name = "MachineDescription";
            MachineDescription.ReadOnly = true;
            // 
            // packageNameDataGridViewTextBoxColumn
            // 
            packageNameDataGridViewTextBoxColumn.DataPropertyName = "PackageName";
            packageNameDataGridViewTextBoxColumn.HeaderText = "PackageName";
            packageNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            packageNameDataGridViewTextBoxColumn.Name = "packageNameDataGridViewTextBoxColumn";
            packageNameDataGridViewTextBoxColumn.ReadOnly = true;
            packageNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // layerDataGridViewTextBoxColumn
            // 
            layerDataGridViewTextBoxColumn.DataPropertyName = "Layer";
            layerDataGridViewTextBoxColumn.HeaderText = "Layer";
            layerDataGridViewTextBoxColumn.MinimumWidth = 6;
            layerDataGridViewTextBoxColumn.Name = "layerDataGridViewTextBoxColumn";
            layerDataGridViewTextBoxColumn.ReadOnly = true;
            layerDataGridViewTextBoxColumn.Width = 125;
            // 
            // optimalNozzleDataGridViewTextBoxColumn
            // 
            optimalNozzleDataGridViewTextBoxColumn.DataPropertyName = "OptimalNozzle";
            optimalNozzleDataGridViewTextBoxColumn.HeaderText = "OptimalNozzle";
            optimalNozzleDataGridViewTextBoxColumn.MinimumWidth = 6;
            optimalNozzleDataGridViewTextBoxColumn.Name = "optimalNozzleDataGridViewTextBoxColumn";
            optimalNozzleDataGridViewTextBoxColumn.ReadOnly = true;
            optimalNozzleDataGridViewTextBoxColumn.Width = 125;
            // 
            // alternateNozzleDataGridViewTextBoxColumn
            // 
            alternateNozzleDataGridViewTextBoxColumn.DataPropertyName = "AlternateNozzle";
            alternateNozzleDataGridViewTextBoxColumn.HeaderText = "AlternateNozzle";
            alternateNozzleDataGridViewTextBoxColumn.MinimumWidth = 6;
            alternateNozzleDataGridViewTextBoxColumn.Name = "alternateNozzleDataGridViewTextBoxColumn";
            alternateNozzleDataGridViewTextBoxColumn.ReadOnly = true;
            alternateNozzleDataGridViewTextBoxColumn.Width = 125;
            // 
            // headDataGridViewTextBoxColumn
            // 
            headDataGridViewTextBoxColumn.DataPropertyName = "Head";
            headDataGridViewTextBoxColumn.HeaderText = "Head";
            headDataGridViewTextBoxColumn.MinimumWidth = 6;
            headDataGridViewTextBoxColumn.Name = "headDataGridViewTextBoxColumn";
            headDataGridViewTextBoxColumn.ReadOnly = true;
            headDataGridViewTextBoxColumn.Width = 125;
            // 
            // centerXDataGridViewTextBoxColumn
            // 
            centerXDataGridViewTextBoxColumn.DataPropertyName = "CenterX";
            centerXDataGridViewTextBoxColumn.HeaderText = "CenterX";
            centerXDataGridViewTextBoxColumn.MinimumWidth = 6;
            centerXDataGridViewTextBoxColumn.Name = "centerXDataGridViewTextBoxColumn";
            centerXDataGridViewTextBoxColumn.ReadOnly = true;
            centerXDataGridViewTextBoxColumn.Width = 125;
            // 
            // centerYDataGridViewTextBoxColumn
            // 
            centerYDataGridViewTextBoxColumn.DataPropertyName = "CenterY";
            centerYDataGridViewTextBoxColumn.HeaderText = "CenterY";
            centerYDataGridViewTextBoxColumn.MinimumWidth = 6;
            centerYDataGridViewTextBoxColumn.Name = "centerYDataGridViewTextBoxColumn";
            centerYDataGridViewTextBoxColumn.ReadOnly = true;
            centerYDataGridViewTextBoxColumn.Width = 125;
            // 
            // rotationDataGridViewTextBoxColumn
            // 
            rotationDataGridViewTextBoxColumn.DataPropertyName = "Rotation";
            rotationDataGridViewTextBoxColumn.HeaderText = "Rotation";
            rotationDataGridViewTextBoxColumn.MinimumWidth = 6;
            rotationDataGridViewTextBoxColumn.Name = "rotationDataGridViewTextBoxColumn";
            rotationDataGridViewTextBoxColumn.ReadOnly = true;
            rotationDataGridViewTextBoxColumn.Width = 125;
            // 
            // partHeightDataGridViewTextBoxColumn
            // 
            partHeightDataGridViewTextBoxColumn.DataPropertyName = "PartHeight";
            partHeightDataGridViewTextBoxColumn.HeaderText = "PartHeight";
            partHeightDataGridViewTextBoxColumn.MinimumWidth = 6;
            partHeightDataGridViewTextBoxColumn.Name = "partHeightDataGridViewTextBoxColumn";
            partHeightDataGridViewTextBoxColumn.ReadOnly = true;
            partHeightDataGridViewTextBoxColumn.Width = 125;
            // 
            // pickHeightDataGridViewTextBoxColumn
            // 
            pickHeightDataGridViewTextBoxColumn.DataPropertyName = "PickHeight";
            pickHeightDataGridViewTextBoxColumn.HeaderText = "PickHeight";
            pickHeightDataGridViewTextBoxColumn.MinimumWidth = 6;
            pickHeightDataGridViewTextBoxColumn.Name = "pickHeightDataGridViewTextBoxColumn";
            pickHeightDataGridViewTextBoxColumn.ReadOnly = true;
            pickHeightDataGridViewTextBoxColumn.Width = 125;
            // 
            // placeHeightDataGridViewTextBoxColumn
            // 
            placeHeightDataGridViewTextBoxColumn.DataPropertyName = "PlaceHeight";
            placeHeightDataGridViewTextBoxColumn.HeaderText = "PlaceHeight";
            placeHeightDataGridViewTextBoxColumn.MinimumWidth = 6;
            placeHeightDataGridViewTextBoxColumn.Name = "placeHeightDataGridViewTextBoxColumn";
            placeHeightDataGridViewTextBoxColumn.ReadOnly = true;
            placeHeightDataGridViewTextBoxColumn.Width = 125;
            // 
            // feederNumberDataGridViewTextBoxColumn
            // 
            feederNumberDataGridViewTextBoxColumn.DataPropertyName = "FeederNumber";
            feederNumberDataGridViewTextBoxColumn.HeaderText = "FeederNumber";
            feederNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            feederNumberDataGridViewTextBoxColumn.Name = "feederNumberDataGridViewTextBoxColumn";
            feederNumberDataGridViewTextBoxColumn.ReadOnly = true;
            feederNumberDataGridViewTextBoxColumn.Width = 125;
            // 
            // partBindingSource2
            // 
            partBindingSource2.DataSource = typeof(Lib_Transmorg.Part);
            // 
            // partBindingSource1
            // 
            partBindingSource1.DataSource = typeof(Lib_Transmorg.Part);
            // 
            // partsBindingSource
            // 
            partsBindingSource.DataMember = "Parts";
            partsBindingSource.DataSource = projectBindingSource;
            // 
            // partBindingSource
            // 
            partBindingSource.DataSource = typeof(Lib_Transmorg.Part);
            // 
            // textBox1
            // 
            textBox1.Location = new Point(356, 45);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(506, 98);
            textBox1.TabIndex = 9;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(356, 27);
            label4.Name = "label4";
            label4.Size = new Size(107, 15);
            label4.TabIndex = 10;
            label4.Text = "Project Description";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 250;
            timer1.Tick += timer1_Tick;
            // 
            // TransmorgGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 543);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(dg_ProjectItems);
            Controls.Add(gb_PcbDetails);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "TransmorgGUI";
            Text = "PnP Transmogrifier";
            FormClosing += TransmorgGUI_FormClosing;
            Load += TransmorgGUI_Load;
            contextMenuStrip3.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            gb_PcbDetails.ResumeLayout(false);
            gb_PcbDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)projectBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dg_ProjectItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)partBindingSource2).EndInit();
            ((System.ComponentModel.ISupportInitialize)partBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)partsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)partBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private ContextMenuStrip contextMenuStrip2;
        private ContextMenuStrip contextMenuStrip3;
        private ToolStripMenuItem option1ToolStripMenuItem;
        private StatusStrip statusStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem loadPnPCSVToolStripMenuItem;
        private ToolStripMenuItem loadLibraryToolStripMenuItem;
        private ToolStripMenuItem loadProjectToolStripMenuItem;
        private ToolStripMenuItem saveProjectToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem1;
        private GroupBox gb_PcbDetails;
        private BindingSource projectBindingSource;
        private DataGridView dg_ProjectItems;
        private BindingSource partBindingSource;
        private TextBox textBox1;
        private Label label4;
        private ToolStripStatusLabel statuslabel;
        private ToolStripMenuItem projectSettingsToolStripMenuItem;
        private ToolStripMenuItem nozzleSettingsToolStripMenuItem;
        private ToolStripMenuItem panelSettingsToolStripMenuItem;
        private Label lb_nozzleSet;
        private Label lb_skipParts;
        private Label lb_placeParts;
        private Label lb_totalParts;
        private Label lb_panel;
        private Label lb_pcbSize;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn orderDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn doublePickDataGridViewTextBoxColumn;
        private BindingSource partsBindingSource;
        private ToolStripMenuItem changePartMenuItem;
        private System.Windows.Forms.Timer timer1;
        private ToolStripMenuItem placementSettingsMenuItem;
        private ToolStripMenuItem exportMenuItem1;
        private ToolStripMenuItem exportMenuItem2;
        private ToolStripStatusLabel tsl_partLocCheck;
        private ToolStripStatusLabel ts_NozzleStatus;
        private BindingSource partBindingSource1;
        private ToolStripTextBox tstb_version;
        private BindingSource partBindingSource2;
        private DataGridViewTextBoxColumn designatorDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn skipDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn PlacementOrder;
        private DataGridViewTextBoxColumn partNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn libPartNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn DesignDescription;
        private DataGridViewTextBoxColumn MachineDescription;
        private DataGridViewTextBoxColumn packageNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn layerDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn optimalNozzleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn alternateNozzleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn headDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn centerXDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn centerYDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn rotationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn partHeightDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pickHeightDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn placeHeightDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn feederNumberDataGridViewTextBoxColumn;
    }
}