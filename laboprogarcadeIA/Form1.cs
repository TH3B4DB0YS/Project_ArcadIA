/************************************************************
 * ==========================================================
 *  PROJECT ARCAD'IA – Plateforme Arcade (C# WinForms)
 * ==========================================================
 * Fichier     : Form1.cs
 * Auteurs     : Timothé CLINQUART, Clément CAULIEZ,
 *               Tristan DESPELCHIN, Jean-Sébastien BURLANDY
 * Date        : 24 avril 2026
 * Objet       : Formulaire principal – écran de connexion.
 *               Saisie du nom d'utilisateur, chargement ou
 *               création du profil joueur, et affichage des
 *               informations de progression (niveau, jeux
 *               débloqués, prochain palier).
 *
 * Dépendances : System.Windows.Forms, GameDatabase, Player
 * ==========================================================
 ************************************************************/
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
                $"Jeux débloqués: {currentPlayer.UnlockedGames}/5\n" +
                // Prochain palier = (jeux débloqués + 1) * 15 niveaux
                $"Prochain déverrouillage au niveau {(currentPlayer.UnlockedGames + 1) * 15}",
                "Profil Joueur",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
            );

            // Lancement du Pendu
            this.Hide(); // On cache le menu principal

            PenduGame pendu = new PenduGame();
            pendu.StartGame(currentPlayer); // On passe le joueur actuel au jeu
            pendu.Launch(); // On ouvre la fenêtre du jeu

            this.Show(); // On réaffiche le menu principal quand le jeu est fini
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            // Vous pouvez ajouter une validation en temps réel ici si souhaité
        }
    }
}
