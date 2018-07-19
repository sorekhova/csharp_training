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

            SelectContact(index, bySelected);
            RemoveContact();
            Thread.Sleep(1000);
            AcceptAlert();
            return this;
        }

        public ContactHelper ModifyViaDetails(int index, ContactData contact, int buttonIndex=1)
        {
            manager.Navigator.GoToHome();
            SelectContact(index, byDetails);
            ModifyContact();
            FillEntry(contact, false);
            UpdateContact(buttonIndex);
            return this;
        }

        public ContactHelper ModifyViaEdit(int index, ContactData contact, int buttonIndex=1)
        {
            manager.Navigator.GoToHome();
            SelectContact(index, byEdit);
            FillEntry(contact, false);
            UpdateContact(buttonIndex);
            return this;
        }

        internal List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHome();

            ICollection<IWebElement> elements = driver.FindElements(By.XPath(bySelected));
            
            foreach (IWebElement element in elements)
            {
                ContactData currentContact = new ContactData();
                string title = element.GetAttribute("title");
                string[] strSplit = title.Split(' ');
                currentContact.Firstname = strSplit[1].Substring(1);
                currentContact.Lastname = strSplit[2].Substring(0,strSplit[2].Length-1);
                contacts.Add(currentContact);
            };

            return contacts;
        }

        public ContactHelper RemoveViaDetails(int index)
        {
            manager.Navigator.GoToHome();
            SelectContact(index, byDetails);
            ModifyContact();
            DeleteContact();
            return this;
        }

        public ContactHelper RemoveViaEdit(int index)
        {
            manager.Navigator.GoToHome();
            SelectContact(index, byEdit);
            DeleteContact();
            return this;
        }

        public void IsContactPresent(int index, string type, ContactData contact)
        {
            if (contact == null)
            { contact = new ContactData("Сергей", "Сергеев"); }
            manager.Navigator.GoToHome();
            while (!IsItemPresent(index, type))
            {
                Create(contact);
                manager.Navigator.GoToHome();
            }
            return;
        }

         public ContactHelper SelectContact(int index, string type)
        {
            driver.FindElement(By.XPath(type + "[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper ModifyContact()
        {
            driver.FindElement(By.Name("modifiy")).Click();
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
            return this;
        }

        public bool IsContactValidValue(int index, string name, string value)
        {
            manager.Navigator.GoToHome();
            SelectContact(index, byEdit);
            return Value(By.Name(name), value);
        }
        public ContactHelper FillEntry(ContactData contact, bool create = true)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("photo"), contact.Photo);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            Type(By.Name("byear"), contact.Byear);
            Type(By.Name("ayear"), contact.Ayear);

            if (create) { new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday); };

            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);

            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);

            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);

             if (create) { new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText(contact.New_group); };

            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);

            return this;
        }

         public void AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }

 
    }
}
