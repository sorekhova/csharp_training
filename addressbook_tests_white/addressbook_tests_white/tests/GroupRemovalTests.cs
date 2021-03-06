﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {

        [Test]
        public void TestGroupRemoval()
        {
            int index =5;
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            if (oldGroups.Count < index)
            {
                for(int i = oldGroups.Count; i<index; i++)
                {
                    GroupData newGroup = new GroupData()
                    {
                        Name = "ngA"+i
                    };

                    app.Groups.Add(newGroup);
                    oldGroups.Add(newGroup);
                }
            }

            app.Groups.Remove(index-1);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            oldGroups.RemoveAt(index-1);

//            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
