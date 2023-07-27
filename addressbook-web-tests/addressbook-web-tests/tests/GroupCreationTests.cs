using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
    
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData();
            group.Name = "test name";
            group.Header = "test header";
            group.Footer = "test footer";
           
            app.Group.Create(group);
            app.Navigator.ReturnToGroupsPage();
            app.Auth.Logout();
        }

       
    }
}
