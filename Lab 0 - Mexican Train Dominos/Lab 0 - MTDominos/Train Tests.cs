//Train Tests

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
    public class TrainTests
    {

        [Test]
        public void TrainTestDefConstructor()
        {
            Train t = new Train();
            Assert.AreEqual(0, t.Count);
            Assert.AreEqual(0, t.EngineValue);
            Assert.IsNull(t.LastDomino);
        }

        [Test]
        public void TrainTestOverloadedConstructor()
        {
            Train t = new Train(2);
            Assert.AreEqual(0, t.Count);
            Assert.AreEqual(2, t.EngineValue);
            Assert.IsNull(t.LastDomino); //Gimme a domino, nope
        }

        [Test]
        public void TrainTestCount()
        {
            Train t = new Train();
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(1, 2);
            t.add(d1);
            t.add(d2);
            Assert.AreEqual(2, t.Count);
        }

        [Test]
        public void TrainTestIsEmpty()
        {
            Train t = new Train();
            Assert.AreEqual(true, t.isEmpty);
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(1, 2);
            t.add(d1);
            t.add(d2);
            Assert.AreEqual(false, t.isEmpty);
            Assert.IsFalse(t.isEmpty);
        }

        [Test]
        public void TrainTestLastDomino()
        {
            Train t = new Train();
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(1, 2);
            t.add(d1);
            t.add(d2);
            Assert.AreEqual(d2, t.LastDomino);
        }

        [Test]
        public void TrainTestPlayableValue()
        {
            Train t = new Train();
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(1, 2);
            t.add(d1);
            t.add(d2);
            Assert.AreEqual(2, t.PlayableValue);
            Assert.AreEqual(d2.Side2, t.PlayableValue);
        }

        [Test]
        public void TrainTestAdd()
        {
            Train t = new Train();
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(1, 2);
            t.add(d1);
            t.add(d2);
            Assert.AreEqual(d1, t[0]);
        }

        [Test]
        public void TrainTestIsPlayable()
        {
            Train t = new Train();
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(1, 2);
            Domino d3 = new Domino(12, 12);
            bool mustFlip;
            t.add(d1);
            t.add(d2);

            Assert.AreEqual(false, t.isPlayable(d3, out mustFlip));
        }

        [Test]
        public void TrainTestIsPlayable2() //Testing a domino that does need to be flipped and is playable.
        {
            Train t = new Train();
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(1, 2);
            Domino d3 = new Domino(12, 2);
            bool mustFlip;
            t.add(d1);
            t.add(d2);
            Assert.AreEqual(true, t.isPlayable(d3, out mustFlip));
        }

        [Test]
        public void TrainTestIsPlayable3() //Testing a domino that doesn't need to be flipped but is still playable.
        {
            Train t = new Train();
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(1, 2);
            Domino d3 = new Domino(2, 3);
            bool mustFlip;
            t.add(d1);
            t.add(d2);
            Assert.AreEqual(true, t.isPlayable(d3, out mustFlip));
        }

        [Test]
        public void TrainTestPlay() //Play only works if there is another domino in the train.
        {
            Train t = new Train();
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(1, 2);
            Domino d3 = new Domino(3, 2);
            t.add(d2);
            t.play(d3);
            
            Assert.AreEqual(d3, t[1]);
        }

        [Test]
        public void TrainTestPlay2() //Testing to see if train is empty because it checks to see if there is a domino before trying to play.
        {
            Train t = new Train();
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(1, 2);
            Domino d3 = new Domino(3, 2);
            t.play(d3);

            Assert.AreEqual(0, t.Count);
        }

        //[Test]
        //public void TrainTestToString()
        //{

        //}

    }
}