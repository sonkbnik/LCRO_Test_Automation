using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SCore.Interfaces;
using SCommon.Helpers;

namespace SCore.BasicObjects
{
    public class Listbox
    {
        private readonly By Locator;
        public readonly String Name;
        public Listbox(By Locator, string name)
        {
            this.Locator = Locator;
            this.Name = name;
        }

        public void Click(string name)
        {
            DriverActions.Click(Locator, name);
        }

        public void JavaScriptClick()
        {
            DriverActions.JavaScriptClick(Locator);
        }

        public void SetListboxValue(String value)
        {
            DriverActions.SetListBoxValue(Locator, value);
        }

        public void SetListboxValueToField(String value, string elementName)
        {
            //DriverActions.SetListBoxValueToField(Locator, value);
        }
        public WebElement IsElementClickable()
        {
            WebElement ele = ExpectedCondition.IsElementClickable(Locator);
            Console.WriteLine("DROPDOWN: " + ele);
            return ele;
        }
        public WebElement WaitUntilElementExists()
        {
            return (WebElement)ExpectedCondition.WaitUntilElementExists(Locator);
        }
    }
}
