using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        
      

        public ContactData(string lastname, string firstname) 
        {
            Lastname = lastname;
            Firstname = firstname;          
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

                throw new ArgumentException(String.Format("error"));

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



    }
}
