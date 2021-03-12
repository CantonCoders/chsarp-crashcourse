using NUnit.Framework;
using PacManKata;
using static PacManKata.Monster;

namespace PacManKataTest
{
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
            Assert.AreEqual(new Cell(11,10, gameGrid), gameGrid.GetPacManLocation());
            gameGrid.Tick();
            Assert.AreEqual(new Cell(12,10, gameGrid), gameGrid.GetPacManLocation());
        }

        [Test]
        public void PacManWrapsAroundFromRightSideToLeftSide()
        {
            MovePacmanOffTheGrid();
            Assert.AreEqual(new Cell(1, 10, gameGrid), gameGrid.GetPacManLocation());
        }

        [Test]
        public void PacManWrapsAroundFromTopToBottom()
        {
            gameGrid.PacMan.FacePacmanUp();
            MovePacmanOffTheGrid();
            Assert.AreEqual(new Cell(10, 1, gameGrid), gameGrid.GetPacManLocation());
        }

        [Test]
        public void PacManWrapsAroundFromBottomToTop()
        {
            gameGrid.PacMan.FacePacmanDown();
            MovePacmanDownOffTheGrid();
            Assert.AreEqual(new Cell(10, 20, gameGrid), gameGrid.GetPacManLocation());
        }

        [Test]
        public void PacManWrapsAroundLeftToRight()
        {
            gameGrid.PacMan.FacePacmanLeft();
            MovePacmanDownOffTheGrid();
            Assert.AreEqual(new Cell(20, 10, gameGrid), gameGrid.GetPacManLocation());
        }

        private void MovePacmanOffTheGrid()
        {
            for (int i = 0; i < 11; i++)
            {
                gameGrid.Tick();
            }
        }

        private void MovePacmanDownOffTheGrid()
        {
            for (int i = 0; i < 10; i++)
            {
                gameGrid.Tick();
            }
        }

        [Test]
        public void PacManMovesInUpDirection()
        {
            gameGrid.PacMan.FacePacmanUp();
            Assert.AreEqual(PacManFacingEnum.Up, gameGrid.WhereIsPacManFacing());

            gameGrid.Tick();
            Assert.AreEqual(new Cell(10, 11, gameGrid), gameGrid.GetPacManLocation());
        }

        [Test]
        public void PacManMovesInLeftDirection()
        {
            gameGrid.PacMan.FacePacmanLeft();
            Assert.AreEqual(PacManFacingEnum.Left, gameGrid.WhereIsPacManFacing());

            gameGrid.Tick();
            Assert.AreEqual(new Cell(9, 10, gameGrid), gameGrid.GetPacManLocation());
        }

        [Test]
        public void PacManMovesInDownDirection()
        {
            gameGrid.PacMan.FacePacmanDown();
            Assert.AreEqual(PacManFacingEnum.Down, gameGrid.WhereIsPacManFacing());

            gameGrid.Tick();
            Assert.AreEqual(new Cell(10, 9, gameGrid), gameGrid.GetPacManLocation());
        }

        [Test]
        public void PacManMovesOneCellThenRightOneCell()
        {
            gameGrid.PacMan.FacePacmanDown();
            gameGrid.Tick();
            Assert.AreEqual(new Cell(10, 9, gameGrid), gameGrid.GetPacManLocation());

            gameGrid.PacMan.FacePacmanRight();
            gameGrid.Tick();
            Assert.AreEqual(new Cell(11, 9, gameGrid), gameGrid.GetPacManLocation());

        }

    }
}