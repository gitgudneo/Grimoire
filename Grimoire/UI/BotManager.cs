using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Grimoire.Botting;
using Grimoire.Botting.Commands;
using Grimoire.Botting.Commands.Combat;
using Grimoire.Botting.Commands.Item;
using Grimoire.Botting.Commands.Map;
using Grimoire.Botting.Commands.Misc;
using Grimoire.Botting.Commands.Misc.Statements;
using Grimoire.Botting.Commands.Quest;
using Grimoire.Game.Data;
using Newtonsoft.Json;
using Grimoire.Game;
using Grimoire.Properties;

namespace Grimoire.UI
{
    // Something needs to be done about this monstrous class. Can we reduce the amount of controls?!?!?!
    public partial class BotManager : Form
    {
        public static BotManager Instance { get; } = new BotManager();

        private IBotEngine _activeBotEngine = new Bot();

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
                    case 1:
                        return lstSkills;
                    case 2:
                        return lstQuests;
                    case 3:
                        return lstDrops;
                    case 4:
                        return lstBoosts;
                    default: return lstCommands;
                }
            }
        }

        private List<StatementCommand> _statementCommands;
        private Dictionary<string, string> _defaultControlText;

        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            TypeNameHandling = TypeNameHandling.All
        };

        private BotManager()
        {
            InitializeComponent();
        }

        private void BotManager_Load(object sender, EventArgs e)
        {
            _panels = new[] {pnlCombat, pnlMap, pnlQuest, pnlItem, pnlMisc, pnlOptions, pnlSaved};
            pnlCombat.Size = new Size(379, 267);
            pnlMap.Size = new Size(343, 200);
            pnlQuest.Size = new Size(249, 137);
            pnlItem.Size = new Size(318, 276);
            pnlMisc.Size = new Size(442, 257);
            pnlOptions.Size = new Size(283, 315);
            pnlSaved.Size = new Size(438, 301);
            HidePanels(pnlCombat);
            lstBoosts.DisplayMember = "Text";
            lstQuests.DisplayMember = "Text";
            lstSkills.DisplayMember = "Text";
            cbBoosts.DisplayMember = "Name";
            cbServers.DisplayMember = "Name";
            cbStatement.DisplayMember = "Text";
            cbLists.SelectedIndex = 0;
            _statementCommands = JsonConvert.DeserializeObject<List<StatementCommand>>(Resources.statementcmds, _serializerSettings);
            _defaultControlText = JsonConvert.DeserializeObject<Dictionary<string, string>>(Resources.defaulttext, _serializerSettings);
            OptionsManager.StateChanged += OnOptionsStateChanged;
        }

        private void TextboxEnter(object sender, EventArgs e)
        {
            TextBox t = (TextBox) sender;
            if (t.Text == _defaultControlText[t.Name])
                t.Clear();
        }

        private void TextboxLeave(object sender, EventArgs e)
        {
            TextBox t = (TextBox) sender;
            if (string.IsNullOrEmpty(t.Text))
            {
                if (_defaultControlText.TryGetValue(t.Name, out string def))
                    t.Text = def;
            }
        }

        public void OnServersLoaded(Server[] servers)
        {
            if (servers?.Length > 0 && cbServers.Items.Count <= 1)
            {
                cbServers.Items.AddRange(servers);
                cbServers.SelectedIndex = 0;
            }
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

        private Configuration GenerateConfiguration()
        {
            return new Configuration
            {
                Author = txtAuthor.Text,
                Description = txtDescription.Text,
                Commands = lstCommands.Items.Cast<IBotCommand>().ToList(),
                Skills = lstSkills.Items.Cast<Skill>().ToList(),
                Quests = lstQuests.Items.Cast<Quest>().ToList(),
                Boosts = lstBoosts.Items.Cast<InventoryItem>().ToList(),
                Drops = lstDrops.Items.Cast<string>().ToList(),
                SkillDelay = (int)numSkillD.Value,
                ExitCombatBeforeRest = chkExitRest.Checked,
                ExitCombatBeforeQuest = chkExistQuest.Checked,
                Server = (Server)cbServers.SelectedItem,
                AutoRelogin = chkRelog.Checked,
                RelogDelay = (int)numRelogDelay.Value,
                RelogRetryUponFailure = chkRelogRetry.Checked,
                BotDelay = (int)numBotDelay.Value,
                EnablePickup = chkPickup.Checked,
                EnableRejection = chkReject.Checked,
                WaitForSkills = chkSkillCD.Checked,
                SkipDelayIndexIf = chkSkip.Checked,
                InfiniteAttackRange = chkInfiniteRange.Checked,
                ProvokeMonsters = chkProvoke.Checked,
                EnemyMagnet = chkMagnet.Checked,
                LagKiller = chkLag.Checked,
                HidePlayers = chkHidePlayers.Checked,
                SkipCutscenes = chkSkipCutscenes.Checked,
                WalkSpeed = (int)numWalkSpeed.Value,
                NotifyUponDrop = lstSoundItems.Items.Cast<string>().ToList(),
                RestIfMp = chkMP.Checked,
                RestIfHp = chkHP.Checked,
                RestMp = (int)numRestMP.Value,
                RestHp = (int)numRest.Value,
                RestartUponDeath = chkRestartDeath.Checked
            };
        }

        public void ApplyConfiguration(Configuration config)
        {
            if (config == null)
                return;

            if (!chkMerge.Checked || ActiveBotEngine.IsRunning)
            {
                lstCommands.Items.Clear();
                lstBoosts.Items.Clear();
                lstDrops.Items.Clear();
                lstQuests.Items.Clear();
                lstSkills.Items.Clear();
                lstSoundItems.Items.Clear();
            }

            txtSavedAuthor.Text = config.Author ?? "Author";
            txtSavedDesc.Text = config.Description ?? "Description";

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

            numSkillD.Value = config.SkillDelay;
            chkExitRest.Checked = config.ExitCombatBeforeRest;
            chkExistQuest.Checked = config.ExitCombatBeforeQuest;
            if (config.Server != null)
                cbServers.SelectedIndex = cbServers.Items.Cast<Server>().ToList().FindIndex(s => s.Name == config.Server.Name);
            chkRelog.Checked = config.AutoRelogin;
            numRelogDelay.Value = config.RelogDelay;
            chkRelogRetry.Checked = config.RelogRetryUponFailure;
            numBotDelay.Value = config.BotDelay;
            chkPickup.Checked = config.EnablePickup;
            chkReject.Checked = config.EnableRejection;
            chkSkillCD.Checked = config.WaitForSkills;
            chkSkip.Checked = config.SkipDelayIndexIf;
            chkInfiniteRange.Checked = config.InfiniteAttackRange;
            chkProvoke.Checked = config.ProvokeMonsters;
            chkMagnet.Checked = config.EnemyMagnet;
            chkHidePlayers.Checked = config.HidePlayers;
            chkSkipCutscenes.Checked = config.SkipCutscenes;
            numWalkSpeed.Value = config.WalkSpeed <= 0 ? 8 : config.WalkSpeed;
            if (config.NotifyUponDrop?.Count > 0)
                lstSoundItems.Items.AddRange(config.NotifyUponDrop.ToArray());
            numRestMP.Value = config.RestMp;
            numRest.Value = config.RestHp;
            chkMP.Checked = config.RestIfMp;
            chkHP.Checked = config.RestIfHp;
            chkRestartDeath.Checked = config.RestartUponDeath;
        }

        private void OnConfigurationChanged(Configuration config)
        {
            if (InvokeRequired)
                Invoke(new Action(() => ApplyConfiguration(config)));
            else
                ApplyConfiguration(config);
        }

        private void OnIndexChanged(int index)
        {
            if (index > -1)
            {
                if (InvokeRequired)
                    Invoke(new Action(() => { lstCommands.SelectedIndex = index; }));
                else
                    lstCommands.SelectedIndex = index;
            }
        }

        private void OnIsRunningChanged(bool isRunning)
        {
            if (!isRunning)
            {
                ActiveBotEngine.IsRunningChanged -= OnIsRunningChanged;
                ActiveBotEngine.IndexChanged -= OnIndexChanged;
                ActiveBotEngine.ConfigurationChanged -= OnConfigurationChanged;

                void Action()
                {
                    btnUp.Enabled = true;
                    btnDown.Enabled = true;
                    btnClear.Enabled = true;
                    btnRemove.Enabled = true;
                }

                if (InvokeRequired)
                    Invoke((Action) Action);
                else
                    Action();
            }

            if (InvokeRequired)
                Invoke(new Action(() => { chkEnable.Checked = isRunning; }));
            else
                chkEnable.Checked = isRunning;
        }

        public void AddCommand(IBotCommand cmd)
        {
            lstCommands.Items.Add(cmd);
        }

        #region  Untabbed

        private void lstCommands_DoubleClick(object sender, EventArgs e)
        {
            int index = lstCommands.SelectedIndex;
            if (index > -1)
            {
                object cmd = lstCommands.Items[index];

                string result = JsonConvert.SerializeObject(cmd, Formatting.Indented, _serializerSettings);

                string mod = RawCommandEditor.Show(result);

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

        private Panel[] _panels;

        private void HidePanels(Panel exception)
        {
            exception.Location = new Point(219, 27);
            switch (exception.Name)
            {
                case "pnlCombat":
                    Size = new Size(624, 385);
                    break;
                case "pnlMap":
                    Size = new Size(589, 387);
                    break;
                case "pnlItem":
                    Size = new Size(562, 387);
                    break;
                case "pnlQuest":
                    Size = new Size(493, 385);
                    break;
                case "pnlMisc":
                    Size = new Size(682, 386);
                    break;
                case "pnlOptions":
                    Size = new Size(527, 387);
                    break;
                case "pnlSaved":
                    Size = new Size(683, 387);
                    break;
                default: return;
            }
            foreach (Panel p in _panels)
                p.Visible = p == exception;
        }

        private void combatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels(pnlCombat);
        }

        private void mapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels(pnlMap);
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels(pnlItem);
        }

        private void questToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels(pnlQuest);
        }

        private void miscToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels(pnlMisc);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels(pnlOptions);
        }

        private void botsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels(pnlSaved);
            txtSaved.Text = Path.Combine(Application.StartupPath, "Bots");
            UpdateTree();
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

        #endregion

        #region Combat tab

        private void btnKill_Click(object sender, EventArgs e)
        {
            string mon = string.IsNullOrEmpty(txtMonster.Text) ? "*" : txtMonster.Text;
            lstCommands.Items.Add(new CmdKill {Monster = mon});
        }

        private void btnKillF_Click(object sender, EventArgs e)
        {
            if (txtKillFItem.Text.Length > 0 && txtKillFQ.Text.Length > 0)
            {
                string monster = string.IsNullOrEmpty(txtKillFMon.Text) ? "*" : txtKillFMon.Text;
                string item = txtKillFItem.Text, quantity = txtKillFQ.Text;
                lstCommands.Items.Add(new CmdKillFor
                {
                    ItemType = rbItems.Checked ? ItemType.Items : ItemType.TempItems,
                    Monster = monster, ItemName = item, Quantity = quantity
                });
            }
        }

        private void btnAddSkill_Click(object sender, EventArgs e)
        {
            string index = numSkill.Text;
            lstSkills.Items.Add(new Skill
            {
                Text = $"{index}: {Skill.GetSkillName(index)}", Index = index, Type = Skill.SkillType.Normal
            });
        }

        private void btnAddSafe_Click(object sender, EventArgs e)
        {
            string index = numSkill.Text;
            int safe = (int)numSafe.Value;
            lstSkills.Items.Add(new Skill
            {
                Text = $"[S] {index}: {Skill.GetSkillName(index)}",
                Index = index, SafeHealth = safe, Type = Skill.SkillType.Safe, SafeMp = chkSafeMp.Checked
            });
        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            lstCommands.Items.Add(new CmdRest());
        }

        private void btnRestF_Click(object sender, EventArgs e)
        {
            lstCommands.Items.Add(new CmdRest {Full = true});
        }

        #endregion

        #region Map tab

        private void btnJoin_Click(object sender, EventArgs e)
        {
            string map = txtJoin.Text, 
                   cell = string.IsNullOrEmpty(txtJoinCell.Text) ? "Enter" : txtJoinCell.Text, 
                   pad = string.IsNullOrEmpty(txtJoinPad.Text) ? "Spawn" : txtJoinPad.Text;
            if (map.Length > 0)
                lstCommands.Items.Add(new CmdJoin { Map = map, Cell = cell, Pad = pad });
        }

        private void btnCellSwap_Click(object sender, EventArgs e)
        {
            txtJoinCell.Text = txtCell.Text;
            txtJoinPad.Text = txtPad.Text;
        }

        private void btnCurrCell_Click(object sender, EventArgs e)
        {
            txtCell.Text = Player.Cell;
            txtPad.Text = Player.Pad;
        }

        private void btnJump_Click(object sender, EventArgs e)
        {
            string cell = string.IsNullOrEmpty(txtCell.Text) ? "Enter" : txtCell.Text,
                pad = string.IsNullOrEmpty(txtPad.Text) ? "Spawn" : txtPad.Text;
            lstCommands.Items.Add(new CmdMoveToCell {Cell = cell, Pad = pad});
        }

        private void btnWalk_Click(object sender, EventArgs e)
        {
            string x = numWalkX.Value.ToString(), y = numWalkY.Value.ToString();
            lstCommands.Items.Add(new CmdWalk {X = x, Y = y});
        }

        private void btnWalkCur_Click(object sender, EventArgs e)
        {
            float[] pos = Player.Position;
            numWalkX.Value = (decimal)pos[0];
            numWalkY.Value = (decimal)pos[1];
        }

        #endregion

        #region Item tab

        private void btnItem_Click(object sender, EventArgs e)
        {
            string item = txtItem.Text;
            if (item.Length > 0 && cbItemCmds.SelectedIndex > -1)
            {
                IBotCommand cmd;

                switch (cbItemCmds.SelectedIndex)
                {
                    case 1:
                        cmd = new CmdSell {ItemName = item};
                        break;
                    case 2:
                        cmd = new CmdEquip { ItemName = item };
                        break;
                    case 3:
                        cmd = new CmdBankTransfer {ItemName = item, TransferFromBank = false};
                        break;
                    case 4:
                        cmd = new CmdBankTransfer { ItemName = item, TransferFromBank = true };
                        break;
                    default:
                        cmd = new CmdGetDrop { ItemName = item };
                        break;
                }
                lstCommands.Items.Add(cmd);
            }
        }

        private void btnMapItem_Click(object sender, EventArgs e)
        {
            lstCommands.Items.Add(new CmdMapItem {ItemId = (int)numMapItem.Value});
        }

        private void btnBBAdd_Click(object sender, EventArgs e)
        {
            string item = txtBBItem.Text;
            if (item.Length > 0)
                lstCommands.Items.Add(new CmdBuyBack { ItemName = item, PageNumberCap = (int)numBBCap.Value });
        }

        private void btnWhitelist_Click(object sender, EventArgs e)
        {
            string item = txtWhitelist.Text;
            if (item.Length > 0)
                lstDrops.Items.Add(item);
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            string bank = txtSwapBank.Text, inv = txtSwapInv.Text;
            if (bank.Length > 0 && inv.Length > 0)
            {
                lstCommands.Items.Add(new CmdBankSwap {
                    InventoryItemName = inv,
                    BankItemName = bank});
            }
        }

        private void btnBoost_Click(object sender, EventArgs e)
        {
            if (cbBoosts.SelectedIndex > -1)
                lstBoosts.Items.Add(cbBoosts.SelectedItem);
        }

        private void cbBoosts_Click(object sender, EventArgs e)
        {
            cbBoosts.Items.Clear();
            cbBoosts.Items.AddRange(Player.Inventory.Items.Where(i => i.Category == "ServerUse").ToArray());
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (txtShopItem.TextLength > 0)
                lstCommands.Items.Add(new CmdBuy { ItemName = txtShopItem.Text, ShopId = (int)numShopId.Value });
        }

        #endregion

        #region Quest tab

        private void btnQuestAdd_Click(object sender, EventArgs e)
        {
            Quest q = new Quest { Id = (int)numQuestID.Value };
            if (chkQuestItem.Checked)
                q.ItemId = numQuestItem.Value.ToString();
            q.Text = q.ItemId != null ? $"{q.Id}:{q.ItemId}" : q.Id.ToString();
            lstQuests.Items.Add(q);
        }

        private void btnQuestComplete_Click(object sender, EventArgs e)
        {
            Quest q = new Quest();
            CmdCompleteQuest cmd = new CmdCompleteQuest();
            q.Id = (int)numQuestID.Value;
            if (chkQuestItem.Checked)
                q.ItemId = numQuestItem.Value.ToString();
            cmd.Quest = q;
            lstCommands.Items.Add(cmd);
        }

        private void btnQuestAccept_Click(object sender, EventArgs e)
        {
            Quest q = new Quest { Id = (int)numQuestID.Value };
            lstCommands.Items.Add(new CmdAcceptQuest {Quest = q});
        }

        private void chkQuestItem_CheckedChanged(object sender, EventArgs e)
        {
            numQuestItem.Enabled = chkQuestItem.Checked;
        }

        #endregion

        #region Misc tab

        private void btnPacket_Click(object sender, EventArgs e)
        {
            lstCommands.Items.Add(new CmdPacket {Packet = txtPacket.Text});
        }

        private void btnDelay_Click(object sender, EventArgs e)
        {
            int delay = (int)numDelay.Value;
            lstCommands.Items.Add(new CmdDelay {Delay = delay});
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            string player = txtPlayer.Text;
            if (player.Length > 0)
                lstCommands.Items.Add(new CmdGotoPlayer { PlayerName = player });
        }

        private void btnBotDelay_Click(object sender, EventArgs e)
        {
            int delay = (int)numBotDelay.Value;
            lstCommands.Items.Add(new CmdBotDelay {Delay = delay});
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            lstCommands.Items.Add(new CmdStop());
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            lstCommands.Items.Add(new CmdRestart());
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Load bot";
                ofd.InitialDirectory = Path.Combine(Application.StartupPath, "Bots");
                ofd.Filter = "Grimoire bots|*.gbot";
                ofd.DefaultExt = ".gbot";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (TryDeserialize(File.ReadAllText(ofd.FileName), out Configuration cfg))
                        ApplyConfiguration(cfg);
                }
            }
        }

        private bool TryDeserialize(string json, out Configuration config)
        {
            try
            {
                config = JsonConvert.DeserializeObject<Configuration>(json, _serializerSettings);
                return true;
            }
            catch {}

            
            config = null;
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Save bot";
                ofd.InitialDirectory = Path.Combine(Application.StartupPath, "Bots");
                ofd.DefaultExt = ".gbot";
                ofd.Filter = "Grimoire bots|*.gbot";
                ofd.CheckFileExists = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Configuration cfg = GenerateConfiguration();
                    try
                    {
                        File.WriteAllText(
                            ofd.FileName, JsonConvert.SerializeObject(cfg, Formatting.Indented, _serializerSettings));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Unable to save bot: {ex.Message}");
                    }
                }
            }
        }

        private void btnLoadCmd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                string defPath = Path.Combine(Application.StartupPath, "Bots");
                ofd.Title = "Select bot to load";
                ofd.Filter = "Grimoire bots|*.gbot";
                ofd.InitialDirectory = defPath;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    lstCommands.Items.Add(new CmdLoadBot
                    {
                        BotFileName = Path.GetFileName(ofd.FileName)
                    });
                }
            }
        }

        private void cbStatement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategories.SelectedIndex > -1 && cbStatement.SelectedIndex > -1)
            {
                StatementCommand cmd = (StatementCommand)cbStatement.SelectedItem;
                txtStatement1.Enabled = cmd.Description1 != null;
                txtStatement2.Enabled = cmd.Description2 != null;
                txtStatement1.Text = cmd.Description1;
                txtStatement2.Text = cmd.Description2;
            }
        }

        private void btnStatementAdd_Click(object sender, EventArgs e)
        {
            if (cbCategories.SelectedIndex > -1 && cbStatement.SelectedIndex > -1)
            {
                string value1 = txtStatement1.Text;
                string value2 = txtStatement2.Text;
                StatementCommand cmd =
                    (StatementCommand)Activator.CreateInstance(cbStatement.SelectedItem.GetType());
                cmd.Value1 = value1;
                cmd.Value2 = value2;
                lstCommands.Items.Add((IBotCommand)cmd);
            }
        }

        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbCategories.SelectedIndex;
            if (index > -1)
            {
                cbStatement.Items.Clear();
                string text = cbCategories.SelectedItem.ToString();
                cbStatement.Items.AddRange(_statementCommands.Where(s => s.Tag == text).ToArray());
            }
        }

        private void btnGotoLabel_Click(object sender, EventArgs e)
        {
            if (txtLabel.TextLength > 0)
                lstCommands.Items.Add(new CmdGotoLabel { Label = txtLabel.Text });
        }

        private void btnAddLabel_Click(object sender, EventArgs e)
        {
            if (txtLabel.TextLength > 0)
                lstCommands.Items.Add(new CmdLabel { Name = txtLabel.Text });
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            lstCommands.Items.Add(new CmdLogout());
        }

        #endregion

        #region Saved bots tab

        private void UpdateTree()
        {
            if (!string.IsNullOrEmpty(txtSaved.Text) && Directory.Exists(txtSaved.Text))
            {
                lblBots.Text = $"Number of Bots: {Directory.EnumerateFiles(txtSaved.Text, "*.gbot", SearchOption.AllDirectories).Count()}";
                treeBots.Nodes.Clear();
                AddTreeNodes(treeBots, txtSaved.Text);
            }
        }

        private void treeBots_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selection = Path.Combine(txtSaved.Text, e.Node.FullPath);
            if (File.Exists(selection))
            {
                if (TryDeserialize(File.ReadAllText(selection), out Configuration cfg))
                    ApplyConfiguration(cfg);
                else return;
            }
            lblCommands.Text = $"Number of{Environment.NewLine}Commands: {lstCommands.Items.Count}";
            lblSkills.Text = $"Skills: {lstSkills.Items.Count}";
            lblQuests.Text = $"Quests: {lstQuests.Items.Count}";
            lblDrops.Text = $"Drops: {lstDrops.Items.Count}";
            lblBoosts.Text = $"Boosts: {lstBoosts.Items.Count}";
        }

        private void treeBots_AfterExpand(object sender, TreeViewEventArgs e)
        {
            string collapsed = Path.Combine(txtSaved.Text, e.Node.FullPath);
            if (Directory.Exists(collapsed))
            {
                AddTreeNodes(e.Node, collapsed);
                if (e.Node.Nodes.Count > 0 && e.Node.Nodes[0].Text == "Loading...")
                    e.Node.Nodes.RemoveAt(0);
            }
        }

        private void AddTreeNodes(TreeNode node, string path)
        {
            foreach (string dir in Directory.EnumerateDirectories(
                path, "*", SearchOption.TopDirectoryOnly))
            {
                string add = Path.GetFileName(dir);
                if (node.Nodes.Cast<TreeNode>().ToList().All(n => n.Text != add))
                {
                    node.Nodes.Add(add).Nodes.Add("Loading...");
                }
            }

            foreach (string file in Directory.EnumerateFiles(
                path, "*.gbot", SearchOption.TopDirectoryOnly))
            {
                string add = Path.GetFileName(file);
                if (node.Nodes.Cast<TreeNode>().ToList().All(n => n.Text != add))
                {
                    node.Nodes.Add(add);
                }
            }
        }

        private void AddTreeNodes(TreeView tree, string path)
        {
            foreach (string dir in Directory.EnumerateDirectories(
                path, "*", SearchOption.TopDirectoryOnly))
            {
                string add = Path.GetFileName(dir);
                if (tree.Nodes.Cast<TreeNode>().ToList().All(n => n.Text != add))
                {
                    tree.Nodes.Add(add).Nodes.Add("Loading...");
                }
            }

            foreach (string file in Directory.EnumerateFiles(
                path, "*.gbot", SearchOption.TopDirectoryOnly))
            {
                string add = Path.GetFileName(file);
                if (tree.Nodes.Cast<TreeNode>().ToList().All(n => n.Text != add))
                {
                    tree.Nodes.Add(add);
                }
            }
        }

        private void btnSavedAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSaved.Text))
            {
                string newDir = Path.Combine(txtSaved.Text, txtSavedAdd.Text);

                if (!Directory.Exists(newDir))
                {
                    try
                    {
                        Directory.CreateDirectory(newDir);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Unable to create directory: {ex.Message}", "Grimoire",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                UpdateTree();
            }
        }

        #endregion

        #region Options tab

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

        #endregion
    }
}
