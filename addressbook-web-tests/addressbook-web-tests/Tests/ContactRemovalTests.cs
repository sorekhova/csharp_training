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

            app.Contacts.Remove(index);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count-1, newContacts.Count);

            oldContacts.RemoveAt(index);

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void ContactRemovalTestDetails()
        {
            int index = 7;
            app.Contacts.IsContactPresent(index, app.Contacts.bySelected, null);

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.RemoveViaDetails(index);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count - 1, newContacts.Count);

            oldContacts.RemoveAt(index);

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void ContactRemovalTestEdit()
        {
            int index = 9;
            app.Contacts.IsContactPresent(index, app.Contacts.bySelected, null);

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.RemoveViaEdit(index);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count - 1, newContacts.Count);

            oldContacts.RemoveAt(index);

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
