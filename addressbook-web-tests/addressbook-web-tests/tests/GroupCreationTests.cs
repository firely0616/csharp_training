﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomDataProvider() 
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData (GenerateRandomString(30))
                    {
                    Header = GenerateRandomString(30),
                    Footer = GenerateRandomString(30)
                    });
            }
            return groups;  
        }

        [Test, TestCaseSource("RandomDataProvider")]
        public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Group.Create(group);
            app.Navigator.ReturnToGroupsPage();
            Assert.AreEqual(oldGroups.Count+1, app.Group.GetGroupCount());
            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

       
    }
}
