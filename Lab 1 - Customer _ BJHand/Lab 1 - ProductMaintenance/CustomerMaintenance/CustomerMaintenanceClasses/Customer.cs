using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMaintenanceClasses
{
    public class Customer
    {
        private string fName;
        private string lName;
        private string eMail;

        public Customer()
        {
        }

        public Customer(string first, string last, string mail)
        {
            FirstName = first;
            LastName = last;
            Email = mail;
        }

        public string FirstName
        {
            get
            {
                return fName;
            }
            set
            {
                if (value.Length > 0 && value.Length <= 50)
                    fName = value;
                else
                    throw new ArgumentOutOfRangeException("First Name must be between 1 and 50 characters");
            }
        }

        public string LastName
        {
            get
            {
                return lName;
            }
            set
            {
                lName = value;
            }
        }

        public string Email
        {
            get
            {
                return eMail;
            }
            set
            {
                eMail = value;
            }
        }

        
        public override string ToString()
        {
            return fName + " " + lName + " (" + eMail + ")";
        }
        
    }
}
