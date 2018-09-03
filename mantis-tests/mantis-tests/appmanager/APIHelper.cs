using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;
using NUnit.Framework;

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

            List<ProjectData> oldProjectTable = new List<ProjectData>();
            List<ProjectData> newProjectTable = new List<ProjectData>();

            oldProjectTable = ListFromTable(client, account);
            if (DeleteProjectFromTable(client, account, project))
            {
                oldProjectTable.Remove(project);
            }

            client.mc_project_add(account.Name, account.Password,projectData);
            oldProjectTable.Add(project);
            newProjectTable = ListFromTable(client, account);

            oldProjectTable.Sort();
            newProjectTable.Sort();
            Assert.AreEqual(oldProjectTable, newProjectTable);

        }

        public void RemoveProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projectData = new Mantis.ProjectData();
            projectData.description = project.Description;
            projectData.name = project.Name;
            projectData.status = new Mantis.ObjectRef();
            projectData.status.name = project.Status;
  
             
            List<ProjectData> oldProjectTable = new List<ProjectData>();
            List<ProjectData> newProjectTable = new List<ProjectData>();


            oldProjectTable = ListFromTable(client, account);
//            int oldCount = oldProjectTable.Count();
            if (!DeleteProjectFromTable(client,account,project))
            {
                client.mc_project_add(account.Name, account.Password, projectData);
                oldProjectTable.Add(new ProjectData() { Name = projectData.name });
//                oldCount++;
                DeleteProjectFromTable(client, account, project);

            }

//            CompareCountTables(account, false, oldCount);


            newProjectTable = ListFromTable(client, account);
           
 
            oldProjectTable.Remove(project);
            oldProjectTable.Sort();
            newProjectTable.Sort();
            Assert.AreEqual(oldProjectTable, newProjectTable);

        }

        private bool CompareCountTables(AccountData account, bool add, int oldCount)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] table = client.mc_projects_get_user_accessible(account.Name, account.Password);
            if (add && table.Count() == oldCount+1 || !add && table.Count() == oldCount-1)
            {
               return true; 
             }
 
            return false;
        }

        private List<ProjectData> ListFromTable(Mantis.MantisConnectPortTypeClient client, AccountData account)
        {
            Mantis.ProjectData[] table = client.mc_projects_get_user_accessible(account.Name, account.Password);
            List<ProjectData> list = new List<ProjectData>();
            foreach (Mantis.ProjectData project in table)
            {
                list.Add(new ProjectData() { Name = project.name });
            };
            return list;
        }

        private bool DeleteProjectFromTable(Mantis.MantisConnectPortTypeClient client, AccountData account, ProjectData project)
        {
            Mantis.ProjectData[] table = client.mc_projects_get_user_accessible(account.Name, account.Password);
            foreach (Mantis.ProjectData projectD in table)
            {
                if (projectD.name == project.Name)
                {
                    return client.mc_project_delete(account.Name, account.Password, projectD.id);
                }
            }
            return false;
        }
    }
}
