using NUnit.Framework;
using PacManKata;

namespace PacManKataTest
{
    public class WhenInitializingTheGame
    {
        GameGrid gameGrid;

        [SetUp]
        public void Setup()
        {
            gameGrid = new GameGrid();
        }

        [Test]
        public void GameGridInializesTo20By20()
        {
            Assert.AreEqual(20, gameGrid.Width);
            Assert.AreEqual(20, gameGrid.Height);
        }

        [Test]
        public void PacManStartsInTheMiddle()
        {
            Assert.AreEqual((10, 10), gameGrid.GetPacManLocation());
        }

        [Test]
        public void StartsWith400Dots()
        {
            Assert.AreEqual(400, gameGrid.CalculateRemainingDots());
        }

        [Test]
        public void PacManFacesRight()
        {
            Assert.AreEqual(PacManFacingEnum.Right, gameGrid.WhereIsPacManFacing());
        }
    }

    public class WhenGameTicks
    {
        GameGrid gameGrid;

        [SetUp]
        public void Setup()
        {
            gameGrid = new GameGrid();
        }

        [Test]
        public void PacManMovesOneSquare()
        {
            gameGrid.Tick();
            Assert.AreEqual((11, 10), gameGrid.GetPacManLocation());
            gameGrid.Tick();
            Assert.AreEqual((12, 10), gameGrid.GetPacManLocation());
        }

        [Test]
        public void PacManMovesInUpDirection()
        {
            gameGrid.ChangePacManFacingTo(PacManFacingEnum.Up);
            Assert.AreEqual(PacManFacingEnum.Up, gameGrid.WhereIsPacManFacing());

            gameGrid.Tick();
            Assert.AreEqual((10, 11), gameGrid.GetPacManLocation());
        }

    }
}