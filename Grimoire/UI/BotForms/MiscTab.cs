using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Grimoire.Botting;
using Grimoire.Botting.Commands.Misc;
using Grimoire.Botting.Commands.Misc.Statements;
using Grimoire.Properties;
using Newtonsoft.Json;

namespace Grimoire.UI.BotForms
{
    public partial class MiscTab : Form
    {
        public static MiscTab Instance { get; } = new MiscTab();

        public bool SkipUnnecessaryDelays
        {
            get => chkSkip.Checked;
            set => chkSkip.Checked = value;
        }

        public int BotDelay
        {
            get => (int) numBotDelay.Value;
            set => numBotDelay.Value = value;
        }

        public bool RestartUponDeath
        {
            get => chkRestartDeath.Checked;
            set => chkRestartDeath.Checked = value;
        }

        public bool Merge => chkMerge.Checked;

        private List<StatementCommand> _statementCommands;

        private readonly Dictionary<string, string> _defaultText = new Dictionary<string, string>
        {
            {nameof(txtPacket), "%xt%zm%........."}, {nameof(txtAuthor), "Author"},
            {nameof(txtDescription), "Description"}, {nameof(txtLabel), "Label name"},
            {nameof(txtPlayer), "Player name"}
        };

        private MiscTab()
        {
            InitializeComponent();
            TopLevel = false;
        }

        private void Misc_Load(object sender, EventArgs e)
        {
            _statementCommands = JsonConvert.DeserializeObject<List<StatementCommand>>(Resources.statementcmds, Configuration.SerializerSettings);
            cbStatement.DisplayMember = "Text";
        }

        private void btnPacket_Click(object sender, EventArgs e)
        {
            BotManagerForm.Instance.AddCommand(new CmdPacket { Packet = txtPacket.Text });
        }

        private void btnDelay_Click(object sender, EventArgs e)
        {
            int delay = (int)numDelay.Value;
            BotManagerForm.Instance.AddCommand(new CmdDelay { Delay = delay });
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            string player = txtPlayer.Text;
            if (player.Length > 0)
                BotManagerForm.Instance.AddCommand(new CmdGotoPlayer { PlayerName = player });
        }

        private void btnBotDelay_Click(object sender, EventArgs e)
        {
            int delay = (int)numBotDelay.Value;
            BotManagerForm.Instance.AddCommand(new CmdBotDelay { Delay = delay });
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            BotManagerForm.Instance.AddCommand(new CmdStop());
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            BotManagerForm.Instance.AddCommand(new CmdRestart());
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
                        BotManagerForm.Instance.ApplyConfiguration(cfg);
                }
            }
        }

        private bool TryDeserialize(string json, out Configuration config)
        {
            try
            {
                config = JsonConvert.DeserializeObject<Configuration>(json, Configuration.SerializerSettings);
                return true;
            }
            catch
            {
                config = null;
                return false;
            }
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
                    Configuration cfg = BotManagerForm.Instance.GenerateConfiguration();
                    try
                    {
                        File.WriteAllText(
                            ofd.FileName, JsonConvert.SerializeObject(cfg, Formatting.Indented, Configuration.SerializerSettings));
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
                    BotManagerForm.Instance.AddCommand(new CmdLoadBot
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
                BotManagerForm.Instance.AddCommand((IBotCommand)cmd);
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
                BotManagerForm.Instance.AddCommand(new CmdGotoLabel { Label = txtLabel.Text });
        }

        private void btnAddLabel_Click(object sender, EventArgs e)
        {
            if (txtLabel.TextLength > 0)
                BotManagerForm.Instance.AddCommand(new CmdLabel { Name = txtLabel.Text });
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            BotManagerForm.Instance.AddCommand(new CmdLogout());
        }

        private void TextboxEnter(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (_defaultText[t.Name] == t.Text)
                t.Clear();
        }

        private void TextboxLeave(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (string.IsNullOrEmpty(t.Text))
                t.Text = _defaultText[t.Name];
        }
    }
}
