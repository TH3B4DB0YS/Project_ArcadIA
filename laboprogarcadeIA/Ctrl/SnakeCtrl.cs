using System;
using System.Collections.Generic;
using System.Text;
using Timer = System.Windows.Forms.Timer;

namespace laboprogarcadeIA.Snake

{
    public class SnakeController
    {
        private SnakeModel _model;
        private Form1 _view;
        private Timer _gameTimer;

        public SnakeController(Form1 view, int gridSize)
        {
            _view = view;
            _model = new SnakeModel(gridSize);

            _gameTimer = new Timer { Interval = 150 };
            _gameTimer.Tick += OnTick;
        }

        public void StartGame()
        {
            _model.Reset();
            _gameTimer.Start();
        }

        private void OnTick(object sender, EventArgs e)
        {
            _model.Update();
            if (_model.IsGameOver)
            {
                _gameTimer.Stop();
                _view.ShowGameOver(_model.Score);
            }
            _view.Refresh(); // Demande à la vue de se redessiner
        }

        public void HandleKeyDown(Keys key)
        {
            switch (key)
            {
                case Keys.Up: if (_model.CurrentDirection != Direction.Down) _model.CurrentDirection = Direction.Up; break;
                case Keys.Down: if (_model.CurrentDirection != Direction.Up) _model.CurrentDirection = Direction.Down; break;
                case Keys.Left: if (_model.CurrentDirection != Direction.Right) _model.CurrentDirection = Direction.Left; break;
                case Keys.Right: if (_model.CurrentDirection != Direction.Left) _model.CurrentDirection = Direction.Right; break;
            }
        }

        // Propriétés pour que la vue puisse lire les données à dessiner
        public List<Point> GetSnakeBody() => _model.Body;
        public Point GetFoodLocation() => _model.Food;
        public int GetScore() => _model.Score;
    }
}
