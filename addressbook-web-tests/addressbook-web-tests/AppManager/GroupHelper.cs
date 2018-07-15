using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        
        public GroupHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        public GroupHelper Create(GroupData group, int buttonIndex = 1)
        {
            manager.Navigator.GoToGroupsPage();
//            Thread.Sleep(1000);
            InitGroupCreation(buttonIndex);
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }


         public GroupHelper Modify(int index, GroupData newData, int buttonIndex = 1)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(index);
            InitGroupModification(buttonIndex);
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int index, int buttonIndex = 1)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(index);
            RemoveGroup(buttonIndex);
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper InitGroupCreation(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='new'])[" + index + "]")).Click();
            return this;
        }
        
        public GroupHelper FillGroupForm(GroupData group)
        {

            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
           
            return this;
        }



        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            if(! IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]")))
            {
                while(! IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]")))
                {
                    GroupData group = new GroupData("aaa");
                    group.Header = "ddd";
                    group.Footer = "fff";
                    Create(group);
                }
 
            }
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[" + index + "]")).Click();
            return this;
        }
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

         public GroupHelper InitGroupModification(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='edit'])[" + index + "]")).Click();
            return this;
        }
    }
}
