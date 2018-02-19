using System;
using System.Windows.Forms;
using Grimoire.Networking;
using Message = Grimoire.Networking.Message;

namespace Grimoire.UI
{
    public partial class PacketLogger : Form
    {
        public static PacketLogger Instance { get; } = new PacketLogger();

        private PacketLogger()
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPackets.Clear();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (txtPackets.Text.Length > 0)
            {
                Clipboard.SetText(txtPackets.Text);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Proxy.Instance.ReceivedFromClient -= PacketCaptured;
            btnStart.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            Proxy.Instance.ReceivedFromClient += PacketCaptured;
        }

        private void PacketCaptured(Message msg)
        {
            if (msg.RawContent != null && msg.RawContent.Contains("%xt%zm%"))
                txtPackets.Invoke(new Action(() => txtPackets.AppendText(msg.RawContent + Environment.NewLine)));
        }

        private void PacketLogger_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
