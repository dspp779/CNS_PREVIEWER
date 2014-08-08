using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNS_PREVIEWER
{
    public partial class MainForm : Form
    {
        private string cnsno;
        private int totalPage;

        // keep track of document download mission
        private int numOfDownloadedPage;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            try
            {
                cnsno = textBox_cnsno.Text;
                // reset the progress bar
                progressBar_download.Value = 0;
                progressBar_download.Maximum = totalPage;
                // run download worker
                backgroundWorker_download.RunWorkerAsync();
            }
            catch (FormatException ex)
            {
                label_help.Text = ex.Message;
            }
            catch (InvalidOperationException)
            {
                label_help.Text = "請等待當前下載作業完成";
            }

        }

        private void textBox_cnsno_TextChanged(object sender, EventArgs e)
        {
            if (textBox_cnsno.TextLength == 0)
                return;
            try
            {
                label_help.Text = " checking total pages...";
                cnsno = textBox_cnsno.Text;

                BackgroundWorkerManager.requestTotalPageAsync(cnsno);
            }
            catch (Exception ex)
            {
                label_help.Text = ex.Message;
            }
        }
        
        private void totalPage_RunWorkerCompleted(object sender, KeyValuePair<string, int> e)
        {
            totalPage = e.Value;
            label_help.Text = totalPage + " pages";
            button_OK.Enabled = (totalPage > 0) ? true : false;
        }

        private void backgroundWorker_download_DoWork(object sender, DoWorkEventArgs e)
        {
            numOfDownloadedPage = 0;
            CnsPreviewUtil.downloadPreview(cnsno, totalPage, backgroundWorker_download);
        }
        private void backgroundWorker_download_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            numOfDownloadedPage++;
            this.progressBar_download.Value = numOfDownloadedPage;
            this.Text = "Downloading " + cnsno + string.Format(" ({0}/{1}).", numOfDownloadedPage, totalPage);
        }
        private void backgroundWorker_download_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Text = "CNS" + cnsno + " downloaded.";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            label_help.Text = "";
            // bind total page request-completing event handler
            BackgroundWorkerManager.workCompleteEventHandler
                += new EventHandler<KeyValuePair<string, int>>(this.totalPage_RunWorkerCompleted);
        }
    }
}
