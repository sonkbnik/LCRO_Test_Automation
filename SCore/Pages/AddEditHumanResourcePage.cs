using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCore.BasicObjects;
using OpenQA.Selenium;

namespace SCore.Pages
{
    public class AddEditHumanResourcePage
    {
        public AddEditHumanResourcePage()
        {
            FirstName = new Textbox(By.XPath("//label[contains(text(),'First name')]/..//input"), "FirstName");
            LastName = new Textbox(By.XPath("//label[contains(text(),'Last name')]/..//input"), "LastName");
            NaturalName = new Textbox(By.XPath("//label[contains(text(),'Natural name')]/..//input"), "NaturalName");
            SpecialityRolesDropdown = new Listbox(By.XPath("//*[@formcontrolname='specialityRoles']"), "Speciality Role Dropdown");
            SpecialityRolesDropdownValue = new Label(By.XPath("//span[contains(text(),'25 Neurosurgery')]"), "25 Neurosurgery");
            SpecialityRolesLabel = new Label(By.XPath("//label[text()='Speciality roles']"), "Speciality Role Label");
            UnitDropdown = new Listbox(By.XPath("//*[@formcontrolname='units']"), "Unit Dropdown");
            UnitDropdownValue = new Label(By.XPath("//span[contains(text(),'3201Y Surgery outpatient clinic')]"), "3201Y Surgery outpatient clinic");
            HeaderRow = new Label(By.XPath("//div[@class='headercontent']"), "Header Row");

        }
        public Textbox FirstName { get; }
        public Textbox LastName { get; }
        public Textbox NaturalName { get; }
        public Listbox SpecialityRolesDropdown { get; set; }
        public Label SpecialityRolesDropdownValue { get; set; }
        public Label SpecialityRolesLabel { get; }
        public Listbox UnitDropdown { get; }
        public Label UnitDropdownValue { get; }
        public Label HeaderRow { get; }


        public void enterFirstName(string deviceName)
        {
            FirstName.IsElementClickable();
            FirstName.SetText(deviceName);
        }

        public void enterLastName(string deviceName)
        {
            LastName.SetText(deviceName);
        }

        public void enterNaturalName(string deviceName)
        {
            NaturalName.IsElementClickable();
            try
            {
                NaturalName.SetText(deviceName);
            }
            catch (Exception e)
            {
                NaturalName.IsElementClickable();
            }
        }

        public void setUnit(string unit)
        {
            UnitDropdown.Click(UnitDropdown.Name);
            UnitDropdownValue.Click(unit);
            HeaderRow.Click("Header Row");
        }

        public void setSpecialityRole(string unit)
        {
            SpecialityRolesDropdown.Click("Unit");
            while (SpecialityRolesDropdownValue.IsElementClickable() == null)
            {
                SpecialityRolesDropdown.JavaScriptClick();
            }
            SpecialityRolesDropdownValue.Click(unit);
            SpecialityRolesLabel.Click(SpecialityRolesLabel.Name);
            //HeaderRow.Click("Header Row");
        }

    }
}
