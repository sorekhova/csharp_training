using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTestDetails()
        {
            int index = 5;
            //preparation
            ContactData contact = new ContactData("Сгей", "Сергеев");
            contact.Address2 = null;
            contact.Bmonth = "May";
            contact.Amonth = "June";
           
            app.Contacts.IsContactPresent(index, app.Contacts.byDetails, contact);

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[index];

            //action
            contact.Firstname = "Сергей";
            app.Contacts.ModifyViaDetails(index, contact);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            //verification

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[index].Firstname = contact.Firstname;
            oldContacts[index].Lastname = contact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData newData in newContacts)
            {
                if (newData.Id == oldData.Id)
                {
                    Assert.AreEqual(contact.Firstname, newData.Firstname);
                    Assert.AreEqual(contact.Lastname, newData.Lastname);
                }
            }

            //          Assert.IsTrue(app.Contacts.IsContactValidValue(index, "firstname", contact.Firstname));
        }

        [Test]
        public void ContactModificationTestDetailsBottom()
        {
            int index = 1;
            ContactData contact = new ContactData("Сергей", "Сергеев");
            contact.Address2 = "Ьщсква";
            contact.Bmonth = "May";
            contact.Amonth = "June";

            app.Contacts.IsContactPresent(index, app.Contacts.byDetails, contact);

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[index];

            app.Contacts.ModifyViaDetails(index, contact, 2);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[index].Firstname = contact.Firstname;
            oldContacts[index].Lastname = contact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData newData in newContacts)
            {
                if (newData.Id == oldData.Id)
                {
                    Assert.AreEqual(contact.Firstname, newData.Firstname);
                    Assert.AreEqual(contact.Lastname, newData.Lastname);
                }
            }
        }

        [Test]
        public void ContactModificationTestEdit()
        {
            int index = 3;
            ContactData contact = new ContactData("Сгей", "Сергеев");
            contact.Address2 = "Санкт-Петербург";
            app.Contacts.IsContactPresent(index, app.Contacts.byEdit, contact);
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[index];

            contact.Firstname = "Сергей";
            app.Contacts.ModifyViaEdit(index, contact);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[index].Firstname = contact.Firstname;
            oldContacts[index].Lastname = contact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData newData in newContacts)
            {
                if (newData.Id == oldData.Id)
                {
                    Assert.AreEqual(contact.Firstname, newData.Firstname);
                    Assert.AreEqual(contact.Lastname, newData.Lastname);
                }
            }
        }

        [Test]
        public void ContactModificationTestEditBottom()
        {
            int index = 1;
            ContactData contact = new ContactData("Иван", "Сергеев");
            contact.Address2 = "Владивосток";
            app.Contacts.IsContactPresent(index, app.Contacts.byEdit, contact);
            contact.Address2 = "Москва";
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[index];

            app.Contacts.ModifyViaEdit(index, contact, 2);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[index].Firstname = contact.Firstname;
            oldContacts[index].Lastname = contact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData newData in newContacts)
            {
                if (newData.Id == oldData.Id)
                {
                    Assert.AreEqual(contact.Firstname, newData.Firstname);
                    Assert.AreEqual(contact.Lastname, newData.Lastname);
                }
            }
        }
    }
}
