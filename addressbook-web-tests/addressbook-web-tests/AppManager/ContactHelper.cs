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
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            
            manager.Navigator.GoToHomePage();
            //            SelectContact(index, byEdit);
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string middlename = Value(By.Name("middlename"));

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");


            return new ContactData(firstName, lastName)
            {
                Address = address,
                Home = homePhone,
                Mobile = mobilePhone,
                Middlename = middlename,
                Nickname = Value(By.Name("nickname")),
                Title = Value(By.Name("title")),
                Company = Value(By.Name("company")),
                Fax = Value(By.Name("fax")),
                Email = Value(By.Name("email")),
                Email2 = Value(By.Name("email2")),
                Email3 = Value(By.Name("email3")),
                Bday = Value(By.Name("bday")),
                Bmonth = Value(By.Name("bmonth")),
                Byear = Value(By.Name("byear")),
                Aday = Value(By.Name("aday")),
                Amonth = Value(By.Name("amonth")),
                Ayear = Value(By.Name("ayear")),
                Address2 = Value(By.Name("address2")),
                Notes = Value(By.Name("notes")),
                Homepage = Value(By.Name("homepage")),
                Phone2 = phone2,
                Work = workPhone            
            };
        }

        public void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            SelectGroupFilter(group.Id);
            SelectContact(contact.Id);
            CommitRemoveContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void CommitRemoveContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public void SelectGroupFilter(string groupId)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByValue(groupId);
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);

        }

        public void AddContactsToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAddByValue(group.Id);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);

        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void SelectGroupToAddByValue(string value)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByValue(value);
        }

        private void SelectContact(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public ContactData GetContactInformationFromViewForm(int index)
        {

            manager.Navigator.GoToHomePage();
            InitContactView(index);
            string allViewNames = driver.FindElement(By.Id("content")).Text.Replace(" ","").Replace("\r\n","").ToUpper();
 
            return new ContactData(null, null)
            {
                AllViewNames = allViewNames
            };
        }
        public void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
        }

        public void InitContactView(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                                .FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
               {
                   Address = address,
                   AllMails = allEmails,
                   AllPhones = allPhones
               };
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        private List<ContactData> contactCash = null;

        public List<ContactData> GetContactList()
        {
            if (contactCash == null)
            {
                contactCash = new List<ContactData>();
                manager.Navigator.GoToHome();
                
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("(//tr[@name='entry'])"));

                foreach (IWebElement element in elements)
                {
                    contactCash.Add(new ContactData(element.FindElements(By.TagName("td"))[2].Text, element.FindElements(By.TagName("td"))[1].Text)
                    { Id = element.FindElements(By.TagName("td"))[0].FindElement(By.TagName("input")).GetAttribute("value") });

                };

             };
            return new List<ContactData>(contactCash);
        }

        public int GetContactCount()
        {
            manager.Navigator.GoToHome();
            return driver.FindElements(By.XPath(bySelected)).Count;
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
            contactCash = null;
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
            contactCash = null;
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[3]")).Click();
            contactCash = null;
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
            contactCash = null;
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
//            Thread.Sleep(5000);
            if (create) { new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday); };
 //           Thread.Sleep(5000);
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);

            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);

            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);

             if (create) { new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText(contact.New_group); };

            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
//            Thread.Sleep(5000);
            return this;
        }

         public void AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }

 
    }
}
