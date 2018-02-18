using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Grimoire.Botting.Commands;
using Grimoire.Botting.Commands.Combat;
using Grimoire.Game.Data;

namespace Grimoire.UI.BotForms
{
    public partial class CombatTab : Form
    {
        public static CombatTab Instance { get; } = new CombatTab();

        public bool WaitForSkills
        {
            get => chkSkillCD.Checked;
            set => chkSkillCD.Checked = value;
        }

        public bool ExitCombatBeforeRest
        {
            get => chkExitRest.Checked;
            set => chkExitRest.Checked = value;
        }

        public bool ExitCombatBeforeQuest
        {
            get => chkExistQuest.Checked;
            set => chkExistQuest.Checked = value;
        }

        public bool RestHealth
        {
            get => chkHP.Checked;
            set => chkHP.Checked = value;
        }

        public bool RestMana
        {
            get => chkMP.Checked;
            set => chkMP.Checked = value;
        }

        public int RestHealthValue
        {
            get => (int) numRest.Value;
            set => numRest.Value = value;
        }

        public int RestManaValue
        {
            get => (int) numRestMP.Value;
            set => numRestMP.Value = value;
        }

        public int SkillDelay
        {
            get => (int) numSkillD.Value;
            set => numSkillD.Value = value;
        }

        private readonly Dictionary<string, string> _defaultText = new Dictionary<string, string>
        {
            {"txtMonster", "Monster (*  = random)"}, {"txtKillFMon", "Monster (* = random)"},
            {"txtKillFItem", "Item name"}, {"txtKillFQ", "Quantity (* = any)"}
        };

        private CombatTab()
        {
            InitializeComponent();
            TopLevel = false;
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            string mon = string.IsNullOrEmpty(txtMonster.Text) ? "*" : txtMonster.Text;
            BotManager.Instance.AddCommand(new CmdKill { Monster = mon });
        }

        private void btnKillF_Click(object sender, EventArgs e)
        {
            if (txtKillFItem.Text.Length > 0 && txtKillFQ.Text.Length > 0)
            {
                string monster = string.IsNullOrEmpty(txtKillFMon.Text) ? "*" : txtKillFMon.Text;
                string item = txtKillFItem.Text, quantity = txtKillFQ.Text;
                BotManager.Instance.AddCommand(new CmdKillFor
                {
                    ItemType = rbItems.Checked ? ItemType.Items : ItemType.TempItems,
                    Monster = monster,
                    ItemName = item,
                    Quantity = quantity
                });
            }
        }

        private void btnAddSkill_Click(object sender, EventArgs e)
        {
            string index = numSkill.Text;
            BotManager.Instance.AddSkill(new Skill
            {
                Text = $"{index}: {Skill.GetSkillName(index)}",
                Index = index,
                Type = Skill.SkillType.Normal
            });
        }

        private void btnAddSafe_Click(object sender, EventArgs e)
        {
            string index = numSkill.Text;
            int safe = (int)numSafe.Value;
            BotManager.Instance.AddSkill(new Skill
            {
                Text = $"[S] {index}: {Skill.GetSkillName(index)}",
                Index = index,
                SafeHealth = safe,
                Type = Skill.SkillType.Safe,
                SafeMp = chkSafeMp.Checked
            });
        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            BotManager.Instance.AddCommand(new CmdRest());
        }

        private void btnRestF_Click(object sender, EventArgs e)
        {
            BotManager.Instance.AddCommand(new CmdRest { Full = true });
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
