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
            location = new Cell(10, 10);
            PacMan = new PacMan();
        }

        private Cell location;

        public int Width { get; }
        public int Height { get; }
        public PacMan PacMan { get; }

        public Cell GetPacManLocation()
        {
            return location;
        }

        public int CalculateRemainingDots()
        {
            return 400;
        }

        public PacManFacingEnum WhereIsPacManFacing()
        {
            return PacMan.Facing;
        }

        public void Tick()
        {
            var pacManFacing = WhereIsPacManFacing();
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
            location.Y--;
            if (location.Y < 1) location.Y = Height;
        }

        private void MovePacManLeft()
        {
            location.X--;
            if (location.X < 1) location.X = Width;
        }

        private void MovePacManUp()
        {
            location.Y++;
            if (IsPacmanAboveGridHeight()) WarpPacmanToBottom();
        }

        private bool IsPacmanAboveGridHeight()
        {
            return location.Y > Height;
        }

        private void MovePacManRight()
        {
            location.X++;
            if (location.X > Width) location.X = 1;
        }

        private void WarpPacmanToBottom()
        {
            location.Y = 1;
        }
    }

    public class Cell
    {
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Cell cell &&
                   X == cell.X &&
                   Y == cell.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}