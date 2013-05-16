using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteen;

namespace GameFifteenTests
{
    [TestClass]
    public class ScoreBoardTests
    {
        [TestMethod]
        public void TestAddToScoreBoard()
        {
            ScoreBoard scores = new ScoreBoard();
            scores.AddToScoreBoard("Pesho", 8);
            Assert.AreEqual("1. Pesho --> 8 moves", scores.ToString());
        }

        [TestMethod]
        public void TestEmptyScoreBoard()
        {
            ScoreBoard scores = new ScoreBoard();
            Assert.AreEqual("The score-board is empty.", scores.ToString());
        }

    }
}
