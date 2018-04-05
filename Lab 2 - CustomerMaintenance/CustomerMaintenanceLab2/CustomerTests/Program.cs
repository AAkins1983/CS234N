using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerMaintenanceClasses;

namespace CustomerTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestCustomerConstructors();
            //TestCustomerPropertyGetters();
            //TestCustomerPropertySetters();
            //TestCustomerFirstNameException();

            //TestCustomerList2Constructor();
            //TestCustomerListFill();
            //TestCustomerList2Fill();
            //TestCustomerListAdd();
            //TestCustomerList2Add();
            //TestCustomerListRemove();
            //TestCustomerListIndexers();

            //TestCustomerClone();
            TestForEach();

            //TestWSCustomer();
            //TestRCustomer();


            Console.WriteLine();
            Console.ReadLine();

        }

        static void TestCustomerClone()
        {
            Customer c1 = new Customer(
                "Mickey", "Mouse", "mmouse@disney.com");
            Customer c2 = (Customer)c1.Clone();
            Console.WriteLine("Testing Clone");
            Console.WriteLine("These should be the same");
            Console.WriteLine("c1 is " + c1);
            Console.WriteLine("c2 is " + c2);
            c1.FirstName = "Edited";
            Console.WriteLine("After edited they should be different.");
            Console.WriteLine("c1 is " + c1);
            Console.WriteLine("c2 is " + c2);         
        }

        static void TestForEach()
        {
            CustomerList cL = new CustomerList();
            foreach(Customer c in cL)
            {
                CustomerList cL = new CustomerList();
                Customer c1 = new Customer(
                    "Mickey", "Mouse", "mmouse@disney.com");
                Customer c2 = new Customer(
                    "Mickey", "Mouse", "mmouse@disney.com");
                cL.Add(c1);
                cL.Add(c2);
                foreach (Customer c in cL)
                {
                    Console.WriteLine(c);
                }
            }
        }

        static void TestWSCustomer()
        {
            WholesaleCustomer wC = new WholesaleCustomer("Mickey", "Mouse", "mmouse@disney.com", "Disney"); // Creates new wholesale customer
            Console.WriteLine("Testing the overloaded constructor");
            Console.WriteLine("Expecting Mickey with Disney as company " + wC); // WC works because we overrode ToString
            
            Console.WriteLine("Testing setters");
            wC.Company = "Disney";
            Console.WriteLine("Expecting Disney " + wC.Company);

            Console.WriteLine("Testing getters");
            Console.WriteLine("Expecting Disney" + " " + wC.Company);
        }

        static void TestRCustomer()
        {
            RetailCustomer rC = new RetailCustomer("Mickey", "Mouse", "mmouse@disney.com", "555-555-5555"); // Creates new retail customer
            Console.WriteLine("Testing the overloaded constructor");
            Console.WriteLine("Expecting Mickey Mouse mmouse@disney.com with 555-555-5555 phone number " + rC); // rC works because we overrode ToString

            Console.WriteLine("Testing setters");
            rC.Phone = "555-555-5555";
            Console.WriteLine("Expecting 555-555-5555 " + rC.Phone);

            Console.WriteLine("Testing getters");
            Console.WriteLine("Expecting 555-555-5555" + " " + rC.Phone);
        }

        static void TestCustomerListConstructor()
        {
            CustomerList cList = new CustomerList();

            Console.WriteLine("Testing constructor");
            Console.WriteLine("Default constructor.  Expecting count of 0 " + cList.Count);
            Console.WriteLine("Default constructor.  Expecting empty string " + cList);
            Console.WriteLine();
        }

        static void TestCustomerList2Constructor()
        {
            CustomerList2 cList = new CustomerList2();

            Console.WriteLine("Testing constructor");
            Console.WriteLine("Default constructor.  Expecting count of 0 " + cList.Count);
            Console.WriteLine("Default constructor.  Expecting empty string " + cList);
            Console.WriteLine();
        }

        static void TestCustomerListFill()
        {
            CustomerList cList = new CustomerList();
            cList.Fill();

            Console.WriteLine("Testing Fill");
            Console.WriteLine("Expecting count of 3 " + cList.Count);
            Console.WriteLine("Expecting list of 3 Customers:\n" + cList);
            Console.WriteLine();
        }

        static void TestCustomerList2Fill()
        {
            CustomerList2 cList = new CustomerList2();
            cList.Fill();

            Console.WriteLine("Testing Fill");
            Console.WriteLine("Expecting count of 3 " + cList.Count);
            Console.WriteLine("Expecting list of 3 Customers:\n" + cList);
            Console.WriteLine();
        }

        static void TestCustomerListAdd()
        {
            CustomerList cList = new CustomerList();
            Customer c1 = new Customer(
                "Mickey", "Mouse", "mmouse@disney.com");
            Customer c3 = new Customer(
                "Minnie", "Mouse", "minniemouse@disney.com");

            Console.WriteLine("Testing Add");
            cList.Add(c1);
            Console.WriteLine("Add that takes a Customer parameter");
            Console.WriteLine("Expecting count of 1 " + cList.Count);
            Console.WriteLine("Expecting list of 1 Customers:\n" + cList);
            cList.Add("Donald", "Duck", "dduck@disney.com");
            Console.WriteLine("Add that takes individual Customer attributes and constructs a Customer");
            Console.WriteLine("Expecting count of 2 " + cList.Count);
            Console.WriteLine("Expecting list of 2 Customers:\n" + cList);
            cList += c3;
            Console.WriteLine("+ operator");
            Console.WriteLine("Expecting count of 3 " + cList.Count);
            Console.WriteLine("Expecting list of 3 Customers:\n" + cList);
            Console.WriteLine();
        }

        static void TestCustomerList2Add()
        {

        }

        static void TestCustomerListRemove()
        {
            CustomerList cList = new CustomerList();
            Customer c1 = new Customer(
                "Mickey", "Mouse", "mmouse@disney.com");
            Customer c3 = new Customer(
                "Minnie", "Mouse", "minniemouse@disney.com");

            cList.Add(c1);
            cList.Add("Donald", "Duck", "dduck@disney.com");
            cList += c3;

            Console.WriteLine("Testing Remove");
            Console.WriteLine("Remove with same object");
            cList.Remove(c1);
            Console.WriteLine("Expecting count of 2 " + cList.Count);
            Console.WriteLine("Expecting list of 2 Customers.  Mickey is not in the list:\n" + cList);
            cList -= c3;
            Console.WriteLine("- operator");
            Console.WriteLine("Expecting count of 1 " + cList.Count);
            Console.WriteLine("Expecting list of 1 Customers.  Minnie is not in the list:\n" + cList);
            Console.WriteLine();
            cList.Remove(new Customer("Donald", "Duck", "dduck@disney.com"));
            Console.WriteLine("Remove with object that has the same attributes but NOT the same object.\n" +
                "WON'T WORK AT THIS POINT.  CHAPTER 14 will talk about the method Equals.");
            Console.WriteLine("Expecting count of 0 " + cList.Count);
            Console.WriteLine("Expecting list of 0 Customers.  Donald should not be in the list:\n" + cList);
        }

        static void TestCustomerListIndexers()
        {
            CustomerList cList = new CustomerList();
            Customer c1 = new Customer(
                "Mickey", "Mouse", "mmouse@disney.com");
            Customer c3 = new Customer(
                "Minnie", "Mouse", "minniemouse@disney.com");

            cList.Add(c1);
            cList.Add("Donald", "Duck", "dduck@disney.com");
            cList += c3;

            Console.WriteLine("Testing indexer");
            Console.WriteLine("Get Customer with index 0");
            Customer c4 = cList[0];
            Console.WriteLine("Expecting Mickey. " + c4);
            Console.WriteLine("Shouldn't alter the list. Expecting count of 3 " + cList.Count);
            Console.WriteLine("Expecting list of 3 Customers.  Mickey is the first element in list:\n" + cList);

            Console.WriteLine("Get Customer with email of minniemouse@disney.com");
            Customer c5 = cList["minniemouse@disney.com"];
            Console.WriteLine("Expecting Minnie " + c5);
            Console.WriteLine("Shouldn't alter the list. Expecting count of 3 " + cList.Count);
            Console.WriteLine("Expecting list of 3 Customers.  Minnie is the third element in list:\n" + cList);

            Console.WriteLine("Set Customer with index 0");
            cList[0] = c3;
            Console.WriteLine("Shouldn't alter the length of the list. Expecting count of 3 " + cList.Count);
            Console.WriteLine("Expecting list of 3 Customers.  Minie is the first element in list as well as the last:\n" + cList);

            // I didn't test the indexer with a number < 0 or > the length of the list, but I should have
            // I didn't test the indexer with a Customer code that's not in the list, but I should have.
        }

        static void TestCustomerConstructors()
        {
            Customer c1 = new Customer();
            Customer c2 = new Customer(
                "Mickey", "Mouse", "mmouse@disney.com");

            Console.WriteLine("Testing both constructors");
            Console.WriteLine("Default constructor.  Expecting default values. " 
                + c1.ToString());
            Console.WriteLine(
                "Overloaded constructor.  Expecting Mickey Mouse (mmouse@disney.com). " + c2);
            Console.WriteLine();
        }

        static void TestCustomerPropertyGetters()
        {
            Customer c1 = new Customer(
                "Mickey", "Mouse", "mmouse@disney.com");

            Console.WriteLine("Testing getters");
            Console.WriteLine("FirstName.  Expecting Mickey. " + c1.FirstName);
            Console.WriteLine("LastName.  Expecting Mouse " + c1.LastName);
            Console.WriteLine("Email.  Expecting mmouse@disney.com. " + c1.Email);
            Console.WriteLine();
        }

        static void TestCustomerPropertySetters()
        {
            Customer c1 = new Customer(
                "Mickey", "Mouse", "mmouse@disney.com");

            Console.WriteLine("Testing setters");
            c1.FirstName = "Donald";
            c1.LastName = "Duck";
            c1.Email = "dduck@disney.com";
            Console.WriteLine("Expecting Donald Duck (dduck@disney.com) " 
                + c1);
            Console.WriteLine();
        }

        static void TestCustomerFirstNameException()
        {
            Customer c1 = new Customer(
                 "Mickey", "Mouse", "mmouse@disney.com");
            try
            {
                Console.WriteLine("Testing First Name Empty.  Expecting an exception");
                c1.FirstName = "";
                Console.WriteLine("I should never see this message.");
            }
            catch (ArgumentOutOfRangeException ae)
            {
                Console.WriteLine(ae.Message);
            }
            try
            {
                Console.WriteLine("Testing First Name tooo long.  Expecting an exception");
                c1.FirstName = "ahlkjfdhlaksjdfhlkajhdfdlkjafhlkdsjahflkdjahkdsfjllajsdfhlaksjdfhlakjshdflkasjdhfksjahdfkjashflkdjaahsfkljsahdflkjashfldjkashflkjsahlfkdjahlfkdsjl";
                Console.WriteLine("I should never see this message.");
            }
            catch (ArgumentOutOfRangeException ae)
            {
                Console.WriteLine(ae.Message);
            }

        }

    }
}
