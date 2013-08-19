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
        public MainForm()
        {
            InitializeComponent();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            int cnsno = int.Parse(textBox_cnsno.Text);
            int total = int.Parse(textBox_page.Text);
            int l = (int)Math.Floor(Math.Log10(total)) + 1;

            CnsUtil.downloadPreview(cnsno, total);
            // get checksum

            /*if (xmlResponse.SelectSingleNode("Response/Status").InnerText.Equals("TRUE"))
            {
                string checksum = xmlResponse.SelectSingleNode("Response/Message").InnerText.Split(',')[1];
                string url = "http://www.cnsonline.com.tw/preview/GenerateImage?generalno=4940"
                    + "&version=zh_TW&pageNum=2&checksum=" + checksum;
                pictureBox1.ImageLocation = url;
            }*/
        }
    }
}
