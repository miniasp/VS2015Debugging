using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactManager.Helper
{
    public class 不同優先權的執行緒Helper
    {
        #region 執行緒委派要用到的方法
        // 這個 Thread 委派方法，需要接收一個參數，而且，該參數的類型必須要 Object
        public void 執行緒方法(object fooObject)
        {
            string fooOutput = fooObject as string;
            if (fooOutput == "2")
                fooOutput = "╴";
            else if (fooOutput == "3")
                fooOutput = "▂";
            else if (fooOutput == "4")
                fooOutput = "▄";
            else if (fooOutput == "5")
                fooOutput = "▆";
            else if (fooOutput == "6")
                fooOutput = "█";

            for (int i = 0; i < 5000; i++)
            {

                Console.Write("{0}", fooOutput);
            }
        }
        #endregion

        #region 模擬不同執行緒的執行
        public void 模擬不同執行緒的執行()
        {
            // 產生一個新的 Thread，當該Thread啟動之後，會執行 [執行緒方法2] 方法
            #region 執行緒優先權為 Lowest
            Thread t2 = new Thread(new ParameterizedThreadStart(執行緒方法));
            ThreadPriority fooThreadPriority2 = ThreadPriority.Lowest;
            t2.Name = "執行緒優先權 " + fooThreadPriority2.ToString();
            t2.Priority = fooThreadPriority2;
            t2.Start("2");
            #endregion

            #region 執行緒優先權為 BelowNormal
            Thread t3 = new Thread(new ParameterizedThreadStart(執行緒方法));
            ThreadPriority fooThreadPriority3 = ThreadPriority.BelowNormal;
            t3.Name = "執行緒優先權 " + fooThreadPriority3.ToString();
            t3.Priority = fooThreadPriority3;
            t3.Start("3");
            #endregion

            #region 執行緒優先權為 Normal
            Thread t4 = new Thread(new ParameterizedThreadStart(執行緒方法));
            ThreadPriority fooThreadPriority4 = ThreadPriority.Normal;
            t4.Name = "執行緒優先權 " + fooThreadPriority4.ToString();
            t4.Priority = fooThreadPriority4;
            t4.Start("4");
            #endregion

            #region 執行緒優先權為 AboveNormal
            Thread t5 = new Thread(new ParameterizedThreadStart(執行緒方法));
            ThreadPriority fooThreadPriority5 = ThreadPriority.AboveNormal;
            t5.Name = "執行緒優先權 " + fooThreadPriority5.ToString();
            t5.Priority = fooThreadPriority5;
            t5.Start("5");
            #endregion

            #region 執行緒優先權為 Highest
            Thread t6 = new Thread(new ParameterizedThreadStart(執行緒方法));
            ThreadPriority fooThreadPriority6 = ThreadPriority.Highest;
            t6.Name = "執行緒優先權 " + fooThreadPriority6.ToString();
            t6.Priority = fooThreadPriority6;
            t6.Start("6");
            #endregion
        }
        #endregion
    }
}
