using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SCore.Interfaces;
using SCommon.Helpers;

namespace SCore.BasicObjects
{
    public class Button : IClick, IGetText, IVisible
    {
        private readonly By Locator;
        public readonly String Name;

        public Button(By locator, string name)
        {
            this.Locator = locator;
            this.Name = name;
        }

        public string Text => throw new NotImplementedException();

        public bool IsDisplayed => throw new NotImplementedException();

        public bool IsNotDisplayed => throw new NotImplementedException();

        public event EventHandler OnClick;
        public event EventHandler Clicked;

        public void Click(string name)
        {
            DriverActions.Click(Locator, name);
        }

        public void IsElementClickable()
        {
            ExpectedCondition.IsElementClickable(Locator);
        }
        public void Click()
        {
            throw new NotImplementedException();
        }


    }
}
