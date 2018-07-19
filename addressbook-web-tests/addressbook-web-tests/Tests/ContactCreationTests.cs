using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public int Compare(string x, string y)
        {
            throw new NotImplementedException();
        }

        [Test]
        public void ContactCreationTest()
        {

            
            ContactData contact = new ContactData("Юрий", "Иванов");
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
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);

            oldContacts.Add(contact);

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }


        [Test]
        public void ContactCreationTestBottom()
        {

            ContactData contact = new ContactData("Петр", "Петров");
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact, 2);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);

            oldContacts.Add(contact);

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void ContactCreationTestNext()
        {
            ContactData contact = new ContactData("Иван", "Иванов");
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);

            app.Contacts.AddNextContact();
            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);

            oldContacts.Add(contact);

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            contact.Lastname = "Романов";
            contact.Firstname = "Роман";

            List<ContactData> nextOldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);

            List<ContactData> nextNewContacts = app.Contacts.GetContactList();
            Assert.AreEqual(nextOldContacts.Count + 1, nextNewContacts.Count);

            nextOldContacts.Add(contact);

            nextOldContacts.Sort();
            nextNewContacts.Sort();
            Assert.AreEqual(nextOldContacts, nextNewContacts);
        }
    }
}

