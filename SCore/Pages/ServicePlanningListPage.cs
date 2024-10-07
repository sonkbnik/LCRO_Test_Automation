using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using SCore.BasicObjects;
using SCommon.Wrappers;

namespace SCore.Pages
{
    public class ServicePlanningListPage
    {
        public ServicePlanningListPage()
        {
            FirstPeriodPlanInListLabel = new Label(By.CssSelector("div.body div[class~='row-click']:first-of-type>div:first-of-type"), "FirstPeriodPlanInList");
            ServicePlanningListPageNoContentLabel = new Label(By.XPath("//p[text()='No content']"), "ServicePlanningListPageNoContentLabel");
        }

        public Label FirstPeriodPlanInListLabel { get; }
        public Label ServicePlanningListPageNoContentLabel { get; }

        public void verifyServicePlanListPageLoading()
        {
            string noContentLabelText = ServicePlanningListPageNoContentLabel.Text;
            string firstPeriodPlanInListLabelText = FirstPeriodPlanInListLabel.Text;

            if (noContentLabelText == null && firstPeriodPlanInListLabelText == null)
            {
                Assert.Fail("Service planning list page did not load correctly");
                ReportHandler.Log(AventStack.ExtentReports.Status.Fail, "Service Planning List Page did not load correctly");
            }
            Assert.Pass("Service planning list page loaded successfully");
            ReportHandler.Log(AventStack.ExtentReports.Status.Pass, "Service Plan List Page loaded successfully");
        }
    }
}
