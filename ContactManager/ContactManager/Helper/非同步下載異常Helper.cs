using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Helper
{
    public class 非同步下載異常Helper
    {
        public static async Task 非同步異常模擬()
        {
            string ServerUrl = "http://photoimageserver.azurewebsites.net";
            var client = new HttpClient();
            var response = await client.GetStringAsync(ServerUrl + "/api/Images");

            throw new NullReferenceException();
        }
    }
}
