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
            Assert.AreEqual(new Cell(10, 10), gameGrid.GetPacManLocation());
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
        public void PacManMovesOneSquareInTheDirectionHeIsFacing()
        {
            gameGrid.PacMan.FacePacmanRight();

            gameGrid.Tick();
            Assert.AreEqual(new Cell(11,10), gameGrid.GetPacManLocation());
            gameGrid.Tick();
            Assert.AreEqual(new Cell(12,10), gameGrid.GetPacManLocation());
        }

        [Test]
        public void PacManWrapsAroundFromRightSideToLeftSide()
        {
            for (int i = 0; i < 11; i++)
            {
                gameGrid.Tick();
            }

            Assert.AreEqual(new Cell(1, 10), gameGrid.GetPacManLocation());
        }

        [Test]
        public void PacManMovesInUpDirection()
        {
            gameGrid.PacMan.FacePacmanUp();
            Assert.AreEqual(PacManFacingEnum.Up, gameGrid.WhereIsPacManFacing());

            gameGrid.Tick();
            Assert.AreEqual(new Cell(10, 11), gameGrid.GetPacManLocation());
        }

        [Test]
        public void PacManMovesInLeftDirection()
        {
            gameGrid.PacMan.FacePacmanLeft();
            Assert.AreEqual(PacManFacingEnum.Left, gameGrid.WhereIsPacManFacing());

            gameGrid.Tick();
            Assert.AreEqual(new Cell(9, 10), gameGrid.GetPacManLocation());
        }

        [Test]
        public void PacManMovesInDownDirection()
        {
            gameGrid.PacMan.FacePacmanDown();
            Assert.AreEqual(PacManFacingEnum.Down, gameGrid.WhereIsPacManFacing());

            gameGrid.Tick();
            Assert.AreEqual(new Cell(10, 9), gameGrid.GetPacManLocation());
        }

        [Test]
        public void PacManMovesOneCellThenRightOneCell()
        {
            gameGrid.PacMan.FacePacmanDown();
            gameGrid.Tick();
            Assert.AreEqual(new Cell(10, 9), gameGrid.GetPacManLocation());

            gameGrid.PacMan.FacePacmanRight();
            gameGrid.Tick();
            Assert.AreEqual(new Cell(11, 9), gameGrid.GetPacManLocation());

        }

    }
}