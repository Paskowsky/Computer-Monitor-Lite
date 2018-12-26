namespace MonitorLiteUi
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gen_keypair = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.view_logs = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.start_stop = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.max_log_size = new System.Windows.Forms.NumericUpDown();
            this.take_screen = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.hotkey = new System.Windows.Forms.TextBox();
            this.hide_tray = new System.Windows.Forms.CheckBox();
            this.minimize_tray = new System.Windows.Forms.CheckBox();
            this.start_minimized = new System.Windows.Forms.CheckBox();
            this.start_startup = new System.Windows.Forms.CheckBox();
            this.start_log_startup = new System.Windows.Forms.CheckBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.public_key = new System.Windows.Forms.TextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.report_extension = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.report_folder = new System.Windows.Forms.TextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.max_log_size)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(260, 238);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(252, 212);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gen_keypair);
            this.groupBox4.Location = new System.Drawing.Point(6, 140);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(240, 62);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Keys";
            // 
            // gen_keypair
            // 
            this.gen_keypair.Location = new System.Drawing.Point(6, 19);
            this.gen_keypair.Name = "gen_keypair";
            this.gen_keypair.Size = new System.Drawing.Size(228, 36);
            this.gen_keypair.TabIndex = 0;
            this.gen_keypair.Text = "Generate Key-Pair...";
            this.gen_keypair.UseVisualStyleBackColor = true;
            this.gen_keypair.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.view_logs);
            this.groupBox2.Location = new System.Drawing.Point(6, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 62);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log Viewer";
            // 
            // view_logs
            // 
            this.view_logs.Location = new System.Drawing.Point(6, 19);
            this.view_logs.Name = "view_logs";
            this.view_logs.Size = new System.Drawing.Size(228, 36);
            this.view_logs.TabIndex = 0;
            this.view_logs.Text = "View Logs...";
            this.view_logs.UseVisualStyleBackColor = true;
            this.view_logs.Click += new System.EventHandler(this.view_logs_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.start_stop);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // start_stop
            // 
            this.start_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.start_stop.Location = new System.Drawing.Point(6, 18);
            this.start_stop.Name = "start_stop";
            this.start_stop.Size = new System.Drawing.Size(228, 36);
            this.start_stop.TabIndex = 0;
            this.start_stop.Text = "Start";
            this.start_stop.UseVisualStyleBackColor = true;
            this.start_stop.Click += new System.EventHandler(this.start_stop_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(252, 212);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Location = new System.Drawing.Point(6, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(240, 200);
            this.tabControl2.TabIndex = 4;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox8);
            this.tabPage4.Controls.Add(this.take_screen);
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.Controls.Add(this.hide_tray);
            this.tabPage4.Controls.Add(this.minimize_tray);
            this.tabPage4.Controls.Add(this.start_minimized);
            this.tabPage4.Controls.Add(this.start_startup);
            this.tabPage4.Controls.Add(this.start_log_startup);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(232, 174);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "General";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.max_log_size);
            this.groupBox8.Location = new System.Drawing.Point(6, 122);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(111, 46);
            this.groupBox8.TabIndex = 10;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Max Log Size (Kb)";
            // 
            // max_log_size
            // 
            this.max_log_size.Location = new System.Drawing.Point(6, 19);
            this.max_log_size.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.max_log_size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.max_log_size.Name = "max_log_size";
            this.max_log_size.Size = new System.Drawing.Size(99, 20);
            this.max_log_size.TabIndex = 0;
            this.max_log_size.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // take_screen
            // 
            this.take_screen.AutoSize = true;
            this.take_screen.Location = new System.Drawing.Point(108, 52);
            this.take_screen.Name = "take_screen";
            this.take_screen.Size = new System.Drawing.Size(111, 17);
            this.take_screen.TabIndex = 9;
            this.take_screen.Text = "Take screenshots";
            this.take_screen.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.hotkey);
            this.groupBox5.Location = new System.Drawing.Point(107, 75);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(119, 46);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Hotkey";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CTRL + ALT +";
            // 
            // hotkey
            // 
            this.hotkey.Location = new System.Drawing.Point(88, 19);
            this.hotkey.MaxLength = 1;
            this.hotkey.Name = "hotkey";
            this.hotkey.Size = new System.Drawing.Size(24, 20);
            this.hotkey.TabIndex = 0;
            this.hotkey.Text = "M";
            this.hotkey.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // hide_tray
            // 
            this.hide_tray.AutoSize = true;
            this.hide_tray.Location = new System.Drawing.Point(6, 52);
            this.hide_tray.Name = "hide_tray";
            this.hide_tray.Size = new System.Drawing.Size(91, 17);
            this.hide_tray.TabIndex = 7;
            this.hide_tray.Text = "Hide tray icon";
            this.hide_tray.UseVisualStyleBackColor = true;
            // 
            // minimize_tray
            // 
            this.minimize_tray.AutoSize = true;
            this.minimize_tray.Location = new System.Drawing.Point(108, 29);
            this.minimize_tray.Name = "minimize_tray";
            this.minimize_tray.Size = new System.Drawing.Size(98, 17);
            this.minimize_tray.TabIndex = 6;
            this.minimize_tray.Text = "Minimize to tray";
            this.minimize_tray.UseVisualStyleBackColor = true;
            // 
            // start_minimized
            // 
            this.start_minimized.AutoSize = true;
            this.start_minimized.Location = new System.Drawing.Point(6, 29);
            this.start_minimized.Name = "start_minimized";
            this.start_minimized.Size = new System.Drawing.Size(96, 17);
            this.start_minimized.TabIndex = 5;
            this.start_minimized.Text = "Start minimized";
            this.start_minimized.UseVisualStyleBackColor = true;
            // 
            // start_startup
            // 
            this.start_startup.AutoSize = true;
            this.start_startup.Location = new System.Drawing.Point(6, 75);
            this.start_startup.Name = "start_startup";
            this.start_startup.Size = new System.Drawing.Size(98, 17);
            this.start_startup.TabIndex = 4;
            this.start_startup.Text = "Start on startup";
            this.start_startup.UseVisualStyleBackColor = true;
            // 
            // start_log_startup
            // 
            this.start_log_startup.AutoSize = true;
            this.start_log_startup.Location = new System.Drawing.Point(6, 6);
            this.start_log_startup.Name = "start_log_startup";
            this.start_log_startup.Size = new System.Drawing.Size(149, 17);
            this.start_log_startup.TabIndex = 1;
            this.start_log_startup.Text = "Start logging on execution";
            this.start_log_startup.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox3);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(232, 174);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Keys";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.public_key);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(220, 162);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Public Key";
            // 
            // public_key
            // 
            this.public_key.Location = new System.Drawing.Point(6, 19);
            this.public_key.Multiline = true;
            this.public_key.Name = "public_key";
            this.public_key.Size = new System.Drawing.Size(208, 137);
            this.public_key.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.groupBox7);
            this.tabPage7.Controls.Add(this.groupBox6);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(232, 174);
            this.tabPage7.TabIndex = 3;
            this.tabPage7.Text = "Reports";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.report_extension);
            this.groupBox7.Location = new System.Drawing.Point(6, 88);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(220, 47);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Report extension";
            // 
            // report_extension
            // 
            this.report_extension.Location = new System.Drawing.Point(6, 19);
            this.report_extension.Name = "report_extension";
            this.report_extension.Size = new System.Drawing.Size(208, 20);
            this.report_extension.TabIndex = 0;
            this.report_extension.Text = ".prv";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button4);
            this.groupBox6.Controls.Add(this.report_folder);
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(220, 76);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Report folder";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 45);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(208, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Browse...";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // report_folder
            // 
            this.report_folder.Location = new System.Drawing.Point(6, 19);
            this.report_folder.Name = "report_folder";
            this.report_folder.Size = new System.Drawing.Size(208, 20);
            this.report_folder.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label3);
            this.tabPage6.Controls.Add(this.label2);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(232, 174);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Tag = "SAVE";
            this.tabPage6.Text = "Save";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "settings.bin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Successfully saved settings to :";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(252, 212);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "About";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "Computer Monitor Lite";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "COMPUTER LITE MONITOR";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Coded by Paskowsky";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Computer Monitor Lite";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.max_log_size)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button view_logs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button start_stop;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox start_log_startup;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button gen_keypair;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox hotkey;
        private System.Windows.Forms.CheckBox hide_tray;
        private System.Windows.Forms.CheckBox minimize_tray;
        private System.Windows.Forms.CheckBox start_minimized;
        private System.Windows.Forms.CheckBox start_startup;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox public_key;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox take_screen;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox report_folder;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox report_extension;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.NumericUpDown max_log_size;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}

