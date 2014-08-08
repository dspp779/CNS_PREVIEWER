using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNS_PREVIEWER
{
    class BackgroundWorkerManager
    {
        private static BackgroundWorker totalPageManager;
        private static Dictionary<string, int> cnsTotalPageDictionary;
        private static string pendingRequestNo;

        public static EventHandler<KeyValuePair<string, int>> workCompleteEventHandler;

        static BackgroundWorkerManager()
        {
            // initialize variable
            totalPageManager = new BackgroundWorker();
            cnsTotalPageDictionary = new Dictionary<string, int>();
            pendingRequestNo = "";

            // set event handler for page information worker thread
            totalPageManager.WorkerSupportsCancellation = true;
            totalPageManager.DoWork += new System.ComponentModel.DoWorkEventHandler(totalPageManager_DoWork);
            totalPageManager.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(totalPageManager_RunWorkerCompleted);
        }

        /* Async method for requesting total page number
         * of specific cns document
         */
        public static void requestTotalPageAsync(string cnsno)
        {
            int totalPage;
            // check history first
            if (cnsTotalPageDictionary.TryGetValue(cnsno, out totalPage))
            {
                responseTotalPageAsync(cnsno, totalPage);
            }
            else if (pendingRequestNo.Length == 0)
            {
                pendingRequestNo = cnsno;
                totalPageManager.RunWorkerAsync(cnsno);
            }
            // check pending request
            else if(!pendingRequestNo.Equals(cnsno))
            {
                pendingRequestNo = cnsno;
            }
        }

        private static void responseTotalPageAsync(string cnsno, int totalPage)
        {
            workCompleteEventHandler.Invoke(totalPageManager, new KeyValuePair<string, int>(cnsno, totalPage));
        }

        private static void totalPageManager_DoWork(object sender, DoWorkEventArgs e)
        {
            string cnsno = (string)e.Argument;
            int totalPage = CnsPreviewUtil.getTotalPage((string)e.Argument);
            e.Result = new KeyValuePair<string, int>(cnsno, totalPage);
        }

        private static void totalPageManager_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            KeyValuePair<string, int> result = (KeyValuePair<string, int>)e.Result;
            cnsTotalPageDictionary.Add(result.Key, result.Value);
            if (pendingRequestNo.Equals(result.Key))
            {
                responseTotalPageAsync(result.Key, result.Value);
                pendingRequestNo = "";
            }
            else
            {
                if(!totalPageManager.IsBusy)
                    totalPageManager.RunWorkerAsync(pendingRequestNo);
            }
        }

    }
}
