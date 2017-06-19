using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;

namespace UnitTestProject1
{
    [TestClass]
    public class BowlingTest
    {
        [TestMethod]
        public void TestAll0()
        {
            IBowlingGame game = new BowlingGame();
            for (int i = 0; i < 20; i++)
            {
                game.Roll(0);
            }
            Assert.AreEqual(0, game.GetScore());
        }
        [TestMethod]
        public void TestAll1()
        {
            IBowlingGame game = new BowlingGame();
            for (int i = 0; i < 20; i++)
            {
                game.Roll(1);
            }
            Assert.AreEqual(20, game.GetScore());
        }
        [TestMethod]
        public void TestAll5()
        {
            IBowlingGame game = new BowlingGame();
            for (int i = 0; i < 21; i++)
            {
                game.Roll(5);
            }
            Assert.AreEqual(150, game.GetScore());
        }
        [TestMethod]
        public void TestAll10()
        {
        
            IBowlingGame game = new BowlingGame();
            for(int i= 0;i < 12;i++)
            {
                game.Roll(10);
            }
            Assert.AreEqual(300, game.GetScore());
        }
        [TestMethod]
        public void TestRand()
        {
            IBowlingGame game = new BowlingGame();
            game.Roll(0);
            game.Roll(1);
            Assert.AreEqual(1, game.GetScore());
            game.Roll(2);
            game.Roll(3);
            Assert.AreEqual(6, game.GetScore());
            game.Roll(4);
            game.Roll(5);
            Assert.AreEqual(15, game.GetScore());
            game.Roll(6);
            game.Roll(4);
            Assert.AreEqual(25, game.GetScore());
            game.Roll(5);
            Assert.AreEqual(35, game.GetScore());
            game.Roll(3);
            Assert.AreEqual(38, game.GetScore());
            game.Roll(6);
            Assert.AreEqual(44, game.GetScore());
            game.Roll(4);
            Assert.AreEqual(48, game.GetScore());
            game.Roll(10);
            game.Roll(4);
            game.Roll(3);
            Assert.AreEqual(82, game.GetScore());
            game.Roll(2);
            game.Roll(4);
            Assert.AreEqual(88, game.GetScore());
            game.Roll(6);
            game.Roll(4);
            game.Roll(10);
            Assert.AreEqual(108, game.GetScore());
        }
    }
}
