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
        private BrowserManagement browser;
        private SeleniumTutorial.FacebookAutomation facebookAutomation;
     
        public Form1()
        {
            InitializeComponent();
        }

        #region BrowserManagement
        private void btnOpenBrowser_Click( object sender, EventArgs e )
        {
            browser = new BrowserManagement();
        }

        private void btnMinimize_Click( object sender, EventArgs e )
        {
            browser.Minimize();
        }

        private void btnMaximize_Click( object sender, EventArgs e )
        {
            browser.Maximize();
        }

        private void btnNavigate_Click_1( object sender, EventArgs e )
        {
            browser.Navigate( txtNavigate.Text );
        }

        private void btnRefresh_Click( object sender, EventArgs e )
        {
            browser.Refresh();
        }

        private void btnBack_Click( object sender, EventArgs e )
        {
            browser.Back();
        }

        private void btnForward_Click( object sender, EventArgs e )
        {
            browser.Forward();
        }

        private void btnFullscreen_Click( object sender, EventArgs e )
        {
            browser.Fullscreen();
        }

        private void btnGetUrl_Click( object sender, EventArgs e )
        {
            lblData.Text = browser.GetUrl();
            lblData.Visible = true;
        }

        private void btnGetTitle_Click( object sender, EventArgs e )
        {
            lblData.Text = browser.GetTitle();
            lblData.Visible = true;
        }
        #endregion

        private void btnLoginFB_Click( object sender, EventArgs e )
        {
            facebookAutomation = new FacebookAutomation();
            facebookAutomation.EMail = txtUsernameFB.Text;
            facebookAutomation.Password = txtPassFB.Text;
            facebookAutomation.AddGroup( txtGroupName.Text );
            facebookAutomation.PostText = txtPost.Text;
            if ( lblPathToPhoto.Visible )
            {
                facebookAutomation.PathToPhoto = lblPathToPhoto.Text;
            }

            facebookAutomation.loginToFB();
            facebookAutomation.preparePostToFB();
            facebookAutomation.publishPost();
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

        private void Form1_Load( object sender, EventArgs e )
        {
            txtUsernameFB.Text = "";
            txtPassFB.Text = "";
            txtGroupName.Text = "";
            txtPost.Text = "";
        }
    }
}
