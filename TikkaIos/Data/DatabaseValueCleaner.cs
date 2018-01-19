using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace TikkaIos.Data
{
    public class DatabaseValueCleaner
    {
        public string GetStringWithMaxLength(string str, int maxLength)
        {
            string retValue = str;

            if (str != null && str.Length > maxLength)
            {
                retValue = str.Substring(0, maxLength);
            }

            return retValue;
        }
    }
}