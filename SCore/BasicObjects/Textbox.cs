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
    public class Textbox : IText, IGetText, ISetText
    {
        private readonly By Locator;
        public readonly String Name;
        public Textbox(By locator, string name)
        {
            this.Locator = locator;
            this.Name = name;
        }

        public string Text => throw new NotImplementedException();

        public event EventHandler OnClick;
        public event EventHandler Clicked;
        public event EventHandler TextChanged;
        public event EventHandler OnSetText;

        public void IsElementClickable()
        {
            ExpectedCondition.IsElementClickable(Locator);
        }
        public void AddText(string text)
        {
            throw new NotImplementedException();
        }

        public void Click()
        {
            throw new NotImplementedException();
        }
        public void Click(string name)
        {
            DriverActions.Click(Locator, name);
        }

        public void RemoveText()
        {
            throw new NotImplementedException();
        }

        public void SetText(string text)
        {
            OnSetText?.Invoke(this, EventArgs.Empty);
            DriverActions.SetText(Locator, text);
        }
    }
}
