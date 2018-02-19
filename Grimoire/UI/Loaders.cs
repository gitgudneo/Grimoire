using System;
using System.Windows.Forms;
using System.Linq;
using Grimoire.Game;
using Grimoire.Game.Data;
using Grimoire.Tools;

namespace Grimoire.UI
{
    public partial class Loaders : Form
    {
        public static Loaders Instance { get; } = new Loaders();

        private Loaders()
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            int id;
            switch (cbLoad.SelectedIndex)
            {
                case 0:
                    if (int.TryParse(txtLoaders.Text, out id)) Shop.LoadHairShop(id);
                    break;
                case 1:
                    if (int.TryParse(txtLoaders.Text, out id)) Shop.Load(id);
                    break;
                case 2:
                    if (txtLoaders.Text.Contains(","))
                        LoadQuests(txtLoaders.Text);
                    else if (int.TryParse(txtLoaders.Text, out id))
                        Player.Quests.Load(id);
                    break;
                case 3:
                    Shop.LoadArmorCustomizer();
                    break;
                default: return;
            }
        }

        private void LoadQuests(string str)
        {
            string[] ids = str.Split(',');
            if (ids.All(s => s.All(char.IsDigit)))
                Player.Quests.Load(ids.Select(int.Parse).ToList());
        }

        // Remove the save button or serialize the tree view node collection?
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Save grabber data";
                ofd.CheckFileExists = false;
                ofd.Filter = "Text files|*.txt";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //File.WriteAllText(ofd.FileName, txtGrab.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Unable to save the file: {ex.Message}", "Grimoire", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnGrab_Click(object sender, EventArgs e)
        {
            treeGrabbed.BeginUpdate();
            treeGrabbed.Nodes.Clear();
            switch (cbGrab.SelectedIndex)
            {
                case 0: Grabber.GrabShopItems(treeGrabbed);
                    break;
                case 1: Grabber.GrabQuestIds(treeGrabbed);
                    break;
                case 2: Grabber.GrabQuests(treeGrabbed);
                    break;
                case 3: Grabber.GrabInventoryItems(treeGrabbed);
                    break;
                case 4: Grabber.GrabTempItems(treeGrabbed);
                    break;
                case 5: Grabber.GrabBankItems(treeGrabbed);
                    break;
                case 6: Grabber.GrabMonsters(treeGrabbed);
                    break;
            }
            treeGrabbed.EndUpdate();
        }

        private void Loaders_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
