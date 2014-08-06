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
            this.textBox_cnsno = new System.Windows.Forms.TextBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.label_no = new System.Windows.Forms.Label();
            this.label_help = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_download = new System.ComponentModel.BackgroundWorker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.progressBar_download = new System.Windows.Forms.ProgressBar();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_cnsno
            // 
            this.textBox_cnsno.Location = new System.Drawing.Point(67, 9);
            this.textBox_cnsno.Name = "textBox_cnsno";
            this.textBox_cnsno.Size = new System.Drawing.Size(106, 22);
            this.textBox_cnsno.TabIndex = 0;
            this.textBox_cnsno.TextChanged += new System.EventHandler(this.textBox_cnsno_TextChanged);
            // 
            // button_OK
            // 
            this.button_OK.Enabled = false;
            this.button_OK.Location = new System.Drawing.Point(98, 65);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 2;
            this.button_OK.Text = "Download";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // label_no
            // 
            this.label_no.AutoSize = true;
            this.label_no.Location = new System.Drawing.Point(12, 12);
            this.label_no.Name = "label_no";
            this.label_no.Size = new System.Drawing.Size(49, 12);
            this.label_no.TabIndex = 3;
            this.label_no.Text = "CNS NO.";
            // 
            // label_help
            // 
            this.label_help.AutoEllipsis = true;
            this.label_help.AutoSize = true;
            this.label_help.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_help.ForeColor = System.Drawing.Color.Red;
            this.label_help.Location = new System.Drawing.Point(103, 0);
            this.label_help.MaximumSize = new System.Drawing.Size(160, 0);
            this.label_help.Name = "label_help";
            this.label_help.Size = new System.Drawing.Size(53, 12);
            this.label_help.TabIndex = 5;
            this.label_help.Text = "label_help";
            this.label_help.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
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
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(14, 40);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(159, 19);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // progressBar_download
            // 
            this.progressBar_download.Location = new System.Drawing.Point(13, 64);
            this.progressBar_download.Name = "progressBar_download";
            this.progressBar_download.Size = new System.Drawing.Size(79, 23);
            this.progressBar_download.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 102);
            this.Controls.Add(this.progressBar_download);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label_no);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_cnsno);
            this.Name = "MainForm";
            this.Text = "CNS";
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
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker_download;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ProgressBar progressBar_download;
    }
}

