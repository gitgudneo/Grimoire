using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Grimoire.Botting;
using Grimoire.Game.Data;
using Newtonsoft.Json;
using Grimoire.Game;
using Grimoire.UI.BotForms;

namespace Grimoire.UI
{
    public partial class BotManagerForm : Form
    {
        public static BotManagerForm Instance { get; } = new BotManagerForm();

        private IBotEngine _activeBotEngine = new Botting.Bot();

        public IBotEngine ActiveBotEngine
        {
            get => _activeBotEngine;
            set
            {
                if (_activeBotEngine.IsRunning)
                    throw new InvalidOperationException("Cannot set a new bot engine while the current one is running");
                _activeBotEngine = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        private ListBox SelectedList
        {
            get
            {
                switch (cbLists.SelectedIndex)
                {
                    case 1: return lstSkills;
                    case 2: return lstQuests;
                    case 3: return lstDrops;
                    case 4: return lstBoosts;
                    default: return lstCommands;
                }
            }
        }

        private BotManagerForm()
        {
            InitializeComponent();
            MainForm.Instance.SizeChanged += Root_SizeChanged;
            MainForm.Instance.VisibleChanged += Root_VisibleChanged;
            lstBoosts.DisplayMember = "Text";
            lstQuests.DisplayMember = "Text";
            lstSkills.DisplayMember = "Text";
            cbLists.SelectedIndex = 0;
            LoadForm(CombatTab.Instance);
        }

        private void Root_SizeChanged(object sender, EventArgs e)
        {
            FormWindowState state = ((Form) sender).WindowState;
            if (state != FormWindowState.Maximized)
                WindowState = state;
        }

        private void Root_VisibleChanged(object sender, EventArgs e)
        {
            Visible = ((Form) sender).Visible;
        }

        private void MoveListItem(int direction)
        {
            if (SelectedList.SelectedItem == null || SelectedList.SelectedIndex < 0)
                return;
            int newIndex = SelectedList.SelectedIndex + direction;
            if (newIndex < 0 || newIndex >= SelectedList.Items.Count)
                return;
            object selected = SelectedList.SelectedItem;
            SelectedList.Items.Remove(selected);
            SelectedList.Items.Insert(newIndex, selected);
            SelectedList.SetSelected(newIndex, true);
        }

        public Configuration GenerateConfiguration()
        {
            return new Configuration
            {
                Author = BotsTab.Instance.Author,
                Description = BotsTab.Instance.Description,
                Commands = lstCommands.Items.Cast<IBotCommand>().ToList(),
                Skills = lstSkills.Items.Cast<Skill>().ToList(),
                Quests = lstQuests.Items.Cast<Quest>().ToList(),
                Boosts = lstBoosts.Items.Cast<InventoryItem>().ToList(),
                Drops = lstDrops.Items.Cast<string>().ToList(),
                SkillDelay = CombatTab.Instance.SkillDelay,
                ExitCombatBeforeRest = CombatTab.Instance.ExitCombatBeforeRest,
                ExitCombatBeforeQuest = CombatTab.Instance.ExitCombatBeforeQuest,
                Server = OptionsTab.Instance.ReloginServer,
                AutoRelogin = OptionsTab.Instance.Relogin,
                RelogDelay = OptionsTab.Instance.ReloginDelay,
                RelogRetryUponFailure = OptionsTab.Instance.ReloginRetry,
                BotDelay = MiscTab.Instance.BotDelay,
                EnablePickup = ItemTab.Instance.Pickup,
                EnableRejection = ItemTab.Instance.Reject,
                WaitForSkills = CombatTab.Instance.WaitForSkills,
                SkipDelayIndexIf = MiscTab.Instance.SkipUnnecessaryDelays,
                InfiniteAttackRange = OptionsTab.Instance.InfiniteRange,
                ProvokeMonsters = OptionsTab.Instance.ProvokeMonsters,
                EnemyMagnet = OptionsTab.Instance.EnemyMagnet,
                LagKiller = OptionsTab.Instance.KillLag,
                HidePlayers = OptionsTab.Instance.HidePlayers,
                SkipCutscenes = OptionsTab.Instance.SkipCutscenes,
                WalkSpeed = OptionsTab.Instance.WalkSpeed,
                NotifyUponDrop = OptionsTab.Instance.NotificationDrops,
                RestIfMp = CombatTab.Instance.RestMana,
                RestIfHp = CombatTab.Instance.RestHealth,
                RestMp = CombatTab.Instance.RestManaValue,
                RestHp = CombatTab.Instance.RestHealthValue,
                RestartUponDeath = MiscTab.Instance.RestartUponDeath
            };
        }

        public void ApplyConfiguration(Configuration config)
        {
            if (config == null)
                return;

            if (!MiscTab.Instance.Merge || ActiveBotEngine.IsRunning)
            {
                lstCommands.Items.Clear();
                lstBoosts.Items.Clear();
                lstDrops.Items.Clear();
                lstQuests.Items.Clear();
                lstSkills.Items.Clear();
                OptionsTab.Instance.NotificationDrops = null;
            }

            BotsTab.Instance.Author = config.Author ?? "Author";
            BotsTab.Instance.Description = config.Description ?? "Description";

            if (config.Commands?.Count > 0)
                lstCommands.Items.AddRange(config.Commands.ToArray());
            if (config.Skills?.Count > 0)
                lstSkills.Items.AddRange(config.Skills.ToArray());
            if (config.Quests?.Count > 0)
                lstQuests.Items.AddRange(config.Quests.ToArray());
            if (config.Boosts?.Count > 0)
                lstBoosts.Items.AddRange(config.Boosts.ToArray());
            if (config.Drops?.Count > 0)
                lstDrops.Items.AddRange(config.Drops.ToArray());

            CombatTab.Instance.SkillDelay = config.SkillDelay;
            CombatTab.Instance.ExitCombatBeforeRest = config.ExitCombatBeforeRest;
            CombatTab.Instance.ExitCombatBeforeQuest = config.ExitCombatBeforeQuest;
            OptionsTab.Instance.SetReloginServer(config.Server);
            OptionsTab.Instance.Relogin = config.AutoRelogin;
            OptionsTab.Instance.ReloginDelay = config.RelogDelay;
            OptionsTab.Instance.ReloginRetry = config.RelogRetryUponFailure;
            MiscTab.Instance.BotDelay = config.BotDelay;
            ItemTab.Instance.Pickup = config.EnablePickup;
            ItemTab.Instance.Reject = config.EnableRejection;
            CombatTab.Instance.WaitForSkills = config.WaitForSkills;
            MiscTab.Instance.SkipUnnecessaryDelays = config.SkipDelayIndexIf;
            OptionsTab.Instance.InfiniteRange = config.InfiniteAttackRange;
            OptionsTab.Instance.ProvokeMonsters = config.ProvokeMonsters;
            OptionsTab.Instance.EnemyMagnet = config.EnemyMagnet;
            OptionsTab.Instance.HidePlayers = config.HidePlayers;
            OptionsTab.Instance.SkipCutscenes = config.SkipCutscenes;
            OptionsTab.Instance.WalkSpeed = config.WalkSpeed <= 0 ? 8 : config.WalkSpeed;
            if (config.NotifyUponDrop?.Count > 0)
                OptionsTab.Instance.NotificationDrops = config.NotifyUponDrop;
            CombatTab.Instance.RestManaValue = config.RestMp;
            CombatTab.Instance.RestHealthValue = config.RestHp;
            CombatTab.Instance.RestMana = config.RestIfMp;
            CombatTab.Instance.RestHealth = config.RestIfHp;
            MiscTab.Instance.RestartUponDeath = config.RestartUponDeath;
        }

        private void OnConfigurationChanged(Configuration config)
        {
            Invoke(new Action(() => ApplyConfiguration(config)));
        }

        private void OnIndexChanged(int index)
        {
            if (index > -1 && index < lstCommands.Items.Count)
                Invoke(new Action(() => { lstCommands.SelectedIndex = index; }));
        }

        private void OnIsRunningChanged(bool isRunning)
        {
            Invoke(new Action(() =>
            {
                if (!isRunning)
                {
                    ActiveBotEngine.IsRunningChanged -= OnIsRunningChanged;
                    ActiveBotEngine.IndexChanged -= OnIndexChanged;
                    ActiveBotEngine.ConfigurationChanged -= OnConfigurationChanged;

                    btnUp.Enabled = true;
                    btnDown.Enabled = true;
                    btnClear.Enabled = true;
                    btnRemove.Enabled = true;
                }

                chkEnable.Checked = isRunning;
            }));
        }

        public void AddCommand(IBotCommand cmd)
        {
            lstCommands.Items.Add(cmd);
        }

        public void AddSkill(Skill skill)
        {
            lstSkills.Items.Add(skill ?? throw new ArgumentNullException(nameof(skill)));
        }

        public void AddWhitelistedItem(string item)
        {
            lstDrops.Items.Add(item ?? throw new ArgumentNullException(nameof(item)));
        }

        public void AddBoost(InventoryItem boost)
        {
            lstBoosts.Items.Add(boost ?? throw new ArgumentNullException(nameof(boost)));
        }

        public void AddQuest(Quest quest)
        {
            lstQuests.Items.Add(quest ?? throw new ArgumentNullException(nameof(quest)));
        }

        private void lstCommands_DoubleClick(object sender, EventArgs e)
        {
            int index = lstCommands.SelectedIndex;
            if (index > -1)
            {
                object cmd = lstCommands.Items[index];

                string mod = CommandEditorForm.Show(
                    JsonConvert.SerializeObject(cmd, 
                        Formatting.Indented, Configuration.SerializerSettings));

                if (mod != null)
                {
                    try
                    {
                        IBotCommand modifiedCmd = (IBotCommand)JsonConvert.DeserializeObject(mod, cmd.GetType());
                        lstCommands.Items.Remove(cmd);
                        lstCommands.Items.Insert(index, modifiedCmd);
                    }
                    catch { }
                }
            }
        }

        private void chkEnable_Click(object sender, EventArgs e)
        {
            if (!Player.IsAlive || !Player.IsLoggedIn || lstCommands.Items.Count <= 0)
            {
                chkEnable.Checked = false;
                return;
            }

            if (chkEnable.Checked)
            {
                btnUp.Enabled = false;
                btnDown.Enabled = false;
                btnClear.Enabled = false;
                btnRemove.Enabled = false;
                ActiveBotEngine.IsRunningChanged += OnIsRunningChanged;
                ActiveBotEngine.IndexChanged += OnIndexChanged;
                ActiveBotEngine.ConfigurationChanged += OnConfigurationChanged;
                ActiveBotEngine.Start(GenerateConfiguration());
            }
            else
            {
                ActiveBotEngine.Stop();
            }
        }

        private void LoadForm(Form form)
        {
            Form cur = (Form) pnlContainer.Tag;

            if (cur != form)
            {
                cur?.Hide();
                pnlContainer.Tag = form;
                Size = new Size(form.Width + 239, form.Height + 69);
                pnlContainer.Size = form.Size;
                form.Parent = pnlContainer;
                form.Show();
            }
        }

        private void combatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(CombatTab.Instance);
        }

        private void mapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(MapTab.Instance);
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(ItemTab.Instance);
        }

        private void questToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(QuestTab.Instance);
        }

        private void miscToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(MiscTab.Instance);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(OptionsTab.Instance);
        }

        private void botsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(BotsTab.Instance);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int selected = SelectedList.SelectedIndex;
            if (selected > -1)
            {
                SelectedList.Items.RemoveAt(selected);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveListItem(1);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveListItem(-1);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                lstBoosts.Items.Clear();
                lstCommands.Items.Clear();
                lstDrops.Items.Clear();
                lstQuests.Items.Clear();
                lstSkills.Items.Clear();
            }
            else
                SelectedList.Items.Clear();
        }

        private void cbLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBoosts.Visible = SelectedList == lstBoosts;
            lstCommands.Visible = SelectedList == lstCommands;
            lstDrops.Visible = SelectedList == lstDrops;
            lstQuests.Visible = SelectedList == lstQuests;
            lstSkills.Visible = SelectedList == lstSkills;
        }

        private void BotManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
