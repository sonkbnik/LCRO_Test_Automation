using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCore.BasicObjects;
using OpenQA.Selenium;

namespace SCore.Pages
{
    public class AddEditDevicePage
    {
        public AddEditDevicePage()
        {
            DeviceName = new Textbox(By.XPath("//label[contains(text(),'Device name')]/..//input"), "DeviceName");
            DeviceTypeDropdown = new Listbox(By.XPath("//*[@formcontrolname='deviceTypeUid']"), "Device Type Dropdown");
            DeviceTypeDropdownValue = new Label(By.XPath("//span[contains(text(),'Ultrasound devices')]"), "Ultrasound devices");
            UnitDropdown = new Listbox(By.XPath("//*[@formcontrolname='units']"), "Unit Dropdown");
            UnitDropdownValue = new Label(By.XPath("//span[contains(text(),'3201Y Surgery outpatient clinic')]"), "3201Y Surgery outpatient clinic");
            UnitLabel = new Label(By.XPath("//label[text()='Units']"), "Unit Label");
            HeaderRow = new Label(By.XPath("//div[@class='headercontent']"), "Header Row");
        }
        public Textbox DeviceName { get; }
        public Listbox DeviceTypeDropdown { get; set; }
        public Label DeviceTypeDropdownValue { get; }
        public Listbox UnitDropdown { get; }
        public Label UnitDropdownValue { get; }
        public Label UnitLabel { get; }
        public Label HeaderRow { get; }

        public void enterDeviceName(string deviceName)
        {
            DeviceName.IsElementClickable();
            DeviceName.SetText(deviceName);
        }

        public void setDeviceType(string deviceValue)
        {
            DeviceTypeDropdown.Click("Device Type");
            while (DeviceTypeDropdownValue.IsElementClickable() == null)
            {
                DeviceTypeDropdown.Click("Device Type");
            }
            DeviceTypeDropdownValue.Click(deviceValue);

        }

        public void setUnit(string unit)
        {
            UnitDropdown.Click("Unit");
            UnitDropdownValue.Click(unit);
            UnitLabel.Click(UnitLabel.Name);
            //HeaderRow.Click("Header Row");
        }

        public void setDeviceTypeToField(string deviceValue, string elementName)
        {
            DeviceTypeDropdown.SetListboxValueToField(deviceValue, elementName);
        }
    }
}
