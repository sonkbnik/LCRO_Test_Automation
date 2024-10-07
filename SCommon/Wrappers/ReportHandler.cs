using System;
using System.Collections.Concurrent;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System.IO;
using System.Threading;
using SCommon.Helpers;


namespace SCommon.Wrappers
{
    public class ReportHandler
    {
        public static ConcurrentDictionary<Thread, ExtentTest> testLoggers;
        public static ExtentReports extent { get; set; }

        public ReportHandler()
        {
            string currentDateTime = DateTime.Now.ToString().Replace(":", "_");
            ExtentSparkReporter spark = new ExtentSparkReporter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "reports", currentDateTime + ".html"));
            //ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "reports", "TestResults.html"));
            spark.Config.DocumentTitle = "Test Report";
            //spark.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extent.AttachReporter(spark);
        }

        static ReportHandler()
        {
            testLoggers = new ConcurrentDictionary<Thread, ExtentTest>();
            extent = new ExtentReports();
        }

        public static ExtentTest CreateTest(string testName)
        {
            ExtentTest testLogger = extent.CreateTest(testName);
            if (!testLoggers.TryAdd(Thread.CurrentThread, testLogger))
            {
                Console.WriteLine($"The logger is the thread {Thread.CurrentThread} not added !");
            }
            ReportHandler.Log(Status.Info, $" exexution of test {testName} started");
            return testLogger;
        }

        public static void Log(Status status, string details)
        {
            ExtentTest selectedLogger;

            if (testLoggers.TryGetValue(Thread.CurrentThread, out selectedLogger))
            {
                selectedLogger.Log(status, details);
            }

        }


        public static void Log(Status status, String details, AventStack.ExtentReports.Model.Media media)
        {
            ExtentTest selectedLogger;

            if (testLoggers.TryGetValue(Thread.CurrentThread, out selectedLogger))
            {
                selectedLogger.Log(status, details, media);
            }
        }

        public static void Capture(string screenShotName)
        {
            screenShotName = screenShotName + (DateTime.Now.ToString().Replace(":", "_"));
            try
            {
                // if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                //{
                string screenShotFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshot", $"{screenShotName}.png");
                ITakesScreenshot ts = (ITakesScreenshot)Browser.GetDriver();
                ts.GetScreenshot().SaveAsFile(screenShotFileName);
                TestContext.AddTestAttachment(screenShotFileName);
                string screenShot = ts.GetScreenshot().AsBase64EncodedString;
                //AventStack.ExtentReports.Model sc = MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenShot, screenShotName).Build();
                //if (sc != null)
                //{
                AventStack.ExtentReports.Status Status = Status.Pass;
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                    Status = Status.Fail;
                Log(Status, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenShot, screenShotName).Build());
                //else ReportHandler.Log(Status.Pass, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenShot, screenShotName).Build());
                //}


                //}
            }
            catch (Exception)
            {

                ReportHandler.Log(Status.Fail, "Screeshot capture failed");
            }
        }

        public void Close()
        {
            extent.Flush();
        }
    }
}
