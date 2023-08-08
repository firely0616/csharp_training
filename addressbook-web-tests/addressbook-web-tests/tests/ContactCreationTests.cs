using System;
using System.Collections.Generic;
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
            ContactData contact = new ContactData("test1", "test1");           
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
            contact.Bday = "15";
            contact.Bmonth = "December";
            contact.Byear = "2001";
            contact.Aday = "11";
            contact.Amonth = "November";
            contact.Ayear = "1999";
            contact.Address2 = "test1";
            contact.Phone2 = "test1";
            contact.Notes = "test1";
            contact.Photo = "C:\\Users\\gohot\\2022-07-28.png";
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.Create(contact);
            app.Navigator.ReturnToHomePage();
            Assert.AreEqual(oldContacts.Count+1, app.Contact.GetContactCount());
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }







    }
}
