namespace SeleniumTutorial
{
    class BrowserManagement
    {
        private OpenQA.Selenium.IWebDriver driver;
        public BrowserManagement()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
        }

        ~BrowserManagement()
        {
            if(driver != null )
            {
                driver.Quit();
            }
        }

        public void Minimize()
        {
            driver.Manage().Window.Minimize();
        }

        public void Maximize()
        {
            driver.Manage().Window.Maximize();
        }

        public void Navigate(string url)
        {
            driver.Navigate().GoToUrl( "https://" + url );
        }

        public void Refresh()
        {
            driver.Navigate().Refresh();
        }

        public void Back()
        {
            driver.Navigate().Back();
        }

        public void Forward()
        {
            driver.Navigate().Forward();
        }

        public void Fullscreen()
        {
            driver.Manage().Window.FullScreen();
        }

        public string GetUrl()
        {
            return driver.Url;
        }

        public string GetTitle()
        {
            return driver.Title;
        }
    }
}