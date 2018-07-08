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
            Thread.Sleep(1000);
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
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
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
