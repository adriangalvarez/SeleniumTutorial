using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTutorial
{
    public static class WebDriverExtensions
    {
        public static OpenQA.Selenium.IWebElement FindElement( 
            this OpenQA.Selenium.IWebDriver driver, 
            OpenQA.Selenium.By by, 
            int timeoutInSeconds )
        {
            if ( timeoutInSeconds > 0 )
            {
                var wait = new OpenQA.Selenium.Support.UI.WebDriverWait( driver, TimeSpan.FromSeconds( timeoutInSeconds ) );
                wait.PollingInterval = TimeSpan.FromMilliseconds( 500 );
                wait.IgnoreExceptionTypes( typeof( OpenQA.Selenium.ElementNotInteractableException ), typeof( OpenQA.Selenium.NoSuchElementException ), typeof(OpenQA.Selenium.WebDriverTimeoutException) );
                wait.Until( drv =>
                    {
                        var elemList = drv.FindElements( by );
                        return ( elemList.Count == 1 );
                    }
                );
            }
            return driver.FindElement( by );
        }
    }
}
