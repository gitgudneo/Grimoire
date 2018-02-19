using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using Grimoire.Botting;
using Grimoire.Botting.Commands.Map;

namespace Grimoire.UI
{
    public partial class Travel : Form
    {
        public static Travel Instance { get; } = new Travel();

        private Travel()
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

        private void Travel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void chkPriv_CheckedChanged(object sender, EventArgs e)
        {
            numPriv.Enabled = chkPriv.Checked;
        }

        private void btnTercess_Click(object sender, EventArgs e)
        {
            ExecuteTravel(new List<IBotCommand>
            {
                CreateJoinCommand("citadel", "m22", "Left"),
                CreateJoinCommand("tercessuinotlim")
            });
        }

        private void btnTwins_Click(object sender, EventArgs e)
        {
            ExecuteTravel(new List<IBotCommand>
            {
                CreateJoinCommand("citadel", "m22", "Left"),
                CreateJoinCommand("tercessuinotlim", "Twins", "Left")
            });
        }

        private void btnTaro_Click(object sender, EventArgs e)
        {
            ExecuteTravel(new List<IBotCommand>
            {
                CreateJoinCommand("citadel", "m22", "Left"),
                CreateJoinCommand("tercessuinotlim", "Taro", "Left")
            });
        }

        private void btnSwindle_Click(object sender, EventArgs e)
        {
            ExecuteTravel(new List<IBotCommand>
            {
                CreateJoinCommand("citadel", "m22", "Left"),
                CreateJoinCommand("tercessuinotlim", "Swindle", "Left")
            });
        }

        private void btnNulgath_Click(object sender, EventArgs e)
        {
            ExecuteTravel(new List<IBotCommand>
            {
                CreateJoinCommand("citadel", "m22", "Left"),
                CreateJoinCommand("tercessuinotlim", "Boss", "Top")
            });
        }

        private void btnNulgath2_Click(object sender, EventArgs e)
        {
            ExecuteTravel(new List<IBotCommand>
            {
                CreateJoinCommand("citadel", "m22", "Left"),
                CreateJoinCommand("tercessuinotlim", "Boss2", "Right")
            });
        }

        private void btnEscherion_Click(object sender, EventArgs e)
        {
            ExecuteTravel(new List<IBotCommand>
            {
                CreateJoinCommand("escherion", "Boss", "Left")
            });
        }

        private void btnDage_Click(object sender, EventArgs e)
        {
            ExecuteTravel(new List<IBotCommand>
            {
                CreateJoinCommand("underworld", "s1", "Left")
            });
        }

        private CmdTravel CreateJoinCommand(string map, string cell = "Enter", string pad = "Spawn")
        {
            return new CmdTravel
            {
                Map = chkPriv.Checked ? map + $"-{numPriv.Value}" : map,
                Cell = cell,
                Pad = pad
            };
        }

        private async void ExecuteTravel(List<IBotCommand> cmds)
        {
            grpTravel.Enabled = false;
            foreach (IBotCommand cmd in cmds)
            {
                await cmd.Execute(null);
                await Task.Delay(1000);
            }
            if (InvokeRequired)
                Invoke(new Action(() => grpTravel.Enabled = true));
            else
                grpTravel.Enabled = true;
        }
    }
}
