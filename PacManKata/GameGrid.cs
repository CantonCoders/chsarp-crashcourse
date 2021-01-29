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
        private PacManFacingEnum pacManFacing;

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

        public PacManFacingEnum WhereIsPacManFacing()
        {
            return pacManFacing;
        }

        public void Tick()
        {
            if (pacManFacing == PacManFacingEnum.Right)
            {
                location.Item1++;
            }
            else if (pacManFacing == PacManFacingEnum.Up)
            {
                location.Item2++;
            }
            else if (pacManFacing == PacManFacingEnum.Left)
            {
                location.Item1--;
            }
            else
            {
                location.Item2--;
            }
        }

        public void ChangePacManFacingTo(PacManFacingEnum newDirection)
        {
            pacManFacing = newDirection;
        }
    }
}