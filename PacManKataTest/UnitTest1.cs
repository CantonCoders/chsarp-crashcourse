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
            Assert.AreEqual(PacManDirectionEnum.Right, gameGrid.WhereIsPacManFacing());
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
        }
    }
}