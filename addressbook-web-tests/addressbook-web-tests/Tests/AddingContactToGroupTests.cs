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

            List<ContactData> contacts = ContactData.GetAll().ToList();
            if (contacts.Count == 0)
            {
                ContactData addContact = new ContactData("Юрий", "Сергеев");
                app.Contacts.Create(addContact);
            }
            List<GroupData> groups = GroupData.GetAll().ToList();
            if (groups.Count==0)
            {
                GroupData addGroup = new GroupData("my");
                app.Groups.Create(addGroup);
            }

            contacts = ContactData.GetAll().ToList();
            groups = GroupData.GetAll().ToList();

            foreach (ContactData contact in contacts)
            {
                ContactData newContact = contact;
                GroupData groupForAdding = groups.First();
                List <GroupData> contactGroups = ContactData.GetGroups(contact.Id);
                List<GroupData> contactNewGroups = GroupData.GetAll().Except(contactGroups).ToList();
                if (contactNewGroups.Count == 0)
                {
                    // add new contact
                    ContactData addContact = new ContactData("Мамай", "Сергеев");
                    app.Contacts.Create(addContact);
                    newContact = ContactData.GetLastContact();
                }
                else
                {
                    groupForAdding =  contactNewGroups.First();
                }

                List<ContactData> oldList = groupForAdding.GetContacts();
                //actions
                app.Contacts.AddContactsToGroup(newContact, groupForAdding);

                //compare
                List<ContactData> newList = groupForAdding.GetContacts();
                oldList.Add(newContact);
                oldList.Sort();
                newList.Sort();

                Assert.AreEqual(oldList, newList);

            }
/*
            ContactData contact = ContactData.GetAll()[contactIndex];

            GroupData addData = new GroupData("my");
            app.Groups.IsGroupPresent(groupIndex, app.Groups.bySelected, addData);

            List<GroupData> groups = GroupData.GetAll().ToList();
            GroupData group = groups[groupIndex];
            
            if (group.ContactEnteredToGroup(contact.Id, group.Id))
            {
                app.Contacts.Create(addContact);
                contact = ContactData.GetLastContact();
            }

            List<ContactData> oldList = group.GetContacts();
            //           List<ContactData> oldList = group.GetContact(contact.Id);
            //           ContactData contact = ContactData.GetAll().Except(oldList).First();

            //actions
            app.Contacts.AddContactsToGroup(contact, group);

            //compare
            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
*/
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
