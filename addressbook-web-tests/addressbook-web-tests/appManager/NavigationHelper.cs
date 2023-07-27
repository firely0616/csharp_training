using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        public string baseURL;
        public NavigationHelper(ApplicationManager manager, String baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
        public void AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
        public void GoToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
        public void GoToGroupsPage()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'groups')]")).Click();
        }
        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

    }
}
