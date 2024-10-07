using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SCommon.Wrappers;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace SCommon.Helpers
{
    public static class DriverActions
    {
        public static void Click(By by, string name, int timeout = 20)
        {
            try
            {
                var element = Browser.GetDriver().FindElement(by);
                Actions actions = new Actions(Browser.GetDriver());
                WebDriverWait wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(20));
                wait.Until(driver => driver.FindElement(by));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                wait.Until(ExpectedConditions.ElementToBeClickable(by));
                actions.Click(element).Perform();
                ReportHandler.Log(AventStack.ExtentReports.Status.Info, $"{name} Clicked");

            }
            catch (Exception)
            {
                Console.WriteLine("Element not found");
                ReportHandler.Log(AventStack.ExtentReports.Status.Info, $"{name} element did not find!");
                //throw;
            }
        }


        public static void SetText(By by, string text)
        {

            try
            {
                var element = Browser.GetDriver().FindElement(by);
                ReportHandler.Log(AventStack.ExtentReports.Status.Info, $"Set text to {element.Text}");
                element.Click();
                element.Clear();
                element.SendKeys(text);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string GetText(By by, string name)
        {
            string elementText = null;
            try
            {
                var element = Browser.GetDriver().FindElement(by);
                ReportHandler.Log(AventStack.ExtentReports.Status.Info, $"Element text: {element.Text}");
                elementText = element.Text;
            }
            catch (Exception)
            {
                ReportHandler.Log(AventStack.ExtentReports.Status.Info, $"{name} element was not found!");
                //Assert.Fail();
            }
            return elementText;
        }

        public static void SetListBoxValue(By by, string value)
        {

            try
            {
                var element = Browser.GetDriver().FindElement(by);
                element.Click();
                //new SelectElement(element).SelectByText(value);

                //ReportHandler.Log(AventStack.ExtentReports.Status.Info, $"Set dropdown value to {element.Text}");

                /*var comboBox = driver.FindElement(By.Name("search[active]"));
                new SelectElement(comboBox).SelectByText("onlyactive");*/

                /*element.Click();
                element.Clear();
                element.SendKeys(text);*/
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void JavaScriptClick(By by)
        {
            var ele = Browser.GetDriver().FindElement(by);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.GetDriver();
            executor.ExecuteScript("arguments[0].click();", ele);
        }
    }
}
