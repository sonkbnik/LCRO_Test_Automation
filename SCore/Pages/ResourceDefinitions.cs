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
    public class ResourceDefinitions
    {
        private Label SpecialityRoleLabel;

        public ResourceDefinitions()
        {
            SpecialityRolesTab = new Label(By.XPath("//div[@class='tab-text'][contains(text(),'Speciality roles')]"), "SpecialityRolesTab");
            FacilityTypesTab = new Label(By.XPath("//div[@class='tab-text'][contains(text(),'Facility types')]"), "FacilityTypesTab");
            FirstSpecialityRoleLabel = new Label(By.CssSelector("div.body div[class~='row']:first-of-type>div:first-of-type"), "FirstSpecialityRoleLabel");
            TabListNoContentLabel = new Label(By.XPath("//p[text()='No content']"), "TabListNoContentLabel");
            FirstFacilityTypeLabel = new Label(By.CssSelector("div.body div[class~='row']:first-of-type>div:first-of-type"), "FirstFacilityTypeLabel");
            AddSpecialityRoleButton = new Button(By.XPath("//button[contains(text(),'Add speciality role')]"), "AddSpecialityRoleButton");
            SpecialityRoleNameInput = new Textbox(By.XPath("//thm-input[@formcontrolname='name']//input"), "SpecialityRoleNameInput");
            RoleTypeDropdown = new Textbox(By.XPath("//thm-dropdown[@formcontrolname='roleType']//input"), "RoleTypeDropdown");
            RoleTypeValue = new Label(By.XPath("//*[@id='dropdown-popper']//thm-row-select//li//p[contains(text(),'Doctor')]"), "RoleTypeValue");
            SpecialityRoleSaveButton = new Button(By.XPath("//thm-button//button[contains(text(),'Save')]"), "SpecialityRoleSaveButton");
        }

        public Label SpecialityRolesTab { get; }
        public Label FacilityTypesTab { get; }
        public Label FirstSpecialityRoleLabel { get; }
        public Label TabListNoContentLabel { get; }
        public Label FirstFacilityTypeLabel { get; }
        public Button AddSpecialityRoleButton { get; }
        public Textbox SpecialityRoleNameInput { get; }
        public Textbox RoleTypeDropdown { get; }
        public Label RoleTypeValue { get; }
        public Button SpecialityRoleSaveButton { get; }


        public void openSpecialityRolesTab()
        {
            SpecialityRolesTab.Click(SpecialityRolesTab.Name);
        }

        public void openFacilityTypesTab()
        {
            FacilityTypesTab.Click(FacilityTypesTab.Name);
        }

        public void ClickAddSpecialityRoleButton()
        {
            AddSpecialityRoleButton.Click(AddSpecialityRoleButton.Name);
        }

        public void verifySpecialityRolesTabLoaded()
        {
            string noContentLabelText = TabListNoContentLabel.Text;
            string firstSpecialityRoleInListLabelText = FirstSpecialityRoleLabel.Text;

            if (noContentLabelText == null && firstSpecialityRoleInListLabelText == null)
            {
                Assert.Fail("Sepciality Roles list page did not load correctly");
                ReportHandler.Log(AventStack.ExtentReports.Status.Fail, "Sepciality Roles List Page did not load correctly");
            }
            Assert.Pass("Sepciality Roles list page loaded successfully");
            ReportHandler.Log(AventStack.ExtentReports.Status.Pass, "Sepciality Roles List Page loaded successfully");
        }

        public string createSpecialityRole(string specialityRoleName, string roleType)
        {
            SpecialityRoleNameInput.SetText(specialityRoleName);
            RoleTypeDropdown.Click(RoleTypeDropdown.Name);
            RoleTypeValue.Click(RoleTypeValue.Name);
            SpecialityRoleSaveButton.Click(SpecialityRoleSaveButton.Name);
            return specialityRoleName;

        }

        public void openSpecialityRoleForEditing(string specialityRoleName)
        {
            string locatorValue = new Element().getLocatorValue("//div[@class='body']//div[contains(text(),'REPLACE_VALUE')]", specialityRoleName);
            SpecialityRoleLabel = new Label(By.XPath(locatorValue), "SpecialityRoleLabel_" + specialityRoleName);
            SpecialityRoleLabel.Click(SpecialityRoleLabel.Name);
        }


        public void updateSpecialityRole(string specialityRoleName, string roleType)
        {
            SpecialityRoleNameInput.SetText(specialityRoleName);
            RoleTypeDropdown.Click(RoleTypeDropdown.Name);
            RoleTypeValue.Click(RoleTypeValue.Name);
            SpecialityRoleSaveButton.Click(SpecialityRoleSaveButton.Name);

        }
    }
}
