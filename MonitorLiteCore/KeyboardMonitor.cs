using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace MonitorLiteCore
{
    internal class KeyboardMonitor
    {
        public bool Installed { get { return _keyHookDelegate == null ? false : _keyHookDelegate.IsAllocated; } }
        private IntPtr _keyHook;
        private GCHandle _keyHookDelegate;

        public KeyboardMonitor()
        {
            
        }

       private int CallNextHook(int code,
          NativeMethods.KeyboardMessage message,
          ref NativeMethods.KeyboardState state)
        {
            if (code >= 0)
            {
                var e = new KeyboardMonitorEventArgs(message, ref state);
                OnKeyboardEvent(this,e);
                if (e.Cancel)
                    return -1;
            }
            return NativeMethods.CallNextHookEx(IntPtr.Zero, code, message, ref state);
        }

        public void Install()
        {
            NativeMethods.DelegateKeyboardHook callback = new NativeMethods.DelegateKeyboardHook(CallNextHook);
            _keyHookDelegate = GCHandle.Alloc(callback);
            using (var process = Process.GetCurrentProcess())
            {
                using (var module = process.MainModule)
                {
                    _keyHook = NativeMethods.SetWindowsHookEx(NativeMethods.WH_KEYBOARD_LL, callback, module.BaseAddress, 0);
                   
                }
            }
        }

        public void Unistall()
        {
            
            if (Installed)
            {
                NativeMethods.UnhookWindowsHookEx(_keyHook);
                _keyHook = IntPtr.Zero;
                _keyHookDelegate.Free();
                
            }
        }

        public event EventHandler<KeyboardMonitorEventArgs> OnKeyboardEvent;
       

    }


}
