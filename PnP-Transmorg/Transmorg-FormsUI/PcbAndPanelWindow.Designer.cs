namespace Transmorg_FormsUI
{
    partial class PcbAndPanelWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PcbAndPanelWindow));
            gb_PcbSettings = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            lb_PcbSizeX = new Label();
            nm_PcbHeight = new NumericUpDown();
            nm_PcbSizeY = new NumericUpDown();
            nm_PcbSizeX = new NumericUpDown();
            gb_PanelSettings = new GroupBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label11 = new Label();
            nm_XMouseBite = new NumericUpDown();
            nm_YMouseBite = new NumericUpDown();
            label10 = new Label();
            label6 = new Label();
            nm_YRailSize = new NumericUpDown();
            nm_XRailSize = new NumericUpDown();
            label7 = new Label();
            label5 = new Label();
            nm_GridY = new NumericUpDown();
            label4 = new Label();
            nm_GridX = new NumericUpDown();
            label3 = new Label();
            btn_Cancel = new Button();
            btn_Apply = new Button();
            cb_PanelEn = new CheckBox();
            gb_PcbSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nm_PcbHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nm_PcbSizeY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nm_PcbSizeX).BeginInit();
            gb_PanelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nm_XMouseBite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nm_YMouseBite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nm_YRailSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nm_XRailSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nm_GridY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nm_GridX).BeginInit();
            SuspendLayout();
            // 
            // gb_PcbSettings
            // 
            gb_PcbSettings.Controls.Add(label2);
            gb_PcbSettings.Controls.Add(label1);
            gb_PcbSettings.Controls.Add(lb_PcbSizeX);
            gb_PcbSettings.Controls.Add(nm_PcbHeight);
            gb_PcbSettings.Controls.Add(nm_PcbSizeY);
            gb_PcbSettings.Controls.Add(nm_PcbSizeX);
            gb_PcbSettings.Location = new Point(10, 9);
            gb_PcbSettings.Margin = new Padding(3, 2, 3, 2);
            gb_PcbSettings.Name = "gb_PcbSettings";
            gb_PcbSettings.Padding = new Padding(3, 2, 3, 2);
            gb_PcbSettings.Size = new Size(288, 104);
            gb_PcbSettings.TabIndex = 0;
            gb_PcbSettings.TabStop = false;
            gb_PcbSettings.Text = "PCB Settings";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Image = Properties.Resources.TextLineHeight;
            label2.ImageAlign = ContentAlignment.MiddleLeft;
            label2.Location = new Point(106, 70);
            label2.Name = "label2";
            label2.Size = new Size(135, 15);
            label2.TabIndex = 5;
            label2.Text = "      PCB Thickness (mm)";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Image = Properties.Resources.AxisY;
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(106, 46);
            label1.Name = "label1";
            label1.Size = new Size(150, 15);
            label1.TabIndex = 4;
            label1.Text = "      PCB Y Dimension (mm)";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lb_PcbSizeX
            // 
            lb_PcbSizeX.AutoSize = true;
            lb_PcbSizeX.Image = Properties.Resources.AxisX;
            lb_PcbSizeX.ImageAlign = ContentAlignment.MiddleLeft;
            lb_PcbSizeX.Location = new Point(106, 21);
            lb_PcbSizeX.Name = "lb_PcbSizeX";
            lb_PcbSizeX.Size = new Size(150, 15);
            lb_PcbSizeX.TabIndex = 3;
            lb_PcbSizeX.Text = "      PCB X Dimension (mm)";
            lb_PcbSizeX.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nm_PcbHeight
            // 
            nm_PcbHeight.DecimalPlaces = 4;
            nm_PcbHeight.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nm_PcbHeight.Location = new Point(5, 69);
            nm_PcbHeight.Margin = new Padding(3, 2, 3, 2);
            nm_PcbHeight.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            nm_PcbHeight.Name = "nm_PcbHeight";
            nm_PcbHeight.Size = new Size(95, 23);
            nm_PcbHeight.TabIndex = 2;
            // 
            // nm_PcbSizeY
            // 
            nm_PcbSizeY.DecimalPlaces = 4;
            nm_PcbSizeY.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nm_PcbSizeY.Location = new Point(5, 44);
            nm_PcbSizeY.Margin = new Padding(3, 2, 3, 2);
            nm_PcbSizeY.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nm_PcbSizeY.Name = "nm_PcbSizeY";
            nm_PcbSizeY.Size = new Size(95, 23);
            nm_PcbSizeY.TabIndex = 1;
            // 
            // nm_PcbSizeX
            // 
            nm_PcbSizeX.DecimalPlaces = 4;
            nm_PcbSizeX.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nm_PcbSizeX.Location = new Point(5, 20);
            nm_PcbSizeX.Margin = new Padding(3, 2, 3, 2);
            nm_PcbSizeX.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nm_PcbSizeX.Name = "nm_PcbSizeX";
            nm_PcbSizeX.Size = new Size(95, 23);
            nm_PcbSizeX.TabIndex = 0;
            // 
            // gb_PanelSettings
            // 
            gb_PanelSettings.Controls.Add(pictureBox2);
            gb_PanelSettings.Controls.Add(pictureBox1);
            gb_PanelSettings.Controls.Add(label11);
            gb_PanelSettings.Controls.Add(nm_XMouseBite);
            gb_PanelSettings.Controls.Add(nm_YMouseBite);
            gb_PanelSettings.Controls.Add(label10);
            gb_PanelSettings.Controls.Add(label6);
            gb_PanelSettings.Controls.Add(nm_YRailSize);
            gb_PanelSettings.Controls.Add(nm_XRailSize);
            gb_PanelSettings.Controls.Add(label7);
            gb_PanelSettings.Controls.Add(label5);
            gb_PanelSettings.Controls.Add(nm_GridY);
            gb_PanelSettings.Controls.Add(label4);
            gb_PanelSettings.Controls.Add(nm_GridX);
            gb_PanelSettings.Controls.Add(label3);
            gb_PanelSettings.Enabled = false;
            gb_PanelSettings.Location = new Point(10, 140);
            gb_PanelSettings.Margin = new Padding(3, 2, 3, 2);
            gb_PanelSettings.Name = "gb_PanelSettings";
            gb_PanelSettings.Padding = new Padding(3, 2, 3, 2);
            gb_PanelSettings.Size = new Size(381, 191);
            gb_PanelSettings.TabIndex = 1;
            gb_PanelSettings.TabStop = false;
            gb_PanelSettings.Text = "Panel Settings";
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Image = Properties.Resources.MouseBiteTab_X_Rail___Copy;
            pictureBox2.Location = new Point(60, 101);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(38, 38);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 20;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.MouseBiteTab_Y_Rail;
            pictureBox1.Location = new Point(222, 101);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(38, 38);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Image = Properties.Resources.TextLineHeight;
            label11.ImageAlign = ContentAlignment.MiddleLeft;
            label11.Location = new Point(5, 141);
            label11.Name = "label11";
            label11.Size = new Size(147, 15);
            label11.TabIndex = 18;
            label11.Text = "     X Mouse Bite Size (mm)";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nm_XMouseBite
            // 
            nm_XMouseBite.DecimalPlaces = 4;
            nm_XMouseBite.Location = new Point(6, 158);
            nm_XMouseBite.Margin = new Padding(3, 2, 3, 2);
            nm_XMouseBite.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nm_XMouseBite.Name = "nm_XMouseBite";
            nm_XMouseBite.Size = new Size(159, 23);
            nm_XMouseBite.TabIndex = 8;
            // 
            // nm_YMouseBite
            // 
            nm_YMouseBite.DecimalPlaces = 4;
            nm_YMouseBite.Location = new Point(172, 158);
            nm_YMouseBite.Margin = new Padding(3, 2, 3, 2);
            nm_YMouseBite.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nm_YMouseBite.Name = "nm_YMouseBite";
            nm_YMouseBite.Size = new Size(159, 23);
            nm_YMouseBite.TabIndex = 9;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Image = Properties.Resources.TextLineHeight_Flipped;
            label10.ImageAlign = ContentAlignment.MiddleLeft;
            label10.Location = new Point(172, 141);
            label10.Name = "label10";
            label10.Size = new Size(150, 15);
            label10.TabIndex = 16;
            label10.Text = "      Y Mouse Bite Size (mm)";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Image = Properties.Resources.TextLineHeight_Flipped;
            label6.ImageAlign = ContentAlignment.MiddleLeft;
            label6.Location = new Point(176, 57);
            label6.Name = "label6";
            label6.Size = new Size(139, 15);
            label6.TabIndex = 10;
            label6.Text = "     Y Panel Rail Size (mm)";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nm_YRailSize
            // 
            nm_YRailSize.DecimalPlaces = 4;
            nm_YRailSize.Location = new Point(176, 74);
            nm_YRailSize.Margin = new Padding(3, 2, 3, 2);
            nm_YRailSize.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nm_YRailSize.Name = "nm_YRailSize";
            nm_YRailSize.Size = new Size(150, 23);
            nm_YRailSize.TabIndex = 7;
            // 
            // nm_XRailSize
            // 
            nm_XRailSize.DecimalPlaces = 4;
            nm_XRailSize.Location = new Point(5, 74);
            nm_XRailSize.Margin = new Padding(3, 2, 3, 2);
            nm_XRailSize.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nm_XRailSize.Name = "nm_XRailSize";
            nm_XRailSize.Size = new Size(151, 23);
            nm_XRailSize.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Image = Properties.Resources.TextLineHeight;
            label7.ImageAlign = ContentAlignment.MiddleLeft;
            label7.Location = new Point(5, 57);
            label7.Name = "label7";
            label7.Size = new Size(139, 15);
            label7.TabIndex = 7;
            label7.Text = "     X Panel Rail Size (mm)";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Image = Properties.Resources.EvenRows;
            label5.ImageAlign = ContentAlignment.MiddleLeft;
            label5.Location = new Point(129, 17);
            label5.Name = "label5";
            label5.Size = new Size(90, 15);
            label5.TabIndex = 6;
            label5.Text = "     Grid Count Y";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nm_GridY
            // 
            nm_GridY.Location = new Point(129, 34);
            nm_GridY.Margin = new Padding(3, 2, 3, 2);
            nm_GridY.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nm_GridY.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nm_GridY.Name = "nm_GridY";
            nm_GridY.Size = new Size(95, 23);
            nm_GridY.TabIndex = 5;
            nm_GridY.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(106, 40);
            label4.Name = "label4";
            label4.Size = new Size(14, 15);
            label4.TabIndex = 4;
            label4.Text = "X";
            // 
            // nm_GridX
            // 
            nm_GridX.Location = new Point(5, 34);
            nm_GridX.Margin = new Padding(3, 2, 3, 2);
            nm_GridX.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nm_GridX.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nm_GridX.Name = "nm_GridX";
            nm_GridX.Size = new Size(95, 23);
            nm_GridX.TabIndex = 4;
            nm_GridX.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Image = Properties.Resources.EvenColumns;
            label3.ImageAlign = ContentAlignment.MiddleLeft;
            label3.Location = new Point(5, 17);
            label3.Name = "label3";
            label3.Size = new Size(90, 15);
            label3.TabIndex = 0;
            label3.Text = "     Grid Count X";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(309, 335);
            btn_Cancel.Margin = new Padding(3, 2, 3, 2);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(82, 22);
            btn_Cancel.TabIndex = 11;
            btn_Cancel.Text = "Cancel";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // btn_Apply
            // 
            btn_Apply.Location = new Point(221, 335);
            btn_Apply.Margin = new Padding(3, 2, 3, 2);
            btn_Apply.Name = "btn_Apply";
            btn_Apply.Size = new Size(82, 22);
            btn_Apply.TabIndex = 10;
            btn_Apply.Text = "Apply";
            btn_Apply.UseVisualStyleBackColor = true;
            btn_Apply.Click += btn_Apply_Click;
            // 
            // cb_PanelEn
            // 
            cb_PanelEn.AutoSize = true;
            cb_PanelEn.Location = new Point(10, 117);
            cb_PanelEn.Margin = new Padding(3, 2, 3, 2);
            cb_PanelEn.Name = "cb_PanelEn";
            cb_PanelEn.Size = new Size(93, 19);
            cb_PanelEn.TabIndex = 3;
            cb_PanelEn.Text = "Enable Panel";
            cb_PanelEn.UseVisualStyleBackColor = true;
            cb_PanelEn.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // PcbAndPanelWindow
            // 
            AcceptButton = btn_Apply;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btn_Cancel;
            ClientSize = new Size(402, 366);
            Controls.Add(cb_PanelEn);
            Controls.Add(btn_Apply);
            Controls.Add(btn_Cancel);
            Controls.Add(gb_PanelSettings);
            Controls.Add(gb_PcbSettings);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PcbAndPanelWindow";
            Text = "PCB and Panel Settings";
            Load += PcbAndPanelWindow_Load;
            gb_PcbSettings.ResumeLayout(false);
            gb_PcbSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nm_PcbHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)nm_PcbSizeY).EndInit();
            ((System.ComponentModel.ISupportInitialize)nm_PcbSizeX).EndInit();
            gb_PanelSettings.ResumeLayout(false);
            gb_PanelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nm_XMouseBite).EndInit();
            ((System.ComponentModel.ISupportInitialize)nm_YMouseBite).EndInit();
            ((System.ComponentModel.ISupportInitialize)nm_YRailSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)nm_XRailSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)nm_GridY).EndInit();
            ((System.ComponentModel.ISupportInitialize)nm_GridX).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gb_PcbSettings;
        private GroupBox gb_PanelSettings;
        private Button btn_Cancel;
        private Button btn_Apply;
        private CheckBox cb_PanelEn;
        private Label label2;
        private Label label1;
        private Label lb_PcbSizeX;
        private NumericUpDown nm_PcbHeight;
        private NumericUpDown nm_PcbSizeY;
        private NumericUpDown nm_PcbSizeX;
        private Label label4;
        private NumericUpDown nm_GridX;
        private Label label3;
        private Label label5;
        private NumericUpDown nm_GridY;
        private Label label6;
        private NumericUpDown nm_YRailSize;
        private NumericUpDown nm_XRailSize;
        private Label label7;
        private NumericUpDown nm_YMouseBite;
        private Label label10;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label11;
        private NumericUpDown nm_XMouseBite;
    }
}