using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteen;

namespace GameFifteenTests
{
    [TestClass]
    public class GameRendererTests
    {
        [TestMethod]
        public void TestRenderWelcomeMessage()
        {
            GameRenderer renderer = new GameRenderer();
            renderer.RenderWelcomeMessage();
        }

        [TestMethod]
        public void TestClear()
        {
            GameRenderer renderer = new GameRenderer();
            renderer.Clear();
        }

        [TestMethod]
        public void TestRenderCommandMessage()
        {
            GameRenderer renderer = new GameRenderer();
            renderer.RenderCommandMessage();
        }

        [TestMethod]
        public void TestRenderWinMessage()
        {
            GameRenderer renderer = new GameRenderer();
            renderer.RenderWinMessage(5);
        }
    }
}
