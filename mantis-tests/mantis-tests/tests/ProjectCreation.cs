using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
   
    [TestFixture]
    public class ProjectCreation : TestBase
    {
  

        [Test]
        public void TestProjectCreation()
        {

            ProjectData project = new ProjectData()
            {
                Name = "second",
                Status = "stable",
                Description = "my"
            };

            app.Login.LogInAdmin();
            app.Menu.Manage();
            app.Project.Add(project);

        }
    }
}
