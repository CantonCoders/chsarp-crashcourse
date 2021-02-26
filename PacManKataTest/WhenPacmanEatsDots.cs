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
    }
}