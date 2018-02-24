using System;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using AxShockwaveFlashObjects;
using Grimoire.Game;
using Grimoire.Networking;
using Grimoire.Tools;

namespace Grimoire.UI
{
    public partial class MainForm : Form
    {
        public static MainForm Instance { get; } = new MainForm();

        public AxShockwaveFlash Client => flashPlayer;

        private MainForm()
        {
            InitializeComponent();
            Task.Factory.StartNew(Proxy.Instance.Start, TaskCreationOptions.LongRunning);
            flashPlayer.FlashCall += Flash.ProcessFlashCall;
            Flash.SwfLoadProgress += OnLoadProgress;
            InitFlashMovie();
        }

        private void OnLoadProgress(int progress)
        {
            if (progress < prgLoader.Maximum)
                prgLoader.Value = progress;
            else
            {
                Flash.SwfLoadProgress -= OnLoadProgress;
                flashPlayer.Visible = true;
                prgLoader.Visible = false;
            }
        }

        private void botToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ShowForm(BotManagerForm.Instance);
        }

        private void fastTravelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(TravelsForm.Instance);
        }

        private void loadersgrabbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(LoadersForm.Instance);
        }

        private void hotkeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(HotkeysForm.Instance);
        }

        private void pluginManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(PluginsForm.Instance);
        }

        private void snifferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(PacketLoggerForm.Instance);
        }

        private void spammerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(PacketSpammerForm.Instance);
        }

        private void tampererToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(PacketTampererForm.Instance);
        }

        public void ShowForm(Form form)
        {
            if (form.Visible)
            {
                form.Hide();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void InitFlashMovie()
        {
            byte[] swf = Properties.Resources.grimoire;

            using (MemoryStream stm = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(stm))
                {
                    writer.Write(8 + swf.Length);
                    writer.Write(0x55665566);
                    writer.Write(swf.Length);
                    writer.Write(swf);
                    stm.Seek(0, SeekOrigin.Begin);
                    flashPlayer.OcxState = new AxHost.State(stm, 1, false, null);
                }
            }
        }

        private void btnBank_Click(object sender, EventArgs e)
        {
            Player.Bank.Show();
        }

        private void cbCells_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cell = (string)cbCells.SelectedItem;
            if (cell != null)
            {
                string pad = (string)cbPads.SelectedItem;
                Player.MoveToCell(cell, pad ?? "Spawn");
            }
        }

        private void cbCells_Click(object sender, EventArgs e)
        {
            cbCells.Items.Clear();
            cbCells.Items.AddRange(World.Cells);
        }

        private void btnFPS_Click(object sender, EventArgs e)
        {
            Flash.Call("SetFPS", numFPS.Value.ToString());
        }
    }
}
