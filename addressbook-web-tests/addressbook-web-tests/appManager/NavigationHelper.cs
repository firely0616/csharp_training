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
            if (driver.Url == baseURL)
            {
                return;
            }

            driver.Navigate().GoToUrl(baseURL);
        }
        public void AddNewContact()
        {
            if (driver.Url == baseURL + "edit.php" && IsElementPresent(By.Name("firstname")))
            {
                return;
            }

            driver.FindElement(By.LinkText("add new")).Click();
        }
        public void ReturnToHomePage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.FindElement(By.LinkText("home page")).Click();
        }
        public void GoToHomePage()
        {
            if (driver.Url == baseURL) 
            { 
                return; 
            }

            driver.FindElement(By.LinkText("home")).Click();
        }
        public void GoToGroupsPage()
        {
            if(driver.Url == baseURL + "group.php" && IsElementPresent(By.Name("new")))
            {
                return;
            }

            driver.FindElement(By.XPath("//a[contains(text(),'groups')]")).Click();
        }
        public void ReturnToGroupsPage()
        {
            if (driver.Url == baseURL + "group.php" && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("group page")).Click();
        }

    }
}
