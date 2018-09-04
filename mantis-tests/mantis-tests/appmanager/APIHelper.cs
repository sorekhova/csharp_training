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
        
            client.mc_project_add(account.Name, account.Password,projectData);
 
        }

  
        public List<ProjectData> ListFromTable( AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] table = client.mc_projects_get_user_accessible(account.Name, account.Password);
            List<ProjectData> list = new List<ProjectData>();
            foreach (Mantis.ProjectData project in table)
            {
                list.Add(new ProjectData() { Name = project.name });
            };
            return list;
        }

        public bool DeleteProjectFromTable( AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
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
