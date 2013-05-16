using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteen;

namespace GameFifteenTests
{
    [TestClass]
    public class GameFieldTests
    {
        [TestMethod]
        public void TestMoveCounter()
        {
            GameField game = new GameField(4);
            int successMoveCount = 0;
            if (game.MakeMove(12))
            {
                successMoveCount++;
            }

            if (game.MakeMove(1))
            {
                successMoveCount++;
            }
            
            Assert.AreEqual(successMoveCount, game.MoveCounter);
        }

        [TestMethod]
        public void TestMoveCounterStartValue()
        {
            GameField game = new GameField(4);
            Assert.AreEqual(0, game.MoveCounter);
        }
    }
}
