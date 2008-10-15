using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WongTung.Common
{
    public class General
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool String2Bool(string value)
        {
            if (value.ToUpper() == "TRUE")
                return true;
            else
                return false;
        }
    }
}
