namespace Transmorg_FormsUI
{
    partial class ConflictResolver
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConflictResolver));
            groupBox1 = new GroupBox();
            btn_Close = new Button();
            cb_LibOptions = new ComboBox();
            btn_ShowLibrary = new Button();
            tb_LibOptionCount = new TextBox();
            btn_libNext = new Button();
            cb_applyAll = new CheckBox();
            btn_libLast = new Button();
            tb_conflictType = new TextBox();
            btn_apply = new Button();
            cb_SkipPart = new CheckBox();
            gb_LibOption = new GroupBox();
            tb_LibPackage = new TextBox();
            label18 = new Label();
            tb_libPartDesc = new TextBox();
            label17 = new Label();
            tb_LibAltNozzleSize = new TextBox();
            label13 = new Label();
            tb_libPlacementMode = new TextBox();
            label11 = new Label();
            tb_libOptNozzleSize = new TextBox();
            label10 = new Label();
            tb_LibPickHeight = new TextBox();
            label9 = new Label();
            tb_LibFeeder = new TextBox();
            label8 = new Label();
            tb_libOptionPartNum = new TextBox();
            label7 = new Label();
            groupBox2 = new GroupBox();
            tb_assignedLibPartDesc = new TextBox();
            label16 = new Label();
            tb_designDesc = new TextBox();
            label15 = new Label();
            label14 = new Label();
            tb_PartFeederNum = new TextBox();
            tb_Rotation = new TextBox();
            label12 = new Label();
            tb_PlaceY = new TextBox();
            tb_PlaceX = new TextBox();
            tb_PartHeight = new TextBox();
            tb_PartLibPartNum = new TextBox();
            tb_PartNum = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tb_PartDesig = new TextBox();
            btn_last = new Button();
            btn_next = new Button();
            tb_ConflictCounter = new TextBox();
            cb_ConflictSelector = new ComboBox();
            groupBox1.SuspendLayout();
            gb_LibOption.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_Close);
            groupBox1.Controls.Add(cb_LibOptions);
            groupBox1.Controls.Add(btn_ShowLibrary);
            groupBox1.Controls.Add(tb_LibOptionCount);
            groupBox1.Controls.Add(btn_libNext);
            groupBox1.Controls.Add(cb_applyAll);
            groupBox1.Controls.Add(btn_libLast);
            groupBox1.Controls.Add(tb_conflictType);
            groupBox1.Controls.Add(btn_apply);
            groupBox1.Controls.Add(cb_SkipPart);
            groupBox1.Controls.Add(gb_LibOption);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Location = new Point(12, 47);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 401);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Conflict";
            // 
            // btn_Close
            // 
            btn_Close.Location = new Point(656, 369);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new Size(113, 23);
            btn_Close.TabIndex = 11;
            btn_Close.Text = "Close";
            btn_Close.UseVisualStyleBackColor = true;
            btn_Close.Click += btn_Close_Click;
            // 
            // cb_LibOptions
            // 
            cb_LibOptions.FormattingEnabled = true;
            cb_LibOptions.Location = new Point(613, 74);
            cb_LibOptions.Margin = new Padding(3, 2, 3, 2);
            cb_LibOptions.Name = "cb_LibOptions";
            cb_LibOptions.Size = new Size(155, 23);
            cb_LibOptions.TabIndex = 8;
            cb_LibOptions.SelectedIndexChanged += cb_LibOptions_SelectedIndexChanged;
            // 
            // btn_ShowLibrary
            // 
            btn_ShowLibrary.Enabled = false;
            btn_ShowLibrary.Location = new Point(613, 17);
            btn_ShowLibrary.Name = "btn_ShowLibrary";
            btn_ShowLibrary.Size = new Size(158, 23);
            btn_ShowLibrary.TabIndex = 5;
            btn_ShowLibrary.Text = "Pick From Library";
            btn_ShowLibrary.UseVisualStyleBackColor = true;
            btn_ShowLibrary.Click += btn_ShowLibrary_Click;
            // 
            // tb_LibOptionCount
            // 
            tb_LibOptionCount.Location = new Point(642, 48);
            tb_LibOptionCount.Name = "tb_LibOptionCount";
            tb_LibOptionCount.ReadOnly = true;
            tb_LibOptionCount.Size = new Size(98, 23);
            tb_LibOptionCount.TabIndex = 6;
            tb_LibOptionCount.TabStop = false;
            tb_LibOptionCount.Text = "1/1";
            tb_LibOptionCount.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_libNext
            // 
            btn_libNext.Location = new Point(745, 46);
            btn_libNext.Name = "btn_libNext";
            btn_libNext.Size = new Size(24, 23);
            btn_libNext.TabIndex = 7;
            btn_libNext.Text = "→";
            btn_libNext.UseVisualStyleBackColor = true;
            btn_libNext.Click += btn_libNext_Click;
            // 
            // cb_applyAll
            // 
            cb_applyAll.AutoSize = true;
            cb_applyAll.Location = new Point(324, 372);
            cb_applyAll.Name = "cb_applyAll";
            cb_applyAll.Size = new Size(190, 19);
            cb_applyAll.TabIndex = 9;
            cb_applyAll.Text = "Apply for all same part number";
            cb_applyAll.UseVisualStyleBackColor = true;
            // 
            // btn_libLast
            // 
            btn_libLast.Location = new Point(613, 46);
            btn_libLast.Name = "btn_libLast";
            btn_libLast.Size = new Size(24, 23);
            btn_libLast.TabIndex = 6;
            btn_libLast.Text = "←";
            btn_libLast.UseVisualStyleBackColor = true;
            btn_libLast.Click += btn_libLast_Click;
            // 
            // tb_conflictType
            // 
            tb_conflictType.Location = new Point(6, 22);
            tb_conflictType.Name = "tb_conflictType";
            tb_conflictType.ReadOnly = true;
            tb_conflictType.Size = new Size(152, 23);
            tb_conflictType.TabIndex = 4;
            tb_conflictType.TabStop = false;
            tb_conflictType.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_apply
            // 
            btn_apply.Location = new Point(538, 369);
            btn_apply.Name = "btn_apply";
            btn_apply.Size = new Size(113, 23);
            btn_apply.TabIndex = 10;
            btn_apply.Text = "Apply";
            btn_apply.UseVisualStyleBackColor = true;
            btn_apply.Click += btn_apply_Click;
            // 
            // cb_SkipPart
            // 
            cb_SkipPart.AutoSize = true;
            cb_SkipPart.Location = new Point(493, 75);
            cb_SkipPart.Name = "cb_SkipPart";
            cb_SkipPart.Size = new Size(107, 19);
            cb_SkipPart.TabIndex = 4;
            cb_SkipPart.Text = "Skip Placement";
            cb_SkipPart.UseVisualStyleBackColor = true;
            cb_SkipPart.CheckedChanged += cb_SkipPart_CheckedChanged;
            // 
            // gb_LibOption
            // 
            gb_LibOption.Controls.Add(tb_LibPackage);
            gb_LibOption.Controls.Add(label18);
            gb_LibOption.Controls.Add(tb_libPartDesc);
            gb_LibOption.Controls.Add(label17);
            gb_LibOption.Controls.Add(tb_LibAltNozzleSize);
            gb_LibOption.Controls.Add(label13);
            gb_LibOption.Controls.Add(tb_libPlacementMode);
            gb_LibOption.Controls.Add(label11);
            gb_LibOption.Controls.Add(tb_libOptNozzleSize);
            gb_LibOption.Controls.Add(label10);
            gb_LibOption.Controls.Add(tb_LibPickHeight);
            gb_LibOption.Controls.Add(label9);
            gb_LibOption.Controls.Add(tb_LibFeeder);
            gb_LibOption.Controls.Add(label8);
            gb_LibOption.Controls.Add(tb_libOptionPartNum);
            gb_LibOption.Controls.Add(label7);
            gb_LibOption.Location = new Point(385, 99);
            gb_LibOption.Name = "gb_LibOption";
            gb_LibOption.Size = new Size(391, 264);
            gb_LibOption.TabIndex = 1;
            gb_LibOption.TabStop = false;
            gb_LibOption.Text = "Library Options";
            // 
            // tb_LibPackage
            // 
            tb_LibPackage.Location = new Point(170, 80);
            tb_LibPackage.Name = "tb_LibPackage";
            tb_LibPackage.ReadOnly = true;
            tb_LibPackage.Size = new Size(216, 23);
            tb_LibPackage.TabIndex = 28;
            tb_LibPackage.TabStop = false;
            tb_LibPackage.TextAlign = HorizontalAlignment.Center;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(113, 83);
            label18.Name = "label18";
            label18.Size = new Size(51, 15);
            label18.TabIndex = 27;
            label18.Text = "Package";
            // 
            // tb_libPartDesc
            // 
            tb_libPartDesc.Location = new Point(170, 51);
            tb_libPartDesc.Name = "tb_libPartDesc";
            tb_libPartDesc.ReadOnly = true;
            tb_libPartDesc.Size = new Size(216, 23);
            tb_libPartDesc.TabIndex = 26;
            tb_libPartDesc.TabStop = false;
            tb_libPartDesc.TextAlign = HorizontalAlignment.Center;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(58, 54);
            label17.Name = "label17";
            label17.Size = new Size(110, 15);
            label17.TabIndex = 25;
            label17.Text = "Lib Part Description";
            // 
            // tb_LibAltNozzleSize
            // 
            tb_LibAltNozzleSize.Location = new Point(170, 196);
            tb_LibAltNozzleSize.Name = "tb_LibAltNozzleSize";
            tb_LibAltNozzleSize.ReadOnly = true;
            tb_LibAltNozzleSize.Size = new Size(216, 23);
            tb_LibAltNozzleSize.TabIndex = 24;
            tb_LibAltNozzleSize.TabStop = false;
            tb_LibAltNozzleSize.TextAlign = HorizontalAlignment.Center;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(71, 199);
            label13.Name = "label13";
            label13.Size = new Size(93, 15);
            label13.TabIndex = 23;
            label13.Text = "Alternate Nozzle";
            // 
            // tb_libPlacementMode
            // 
            tb_libPlacementMode.Location = new Point(169, 225);
            tb_libPlacementMode.Name = "tb_libPlacementMode";
            tb_libPlacementMode.ReadOnly = true;
            tb_libPlacementMode.Size = new Size(216, 23);
            tb_libPlacementMode.TabIndex = 22;
            tb_libPlacementMode.TabStop = false;
            tb_libPlacementMode.TextAlign = HorizontalAlignment.Center;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(66, 228);
            label11.Name = "label11";
            label11.Size = new Size(97, 15);
            label11.TabIndex = 21;
            label11.Text = "Placement Mode";
            // 
            // tb_libOptNozzleSize
            // 
            tb_libOptNozzleSize.Location = new Point(170, 167);
            tb_libOptNozzleSize.Name = "tb_libOptNozzleSize";
            tb_libOptNozzleSize.ReadOnly = true;
            tb_libOptNozzleSize.Size = new Size(216, 23);
            tb_libOptNozzleSize.TabIndex = 20;
            tb_libOptNozzleSize.TabStop = false;
            tb_libOptNozzleSize.TextAlign = HorizontalAlignment.Center;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(76, 170);
            label10.Name = "label10";
            label10.Size = new Size(88, 15);
            label10.TabIndex = 19;
            label10.Text = "Optimal Nozzle";
            // 
            // tb_LibPickHeight
            // 
            tb_LibPickHeight.Location = new Point(170, 138);
            tb_LibPickHeight.Name = "tb_LibPickHeight";
            tb_LibPickHeight.ReadOnly = true;
            tb_LibPickHeight.Size = new Size(216, 23);
            tb_LibPickHeight.TabIndex = 18;
            tb_LibPickHeight.TabStop = false;
            tb_LibPickHeight.TextAlign = HorizontalAlignment.Center;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(96, 141);
            label9.Name = "label9";
            label9.Size = new Size(68, 15);
            label9.TabIndex = 17;
            label9.Text = "Pick Height";
            // 
            // tb_LibFeeder
            // 
            tb_LibFeeder.Location = new Point(170, 109);
            tb_LibFeeder.Name = "tb_LibFeeder";
            tb_LibFeeder.ReadOnly = true;
            tb_LibFeeder.Size = new Size(216, 23);
            tb_LibFeeder.TabIndex = 16;
            tb_LibFeeder.TabStop = false;
            tb_LibFeeder.TextAlign = HorizontalAlignment.Center;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(75, 112);
            label8.Name = "label8";
            label8.Size = new Size(89, 15);
            label8.TabIndex = 15;
            label8.Text = "Feeder Number";
            // 
            // tb_libOptionPartNum
            // 
            tb_libOptionPartNum.Location = new Point(170, 22);
            tb_libOptionPartNum.Name = "tb_libOptionPartNum";
            tb_libOptionPartNum.ReadOnly = true;
            tb_libOptionPartNum.Size = new Size(216, 23);
            tb_libOptionPartNum.TabIndex = 14;
            tb_libOptionPartNum.TabStop = false;
            tb_libOptionPartNum.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(95, 24);
            label7.Name = "label7";
            label7.Size = new Size(75, 15);
            label7.TabIndex = 13;
            label7.Text = "Part Number";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tb_assignedLibPartDesc);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(tb_designDesc);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(tb_PartFeederNum);
            groupBox2.Controls.Add(tb_Rotation);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(tb_PlaceY);
            groupBox2.Controls.Add(tb_PlaceX);
            groupBox2.Controls.Add(tb_PartHeight);
            groupBox2.Controls.Add(tb_PartLibPartNum);
            groupBox2.Controls.Add(tb_PartNum);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(tb_PartDesig);
            groupBox2.Location = new Point(6, 48);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(367, 321);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "PnP Part";
            // 
            // tb_assignedLibPartDesc
            // 
            tb_assignedLibPartDesc.Location = new Point(145, 138);
            tb_assignedLibPartDesc.Name = "tb_assignedLibPartDesc";
            tb_assignedLibPartDesc.ReadOnly = true;
            tb_assignedLibPartDesc.Size = new Size(216, 23);
            tb_assignedLibPartDesc.TabIndex = 24;
            tb_assignedLibPartDesc.TabStop = false;
            tb_assignedLibPartDesc.TextAlign = HorizontalAlignment.Center;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(29, 141);
            label16.Name = "label16";
            label16.Size = new Size(110, 15);
            label16.TabIndex = 23;
            label16.Text = "Lib Part Description";
            // 
            // tb_designDesc
            // 
            tb_designDesc.Location = new Point(145, 109);
            tb_designDesc.Name = "tb_designDesc";
            tb_designDesc.ReadOnly = true;
            tb_designDesc.Size = new Size(216, 23);
            tb_designDesc.TabIndex = 22;
            tb_designDesc.TabStop = false;
            tb_designDesc.TextAlign = HorizontalAlignment.Center;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(33, 112);
            label15.Name = "label15";
            label15.Size = new Size(106, 15);
            label15.TabIndex = 21;
            label15.Text = "Design Description";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(5, 170);
            label14.Name = "label14";
            label14.Size = new Size(126, 15);
            label14.TabIndex = 20;
            label14.Text = "Assinged Feeder Num.";
            // 
            // tb_PartFeederNum
            // 
            tb_PartFeederNum.Location = new Point(145, 167);
            tb_PartFeederNum.Name = "tb_PartFeederNum";
            tb_PartFeederNum.ReadOnly = true;
            tb_PartFeederNum.Size = new Size(216, 23);
            tb_PartFeederNum.TabIndex = 19;
            tb_PartFeederNum.TabStop = false;
            tb_PartFeederNum.TextAlign = HorizontalAlignment.Center;
            // 
            // tb_Rotation
            // 
            tb_Rotation.Location = new Point(145, 283);
            tb_Rotation.Name = "tb_Rotation";
            tb_Rotation.ReadOnly = true;
            tb_Rotation.Size = new Size(216, 23);
            tb_Rotation.TabIndex = 18;
            tb_Rotation.TabStop = false;
            tb_Rotation.TextAlign = HorizontalAlignment.Center;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(85, 285);
            label12.Name = "label12";
            label12.Size = new Size(52, 15);
            label12.TabIndex = 17;
            label12.Text = "Rotation";
            // 
            // tb_PlaceY
            // 
            tb_PlaceY.Location = new Point(145, 254);
            tb_PlaceY.Name = "tb_PlaceY";
            tb_PlaceY.ReadOnly = true;
            tb_PlaceY.Size = new Size(216, 23);
            tb_PlaceY.TabIndex = 16;
            tb_PlaceY.TabStop = false;
            tb_PlaceY.TextAlign = HorizontalAlignment.Center;
            // 
            // tb_PlaceX
            // 
            tb_PlaceX.Location = new Point(145, 225);
            tb_PlaceX.Name = "tb_PlaceX";
            tb_PlaceX.ReadOnly = true;
            tb_PlaceX.Size = new Size(216, 23);
            tb_PlaceX.TabIndex = 15;
            tb_PlaceX.TabStop = false;
            tb_PlaceX.TextAlign = HorizontalAlignment.Center;
            // 
            // tb_PartHeight
            // 
            tb_PartHeight.Location = new Point(145, 196);
            tb_PartHeight.Name = "tb_PartHeight";
            tb_PartHeight.ReadOnly = true;
            tb_PartHeight.Size = new Size(216, 23);
            tb_PartHeight.TabIndex = 14;
            tb_PartHeight.TabStop = false;
            tb_PartHeight.TextAlign = HorizontalAlignment.Center;
            // 
            // tb_PartLibPartNum
            // 
            tb_PartLibPartNum.Location = new Point(145, 80);
            tb_PartLibPartNum.Name = "tb_PartLibPartNum";
            tb_PartLibPartNum.ReadOnly = true;
            tb_PartLibPartNum.Size = new Size(216, 23);
            tb_PartLibPartNum.TabIndex = 13;
            tb_PartLibPartNum.TabStop = false;
            tb_PartLibPartNum.TextAlign = HorizontalAlignment.Center;
            // 
            // tb_PartNum
            // 
            tb_PartNum.Location = new Point(145, 51);
            tb_PartNum.Name = "tb_PartNum";
            tb_PartNum.ReadOnly = true;
            tb_PartNum.Size = new Size(216, 23);
            tb_PartNum.TabIndex = 12;
            tb_PartNum.TabStop = false;
            tb_PartNum.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(65, 257);
            label6.Name = "label6";
            label6.Size = new Size(73, 15);
            label6.TabIndex = 11;
            label6.Text = "Placement Y";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(64, 227);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 10;
            label5.Text = "Placement X";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(72, 198);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 9;
            label4.Text = "Part Height";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 83);
            label3.Name = "label3";
            label3.Size = new Size(131, 15);
            label3.TabIndex = 8;
            label3.Text = "Assinged Lib Part Num.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 54);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 7;
            label2.Text = "Part Number";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 25);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 6;
            label1.Text = "Ref. Designator";
            // 
            // tb_PartDesig
            // 
            tb_PartDesig.Location = new Point(145, 22);
            tb_PartDesig.Name = "tb_PartDesig";
            tb_PartDesig.ReadOnly = true;
            tb_PartDesig.Size = new Size(216, 23);
            tb_PartDesig.TabIndex = 5;
            tb_PartDesig.TabStop = false;
            tb_PartDesig.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_last
            // 
            btn_last.Location = new Point(12, 12);
            btn_last.Name = "btn_last";
            btn_last.Size = new Size(24, 23);
            btn_last.TabIndex = 0;
            btn_last.Text = "←";
            btn_last.UseVisualStyleBackColor = true;
            btn_last.Click += btn_last_Click;
            // 
            // btn_next
            // 
            btn_next.Location = new Point(144, 12);
            btn_next.Name = "btn_next";
            btn_next.Size = new Size(24, 23);
            btn_next.TabIndex = 1;
            btn_next.Text = "→";
            btn_next.UseVisualStyleBackColor = true;
            btn_next.Click += btn_next_Click;
            // 
            // tb_ConflictCounter
            // 
            tb_ConflictCounter.Location = new Point(41, 14);
            tb_ConflictCounter.Name = "tb_ConflictCounter";
            tb_ConflictCounter.ReadOnly = true;
            tb_ConflictCounter.Size = new Size(98, 23);
            tb_ConflictCounter.TabIndex = 3;
            tb_ConflictCounter.TabStop = false;
            tb_ConflictCounter.Text = "1/1";
            tb_ConflictCounter.TextAlign = HorizontalAlignment.Center;
            // 
            // cb_ConflictSelector
            // 
            cb_ConflictSelector.FormattingEnabled = true;
            cb_ConflictSelector.Location = new Point(172, 14);
            cb_ConflictSelector.Margin = new Padding(3, 2, 3, 2);
            cb_ConflictSelector.Name = "cb_ConflictSelector";
            cb_ConflictSelector.Size = new Size(108, 23);
            cb_ConflictSelector.TabIndex = 3;
            cb_ConflictSelector.SelectedIndexChanged += cb_ConflictSelector_SelectedIndexChanged;
            // 
            // ConflictResolver
            // 
            AcceptButton = btn_apply;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btn_Close;
            ClientSize = new Size(800, 459);
            Controls.Add(cb_ConflictSelector);
            Controls.Add(tb_ConflictCounter);
            Controls.Add(btn_next);
            Controls.Add(btn_last);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConflictResolver";
            Text = "Conflict Resolver";
            Load += ConflictResolver_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gb_LibOption.ResumeLayout(false);
            gb_LibOption.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox cb_SkipPart;
        private GroupBox gb_LibOption;
        private GroupBox groupBox2;
        private Button btn_apply;
        private Button btn_last;
        private Button btn_next;
        private TextBox tb_ConflictCounter;
        private TextBox tb_conflictType;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox tb_PartDesig;
        private Label label4;
        private Label label5;
        private Label label6;
        private CheckBox cb_applyAll;
        private TextBox tb_PlaceY;
        private TextBox tb_PlaceX;
        private TextBox tb_PartHeight;
        private TextBox tb_PartLibPartNum;
        private TextBox tb_PartNum;
        private TextBox tb_LibOptionCount;
        private Button btn_libNext;
        private Button btn_libLast;
        private TextBox tb_libPlacementMode;
        private Label label11;
        private TextBox tb_libOptNozzleSize;
        private Label label10;
        private TextBox tb_LibPickHeight;
        private Label label9;
        private TextBox tb_LibFeeder;
        private Label label8;
        private TextBox tb_libOptionPartNum;
        private Label label7;
        private TextBox tb_Rotation;
        private Label label12;
        private TextBox tb_LibAltNozzleSize;
        private Label label13;
        private Button btn_ShowLibrary;
        private ComboBox cb_LibOptions;
        private ComboBox cb_ConflictSelector;
        private Button btn_Close;
        private Label label14;
        private TextBox tb_PartFeederNum;
        private TextBox tb_libPartDesc;
        private Label label17;
        private TextBox tb_assignedLibPartDesc;
        private Label label16;
        private TextBox tb_designDesc;
        private Label label15;
        private TextBox tb_LibPackage;
        private Label label18;
    }
}