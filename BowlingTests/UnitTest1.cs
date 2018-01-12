using System;
using Bowling;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace BowlingGameTests
{
    [TestClass]
    public class GameTests
    {
        static string SCORES_PATH = Environment.GetEnvironmentVariable("dropbox") + @"\IT\BowlingScoreCalculator\Scores\";
        string BEST_GAME = SCORES_PATH + "Best Game.txt";
        string GAME_1 = SCORES_PATH + "Game 1.txt";
        string GAME_2 = SCORES_PATH + "Game 2.txt";
        string GAME_3 = SCORES_PATH + "Game 3.txt";
        string GAME_4 = SCORES_PATH + "Game 4.txt";
        string GAME_5 = SCORES_PATH + "Game 5.txt";
        string GAME_6 = SCORES_PATH + "Game 6.txt";
        string GAME_7 = SCORES_PATH + "Game 7.txt";
        string GAME_8 = SCORES_PATH + "Game 8.txt";
        string LOTS_OF_SPARES = SCORES_PATH + "Lots of Spares.txt";
        string NO_SPARES = SCORES_PATH + "No Spares.txt";
        string TENTH_FRAME_WEIRDNESS = SCORES_PATH + "tenth frame weirdness.txt";
        string WORST_GAME = SCORES_PATH + "Worst Game.txt";
        string ALMOST_PERFECT = SCORES_PATH + "Almost Perfect.txt";
        string FINISH = SCORES_PATH + "finish.txt";

        private Game game = new Game();
        [TestMethod]
        public void CanBowlGutterGame()
        {
            RollMany(20, 0);
            var score = game.Score();
            Assert.AreEqual(0, score);
        }
        [TestMethod]
        public void CanBowlAllOnes()
        {
            RollMany(20, 1);
            var score = game.Score();
            Assert.AreEqual(20, score);
        }
        [TestMethod]
        public void CanBowlSpare()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(2);
            game.Roll(2);
            RollMany(16, 0);
            var score = game.Score();
            Assert.AreEqual(16, score);
        }
        [TestMethod]
        public void CanBowlStrike()
        {
            game.Roll(10);
            game.Roll(5);
            game.Roll(2);
            game.Roll(2);
            RollMany(15, 0);
            var score = game.Score();
            Assert.AreEqual(26, score);
        }
        [TestMethod]
        public void CanBowlPerfectGame()
        {
            RollMany(12, 10);
            var score = game.Score();
            Assert.AreEqual(300, score);
        }
        private void RollMany(Int32 rolls, Int32 pins)
        {
            for (var roll = 0; roll < rolls; roll++)
                game.Roll(pins);
        }
        [TestMethod]
        public void TwoBallsOnly()
        {
            game.Roll(1);
            game.Roll(2);
            Assert.AreEqual(3, game.Score());
        }
        [TestMethod]
        public void NoSpares()
        {
            game.Roll(1);
            game.Roll(2);
            game.Roll(3);
            game.Roll(4);
            game.Roll(1);
            game.Roll(2);
            game.Roll(3);
            game.Roll(4);
            game.Roll(1);
            game.Roll(2);
            game.Roll(3);
            game.Roll(4);
            game.Roll(1);
            game.Roll(2);
            game.Roll(3);
            game.Roll(4);
            game.Roll(1);
            game.Roll(2);
            game.Roll(3);
            game.Roll(4);
            Assert.AreEqual(50, game.Score());
        }
        [TestMethod]
        public void Game2()
        {
            game.Roll(8);
            game.Roll(2);
            game.Roll(1);
            Assert.AreEqual(12, game.Score());
        }
        [TestMethod]
        public void Game3()
        {
            game.Roll(10);
            game.Roll(1);
            Assert.AreEqual(12, game.Score());
        }
        [TestMethod]
        public void Game4()
        {
            game.Roll(10);
            game.Roll(1);
            game.Roll(1);
            Assert.AreEqual(14, game.Score());
        }
        [TestMethod]
        public void Game5()
        {
            game.Roll(10);
            game.Roll(1);
            game.Roll(1);
            game.Roll(5);
            Assert.AreEqual(19, game.Score());
        }
        [TestMethod]
        public void Game6()
        {
            game.Roll(7);
            game.Roll(3);
            game.Roll(10);
            game.Roll(1);
            game.Roll(2);
            Assert.AreEqual(36, game.Score());
        }
        [TestMethod]
        public void Game7()
        {
            game.Roll(10);
            game.Roll(10);
            game.Roll(1);
            game.Roll(3);
            game.Roll(1);
            Assert.AreEqual(40, game.Score());
        }
        [TestMethod]
        public void PrintBestGame()
        {
            Game game = new Game(BEST_GAME);
            game.PrintScoreFrames2();
            Assert.AreEqual(300, game.Score());
        }
        [TestMethod]
        public void PrintGame7()
        {
            Game game = new Game(GAME_7);
            game.PrintScoreFrames2();
            Assert.AreEqual(40, game.Score());
        }
        [TestMethod]
        public void PrintGame2()
        {
            Game game = new Game(GAME_2);
            game.PrintScoreFrames2();
            Assert.AreEqual(12, game.Score());
        }
        [TestMethod]
        public void PrintGame8()
        {
            Game game = new Game(GAME_8);
            game.PrintScoreFrames2();
            Assert.AreEqual(20, game.Score());
        }
        [TestMethod]
        public void PrintGame10()
        {
            Game game = new Game(TENTH_FRAME_WEIRDNESS);
            game.PrintScoreFrames2();
            Assert.AreEqual(15, game.Score());
        }
        [TestMethod]
        public void PrintGameAP()
        {
            Game game = new Game(ALMOST_PERFECT);
            game.PrintScoreFrames2();
            Assert.AreEqual(299, game.Score());
        }
        [TestMethod]
        public void PrintGameFinish()
        {
            Game game = new Game(FINISH);
            game.PrintScoreFrames2();
            Assert.AreEqual(33, game.Score());
        }
    }
}
