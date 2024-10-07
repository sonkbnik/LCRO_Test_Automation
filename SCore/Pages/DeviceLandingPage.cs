using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCore.BasicObjects;
using OpenQA.Selenium;

namespace SCore.Pages
{
    public class DeviceLandingPage
    {
        public DeviceLandingPage()
        {
            AddNewDeviceButton = new Button(By.XPath("//button[contains(text(), 'Add new')]"), "Add New Device");
        }
        public Button AddNewDeviceButton { get; }
        public AddEditDevicePage ClickAddNewDeviceButton()
        {
            AddNewDeviceButton.IsElementClickable();
            AddNewDeviceButton.Click(AddNewDeviceButton.Name);
            AddEditDevicePage addEditDevicePage = new AddEditDevicePage();
            return addEditDevicePage;
        }
    }
}
