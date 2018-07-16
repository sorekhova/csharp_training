using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {


        [Test]
        public void GroupRemovalTest()
        {
            int index = 7;
            app.Groups.IsGroupPresent(index, app.Groups.bySelected, null);
            app.Groups.Remove(index);
        }

        [Test]
        public void GroupRemovalTestBottom()
        {
            int index = 2;
            app.Groups.IsGroupPresent(index, app.Groups.bySelected, null);
            app.Groups.Remove(index, 2);
        }

    }
}
