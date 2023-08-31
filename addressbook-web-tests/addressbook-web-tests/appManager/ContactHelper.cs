using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.AddNewContact();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper Remove(int contactId)
        {
            
                SelectContact(contactId);
                SubmitContactRemove();
                return this;       
        }
        public ContactHelper Remove(ContactData contact)
        {

            SelectContact(contact.Id);
            SubmitContactRemove();
            return this;
        }

        public void SubmitContactRemove()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactChache = null;
        }
        public ContactHelper Modificate(int contactId, ContactData contact)
        {         
                SelectContactForModificate(contactId);
                FillContactForm(contact);
                SubmitContactModificate();
                return this;         
        }
        public ContactHelper Modificate(ContactData contact, ContactData contactModificate)
        {
            SelectContactForModificate(contact.Id);
            FillContactForm(contactModificate);
            SubmitContactModificate();
            return this;
        }
        public void SubmitContactModificate()
        {
            driver.FindElement(By.Name("update")).Click();
            contactChache = null;
        }
        public bool IsContactPresent()
        {
            return IsElementPresent(By.XPath("//tr[@class = 'odd' or @name = 'entry']"));
        }

        public int GetNumberOfSerachResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.XPath("//label//span")).Text;           
            return Int32.Parse(text);
        }

        public void GoToContactDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            driver.FindElement(By.XPath("(//form[@name='MainForm']//img[@title='Details'])["+index+"]")).Click();
        }

        public ContactData GetContactInformationFromDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            GoToContactDetails(index);
            string allInfo = driver.FindElement(By.XPath("//div[@id = 'content']")).Text;
            return new ContactData()
            {
                AllInfo = allInfo
            };
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string firstname = cells[2].Text;
            string lastname = cells[1].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;

            return new ContactData(lastname, firstname) 
            {
                Address = address, 
                AllPhones = allPhones,
            };

        }
        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            SelectContactForModificate(index);          
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");




            return new ContactData(lastname, firstname)
            {

                Middlename= middlename,
                Address = address,
                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,
                Phone2 = phone2,
                Nickname = nickname,
                Company = company,
                Title = title,
                Fax = fax,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Address2 = address2,
                Homepage = homepage,
                Notes = notes
            };

        }

        private List<ContactData> contactChache = null;

        public List<ContactData> GetContactList()
        {
            if (contactChache == null)
            {
                contactChache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@class = 'odd' or @name = 'entry']"));
                int count = 0;
                foreach (IWebElement element in elements)
                {
                    count++;
                    contactChache.Add(new ContactData(element.FindElement(By.XPath("//tr[@class = 'odd' or @name = 'entry'][" + count + "]//td[2]")).Text,
                        element.FindElement(By.XPath("//tr[@class = 'odd' or @name = 'entry'][" + count + "]//td[3]")).Text));
                }
            }
            return new List<ContactData>(contactChache);
        }

        public int GetContactCount() 
        {
        return driver.FindElements(By.XPath("//tr[@class = 'odd' or @name = 'entry']")).Count;
        }

        public void SelectContact(int contactId)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + contactId + "]")).Click();
        }
        public ContactHelper SelectContact(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();
            return this;
        }
        public void SelectContactForModificate(int contactId)
        {
            driver.FindElement(By.XPath("(//form[@name='MainForm']//img[@title='Edit'])[" + contactId + "]")).Click();
        }
        public ContactHelper SelectContactForModificate(String id)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]' and @value='"+id+ "']/ancestor::tr//img[@title='Edit']")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            Type(By.Name("byear"), contact.Byear);
            Type(By.Name("ayear"), contact.Ayear);
            return this;

        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//input[contains(@value, 'Enter')]")).Click();
            contactChache = null;
            return this;
        }

    }
}
