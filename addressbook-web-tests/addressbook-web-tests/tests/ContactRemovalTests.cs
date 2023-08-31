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
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Navigator.GoToHomePage();
            List<ContactData> oldContacts = ContactData.GetAll();           
            if (app.Contact.IsContactPresent())
            {
                ContactData contactToBeRemoved = oldContacts[0];
                app.Contact.Remove(contactToBeRemoved);
            }
            else
            {
                ContactData contactForRemove = new ContactData("test","test");
                app.Contact.Create(contactForRemove);
                app.Navigator.ReturnToHomePage();
                oldContacts = ContactData.GetAll();
                app.Contact.Remove(contactForRemove);               
            }
            System.Threading.Thread.Sleep(1000);
            app.Navigator.GoToHomePage();
            if (oldContacts.Count <= 0)
            {
                Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());
            }
            else
            {
                Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());
            }
            List<ContactData> newContacts = ContactData.GetAll();
            if (oldContacts.Count>0) 
            {
                oldContacts.RemoveAt(0);
            }          
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
