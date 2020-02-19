using System;
using System.Collections.Generic;
using System.Text;

namespace FacebookAutomation
{
    public class PageFacebookLogin
    {
        private OpenQA.Selenium.IWebDriver driver;
        private OpenQA.Selenium.IWebElement elemUsername;
        private OpenQA.Selenium.IWebElement elemPassword;

        public PageFacebookLogin(OpenQA.Selenium.IWebDriver driver)
        {
            this.driver = driver;
        }

        private void SetUsername(string username )
        {
            elemUsername = driver.FindElement( OpenQA.Selenium.By.Id( "email" ) );
            elemUsername.SendKeys( username );
        }

        private void SetPassword(string password )
        {
            elemPassword = driver.FindElement( OpenQA.Selenium.By.Id( "pass" ) );
            elemPassword.SendKeys( password );
        }

        public void Login(string username, string password)
        {
            SetUsername( username );
            SetPassword( password );
            elemPassword.SendKeys( OpenQA.Selenium.Keys.Enter );
        }
    }
}
