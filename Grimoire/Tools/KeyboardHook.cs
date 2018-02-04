using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Grimoire.Tools
{
    public class KeyboardHook : IDisposable
    {
        public static KeyboardHook Instance { get; } = new KeyboardHook();

        [DllImport("user32", CallingConvention = CallingConvention.StdCall)]
        private static extern int SetWindowsHookEx(int idHook, CallbackDelegate lpfn, int hInstance, int threadId);

        [DllImport("user32", CallingConvention = CallingConvention.StdCall)]
        private static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("user32", CallingConvention = CallingConvention.StdCall)]
        private static extern int CallNextHookEx(int idHook, int nCode, int wParam, int lParam);

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;

        public delegate int CallbackDelegate(int code, int wParam, int lParam);
        private readonly CallbackDelegate hookCallback;

        public event Action<Keys> KeyDown;
        public readonly List<Keys> TargetedKeys;
        private readonly int _hookId;

        private KeyboardHook()
        {
            hookCallback = HookProc;

            _hookId = SetWindowsHookEx(WH_KEYBOARD_LL, hookCallback, 0, 0);
            TargetedKeys = new List<Keys>();
        }

        private int HookProc(int code, int wParam, int lParam)
        {
            if (code < 0)
                return CallNextHookEx(_hookId, code, wParam, lParam);

            if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN)
            {
                Keys key = (Keys)Marshal.ReadInt32((IntPtr)lParam);
                if (TargetedKeys.Contains(key))
                    KeyDown?.Invoke(key);
            }

            return CallNextHookEx(_hookId, code, wParam, lParam);
        }

        public void Dispose()
        {
            UnhookWindowsHookEx(_hookId);
        }
    }
}
