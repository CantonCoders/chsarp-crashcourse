using NUnit.Framework;
using PacManKata;
using System.Linq;

namespace PacManKataTest
{

    public class WhenPacmanEatsDots
    {
        GameGrid gameGrid;

        [SetUp]
        public void SetUp()
        {
            gameGrid = new GameGrid();
        }

        [Test]
        public void GameGridIsFilledWithDots()
        {
            var cells = gameGrid.GetAllCells();

            Assert.AreEqual(400, cells.Count());

            Assert.AreEqual(400, cells.Where(c => c.HasDot()).Count());
        }

        [Test]
        public void PacmanEatsFirstDot()
        {
            gameGrid.Tick();
            Assert.AreEqual(399, gameGrid.CalculateRemainingDots());
            Assert.AreEqual(false, gameGrid.GetCell(10, 10).HasDot());
        }

        [Test]
        public void PacmanEatsTwoDots()
        {
            gameGrid.Tick();
            gameGrid.Tick();
            Assert.AreEqual(398, gameGrid.CalculateRemainingDots());
            Assert.AreEqual(false, gameGrid.GetCell(10, 10).HasDot());
            Assert.AreEqual(false, gameGrid.GetCell(11, 10).HasDot());
        }

        [Test]
        public void PacmanCanChangeFacingAndEatDots()
        {
            gameGrid.Tick();
            gameGrid.PacMan.FacePacmanUp();
            gameGrid.Tick();
            gameGrid.Tick();
            Assert.AreEqual(397, gameGrid.CalculateRemainingDots());
            Assert.AreEqual(false, gameGrid.GetCell(10, 10).HasDot());
            Assert.AreEqual(false, gameGrid.GetCell(11, 10).HasDot());
            Assert.AreEqual(false, gameGrid.GetCell(11, 11).HasDot());

            Assert.AreEqual(new Cell(11, 12, gameGrid), gameGrid.GetPacManLocation());
        }

        [Test]
        public void PacmanCannotEatCellDotsMoreThanOnce()
        {
            gameGrid.Tick();
            gameGrid.PacMan.FacePacmanUp();
            gameGrid.Tick();
            gameGrid.PacMan.FacePacmanDown();
            gameGrid.Tick();
            gameGrid.Tick();

            Assert.AreEqual(new Cell(11, 9, gameGrid), gameGrid.GetPacManLocation());

            Assert.AreEqual(false, gameGrid.GetCell(10, 10).HasDot());
            Assert.AreEqual(false, gameGrid.GetCell(11, 10).HasDot());
            Assert.AreEqual(false, gameGrid.GetCell(11, 11).HasDot());

            Assert.AreEqual(397, gameGrid.CalculateRemainingDots());

        }
    }
}