using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class GroupModifacationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("test update");
            group.Header = "test header update";
            group.Footer = "test footer update";
            app.Navigator.GoToGroupsPage();
            List<GroupData> oldGroups = GroupData.GetAll();           
            if (app.Group.IsGroupPresent())
            {
                GroupData toBeModificate = oldGroups[0];
                app.Group.Modificate(toBeModificate, group);
            }
            else
            {
                GroupData groupForModificate = new GroupData("test name");
                groupForModificate.Header = "test header";
                groupForModificate.Footer = "test footer";
                app.Group.Create(groupForModificate);
                app.Navigator.ReturnToGroupsPage();
                oldGroups = GroupData.GetAll();
                GroupData newToBeModificate = oldGroups[0];
                app.Group.Modificate(newToBeModificate, group);
            }           
            app.Navigator.ReturnToGroupsPage();
            Assert.AreEqual(oldGroups.Count, app.Group.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = group.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
