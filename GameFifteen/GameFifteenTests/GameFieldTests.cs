using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteen;

namespace GameFifteenTests
{
    [TestClass]
    public class GameFieldTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InitializeFieldWithNegativeSize()
        {
            GameField gamefield = new GameField(-2);
        }

        [TestMethod]
        public void TestMoveCounter()
        {
            GameField gamefield = new GameField(4);
            int successMoveCount = 0;
            if (gamefield.MakeMove(12))
            {
                successMoveCount++;
            }

            if (gamefield.MakeMove(1))
            {
                successMoveCount++;
            }
            
            Assert.AreEqual(successMoveCount, gamefield.MoveCounter);
        }

        [TestMethod]
        public void TestMoveCounterStartValue()
        {
            GameField gamefield = new GameField(4);
            Assert.AreEqual(0, gamefield.MoveCounter);
        }

        [TestMethod]
        public void TestIsCurrentMatrixArranged()
        {
            GameField gamefield = new GameField(4);
            Assert.IsFalse(gamefield.IsCurrentMatrixArranged());
        }

        [TestMethod]
        public void TestToString()
        {
            GameField gamefield = new GameField(4);
            Assert.IsTrue(gamefield.ToString().StartsWith(" -------------"));
        }

        [TestMethod]
        public void TestToStringSecondTest()
        {
            GameField gamefield = new GameField(4);
            Assert.IsTrue(gamefield.ToString().Contains("|"));
        }
    }
}
