using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace MonitorLiteCore
{
    class WindowChangeMonitor
    {
        private GCHandle _keyHookDelegate;
        private IntPtr _keyHook;

        public bool Installed { get { return _keyHookDelegate == null ? false : _keyHookDelegate.IsAllocated; } }

        public event EventHandler<WindowChangeMonitorEventArgs> OnWindowChangeEvent;

        public void Install()
        {
            if (Installed)
                return;

            NativeMethods.WinEventProc callback = new NativeMethods.WinEventProc(EventProcessor);
            _keyHookDelegate = GCHandle.Alloc(callback);

            _keyHook = NativeMethods.SetWinEventHook(3, 32780, IntPtr.Zero, callback, 0, 0, 0);

            if (_keyHook == IntPtr.Zero) throw new Win32Exception("H");

            IntPtr currentForegroundWindow = NativeMethods.GetForegroundWindow();

            new Thread(new ThreadStart(() => { OnWindowChangeEvent?.Invoke(this, new WindowChangeMonitorEventArgs(currentForegroundWindow)); })).Start();

           // InvokeFocusChange(currentForegroundWindow, NativeHelpers.GetTitleFromHandle(currentForegroundWindow), NativeHelpers.GetProcessFromWindowHandle(currentForegroundWindow));

            //OnWindowFocus.BeginInvoke(currentForegroundWindow, Utilities.GetTitleFromHandle(currentForegroundWindow),
            //    Utilities.GetProcessFromWindowHandle(currentForegroundWindow), null, null);
        }

        public void Unistall()
        {
            if (!Installed)
                return;

            NativeMethods.UnhookWinEvent(_keyHook);
            _keyHook = IntPtr.Zero;
            _keyHookDelegate.Free();
        }

        private void EventProcessor(IntPtr hWinEventHook, uint eventId, IntPtr hWnd, long idObject, long idChild, uint dwEventThread, uint dwmsEventTime)
        {
            //   if (idObject != 0 || idChild != 0) return;

            if (hWnd == IntPtr.Zero) return;

            if (eventId != 3) return;

            if (!NativeMethods.IsTopLevelWindow(hWnd)) return;

            new Thread(new ThreadStart(() => { OnWindowChangeEvent?.Invoke(this, new WindowChangeMonitorEventArgs(hWnd)); })).Start();
           

            //InvokeFocusChange(hWnd, NativeMethods.GetTitleFromHandle(hWnd), NativeMethods.GetProcessFromWindowHandle(hWnd));




        }

    }
}
