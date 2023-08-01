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
            app.Group.Modificate(1, group);
            app.Navigator.ReturnToGroupsPage();

        }
    }
}
