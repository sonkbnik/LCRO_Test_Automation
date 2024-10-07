using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCore.BasicObjects;
using OpenQA.Selenium;
using NUnit.Framework;
using SCommon.Wrappers;

namespace SCore.Pages
{
    public class AvailabilityInformationPage
    {
        private Label UnitsDropdownValue;

        public AvailabilityInformationPage()
        {
            FirstAvailabilityInListLabel = new Label(By.CssSelector("div.body div[class~='row']:first-of-type>div:first-of-type"), "FirstAvailabilityInListLabel");
            AvailabilityListPageNoContentLabel = new Label(By.XPath("//p[text()='No content']"), "AvailabilityListPageNoContentLabel");
            UnitsDropdown = new Label(By.XPath("//div[@class='unit']/thm-dropdown//input"), "UnitDropdown");

            AddAvailabilityIcon = new Button(By.XPath("(//button//*[contains(@class,'pm-icon-add-alternative')])[1]"), "AddAvailabilityIcon");
            StartTime = new Textbox(By.XPath("//thm-timepicker[@formcontrolname='startTime']"), "StartTime");
            EndTime = new Textbox(By.XPath("//thm-timepicker[@formcontrolname='endTime']"), "EndTime");
            HourTime = new Textbox(By.XPath("//input[@id='hour']"), "HourTime");
            MinuteTime = new Textbox(By.XPath("//input[@id='minute']"), "MinuteTime");
            OkButton = new Button(By.XPath("//thm-common-picker-dropdown//button[contains(text(),'Ok')]"), "OkButton");
            SaveAvailabilityButton = new Button(By.XPath("//thm-button//button[contains(text(),'Save')]"), "ServiceSaveButton");
            ExistingAvailabilityChip = new Label(By.XPath("(//div//span[@class='cell availability-marker'])[last()]"), "ExistingAvailabilityChip");
        }

        public Label FirstAvailabilityInListLabel { get; }
        public Label AvailabilityListPageNoContentLabel { get; }
        public Label UnitsDropdown { get; }
        public Button AddAvailabilityIcon { get; }
        public Textbox StartTime { get; }
        public Textbox EndTime { get; }
        public Textbox HourTime { get; }
        public Textbox MinuteTime { get; }
        public Button OkButton { get; }
        public Button SaveAvailabilityButton { get; }
        public Label ExistingAvailabilityChip { get; }


        public void verifyAvailabilityInfoPageLoading()
        {
            string noContentLabelText = AvailabilityListPageNoContentLabel.Text;
            string firstAvailabilityInListLabelText = FirstAvailabilityInListLabel.Text;

            if (noContentLabelText == null && firstAvailabilityInListLabelText == null)
            {
                Assert.Fail("Availabiliy info list page did not load correctly");
                ReportHandler.Log(AventStack.ExtentReports.Status.Fail, "Availabiliy info List Page did not load correctly");
            }
            Assert.Pass("Availabiliy info list page loaded successfully");
            ReportHandler.Log(AventStack.ExtentReports.Status.Pass, "Availabiliy info List Page loaded successfully");
        }

        public Boolean verifyEmployeePresent()
        {
            Boolean isPresent = false;
            string noContentLabelText = AvailabilityListPageNoContentLabel.Text;

            if (noContentLabelText == null)
                isPresent = true;
            return isPresent;
        }

        public void selectUnitThatContainsResource()
        {
            Boolean isPresent = verifyEmployeePresent();

            if (!isPresent)
            {

                int i = 2;
                while (i < 6)
                {
                    UnitsDropdown.Click(UnitsDropdown.Name);

                    string unitLocatorValue = "(//*[@id='dropdown-popper']//li)[" + i + "]";
                    UnitsDropdownValue = new Label(By.XPath(unitLocatorValue), "UnitsDropdownValue_" + i.ToString());
                    UnitsDropdownValue.Click(UnitsDropdownValue.Name);
                    Thread.Sleep(5000);
                    Boolean isPresent1 = verifyEmployeePresent();
                    if (isPresent1)
                    {
                        break;
                    }
                    i++;
                }
            }
        }

        public void openAvailabilityDetailsDialog()
        {
            AddAvailabilityIcon.Click(AddAvailabilityIcon.Name);

        }

        public void createAvailability(string starttime, string endtime)
        {
            StartTime.Click(StartTime.Name);
            HourTime.SetText(starttime);
            MinuteTime.SetText("30");
            OkButton.Click(OkButton.Name);

            EndTime.Click(EndTime.Name);
            HourTime.SetText(endtime);
            MinuteTime.SetText("30");
            OkButton.Click(OkButton.Name);

            SaveAvailabilityButton.Click(SaveAvailabilityButton.Name);
        }

        public void updateCreatedAvailability(string starttime, string endtime)
        {
            ExistingAvailabilityChip.Click(ExistingAvailabilityChip.Name);
            StartTime.Click(StartTime.Name);
            HourTime.SetText(starttime);
            MinuteTime.SetText("00");
            OkButton.Click(OkButton.Name);

            EndTime.Click(EndTime.Name);
            HourTime.SetText(endtime);
            MinuteTime.SetText("00");
            OkButton.Click(OkButton.Name);

            SaveAvailabilityButton.Click(SaveAvailabilityButton.Name);
        }
    }
}
