using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCore.BasicObjects;
using OpenQA.Selenium;
using SCommon.Wrappers;

namespace SCore.Pages
{
    public class LoginPage
    {
        public LoginPage()
        {
            UserName = new Textbox(By.XPath("//*[@name='username']"), "UserName");
            PassWord = new Textbox(By.XPath("//*[@name='password']"), "Password");
            LoginButton = new Button(By.XPath("//button[@type='submit']"), "Login Button");
            pmLogo = new Label(By.XPath("//*[@class='title' and text()='Production Management']"), "Production Management");
        }

        public Textbox UserName { get; }
        public Textbox PassWord { get; }
        public Button LoginButton { get; }
        public Label pmLogo { get; }



        public void LaunchAndLogin(string userName)
        {
            Browser.CreateDriver();
            /// <summary>
            ///Browser.Navigate("https://opensource-demo.orangehrmlive.com/");
            Browser.Navigate("https://productionmanagement.westeurope.cloudapp.azure.com:4431/#/");
            Thread.Sleep(5000);
            UserName.SetText(userName);
            PassWord.SetText("admin123");
            LoginButton.Click(LoginButton.Name);
            Thread.Sleep(20000);
        }

        public HomePage launchAndLoginProductionManagmentWebsite()
        {
            Browser.CreateDriver();
            Browser.Navigate("https://prodmgmt-dev.swedencentral.cloudapp.azure.com:4431/#/");
            Thread.Sleep(10000);
            //pmLogo.Click(pmLogo.Name);
            HomePage landingPage = new HomePage();
            return landingPage;
        }
    }
}
