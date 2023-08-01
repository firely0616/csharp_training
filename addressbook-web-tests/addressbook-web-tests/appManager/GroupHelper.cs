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
            if (IsGroupPresent()) 
            {
                SelectGroup(groupId);
                driver.FindElement(By.Name("delete")).Click();
                return this;
            }
            else 
            {
                GroupData groupForRemove = new GroupData();
                groupForRemove.Name = "test name";
                groupForRemove.Header = "test header";
                groupForRemove.Footer = "test footer";
                Create(groupForRemove);
                driver.FindElement(By.LinkText("group page")).Click();
                SelectGroup(groupId);
                driver.FindElement(By.Name("delete")).Click();
                return this;
            }
            
        }
       
        public GroupHelper Modificate(int groupId, GroupData group)
        {
            if (IsGroupPresent())
            {
                SelectGroup(groupId);
                driver.FindElement(By.Name("edit")).Click();
                FillGroupForm(group);
                driver.FindElement(By.Name("update")).Click();
                return this;
            }
            else
            {
                GroupData groupForModificate = new GroupData();
                groupForModificate.Name = "test name";
                groupForModificate.Header = "test header";
                groupForModificate.Footer = "test footer";
                Create(groupForModificate);
                driver.FindElement(By.LinkText("group page")).Click();
                SelectGroup(groupId);
                driver.FindElement(By.Name("edit")).Click();
                FillGroupForm(group);
                driver.FindElement(By.Name("update")).Click();
                return this;
            }

        }
        public bool IsGroupPresent()
        {
            return IsElementPresent(By.XPath("//span[@class = 'group']"));
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
            Type(By.Name("group_name"), "test");
            Type(By.Name("group_header"), "test");
            Type(By.Name("group_footer"), "test");
            return this;
        }

       

    }
}
