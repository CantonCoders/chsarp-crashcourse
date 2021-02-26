using PacManKataTest;
using System;
using System.Collections.Generic;

namespace PacManKata
{
    public class GameGrid
    {
        public GameGrid()
        {
            Width = 20;
            Height = 20;
            cells = new Cell[Width, Height];
            for(var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Width; y++)
                {
                    cells[x, y] = new Cell(x, y);
                }
            }


            pacmanLocation = new Cell(10, 10);
            PacMan = new PacMan();
        }

        private int numberOfDots = 400;
        private Cell[,] cells;

        private Cell pacmanLocation;

        public int Width { get; }
        public int Height { get; }
        public PacMan PacMan { get; }

        public Cell GetPacManLocation()
        {
            return pacmanLocation;
        }

        public int CalculateRemainingDots()
        {
            return numberOfDots;
        }

        public PacManFacingEnum WhereIsPacManFacing()
        {
            return PacMan.Facing;
        }

        public void Tick()
        {
            GetCell(10, 10).EatDot();
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
            numberOfDots--;
        }

        private void MovePacManDown()
        {
            pacmanLocation = pacmanLocation.Down();
            if (pacmanLocation.Y < 1) pacmanLocation.Y = Height;
        }

        private void MovePacManLeft()
        {
            pacmanLocation = pacmanLocation.Left();
            if (pacmanLocation.X < 1) pacmanLocation.X = Width;
        }

        private void MovePacManUp()
        {
            pacmanLocation = pacmanLocation.Up();
            if (IsPacmanAboveGridHeight()) WarpPacmanToBottom();
        }

        private bool IsPacmanAboveGridHeight()
        {
            return pacmanLocation.Y > Height;
        }

        private void MovePacManRight()
        {
            pacmanLocation = pacmanLocation.Right();
            if (pacmanLocation.X > Width) pacmanLocation.X = 1;
        }

        private void WarpPacmanToBottom()
        {
            pacmanLocation.Y = 1;
        }

        public Cell GetCell(int x, int y)
        {
            return cells[x, y];
        }

        public IEnumerable<Cell> GetAllCells()
        {
            foreach(var car in cells)
            {
                yield return car;
            }
        }
    }

    public class Cell
    {
        private bool _hasDot = true;

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

        public bool HasDot()
        {
            return _hasDot;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public Cell Right()
        {
            return new Cell(++X, Y);
        }

        internal Cell Down()
        {
            return new Cell(X, --Y);
        }

        internal Cell Left()
        {
            return new Cell(--X, Y);
        }

        internal Cell Up()
        {
            return new Cell(X, ++Y);
        }

        internal void EatDot()
        {
            _hasDot = false;
        }
    }
}