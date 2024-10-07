using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCore.BasicObjects;
using OpenQA.Selenium;

namespace SCore.Pages
{
    public class EmployeeListPage
    {
        private Label SystemDropdownIdentifierValue;

        public EmployeeListPage()
        {
            FirstEmployeeInListLabel = new Label(By.CssSelector("div.body div[class~='row-click']:first-of-type>div:first-of-type"), "FirstEmployeeInListLabel");
            EmployeeListPageNoContentLabel = new Label(By.XPath("//p[text()='No content']"), "EmployeeListPageNoContentLabel");
            AddIdentifierButton = new Button(By.XPath("//button[contains(text(),'Add identifier')]"), "AddIdentifierButton");
            SystemDropdown = new Textbox(By.XPath("(//thm-dropdown[@formcontrolname='systemname']//input)[last()]"), "SystemDropdown");
            IdentifierInput = new Textbox(By.XPath("(//thm-input[@formcontrolname='externalid']//input)[last()]"), "IdentifierInputField");
            EmployeeSaveButton = new Button(By.XPath("//thm-button//button[contains(text(),'Save')]"), "EmployeeSaveButton");
        }

        public Label FirstEmployeeInListLabel { get; }
        public Label EmployeeListPageNoContentLabel { get; }
        public Button AddIdentifierButton { get; }
        public Textbox SystemDropdown { get; }
        public Textbox IdentifierInput { get; }
        public Button EmployeeSaveButton { get; }

        public void openEmployeeForEditing()
        {
            FirstEmployeeInListLabel.Click(FirstEmployeeInListLabel.Name);
        }

        public void updateEmployee(string identifier, string identifiervalue)
        {
            AddIdentifierButton.Click(AddIdentifierButton.Name);
            Thread.Sleep(2000);
            SystemDropdown.Click(SystemDropdown.Name);

            string systemIdentifierLocatorValue = new Element().getLocatorValue("//*[@id='dropdown-popper']//thm-row-select//li//p[contains(text(),'REPLACE_VALUE')]", identifier);
            SystemDropdownIdentifierValue = new Label(By.XPath(systemIdentifierLocatorValue), "SystemDropdownIdentifierValue_" + identifier);
            SystemDropdownIdentifierValue.Click(SystemDropdownIdentifierValue.Name);

            IdentifierInput.SetText(identifiervalue);

            EmployeeSaveButton.Click(EmployeeSaveButton.Name);
        }
    }
}
