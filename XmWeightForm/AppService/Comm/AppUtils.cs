using System;
using System.Collections.Generic;
using System.Text;

namespace AppService.Comm
{
    public class AppUtils
    {

        /// <summary>
        /// 字符串反转
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StringReverse(string str)
        {
            char[] cs = str.ToCharArray();
            Array.Reverse(cs);

            return new string(cs);
        }

    }
}
