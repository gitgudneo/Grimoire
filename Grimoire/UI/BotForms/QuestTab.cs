using System;
using System.Windows.Forms;
using Grimoire.Botting.Commands.Quest;

namespace Grimoire.UI.BotForms
{
    public partial class QuestTab : Form
    {
        public static QuestTab Instance { get; } = new QuestTab();

        private QuestTab()
        {
            InitializeComponent();
            TopLevel = false;
        }

        private void btnQuestAdd_Click(object sender, EventArgs e)
        {
            Game.Data.Quest q = new Game.Data.Quest { Id = (int)numQuestID.Value };
            if (chkQuestItem.Checked)
                q.ItemId = numQuestItem.Value.ToString();
            q.Text = q.ItemId != null ? $"{q.Id}:{q.ItemId}" : q.Id.ToString();
            BotManager.Instance.AddQuest(q);
        }

        private void btnQuestComplete_Click(object sender, EventArgs e)
        {
            Game.Data.Quest q = new Game.Data.Quest();
            CmdCompleteQuest cmd = new CmdCompleteQuest();
            q.Id = (int)numQuestID.Value;
            if (chkQuestItem.Checked)
                q.ItemId = numQuestItem.Value.ToString();
            cmd.Quest = q;
            BotManager.Instance.AddCommand(cmd);
        }

        private void btnQuestAccept_Click(object sender, EventArgs e)
        {
            Game.Data.Quest q = new Game.Data.Quest { Id = (int)numQuestID.Value };
            BotManager.Instance.AddCommand(new CmdAcceptQuest { Quest = q });
        }

        private void chkQuestItem_CheckedChanged(object sender, EventArgs e)
        {
            numQuestItem.Enabled = chkQuestItem.Checked;
        }
    }
}
