//WholesaleCustomer

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerMaintenanceClasses
{
    public class WholesaleCustomer : Customer
    {
        private string company; // Instance variable

        public WholesaleCustomer() { } // Default constructor

        public WholesaleCustomer(string first, string last, string mail, string comp)
            : base(first, last, mail) // Overloaded constructor
        {
            company = comp;
        }

        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public override string ToString()
        {
            return base.ToString() + " works for " + Company;
        }
    }
}