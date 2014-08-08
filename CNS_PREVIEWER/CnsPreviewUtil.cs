using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace CNS_PREVIEWER
{
    class CnsPreviewUtil
    {
        private static BackgroundWorker worker;

        // get total page of specific cns document
        public static int getTotalPage(string cnsno)
        {
            using (WebClient client = new WebClient())
            {
                string htmlDoc = client.DownloadString("http://www.cnsonline.com.tw/?node=result&generalno=" + cnsno);
                string pattern = @"javascript:accessPreview\('" + cnsno + @"', '(zh_TW)', 1, (\d+)\);";

                Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
                MatchCollection matches = rgx.Matches(htmlDoc);
                // parse total page and return
                return (matches.Count > 0) ? int.Parse(matches[0].Groups[2].Value) : 0;
            }
        }

        public static void downloadPreview(string cnsno)
        {
            downloadPreview(cnsno, getTotalPage(cnsno));
        }
        public static void downloadPreview(string cnsno, int total, BackgroundWorker progressWorker)
        {
            worker = progressWorker;
            downloadPreview(cnsno, total);
        }
        public static void downloadPreview(string cnsno, int total)
        {
            // compute how many digit
            int l = (int)Math.Floor(Math.Log10(total)) + 1;

            // parallel download
            Parallel.For(1, total+1, i =>
            {
                XmlDocument xmlResponse = getPreviewChecksum(cnsno, "zh_TW", i, total);

                if (xmlResponse.SelectSingleNode("Response/Status").InnerText.Equals("TRUE"))
                {
                    string checksum = xmlResponse.SelectSingleNode("Response/Message").InnerText.Split(',')[1];
                    string url = "http://www.cnsonline.com.tw/preview/GenerateImage?generalno=" + cnsno
                        + "&version=zh_TW&pageNum=" + i + "&checksum=" + checksum;

                    using (WebClient webClient = new WebClient())
                    {
                        string fileName = string.Format("cns{0}-{1}.jpg", cnsno, i.ToString("D" + l));
                        webClient.DownloadFile(url, fileName);
                    }
                }
                onDocDownloadComplete(i);
            });
            worker = null;
        }

        private static void onDocDownloadComplete(int pageno)
        {
            if (worker != null)
                worker.ReportProgress(pageno);
        }

        private static XmlDocument getPreviewChecksum(string cnsno, string version, int pageno, int total)
        {
            string parameter = "generalno=" + cnsno + "&version=" + version + "&pageNum=" + pageno
                + "&pages=" + total;
            return XmlRequestPostData("http://www.cnsonline.com.tw/preview/GetData", parameter);
        }

        /* send http post xml  document request
         * return xml document
         */
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
