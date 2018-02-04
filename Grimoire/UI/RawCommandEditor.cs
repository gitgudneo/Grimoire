using System;
using System.Windows.Forms;

namespace Grimoire.UI
{
    public partial class RawCommandEditor : Form
    {
        public string Input => txtCmd.Text;

        public string Content { set => txtCmd.Text = value; }

        private RawCommandEditor()
        {
            InitializeComponent();
        }

        private void RawCommandEditor_Load(object sender, EventArgs e)
        {
            txtCmd.Select();
        }

        private void txtCmd_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnOK.PerformClick();
                    break;
                case Keys.Escape:
                    btnCancel.PerformClick();
                    break;
            }
        }

        public static string Show(string content)
        {
            using (RawCommandEditor dialog = new RawCommandEditor {Content = content})
                return dialog.ShowDialog() == DialogResult.OK ? dialog.Input : null;
        }
    }
}
