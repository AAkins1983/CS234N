using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerMaintenanceClasses
{
    public class CustomerList : IEnumerable<Customer>
    {
        private List<Customer> customers;  // Instance variable of a list of customers

        public CustomerList()
        {
            customers = new List<Customer>();
        }

        public int Count
        {
            get
            {
                return customers.Count;
            }
        }

        public void Fill()
        {
            customers = CustomerDB.GetCustomers();
        }

        public void Save()
        {
            CustomerDB.SaveCustomers(customers);
        }

        public void Add(Customer customer)
        {
            customers.Add(customer);
            //Changed(this);
        }

        public void Add(string first, string last, string email)
        {
            Customer c = new Customer(first, last, email);
            customers.Add(c);
            //Changed(this);
        }

        public void Remove(Customer customer)
        {
            customers.Remove(customer);
            //Changed(this);
        }

        public override string ToString()
        {
            string output = "";
            foreach (Customer c in customers)
            {
                output += c.ToString() + "\n";
            }
            return output;
        }

        public Customer this[int i]
        {
            get
            {
                if (i < 0)
                {
                    throw new ArgumentOutOfRangeException("i");
                }
                else if (i >= customers.Count)
                {
                    throw new ArgumentOutOfRangeException("i");
                }
                return customers[i];
            }
            set
            {
                customers[i] = value;
                //Changed(this);
            }
        }

        public Customer this[string email]
        {
            get
            {
                foreach (Customer c in customers)
                {
                    if (c.Email == email)
                        return c;
                }
                return null;
            }
        }

        public static CustomerList operator +(CustomerList cl, Customer c)
        {
            cl.Add(c);
            return cl;
        }

        public static CustomerList operator -(CustomerList cl, Customer c)
        {
            cl.Remove(c);
            return cl;
        }

        public IEnumerator<Customer> GetEnumerator()
        {
            foreach (Customer c in customers)
            {
                yield return c;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new Exception(
            "The method or operation is not implemented.");
        }

    }
}
