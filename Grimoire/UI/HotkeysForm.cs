using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Grimoire.Game;
using Grimoire.Tools;
using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace Grimoire.UI
{
    public partial class HotkeysForm : Form
    {
        public static HotkeysForm Instance { get; } = new HotkeysForm();

        private HotkeysForm()
        {
            InitializeComponent();
            MainForm.Instance.SizeChanged += Root_SizeChanged;
            MainForm.Instance.VisibleChanged += Root_VisibleChanged;
            lstKeys.DisplayMember = "Text";
            cbActions.SelectedIndex = 0;
            cbKeys.SelectedIndex = 0;
            lstKeys.Items.AddRange(Program.HotkeysManager.RegisteredHotkeys.ToArray());
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Hotkey h = (Hotkey)lstKeys.SelectedItem;
            if (h != null)
            {
                Program.HotkeysManager.UninstallHotkey(h.Key);
                lstKeys.Items.Remove(h);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int action = cbActions.SelectedIndex;
            if (action > -1 && cbKeys.SelectedIndex > -1)
            {
                Keys key = (Keys)Enum.Parse(typeof(Keys), cbKeys.SelectedItem.ToString());

                if (!Program.HotkeysManager.IsKeyRegistered(key))
                {
                    Hotkey h = new Hotkey
                    {
                        ActionIndex = action,
                        Key = key,
                        Text = $"{key}: {cbActions.Items[action]}"
                    };
                    Program.HotkeysManager.RegisterHotkey(h);
                    lstKeys.Items.Add(h);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Program.HotkeysManager.ConfigPath, 
                JsonConvert.SerializeObject(Program.HotkeysManager.RegisteredHotkeys));
        }

        private void Hotkeys_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
