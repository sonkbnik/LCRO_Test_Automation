using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCore.Interfaces
{
    internal interface ISetText : IText
    {
        void SetText(string text);
        void AddText(string text);
        void RemoveText();
    }
}
