using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace addressbook_tests_white
{
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            int index = 2;

            List<ContactData> oldContacts = app.Contacts.GetContactList();
 
            if (oldContacts.Count < index)
            {
                for (int i = oldContacts.Count; i < index; i++)
                {
                    ContactData newContact = new ContactData()
                    {
                        Firstname = "ngA" + i,
                        Lastname = "lgA"+i
                    };

                    app.Contacts.Create(newContact);
                    oldContacts.Add(newContact);
                }
            }


            app.Contacts.Remove(index-1);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count-1, newContacts.Count);
            oldContacts.Sort();
            oldContacts.RemoveAt(index-1);

//            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

         }

    }
}
