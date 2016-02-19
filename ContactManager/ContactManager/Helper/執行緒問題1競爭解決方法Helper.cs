using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactManager.Helper
{
    class 執行緒問題1競爭解決方法Helper
    {
        private static int counter = 0;
        private static object 共用鎖 = new object();

        public static void 模擬測試()
        {
            // 建立第一個執行緒，其會執行 DoWork1 方法
            Thread thread1 = new Thread(DoWork1);

            // 建立第二個執行緒，其會執行 DoWork1 方法
            Thread thread2 = new Thread(DoWork1);

            // 開啟啟動執行這兩個執行緒
            thread1.Start();
            thread2.Start();

            // 等候這兩個執行緒結束執行
            thread1.Join();
            thread2.Join();
        }
        public static void DoWork1()
        {
            for (int index = 0; index < 10000000; index++)
            {
                // 使用 共用鎖 來避免不同執行緒可以同時執行底下程式碼
                lock (共用鎖)
                {
                    counter++;
                }
            }
        }
    }
}
