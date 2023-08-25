using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WebAddressbookTests;
using Newtonsoft.Json;

namespace addressbook_test_data_generators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeData = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter streamWriter = new StreamWriter(args[2]);
            string format = args[3];

            List<GroupData> groups = new List<GroupData>();
            List<ContactData> contacts = new List<ContactData>();

            if (typeData == "group")
            {
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }
            }
            else if (typeData == "contact")
            {              
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                    {
                        Middlename = TestBase.GenerateRandomString(10),
                        Nickname = TestBase.GenerateRandomString(10),
                        Company = TestBase.GenerateRandomString(10),
                        Address = TestBase.GenerateRandomString(10)
                    });
                }
            }
            else Console.Out.Write("Unrecognized data type " + typeData);


            if (format == "csv")
            {
               if (typeData == "group") writeGroupsToCsvFile(groups, streamWriter);
               if (typeData == "contact") writeContactsToCsvFile(contacts, streamWriter);
            }
            else if (format == "xml")
            {
                if (typeData == "group") writeGroupsToXmlFile(groups, streamWriter);
                if (typeData == "contact") writeContactsToXmlFile(contacts, streamWriter);
            }
            else if (format == "json")
            {
                if (typeData == "group") writeGroupsToJsonFile(groups, streamWriter);
                if (typeData == "contact") writeContactsToJsonFile(contacts, streamWriter);
            }
            else Console.Out.Write("Unrecognized format " + format);
            streamWriter.Close();
        }
        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter streamWriter)
        {
            foreach(GroupData group in groups)
            {
                streamWriter.WriteLine(String.Format("${0},${1},${2}", group.Name, group.Header, group.Footer));
            }
        }
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter streamWriter) 
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(streamWriter, groups);
        }
        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter streamWriter)
        {
            streamWriter.Write(JsonConvert.SerializeObject(groups, Formatting.Indented));
        }


        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter streamWriter)
        {
            foreach (ContactData contact in contacts)
            {
                streamWriter.WriteLine(String.Format("${0},${1},${2},${3},${4},${5}", contact.Firstname, contact.Lastname, contact.Middlename, contact.Nickname, contact.Company, contact.Address));
            }
        }
        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter streamWriter)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(streamWriter, contacts);
        }
        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter streamWriter)
        {
            streamWriter.Write(JsonConvert.SerializeObject(contacts, Formatting.Indented));
        }
    }
}
