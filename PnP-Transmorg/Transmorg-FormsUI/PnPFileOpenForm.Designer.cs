namespace Transmorg_FormsUI
{
    partial class PnPFileOpenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnPFileOpenForm));
            tb_filePath = new TextBox();
            button1 = new Button();
            nm_headeroffset = new NumericUpDown();
            label1 = new Label();
            rtb_HeaderLines = new RichTextBox();
            cb_refDes = new ComboBox();
            cb_partNum = new ComboBox();
            cb_XMid = new ComboBox();
            cb_YMid = new ComboBox();
            cb_Rotation = new ComboBox();
            cb_height = new ComboBox();
            cb_PcbSide = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            btn_load = new Button();
            label4 = new Label();
            label10 = new Label();
            cb_description = new ComboBox();
            label11 = new Label();
            nm_YOriginOffset = new NumericUpDown();
            nm_XOriginOffset = new NumericUpDown();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            ((System.ComponentModel.ISupportInitialize)nm_headeroffset).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nm_YOriginOffset).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nm_XOriginOffset).BeginInit();
            SuspendLayout();
            // 
            // tb_filePath
            // 
            tb_filePath.Location = new Point(98, 9);
            tb_filePath.Margin = new Padding(3, 2, 3, 2);
            tb_filePath.Name = "tb_filePath";
            tb_filePath.ReadOnly = true;
            tb_filePath.Size = new Size(1015, 23);
            tb_filePath.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(10, 8);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(82, 22);
            button1.TabIndex = 1;
            button1.Text = "Browse";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // nm_headeroffset
            // 
            nm_headeroffset.Location = new Point(10, 51);
            nm_headeroffset.Margin = new Padding(3, 2, 3, 2);
            nm_headeroffset.Name = "nm_headeroffset";
            nm_headeroffset.Size = new Size(149, 23);
            nm_headeroffset.TabIndex = 2;
            nm_headeroffset.ValueChanged += nm_headeroffset_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 34);
            label1.Name = "label1";
            label1.Size = new Size(139, 15);
            label1.TabIndex = 3;
            label1.Text = "Offset to Column Names";
            // 
            // rtb_HeaderLines
            // 
            rtb_HeaderLines.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            rtb_HeaderLines.Location = new Point(164, 34);
            rtb_HeaderLines.Margin = new Padding(3, 2, 3, 2);
            rtb_HeaderLines.Name = "rtb_HeaderLines";
            rtb_HeaderLines.ReadOnly = true;
            rtb_HeaderLines.Size = new Size(949, 53);
            rtb_HeaderLines.TabIndex = 5;
            rtb_HeaderLines.Text = "";
            // 
            // cb_refDes
            // 
            cb_refDes.FormattingEnabled = true;
            cb_refDes.Location = new Point(12, 162);
            cb_refDes.Margin = new Padding(3, 2, 3, 2);
            cb_refDes.Name = "cb_refDes";
            cb_refDes.Size = new Size(133, 23);
            cb_refDes.TabIndex = 6;
            cb_refDes.SelectedIndexChanged += cb_refDes_SelectedIndexChanged;
            // 
            // cb_partNum
            // 
            cb_partNum.FormattingEnabled = true;
            cb_partNum.Location = new Point(149, 162);
            cb_partNum.Margin = new Padding(3, 2, 3, 2);
            cb_partNum.Name = "cb_partNum";
            cb_partNum.Size = new Size(133, 23);
            cb_partNum.TabIndex = 7;
            cb_partNum.SelectedIndexChanged += cb_partNum_SelectedIndexChanged;
            // 
            // cb_XMid
            // 
            cb_XMid.FormattingEnabled = true;
            cb_XMid.Location = new Point(427, 162);
            cb_XMid.Margin = new Padding(3, 2, 3, 2);
            cb_XMid.Name = "cb_XMid";
            cb_XMid.Size = new Size(133, 23);
            cb_XMid.TabIndex = 8;
            cb_XMid.SelectedIndexChanged += cb_XMid_SelectedIndexChanged;
            // 
            // cb_YMid
            // 
            cb_YMid.FormattingEnabled = true;
            cb_YMid.Location = new Point(566, 162);
            cb_YMid.Margin = new Padding(3, 2, 3, 2);
            cb_YMid.Name = "cb_YMid";
            cb_YMid.Size = new Size(133, 23);
            cb_YMid.TabIndex = 9;
            cb_YMid.SelectedIndexChanged += cb_YMid_SelectedIndexChanged;
            // 
            // cb_Rotation
            // 
            cb_Rotation.FormattingEnabled = true;
            cb_Rotation.Location = new Point(705, 162);
            cb_Rotation.Margin = new Padding(3, 2, 3, 2);
            cb_Rotation.Name = "cb_Rotation";
            cb_Rotation.Size = new Size(133, 23);
            cb_Rotation.TabIndex = 10;
            cb_Rotation.SelectedIndexChanged += cb_Rotation_SelectedIndexChanged;
            // 
            // cb_height
            // 
            cb_height.FormattingEnabled = true;
            cb_height.Location = new Point(844, 162);
            cb_height.Margin = new Padding(3, 2, 3, 2);
            cb_height.Name = "cb_height";
            cb_height.Size = new Size(133, 23);
            cb_height.TabIndex = 11;
            cb_height.SelectedIndexChanged += cb_height_SelectedIndexChanged;
            // 
            // cb_PcbSide
            // 
            cb_PcbSide.FormattingEnabled = true;
            cb_PcbSide.Location = new Point(983, 162);
            cb_PcbSide.Margin = new Padding(3, 2, 3, 2);
            cb_PcbSide.Name = "cb_PcbSide";
            cb_PcbSide.Size = new Size(133, 23);
            cb_PcbSide.TabIndex = 12;
            cb_PcbSide.SelectedIndexChanged += cb_PcbSide_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 145);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 13;
            label2.Text = "Ref. Designator";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(149, 145);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 14;
            label3.Text = "Part Number";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(427, 145);
            label5.Name = "label5";
            label5.Size = new Size(99, 15);
            label5.TabIndex = 16;
            label5.Text = "X Midpoint (mm)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(566, 145);
            label6.Name = "label6";
            label6.Size = new Size(99, 15);
            label6.TabIndex = 17;
            label6.Text = "Y Midpoint (mm)";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(705, 145);
            label7.Name = "label7";
            label7.Size = new Size(76, 15);
            label7.TabIndex = 18;
            label7.Text = "Part Rotation";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(844, 145);
            label8.Name = "label8";
            label8.Size = new Size(67, 15);
            label8.TabIndex = 19;
            label8.Text = "Part Height";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(983, 145);
            label9.Name = "label9";
            label9.Size = new Size(78, 15);
            label9.TabIndex = 20;
            label9.Text = "Part PCB Side";
            // 
            // btn_load
            // 
            btn_load.Enabled = false;
            btn_load.Location = new Point(1028, 121);
            btn_load.Margin = new Padding(3, 2, 3, 2);
            btn_load.Name = "btn_load";
            btn_load.Size = new Size(82, 22);
            btn_load.TabIndex = 21;
            btn_load.Text = "Load";
            btn_load.UseVisualStyleBackColor = true;
            btn_load.Click += btn_load_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 130);
            label4.Name = "label4";
            label4.Size = new Size(477, 15);
            label4.TabIndex = 15;
            label4.Text = "Set the offset from start of file to the column names, then map the column names below:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(288, 145);
            label10.Name = "label10";
            label10.Size = new Size(67, 15);
            label10.TabIndex = 23;
            label10.Text = "Description";
            // 
            // cb_description
            // 
            cb_description.FormattingEnabled = true;
            cb_description.Location = new Point(288, 162);
            cb_description.Margin = new Padding(3, 2, 3, 2);
            cb_description.Name = "cb_description";
            cb_description.Size = new Size(133, 23);
            cb_description.TabIndex = 22;
            cb_description.SelectedIndexChanged += cb_description_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Image = Properties.Resources.TextLineHeight_Flipped;
            label11.ImageAlign = ContentAlignment.MiddleLeft;
            label11.Location = new Point(9, 88);
            label11.Name = "label11";
            label11.Size = new Size(130, 15);
            label11.TabIndex = 27;
            label11.Text = "    X Origin Offset (mm)";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nm_YOriginOffset
            // 
            nm_YOriginOffset.DecimalPlaces = 4;
            nm_YOriginOffset.Location = new Point(183, 105);
            nm_YOriginOffset.Margin = new Padding(3, 2, 3, 2);
            nm_YOriginOffset.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nm_YOriginOffset.Name = "nm_YOriginOffset";
            nm_YOriginOffset.Size = new Size(150, 23);
            nm_YOriginOffset.TabIndex = 25;
            nm_YOriginOffset.ValueChanged += nm_YOriginOffset_ValueChanged;
            // 
            // nm_XOriginOffset
            // 
            nm_XOriginOffset.DecimalPlaces = 4;
            nm_XOriginOffset.Location = new Point(12, 105);
            nm_XOriginOffset.Margin = new Padding(3, 2, 3, 2);
            nm_XOriginOffset.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nm_XOriginOffset.Name = "nm_XOriginOffset";
            nm_XOriginOffset.Size = new Size(151, 23);
            nm_XOriginOffset.TabIndex = 24;
            nm_XOriginOffset.ValueChanged += nm_XOriginOffset_ValueChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Image = Properties.Resources.TextLineHeight;
            label12.ImageAlign = ContentAlignment.MiddleLeft;
            label12.Location = new Point(183, 88);
            label12.Name = "label12";
            label12.Size = new Size(130, 15);
            label12.TabIndex = 26;
            label12.Text = "    Y Origin Offset (mm)";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(339, 89);
            label13.Name = "label13";
            label13.Size = new Size(409, 15);
            label13.TabIndex = 28;
            label13.Text = "X and Y Origin Offsets are subtracted from the PnP CSV coordinates on load.";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(339, 107);
            label14.Name = "label14";
            label14.Size = new Size(461, 15);
            label14.TabIndex = 29;
            label14.Text = "This can be used to correct mismatches between Machine and PnP CSV origins points.";
            // 
            // PnPFileOpenForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1122, 196);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label11);
            Controls.Add(nm_YOriginOffset);
            Controls.Add(nm_XOriginOffset);
            Controls.Add(label12);
            Controls.Add(label10);
            Controls.Add(cb_description);
            Controls.Add(btn_load);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cb_PcbSide);
            Controls.Add(cb_height);
            Controls.Add(cb_Rotation);
            Controls.Add(cb_YMid);
            Controls.Add(cb_XMid);
            Controls.Add(cb_partNum);
            Controls.Add(cb_refDes);
            Controls.Add(rtb_HeaderLines);
            Controls.Add(label1);
            Controls.Add(nm_headeroffset);
            Controls.Add(button1);
            Controls.Add(tb_filePath);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PnPFileOpenForm";
            Text = "Open PnP CSV File";
            ((System.ComponentModel.ISupportInitialize)nm_headeroffset).EndInit();
            ((System.ComponentModel.ISupportInitialize)nm_YOriginOffset).EndInit();
            ((System.ComponentModel.ISupportInitialize)nm_XOriginOffset).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_filePath;
        private Button button1;
        private NumericUpDown nm_headeroffset;
        private Label label1;
        private RichTextBox rtb_HeaderLines;
        private ComboBox cb_refDes;
        private ComboBox cb_partNum;
        private ComboBox cb_XMid;
        private ComboBox cb_YMid;
        private ComboBox cb_Rotation;
        private ComboBox cb_height;
        private ComboBox cb_PcbSide;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button btn_load;
        private Label label4;
        private Label label10;
        private ComboBox cb_description;
        private Label label11;
        private NumericUpDown nm_YOriginOffset;
        private NumericUpDown nm_XOriginOffset;
        private Label label12;
        private Label label13;
        private Label label14;
    }
}