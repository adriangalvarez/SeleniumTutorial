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
        private bool isGroup = false;             //Facebook handles differently if the post is to your own wall, or to a group wall

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

            loginToFB();
            preparePostToFB();
            publishPost();
        }

        private void loginToFB()
        {
            if ( txtGroupName.Text.Equals(string.Empty) )
                driver.Navigate().GoToUrl( String.Format( "https://www.facebook.com/" ) );
            else
            {
                isGroup = true;
                driver.Navigate().GoToUrl( String.Format( "https://www.facebook.com/groups/{0}/", txtGroupName.Text ) );
            }

            OpenQA.Selenium.IWebElement elemEMail = driver.FindElement( OpenQA.Selenium.By.Id( "email" ) );
            OpenQA.Selenium.IWebElement elemPass = driver.FindElement( OpenQA.Selenium.By.Id( "pass" ) );

            elemEMail.SendKeys( txtUsernameFB.Text );
            elemPass.SendKeys( txtPassFB.Text );
            elemPass.SendKeys( OpenQA.Selenium.Keys.Enter );
        }

        private void preparePostToFB()
        {
            if ( lblPathToPhoto.Visible )
            {
                addImageToFBPost();
            }

            if ( !txtPost.Equals( string.Empty ) )
            {
                OpenQA.Selenium.IWebElement elemPost;
                if ( isGroup )
                    elemPost = driver.FindElement( OpenQA.Selenium.By.XPath( "/html/body/div[1]/div[3]/div[1]/div/div[2]/div[2]/div[2]/div[2]/div[3]/div[1]/div/div/div[2]/div[1]/div/div/div/div[2]/div/div[1]/div[1]/div/div[1]/div[2]/div/div/div/div/div/div/div[2]/div" ), 40 );
                else
                {
                    driver.FindElement( OpenQA.Selenium.By.Name( "xhpc_message" ), 10 ).SendKeys( OpenQA.Selenium.Keys.Return );
                    elemPost = driver.FindElement( OpenQA.Selenium.By.XPath( "//div [@data-testid='status-attachment-mentions-input']" ), 10 );
                }

                elemPost.SendKeys( txtPost.Text );
            }
        }

        private void addImageToFBPost()
        {
            OpenQA.Selenium.IWebElement addPicButton;

            if ( isGroup )
            {
                addPicButton = driver.FindElement( OpenQA.Selenium.By.Name( "composer_photo[]" ), 10 );
                addPicButton.SendKeys( lblPathToPhoto.Text );

                //This line is because in group posts, if the image isn't uploaded before clicking the "Post" button, it gets lost,
                //so I need to wait until it shows up as a thumbnail before going to publishPost()
                OpenQA.Selenium.IWebElement elemImage = driver.FindElement( OpenQA.Selenium.By.XPath( "//div [@data-testid='media-attachment-photo']" ), 60 );
            } else
            {
                addPicButton = driver.FindElement( OpenQA.Selenium.By.XPath( "/html/body/div[1]/div[3]/div[1]/div/div[2]/div[2]/div[1]/div[2]/div/div[3]/div/div/div[2]/div/div/div/form/div[2]/span/div[1]/div/a/div[2]/input" ), 10 );
                addPicButton.SendKeys( lblPathToPhoto.Text );
            }
        }

        private void publishPost()
        {
            OpenQA.Selenium.IWebElement elemPostButton = driver.FindElement( OpenQA.Selenium.By.XPath( "//button [@data-testid='react-composer-post-button']" ), 10 );

            if ( isGroup )
            {
                OpenQA.Selenium.IWebElement elemImage = driver.FindElement( OpenQA.Selenium.By.XPath( "//div [@data-testid='media-attachment-photo']" ), 60 );
                try
                {
                    elemPostButton.Click();
                } catch ( OpenQA.Selenium.StaleElementReferenceException )
                {
                    elemPostButton = driver.FindElement( OpenQA.Selenium.By.XPath( "//button [@data-testid='react-composer-post-button']" ), 10 );
                    elemPostButton.Click();
                }
            } else
            {
                elemPostButton.Click();
            }
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

        private void Form1_Load( object sender, EventArgs e )
        {
            txtUsernameFB.Text = "testuser";
            txtPassFB.Text = "testpass";
            txtGroupName.Text = "testgroup";
            txtPost.Text = "testpost";
        }
    }
}
