using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCore.Interfaces
{
    internal interface IClick
    {
        event EventHandler OnClick;
        event EventHandler Clicked;
        void Click();
        void Click(string name);
    }
}
