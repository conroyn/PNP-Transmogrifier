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
    public partial class PcbAndPanelWindow : Form
    {
        public Project project = new Project();
        public bool ProjectModified = false;

        public PcbAndPanelWindow()
        {
            InitializeComponent();
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            ProjectModified = true;
            project.Pcb.SizeX = Convert.ToDouble(nm_PcbSizeX.Value);
            project.Pcb.SizeY = Convert.ToDouble(nm_PcbSizeY.Value);
            project.Pcb.Thickness = Convert.ToDouble(nm_PcbHeight.Value);

            project.Pcb.Panalized = cb_PanelEn.Checked;

            project.Pcb.PanelCountX = Convert.ToInt32(nm_GridX.Value);
            project.Pcb.PanelCountY = Convert.ToInt32(nm_GridY.Value);
            project.Pcb.PanelRailX = Convert.ToDouble(nm_XRailSize.Value);
            project.Pcb.PanelRailY = Convert.ToDouble(nm_YRailSize.Value);
            project.Pcb.PanelMouseBiteX = Convert.ToDouble(nm_XMouseBite.Value);
            project.Pcb.PanelMouseBiteY = Convert.ToDouble(nm_YMouseBite.Value);

            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            gb_PanelSettings.Enabled = cb_PanelEn.Checked;
        }

        private void PcbAndPanelWindow_Load(object sender, EventArgs e)
        {
            if (project == null)
            {
                this.Close();
            }
            else
            {
                nm_PcbSizeX.Value = Convert.ToDecimal(project.Pcb.SizeX);
                nm_PcbSizeY.Value = Convert.ToDecimal(project.Pcb.SizeY);
                nm_PcbHeight.Value = Convert.ToDecimal(project.Pcb.Thickness);
                cb_PanelEn.Checked = project.Pcb.Panalized;

                if (project.Pcb.PanelCountX < 1)
                {
                    nm_GridX.Value = 1;
                }
                else
                {
                    nm_GridX.Value = Convert.ToDecimal(project.Pcb.PanelCountX);
                }
                if (project.Pcb.PanelCountY < 1)
                {
                    nm_GridY.Value = 1;
                }
                else
                {
                    nm_GridY.Value = Convert.ToDecimal(project.Pcb.PanelCountY);
                }
                nm_XRailSize.Value = Convert.ToDecimal(project.Pcb.PanelRailX);
                nm_YRailSize.Value = Convert.ToDecimal(project.Pcb.PanelRailY);
                nm_XMouseBite.Value = Convert.ToDecimal(project.Pcb.PanelMouseBiteX);
                nm_YMouseBite.Value = Convert.ToDecimal(project.Pcb.PanelMouseBiteY);

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
