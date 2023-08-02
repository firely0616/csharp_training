using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class GroupModifacationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData();
            group.Name = "test update";
            group.Header = "test header update";
            group.Footer = "test footer update";
            app.Navigator.GoToGroupsPage();
            if (app.Contact.IsContactPresent())
            {
                app.Group.Modificate(1, group);
            }
            else
            {
                GroupData groupForModificate = new GroupData();
                groupForModificate.Name = "test name";
                groupForModificate.Header = "test header";
                groupForModificate.Footer = "test footer";
                app.Group.Create(groupForModificate);
                app.Navigator.ReturnToGroupsPage();
                app.Group.Modificate(1, group);
            }
            
            app.Navigator.ReturnToGroupsPage();

        }
    }
}
