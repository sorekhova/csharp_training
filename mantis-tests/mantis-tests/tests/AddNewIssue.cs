using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssue : TestBase
    {
        [Test]
        public void TestAddNewIssue()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            IssueData issueData = new IssueData()
            {
                Summary = "some short text",
                Description = "some long text",
                Category="General"
            };
            ProjectData project = new ProjectData() { Id = "8" };
            app.API.CreateNewIssue(account, issueData, project);
        }
    }
}
