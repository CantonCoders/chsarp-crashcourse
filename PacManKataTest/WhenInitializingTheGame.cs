using NUnit.Framework;
using PacManKata;
using static PacManKata.Monster;

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
            Assert.AreEqual(new Cell(10, 10, gameGrid), gameGrid.GetPacManLocation());
        }

        [Test]
        public void StartsWith400Dots()
        {
            Assert.AreEqual(400, gameGrid.GetRemainingDotTotal());
        }

        [Test]
        public void PacManFacesRight()
        {
            Assert.AreEqual(PacManFacingEnum.Right, gameGrid.WhereIsPacManFacing());
        }



        [Test]
        public void ThereAre5MonstersToStart()
        {
            Assert.AreEqual(5, gameGrid.Monsters.Length);
        }

        [Test]
        public void OnFirstTickMonster1AppearsAnyWhereOnBoard()
        {
            gameGrid.Tick();
            Assert.IsNotNull(gameGrid.Monsters[0].Location);
        }

    }
}