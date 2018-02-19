using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Grimoire.Networking;
using Grimoire.Tools;

namespace Grimoire.UI
{
    public partial class PacketSpammer : Form
    {
        public static PacketSpammer Instance { get; } = new PacketSpammer();

        private PacketSpammer()
        {
            InitializeComponent();
            Root.Instance.SizeChanged += Root_SizeChanged;
            Root.Instance.VisibleChanged += Root_VisibleChanged;
        }

        private void Root_SizeChanged(object sender, EventArgs e)
        {
            FormWindowState state = ((Form)sender).WindowState;
            if (state != FormWindowState.Maximized)
                WindowState = state;
        }

        private void Root_VisibleChanged(object sender, EventArgs e)
        {
            Visible = ((Form)sender).Visible;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstPackets.Items.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtPacket.Text.Length > 0)
            {
                lstPackets.Items.Add(txtPacket.Text);
                txtPacket.Clear();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lstPackets.Items.Count > 0)
            {
                SaveConfig();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            lstPackets.Items.Clear();
            LoadConfig();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Spammer.Instance.Stop();
            Spammer.Instance.IndexChanged -= IndexChanged;
            SetButtonsEnabled(true);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (lstPackets.Items.Count > 0)
            {
                SetButtonsEnabled(false);
                List<string> packets = lstPackets.Items.Cast<string>().ToList();
                int delay = (int) numDelay.Value;
                Spammer.Instance.IndexChanged += IndexChanged;
                Spammer.Instance.Start(packets, delay);
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (txtPacket.TextLength > 0)
            {
                btnSend.Enabled = false;
                await Proxy.Instance.SendToServer(txtPacket.Text);
                btnSend.Enabled = true;
            }
        }

        private void PacketSpammer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        /* XML is only used here because all other bots use this format and
           Grimoire compatibility was requested */
        private void SaveConfig()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Save spammer file";
                ofd.Filter = "XML files|*.xml";
                ofd.CheckFileExists = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (XmlWriter xw = XmlWriter.Create(ofd.FileName))
                    {
                        xw.WriteStartElement("autoer");
                        foreach (string p in lstPackets.Items)
                        {
                            xw.WriteElementString("packet", p);
                        }
                        xw.WriteElementString("author", "Author");
                        xw.WriteElementString("spamspeed", numDelay.Value.ToString());
                        xw.WriteEndElement();
                    }
                }
            }
        }

        /* XML is only used here because all other bots use this format and
           Grimoire compatibility was requested */
        private void LoadConfig()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Load spammer file";
                ofd.Filter = "XML files|*.xml";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    XElement xelement = XElement.Load(ofd.FileName);

                    foreach (XElement entry in xelement.Nodes())
                    {
                        if (entry.Name == "packet")
                        {
                            lstPackets.Items.Add(entry.Value);
                        }
                        else if (entry.Name == "spamspeed")
                        {
                            string d = entry.Name.ToString();
                            numDelay.Value = d.All(char.IsDigit) ? int.Parse(d) : 2000;
                        }
                    }
                }
            }
        }

        private void SetButtonsEnabled(bool enabled)
        {
            btnStart.Enabled = enabled;
            btnAdd.Enabled = enabled;
            btnClear.Enabled = enabled;
            btnLoad.Enabled = enabled;
        }

        private void IndexChanged(int index)
        {
            lstPackets.Invoke(new Action(() => { lstPackets.SelectedIndex = index; }));
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int index = lstPackets.SelectedIndex;
            if (index > -1)
                lstPackets.Items.RemoveAt(index);
        }
    }
}
