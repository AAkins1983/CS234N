using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using MTDClasses;

namespace MTDUnitTests
{
    [TestFixture]
    public class HandTests
    {
        // Instance variables
        Domino def;
        Domino d12;
        Domino d21;
        Domino d33;

        [SetUp] // Runs before every test
        public void SetUpAllTests()
        {
            def = new Domino();
            d12 = new Domino(1, 2);
            d21 = new Domino(2, 1);
            d33 = new Domino(3, 3);
        }

        [Test]
        public void HandTestCount()
        {
            Hand h = new Hand();
            h.add(d12);
            h.add(d21);
            Assert.AreEqual(2, h.Count);
        }

        [Test]
        public void HandTestIsEmpty()
        {
            Hand h = new Hand();
            Assert.AreEqual(true, h.isEmpty);
            h.add(d12);
            h.add(d21);
            Assert.AreEqual(false, h.isEmpty);
            Assert.IsFalse(h.isEmpty);
        }

        [Test]
        //I don't think this is right??
        public void HandTestIndexOfDomino()
        {
            Hand h = new Hand();
            h.add(d12);
            h.add(d33);
            Assert.AreEqual(d12, h[0]);
        }
    }
}
