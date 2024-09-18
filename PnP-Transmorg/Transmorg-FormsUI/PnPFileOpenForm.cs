using Lib_Transmorg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Transmorg_FormsUI
{
    public partial class PnPFileOpenForm : Form
    {
        public InputCsvMapping? InputCsvMapping = null;
        public string FilePath = string.Empty;
        public bool cancel = true;
        private bool init = false;

        private string[]? lines = null;

        string AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string AppFolder = "TransmorgPnP";
        string ImportFormatFile = "CsvImportFormat.json";
        string FormatFile = string.Empty;

        public PnPFileOpenForm()
        {
            InitializeComponent();
            FormatFile = Path.Combine(AppDataFolder, AppFolder, ImportFormatFile);
            if (File.Exists(FormatFile))
            {
                InputCsvMapping? Mapping = JsonSerializer.Deserialize<InputCsvMapping>(File.ReadAllText(FormatFile));
                if (Mapping != null)
                {
                    InputCsvMapping = Mapping;
                }
            }
            OpenHandler();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenHandler();
        }

        public void OpenHandler()
        {
            string filePath = string.Empty;
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                fileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = fileDialog.FileName;
                }
            }

            if (filePath != string.Empty && File.Exists(filePath))
            {
                tb_filePath.Text = filePath;
                FilePath = filePath;
                using (var fstream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var reader = new StreamReader(fstream))
                {
                    bool done = false;
                    List<string> readLines = new List<string>();
                    while (!done)
                    {
                        string? line = reader.ReadLine();
                        if(line == null)
                        {
                            done = true;
                        }
                        else
                        {
                            readLines.Add(line);
                        }

                    }
                    lines = readLines.ToArray();
                }
                nm_headeroffset.Maximum = lines.Length - 1;
                if (InputCsvMapping != null)
                {
                    init = true;
                    nm_headeroffset.Value = InputCsvMapping.LinesToSkip;
                    init = false;
                    cb_refDes.Items.Clear();
                    cb_refDes.Items.Add(InputCsvMapping.DesignatorHeader);
                    cb_refDes.SelectedIndex = 0;
                    cb_partNum.Items.Clear();
                    cb_partNum.Items.Add(InputCsvMapping.PartNumHeader);
                    cb_partNum.SelectedIndex = 0;
                    cb_description.Items.Clear();
                    cb_description.Items.Add(InputCsvMapping.DesignDescriptionHeader);
                    cb_description.SelectedIndex = 0;
                    cb_XMid.Items.Clear();
                    cb_XMid.Items.Add(InputCsvMapping.MidXHeader);
                    cb_XMid.SelectedIndex = 0;
                    cb_YMid.Items.Clear();
                    cb_YMid.Items.Add(InputCsvMapping.MidYHeader);
                    cb_YMid.SelectedIndex = 0;
                    cb_Rotation.Items.Clear();
                    cb_Rotation.Items.Add(InputCsvMapping.RotationHeader);
                    cb_Rotation.SelectedIndex = 0;
                    cb_height.Items.Clear();
                    cb_height.Items.Add(InputCsvMapping.HeightHeader);
                    cb_height.SelectedIndex = 0;
                    cb_PcbSide.Items.Clear();
                    cb_PcbSide.Items.Add(InputCsvMapping.LayerHeader);
                    cb_PcbSide.SelectedIndex = 0;
                    nm_XOriginOffset.Value = (decimal)InputCsvMapping.XCenterOffset;
                    nm_YOriginOffset.Value = (decimal)InputCsvMapping.YCenterOffset;
                }
                else
                {
                    InputCsvMapping = new InputCsvMapping();
                }
            }
            else
            {
                lines = null;
                nm_headeroffset.Maximum = 100;
            }
            UpdateLines(false);
        }

        public void UpdateLines(bool clear = true)
        {
            string headerLine = string.Empty;
            if (lines != null)
            {
                if (nm_headeroffset.Value <= 0)
                {
                    headerLine = lines[0];
                    rtb_HeaderLines.Clear();
                    rtb_HeaderLines.AppendText(Environment.NewLine);
                    rtb_HeaderLines.AppendText(headerLine.Replace("\"", "") + Environment.NewLine, Color.DarkGreen);
                    rtb_HeaderLines.AppendText(lines[1], Color.Black);
                }
                else if (nm_headeroffset.Value >= lines.Length - 1)
                {
                    headerLine = lines[lines.Length - 1];
                    rtb_HeaderLines.Clear();
                    rtb_HeaderLines.AppendText(lines[lines.Length - 2].Replace("\"", "") + Environment.NewLine, Color.LightGray);
                    rtb_HeaderLines.AppendText(headerLine + Environment.NewLine, Color.DarkGreen);
                    rtb_HeaderLines.AppendText(Environment.NewLine);
                }
                else
                {
                    int index = Convert.ToInt32(nm_headeroffset.Value);
                    headerLine = lines[index];
                    rtb_HeaderLines.Clear();
                    rtb_HeaderLines.AppendText(lines[index - 1] + Environment.NewLine, Color.LightGray);
                    rtb_HeaderLines.AppendText(headerLine.Replace("\"", "") + Environment.NewLine, Color.DarkGreen);
                    rtb_HeaderLines.AppendText(lines[index + 1] + Environment.NewLine, Color.Black);
                }
                if (headerLine.StartsWith("\""))
                {
                    InputCsvMapping.QuotedValues = true;
                }
                string[] headers = headerLine.Replace("\"", "").Split(',');
                if (clear)
                {
                    cb_refDes.Items.Clear();
                    cb_partNum.Items.Clear();
                    cb_description.Items.Clear();
                    cb_XMid.Items.Clear();
                    cb_YMid.Items.Clear();
                    cb_Rotation.Items.Clear();
                    cb_height.Items.Clear();
                    cb_PcbSide.Items.Clear();
                }
                foreach (string header in headers)
                {
                    if (!cb_refDes.Items.Contains(header)) cb_refDes.Items.Add(header);
                    if (!cb_partNum.Items.Contains(header)) cb_partNum.Items.Add(header);
                    if (!cb_description.Items.Contains(header)) cb_description.Items.Add(header);
                    if (!cb_XMid.Items.Contains(header)) cb_XMid.Items.Add(header);
                    if (!cb_YMid.Items.Contains(header)) cb_YMid.Items.Add(header);
                    if (!cb_Rotation.Items.Contains(header)) cb_Rotation.Items.Add(header);
                    if (!cb_height.Items.Contains(header)) cb_height.Items.Add(header);
                    if (!cb_PcbSide.Items.Contains(header)) cb_PcbSide.Items.Add(header);
                }
                if (cb_refDes.Items.Count > 0) cb_refDes.SelectedIndex = 0;
                if (cb_partNum.Items.Count > 0) cb_partNum.SelectedIndex = 0;
                if (cb_description.Items.Count > 0) cb_description.SelectedIndex = 0;
                if (cb_XMid.Items.Count > 0) cb_XMid.SelectedIndex = 0;
                if (cb_YMid.Items.Count > 0) cb_YMid.SelectedIndex = 0;
                if (cb_Rotation.Items.Count > 0) cb_Rotation.SelectedIndex = 0;
                if (cb_height.Items.Count > 0) cb_height.SelectedIndex = 0;
                if (cb_PcbSide.Items.Count > 0) cb_PcbSide.SelectedIndex = 0;
            }
            else
            {
                rtb_HeaderLines.Clear();
            }

        }

        private void CheckButton()
        {
            if (InputCsvMapping != null)
            {
                if (
                InputCsvMapping.DesignatorHeader == string.Empty ||
                InputCsvMapping.PartNumHeader == string.Empty ||
                InputCsvMapping.DesignDescriptionHeader == string.Empty ||
                InputCsvMapping.MidXHeader == string.Empty ||
                InputCsvMapping.MidYHeader == string.Empty ||
                InputCsvMapping.HeightHeader == string.Empty ||
                InputCsvMapping.RotationHeader == string.Empty ||
                InputCsvMapping.LayerHeader == string.Empty)
                {
                    btn_load.Enabled = false;
                }
                else
                {
                    btn_load.Enabled = true;
                }
            }
            else
            {
                btn_load.Enabled = false;
            }
        }

        private void nm_headeroffset_ValueChanged(object sender, EventArgs e)
        {
            if (!init)
            {
                InputCsvMapping.LinesToSkip = Convert.ToInt32(nm_headeroffset.Value);
                UpdateLines();
            }
        }

        private void cb_refDes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InputCsvMapping != null)
            {
                if (cb_refDes.SelectedItem != null)
                {
                    InputCsvMapping.DesignatorHeader = cb_refDes.SelectedItem.ToString();
                    CheckButton();
                }
                else
                {
                    InputCsvMapping.DesignatorHeader = string.Empty;
                }

            }
        }

        private void cb_partNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InputCsvMapping != null)
            {
                if (cb_partNum.SelectedItem != null)
                {
                    InputCsvMapping.PartNumHeader = cb_partNum.SelectedItem.ToString();
                    CheckButton();
                }
                else
                {
                    InputCsvMapping.PartNumHeader = string.Empty;
                }

            }
        }

        private void cb_XMid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InputCsvMapping != null)
            {
                if (cb_XMid.SelectedItem != null)
                {
                    InputCsvMapping.MidXHeader = cb_XMid.SelectedItem.ToString();
                    CheckButton();
                }
                else
                {
                    InputCsvMapping.MidYHeader = string.Empty;
                }

            }
        }

        private void cb_YMid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InputCsvMapping != null)
            {
                if (cb_YMid.SelectedItem != null)
                {
                    InputCsvMapping.MidYHeader = cb_YMid.SelectedItem.ToString();
                    CheckButton();
                }
                else
                {
                    InputCsvMapping.MidYHeader = string.Empty;
                }

            }
        }

        private void cb_Rotation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InputCsvMapping != null)
            {
                if (cb_Rotation.SelectedItem != null)
                {
                    InputCsvMapping.RotationHeader = cb_Rotation.SelectedItem.ToString();
                    CheckButton();
                }
                else
                {
                    InputCsvMapping.RotationHeader = string.Empty;
                }

            }
        }

        private void cb_height_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InputCsvMapping != null)
            {
                if (cb_height.SelectedItem != null)
                {
                    InputCsvMapping.HeightHeader = cb_height.SelectedItem.ToString();
                    CheckButton();
                }
                else
                {
                    InputCsvMapping.HeightHeader = string.Empty;
                }

            }
        }

        private void cb_PcbSide_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InputCsvMapping != null)
            {
                if (cb_PcbSide.SelectedItem != null)
                {
                    InputCsvMapping.LayerHeader = cb_PcbSide.SelectedItem.ToString();
                    CheckButton();
                }
                else
                {
                    InputCsvMapping.LayerHeader = string.Empty;
                }

            }

        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Path.Combine(AppDataFolder, AppFolder)))
            {
                Directory.CreateDirectory(Path.Combine(AppDataFolder, AppFolder));
            }
            if (File.Exists(FormatFile))
            {
                File.Delete(FormatFile);
            }
            string json = JsonSerializer.Serialize(InputCsvMapping);
            File.WriteAllText(FormatFile, json);
            cancel = false;
            this.Close();
        }

        private void cb_description_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InputCsvMapping != null)
            {
                if (cb_description.SelectedItem != null)
                {
                    InputCsvMapping.DesignDescriptionHeader = cb_description.SelectedItem.ToString();
                    CheckButton();
                }
                else
                {
                    InputCsvMapping.DesignDescriptionHeader = string.Empty;
                }

            }
        }

        private void nm_XOriginOffset_ValueChanged(object sender, EventArgs e)
        {
            if (InputCsvMapping != null)
            {
                InputCsvMapping.XCenterOffset = Convert.ToDouble(nm_XOriginOffset.Value);
            }
        }

        private void nm_YOriginOffset_ValueChanged(object sender, EventArgs e)
        {
            if (InputCsvMapping != null)
            {
                InputCsvMapping.YCenterOffset = Convert.ToDouble(nm_YOriginOffset.Value);
            }
        }
    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
