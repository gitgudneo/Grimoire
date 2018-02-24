using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grimoire.Game;
using Grimoire.UI;
using Newtonsoft.Json;

namespace Grimoire.Tools
{
    public class HotkeyManager : IDisposable
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

        private static readonly Action[] Actions =
        {
            () => MainForm.Instance.ShowForm(BotManagerForm.Instance),
            () => MainForm.Instance.ShowForm(HotkeysForm.Instance),
            () => MainForm.Instance.ShowForm(LoadersForm.Instance),
            () => MainForm.Instance.ShowForm(PacketLoggerForm.Instance),
            () => MainForm.Instance.ShowForm(PacketSpammerForm.Instance),
            () => MainForm.Instance.ShowForm(TravelsForm.Instance),
            () =>
            {
                if (MainForm.Instance.Visible)
                    MainForm.Instance.Hide();
                else
                    MainForm.Instance.Show();
            },
            () => Player.Bank.Show()
        };

        public string ConfigPath => Path.Combine(Application.StartupPath, "hotkeys.json");

        public readonly List<Hotkey> RegisteredHotkeys = new List<Hotkey>();

        public bool IsKeyRegistered(Keys k) => RegisteredHotkeys.Any(h => h.Key == k);

        private readonly KeyboardHook _hook;

        private int ProcessId { get; } = Process.GetCurrentProcess().Id;

        public HotkeyManager(KeyboardHook hook)
        {
            _hook = hook;
        }

        public void RegisterHotkey(Hotkey hotkey)
        {
            if (!_hook.TargetedKeys.Contains(hotkey.Key))
            {
                _hook.TargetedKeys.Add(hotkey.Key);
                RegisteredHotkeys.Add(hotkey);
            }
        }

        public void UninstallHotkey(Keys key)
        {
            _hook.TargetedKeys.Remove(key);
            RegisteredHotkeys.Remove(RegisteredHotkeys.FirstOrDefault(f => f.Key == key));
        }

        public void LoadHotkeys()
        {
            if (File.Exists(ConfigPath))
            {
                Hotkey[] hotkeys = JsonConvert.DeserializeObject<Hotkey[]>(File.ReadAllText(ConfigPath));
                if (hotkeys != null)
                {
                    RegisteredHotkeys.AddRange(hotkeys);
                    RegisteredHotkeys.ForEach(h => _hook.TargetedKeys.Add(h.Key));
                }
            }
            _hook.KeyDown += OnKeyDown;
        }

        private void OnKeyDown(Keys key)
        {
            Hotkey pressed = RegisteredHotkeys.First(h => h.Key == key);
            if (ApplicationContainsFocus() || pressed.ActionIndex == 6)
                Actions[pressed.ActionIndex]();
        }

        private bool ApplicationContainsFocus()
        {
            IntPtr handle = GetForegroundWindow();

            if (handle == IntPtr.Zero)
                return false;

            GetWindowThreadProcessId(handle, out int focusedProcessId);

            return focusedProcessId == ProcessId;
        }

        public void Dispose()
        {
            _hook.Dispose();
        }
    }
}
