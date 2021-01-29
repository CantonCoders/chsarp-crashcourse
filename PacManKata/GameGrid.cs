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
        }

        public int Width { get; }
        public int Height { get; }
        
        public (int, int) GetPacManLocation()
        {
            return (10, 10);
        }

        public int CalculateRemainingDots()
        {
            return 400;
        }

        public PacManDirectionEnum WhereIsPacManFacing()
        {
            return PacManDirectionEnum.Right;
        }
    }
}