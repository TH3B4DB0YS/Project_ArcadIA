namespace laboprogarcadeIA.Snake
{
    public partial class Form1 : Form
    {
        private SnakeController _controller;
        private const int TileSize = 20;

        public Form1()
        {
            this.DoubleBuffered = true;
            this.ClientSize = new Size(400, 430);

            // La vue crée le contrôleur et lui passe une référence d'elle-même
            _controller = new SnakeController(this, 20);

            // Abonnements aux événements
            this.KeyDown += (s, e) => _controller.HandleKeyDown(e.KeyCode);
            this.Paint += OnPaint;

            _controller.StartGame();
        }

        public void ShowGameOver(int score)
        {
            var res = MessageBox.Show($"Score : {score}\nRejouer ?", "Game Over", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes) _controller.StartGame();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // On demande les données au contrôleur pour les dessiner
            g.DrawString($"Score: {_controller.GetScore()}", this.Font, Brushes.Black, 10, 405);

            // Dessin de la pomme
            Point food = _controller.GetFoodLocation();
            g.FillEllipse(Brushes.Red, food.X * TileSize, food.Y * TileSize, TileSize, TileSize);

            // Dessin du serpent
            foreach (Point p in _controller.GetSnakeBody())
            {
                g.FillRectangle(Brushes.Green, p.X * TileSize, p.Y * TileSize, TileSize - 1, TileSize - 1);
            }
        }
    }
}