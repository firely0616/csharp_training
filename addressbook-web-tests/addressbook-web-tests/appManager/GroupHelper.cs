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
                driver.FindElement(By.Name("delete")).Click();
                return this;
        }
       
        public GroupHelper Modificate(int groupId, GroupData group)
        {
           
                SelectGroup(groupId);
                driver.FindElement(By.Name("edit")).Click();
                FillGroupForm(group);
                driver.FindElement(By.Name("update")).Click();
                return this;         
        }
        public bool IsGroupPresent()
        {
            return IsElementPresent(By.XPath("//span[@class = 'group']"));
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {            
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }

        public void SelectGroup(int groupId) {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])["+groupId+"]")).Click(); 
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
