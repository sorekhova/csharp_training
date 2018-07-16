﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
       
        [Test]
        public void GroupCreationTest()
        {
  
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";
            
            app.Groups.Create(group);
        }

        [Test]
        public void GroupCreationTestBottom()
        {

            GroupData group = new GroupData("sss");
            group.Header = "sss";
            group.Footer = "sss";
            
            app.Groups.Create(group, 2);
        }
        [Test]
        public void EmptyGroupCreationTest()
        {

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
      
            app.Groups.Create(group, 1);
        }

    }
}