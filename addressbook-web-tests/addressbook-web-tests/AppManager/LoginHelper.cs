﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) 
            : base(manager)
        {
        }
        public void Login(AccountData accountdata)
        {
            Type(By.Name("user"), accountdata.Username);
            Type(By.Name("pass"), accountdata.Password);

            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        public void LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

    }
}
