using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UnityCommon
{
    public class DownLoadCom
    {
        /// <summary>
        /// 根据服务器制定head的编码得到Html
        /// http://stackoverflow.com/questions/11018813/encoding-with-http-client-in-net-4-5
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string DownLoadHtml(string url)
        {
            var http = new HttpClient();
            try
            {
                return http.GetStringAsync(url).Result;
            }
            catch (Exception)
            {
                return http.GetStringAsync(url).Result;
            }
        }

        public static string DownLoadHtml(string url, Encoding encoding)
        {
            var webClient = new WebClient { Encoding = encoding };

            try
            {
                return webClient.DownloadString(url);
            }
            catch (Exception e)
            {
                return webClient.DownloadString(url);
            }
        }
    }
}
