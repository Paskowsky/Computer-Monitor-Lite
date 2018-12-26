using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MonitorLiteCore;
using System.IO;
using MonitorLiteViewer;

namespace MonitorLiteUi
{
    public partial class Form1 : Form
    {

        MonitorLite monitor;
        LogViewer logViewer;
        public Form1(MonitorSettings settings)
        {

            InitializeComponent();

            MonitorLiteManager.HotKeyPress += MonitorLiteManager_HotKeyPress;

            tabControl2.SelectedIndexChanged += TabControl2_SelectedIndexChanged;
            SetUiSettings(settings);


            RestartMonitor();

            logViewer = new LogViewer();
            this.FormClosing += Form1_FormClosing;
            this.notifyIcon1.Icon = this.Icon;
            this.notifyIcon1.MouseDoubleClick += NotifyIcon1_MouseDoubleClick;
            this.Resize += Form1_Resize;
        }

        private void MonitorLiteManager_HotKeyPress(object sender, EventArgs e)
        {
            if (this.IsDisposed)
                return;

            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => { MonitorLiteManager_HotKeyPress(sender, e); }));
                return;
            }

           

            if (!this.Visible)
            {
                this.Show();
            }

            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                if (!this.Visible)
                    return;

                if (monitor == null)
                    return;

                if (!monitor.Settings.MinimizeToTray)
                    return;



                this.ShowInTaskbar = false;
                this.notifyIcon1.Visible = !monitor.Settings.HideTrayIcon;
                this.Hide();
            }
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.notifyIcon1.Visible = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }






        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (monitor != null)
            {
                monitor.Stop();
            }
        }

        private void RestartMonitor()
        {
            bool enabled = false;
            if (monitor != null)
            {
                enabled = monitor.Enabled;
                monitor.Stop();
                monitor = null;
            }
            monitor = MonitorLiteManager.CreateMonitor(GetUiSettings());
            Monitor_OnStatusChange(null, EventArgs.Empty);
            monitor.OnStatusChange += Monitor_OnStatusChange;

            if (enabled && !monitor.Enabled)
                monitor.Start();

            if (monitor.Settings.StartMinimized)
            {
                this.WindowState = FormWindowState.Minimized;
                if (monitor.Settings.MinimizeToTray)
                {
                    this.ShowInTaskbar = false;
                }
                else { this.ShowInTaskbar = true; }
            }



        }

        private void Monitor_OnStatusChange(object sender, EventArgs e)
        {
            if (monitor.Enabled)
            {
                start_stop.Text = "Stop";
            }
            else
            {
                start_stop.Text = "Start";
            }
        }

        private void TabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tag = tabControl2.SelectedTab.Tag as string;
            if (tag == "SAVE")
            {
                SaveMonitorSettings();
                RestartMonitor();
                label3.Text = Program.monitorSettingPath;
            }
        }

        private void ReadMonitorSettings()
        {
            MonitorSettings settings;

            if (!File.Exists(Program.monitorSettingPath))
            {
                settings = GetUiSettings();
            }
            else
            {
                byte[] settingsData = File.ReadAllBytes(Program.monitorSettingPath);
                settings = MonitorLiteManager.ReadSettings(settingsData);
                SetUiSettings(settings);
            }
        }

        private void SaveMonitorSettings()
        {
            MonitorSettings settings = GetUiSettings();
            byte[] settingsData = MonitorLiteManager.WriteSettings(settings);
            File.WriteAllBytes(Program.monitorSettingPath, settingsData);
        }

        private MonitorSettings GetUiSettings()
        {
            MonitorSettings settings = MonitorLiteManager.GetDefaultSettings();
            settings.StartOnStartup = start_startup.Checked;
            settings.StartLoggingOnStartup = start_log_startup.Checked;
            settings.StartMinimized = start_minimized.Checked;
            settings.MinimizeToTray = minimize_tray.Checked;
            settings.HideTrayIcon = hide_tray.Checked;
            settings.Hotkey = hotkey.Text[0];
            settings.ReportStoragePath = report_folder.Text;
            settings.ReportExtension = report_extension.Text;
            settings.MaxLogSize = (int)max_log_size.Value;
            settings.PublicKey = public_key.Text;
            settings.TakeScreenshots = take_screen.Checked;
            return settings;
        }

        private void SetUiSettings(MonitorSettings settings)
        {
            start_startup.Checked = settings.StartOnStartup;
            start_log_startup.Checked = settings.StartLoggingOnStartup;
            start_minimized.Checked = settings.StartMinimized;
            minimize_tray.Checked = settings.MinimizeToTray;
            hide_tray.Checked = settings.HideTrayIcon;
            hotkey.Text = settings.Hotkey.ToString();
            report_folder.Text = settings.ReportStoragePath;
            report_extension.Text = settings.ReportExtension;
            max_log_size.Value = settings.MaxLogSize;
            public_key.Text = settings.PublicKey;
            take_screen.Checked = settings.TakeScreenshots;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string publicKey, privateKey;
            MonitorLiteCommon.Cryptographics.GenerateKeyPair(out publicKey, out privateKey);
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Plain Text(.txt)|*.txt";
                sfd.FileName = "public_key.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, publicKey);
                }
                sfd.FileName = "private_key.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, privateKey);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!IsAllUpper(hotkey.Text))
                hotkey.Text = hotkey.Text.ToUpperInvariant();
        }

        private bool IsAllUpper(string s)
        {
            foreach (char c in s)
                if (!char.IsUpper(c))
                    return false;
            return true;
        }

        private void start_stop_Click(object sender, EventArgs e)
        {
            if (monitor == null || !monitor.Enabled)
            {
                RestartMonitor();
                if (!monitor.Enabled)
                    monitor.Start();
                return;
            }

            monitor.Stop();

        }

        private void view_logs_Click(object sender, EventArgs e)
        {
            if (monitor == null)
                return;

            logViewer.ShowLogViewer(monitor.Settings.ReportStoragePath, monitor.Settings.ReportExtension);
        }
    }
}
