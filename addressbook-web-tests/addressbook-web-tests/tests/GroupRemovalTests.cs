using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest() { 

            app.Navigator.GoToGroupsPage();
            if(app.Group.IsGroupPresent())
            {
                app.Group.Remove(1);
            }
            else 
            {
                GroupData groupForRemove = new GroupData();
                groupForRemove.Name = "test name";
                groupForRemove.Header = "test header";
                groupForRemove.Footer = "test footer";
                app.Group.Create(groupForRemove);
                app.Navigator.ReturnToGroupsPage();
                app.Group.Remove(1);
            }          
            app.Navigator.ReturnToGroupsPage();
        }

    }
}
