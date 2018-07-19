using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            int index = 0;
            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;
            
            app.Groups.IsGroupPresent(index, app.Groups.bySelected, newData);

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(index, newData);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups[index].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void GroupModificationTestBottom()
        {
            int index = 1;
            GroupData newData = new GroupData("www");
            newData.Header = "www";
            newData.Footer = "www";

            app.Groups.IsGroupPresent(index, app.Groups.bySelected, newData);

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(index, newData, 2);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups[index].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
