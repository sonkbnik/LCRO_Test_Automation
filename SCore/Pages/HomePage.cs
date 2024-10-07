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
    public class HomePage : BasePage
    {
        private Label MenuItem;

        public HomePage()
        {
            LanguageDropdown = new Textbox(By.XPath("//div[@class='language']//input"), "LanguageDropdown");
            EnglishLanguage = new Label(By.XPath("//*[@id='dropdown-popper']//li//p[contains(text(),'Englanti') or contains(text(),'English')]"), "EnglishLanguage");
            MenuArrow = new Label(By.XPath("//app-leftsidenav//button//*[contains(@class,'right')]"), "Menu Arrow");
            ServiceMenuIcon = new Label(By.XPath("//app-icon-menu-item//a[contains(@href,'/services')]"), "ServiceMenuIcon");
            ResourceMenu = new Label(By.XPath("//span[contains(text(), 'Resource')]//preceding-sibling::span"), "Resource Menu");
            DeviceMenu = new Button(By.XPath("//span[text()='Devices']"), "Device Menu");
            HumanResourcesMenu = new Label(By.XPath("//span[text()='Employees']"), "Human Resources Menu");
            //div[@apptextmenuitem]//span[contains(text(),'Employees')]
            HomePageNoContentLabel = new Label(By.XPath("//p[text()='No content']"), "HomePageNoContentLabel");
            HomePageFirstRecordLabel = new Label(By.CssSelector("div.body div[class~='row']:first-of-type>div:first-of-type"), "HomePageFirstRecordLabel");
        }

        public Textbox LanguageDropdown { get; }
        public Label EnglishLanguage { get; }
        public Label MenuArrow { get; }
        public Label ServiceMenuIcon { get; }
        public Label ResourceMenu { get; }
        public Button DeviceMenu { get; }
        public Label HumanResourcesMenu { get; }
        public Label HomePageNoContentLabel { get; }
        public Label HomePageFirstRecordLabel { get; }

        public void ClickMenuArrow()
        {
            MenuArrow.Click(MenuArrow.Name);
        }
        public void ClickResourceMenu()
        {
            ResourceMenu.Click(ResourceMenu.Name);
        }

        public void expandLeftMenu()
        {
            MenuArrow.Click(MenuArrow.Name);
        }

        public ServiceListPage ClickServiceMenuIcon()
        {
            ServiceMenuIcon.Click(ServiceMenuIcon.Name);
            ServiceListPage servicelistPage = new ServiceListPage(); ;
            return servicelistPage;
        }

        public Object clickMenu(String menuName)
        {
            Object page;
            string locatorValue = new Element().getLocatorValue("//div[@apptextmenuitem]//span[contains(text(),'REPLACE_VALUE')]", menuName);
            MenuItem = new Label(By.XPath(locatorValue), "MenuItem_" + menuName);
            MenuItem.Click(MenuItem.Name);
            switch (menuName)
            {
                case "Services":
                    page = new ServiceListPage(); break;
                case "Service planning":
                    page = new ServicePlanningListPage(); break;
                case "Facilities":
                    page = new FacilitiesListPage(); break;
                case "Employees":
                    page = new EmployeeListPage(); break;
                case "Availability information":
                    page = new AvailabilityInformationPage(); break;
                case "Resource definitions":
                    page = new ResourceDefinitions(); break;
                default:
                    Console.WriteLine("In DEFAULT block");
                    page = null; break;
            }
            return page;
            //if (menuName == "Service")
            //return new ServiceListPage();
            //else 
            //    return new HomePage();
        }

        public DeviceLandingPage ClickDeviceMenu()
        {
            DeviceMenu.Click(DeviceMenu.Name);
            DeviceLandingPage devicePage = new DeviceLandingPage(); ;
            return devicePage;
        }

        public EmployeeListPage ClickHumanResourcesMenu()
        {
            HumanResourcesMenu.Click(HumanResourcesMenu.Name);
            EmployeeListPage humanResourcesPage = new EmployeeListPage(); ;
            return humanResourcesPage;
        }

        public void setLanguage(string language)
        {
            LanguageDropdown.Click(LanguageDropdown.Name);
            if (language.Equals("English") || language.Equals("Englanti"))
                EnglishLanguage.Click(EnglishLanguage.Name);
        }

        public void verifyHomepageLoading()
        {
            string labelText = HomePageNoContentLabel.Text;
            string empLabelText = HomePageFirstRecordLabel.Text;

            if (labelText == null && empLabelText == null)
            {
                Assert.Fail("Homepage did not load correctly");
                ReportHandler.Log(AventStack.ExtentReports.Status.Fail, "Homepage did not correctly");
            }
            Assert.Pass("Homepage loaded successfully");
            ReportHandler.Log(AventStack.ExtentReports.Status.Pass, "Homepage loaded successfully");
        }
    }
}
