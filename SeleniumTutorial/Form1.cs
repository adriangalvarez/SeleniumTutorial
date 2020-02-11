using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeleniumTutorial
{
    public partial class Form1 : Form
    {
        private OpenQA.Selenium.IWebDriver driver;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenBrowser_Click( object sender, EventArgs e )
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
        }

        private void btnMinimize_Click( object sender, EventArgs e )
        {
            driver.Manage().Window.Minimize();
        }

        private void btnMaximize_Click( object sender, EventArgs e )
        {
            driver.Manage().Window.Maximize();
        }

        private void btnNavigate_Click_1( object sender, EventArgs e )
        {
            driver.Navigate().GoToUrl( "https://" + txtNavigate.Text );
        }

        private void btnLoginFB_Click( object sender, EventArgs e )
        {
            if ( driver is null )
            {
                driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            }

            loginToFB();
            postToFBGroup();
        }

        private void loginToFB()
        {
            driver.Navigate().GoToUrl( String.Format( "https://www.facebook.com/groups/{0}/", txtGroupName.Text ) );

            OpenQA.Selenium.IWebElement elemEMail = driver.FindElement( OpenQA.Selenium.By.Id( "email" ) );
            OpenQA.Selenium.IWebElement elemPass = driver.FindElement( OpenQA.Selenium.By.Id( "pass" ) );

            elemEMail.SendKeys( txtUsernameFB.Text );
            elemPass.SendKeys( txtPassFB.Text );
            elemPass.SendKeys( OpenQA.Selenium.Keys.Enter );
        }

        private void postToFBGroup()
        {
            OpenQA.Selenium.IWebElement elemPost = driver.FindElement( OpenQA.Selenium.By.Name( "xhpc_message_text" ) );
            elemPost.SendKeys( txtPost.Text );

            OpenQA.Selenium.IWebElement elemPostButton = driver.FindElement( OpenQA.Selenium.By.XPath( "//button [@data-testid='react-composer-post-button']" ) );
            elemPostButton.Click();
        }

        private void Form1_FormClosed( object sender, FormClosedEventArgs e )
        {
            if ( !(driver is null) )
            {
                driver.Quit();
            }
        }

        private void Form1_Load( object sender, EventArgs e )
        {

        }

        private void btnRefresh_Click( object sender, EventArgs e )
        {
            driver.Navigate().Refresh();
        }

        private void btnBack_Click( object sender, EventArgs e )
        {
            driver.Navigate().Back();
        }

        private void btnForward_Click( object sender, EventArgs e )
        {
            driver.Navigate().Forward();
        }

        private void btnFullscreen_Click( object sender, EventArgs e )
        {
            driver.Manage().Window.FullScreen();
        }

        private void btnGetUrl_Click( object sender, EventArgs e )
        {
            lblData.Text = driver.Url;
            lblData.Visible = true;
        }

        private void btnGetTitle_Click( object sender, EventArgs e )
        {
            lblData.Text = driver.Title;
            lblData.Visible = true;
        }
    }
}
