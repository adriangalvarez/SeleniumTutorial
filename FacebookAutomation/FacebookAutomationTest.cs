using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTutorial
{
    public class FacebookAutomationTest
    {
        private bool isGroup;

        private OpenQA.Selenium.IWebDriver driver;
        private FacebookAutomation.PageFacebookLogin pageFacebookLogin;
        private FacebookAutomation.PageFacebookWall pageFacebookWall;

        #region "Constructor & Destructor"
        public FacebookAutomationTest()
        {
            OpenQA.Selenium.Chrome.ChromeOptions options = new OpenQA.Selenium.Chrome.ChromeOptions();
            options.AddArguments( new string[] { "--start-maximized", "--disable-notifications", "--incognito" } );
            driver = new OpenQA.Selenium.Chrome.ChromeDriver( options );
            groups = new List<string>();
        }

        ~FacebookAutomationTest()
        {
            if ( !( driver is null ) )
            {
                driver.Quit();
            }
        }
        #endregion

        #region "Properties"
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
        #endregion

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

            pageFacebookLogin = new global::FacebookAutomation.PageFacebookLogin( driver );
            pageFacebookLogin.Login( email, password );
		}

        public void preparePostToFB()
        {
            pageFacebookWall = new global::FacebookAutomation.PageFacebookWall( driver, isGroup );
            pageFacebookWall.preparePostToFB( postText, pathToPhoto );
        }

        public void publishPost()
        {
            pageFacebookWall.publishPost();
        }
    }
}
