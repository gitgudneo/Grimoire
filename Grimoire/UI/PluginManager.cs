using System;
using System.IO;
using System.Windows.Forms;
using Grimoire.Tools.Plugins;

namespace Grimoire.UI
{
    public partial class PluginManager : Form
    {
        public static PluginManager Instance { get; } = new PluginManager();

        public PluginManager()
        {
            InitializeComponent();
            Root.Instance.SizeChanged += Root_SizeChanged;
            Root.Instance.VisibleChanged += Root_VisibleChanged;
            lstLoaded.DisplayMember = "Name";
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Load Grimoire plugin";
                ofd.Filter = "Dynamic Link Library|*.dll";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtPlugin.Text = ofd.FileName;
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string dll;
            if (File.Exists(dll = txtPlugin.Text))
            {
                GrimoirePlugin p = new GrimoirePlugin(dll);
                if (p.Load())
                {
                    txtPlugin.Clear();
                    lstLoaded.Items.Clear();
                    lstLoaded.Items.AddRange(GrimoirePlugin.LoadedPlugins.ToArray());
                    lstLoaded.SelectedItem = p;
                }
                else
                {
                    MessageBox.Show(p.LastError, "Grimoire",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUnload_Click(object sender, EventArgs e)
        {
            int index;
            if ((index = lstLoaded.SelectedIndex) > -1)
            {
                GrimoirePlugin p = GrimoirePlugin.LoadedPlugins[index];
                if (p.Unload())
                {
                    lstLoaded.Items.RemoveAt(index);
                    lblAuthor.Text = "Plugin created by:";
                    txtDesc.Clear();
                }
                else
                {
                    MessageBox.Show(p.LastError, "Grimoire",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lstLoaded_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            if ((index = lstLoaded.SelectedIndex) > -1)
            {
                GrimoirePlugin p = GrimoirePlugin.LoadedPlugins[index];
                lblAuthor.Text = $"Plugin created by: {p.Author}";
                txtDesc.Text = p.Description;
            }
        }

        private void PluginManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
