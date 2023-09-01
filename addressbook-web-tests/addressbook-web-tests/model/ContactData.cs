using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB.Mapping;
using NUnit.Framework;
using OpenQA.Selenium.Remote;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string allPhones;

        public ContactData(string lastname, string firstname) 
        {
            Lastname = lastname;
            Firstname = firstname;          
        }
        public ContactData()
        {
            
        }
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(other, this))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }
        public override int GetHashCode()
        {
            return Lastname.GetHashCode() + Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return "lastname = " + Lastname + " firstname = " + Firstname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            else
            {
                return Lastname.CompareTo(other.Lastname);
            }
        }
        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id
        {
            get; set;
        }
        [Column(Name = "firstname")]
        public string Firstname
        {
            get; set;
        }

        public string Photo
        {
            get; set;

        }
        [Column(Name = "homepage")]
        public string Homepage
        {
            get; set;

        }
        [Column(Name = "email")]
        public string Email
        {
            get; set;

        }
        [Column(Name = "email2")]
        public string Email2
        {
            get; set;

        }
        [Column(Name = "email3")]
        public string Email3
        {
            get; set;

        }
        [Column(Name = "work")]
        public string Work
        {
            get; set;

        }
        [Column(Name = "fax")]
        public string Fax
        {
            get; set;

        }
        [Column(Name = "mobile")]
        public string Mobile
        {
            get; set;

        }
        [Column(Name = "middlename")]
        public string Middlename
        {
            get; set;

        }
        [Column(Name = "nickname")]
        public string Nickname
        {
            get; set;

        }
        [Column(Name = "lastname")]
        public string Lastname
        {
            get; set;

        }
        [Column(Name = "title")]
        public string Title
        {
            get; set;
        }
        [Column(Name = "company")]
        public string Company
        {
            get; set;

        }
        [Column(Name = "address")]
        public string Address
        {
            get; set;

        }
        [Column(Name = "home")]
        public string Home {
            get; set;

        }
        [Column(Name = "bday")]
        public string Bday
        {
            get; set;

        }
        [Column(Name = "bmonth")]
        public string Bmonth
        {
            get; set;

        }
        [Column(Name = "byear")]
        public string Byear
        {
            get; set;

        }
        [Column(Name = "aday")]
        public string Aday
        {
            get; set;

        }
        [Column(Name = "amonth")]
        public string Amonth
        {
            get; set;

        }
        [Column(Name = "ayear")]
        public string Ayear
        {
            get; set;

        }
        [Column(Name = "address2")]
        public string Address2
        {
            get; set;

        }
        [Column(Name = "phone2")]
        public string Phone2
        {
            get; set;

        }
        [Column(Name = "notes")]
        public string Notes
        {
            get; set;

        }
        public string AllPhones
        {
            get 
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUpPhone(Home) + CleanUpPhone(Mobile) + CleanUpPhone(Work) + CleanUpPhone(Phone2)).Trim();
                }
            }

            set 
            {
                allPhones = value;
            }

        }
        public string allInfo = null;
        public string AllInfo
        {
            get 
            {
                if (allInfo == null)
                {
                    if (Firstname != null && Firstname != "")  allInfo += Firstname; 
                    if (Middlename != null && Middlename != "")  allInfo += " " + Middlename; 
                    if (Lastname != null && Lastname != "") allInfo += " " + Lastname;

                    if (Nickname != null && Nickname != "") allInfo += "\r\n" + Nickname ;

                    if (Title != null && Title != "") allInfo += "\r\n" + Title;

                    if (Company != null && Company != "") allInfo += "\r\n" + Company;

                    if (Address != null && Address != "") allInfo += "\r\n" + Address;

                    if (Home != null && Home != "") allInfo += "\r\n\r\n" + "H: " + Home; else allInfo += "\r\n";

                    if (Mobile != null && Mobile != "") allInfo +="\r\nM: " + Mobile;

                    if (Work != null && Work != "") allInfo += "\r\n" + "W: " + Work;

                    if (Fax != null && Fax != "") allInfo += "\r\n" + "F: " + Fax ;

                    if (Email != null && Email != "") allInfo += "\r\n\r\n" + Email;

                    if (Email2 != null && Email2 != "") allInfo += "\r\n" + Email2 ;

                    if (Email3 != null && Email3 != "") allInfo += "\r\n" + Email3 ;

                    if (Homepage != null && Homepage != "") allInfo += "\r\n" + "Homepage:\r\n" + Homepage;

                    if (Address2 != null && Address2 != "") allInfo += "\r\n\r\n\r\n" + Address2 ;

                    if (Phone2 != null && Phone2 != "") allInfo += "\r\n\r\n" + "P: " + Phone2;

                    if (Notes != null && Notes != "")  allInfo += "\r\n\r\n" + Notes;

                    return allInfo;
                }
                return allInfo;                       
            }
            set
            {
                allInfo = value;
            }
        }
        public string CleanUpPhone(string phone)
        {
            if (phone == null || phone == "") 
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }
        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts select g).ToList();
            }
        }
    }
}
