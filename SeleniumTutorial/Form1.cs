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
        private void btnLoginFB_Click( object sender, EventArgs e )
        {
            if ( driver is null )
            {
                OpenQA.Selenium.Chrome.ChromeOptions options = new OpenQA.Selenium.Chrome.ChromeOptions();
                options.AddArguments(new string[] { "--start-maximized", "--disable-notifications", "--incognito" } );
                driver = new OpenQA.Selenium.Chrome.ChromeDriver(options);
            }

            preparePostToFB( loginToFB() );
        }

        private bool loginToFB()
        {
            bool group = false;

            if ( txtGroupName.Text.Equals(string.Empty) )
                driver.Navigate().GoToUrl( String.Format( "https://www.facebook.com/" ) );
            else
            {
                group = true;
                driver.Navigate().GoToUrl( String.Format( "https://www.facebook.com/groups/{0}/", txtGroupName.Text ) );
            }

            OpenQA.Selenium.IWebElement elemEMail = driver.FindElement( OpenQA.Selenium.By.Id( "email" ) );
            OpenQA.Selenium.IWebElement elemPass = driver.FindElement( OpenQA.Selenium.By.Id( "pass" ) );

            elemEMail.SendKeys( txtUsernameFB.Text );
            elemPass.SendKeys( txtPassFB.Text );
            elemPass.SendKeys( OpenQA.Selenium.Keys.Enter );
            return group;
        }

        private void preparePostToFB(bool group )
        {
            if ( !txtPost.Equals( string.Empty ) )
            {
                OpenQA.Selenium.IWebElement elemPost;

                if ( group )
                    elemPost = driver.FindElement( OpenQA.Selenium.By.Name( "xhpc_message_text" ), 10 );
                else
                {
                    driver.FindElement( OpenQA.Selenium.By.Name( "xhpc_message" ), 10 ).SendKeys( OpenQA.Selenium.Keys.Return );
                    elemPost = driver.FindElement( OpenQA.Selenium.By.XPath( "//div [@data-testid='status-attachment-mentions-input']" ), 10 );
                }

                elemPost.SendKeys( txtPost.Text );
            }

            if ( lblPathToPhoto.Visible )
            {
                addImageToFBPost();
            }

            makePost();
        }

        private void addImageToFBPost()
        {
            OpenQA.Selenium.IWebElement addPicButton = driver.FindElement( OpenQA.Selenium.By.Name( "composer_photo[]" ), 10 );
            addPicButton.SendKeys( lblPathToPhoto.Text );
        }

        private void makePost()
        {
            OpenQA.Selenium.IWebElement elemPostButton = driver.FindElement( OpenQA.Selenium.By.XPath( "//button [@data-testid='react-composer-post-button']" ), 10 );
            elemPostButton.Click();
        }

        private void btnSelectFile_Click( object sender, EventArgs e )
        {
            OpenFileDialog fileFB = new OpenFileDialog();
            fileFB.Title = "Select Photo to Upload to Facebook";
            fileFB.Filter = "Pictures (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF";
            if( fileFB.ShowDialog() == DialogResult.OK )
            {
                lblPathToPhoto.Visible = true;
                lblPathToPhoto.Text = fileFB.FileName;
            }
        }

        private void Form1_FormClosed( object sender, FormClosedEventArgs e )
        {
            if ( !( driver is null ) )
            {
                driver.Quit();
            }
        }
    }
}
