﻿using PacManKataTest;
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
        private PacManFacingEnum pacManFacing;


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
            location.Y--;
        }

        private void MovePacManLeft()
        {
            location.X--;
        }

        private void MovePacManUp()
        {
            location.Y++;
        }

        private void MovePacManRight()
        {
            location.X++;
        }

        public void ChangePacManFacingTo(PacManFacingEnum newDirection)
        {
            pacManFacing = newDirection;
        }
    }

    public class Cell
    {
        public Cell(int x, int v2)
        {
            X = x;
            Y = v2;
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