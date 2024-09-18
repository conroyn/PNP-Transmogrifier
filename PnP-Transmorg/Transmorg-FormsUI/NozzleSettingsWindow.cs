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
    public partial class NozzleSettingsWindow : Form
    {
        public NozzleSettingsWindow()
        {
            InitializeComponent();
        }

        public Project project = new Project();
        public bool changed = false;
        private class NozzleStats
        {
            public TextBox Optimal;
            public TextBox Alternate;
            public TextBox Total;
        }

        private List<NozzleStats> statBoxes;
        private List<TextBox> actualUsageBoxes;

        private void NozzleSettingsWindow_Load(object sender, EventArgs e)
        {
            statBoxes = new List<NozzleStats>
            {
                new NozzleStats
                {
                    Optimal = tb_cn030Opt,
                    Alternate = tb_cn030Alt,
                    Total = tb_cn030Total,
                },
                new NozzleStats
                {
                    Optimal = tb_cn040Opt,
                    Alternate = tb_cn040Alt,
                    Total = tb_cn040Total,
                },
                new NozzleStats
                {
                    Optimal = tb_cn065Opt,
                    Alternate = tb_cn065Alt,
                    Total = tb_cn065Total,
                },
                new NozzleStats
                {
                    Optimal = tb_cn100Opt,
                    Alternate = tb_cn100Alt,
                    Total = tb_cn100Total,
                },
                new NozzleStats
                {
                    Optimal = tb_cn140Opt,
                    Alternate = tb_cn140Alt,
                    Total = tb_cn140Total,
                },
                new NozzleStats
                {
                    Optimal = tb_cn220Opt,
                    Alternate = tb_cn220Alt,
                    Total = tb_cn220Total,
                },
                new NozzleStats
                {
                    Optimal = tb_cn400Opt,
                    Alternate = tb_cn400Alt,
                    Total = tb_cn400Total,
                },
                new NozzleStats
                {
                    Optimal = tb_cn750Opt,
                    Alternate = tb_cn750Alt,
                    Total = tb_cn750Total,
                },
                new NozzleStats
                {
                    Optimal = tb_yx01Opt,
                    Alternate = tb_yx01Alt,
                    Total = tb_yx01Total,
                },
                new NozzleStats
                {
                    Optimal = tb_yx02Opt,
                    Alternate = tb_yx02Alt,
                    Total = tb_yx02Total,
                },
                new NozzleStats
                {
                    Optimal = tb_yx03Opt,
                    Alternate = tb_yx03Alt,
                    Total = tb_yx03Total,
                },
                new NozzleStats
                {
                    Optimal = tb_yx04Opt,
                    Alternate = tb_yx04Alt,
                    Total = tb_yx04Total,
                },
                new NozzleStats
                {
                    Optimal = tb_yx05Opt,
                    Alternate = tb_yx05Alt,
                    Total = tb_yx05Total,
                },
                new NozzleStats
                {
                    Optimal = tb_yx06Opt,
                    Alternate = tb_yx06Alt,
                    Total = tb_yx06Total,
                },
                new NozzleStats
                {
                    Optimal = tb_yxOtherOpt,
                    Alternate = tb_yxOtherAlt,
                    Total = tb_yxOtherTotal,
                }
            };
            actualUsageBoxes = new List<TextBox>
            {
                tb_cn030Actual,
                tb_cn040Actual,
                tb_cn065Actual,
                tb_cn100Actual,
                tb_cn140Actual,
                tb_cn220Actual,
                tb_cn400Actual,
                tb_cn750Actual,
                tb_yx01Actual,
                tb_yx02Actual,
                tb_yx03Actual,
                tb_yx04Actual,
                tb_yx05Actual,
                tb_yx06Actual,
                tb_yxOtherActual
            };

            foreach (NeodenNozzles nozzle in Enum.GetValues(typeof(NeodenNozzles)))
            {
                if (nozzle == NeodenNozzles.Unset)
                {
                    continue;
                }
                if (nozzle == NeodenNozzles.None)
                {
                    cb_head1.Items.Add(nozzle);
                    cb_head2.Items.Add(nozzle);
                    cb_holder1.Items.Add(nozzle);
                    cb_holder2.Items.Add(nozzle);
                    continue;
                }
                cb_head1.Items.Add(nozzle);
                cb_head2.Items.Add(nozzle);
                cb_holder1.Items.Add(nozzle);
                cb_holder2.Items.Add(nozzle);
                int PrimaryChoice = project.Parts.Count(item => item.OptimalNozzle == nozzle && !item.Skip);
                int AlternateChoice = project.Parts.Count(item => item.AlternateNozzle == nozzle && !item.Skip);
                int total = PrimaryChoice + AlternateChoice;
                statBoxes[(int)nozzle - 1].Optimal.Text = PrimaryChoice.ToString();
                statBoxes[(int)nozzle - 1].Alternate.Text = AlternateChoice.ToString();
                statBoxes[(int)nozzle - 1].Total.Text = total.ToString();
            }
            cb_head1.Text = project.NozzleSet.Head1.ToString();
            cb_head2.Text = project.NozzleSet.Head2.ToString();
            cb_holder1.Text = project.NozzleSet.Holder1.ToString();
            cb_holder2.Text = project.NozzleSet.Holder2.ToString();

        }

        private bool CountNozzleUse()
        {
            bool valid = true;
            int[] NozzleUse = new int[Enum.GetNames(typeof(NeodenNozzles)).Length];
            List<NeodenNozzles> nozzles = new List<NeodenNozzles>();

            if (Enum.TryParse(typeof(NeodenNozzles), cb_head1.Text, out object Head1Nozzle))
            {
                nozzles.Add((NeodenNozzles)Head1Nozzle);
            }
            if (Enum.TryParse(typeof(NeodenNozzles), cb_head2.Text, out object Head2Nozzle))
            {
                nozzles.Add((NeodenNozzles)Head2Nozzle);
            }
            if (Enum.TryParse(typeof(NeodenNozzles), cb_holder1.Text, out object Holder1Nozzle))
            {
                nozzles.Add((NeodenNozzles)Holder1Nozzle);
            }
            if (Enum.TryParse(typeof(NeodenNozzles), cb_holder2.Text, out object Holder2Nozzle))
            {
                nozzles.Add((NeodenNozzles)Holder2Nozzle);
            }

            foreach (Part part in project.Parts)
            {
                if (!part.Skip)
                {
                    if (nozzles.Contains(part.OptimalNozzle))
                    {
                        NozzleUse[(int)part.OptimalNozzle]++;
                    }
                    else if (nozzles.Contains(part.AlternateNozzle))
                    {
                        NozzleUse[(int)part.AlternateNozzle]++;
                    }
                    else if (part.OptimalNozzle != NeodenNozzles.Unset)
                    {
                        NozzleUse[(int)part.OptimalNozzle]++;
                    }
                }
            }
            for (int i = 0; i < actualUsageBoxes.Count(); i++)
            {
                actualUsageBoxes[i].Text = NozzleUse[i + 1].ToString();
                if (!nozzles.Contains((NeodenNozzles)i + 1))
                {
                    if (NozzleUse[i + 1] > 0)
                    {
                        actualUsageBoxes[i].BackColor = Color.Red;
                        valid = false;
                    }
                    else
                    {
                        actualUsageBoxes[i].BackColor = SystemColors.Control;
                    }

                }
                else
                {
                    actualUsageBoxes[i].BackColor = SystemColors.ActiveCaption;
                }
            }
            return valid;

        }

        private void cb_head1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CountNozzleUse();
        }

        private void cb_head2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CountNozzleUse();
        }

        private void cb_holder1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CountNozzleUse();
        }

        private void cb_holder2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CountNozzleUse();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Enum.TryParse(typeof(NeodenNozzles), cb_head1.Text, out object result))
            {
                project.NozzleSet.Head1 = (NeodenNozzles)result;
            }
            else
            {
                project.NozzleSet.Head1 = NeodenNozzles.None;
            }
            if (Enum.TryParse(typeof(NeodenNozzles), cb_head2.Text, out result))
            {
                project.NozzleSet.Head2 = (NeodenNozzles)result;
            }
            else
            {
                project.NozzleSet.Head2 = NeodenNozzles.None;
            }
            if (Enum.TryParse(typeof(NeodenNozzles), cb_holder1.Text, out result))
            {
                project.NozzleSet.Holder1 = (NeodenNozzles)result;
            }
            else
            {
                project.NozzleSet.Holder1 = NeodenNozzles.None;
            }
            if (Enum.TryParse(typeof(NeodenNozzles), cb_holder2.Text, out result))
            {
                project.NozzleSet.Holder2 = (NeodenNozzles)result;
            }
            else
            {
                project.NozzleSet.Holder2 = NeodenNozzles.None;
            }
            changed = true;
            this.Close();
        }
    }
}
