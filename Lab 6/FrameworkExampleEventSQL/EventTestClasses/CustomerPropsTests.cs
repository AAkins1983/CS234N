using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EventPropsClasses;
using EventPropsClassses;

namespace EventTestClasses
{
    [TestFixture]
    public class CustomerPropsTests
    {
        private CustomerProps c;

        [SetUp]
        public void SetUpTests()
        {
            c = new CustomerProps();
            c.ID = 10;
            c.Name = "Flavor Flav";
            c.Address = "123 ABC Drive";
            c.City = "Hollywood";
            c.State = "California";
            c.ZipCode = 12345;
            c.ConcurrencyID = 1;
        }

        [Test]
        public void TestClone()
        {
            CustomerProps newC = (CustomerProps)c.Clone();
            Assert.AreEqual(c.ID, newC.ID);
            Assert.AreEqual(c.Name, newC.Name);
            Assert.AreEqual(c.Address, newC.Address);
            Assert.AreEqual(c.City, newC.City);
            Assert.AreEqual(c.State, newC.State);
            Assert.AreEqual(c.ZipCode, newC.ZipCode);
            Assert.AreEqual(c.ConcurrencyID, newC.ConcurrencyID);
        }

        [Test]
        public void TestGetState()
        {
            string output = c.GetState();
            Assert.True(output.Contains("This is a test"));
            Console.WriteLine(output);
        }

        [Test]
        public void TestSetState()
        {
            string output = c.GetState();
            CustomerProps newC = new CustomerProps();
            newC.SetState(output);
            Assert.AreEqual(c.ID, newC.ID);
            Assert.AreEqual(c.Name, newC.Name);
            Assert.AreEqual(c.Address, newC.Address);
            Assert.AreEqual(c.City, newC.City);
            Assert.AreEqual(c.State, newC.State);
            Assert.AreEqual(c.ZipCode, newC.ZipCode);
            Assert.AreEqual(c.ConcurrencyID, newC.ConcurrencyID);
        }
    }
}
