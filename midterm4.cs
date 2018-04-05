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