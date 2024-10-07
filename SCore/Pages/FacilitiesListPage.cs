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
    public class FacilitiesListPage
    {
        private Label FacilityTypeDropdownValue;
        private Label UnitsDropdownValue;
        private Label FacilityLabel;

        public FacilitiesListPage()
        {
            FirstFacilityInListLabel = new Label(By.CssSelector("div.body div[class~='row-click']:first-of-type>div:first-of-type"), "FirstFacilityInListLabel");
            FacilitiesListPageNoContentLabel = new Label(By.XPath("//p[text()='No content']"), "FacilitiesListPageNoContentLabel");
            AddFacilityButton = new Button(By.XPath("//button[contains(text(),'Add facility')]"), "AddFacilityButton");
            FacilityNameInput = new Textbox(By.XPath("//thm-input[@formcontrolname='facilityName']//input"), "FacilityNameInput");
            FacilityTypeDropdown = new Textbox(By.XPath("//thm-dropdown[@formcontrolname='facilityType']//input"), "SpecialtyDropdown");
            //FacilityTypeDropdownValue = new Label(By.XPath("//*[@id='dropdown-popper']//thm-row-select//li//p[contains(text(),'Ortopedia, työpiste')]"), "FacilityTypeDropdownValue");
            PhoneNumberInput = new Textbox(By.XPath("//thm-input[@formcontrolname='phoneNumber']//input"), "PhoneNumberInput");
            UnitsDropdown = new Textbox(By.XPath("//thm-multiselect[@formcontrolname='units']//input"), "UnitsDropdown");
            //UnitsDropdownValue = new Label(By.XPath("//*[@id='dropdown-popper']//li//p/span[contains(text(),'00000')]"), "UnitsDropdownValue");
            FacilitySaveButton = new Button(By.XPath("//thm-button//button[contains(text(),'Save')]"), "FacilitySaveButton");
            AllTabFacilityTypeDropdown = new Label(By.XPath("//*[@id='dropdown-popper']//span[contains(text(),'All')]"), "AllTabFacilityTypeDropdown");

        }


        public Label FirstFacilityInListLabel { get; }
        public Label FacilitiesListPageNoContentLabel { get; }
        public Button AddFacilityButton { get; }
        public Textbox FacilityNameInput { get; }
        public Textbox FacilityTypeDropdown { get; }
        public Textbox PhoneNumberInput { get; }
        public Textbox UnitsDropdown { get; }
        public Button FacilitySaveButton { get; }
        public Label AllTabFacilityTypeDropdown { get; }



        public void ClickAddFacilityButton()
        {
            AddFacilityButton.Click(AddFacilityButton.Name);
        }

        public void verifyFacilitiesListPageLoading()
        {
            string noContentLabelText = FacilitiesListPageNoContentLabel.Text;
            string firstFacilityInListLabelText = FirstFacilityInListLabel.Text;

            if (noContentLabelText == null && firstFacilityInListLabelText == null)
            {
                Assert.Fail("Facilities list page did not load correctly");
                ReportHandler.Log(AventStack.ExtentReports.Status.Fail, "Facilities List Page did not load correctly");
            }
            Assert.Pass("Facilities list page loaded successfully");
            ReportHandler.Log(AventStack.ExtentReports.Status.Pass, "Facilities List Page loaded successfully");
        }

        public string createFacility(string facilityname, string facilitytype, string phonenumber, string unit)
        {
            FacilityNameInput.SetText(facilityname);

            FacilityTypeDropdown.Click(FacilityTypeDropdown.Name);
            AllTabFacilityTypeDropdown.Click(AllTabFacilityTypeDropdown.Name);
            string facilityTypeLocatorValue = new Element().getLocatorValue("//*[@id='dropdown-popper']//thm-row-select//li//p[contains(text(),'REPLACE_VALUE')]", facilitytype);
            FacilityTypeDropdownValue = new Label(By.XPath(facilityTypeLocatorValue), "FacilityTypeDropdownValue_" + facilitytype);
            FacilityTypeDropdownValue.Click(FacilityTypeDropdownValue.Name);

            PhoneNumberInput.SetText(phonenumber);

            UnitsDropdown.Click(UnitsDropdown.Name);

            string unitLocatorValue = new Element().getLocatorValue("//*[@id='dropdown-popper']//li//p/span[contains(text(),'REPLACE_VALUE')]", unit);
            UnitsDropdownValue = new Label(By.XPath(unitLocatorValue), "UnitsDropdownValue_" + unit);
            UnitsDropdownValue.Click(UnitsDropdownValue.Name);
            UnitsDropdown.Click(UnitsDropdown.Name); //To close the multiselect dropdown.
            FacilitySaveButton.Click(FacilitySaveButton.Name);
            return facilityname;
        }


        public void openFacilityForEditing(string facilityName)
        {

            string locatorValue = new Element().getLocatorValue("//div[@class='body']//div[contains(text(),'REPLACE_VALUE')]", facilityName);
            FacilityLabel = new Label(By.XPath(locatorValue), "ServiceLabel_" + facilityName);
            FacilityLabel.Click(FacilityLabel.Name);
        }

        public void updateFacility(string newfacilityname, string newfacilitytype, string phonenumber, string unit)
        {
            FacilityNameInput.SetText(newfacilityname);

            FacilityTypeDropdown.Click(FacilityTypeDropdown.Name);
            AllTabFacilityTypeDropdown.Click(AllTabFacilityTypeDropdown.Name);
            string facilityTypeLocatorValue = new Element().getLocatorValue("//*[@id='dropdown-popper']//thm-row-select//li//p[contains(text(),'REPLACE_VALUE')]", newfacilitytype);
            FacilityTypeDropdownValue = new Label(By.XPath(facilityTypeLocatorValue), "FacilityTypeDropdownValue_" + newfacilitytype);
            FacilityTypeDropdownValue.Click(FacilityTypeDropdownValue.Name);

            PhoneNumberInput.SetText(phonenumber);

            UnitsDropdown.Click(UnitsDropdown.Name);

            string unitLocatorValue = new Element().getLocatorValue("//*[@id='dropdown-popper']//li//p/span[contains(text(),'REPLACE_VALUE')]", unit);
            UnitsDropdownValue = new Label(By.XPath(unitLocatorValue), "UnitsDropdownValue_" + unit);
            UnitsDropdownValue.Click(UnitsDropdownValue.Name);
            UnitsDropdown.Click(UnitsDropdown.Name); //To close the multiselect dropdown.
            FacilitySaveButton.Click(FacilitySaveButton.Name);

        }

    }
}
