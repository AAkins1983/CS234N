using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerMaintenanceClasses
{
    public class RetailCustomer : Customer
    {
        private string phoneNum;

        public RetailCustomer() { }

        public RetailCustomer(string first, string last, string mail, string phone)
            : base(first, last, mail) // Overloaded constructor
        {
            phoneNum = phone;
        }

        public string Phone
        {
            get { return phoneNum; }
            set { phoneNum = value; }
        }

        public override string ToString()
        {
            return base.ToString() + " Phone Number: " + Phone;
        }

    }
}
