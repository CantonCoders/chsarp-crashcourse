using PacManKataTest;
using System;
using System.Collections.Generic;
using static PacManKata.Monster;

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
                    cells[x, y] = new Cell(x, y, this);
                }
            }
            
            this.Monsters = new Monster[5];
            this.Monsters[0] = new Monster(this);
            pacmanLocation = GetCell(10, 10);
            PacMan = new PacMan();
        }

        private int numberOfDots = 400;
        private Cell[,] cells;

        private Cell pacmanLocation;
        public readonly Monster[] Monsters;

        public int Width { get; }
        public int Height { get; }
        public PacMan PacMan { get; }

        public Cell GetPacManLocation()
        {
            return pacmanLocation;
        }

        public int CalculateRemainingDots()
        {
            int total = 0;

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (cells[x, y].HasDot()) total++;
                }
            }

            return total;
        }

        public PacManFacingEnum WhereIsPacManFacing()
        {
            return PacMan.Facing;
        }

        public void Tick()
        {

            this.GetPacManLocation().EatDot();
            //numberOfDots--;
         
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

    public class Monster
    {
        private GameGrid _gameGrid;
        public Monster(GameGrid gameGrid)
        {
            this._gameGrid = gameGrid;
        }
        public object Location
        {
            get { return this._gameGrid.GetCell(0, 0); }
        }

        public class Cell
        {
            private bool _hasDot = true;
            private GameGrid _gameGrid;

            public Cell(int x, int y, GameGrid gameGrid)
            {
                X = x;
                Y = y;
                _gameGrid = gameGrid;
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
                if ((X + 1) < this._gameGrid.Width)
                    return _gameGrid.GetCell(X + 1, Y);
                return _gameGrid.GetCell(0, Y);
            }

            internal Cell Down()
            {
                return _gameGrid.GetCell(X, --Y);
            }

            internal Cell Left()
            {
                return _gameGrid.GetCell(--X, Y);
            }

            internal Cell Up()
            {
                if ((Y + 1) < _gameGrid.Height)
                    return _gameGrid.GetCell(X, Y + 1);
                return _gameGrid.GetCell(X, 0);
            }

            internal void EatDot()
            {
                _hasDot = false;
            }
        }
    }
}