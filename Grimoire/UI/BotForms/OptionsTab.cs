using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Grimoire.Botting;
using Grimoire.Game.Data;

namespace Grimoire.UI.BotForms
{
    public partial class OptionsTab : Form
    {
        public static OptionsTab Instance { get; } = new OptionsTab();

        public bool Relogin
        {
            get => chkRelog.Checked;
            set => chkRelog.Checked = value;
        }

        public bool ReloginRetry
        {
            get => chkRelogRetry.Checked;
            set => chkRelogRetry.Checked = value;
        }

        public int ReloginDelay
        {
            get => (int) numRelogDelay.Value;
            set => numRelogDelay.Value = value;
        }

        public Server ReloginServer => (Server) cbServers.SelectedItem;

        public List<string> NotificationDrops
        {
            get => lstSoundItems.Items.Cast<string>().ToList();
            set
            {
                if (value == null)
                    lstSoundItems.Items.Clear();
                else lstSoundItems.Items.AddRange(value.ToArray());
            }
        }

        public bool InfiniteRange
        {
            get => chkInfiniteRange.Checked;
            set => chkInfiniteRange.Checked = value;
        }

        public bool ProvokeMonsters
        {
            get => chkProvoke.Checked;
            set => chkProvoke.Checked = value;
        }

        public bool EnemyMagnet
        {
            get => chkMagnet.Checked;
            set => chkMagnet.Checked = value;
        }

        public bool KillLag
        {
            get => chkLag.Checked;
            set => chkLag.Checked = value;
        }

        public bool HidePlayers
        {
            get => chkHidePlayers.Checked;
            set => chkHidePlayers.Checked = value;
        }

        public bool SkipCutscenes
        {
            get => chkSkipCutscenes.Checked;
            set => chkSkipCutscenes.Checked = value;
        }

        public bool DisableAnims
        {
            get => chkDisableAnims.Checked;
            set => chkDisableAnims.Checked = value;
        }

        public int WalkSpeed
        {
            get => (int) numWalkSpeed.Value;
            set => numWalkSpeed.Value = value;
        }

        private OptionsTab()
        {
            InitializeComponent();
            TopLevel = false;
        }

        private void Options_Load(object sender, EventArgs e)
        {
            cbServers.DisplayMember = "Name";
            OptionsManager.StateChanged += OnOptionsStateChanged;
        }

        private void btnSoundAdd_Click(object sender, EventArgs e)
        {
            if (txtSoundItem.TextLength > 0)
                lstSoundItems.Items.Add(txtSoundItem.Text);
        }

        private void btnSoundDelete_Click(object sender, EventArgs e)
        {
            int index = lstSoundItems.SelectedIndex;
            if (index > -1)
                lstSoundItems.Items.RemoveAt(index);
        }

        private void btnSoundClear_Click(object sender, EventArgs e)
        {
            lstSoundItems.Items.Clear();
        }

        private void btnSoundTest_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
                Console.Beep();
        }

        private void chkInfiniteRange_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.InfiniteRange = chkInfiniteRange.Checked;
        }

        private void chkProvoke_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.ProvokeMonsters = chkProvoke.Checked;
        }

        private void chkMagnet_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.EnemyMagnet = chkMagnet.Checked;
        }

        private void chkLag_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.LagKiller = chkLag.Checked;
        }

        private void chkHidePlayers_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.HidePlayers = chkHidePlayers.Checked;
        }

        private void chkSkipCutscenes_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.SkipCutscenes = chkSkipCutscenes.Checked;
        }

        private void numWalkSpeed_ValueChanged(object sender, EventArgs e)
        {
            OptionsManager.WalkSpeed = (int)numWalkSpeed.Value;
        }

        private void chkDisableAnims_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.DisableAnimations = chkDisableAnims.Checked;
        }

        private void OnOptionsStateChanged(bool state)
        {
            if (InvokeRequired)
                Invoke(new Action(() => chkEnableSettings.Checked = state));
            else
                chkEnableSettings.Checked = state;
        }

        private void chkEnableSettings_Click(object sender, EventArgs e)
        {
            if (chkEnableSettings.Checked)
                OptionsManager.Start();
            else
                OptionsManager.Stop();
        }

        public void OnServersLoaded(Server[] servers)
        {
            if (servers?.Length > 0 && cbServers.Items.Count <= 1)
            {
                cbServers.Items.AddRange(servers);
                cbServers.SelectedIndex = 0;
            }
        }

        public void SetReloginServer(Server server)
        {
            cbServers.SelectedItem = cbServers.Items.Cast<Server>()
                .FirstOrDefault(s => s.Name.Equals(server.Name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
