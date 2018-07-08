using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {

            GroupData newData = new GroupData("zzz");
            newData.Header = "ttt";
            newData.Footer = "qqq";

            app.Groups.Modify(1, newData);
        }

        [Test]
        public void GroupModificationTestBottom()
        {

            GroupData newData = new GroupData("www");
            newData.Header = "www";
            newData.Footer = "www";

            app.Groups.Modify(1, newData, 2);
        }
    }
}
