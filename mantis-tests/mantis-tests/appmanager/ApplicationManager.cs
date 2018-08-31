using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

//using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {

        protected IWebDriver driver;
        protected string baseURL;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.UseLegacyImplementation = true;
            options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";

            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/mantisbt-1.2.20";
            Registration = new RegistrationHelper(this);
            Login = new LoginHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            Menu = new ManagementMenuHelper(this);
            Project = new ProjectManagementHelper(this);
            Admin = new AdminHelper(this, baseURL);

  //          verificationErrors = new StringBuilder();

 
        }

        ~ApplicationManager()
        {
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
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
  //              newInstance.driver.Url = "http://localhost/mantisbt-2.16.0/mantisbt-2.16.0/login_page.php/";
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
                app.Value = newInstance;
                
            }
            return app.Value;
        }
 
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }

        }

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get;  set; }
        public JamesHelper James { get; set; }
        public MailHelper Mail { get;  set; }

        public LoginHelper Login { get;  set; }
        public ManagementMenuHelper Menu { get;  set; }
        public ProjectManagementHelper Project { get;  set; }
        public AdminHelper Admin { get;  set; }
    }
}
