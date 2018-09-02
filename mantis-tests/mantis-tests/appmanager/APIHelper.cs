using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        

        public APIHelper(ApplicationManager manager) : base(manager) { }
        public void CreateNewIssue(AccountData account, IssueData issueData, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public void CreateNewProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projectData = new Mantis.ProjectData();
            projectData.description = project.Description;
            projectData.name = project.Name;
            projectData.status = new Mantis.ObjectRef();
            projectData.status.name = project.Status;
            Mantis.ProjectData[] table = client.mc_projects_get_user_accessible(account.Name, account.Password);
            if (table.Count() != 0)
            {
                foreach(Mantis.ProjectData projectD in table)
                {
                    if (projectD.name==project.Name)
                    {
                        client.mc_project_delete(account.Name, account.Password,projectD.id);
                    }
                }
            };


            client.mc_project_add(account.Name, account.Password,projectData);

          }

        public void RemoveProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projectData = new Mantis.ProjectData();
            projectData.description = project.Description;
            projectData.name = project.Name;
            projectData.status = new Mantis.ObjectRef();
            projectData.status.name = project.Status;
            bool found = false;
            Mantis.ProjectData[] table = client.mc_projects_get_user_accessible(account.Name, account.Password);
            if (table.Count() != 0)
            {
                foreach (Mantis.ProjectData projectD in table)
                {
                    if (projectD.name == project.Name)
                    {
                        found = true;
                        client.mc_project_delete(account.Name, account.Password, projectD.id);
                    }
                }
            }
            if (!found)
            {
                Mantis.ProjectData[] newTable = client.mc_projects_get_user_accessible(account.Name, account.Password);
                foreach (Mantis.ProjectData projectD in newTable)
                {
                    if (projectD.name == project.Name)
                    {
                        client.mc_project_delete(account.Name, account.Password, projectD.id);
                    }
                }
            }
    

        }
    }
}
