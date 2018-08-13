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
            int contactIndex = 2;
            int groupIndex = 5;
            ContactData addContact = new ContactData("Иван", "Сергеев");
            app.Contacts.IsContactPresent(contactIndex, app.Contacts.bySelected, addContact);
            ContactData contact = ContactData.GetAll()[contactIndex];

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
        }
    }
}
