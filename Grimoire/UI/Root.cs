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
    public partial class Root : Form
    {
        public static Root Instance { get; private set; }
        public AxShockwaveFlash Client => flashPlayer;

        public Root()
        {
            InitializeComponent();
            Instance = this;
        }
        
        private void Root_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(Proxy.Instance.Start, TaskCreationOptions.LongRunning);
            flashPlayer.FlashCall += Flash.ProcessFlashCall;
            Flash.SwfLoadProgress += OnLoadProgress;
            Hotkeys.Instance.LoadHotkeys();
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
            ShowForm(BotManager.Instance);
        }

        private void fastTravelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(Travel.Instance);
        }

        private void loadersgrabbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(Loaders.Instance);
        }

        private void hotkeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(Hotkeys.Instance);
        }

        private void pluginManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(PluginManager.Instance);
        }

        private void snifferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(PacketLogger.Instance);
        }

        private void spammerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(PacketSpammer.Instance);
        }

        private void tampererToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(PacketTamperer.Instance);
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

        private void Root_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hotkeys.InstalledHotkeys.ForEach(h => h.Uninstall());
            KeyboardHook.Instance.Dispose();
            Proxy.Instance.Stop(true);
        }
    }
}
