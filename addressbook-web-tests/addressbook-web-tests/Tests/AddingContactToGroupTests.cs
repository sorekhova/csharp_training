using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();

            ContactData contact = ContactData.GetAll().Except(oldList).First();

            //actions
            app.Contacts.AddContactToGroup(contact, group);
            //compare

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);

        }

        [Test]
        public void TestAddingAllContactsToGroup()
        {
            
            List<GroupData> groups = GroupData.GetAll().ToList();
            for (int i =0; i<groups.LongCount(); ++i)
            {
                bool addition = true;
                GroupData group = groups[i];
                List<ContactData> oldList = group.GetContacts();
                List<ContactData> all = ContactData.GetAll().ToList();

                foreach (ContactData contact in all)
                {
                    addition = true;
                    foreach (ContactData existContact in oldList)
                    {
                        if (contact.Id == existContact.Id) { addition = false; break; }
                    }

                    if (addition)
                    {
                        //actions
                        app.Contacts.AddContactsToGroup(contact, group);
                        //compare

                        List<ContactData> newList = group.GetContacts();
                        oldList.Add(contact);
                        oldList.Sort();
                        newList.Sort();

                        Assert.AreEqual(oldList, newList);
                    }
                }
            
            }
         }
    }
}
