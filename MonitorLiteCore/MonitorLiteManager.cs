using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MonitorLiteCore
{
    public static class MonitorLiteManager
    {
        private static Hotkey hotKey;

        public static event EventHandler HotKeyPress;


        static MonitorLiteManager()
        {
            KeylogManager.Initialize();
            

        }

        public static MonitorLite CreateMonitor(MonitorSettings settings)
        {
            SetHotkey(settings.Hotkey);
            MonitorLite monitor = new MonitorLite(settings);
            ReportManager.OnReport += monitor.OnReport;
            return monitor;
        }

        private static void SetHotkey(char hotkey)
        {
            uint MOD_ALT = 0x0001;
            uint MOD_CONTROL = 0x0002;

            if(hotKey != null)
            {
                hotKey.Trigger -= HotKey_Trigger;
                hotKey.Close();
            }
            
            hotKey = Hotkey.Create(MOD_ALT | MOD_CONTROL, (Keys)Enum.Parse(typeof(Keys), hotkey.ToString(), true));
            hotKey.Trigger += HotKey_Trigger;
        }

        private static void HotKey_Trigger(object sender, EventArgs e)
        {
            HotKeyPress?.Invoke(null, EventArgs.Empty);
        }

        public static MonitorSettings GetDefaultSettings()
        {
            MonitorSettings settings = new MonitorSettings();
            
            return settings;
        }

        public static MonitorSettings ReadSettings(byte[] data)
        {
            return new MonitorSettings(data);
        }

        public static byte[] WriteSettings(MonitorSettings settings)
        {
            return settings.Export();
        }


    }
}
