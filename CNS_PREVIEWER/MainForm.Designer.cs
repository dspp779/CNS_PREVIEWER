namespace CNS_PREVIEWER
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBox_cnsno = new System.Windows.Forms.TextBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.label_no = new System.Windows.Forms.Label();
            this.label_help = new System.Windows.Forms.Label();
            this.backgroundWorker_download = new System.ComponentModel.BackgroundWorker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.progressBar_download = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker_totalPage = new System.ComponentModel.BackgroundWorker();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_cnsno
            // 
            resources.ApplyResources(this.textBox_cnsno, "textBox_cnsno");
            this.textBox_cnsno.Name = "textBox_cnsno";
            this.textBox_cnsno.TextChanged += new System.EventHandler(this.textBox_cnsno_TextChanged);
            // 
            // button_OK
            // 
            resources.ApplyResources(this.button_OK, "button_OK");
            this.button_OK.Name = "button_OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // label_no
            // 
            resources.ApplyResources(this.label_no, "label_no");
            this.label_no.Name = "label_no";
            // 
            // label_help
            // 
            this.label_help.AutoEllipsis = true;
            resources.ApplyResources(this.label_help, "label_help");
            this.label_help.ForeColor = System.Drawing.Color.Red;
            this.label_help.Name = "label_help";
            // 
            // backgroundWorker_download
            // 
            this.backgroundWorker_download.WorkerReportsProgress = true;
            this.backgroundWorker_download.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_download_DoWork);
            this.backgroundWorker_download.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_download_ProgressChanged);
            this.backgroundWorker_download.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_download_RunWorkerCompleted);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label_help);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // progressBar_download
            // 
            resources.ApplyResources(this.progressBar_download, "progressBar_download");
            this.progressBar_download.Name = "progressBar_download";
            // 
            // backgroundWorker_totalPage
            // 
            this.backgroundWorker_totalPage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_totalPage_DoWork);
            this.backgroundWorker_totalPage.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_download_RunWorkerCompleted);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar_download);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label_no);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_cnsno);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_cnsno;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Label label_no;
        private System.Windows.Forms.Label label_help;
        private System.ComponentModel.BackgroundWorker backgroundWorker_download;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ProgressBar progressBar_download;
        private System.ComponentModel.BackgroundWorker backgroundWorker_totalPage;
    }
}

