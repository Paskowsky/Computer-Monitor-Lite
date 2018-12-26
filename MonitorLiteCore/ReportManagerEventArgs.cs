using MonitorLiteCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitorLiteCore
{
    class ReportManagerEventArgs : EventArgs
    {
        public Report Report { get; private set; }
        public ReportManagerEventArgs(Report r)
        {
            Report = r;
        }
    }
}
