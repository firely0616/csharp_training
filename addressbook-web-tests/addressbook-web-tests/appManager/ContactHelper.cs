using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;
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
                driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
                driver.SwitchTo().Alert().Accept();
                return this;       
        }
      

        public ContactHelper Modificate(int contactId, ContactData contact)
        {         
                SelectContactForModificate(contactId);
                FillContactForm(contact);
                driver.FindElement(By.Name("update")).Click();
                return this;         
        }
        public bool IsContactPresent()
        {
            return IsElementPresent(By.XPath("//tr[@class = 'odd' or @name = 'entry']"));
        }

        public void SelectContact(int contactId)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + contactId + "]")).Click();
        }
        public void SelectContactForModificate(int contactId)
        {
            driver.FindElement(By.XPath("(//form[@name='MainForm']//img[@title='Edit'])[" + contactId + "]")).Click();
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
            TypeDate(By.Name("bday"), contact.Bday);
            TypeDate(By.Name("bmonth"), contact.Bmonth);
            TypeDate(By.Name("aday"), contact.Aday);
            TypeDate(By.Name("amonth"), contact.Amonth);
            return this;

        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//input[contains(@value, 'Enter')]")).Click();
            return this;
        }

    }
}
