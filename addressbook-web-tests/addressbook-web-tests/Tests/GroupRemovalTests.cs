using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {


        [Test]
        public void GroupRemovalTest()
        {
            int index = 0;
            app.Groups.IsGroupPresent(index, app.Groups.bySelected, null);

            //List<GroupData> oldGroups = app.Groups.GetGroupList();
            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData toBeRemoved = oldGroups[index];

            //app.Groups.Remove(index);
            app.Groups.Remove(toBeRemoved);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            //List<GroupData> newGroups = app.Groups.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();
            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);

            oldGroups.RemoveAt(index);

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }

        [Test]
        public void GroupRemovalTestBottom()
        {
            int index = 2;
            app.Groups.IsGroupPresent(index, app.Groups.bySelected, null);

            //List<GroupData> oldGroups = app.Groups.GetGroupList();
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[index];

            app.Groups.Remove(index, 2);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            //List<GroupData> newGroups = app.Groups.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();
            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);

            oldGroups.RemoveAt(index);

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }

    }
}
