using System;
using System.Collections.Generic;
using System.Text;

namespace MonitorLiteViewer
{
    public class LogViewer
    {
        private LogViewerForm _form;



        public void ShowLogViewer(string logFolder,string logExt)
        {
            if(_form == null)
            {
                _form = new LogViewerForm(logFolder,logExt);
            }

            if (_form.Visible)
            {
                _form.Focus();
            }
            else
            {
                _form.Show();
            }
        }
    }
}
