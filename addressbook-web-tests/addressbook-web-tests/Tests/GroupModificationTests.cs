using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            int index = 0;
            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;
            
            app.Groups.IsGroupPresent(index, app.Groups.bySelected, newData);

            //List<GroupData> oldGroups = app.Groups.GetGroupList();
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[index];

            app.Groups.Modify(index, newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            //List<GroupData> newGroups = app.Groups.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups[index].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id )
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }

        [Test]
        public void GroupModificationTestBottom()
        {
            int index = 1;
            GroupData newData = new GroupData("www");
            newData.Header = "www";
            newData.Footer = "www";

            app.Groups.IsGroupPresent(index, app.Groups.bySelected, newData);

            //List<GroupData> oldGroups = app.Groups.GetGroupList();
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[index];
            app.Groups.Modify(index, newData, 2);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            //List<GroupData> newGroups = app.Groups.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups[index].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
