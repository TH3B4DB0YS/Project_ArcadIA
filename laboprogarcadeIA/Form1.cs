using System;
using System.Windows.Forms;

namespace laboprogarcadeIA
{
    public partial class Form1 : Form
    {
        private GameDatabase database;
        private Player currentPlayer;

        public Form1()
        {
            InitializeComponent();
            database = new GameDatabase();
        }

        private void Gamechoise_Click(object sender, EventArgs e)
        {
            string gameID = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(gameID))
            {
                MessageBox.Show("Veuillez entrer un ID de jeu valide.", "Erreur");
                return;
            }

            currentPlayer = database.GetOrCreatePlayer(gameID);
            
            MessageBox.Show(
                $"Bienvenue {gameID}!\n" +
                $"Niveau: {currentPlayer.Level}\n" +
                $"Jeux débloqués: {currentPlayer.UnlockedGames}/5\n "+
                $"Prochaine déverrouillage à {(currentPlayer.UnlockedGames + 1) * currentPlayer.Level+5} LVL",
                "Profil Joueur",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Warning
            );
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            // Vous pouvez ajouter une validation en temps réel ici si souhaité
        }
    }
}
