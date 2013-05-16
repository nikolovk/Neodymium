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

        [TestMethod]
        public void TestAddSevenToScoreBoard()
        {
            ScoreBoard scores = new ScoreBoard();
            scores.AddToScoreBoard("Pesho", 9);
            scores.AddToScoreBoard("Pesho", 88);
            scores.AddToScoreBoard("Pesho", 7);
            scores.AddToScoreBoard("Pesho", 8);
            scores.AddToScoreBoard("Pesho", 8);
            scores.AddToScoreBoard("Pesho", 8);
            scores.AddToScoreBoard("Pesho", 8);
            string expectedScoreBoard = "";


            expectedScoreBoard += "1. Pesho --> 88 moves" + Environment.NewLine;
            expectedScoreBoard += "2. Pesho --> 9 moves" + Environment.NewLine;
            expectedScoreBoard += "3. Pesho --> 8 moves" + Environment.NewLine;
            expectedScoreBoard += "4. Pesho --> 8 moves" + Environment.NewLine;
            expectedScoreBoard += "5. Pesho --> 8 moves";
            Assert.AreEqual(expectedScoreBoard, scores.ToString());
        }
    }
}
