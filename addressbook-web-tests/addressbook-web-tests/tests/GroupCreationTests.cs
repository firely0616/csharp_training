using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
    
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("test name");            
            group.Header = "test header";
            group.Footer = "test footer";
            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Group.Create(group);
            app.Navigator.ReturnToGroupsPage();
            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

       
    }
}
