using System;
using System.Windows.Forms;
using Grimoire.Networking;

namespace ExamplePacketPlugin
{
    public partial class Main : Form
    {
        public static Main Instance { get; } = new Main();

        public Main()
        {
            InitializeComponent();
        }

        public JoinHandler Handler { get; } = new JoinHandler();

        private void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnable.Checked)
            {
                Handler.MapToJoin = txtMap.Text;
                Proxy.Instance.RegisterHandler(Handler);
            }
            else
            {
                Proxy.Instance.UnregisterHandler(Handler);
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
