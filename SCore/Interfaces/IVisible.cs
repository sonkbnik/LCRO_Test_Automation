using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCore.Interfaces
{
    internal interface IVisible
    {
        bool IsDisplayed { get; }
        bool IsNotDisplayed { get; }
    }
}
