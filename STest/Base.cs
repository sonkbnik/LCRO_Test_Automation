using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SCore;
using SCommon.Wrappers;

namespace STest
{
    public class Base
    {
        internal CoreBase CoreBase;

        [SetUp]
        public void StartTest()
        {
            Console.WriteLine("Start");
            ReportHandler.CreateTest(TestContext.CurrentContext.Test.Name);
            CoreBase = new CoreBase();

        }

        [TearDown]
        public void EndTest()
        {
            ReportHandler.Capture(TestContext.CurrentContext.Test.Name);
            //if (TestContext.CurrentContext.Result.Equals(false)) 
            //{
            //    Assert.Fail();
            //}
            if (TestContext.CurrentContext.Result.FailCount > 0)
            {
                ReportHandler.Log(AventStack.ExtentReports.Status.Fail, $"Test failed {TestContext.CurrentContext.Test.Name} ");
            }
            //OrangeHRM?.Dispose();
            CoreBase = null;
            Browser.Quit();
        }
    }
}
