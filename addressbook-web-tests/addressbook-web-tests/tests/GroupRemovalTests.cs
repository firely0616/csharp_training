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
            List<GroupData> oldGroups = app.Group.GetGroupList();
            if (app.Group.IsGroupPresent())
            {
                app.Group.Remove(1);
            }
            else 
            {
                GroupData groupForRemove = new GroupData("test name");
                groupForRemove.Header = "test header";
                groupForRemove.Footer = "test footer";
                app.Group.Create(groupForRemove);
                app.Navigator.ReturnToGroupsPage();
                app.Group.Remove(1);
            }          
            app.Navigator.ReturnToGroupsPage();
            if (oldGroups.Count<=0)
            {
                Assert.AreEqual(oldGroups.Count, app.Group.GetGroupCount());
            }
            else
            {
                Assert.AreEqual(oldGroups.Count - 1, app.Group.GetGroupCount());
            }
            List<GroupData> newGroups = app.Group.GetGroupList();
            if (oldGroups.Count>0)
            {
                oldGroups.RemoveAt(0);
            }          
            Assert.AreEqual(oldGroups, newGroups);

        }

    }
}
