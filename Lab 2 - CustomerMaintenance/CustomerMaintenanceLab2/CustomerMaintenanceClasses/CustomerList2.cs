using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerMaintenanceClasses
{
    public class CustomerList2 : List<Customer>
    {
        public CustomerList2() : base() { } // Default constructor

        public void Fill()
        {
            //this = CustomerDB.GetCustomers();

            List<Customer> customers = CustomerDB.GetCustomers();
            foreach (Customer c in customers)
                this.Add(c);
        }

        public void Save()
        {
            CustomerDB.SaveCustomers(this);
        }

        public void Add(string first, string last, string email)
        {
            Customer c = new Customer(first, last, email);
            Add(c);
        }

        public Customer this[string email]
        {
            get
            {
                foreach (Customer c in this)
                {
                    if (c.Email == email)
                        return c;
                }
                return null;
            }
        }

        public static CustomerList2 operator +(CustomerList2 cl, Customer c)
        {
            cl.Add(c);
            return cl;
        }

        public static CustomerList2 operator -(CustomerList2 cl, Customer c)
        {
            cl.Remove(c);
            return cl;
        }

        public override string ToString()
        {
            string output = "";
            foreach (Customer c in this)
            {
                output += c.ToString() + "\n";
            }
            return output;
        }
    }
}
