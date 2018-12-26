using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MonitorLiteCore
{
    class WindowChangeMonitorEventArgs : EventArgs
    {
        public IntPtr hWnd { get; private set; }
        public string WindowTitle { get; private set; }
        public Process WindowProcess { get; private set; }

        public WindowChangeMonitorEventArgs(IntPtr hWnd)
        {
            this.hWnd = hWnd;
            this.WindowTitle = NativeMethods.GetTitleFromHandle(hWnd);
            this.WindowProcess = NativeMethods.GetProcessFromWindowHandle(hWnd);
        }
    }
}
