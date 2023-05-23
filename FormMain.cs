using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO.Compression;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using System.Net;
using System;
using Microsoft.Identity.Client;
using PnP.Framework;
using System.Security;
using Microsoft.Graph;
using Microsoft.Extensions.Hosting;
using PnP.Framework.Provisioning.Model;
using System.ComponentModel;
using Microsoft.SharePoint.Client.Search.Query;

namespace SharePointArchiver
{
    public partial class FormMain : System.Windows.Forms.Form
    {
        private Logger _log = new Logger(100u);

        private int highestPercentageReached = 0;
        private string DownloadPath = string.Empty;
        private string sharePointUrl = string.Empty;
        private ClientContext ctx;
        private Microsoft.SharePoint.Client.Folder folder;

        public FormMain()
        {
            InitializeComponent();

            InitializeBackgroundWorker();
        }

        private void timeUpdateLogWindow_Tick(object sender, EventArgs e)
        {
            richTextBoxLog.Text = _log.GetLogAsText(true);
            richTextBoxLog.ScrollToBottom();
        }

        // Set up the BackgroundWorker object by
        // attaching event handlers.
        private void InitializeBackgroundWorker()
        {
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
        }

        private bool GetFoldersAndFiles(Microsoft.SharePoint.Client.Folder mainFolder, ClientContext clientContext, string pathString, BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return false;
            }
            else
            {

                clientContext.Load(mainFolder, k => k.Files, k => k.Folders);
                clientContext.ExecuteQuery();
                foreach (var folder in mainFolder.Folders)
                {
                    string folderPath = string.Format(@"{0}\{1}", pathString, folder.Name);

                    System.IO.Directory.CreateDirectory(folderPath);

                    _log.AddToLog("Creating Folder: " + folderPath, Color.Green);

                    GetFoldersAndFiles(folder, clientContext, folderPath, worker, e);
                }

                foreach (var file in mainFolder.Files)
                {
                    var fileRef = file.ServerRelativeUrl;
                    var fileInfo = file.OpenBinaryStream();
                    var fileName = Path.Combine(pathString, file.Name);

                    clientContext.Load(file);
                    clientContext.ExecuteQuery();

                    var stream = file.OpenBinaryStream();
                    clientContext.ExecuteQuery();

                    var filePath = pathString + @"\" + file.Name;

                    _log.AddToLog("Creating File: " + filePath, Color.Green);

                    using (var fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                    {
                        stream.Value.CopyTo(fileStream);
                    }
                }

                return true;
            }
        }


        private void buttonSetDownloadPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new System.Windows.Forms.OpenFileDialog();

            fileDialog.ValidateNames = false;

            fileDialog.CheckFileExists = false;

            fileDialog.CheckPathExists = true;

            fileDialog.Multiselect = false;

            fileDialog.FileName = "Folder Selection";

            var response = fileDialog.ShowDialog();

            if (response == DialogResult.OK)
            {
                label1.Text = Path.GetDirectoryName(fileDialog.FileName);
            }
        }

        private async void buttonDownload_Click(object sender, EventArgs e)
        {
            buttonDownload.Enabled = false;

            btnCancel.Enabled = true;

            highestPercentageReached = 0;

            Cursor.Current = Cursors.WaitCursor;

            Web currentWeb;
            DownloadPath = label1.Text;
            string userLogin = textBoxUsername.Text;
            sharePointUrl = textBoxSharePointUrl.Text.Trim();

            using (SecureString password = new SecureString())
            {
                foreach (char c in textBoxPassword.Text.ToCharArray())
                {
                    password.AppendChar(c);
                }

                textBoxPassword.Text = string.Empty;

                _log.AddToLog("START", Color.Green);

                PnP.Framework.AuthenticationManager auth = new PnP.Framework.AuthenticationManager(userLogin, password);

                try
                {
                    using (ctx = await auth.GetContextAsync(sharePointUrl))
                    {
                        currentWeb = ctx.Web;
                        ctx.Load(currentWeb);
                        await ctx.ExecuteQueryRetryAsync();

                        folder = ctx.Web.GetFolderByServerRelativeUrl(textBoxSiteUrl.Text.Trim());
                        ctx.Load(folder);
                        ctx.ExecuteQuery();

                        if (ctx.HasPendingRequest)
                            ctx.ExecuteQuery();

                        backgroundWorker1.RunWorkerAsync(folder);
                    }
                }
                catch (Exception ex)
                {
                    switch (ex)
                    {
                        case MsalUiRequiredException:
                            MessageBox.Show("Bad username or password.");
                            return;
                        default:
                            MessageBox.Show($"Error: {ex}");
                            break;
                    }
                }
            }

            return;
        }


        // This event handler updates the progress bar.
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            // Cancel the asynchronous operation.
            this.backgroundWorker1.CancelAsync();

            // Disable the Cancel button.
            btnCancel.Enabled = false;
        }

        // This event handler is where the actual,
        // potentially time-consuming work is done.
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This is will be available to the
            // RunWorkerCompleted eventhandler.
            e.Result = GetFoldersAndFiles(folder, ctx, DownloadPath, worker, e);
        }

        // This event handler deals with the results of the
        // background operation.
        private void backgroundWorker1_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled
                // the operation.
                // Note that due to a race condition in
                // the DoWork event handler, the Cancelled
                // flag may not have been set, even though
                // CancelAsync was called.
                _log.AddToLog("CANCELLED", Color.Red);
            }
            else
            {
                // Finally, handle the case where the operation
                // succeeded.
                _log.AddToLog("DONE", Color.Green);
            }

            // Enable the Start button.
            buttonDownload.Enabled = true;

            // Disable the Cancel button.
            btnCancel.Enabled = false;
        }
    }
}