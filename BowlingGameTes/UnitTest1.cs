using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingKata;

namespace BowlingGameTes
{
    public class UnitTest1
    {
        private Game g;

        public UnitTest1()
        {
            g = new Game();
        }

        private void rollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                g.Roll(pins);
            }
        }

        private void rollSpare()
        {
            g.Roll(6);
            g.Roll(4);
        }

        [TestMethod]
        public void TestGutterGame()
        {
            rollMany(20, 0);
            Assert.Equals(0, g.Score());
        }

        [TestMethod]
        public void TestAllOnes()
        {
            rollMany(20, 1);
            Assert.Equals(20, g.Score());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            rollSpare();
            g.Roll(4);
            rollMany(17, 0);
            Assert.Equals(18, g.Score());
        }

        [TestMethod]
        public void TestOneStrike()
        {
            g.Roll(10);
            g.Roll(4);
            g.Roll(5);
            rollMany(17, 0);
            Assert.Equals(28, g.Score());
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            rollMany(12, 10);
            Assert.Equals(300, g.Score());
        }

        [TestMethod]
        public void TestRandomGameNoExtraRoll()
        {
            g.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });
            Assert.Equals(131, g.Score());
        }

        [TestMethod]
        public void TestRandomGameWithSpareThenStrikeAtEnd()
        {
            g.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 });
            Assert.Equals(143, g.Score());
        }

        [TestMethod]
        public void TestRandomGameWithThreeStrikesAtEnd()
        {
            g.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10 });
            Assert.Equals(163, g.Score());
        }

    }
}
