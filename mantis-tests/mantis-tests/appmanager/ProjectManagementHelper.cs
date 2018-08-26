using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public void Add(ProjectData project)
        {
            if (! Verify(project))
            { 
                CreateNewProject();
                FillProjectForm(project);
                SubmitAddProject();
            };
        }

        public void Remove(ProjectData project)
        {
            if (Verify(project))
            {
                OpenProject(project);
                SubmitRemoveProject();
            };
        }

        private void SubmitRemoveProject()
        {
            driver.FindElements(By.CssSelector("input.button"))[1].Click();
            driver.FindElement(By.CssSelector("input.button")).Click();
        }

        private void OpenProject(ProjectData project)
        {
            driver.FindElement(By.LinkText(project.Name)).Click();
        }

        private bool Verify(ProjectData project)
        {
            if (driver.FindElements(By.LinkText(project.Name)).Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        private void CreateNewProject()
        {
            if (driver.FindElements(By.Name("form_set_project")).Count == 0)
            {
                driver.FindElements(By.CssSelector("input.button-small"))[1].Click();
            }
            else
            {
                driver.FindElements(By.CssSelector("input.button-small"))[2].Click();
            }
        }

        private void SubmitAddProject()
        {
            driver.FindElement(By.CssSelector("input.button")).Click();
        }

        private void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
            driver.FindElement(By.Name("status")).SendKeys(project.Status);
            driver.FindElement(By.Name("description")).SendKeys(project.Description);
        }
    }
}
