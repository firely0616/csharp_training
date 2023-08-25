using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Remote;

namespace WebAddressbookTests
{
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
                return -1;
            }
        }

        public string Firstname
        {
            get; set;
        }
        public string Photo
        {
            get; set;

        }
        public string Homepage
        {
            get; set;

        }
        public string Email
        {
            get; set;

        }
        public string Email2
        {
            get; set;

        }
        public string Email3
        {
            get; set;

        }
        public string Work
        {
            get; set;

        }
        public string Fax
        {
            get; set;

        }
        public string Mobile
        {
            get; set;

        }
        public string Middlename
        {
            get; set;

        }
        public string Nickname
        {
            get; set;

        }
        public string Lastname
        {
            get; set;

        }
        public string Title
        {
            get; set;
        }
        public string Company
        {
            get; set;

        }
        public string Address
        {
            get; set;

        }
        public string Home {
            get; set;

        }
        public string Bday
        {
            get; set;

        }
        public string Bmonth
        {
            get; set;

        }
        public string Byear
        {
            get; set;

        }
        public string Aday
        {
            get; set;

        }
        public string Amonth
        {
            get; set;

        }
        public string Ayear
        {
            get; set;

        }
        public string Address2
        {
            get; set;

        }
        public string Phone2
        {
            get; set;

        }
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
    }
}
