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

        [TestMethod]
        public void TestParseInput()
        {
            privateEngine.Invoke("ParseInput", "exit");
            bool toPlay = (bool)privateEngine.GetField("toPlay");
            Assert.IsFalse(toPlay);
        }

        /// <summary>
        /// Test is made to ensure GameEngine, Scoreboard and GameRenderer work together correctly
        /// </summary>
        [TestMethod]
        public void TestParseInputSecondTest()
        {
            privateEngine.Invoke("ParseInput", "jibber-jabber");
            privateEngine.Invoke("ParseInput", "top");
            privateEngine.Invoke("ParseInput", "1");
            privateEngine.Invoke("ParseInput", "2");
            privateEngine.Invoke("ParseInput", "3");
            privateEngine.Invoke("ParseInput", "4");
            privateEngine.Invoke("ParseInput", "5");
            privateEngine.Invoke("ParseInput", "6");
            privateEngine.Invoke("ParseInput", "7");
            privateEngine.Invoke("ParseInput", "8");
            privateEngine.Invoke("ParseInput", "9");
            privateEngine.Invoke("ParseInput", "10");
            privateEngine.Invoke("ParseInput", "11");
            privateEngine.Invoke("ParseInput", "12");
            privateEngine.Invoke("ParseInput", "13");
            privateEngine.Invoke("ParseInput", "14");
            privateEngine.Invoke("ParseInput", "15");
            privateEngine.Invoke("ParseInput", "16");
        }
    }
}
