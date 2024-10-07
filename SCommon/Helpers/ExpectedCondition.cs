using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SCommon.Wrappers;
using SeleniumExtras.WaitHelpers;

namespace SCommon.Helpers
{
    public class ExpectedCondition
    {
        static WebDriverWait wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(15));

        public static WebElement IsElementClickable(By by)
        {
            try
            {
                WebElement ele = (WebElement)wait.Until(ExpectedConditions.ElementToBeClickable(Browser.GetDriver().FindElement(by)));
                return ele;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Element is not clickable: " + by);
                return null;
            }

        }

        public static WebElement WaitUntilElementExists(By by)
        {
            try
            {
                Console.WriteLine("EXPECTED_CONDITION: " + (WebElement)wait.Until(ExpectedConditions.ElementExists(by)));
                return (WebElement)wait.Until(ExpectedConditions.ElementExists(by));
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXPECTED_CONDITION_EXCEPTION: " + ex.StackTrace + ex.InnerException);
                return null;
            }
        }
    }
}
