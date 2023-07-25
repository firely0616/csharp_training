using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
    
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Group.InitGroupCreation();
            GroupData group = new GroupData();
            group.Name = "test name";
            group.Header = "test header";
            group.Footer = "test footer";
            app.Group.FillGroupForm(group);
            app.Group.SubmitGroupCreation();
            app.Navigator.ReturnToGroupsPage();
            app.Auth.Logout();
        }

       
    }
}
