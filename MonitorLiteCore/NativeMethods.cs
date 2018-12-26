using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace MonitorLiteCore
{
    static class NativeMethods
    {
        public enum KeyboardUpDown
        {
            Down,
            Up,
            None
        }

        public enum KeyboardMessage
        {
            KeyDown = 0x100,
            KeyUp = 0x101,
            SysKeyDown = 0x104,
            SysKeyUp = 0x105
        }

        public struct KeyboardState
        {
            public Keys KeyCode;
            public int ScanCode;
            public KeyboardStateFlag Flag;
            public int Time;
            public IntPtr ExtraInfo;
        }

        public struct KeyboardStateFlag
        {
            private int _flag;

            private bool IsFlagging(int value)
            {
                return (_flag & value) != 0;
            }

            private void Flag(bool value, int digit)
            {
                _flag = value ? _flag | digit : _flag & ~digit;
            }

            public bool IsExtended
            {
                get { return IsFlagging(0x01); }
                set { Flag(value, 0x01); }
            }

            public bool IsInjected
            {
                get { return IsFlagging(0x10); }
                set { Flag(value, 0x10); }
            }

            public bool AltDown
            {
                get { return IsFlagging(0x20); }
                set { Flag(value, 0x20); }
            }

            public bool IsUp
            {
                get { return IsFlagging(0x80); }
                set { Flag(value, 0x80); }
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr SetWindowsHookEx(
            int hookType,
            DelegateKeyboardHook hookDelegate,
            IntPtr hInstance,
            uint threadId
        );

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int CallNextHookEx(
            IntPtr hook,
            int code,
            KeyboardMessage message,
            ref KeyboardState state
        );

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(
            IntPtr hook
        );

        [DllImport("user32.dll")]
        public static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int ToUnicodeEx(uint wVirtKey, uint wScanCode, byte[] lpKeyState, StringBuilder pwszBuff, int cchBuff, uint wFlags, IntPtr dwhkl);


        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern short GetAsyncKeyState(Keys vKey);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern short GetKeyState(Keys vKey);



        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpStr, int nMaxCount);

        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventProc lpfnWinEventProc, uint idProcess, uint idThread, uint dwflags);

        [DllImport("user32.dll")]
        public static extern IntPtr GetAncestor(IntPtr hwnd, uint gaFlags);

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifier, uint vk);

        [DllImport("user32.dll")]
        public static extern bool GetMessage(ref Message lpMsg, IntPtr hWnd, uint filterInMain, uint filterMax);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public delegate int DelegateKeyboardHook(
          int code,
          KeyboardMessage message,
          ref KeyboardState state);

        public const int WH_KEYBOARD_LL = 13;

        public delegate void WinEventProc(IntPtr hWinEventHook, uint eventId, IntPtr hwnd, long idObject, long idChild, uint dwEventThread, uint dwmsEventTime);

        public static Process GetProcessFromWindowHandle(IntPtr hWnd)
        {
            uint processId;

            NativeMethods.GetWindowThreadProcessId(hWnd, out processId);

            if (processId == 0) return null;

            try
            {
                return Process.GetProcessById((int)processId);
            }
            catch (ArgumentException)
            {
                return null;
            }


        }

        public static string GetTitleFromHandle(IntPtr hWnd)
        {
            int textLength = NativeMethods.GetWindowTextLength(hWnd);

            if (textLength > 0)
            {
                StringBuilder sb = new StringBuilder(textLength + 1);

                textLength = NativeMethods.GetWindowText(hWnd, sb, sb.Capacity);

                if (textLength > 0) return sb.ToString(0, textLength);
            }



            return "";

        }

        public static bool IsTopLevelWindow(IntPtr hWnd)
        {
            return NativeMethods.GetAncestor(hWnd, 2) == hWnd;
        }

    }
}
