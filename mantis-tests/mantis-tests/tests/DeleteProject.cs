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
                Name = "second",
                Status = "stable",
                Description = "my"
            };

            List<ProjectData> oldProjectTable = new List<ProjectData>();
            oldProjectTable = app.API.ListFromTable(account);

            if (!app.API.DeleteProjectFromTable(account, project))
            {
                app.API.CreateNewProject(account, project);
                oldProjectTable.Add(project);
            }
 
            app.API.DeleteProjectFromTable( account, project);

            List<ProjectData> newProjectTable = new List<ProjectData>();
            newProjectTable = app.API.ListFromTable( account);

            oldProjectTable.Remove(project);
            oldProjectTable.Sort();
            newProjectTable.Sort();
            Assert.AreEqual(oldProjectTable, newProjectTable);
        }
    }
}
