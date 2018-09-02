using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class DeleteProject : TestBase
    {
        [Test]
        public void TestDeleteProject()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
 
            ProjectData project = new ProjectData()
            {
                Name = "3",
                Status = "stable",
                Description = "my"
            };

 
            app.API.RemoveProject(account, project);
        }
    }
}
