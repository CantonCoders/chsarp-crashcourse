using NUnit.Framework;
using PacManKata;
using System.Linq;

namespace PacManKataTest
{

    public class WhenPacmanEatsDots
    {
        GameGrid gameGride;

        [SetUp]
        public void SetUp()
        {
            gameGride = new GameGrid();
        }

        [Test]
        public void GameGridIsFilledWithDots()
        {
            var cells = gameGride.GetAllCells();

            Assert.AreEqual(400, cells.Count());

            Assert.AreEqual(400, cells.Where(c => c.HasDot()).Count());
        }

        [Test]
        public void PacmanEatsFirstDot()
        {
            gameGride.Tick();
            Assert.AreEqual(399, gameGride.CalculateRemainingDots());
            Assert.AreEqual(false, gameGride.GetCell(10, 10).HasDot());
        }

        [Test]
        public void PacmanEatsTwoDots()
        {
            gameGride.Tick();
            gameGride.Tick();
            Assert.AreEqual(398, gameGride.CalculateRemainingDots());
            Assert.AreEqual(false, gameGride.GetCell(10, 10).HasDot());
            Assert.AreEqual(false, gameGride.GetCell(11, 10).HasDot());
        }
    }
}