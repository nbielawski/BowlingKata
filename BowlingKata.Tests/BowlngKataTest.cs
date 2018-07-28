using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingKata.Tests
{
    [TestClass]
    public class BowlngKataTest
    {
        private Game g;

        [TestInitialize]    
        public void initialize()
        {
            g = new Game();
        }


        [TestMethod]
        public void AllGutterBallsShouldEqualZero()
        {
            RollMultiple(20, 0);

            Assert.AreEqual(0, g.Score());
        }

        [TestMethod]
        public void AllThreesShouldEqualSixty()
        {
            RollMultiple(20, 3);

            Assert.AreEqual(60, g.Score());
        }

        [TestMethod]
        public void SpareFollowedByAllGutterBalls()
        {
            RollSpare();

            RollMultiple(18, 0);

            Assert.AreEqual(10, g.Score());
        }

        [TestMethod]
        public void SparePlusTwoFollowedByAllGutterBallsSHouldEqualFourteen()
        {
            RollSpare();
            g.Roll(2);
            RollMultiple(17, 0);

            Assert.AreEqual(14, g.Score());
        }

        [TestMethod]
        public void ConsecutiveSpareMultipleBonuses()
        {
            RollSpare();
            RollSpare();
            RollMultiple(16, 1);

            Assert.AreEqual(42, g.Score());
        }


        [TestMethod]
        public void LastFrameSpareBonusBallShouldEqualEleven()
        {
            RollMultiple(18, 0);
            RollSpare();
            g.Roll(1);

            Assert.AreEqual(11, g.Score());
        }

        [TestMethod]
        public void StrikeFirstFrameGutterTheRest()
        {
            RollStrike();
            RollMultiple(18, 0);
            Assert.AreEqual(10, g.Score());
        }

        [TestMethod]
        public void StrikepPlusTwoBallBonusShouldEqualThirtyFour()
        {
            RollStrike();
            RollMultiple(4, 4);
            RollMultiple(14, 0);

            Assert.AreEqual(34, g.Score());
        }

        [TestMethod]
        public void ThreeConsecutiveStrikesPlusTwoBallBonus()
        {
            RollStrike();
            RollStrike();
            RollStrike();
            RollMultiple(2, 1);
            RollMultiple(12,0);

            Assert.AreEqual(65, g.Score());
        }

        [TestMethod]
        public void StrikeInLastFramePlusBonusBall()
        {
            RollMultiple(18, 0);
            RollStrike();
            RollMultiple(2, 4);

            Assert.AreEqual(18, g.Score());
        }

        [TestMethod]
        public void GuttersThenThreeStrikesLastFrame()
        {
            RollMultiple(18, 0);
            RollStrike();
            RollStrike();
            RollStrike();

            Assert.AreEqual(30, g.Score());
        }
        [TestMethod]
        public void AllSparesPlusGutter()
        {
            RollMultiple(20, 5);
            g.Roll(0);

            Assert.AreEqual(145, g.Score());

        }
        [TestMethod]
        public void PerfectGame()
        {
            RollMultiple(12, 10);

            Assert.AreEqual(300, g.Score());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Can only have a max of 10 Pins per Frame")]
        public void TestRollGreaterThanTenThrowsException()
        {
            g.Roll(11);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A single roll cant Knock down more than 10 pins")]
        public void TestFrameRollsMoreThanTenPinsThrowsException()
        {
            RollMultiple(2, 9);
        }

        private void RollStrike()
        {
            g.Roll(10);
        }

        public void RollMultiple(int rolls, int pins)
        {

            for (int i = 0; i < rolls; i++)
            {
                g.Roll(pins);
            }
        }

        public void RollSpare()
        {

            RollMultiple(2, 5);
        }

    }
}
