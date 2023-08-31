using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTest() { 

            app.Navigator.GoToGroupsPage();
            List<GroupData> oldGroups = GroupData.GetAll();                       
            if (app.Group.IsGroupPresent())
            {
                GroupData toBeRemoved = oldGroups[0];
                app.Group.Remove(toBeRemoved);
            }
            else 
            {
                GroupData groupForRemove = new GroupData("test name");
                groupForRemove.Header = "test header";
                groupForRemove.Footer = "test footer";
                app.Group.Create(groupForRemove);
                app.Navigator.ReturnToGroupsPage();
                oldGroups = GroupData.GetAll();
                app.Group.Remove(groupForRemove);
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
            List<GroupData> newGroups = GroupData.GetAll();
            if (oldGroups.Count>0)
            {
                oldGroups.RemoveAt(0);
            } 
            
            Assert.AreEqual(oldGroups, newGroups);

        }

    }
}
