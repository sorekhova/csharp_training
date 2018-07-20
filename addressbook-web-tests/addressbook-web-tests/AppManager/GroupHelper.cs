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

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        private List<GroupData> groupCash = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCash == null)
            {
                groupCash = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCash.Add(new GroupData(element.Text)
                    { Id = element.FindElement(By.TagName("input")).GetAttribute("value") });
                };
            }
            return new List<GroupData>(groupCash);
        }

        public GroupHelper Modify(int index, GroupData newData, int buttonIndex = 1)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(index, bySelected);
            InitGroupModification(buttonIndex);
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int index, int buttonIndex = 1)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(index, bySelected);
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

        public GroupHelper SelectGroup(int index, string type)
        {
 
            driver.FindElement(By.XPath(type + "[" + (index + 1) + "]")).Click();
            return this;
        }

        public void IsGroupPresent(int index, string type, GroupData group)
        {
            if (group == null)
            { group = new GroupData("new group"); }
            manager.Navigator.GoToGroupsPage();
            while (!IsItemPresent(index, type))
            {
                Create(group);
            }
            return;
        }

        public GroupHelper RemoveGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[" + index + "]")).Click();
            groupCash = null;
            return this;
        }
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCash = null;
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCash = null;
            return this;
        }

         public GroupHelper InitGroupModification(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='edit'])[" + index + "]")).Click();
            return this;
        }
    }
}
