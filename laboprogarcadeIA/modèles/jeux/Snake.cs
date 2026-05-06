using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace laboprogarcadeIA.Snake

{
    public enum Direction { Up, Down, Left, Right }
    public class SnakeModel 
    {
        // Propriétés du serpent
        public List<Point> Body { get; private set; }
        public Direction CurrentDirection { get; set; }
        public bool IsGameOver { get; private set; }
        public int Score { get; private set; }
        public Point Food { get; private set; }
        public int GridSize { get; private set; }
        public Random rand = new Random();


        public SnakeModel(int gridSize)
        {
            GridSize = gridSize;
            Reset();
        }

        public void Reset()
        {
            Body = new List<Point> { new Point(GridSize / 2, GridSize / 2) };
            CurrentDirection = Direction.Right;
            IsGameOver = false;
            Score = 0;
            GenerateFood();
        }

        private void GenerateFood()
        {
            Food = new Point(rand.Next(GridSize), rand.Next(GridSize));
        }
        public void Update()
        {
            if (IsGameOver) return;
            Point newHead = Body[0];
            switch (CurrentDirection)
            {
                case Direction.Up: newHead.Y--; break;
                case Direction.Down: newHead.Y++; break;
                case Direction.Left: newHead.X--; break;
                case Direction.Right: newHead.X++; break;
            }

            if (newHead.X < 0 || newHead.X >= GridSize || newHead.Y < 0 || newHead.Y >= GridSize || Body.Contains(newHead))
            {
                IsGameOver = true;
                return;
            }

            Body.Insert(0, newHead);
            if (newHead == Food) { Score += 10; GenerateFood(); }
            else { Body.RemoveAt(Body.Count - 1); }
        }
    }
}
