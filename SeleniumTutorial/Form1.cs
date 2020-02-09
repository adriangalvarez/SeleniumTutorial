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
    }
}
