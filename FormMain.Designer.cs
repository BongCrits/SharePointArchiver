namespace SharePointArchiver
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            buttonDownload = new Button();
            buttonSetDownloadPath = new Button();
            label1 = new Label();
            textBoxSiteUrl = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            label4 = new Label();
            timerLogRefresh = new System.Windows.Forms.Timer(components);
            richTextBoxLog = new ScrollingRichTextBox();
            label5 = new Label();
            textBoxSharePointUrl = new TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            progressBar1 = new ProgressBar();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // buttonDownload
            // 
            buttonDownload.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDownload.Location = new Point(584, 360);
            buttonDownload.Margin = new Padding(6);
            buttonDownload.Name = "buttonDownload";
            buttonDownload.Size = new Size(302, 83);
            buttonDownload.TabIndex = 0;
            buttonDownload.Text = "Download";
            buttonDownload.UseVisualStyleBackColor = true;
            buttonDownload.Click += buttonDownload_Click;
            // 
            // buttonSetDownloadPath
            // 
            buttonSetDownloadPath.Location = new Point(16, 64);
            buttonSetDownloadPath.Margin = new Padding(6);
            buttonSetDownloadPath.Name = "buttonSetDownloadPath";
            buttonSetDownloadPath.Size = new Size(282, 68);
            buttonSetDownloadPath.TabIndex = 1;
            buttonSetDownloadPath.Text = "Set Download Path";
            buttonSetDownloadPath.UseVisualStyleBackColor = true;
            buttonSetDownloadPath.Click += buttonSetDownloadPath_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 16);
            label1.Name = "label1";
            label1.Size = new Size(43, 32);
            label1.TabIndex = 2;
            label1.Text = "C:\\";
            // 
            // textBoxSiteUrl
            // 
            textBoxSiteUrl.Location = new Point(16, 256);
            textBoxSiteUrl.Multiline = true;
            textBoxSiteUrl.Name = "textBoxSiteUrl";
            textBoxSiteUrl.PlaceholderText = "/sites/MyFirstSharePointSite/SomeDocLibrary/SomeFolder";
            textBoxSiteUrl.Size = new Size(888, 40);
            textBoxSiteUrl.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 216);
            label2.Name = "label2";
            label2.Size = new Size(318, 32);
            label2.TabIndex = 4;
            label2.Text = "SharePoint Site Relative URL:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 304);
            label3.Name = "label3";
            label3.Size = new Size(126, 32);
            label3.TabIndex = 5;
            label3.Text = "Username:";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(24, 344);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.PlaceholderText = "user@contoso.com";
            textBoxUsername.Size = new Size(408, 39);
            textBoxUsername.TabIndex = 6;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(24, 432);
            textBoxPassword.Margin = new Padding(2, 1, 2, 1);
            textBoxPassword.MaxLength = 14;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(408, 39);
            textBoxPassword.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 392);
            label4.Name = "label4";
            label4.Size = new Size(116, 32);
            label4.TabIndex = 8;
            label4.Text = "Password:";
            // 
            // timerLogRefresh
            // 
            timerLogRefresh.Enabled = true;
            timerLogRefresh.Interval = 500;
            timerLogRefresh.Tick += timeUpdateLogWindow_Tick;
            // 
            // richTextBoxLog
            // 
            richTextBoxLog.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBoxLog.Location = new Point(24, 504);
            richTextBoxLog.Name = "richTextBoxLog";
            richTextBoxLog.ReadOnly = true;
            richTextBoxLog.Size = new Size(896, 240);
            richTextBoxLog.TabIndex = 10;
            richTextBoxLog.Text = "Logs.....";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 136);
            label5.Name = "label5";
            label5.Size = new Size(228, 32);
            label5.TabIndex = 12;
            label5.Text = "SharePoint Site URL:";
            // 
            // textBoxSharePointUrl
            // 
            textBoxSharePointUrl.Location = new Point(16, 176);
            textBoxSharePointUrl.Multiline = true;
            textBoxSharePointUrl.Name = "textBoxSharePointUrl";
            textBoxSharePointUrl.PlaceholderText = "https://contoso.sharepoint.com/sites/MyFirstSharePointSite";
            textBoxSharePointUrl.Size = new Size(888, 40);
            textBoxSharePointUrl.TabIndex = 11;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(24, 760);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(584, 40);
            progressBar1.TabIndex = 13;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(664, 760);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(224, 40);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(944, 810);
            Controls.Add(btnCancel);
            Controls.Add(progressBar1);
            Controls.Add(label5);
            Controls.Add(textBoxSharePointUrl);
            Controls.Add(richTextBoxLog);
            Controls.Add(label4);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUsername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxSiteUrl);
            Controls.Add(label1);
            Controls.Add(buttonSetDownloadPath);
            Controls.Add(buttonDownload);
            Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(6);
            MaximumSize = new Size(960, 849);
            MinimumSize = new Size(960, 849);
            Name = "FormMain";
            Text = "Share Point Archiver";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonDownload;
        private Button buttonSetDownloadPath;
        private Label label1;
        private TextBox textBoxSiteUrl;
        private Label label2;
        private Label label3;
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private Label label4;
        private System.Windows.Forms.Timer timerLogRefresh;
        private ScrollingRichTextBox richTextBoxLog;
        private Label label5;
        private TextBox textBoxSharePointUrl;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ProgressBar progressBar1;
        private Button btnCancel;
    }
}