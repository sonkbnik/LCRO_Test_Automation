using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCore.BasicObjects;
using OpenQA.Selenium;
using SCommon.Helpers;
using NUnit.Framework;
using SCommon.Wrappers;

namespace SCore.Pages
{
    public class ServiceListPage : BasePage
    {
        private Label ServiceLabel;
        private Label ServicePriorityDropdownValue;
        private Label ResourceTypeFacility;
        private Label ResourceFacilityValue;
        private Label SystemDropdownValue;

        public ServiceListPage()
        {
            AddServiceButton = new Button(By.XPath("//button[contains(text(),' Add service')]"), "AddServiceButton");
            SpecialtyDropdown = new Textbox(By.XPath("//thm-dropdown[@formcontrolname='specialty']//input"), "SpecialtyDropdown");
            SpecialtyDropdownValue = new Label(By.XPath("//*[@id='dropdown-popper']//thm-row-select//li//p[contains(text(),'10R Reumatologia')]"), "SpecialtyDropdownValue");
            ServiceNameInput = new Textbox(By.XPath("//thm-input[@formcontrolname='serviceName']//input"), "ServiceNameInput");
            StartTime = new Textbox(By.XPath("//thm-timepicker[@formcontrolname='startTime']"), "StartTime");
            EndTime = new Textbox(By.XPath("//thm-timepicker[@formcontrolname='endTime']"), "EndTime");
            HourTime = new Textbox(By.XPath("//input[@id='hour']"), "HourTime");
            MinuteTime = new Textbox(By.XPath("//input[@id='minute']"), "MinuteTime");
            OkButton = new Button(By.XPath("//thm-common-picker-dropdown//button[contains(text(),'Ok')]"), "OkButton");
            ServiceClassificationDropdown = new Textbox(By.XPath("//thm-dropdown[@formcontrolname='classification']"), "ServiceClassificationDropdown");
            ClassificationDoctorDropdownValue = new Label(By.XPath("//*[@id='dropdown-popper']//li//p[contains(text(),'Doctor')]"), "ClassificationDoctorDropdownValue");
            AddResourceButton = new Button(By.XPath("//button[contains(text(),' Add resource')]"), "AddResourceButton");
            ResourceTypeDropdown = new Textbox(By.XPath("(//thm-dropdown[@formcontrolname='resourcetype']//input)[last()]"), "ResourceTypeDropdown");
            ResourceTypeEmployee = new Label(By.XPath("//*[@id='dropdown-popper']//li//p[contains(text(),'Employee')]"), "ResourceTypeEmployee");
            ResourceDropdown = new Textbox(By.XPath("(//thm-dropdown[@formcontrolname='resource']//input)[last()]"), "ResourceDropdown");
            ResourceValue = new Label(By.XPath("//*[@id='dropdown-popper']//li//p[contains(text(),'Fysioterapeutti')]"), "ResourceValue");
            ServiceSaveButton = new Button(By.XPath("//thm-button//button[contains(text(),'Save')]"), "ServiceSaveButton");
            ServiceListPageNoContentLabel = new Label(By.XPath("//p[text()='No content']"), "ServiceListPageNoContentLabel");
            FirstServiceInListLabel = new Label(By.CssSelector("div.body div[class~='row-click']:first-of-type>div:first-of-type"), "FirstServiceInListLabel");
            ServicePriorityDropdown = new Textbox(By.XPath("//thm-dropdown[@formcontrolname='allocationPriority']"), "ServicePriorityDropdown");
            //ServicePriorityDropdownValue = new Label(By.XPath("//*[@id='dropdown-popper']//li//p[contains(text(),'High')]"), "ServicePriorityDropdownValue");
            ResourceTypeDropdownForFacility = new Textbox(By.XPath("(//thm-dropdown[@formcontrolname='resourcetype']//input)[last()]"), "ResourceDropdownForFacility");
            //ResourceTypeFacility = new Label(By.XPath("//*[@id='dropdown-popper']//li//p[contains(text(),'Facility')]"), "ResourceDropdownForFacilityVal");
            ResourceDropdownFacility = new Textbox(By.XPath("(//thm-dropdown[@formcontrolname='resource']//input)[last()]"), "ResourceDropdownFacility");
            //ResourceFacilityValue = new Label(By.XPath("//*[@id='dropdown-popper']//li//p[contains(text(),'Ortopedi')]"), "ResourceFacilityValue");
            ReservationBookTab = new Label(By.XPath("//div[contains(text(),'Reservation book')]"), "ReservationBookTab");
            AddIdentifierButton = new Button(By.XPath("//button[contains(text(),'Add identifier')]"), "AddIdentifierButton");
            SystemDropdown = new Textbox(By.XPath("(//thm-dropdown[@formcontrolname='systemname']//input)[last()]"), "SystemIdentifierDropdown");
            //SystemDropdownValue = new Label(By.XPath("//*[@id='dropdown-popper']//li//p[contains(text(),'Lifecare')]"), "SystemDropdownValue");
            IdentifierInput = new Textbox(By.XPath("(//thm-input[@formcontrolname='externalid']//input)[last()]"), "IdentifierInputField");
            AllTabResourceValueDropdown = new Label(By.XPath("//*[@id='dropdown-popper']//span[contains(text(),'All')]"), "AllTabResourceValueDropdown");

        }

        public Button AddServiceButton { get; }
        public Textbox SpecialtyDropdown { get; }
        public Label SpecialtyDropdownValue { get; }
        public Textbox ServiceNameInput { get; }
        public Textbox StartTime { get; }
        public Textbox EndTime { get; }
        public Textbox HourTime { get; }
        public Textbox MinuteTime { get; }
        public Button OkButton { get; }
        public Textbox ServiceClassificationDropdown { get; }
        public Label ClassificationDoctorDropdownValue { get; }
        public Button AddResourceButton { get; }
        public Textbox ResourceTypeDropdown { get; }
        public Textbox ResourceDropdown { get; }
        public Label ResourceValue { get; }
        public Button ServiceSaveButton { get; }
        public Label ServiceListPageNoContentLabel { get; }
        public Label FirstServiceInListLabel { get; }
        public Label ResourceTypeEmployee { get; }
        public Textbox ServicePriorityDropdown { get; }
        //public Label ServicePriorityDropdownValue { get; }
        public Textbox ResourceTypeDropdownForFacility { get; }
        //public Label ResourceTypeFacility { get; }
        public Textbox ResourceDropdownFacility { get; }
        public Label ReservationBookTab { get; }
        public Button AddIdentifierButton { get; }
        public Textbox SystemDropdown { get; }
        public Textbox IdentifierInput { get; }
        public Label AllTabResourceValueDropdown { get; }

        public void ClickAddServiceButton()
        {
            AddServiceButton.Click(AddServiceButton.Name);
        }

        public string createService(string specialty, string servicename, string starttime, string endtime, string serviceclassification, string resourcetype, string resource, int amount)
        {
            SpecialtyDropdown.Click(SpecialtyDropdown.Name);
            SpecialtyDropdownValue.Click(SpecialtyDropdownValue.Name);
            ServiceNameInput.SetText(servicename);
            StartTime.Click(StartTime.Name);
            //HourTime.Click(HourTime.Name);
            HourTime.SetText(starttime);
            MinuteTime.SetText("30");
            OkButton.Click(OkButton.Name);


            EndTime.Click(EndTime.Name);
            //HourTime.Click(HourTime.Name);
            HourTime.SetText(endtime);
            MinuteTime.SetText("30");
            OkButton.Click(OkButton.Name);

            ServiceClassificationDropdown.Click(ServiceClassificationDropdown.Name);
            ClassificationDoctorDropdownValue.Click(ClassificationDoctorDropdownValue.Name);
            AddResourceButton.Click(AddResourceButton.Name);
            ResourceTypeDropdown.Click(ResourceTypeDropdown.Name);
            ResourceTypeEmployee.Click(ResourceTypeEmployee.Name);
            ResourceDropdown.Click(ResourceDropdown.Name);
            AllTabResourceValueDropdown.Click(AllTabResourceValueDropdown.Name);
            ResourceValue.Click(ResourceValue.Name);
            ServiceSaveButton.Click(ServiceSaveButton.Name);
            return servicename;

        }

        public void updateService(string servicename, string starttime, string endtime, string servicepriority, string resourcetypefacility, string facilitytype, int amount, string system, string identifiervalue)
        {

            //ServiceNameInput.SetText(servicename);
            StartTime.Click(StartTime.Name);
            //HourTime.Click(HourTime.Name);
            HourTime.SetText(starttime);
            MinuteTime.SetText("00");
            OkButton.Click(OkButton.Name);

            EndTime.Click(EndTime.Name);
            //HourTime.Click(HourTime.Name);
            HourTime.SetText(endtime);
            MinuteTime.SetText("00");
            OkButton.Click(OkButton.Name);

            ServicePriorityDropdown.Click(ServicePriorityDropdown.Name);

            string priorityLocatorValue = new Element().getLocatorValue("//*[@id='dropdown-popper']//li//p[contains(text(),'REPLACE_VALUE')]", servicepriority);
            ServicePriorityDropdownValue = new Label(By.XPath(priorityLocatorValue), "ServicePriorityDropdownValue_" + servicepriority);
            ServicePriorityDropdownValue.Click(ServicePriorityDropdownValue.Name);

            AddResourceButton.Click(AddResourceButton.Name);
            ResourceTypeDropdownForFacility.Click(ResourceTypeDropdownForFacility.Name);

            string resourceTypeLocatorValue = new Element().getLocatorValue("//*[@id='dropdown-popper']//li//p[contains(text(),'REPLACE_VALUE')]", resourcetypefacility);
            ResourceTypeFacility = new Label(By.XPath(resourceTypeLocatorValue), "ResourceTypeFacility_" + resourcetypefacility);
            ResourceTypeFacility.Click(ResourceTypeFacility.Name);

            ResourceDropdownFacility.Click(ResourceDropdownFacility.Name);
            AllTabResourceValueDropdown.Click(AllTabResourceValueDropdown.Name);
            string facilityTypeLocatorValue = new Element().getLocatorValue("//*[@id='dropdown-popper']//li//p[contains(text(),'REPLACE_VALUE')]", facilitytype);
            ResourceFacilityValue = new Label(By.XPath(facilityTypeLocatorValue), "ResourceFacilityValue_" + facilitytype);
            ResourceFacilityValue.Click(ResourceFacilityValue.Name);

            ReservationBookTab.Click(ReservationBookTab.Name);
            AddIdentifierButton.Click(AddIdentifierButton.Name);
            SystemDropdown.Click(SystemDropdown.Name);

            string identifierLocatorValue = new Element().getLocatorValue("//*[@id='dropdown-popper']//li//p[contains(text(),'REPLACE_VALUE')]", system);
            SystemDropdownValue = new Label(By.XPath(identifierLocatorValue), "SystemDropdownValue_" + system);
            SystemDropdownValue.Click(SystemDropdownValue.Name);

            IdentifierInput.SetText(identifiervalue);

            ServiceSaveButton.Click(ServiceSaveButton.Name);
        }


        public void verifyServiceListPageLoading()
        {
            string serviceListPageNoContentLabelText = ServiceListPageNoContentLabel.Text;
            string firstServiceInListLabelText = FirstServiceInListLabel.Text;

            if (serviceListPageNoContentLabelText == null && firstServiceInListLabelText == null)
            {
                Assert.Fail("Service list page did not load correctly");
                ReportHandler.Log(AventStack.ExtentReports.Status.Fail, "Service list page did not correctly");
            }
            Assert.Pass("Service list page loaded successfully");
            ReportHandler.Log(AventStack.ExtentReports.Status.Pass, "Service list page loaded successfully");
        }

        public void openServiceFromListForEditing(string serviceName)
        {

            string locatorValue = new Element().getLocatorValue("//div[@class='body']//div[contains(text(),'REPLACE_VALUE')]", serviceName);
            ServiceLabel = new Label(By.XPath(locatorValue), "ServiceLabel_" + serviceName);
            ServiceLabel.Click(ServiceLabel.Name);
        }

    }
}
