using MonitorLiteCommon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MonitorLiteViewer
{
    static class Helpers
    {

        public static Report DecryptReport(byte[] reportData, string privateKey)
        {
            byte[] data = Cryptographics.HashVerify(reportData, privateKey);
            data = Cryptographics.Decrypt(data, privateKey);
            return Report.DeserializeReport(data);
        }

        public static string ReportToHtml(Report report)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<html><head></head><body>");

            sb.AppendFormat("<h1>{0}</h1><h2>{1}</h2>",report.Title, report.Date.ToShortDateString() + " " + report.Date.ToShortTimeString());

            switch (report.ContentType)
            {
                case Report.REPORT_TEXT:
                    {
                        sb.AppendFormat("<textarea readonly style=\"margin:0px; width:100%; height:100%;\">{0}</textarea>", report.ToText());
                    }
                    break;
                case Report.REPORT_IMAGE:
                    {
                        sb.AppendFormat("<img src='data:image/jpeg;base64, {0}'/>", Convert.ToBase64String(report.Content));
                    }
                    break;
            }
            
            sb.Append("</body></html>");

            return sb.ToString();
        }


    }
}
