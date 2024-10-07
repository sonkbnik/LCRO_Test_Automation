using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCore.BasicObjects
{
    public class Element
    {
        public string getLocatorValue(string locator, string replaceValue)
        {
            string elementLocator = locator.Replace("REPLACE_VALUE", replaceValue);
            return elementLocator;
        }
    }
}
