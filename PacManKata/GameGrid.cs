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
            PacMan = new PacMan();
        }

        private (int, int) location;
        private PacManFacingEnum pacManFacing;


        public int Width { get; }
        public int Height { get; }
        public PacMan PacMan { get; }

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
                MovePacManRight();
            }
            else if (pacManFacing == PacManFacingEnum.Up)
            {
                MovePacManUp();
            }
            else if (pacManFacing == PacManFacingEnum.Left)
            {
                MovePacManLeft();
            }
            else
            {
                MovePacManDown();
            }
        }

        private void MovePacManDown()
        {
            location.Item2--;
        }

        private void MovePacManLeft()
        {
            location.Item1--;
        }

        private void MovePacManUp()
        {
            location.Item2++;
        }

        private void MovePacManRight()
        {
            location.Item1++;
        }

        public void ChangePacManFacingTo(PacManFacingEnum newDirection)
        {
            pacManFacing = newDirection;
        }
    }
}