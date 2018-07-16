using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            int index = 4;
            app.Contacts.IsContactPresent(index, app.Contacts.bySelected, null);
            app.Contacts.Remove(index);
        }

        [Test]
        public void ContactRemovalTestDetails()
        {
            int index = 7;
            app.Contacts.IsContactPresent(index, app.Contacts.bySelected, null);
            app.Contacts.RemoveViaDetails(index);
        }

        [Test]
        public void ContactRemovalTestEdit()
        {
            int index = 9;
            app.Contacts.IsContactPresent(index, app.Contacts.bySelected, null);
            app.Contacts.RemoveViaEdit(index);
        }
    }
}
