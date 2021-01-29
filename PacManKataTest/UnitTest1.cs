using NUnit.Framework;
using PacManKata;

namespace PacManKataTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InitializeGameGrid()
        {
            var gameGrid = new GameGrid();

            Assert.AreEqual(20, gameGrid.Width);
            Assert.AreEqual(20, gameGrid.Height);
        }
    }
}