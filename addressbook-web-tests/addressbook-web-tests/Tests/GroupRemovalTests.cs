﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {


        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.Remove(1);
        }

        [Test]
        public void GroupRemovalTestBottom()
        {
            app.Groups.Remove(2, 2);
        }

    }
}
