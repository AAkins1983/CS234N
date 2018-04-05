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
    public class ProductPropsTests
    {
        private ProductProps p;
        [SetUp]

        public void SetUpTests()
        {
            p = new ProductProps();
            p.ID = 10;
            p.Code = "p000";
            p.Description = "This is a test";
            p.Quantity = 10;
            p.ConcurrencyID = 1;
        }

        [Test]
        public void TestClone()
        {
            //ProductProps p = new ProductProps();
            //p.ID = 10;
            //p.Code = "p000";
            //p.Description = "This is a test";
            //p.Quantity = 10;
            //p.ConcurrencyID = 1;

            ProductProps newP = (ProductProps)p.Clone();
            Assert.AreEqual(p.ID, newP.ID);
            Assert.AreEqual(p.Code, newP.Code);
            Assert.AreEqual(p.Description, newP.Description);
            Assert.AreEqual(p.Quantity, newP.Quantity);
            Assert.AreEqual(p.ConcurrencyID, newP.ConcurrencyID);
        }

        [Test]
        public void TestGetState()
        {
            string output = p.GetState();
            Assert.True(output.Contains("This is a test"));
            Console.WriteLine(output);
        }

        [Test]
        public void TestSetState()
        {
            string output = p.GetState();
            ProductProps newP = new ProductProps();
            newP.SetState(output);
            Assert.AreEqual(p.ID, newP.ID);
            Assert.AreEqual(p.Code, newP.Code);
            Assert.AreEqual(p.Description, newP.Description);
            Assert.AreEqual(p.Quantity, newP.Quantity);
            Assert.AreEqual(p.ConcurrencyID, newP.ConcurrencyID);
        }
    }
}
