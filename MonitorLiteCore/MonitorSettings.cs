using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MonitorLiteCore
{
    public class MonitorSettings
    {
        internal MonitorSettings()
        {
            this.StartLoggingOnStartup = false;
            this.StartOnStartup = false;
            this.StartMinimized = false;
            this.MinimizeToTray = false;
            this.HideTrayIcon = false;
            this.Hotkey = 'M';
            this.ReportExtension = ".prv";
            this.ReportStoragePath = @"%appdata%\logs\";
            this.PublicKey = string.Empty;
            this.MaxLogSize = 5;
        }

        internal MonitorSettings(byte[] data)
        {
            using(MemoryStream ms = new MemoryStream(data))
            {
                using(BinaryReader br = new BinaryReader(ms, Encoding.UTF8))
                {
                    StartLoggingOnStartup = br.ReadBoolean();
                    PublicKey = br.ReadString();
                    StartOnStartup = br.ReadBoolean();
                    StartMinimized = br.ReadBoolean();
                    MinimizeToTray = br.ReadBoolean();
                    HideTrayIcon = br.ReadBoolean();
                    Hotkey = br.ReadChar();
                    ReportStoragePath = br.ReadString();
                    ReportExtension = br.ReadString();
                    MaxLogSize = br.ReadInt32();
                    TakeScreenshots = br.ReadBoolean();
                }
            }
        }
        
        
        public bool StartLoggingOnStartup { get; set; }
        public string PublicKey { get; set; }

        public bool StartOnStartup { get; set; }
        public bool StartMinimized { get; set; }
        public bool MinimizeToTray { get; set; }
        public bool HideTrayIcon { get; set; }
        public char Hotkey { get; set; }
        public string ReportStoragePath { get; set; }
        public string ReportExtension { get; set;}
        public bool TakeScreenshots { get; set; }
        public int MaxLogSize { get; set; }

        internal byte[] Export()
        {
            using(MemoryStream ms = new MemoryStream())
            {
                using(BinaryWriter bw = new BinaryWriter(ms,Encoding.UTF8))
                {
                    bw.Write(StartLoggingOnStartup);
                    bw.Write(PublicKey);
                    bw.Write(StartOnStartup);
                    bw.Write(StartMinimized);
                    bw.Write(MinimizeToTray);
                    bw.Write(HideTrayIcon);
                    bw.Write(Hotkey);
                    bw.Write(ReportStoragePath);
                    bw.Write(ReportExtension);
                    bw.Write(MaxLogSize);
                    bw.Write(TakeScreenshots);
                }
                return ms.ToArray();
            }
        }

    }
}
