using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void LogInAdmin()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            LogIn(account);
        }

        public void LogIn(AccountData account)
        {

            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input.button")).Click();
        }

    }
}
