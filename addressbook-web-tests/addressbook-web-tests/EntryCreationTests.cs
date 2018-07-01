using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class EntryCreationTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.UseLegacyImplementation = true;
            options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void EntryCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));

            AddNewEntry();

            EntryData entry = new EntryData("Иван", "Иванов");
            /*
            entry.Home = "+7(921)999-99-00";
            entry.Address2 = "Санкт-Петербург";
            entry.Bmonth = "May";
            entry.Amonth = "June";
            entry.New_group = "aaa";
            entry.Photo = "C:\\Users\\Public\\Pictures\\Sample Pictures\\Chrysanthemum.jpg";
            entry.Aday = "1";
            entry.Address = "Moscow";
            entry.Ayear = "2019";
            entry.Bday = "2";
            entry.Byear = "1900";
            entry.Company = "Emerson";
            entry.Email = "iivanov@mail.com";
            entry.Email2 = "iivanov@gmail.com";
            entry.Email3 = "iivanov@yandex.ru";
            entry.Fax = "+7(905)222-22-22";
            entry.Homepage = "https://docs.microsoft.com";
            entry.Middlename = "Иванович";
            entry.Mobile = "+7";
            entry.Nickname = "iii";
            */

            FillEntry(entry);
            SubmitNewEntry();
            
            Logout();
        }

        private void FillEntry(EntryData entry)
        {
           
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(entry.Firstname);
            
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(entry.Middlename);
            
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(entry.Lastname);
           
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(entry.Nickname);
 
            driver.FindElement(By.Name("photo")).Clear();
            driver.FindElement(By.Name("photo")).SendKeys(entry.Photo);
                
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(entry.Title);

            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(entry.Company);

            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(entry.Address);

            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(entry.Home);

            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(entry.Mobile);

            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(entry.Work);
           
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(entry.Fax);

            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(entry.Email);

            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(entry.Email2);

            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(entry.Email3);

            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(entry.Homepage);

            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(entry.Bday);

            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(entry.Bmonth);

            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(entry.Byear);

            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(entry.Aday);

            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(entry.Amonth);

            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys(entry.Ayear);

            new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText(entry.New_group);

            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys(entry.Address2);

            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys(entry.Phone2);

            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(entry.Notes);
            
        }

        private void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void SubmitNewEntry()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        private void AddNewEntry()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private void Login(AccountData accountdata)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(accountdata.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(accountdata.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}

