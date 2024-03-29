﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
         
        [Test]
        public void ContactModifitacionTest()
        {
            ContactData contact = new ContactData("NEWCONTACT", "NEWCONTACT");
            contact.Middlename = "testUpdate";
            contact.Nickname = "testUpdate";
            contact.Title = "testUpdate";
            contact.Company = "testUpdate";
            contact.Address = "testUpdate";
            contact.Home = "testUpdate";
            contact.Mobile = "testUpdate";
            contact.Work = "testUpdate";
            contact.Fax = "testUpdate";
            contact.Email = "testUpdate";
            contact.Email2 = "testUpdate";
            contact.Email3 = "testUpdate";
            contact.Homepage = "testUpdate";          
            contact.Address2 = "testUpdate";
            contact.Phone2 = "testUpdate";
            contact.Notes = "testUpdate";
            app.Navigator.GoToHomePage();
            List<ContactData> oldContacts = ContactData.GetAll();          
            if (app.Contact.IsContactPresent()) 
            {
                ContactData toBeModificate = oldContacts[0];
                app.Contact.Modificate(toBeModificate, contact);
            }
            else
            {
                ContactData contactForModificate = new ContactData("test", "test");
                app.Contact.Create(contactForModificate);
                app.Navigator.ReturnToHomePage();
                oldContacts = ContactData.GetAll();
                ContactData newToBeModificate = oldContacts[0];
                app.Contact.Modificate(newToBeModificate, contact);
            }          
            app.Navigator.ReturnToHomePage();
            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].Lastname = contact.Lastname;
            oldContacts[0].Firstname = contact.Firstname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}

