using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {


        [Test]
        public void GroupRemovalTest()
        {
            int index = 0;
            app.Groups.IsGroupPresent(index, app.Groups.bySelected, null);

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(index);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);

            oldGroups.RemoveAt(index);

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void GroupRemovalTestBottom()
        {
            int index = 2;
            app.Groups.IsGroupPresent(index, app.Groups.bySelected, null);

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(index, 2);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);

            oldGroups.RemoveAt(index);

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
