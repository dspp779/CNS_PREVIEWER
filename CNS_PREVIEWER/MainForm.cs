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
        private int pageno;
        private int downloadedPage;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            try
            {
                cnsno = textBox_cnsno.Text;
                progressBar_download.Value = 0;
                progressBar_download.Maximum = pageno;
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
            if (backgroundWorker_download.IsBusy)
                return;
            if (textBox_cnsno.TextLength == 0)
                return;
            try
            {
                label_help.Text = " checking total pages...";
                cnsno = textBox_cnsno.Text;
                if (backgroundWorker1.IsBusy)
                    backgroundWorker1.CancelAsync();
                backgroundWorker1.RunWorkerAsync(cnsno);
            }
            catch (Exception ex)
            {
                label_help.Text = ex.Message;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            pageno = CnsPreviewUtil.getTotalPage((string)e.Argument);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label_help.Text = pageno + " pages";
            button_OK.Enabled = (pageno > 0) ? true : false;
        }

        private void backgroundWorker_download_DoWork(object sender, DoWorkEventArgs e)
        {
            downloadedPage = 0;
            CnsPreviewUtil.downloadPreview(cnsno, pageno, backgroundWorker_download);
        }

        private void backgroundWorker_download_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            downloadedPage++;
            this.progressBar_download.Value = downloadedPage;
            this.Text = "Downloading " + cnsno + string.Format(" ({0}/{1}).", downloadedPage, pageno);
        }

        private void backgroundWorker_download_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Text = "CNS" + cnsno + " downloaded.";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            label_help.Text = "";
        }
    }
}
