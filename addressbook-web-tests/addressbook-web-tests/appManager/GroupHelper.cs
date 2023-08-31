using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            return this;
        }
        public GroupHelper Remove(int groupId)
        {
            SelectGroup(groupId);
            RemoveGroup();
            return this;
        }
        public GroupHelper Remove(GroupData group)
        {
            SelectGroup(group.Id);
            RemoveGroup();
            return this;
        }
        public void RemoveGroup() 
        {
            driver.FindElement(By.Name("delete")).Click();
            groupChache = null;
        }

        public GroupHelper Modificate(int groupId, GroupData group)
        {

            SelectGroup(groupId);
            InitGroupModification();
            FillGroupForm(group);
            SubmitGroupModification();
            return this;
        }
        public GroupHelper Modificate(GroupData group, GroupData groupModificate)
        {

            SelectGroup(group.Id);
            InitGroupModification();
            FillGroupForm(groupModificate);
            SubmitGroupModification();
            return this;
        }
        public void InitGroupModification() 
        {
            driver.FindElement(By.Name("edit")).Click();
        }
        public void SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupChache = null;
        }

        public bool IsGroupPresent()
        {
            return IsElementPresent(By.XPath("//span[@class = 'group']"));
        }

        private List<GroupData> groupChache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupChache == null)
            {
                groupChache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    
                    groupChache.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<GroupData>(groupChache);

        }
        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count();
        }

        public void SelectGroup(int groupId) {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])["+groupId+"]")).Click(); 
        }
        public GroupHelper SelectGroup(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();
            return this;
        }
        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Id("content")).Click();
            driver.FindElement(By.Name("submit")).Click();
            groupChache = null;
            return this;
        }

        public GroupHelper FillGroupForm(GroupData groupData)
        {
            Type(By.Name("group_name"), groupData.Name);
            Type(By.Name("group_header"), groupData.Header);
            Type(By.Name("group_footer"), groupData.Footer);
            return this;
        }

       

    }
}
