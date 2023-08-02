using System;
using System.Collections.Generic;
using System.Linq;
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
            if (app.Contact.IsContactPresent())
            {
                app.Contact.Remove(1);
            }
            else
            {
                ContactData contactForRemove = new ContactData();
                contactForRemove.Firstname = "test";
                contactForRemove.Middlename = "test";
                contactForRemove.Lastname = "test";
                app.Contact.Create(contactForRemove);
                app.Navigator.ReturnToHomePage();
                app.Contact.Remove(1);
            }
            
            app.Navigator.GoToHomePage();
        }
    }
}
