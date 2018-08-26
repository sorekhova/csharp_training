using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager) { }

        public void Manage()
        {
            SelectManage();
            SelectManageProjects();


        }

        private void SelectManageProjects()
        {
            driver.FindElement(By.LinkText("Manage Projects")).Click();
        }

        private void SelectManage()
        {
            driver.FindElement(By.LinkText("Manage")).Click();
        }
    }
}
