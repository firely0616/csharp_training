using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Navigator.GoToHomePage();
            List<ContactData> oldContacts = app.Contact.GetContactList();
            if (app.Contact.IsContactPresent())
            {
                app.Contact.Remove(1);
            }
            else
            {
                ContactData contactForRemove = new ContactData("test","test");
                app.Contact.Create(contactForRemove);
                app.Navigator.ReturnToHomePage();
                app.Contact.Remove(1);               
            }
            System.Threading.Thread.Sleep(2000);
            app.Navigator.GoToHomePage();
            List<ContactData> newContacts = app.Contact.GetContactList();
            if (oldContacts.Count>0) 
            {
                oldContacts.RemoveAt(0);
            }          
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
