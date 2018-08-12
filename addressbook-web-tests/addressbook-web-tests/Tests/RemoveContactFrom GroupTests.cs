using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemoveContactFrom_GroupTests : AuthTestBase
    {
        [Test]
        public void TestRemoveContactFromGroup()
        {

            List<GroupData> groups = GroupData.GetAll().ToList();
            for (int i = 0; i < groups.LongCount(); ++i)
            {
 
                List<ContactData> groupList = groups[i].GetContacts();
                List<ContactData> oldList = groups[i].GetContacts();
                foreach (ContactData contact in groupList)
                {

                    //actions
                    app.Contacts.RemoveContactFromGroup(contact, groups[i]);
                    //compare

                    List<ContactData> newList = groups[i].GetContacts();
                    oldList.Remove(contact);
                    oldList.Sort();
                    newList.Sort();

                    Assert.AreEqual(oldList, newList);
                }
            }
        }
    }
}
