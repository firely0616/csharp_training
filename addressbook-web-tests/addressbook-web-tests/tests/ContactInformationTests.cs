﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation() 
        {
            ContactData fromTable = app.Contact.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(1);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);


        }
        [Test]
        public void TestContactDetails() 
        {
            ContactData fromDetails = app.Contact.GetContactInformationFromDetails(1);
            ContactData fromEdit = app.Contact.GetContactInformationFromEditForm(1);
            Assert.AreEqual(fromEdit.AllInfo, fromDetails.AllInfo);

        }

    }
}
