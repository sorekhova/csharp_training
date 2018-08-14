using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemoveContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemoveContactFromGroup()
        {
 
            List<ContactData> contacts = ContactData.GetAll().ToList();
            if (contacts.Count == 0)
            {
                ContactData addContact = new ContactData("Юрий", "Сергеев");
                app.Contacts.Create(addContact);
            }
            List<GroupData> groups = GroupData.GetAll().ToList();
            if (groups.Count == 0)
            {
                GroupData addGroup = new GroupData("my");
                app.Groups.Create(addGroup);
            }

            contacts = ContactData.GetAll().ToList();
            groups = GroupData.GetAll().ToList();
            foreach (ContactData contact in contacts)
            {
                List<GroupData> contactGroups = ContactData.GetGroups(contact.Id);
                if (contactGroups.Count == 0)
                {
                    app.Contacts.AddContactsToGroup(contact, groups.First());
                    contactGroups = ContactData.GetGroups(contact.Id);
                }

                List<ContactData> oldList = contactGroups.First().GetContacts();
                //actions
                app.Contacts.RemoveContactFromGroup(contact, contactGroups.First());
                //compare

                List<ContactData> newList = contactGroups.First().GetContacts();
                oldList.Remove(contact);
                oldList.Sort();
                newList.Sort();

                Assert.AreEqual(oldList, newList);
            }
                /*

                            List<GroupData> groups = GroupData.GetAll().ToList();
                            List<GroupContactRelation> enteredToGroup = contact.ContactEnteredToGroup(contact.Id, groups[groupIndex].Id);

                            if (enteredToGroup.Count == 0)
                            {
                                app.Contacts.AddContactsToGroup(contact, groups[groupIndex]);
                            }

                            //for (int i = 0; i < groups.LongCount(); ++i)
                            //{

                            //    List<ContactData> groupList = groups[i].GetContacts();
                                  List<ContactData> oldList = groups[groupIndex].GetContacts();
                            //    foreach (ContactData contact in groupList)
                            //    {

                                    //actions
                                    app.Contacts.RemoveContactFromGroup(contact, groups[groupIndex]);
                                    //compare

                                    List<ContactData> newList = groups[groupIndex].GetContacts();
                                    oldList.Remove(contact);
                                    oldList.Sort();
                                    newList.Sort();

                                    Assert.AreEqual(oldList, newList);
                            //    }
                            //}
                             */
            }

    }
}
