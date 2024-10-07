using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCore.Pages;

namespace SCore
{
    public class CoreBase : IDisposable
    {
        public CoreBase()
        {
            Login = new LoginPage();
        }

        public LoginPage Login { get; }

        public void Dispose()
        {
            try
            {
                //Browser.Quit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
