using System;
using System.Windows.Forms;
using Grimoire.UI;

namespace ExampleCommandPlugin
{
    public partial class Main : Form
    {
        public static Main Instance { get; } = new Main();

        public Main()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMonster.Text))
            {
                BotManagerForm.Instance.AddCommand(new CmdKillMany
                {
                    Kills = (int)numKills.Value,
                    Monster = txtMonster.Text
                });
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
