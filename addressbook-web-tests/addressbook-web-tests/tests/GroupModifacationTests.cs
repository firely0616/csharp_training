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
            GroupData group = new GroupData("test update");
            group.Header = "test header update";
            group.Footer = "test footer update";
            app.Navigator.GoToGroupsPage();
            List<GroupData> oldGroups = app.Group.GetGroupList();
            if (app.Group.IsGroupPresent())
            {
                app.Group.Modificate(1, group);
            }
            else
            {
                GroupData groupForModificate = new GroupData("test name");
                groupForModificate.Header = "test header";
                groupForModificate.Footer = "test footer";
                app.Group.Create(groupForModificate);
                app.Navigator.ReturnToGroupsPage();
                app.Group.Modificate(1, group);
            }           
            app.Navigator.ReturnToGroupsPage();
            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups[0].Name = group.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
