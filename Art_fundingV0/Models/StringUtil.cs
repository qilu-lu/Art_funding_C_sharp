using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art_fundingV0.Models
{
    public class StringUtil
    {
        public static int toInt(string s)
        {
            int id;
            int.TryParse(s, out id);
            return id;
        }
    }
}