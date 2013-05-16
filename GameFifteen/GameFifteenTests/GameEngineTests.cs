using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteen;

namespace GameFifteenTests
{
    [TestClass]
    public class GameEngineTests
    {
        static GameEngine engine = new GameEngine();
        PrivateObject privateEngine = new PrivateObject(engine);
            

        [TestMethod]
        public void TestScoreBoardField()
        {
            var scoreboard = privateEngine.GetField("scoreBoard");
            Assert.IsInstanceOfType(scoreboard, typeof(ScoreBoard));
        }

        [TestMethod]
        public void TestGameFieldField()
        {
            var gamefield = privateEngine.GetField("field");
            Assert.IsInstanceOfType(gamefield, typeof(GameField));
        }


    }
}
