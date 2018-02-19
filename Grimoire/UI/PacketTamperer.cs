using System;
using System.Windows.Forms;
using Grimoire.Networking;

namespace Grimoire.UI
{
    public partial class PacketTamperer : Form
    {
        public static PacketTamperer Instance { get; } = new PacketTamperer();

        private PacketTamperer()
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

        private void PacketTamperer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void chkFromServer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFromServer.Checked)
                Proxy.Instance.ReceivedFromServer += ReceivedFromServer;
            else
                Proxy.Instance.ReceivedFromServer -= ReceivedFromServer;
        }

        private void chkFromClient_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFromClient.Checked)
                Proxy.Instance.ReceivedFromClient += ReceivedFromClient;
            else
                Proxy.Instance.ReceivedFromClient -= ReceivedFromClient;
        }

        private async void btnToClient_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSend.Text))
            {
                btnToClient.Enabled = false;
                await Proxy.Instance.SendToClient(txtSend.Text);
                btnToClient.Enabled = true;
            }
        }

        private async void btnToServer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSend.Text))
            {
                btnToServer.Enabled = false;
                await Proxy.Instance.SendToServer(txtSend.Text);
                btnToServer.Enabled = true;
            }
        }

        private void ReceivedFromClient(Networking.Message message)
        {
            txtSend.Invoke(new Action(() => Append("From client: " + message.RawContent)));
        }

        private void ReceivedFromServer(Networking.Message message)
        {
            txtSend.Invoke(new Action(() => Append("From server: " + message.RawContent)));
        }

        private void Append(string text)
        {
            txtReceive.AppendText(text + Environment.NewLine + Environment.NewLine);
        }
    }
}
