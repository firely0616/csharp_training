using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroupTest()
        {
            List<GroupData> groupList = GroupData.GetAll();
            List<ContactData> contactList = ContactData.GetAll();
            if (groupList.Count == 0)
            {
                app.Group.Create(new GroupData("test"));
                groupList = GroupData.GetAll();
            }
            if (contactList.Count == 0)
            {
                app.Contact.Create(new ContactData("test","test"));
                contactList = ContactData.GetAll();
            }
            int count = 0;
            foreach(GroupData g in groupList)
            {
                List<ContactData> contactsInGroup = g.GetContacts();
                contactList.Sort();
                contactsInGroup.Sort();
                if (contactList.Count()!=contactsInGroup.Count())
                {
                    ContactData contact = contactList.Except(contactsInGroup).First();
                    List<ContactData> oldList = g.GetContacts();
                    app.Contact.AddContatToGroup(contact, g);
                    List<ContactData> newList = g.GetContacts();
                    oldList.Add(contact);
                    oldList.Sort();
                    newList.Sort();
                    Assert.AreEqual(oldList, newList);
                    break;
                }
                count++;
                if (count == groupList.Count())
                {
                    app.Contact.Create(new ContactData("test1", "test1"));
                    contactList = ContactData.GetAll();
                    ContactData contact = contactList.Except(contactsInGroup).First();
                    List<ContactData> oldList = g.GetContacts();
                    app.Contact.AddContatToGroup(contact, g);
                    List<ContactData> newList = g.GetContacts();
                    oldList.Add(contact);
                    oldList.Sort();
                    newList.Sort();
                    Assert.AreEqual(oldList, newList);
                }

               
            }

        }
    }
}
