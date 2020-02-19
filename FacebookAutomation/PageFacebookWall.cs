using System;
using System.Collections.Generic;
using System.Text;
using SeleniumTutorial;

namespace FacebookAutomation
{
    class PageFacebookWall
    {
        private OpenQA.Selenium.IWebDriver driver;
        private OpenQA.Selenium.IWebElement elemPostText;
        private OpenQA.Selenium.IWebElement elemAddImage;
        bool isGroup;

        public PageFacebookWall(OpenQA.Selenium.IWebDriver driver, bool isGroup)
        {
            this.driver = driver;
            this.isGroup = isGroup;
        }

        private void SetImageElement()
        {
            if ( isGroup )
                elemAddImage = driver.FindElement( OpenQA.Selenium.By.Name( "composer_photo[]" ), 10 );
            else
                elemAddImage = driver.FindElement( OpenQA.Selenium.By.XPath( "/html/body/div[1]/div[3]/div[1]/div/div[2]/div[2]/div[1]/div[2]/div/div[3]/div/div/div[2]/div/div/div/form/div[2]/span/div[1]/div/a/div[2]/input" ), 10 );
        }

        private void SetPostTextElement()
        {
            if ( isGroup )
            {
                elemPostText = driver.FindElement( OpenQA.Selenium.By.XPath( "/html/body/div[1]/div[3]/div[1]/div/div[2]/div[2]/div[2]/div[2]/div[3]/div[1]/div/div/div[2]/div[1]/div/div/div/div[2]/div/div[1]/div[1]/div/div[1]/div[2]/div/div/div/div/div/div/div[2]/div" ), 40 );
            } else
            {
                driver.FindElement( OpenQA.Selenium.By.Name( "xhpc_message" ), 10 ).SendKeys( OpenQA.Selenium.Keys.Return );
                elemPostText = driver.FindElement( OpenQA.Selenium.By.XPath( "//div [@data-testid='status-attachment-mentions-input']" ), 10 );
            }
        }

        public void preparePostToFB(string postText, string pathToPhoto)
        {
            if ( !( pathToPhoto is null ) )
            {
                SetImageElement();
                elemAddImage.SendKeys( pathToPhoto );
                if ( isGroup )
                {
                    //This line is because in group posts, I need to wait until the post button is enabled before going to publishPost()
                    //or the photo would be lost.
                    OpenQA.Selenium.IWebElement elemPostButton = driver.FindElement( OpenQA.Selenium.By.XPath( "//button [@data-testid='react-composer-post-button']" ), 60, true );
                }
            }

            if ( !postText.Equals( string.Empty ) )
            {
                SetPostTextElement();
                elemPostText.SendKeys( postText );
            }
        }

        public void publishPost()
        {
            OpenQA.Selenium.IWebElement elemPostButton = driver.FindElement( OpenQA.Selenium.By.XPath( "//button [@data-testid='react-composer-post-button']" ), 10 );
            elemPostButton.Click();
        }
    }
}
