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
    public partial class Hotkeys : Form
    {
        public static Hotkeys Instance { get; } = new Hotkeys();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

        public static readonly Action[] Actions =
        {
            () => Root.Instance.ShowForm(BotManager.Instance),
            () => Root.Instance.ShowForm(Instance),
            () => Root.Instance.ShowForm(Loaders.Instance),
            () => Root.Instance.ShowForm(PacketLogger.Instance),
            () => Root.Instance.ShowForm(PacketSpammer.Instance),
            () => Root.Instance.ShowForm(Travel.Instance),
            () =>
            {
                if (Root.Instance.Visible)
                    Root.Instance.Hide();
                else
                    Root.Instance.Show();
            },
            () => Player.Bank.Show()
        };

        public static readonly List<Hotkey> InstalledHotkeys = new List<Hotkey>();

        private string configPath => Path.Combine(Application.StartupPath, "hotkeys.json");
        private int _processId;

        private Hotkeys()
        {
            InitializeComponent();
            Root.Instance.SizeChanged += Root_SizeChanged;
            Root.Instance.VisibleChanged += Root_VisibleChanged;
            lstKeys.DisplayMember = "Text";
            cbActions.SelectedIndex = 0;
            cbKeys.SelectedIndex = 0;
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
                h.Uninstall();
                InstalledHotkeys.Remove(h);
                lstKeys.Items.Remove(h);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int action = cbActions.SelectedIndex;
            if (action > -1 && cbKeys.SelectedIndex > -1)
            {
                Keys key = (Keys)Enum.Parse(typeof(Keys), cbKeys.SelectedItem.ToString());

                if (!KeyboardHook.Instance.TargetedKeys.Contains(key))
                {
                    Hotkey h = new Hotkey
                    {
                        ActionIndex = action,
                        Key = key,
                        Text = $"{key}: {cbActions.Items[action]}"
                    };
                    h.Install();
                    InstalledHotkeys.Add(h);
                    lstKeys.Items.Add(h);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText(configPath, JsonConvert.SerializeObject(InstalledHotkeys));
        }

        public void LoadHotkeys()
        {
            if (File.Exists(configPath))
            {
                Hotkey[] hotkeys = JsonConvert.DeserializeObject<Hotkey[]>(File.ReadAllText(configPath));
                if (hotkeys != null)
                {
                    InstalledHotkeys.AddRange(hotkeys);
                    foreach (Hotkey h in InstalledHotkeys)
                    {
                        lstKeys.Items.Add(h);
                        h.Install();
                    }
                }
            }
            KeyboardHook.Instance.KeyDown += OnKeyDown;
            _processId = Process.GetCurrentProcess().Id;
        }

        public void OnKeyDown(Keys key)
        {
            Hotkey pressed = InstalledHotkeys.First(h => h.Key == key);
            if (ApplicationContainsFocus() || (string)cbActions.Items[pressed.ActionIndex] == "Minimize to tray")
                Actions[pressed.ActionIndex]();
        }

        public bool ApplicationContainsFocus()
        {
            IntPtr handle = GetForegroundWindow();

            if (handle == IntPtr.Zero)
                return false;

            GetWindowThreadProcessId(handle, out int focusedProcessId);

            return focusedProcessId == _processId;
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
