using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using MTDClasses;

namespace MTDUnitTests
{
    public class PrivateTrainTests
    {
        //Instance variables
        Hand h1;
        PrivateTrain pt1;
        PrivateTrain pt2;
        Hand myHand;
        Hand yourHand;
        Domino d11;
        Domino d14;
        Domino d13;
        Domino d34;
        Domino d31;
        Domino d55;

        [SetUp]
        public void SetUpAllTests()
        {
            h1 = new Hand();
            pt1 = new PrivateTrain(h1);
            pt2 = new PrivateTrain(h1, 7);
            myHand = new Hand();
            yourHand = new Hand();
            d11 = new Domino(1, 1);
            d13 = new Domino(1, 3);
            d14 = new Domino(1, 4);
            d31 = new Domino(3, 1);
            d34 = new Domino(3, 4);
            d55 = new Domino(5, 5);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual(false, pt1.IsOpen);
            Assert.AreEqual(7, pt2.EngineValue);
        }

        [Test]
        public void TestOpen()
        {
            pt1.Open();
            Assert.AreEqual(true, pt1.IsOpen);
        }

        [Test]
        public void TestClose()
        {
            pt1.Open();
            Assert.AreEqual(true, pt1.IsOpen);
            pt1.Close();
            Assert.AreEqual(false, pt1.IsOpen);
        }

        [Test]
        public void TestIsPlayable()
        {
            bool flip = false;
            PrivateTrain myTrain = new PrivateTrain(myHand, 3);
            Assert.True(myTrain.IsPlayable(d31, out flip, myHand));
            Assert.False(myTrain.IsPlayable(d55, out flip, myHand));
            Assert.False(myTrain.IsPlayable(d31, out flip, yourHand));
            myTrain.Open();
            Assert.True(myTrain.IsPlayable(d31, out flip, yourHand));
        }

        [Test]
        public void TestPlay()
        {
            pt1.add(d13);
            pt1.add(d14);
            pt1.play(d14);
            Assert.AreEqual(1, pt1.PlayableValue);
            Assert.AreEqual(3, pt1.Count);
        }
    }
}
