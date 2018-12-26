using MonitorLiteCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MonitorLiteViewer
{
    partial class LogViewerForm : Form
    {
        private string LogFolder { get; set; }
        private string LogExtension { get; set; }

        public LogViewerForm(string logsFolder, string logsExt)
        {

            LogFolder = logsFolder;
            LogExtension = logsExt;

            InitializeComponent();
            this.tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            PopulateLogList();
        }

        private void PopulateLogList()
        {
            string privKey;
            if (!TryGetPrivateKey(out privKey))
                return;
            new Thread(new ThreadStart(() =>
            {
                PopulateLogListBack(privKey);
            })).Start();
        }

        private void PopulateLogListBack(string privKey)
        {
           
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => { betterListView1.SuspendLayout();
                    betterListView1.Items.Clear();


                }));
            }
            else
            {
                betterListView1.SuspendLayout();
                betterListView1.Items.Clear();
            }



            foreach (string file in Directory.GetFiles(Environment.ExpandEnvironmentVariables(LogFolder), string.Format("*{0}", LogExtension)))
            {
                try
                {
                    byte[] fileData = File.ReadAllBytes(file);

                    Report r = Helpers.DecryptReport(fileData, privKey);

                    ListViewItem item = new ListViewItem(new string[] { r.Date.ToString(), r.Title });
                    item.Tag = file;

                    if (this.InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(() => { betterListView1.Items.Add(item); }));
                    }
                    else
                    {
                        betterListView1.Items.Add(item);
                    }
                }
                catch
                {

                }
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => { betterListView1.ResumeLayout(); }));
            }
            else
            {
                betterListView1.ResumeLayout();
            }

        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Tag as string == "VIEW")
            {
                PopulateLogList();

            }
        }

        private bool TryGetPrivateKey(out string privateKey)
        {
            privateKey = null;
            if (string.IsNullOrEmpty(textBox1.Text))
                return false;

            privateKey = textBox1.Text;
            return true;
        }

        private void betterListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string privKey;
            if (!TryGetPrivateKey(out privKey))
                return;

            foreach(ListViewItem item in betterListView1.SelectedItems)
            {
                string filePath = item.Tag as string;
                if (!File.Exists(filePath))
                    continue;

                byte[] fileData = File.ReadAllBytes(filePath);

                Report report = Helpers.DecryptReport(fileData, privKey);

                webBrowser1.DocumentText = Helpers.ReportToHtml(report);
            }
        }
    }

    
}
