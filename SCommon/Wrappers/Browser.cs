using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager.DriverConfigs.Impl;



namespace SCommon.Wrappers
{
    public class Browser
    {
        static ConcurrentDictionary<Thread, IWebDriver> drivers = new ConcurrentDictionary<Thread, IWebDriver>();


        public static IWebDriver CreateDriver()
        {
            IWebDriver driver = null;
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            //driver = new ChromeDriver();
            var options = new EdgeOptions();
            options.AddArgument("--ignore-ssl-errors=yes");
            options.AddArgument("--ignore-certificate-errors");
            //options.AddArgument("--allow-insecure-localhost");
            try
            {
                driver = new EdgeDriver(options);
            }
            catch (Exception e)
            {
                Console.WriteLine("InnerException:"+e.InnerException);
                Console.WriteLine("Message:" + e.Message);
                
            }
            
            driver.Manage().Window.Maximize();

            if (!drivers.TryAdd(Thread.CurrentThread, driver))
            {
                Console.WriteLine("Driver is not added!!!");
            }
            return driver;

        }

        public static void Quit()
        {
            GetDriver().Close();
            //GetDriver().Quit();
            if (!drivers.TryRemove(Thread.CurrentThread, out _))
            {
                Console.WriteLine("Could not remove driver!!!");
            }
        }

        public static IWebDriver GetDriver()
        {

            IWebDriver selectedDriver;
            if (drivers.TryGetValue(Thread.CurrentThread, out selectedDriver))
            {
                return selectedDriver;
            }
            else
            {
                throw new Exception("Driver did not found!!!");
            }

        }

        public static void Navigate(string url)
        {
            GetDriver().Navigate().GoToUrl(url);
        }
    }
}
