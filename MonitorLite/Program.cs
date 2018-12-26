using MonitorLiteCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MonitorLiteUi
{
    static class Program
    {
        internal static string monitorSettingPath = "monitor.config";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MonitorSettings settings = MonitorLiteManager.GetDefaultSettings();
            if (File.Exists(monitorSettingPath))
            {
                byte[] settingsData = File.ReadAllBytes(Program.monitorSettingPath);
                settings = MonitorLiteManager.ReadSettings(settingsData);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(settings));
        }


    }
}
