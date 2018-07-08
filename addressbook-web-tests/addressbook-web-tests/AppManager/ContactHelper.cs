using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact, int buttonIndex = 1)
        {
            manager.Navigator.GoToHome();

            AddNewContact();
            FillEntry(contact);
            SubmitContactCreation(buttonIndex);
            return this;
        }

        public ContactHelper Remove(int index)
        {
            manager.Navigator.GoToHome();

            SelectContact(index);
            RemoveContact();
            Thread.Sleep(1000);
            AcceptAlert();
            return this;
        }

        public ContactHelper ModifyViaDetails(int index, ContactData contact, int buttonIndex=1)
        {
            manager.Navigator.GoToHome();

            DetailsContact(index);
            ModifyContact();
            FillEntry(contact, false);
            UpdateContact(buttonIndex);
            return this;
        }

        public ContactHelper ModifyViaEdit(int index, ContactData contact, int buttonIndex=1)
        {
            manager.Navigator.GoToHome();

            EditContact(index);
            FillEntry(contact, false);
            UpdateContact(buttonIndex);
            return this;
        }

        public ContactHelper RemoveViaDetails(int index)
        {
            manager.Navigator.GoToHome();

            DetailsContact(index);
            ModifyContact();
            DeleteContact();
            return this;
        }

        public ContactHelper RemoveViaEdit(int index)
        {
            manager.Navigator.GoToHome();

            EditContact(index);
            DeleteContact();
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper DetailsContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Details'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper ModifyContact()
        {
            driver.FindElement(By.Name("modifiy")).Click();
            return this;
        }

        public ContactHelper EditContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index +"]")).Click();
            return this;
        }

        public ContactHelper UpdateContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[3]")).Click();
            return this;
        }
 
        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper AddNextContact()
        {
            driver.FindElement(By.LinkText("add next")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[" + index + "]")).Click();
            /*
                        if (IsElementPresent(By.Name("submit")))
                        {
                            driver.FindElement(By.Name("submit")).Click();
                        } 
            */
            return this;
        }

        public ContactHelper FillEntry(ContactData contact, bool create = true)
        {

            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);

            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);

            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);

            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);

            driver.FindElement(By.Name("photo")).Clear();
            driver.FindElement(By.Name("photo")).SendKeys(contact.Photo);

            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(contact.Title);

            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(contact.Company);

            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(contact.Address);

            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(contact.Home);

            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(contact.Mobile);

            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(contact.Work);

            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(contact.Fax);

            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(contact.Email);

            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(contact.Email2);

            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(contact.Email3);

            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(contact.Homepage);

            if (create) { new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday); };

            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);

            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(contact.Byear);

            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);

            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);

            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys(contact.Ayear);

            if (create) { new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText(contact.New_group); };

            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys(contact.Address2);

            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys(contact.Phone2);

            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(contact.Notes);
            return this;
        }

         public void AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }

 
    }
}
