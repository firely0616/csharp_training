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
            app.Group.Remove(1);
            app.Navigator.ReturnToGroupsPage();
        }

    }
}
