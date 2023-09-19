using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.IO.Ports;

namespace mantis_tests

{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;
        private bool acceptNextAlert = true;
        protected LoginHelper loginHelper;
        protected ProjectHelper projectHelper;
        protected NavigationHelper navigationHelper;
        protected APIHelper apiHelper;
        private static ThreadLocal <ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager() {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-1.3.20/login_page.php";
            verificationErrors = new StringBuilder();
            Registration = new RegistrationHelper(this);
//            Ftp = new FtpHelper(this);
            loginHelper = new LoginHelper(this);
            projectHelper = new ProjectHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            apiHelper = new APIHelper(this);

        }

        ~ApplicationManager() {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

        }   

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-1.3.20/login_page.php";
                app.Value = newInstance;
              
            }
            return app.Value;
        }

        public IWebDriver Driver { 
            get
            {
            return driver;
            }
        }
        public RegistrationHelper Registration
        {
            get;set;
        }
        public FtpHelper Ftp
        {
            get; set;
        }
        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }
        public ProjectHelper Project
        {
            get 
            {
                return projectHelper;
            }
        }
        public NavigationHelper Navigator
        {
            get
            {
                return navigationHelper;
            }
        }

        public APIHelper api
        {
            get
            {
                return apiHelper;
            }
        }

    }
}
