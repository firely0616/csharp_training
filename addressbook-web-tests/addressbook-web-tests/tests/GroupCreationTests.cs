using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;
using NUnit.Framework;
using Newtonsoft.Json;


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
        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header= parts[1],
                    Footer= parts[2]
                });
            }
            return groups;
        }
        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));
        }
        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"groups.json"));
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
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
