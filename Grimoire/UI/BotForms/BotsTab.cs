using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Grimoire.Botting;
using Newtonsoft.Json;

namespace Grimoire.UI.BotForms
{
    public partial class BotsTab : Form
    {
        public static BotsTab Instance { get; } = new BotsTab();

        public string Author
        {
            get => txtSavedAuthor.Text;
            set => txtSavedAuthor.Text = value;
        }

        public string Description
        {
            get => txtSavedDesc.Text;
            set => txtSavedDesc.Text = value;
        }

        private readonly Dictionary<string, string> _defaultText = new Dictionary<string, string>
        {
            {nameof(txtSavedAuthor), "Author"}, {nameof(txtSavedDesc), "Description"}
        };

        private BotsTab()
        {
            InitializeComponent();
            TopLevel = false;
        }

        private void UpdateTree()
        {
            if (!string.IsNullOrEmpty(txtSaved.Text) && Directory.Exists(txtSaved.Text))
            {
                lblBots.Text = $"Number of Bots: {Directory.EnumerateFiles(txtSaved.Text, "*.gbot", SearchOption.AllDirectories).Count()}";
                treeBots.Nodes.Clear();
                AddTreeNodes(treeBots, txtSaved.Text);
            }
        }

        private void treeBots_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selection = Path.Combine(txtSaved.Text, e.Node.FullPath);
            if (File.Exists(selection))
            {
                try
                {
                    Configuration cfg =
                        JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(selection));
                    BotManagerForm.Instance.ApplyConfiguration(cfg);

                    lblCommands.Text = $"Number of{Environment.NewLine}Commands: {cfg.Commands?.Count}";
                    lblSkills.Text = $"Skills: {cfg.Skills?.Count}";
                    lblQuests.Text = $"Quests: {cfg.Quests?.Count}";
                    lblDrops.Text = $"Drops: {cfg.Drops?.Count}";
                    lblBoosts.Text = $"Boosts: {cfg.Boosts?.Count}";
                }
                catch
                {
                }
            }
        }

        private void treeBots_AfterExpand(object sender, TreeViewEventArgs e)
        {
            string collapsed = Path.Combine(txtSaved.Text, e.Node.FullPath);
            if (Directory.Exists(collapsed))
            {
                AddTreeNodes(e.Node, collapsed);
                if (e.Node.Nodes.Count > 0 && e.Node.Nodes[0].Text == "Loading...")
                    e.Node.Nodes.RemoveAt(0);
            }
        }

        private void AddTreeNodes(TreeNode node, string path)
        {
            foreach (string dir in Directory.EnumerateDirectories(
                path, "*", SearchOption.TopDirectoryOnly))
            {
                string add = Path.GetFileName(dir);
                if (node.Nodes.Cast<TreeNode>().ToList().All(n => n.Text != add))
                {
                    node.Nodes.Add(add).Nodes.Add("Loading...");
                }
            }

            foreach (string file in Directory.EnumerateFiles(
                path, "*.gbot", SearchOption.TopDirectoryOnly))
            {
                string add = Path.GetFileName(file);
                if (node.Nodes.Cast<TreeNode>().ToList().All(n => n.Text != add))
                {
                    node.Nodes.Add(add);
                }
            }
        }

        private void AddTreeNodes(TreeView tree, string path)
        {
            foreach (string dir in Directory.EnumerateDirectories(
                path, "*", SearchOption.TopDirectoryOnly))
            {
                string add = Path.GetFileName(dir);
                if (tree.Nodes.Cast<TreeNode>().ToList().All(n => n.Text != add))
                {
                    tree.Nodes.Add(add).Nodes.Add("Loading...");
                }
            }

            foreach (string file in Directory.EnumerateFiles(
                path, "*.gbot", SearchOption.TopDirectoryOnly))
            {
                string add = Path.GetFileName(file);
                if (tree.Nodes.Cast<TreeNode>().ToList().All(n => n.Text != add))
                {
                    tree.Nodes.Add(add);
                }
            }
        }

        private void btnSavedAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSaved.Text))
            {
                string newDir = Path.Combine(txtSaved.Text, txtSavedAdd.Text);

                if (!Directory.Exists(newDir))
                {
                    try
                    {
                        Directory.CreateDirectory(newDir);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Unable to create directory: {ex.Message}", "Grimoire",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                UpdateTree();
            }
        }

        private void TextboxEnter(object sender, EventArgs e)
        {
            TextBox t = (TextBox) sender;
            if (_defaultText[t.Name] == t.Text)
                t.Clear();
        }

        private void TextboxLeave(object sender, EventArgs e)
        {
            TextBox t = (TextBox) sender;
            if (string.IsNullOrEmpty(t.Text))
                t.Text = _defaultText[t.Name];
        }
    }
}
