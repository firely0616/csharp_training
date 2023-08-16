using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("lastname", "firstname");           
            contact.Middlename = "test1";           
            contact.Nickname = "test1";
            contact.Title = "test1";
            contact.Company = "test1";
            contact.Address = "test1";
            contact.Home = "test1";
            contact.Mobile = "test1";
            contact.Work = "test1";
            contact.Fax = "test1";
            contact.Email = "test1";
            contact.Email2 = "test1";
            contact.Email3 = "test1";
            contact.Homepage = "test1";
            contact.Address2 = "test1";
            contact.Phone2 = "test1";
            contact.Notes = "test1";
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.Create(contact);
            app.Navigator.ReturnToHomePage();
            Assert.AreEqual(oldContacts.Count+1, app.Contact.GetContactCount());
            List<ContactData> newContacts = app.Contact.GetContactList();
            List<ContactData> oldContactsCopy = new List<ContactData>();
            oldContactsCopy.Add(contact);
            foreach (ContactData cont in oldContacts) 
                {
                    oldContactsCopy.Add(cont);
                }
            oldContactsCopy.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContactsCopy, newContacts);

        }
    }
}
