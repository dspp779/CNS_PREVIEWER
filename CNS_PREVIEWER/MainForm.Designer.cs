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
            this.textBox_page = new System.Windows.Forms.TextBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.label_no = new System.Windows.Forms.Label();
            this.label_page = new System.Windows.Forms.Label();
            this.label_help = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_cnsno
            // 
            this.textBox_cnsno.Location = new System.Drawing.Point(73, 9);
            this.textBox_cnsno.Name = "textBox_cnsno";
            this.textBox_cnsno.Size = new System.Drawing.Size(100, 22);
            this.textBox_cnsno.TabIndex = 0;
            // 
            // textBox_page
            // 
            this.textBox_page.Location = new System.Drawing.Point(73, 37);
            this.textBox_page.Name = "textBox_page";
            this.textBox_page.Size = new System.Drawing.Size(100, 22);
            this.textBox_page.TabIndex = 1;
            // 
            // button_OK
            // 
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
            // label_page
            // 
            this.label_page.AutoSize = true;
            this.label_page.Location = new System.Drawing.Point(12, 40);
            this.label_page.Name = "label_page";
            this.label_page.Size = new System.Drawing.Size(54, 12);
            this.label_page.TabIndex = 4;
            this.label_page.Text = "Total Page";
            // 
            // label_help
            // 
            this.label_help.AutoSize = true;
            this.label_help.ForeColor = System.Drawing.Color.Red;
            this.label_help.Location = new System.Drawing.Point(12, 70);
            this.label_help.MaximumSize = new System.Drawing.Size(90, 0);
            this.label_help.Name = "label_help";
            this.label_help.Size = new System.Drawing.Size(0, 12);
            this.label_help.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 102);
            this.Controls.Add(this.label_help);
            this.Controls.Add(this.label_page);
            this.Controls.Add(this.label_no);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_page);
            this.Controls.Add(this.textBox_cnsno);
            this.Name = "MainForm";
            this.Text = "CNS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_cnsno;
        private System.Windows.Forms.TextBox textBox_page;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Label label_no;
        private System.Windows.Forms.Label label_page;
        private System.Windows.Forms.Label label_help;
    }
}

