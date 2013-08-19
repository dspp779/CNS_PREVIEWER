using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CNS_PREVIEWER
{
    class CnsUtil
    {
        public static void downloadPreview(int cnsno, int total)
        {
            int l = (int)Math.Floor(Math.Log10(total)) + 1;

            for (int i = 1; i <= total; i++)
            {
                XmlDocument xmlResponse = getPreviewChecksum(cnsno, "zh_TW", i, total);

                if (!xmlResponse.SelectSingleNode("Response/Status").InnerText.Equals("TRUE"))
                {
                    break;
                }
                string checksum = xmlResponse.SelectSingleNode("Response/Message").InnerText.Split(',')[1];
                string url = "http://www.cnsonline.com.tw/preview/GenerateImage?generalno=" + cnsno
                    + "&version=zh_TW&pageNum=" + i + "&checksum=" + checksum;

                using (WebClient webClient = new WebClient())
                {
                    string fileName = string.Format("cns{0}-{1}.jpg", cnsno, i.ToString("D" + l));
                    webClient.DownloadFile(url, fileName);
                }
            }
            // get checksum

            /*if (xmlResponse.SelectSingleNode("Response/Status").InnerText.Equals("TRUE"))
            {
                string checksum = xmlResponse.SelectSingleNode("Response/Message").InnerText.Split(',')[1];
                string url = "http://www.cnsonline.com.tw/preview/GenerateImage?generalno=4940"
                    + "&version=zh_TW&pageNum=2&checksum=" + checksum;
                pictureBox1.ImageLocation = url;
            }*/
        }

        private static XmlDocument getPreviewChecksum(int no, string version, int pageno, int total)
        {
            string parameter = "generalno=" + no + "&version=zh_TW&pageNum=" + pageno
                + "&pages=" + total;
            return XmlRequestPostData("http://www.cnsonline.com.tw/preview/GetData", parameter);
        }

        private static XmlDocument XmlRequestPostData(string url, string postData)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(postData);

            request.Method = "POST";
            request.Accept = "text/xml";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            HttpRequestCachePolicy noCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            request.CachePolicy = noCachePolicy;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                return (xmlDoc);
            }
        }

    }
}
