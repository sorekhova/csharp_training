using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewProject : TestBase
    {
        [Test]
        public void TestAddNewProject()
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

 
            app.API.CreateNewProject(account, project);
        }
    }
}
