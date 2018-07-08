﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.Remove(1);
        }

        [Test]
        public void ContactRemovalTestDetails()
        {
            app.Contacts.RemoveViaDetails(1);
        }

        [Test]
        public void ContactRemovalTestEdit()
        {
            app.Contacts.RemoveViaEdit(1);
        }
    }
}
