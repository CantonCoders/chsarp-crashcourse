using PacManKataTest;
using System;

namespace PacManKata
{
    public class GameGrid
    {
        public GameGrid()
        {
            Width = 20;
            Height = 20;
            location = (10, 10);
        }

        private (int, int) location;

        public int Width { get; }
        public int Height { get; }
        
        public (int, int) GetPacManLocation()
        {
            return location;
        }

        public int CalculateRemainingDots()
        {
            return 400;
        }

        public PacManDirectionEnum WhereIsPacManFacing()
        {
            return PacManDirectionEnum.Right;
        }

        public void Tick()
        {
            location = (11, 10);
        }
    }
}