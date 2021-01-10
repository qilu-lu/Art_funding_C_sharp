using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art_fundingV0.Models
{
    public class CookieUtil
    {
        public static string getTypeFromCookie(string cookie)
        {
            return cookie.Split('-')[0];
        }

        public static int getIdFromCookie(string cookie)
        {
            return StringUtil.toInt(cookie.Split('-')[1]);
        }

        public static string generateCookieValue(string type, int id)
        {
            return type + "-" + id;
        }
    }
}