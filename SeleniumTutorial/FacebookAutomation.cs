using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTutorial
{
    class FacebookAutomation
    {
        private bool isGroup;

        private OpenQA.Selenium.IWebDriver driver;
        ~FacebookAutomation()
        {
            if ( !( driver is null ) )
            {
                driver.Quit();
            }
        }

        private string email;

		public string EMail
		{
			get { return email; }
			set { email = value; }
		}

		private string password;

		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		private string postText;

		public string PostText
		{
			get { return postText; }
			set { postText = value; }
		}

		private List<string> groups;

		private string pathToPhoto;

		public string PathToPhoto
		{
			get { return pathToPhoto; }
			set { pathToPhoto = value; }
		}

        public FacebookAutomation()
        {
            OpenQA.Selenium.Chrome.ChromeOptions options = new OpenQA.Selenium.Chrome.ChromeOptions();
            options.AddArguments( new string[] { "--start-maximized", "--disable-notifications", "--incognito" } );
            driver = new OpenQA.Selenium.Chrome.ChromeDriver( options );
            groups = new List<string>();
        }

        public void AddGroup(string groupName )
        {
            groups.Add( groupName );
        }

		public void loginToFB()
		{
            if ( email is null || password is null )
            {
                throw new Exception( "You must initialize Facebook email and password." );
            }

			if ( groups[0].Equals(string.Empty) )
				driver.Navigate().GoToUrl( String.Format( "https://www.facebook.com/" ) );
			else
			{
				isGroup = true;
				driver.Navigate().GoToUrl( String.Format( "https://www.facebook.com/groups/{0}/", groups[0] ) );
			}

			OpenQA.Selenium.IWebElement elemEMail = driver.FindElement( OpenQA.Selenium.By.Id( "email" ) );
			OpenQA.Selenium.IWebElement elemPass = driver.FindElement( OpenQA.Selenium.By.Id( "pass" ) );

			elemEMail.SendKeys( email );
			elemPass.SendKeys( password );
			elemPass.SendKeys( OpenQA.Selenium.Keys.Enter );
		}

        public void preparePostToFB()
        {
            if ( !(pathToPhoto is null) )
            {
                addImageToFBPost();
            }

            if ( !postText.Equals( string.Empty ) )
            {
                OpenQA.Selenium.IWebElement elemPost;
                if ( isGroup )
                    elemPost = driver.FindElement( OpenQA.Selenium.By.XPath( "/html/body/div[1]/div[3]/div[1]/div/div[2]/div[2]/div[2]/div[2]/div[3]/div[1]/div/div/div[2]/div[1]/div/div/div/div[2]/div/div[1]/div[1]/div/div[1]/div[2]/div/div/div/div/div/div/div[2]/div" ), 40 );
                else
                {
                    driver.FindElement( OpenQA.Selenium.By.Name( "xhpc_message" ), 10 ).SendKeys( OpenQA.Selenium.Keys.Return );
                    elemPost = driver.FindElement( OpenQA.Selenium.By.XPath( "//div [@data-testid='status-attachment-mentions-input']" ), 10 );
                }

                elemPost.SendKeys( postText );
            }
        }

        private void addImageToFBPost()
        {
            OpenQA.Selenium.IWebElement addPicButton;

            if ( isGroup )
            {
                addPicButton = driver.FindElement( OpenQA.Selenium.By.Name( "composer_photo[]" ), 10 );
                addPicButton.SendKeys( pathToPhoto );

                //This line is because in group posts, I need to wait until the post button is enabled before going to publishPost()
                //or the photo would be lost.
                OpenQA.Selenium.IWebElement elemPostButton = driver.FindElement( OpenQA.Selenium.By.XPath( "//button [@data-testid='react-composer-post-button']" ), 60, true );
            } else
            {
                addPicButton = driver.FindElement( OpenQA.Selenium.By.XPath( "/html/body/div[1]/div[3]/div[1]/div/div[2]/div[2]/div[1]/div[2]/div/div[3]/div/div/div[2]/div/div/div/form/div[2]/span/div[1]/div/a/div[2]/input" ), 10 );
                addPicButton.SendKeys( pathToPhoto );
            }
        }

        public void publishPost()
        {
            OpenQA.Selenium.IWebElement elemPostButton = driver.FindElement( OpenQA.Selenium.By.XPath( "//button [@data-testid='react-composer-post-button']" ), 10 );
            elemPostButton.Click();
        }
    }
}
