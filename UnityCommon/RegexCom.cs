using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnityCommon
{
    public class RegexCom
    {
        /// <summary>
        /// 正则匹配单条图片
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string ImageUrl(string html)
        {
            var regex = new Regex("http://.*(png|jpg)",RegexOptions.IgnoreCase);
            if (regex.IsMatch(html))
            {
                var i = regex.Match(html).Groups;
                return regex.Match(html).Value;
            }

            return "";
        }
    }
}
