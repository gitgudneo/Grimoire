using System;
using System.IO;
using System.Windows.Forms;
using Grimoire.Tools.Plugins;

namespace Grimoire.UI
{
    public partial class PluginsForm : Form
    {
        public static PluginsForm Instance { get; } = new PluginsForm();

        public PluginsForm()
        {
            InitializeComponent();
            MainForm.Instance.SizeChanged += Root_SizeChanged;
            MainForm.Instance.VisibleChanged += Root_VisibleChanged;
            lstLoaded.DisplayMember = "Name";

            if (Program.PluginsManager.LoadedPlugins.Count > 0)
            {
                lstLoaded.Items.AddRange(Program.PluginsManager.LoadedPlugins.ToArray());
                lstLoaded.SelectedIndex = 0;
            }
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

                    if (ofd.FileName == 
                        Path.Combine(Program.PluginsPath, Path.GetFileName(ofd.FileName)))
                    {
                        chkAutoload.Checked = true;
                        chkAutoload.Enabled = false;
                    }
                    else
                    {
                        chkAutoload.Checked = false;
                        chkAutoload.Enabled = true;
                    }
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string dll;

            if (File.Exists(dll = txtPlugin.Text))
            {
                if (chkAutoload.Enabled && chkAutoload.Checked)
                {
                    string copy = Path.Combine(Program.PluginsPath, Path.GetFileName(dll));

                    if (!File.Exists(copy))
                    {
                        try
                        {
                            File.Copy(dll, copy);
                            dll = copy;
                            txtPlugin.Text = dll;
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show($"Unable to copy {dll} to {copy}\n{exc.Message}");
                        }
                    }
                }

                if (Program.PluginsManager.Load(dll))
                {
                    txtPlugin.Clear();
                    lstLoaded.Items.Clear();
                    lstLoaded.Items.AddRange(Program.PluginsManager.LoadedPlugins.ToArray());
                    lstLoaded.SelectedIndex = lstLoaded.Items.Count - 1;
                }
                else
                {
                    MessageBox.Show(Program.PluginsManager.LastError, "Grimoire",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUnload_Click(object sender, EventArgs e)
        {
            GrimoirePlugin p = (GrimoirePlugin) lstLoaded.SelectedItem;

            if (p != null)
            {
                if (Program.PluginsManager.Unload(p))
                {
                    lstLoaded.Items.Remove(p);
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
            GrimoirePlugin p = (GrimoirePlugin) lstLoaded.SelectedItem;

            if (p != null)
            {
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
