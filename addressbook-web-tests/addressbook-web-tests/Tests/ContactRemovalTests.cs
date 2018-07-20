using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            int index = 2;
            app.Contacts.IsContactPresent(index, app.Contacts.bySelected, null);

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData toBeRemoved = oldContacts[index];

            app.Contacts.Remove(index);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count-1, newContacts.Count);

            oldContacts.RemoveAt(index);

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }

        [Test]
        public void ContactRemovalTestDetails()
        {
            int index = 7;
            app.Contacts.IsContactPresent(index, app.Contacts.bySelected, null);

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData toBeRemoved = oldContacts[index];

            app.Contacts.RemoveViaDetails(index);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count - 1, newContacts.Count);

            oldContacts.RemoveAt(index);

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }

        [Test]
        public void ContactRemovalTestEdit()
        {
            int index = 9;
            app.Contacts.IsContactPresent(index, app.Contacts.bySelected, null);

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData toBeRemoved = oldContacts[index];

            app.Contacts.RemoveViaEdit(index);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count - 1, newContacts.Count);

            oldContacts.RemoveAt(index);

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }
    }
}
