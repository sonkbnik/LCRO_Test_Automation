using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCore.Interfaces
{
    internal interface IText
    {
        event EventHandler TextChanged;
        event EventHandler OnSetText;
    }
}
