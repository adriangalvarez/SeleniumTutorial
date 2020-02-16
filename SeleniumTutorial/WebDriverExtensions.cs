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
            int timeoutInSeconds,
            bool waitForClickable = false)
        {
            if ( timeoutInSeconds > 0 )
            {
                var wait = new OpenQA.Selenium.Support.UI.WebDriverWait( driver, TimeSpan.FromSeconds( timeoutInSeconds ) );
                wait.PollingInterval = TimeSpan.FromMilliseconds( 500 );
                wait.IgnoreExceptionTypes( typeof( OpenQA.Selenium.ElementNotInteractableException ), typeof( OpenQA.Selenium.NoSuchElementException ), typeof( OpenQA.Selenium.WebDriverTimeoutException ) );
                wait.Until( drv =>
                {
                    var elemList = drv.FindElements( by );
                    return ( ( !waitForClickable && elemList.Count == 1 )
                        || ( waitForClickable && elemList.Count == 1 && elemList[ 0 ].Displayed && elemList[ 0 ].Enabled ) );
                }
                );
            }
            return driver.FindElement( by );
        }
    }
}
