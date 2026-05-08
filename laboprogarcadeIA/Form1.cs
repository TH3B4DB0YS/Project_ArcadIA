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
            if (string.IsNullOrEmpty(gameID)) return;

            currentPlayer = database.GetOrCreatePlayer(gameID);

            currentPlayer.UpdateUnlockedGames();

            UpdateGameButtons();

            MessageBox.Show($"Bienvenue {gameID}!\nNiveau: {currentPlayer.Level}\nJeux débloqués: {currentPlayer.UnlockedGames}\nProchain déverrouillage au niveau: {currentPlayer.UnlockedGames + 1}\n");

            currentPlayer = database.GetOrCreatePlayer(gameID);

            DialogResult result = MessageBox.Show(
                $"Bienvenue {gameID}!\n" +
                $"Niveau: {currentPlayer.Level}\n" +
                $"Jeux débloqués: {currentPlayer.UnlockedGames}/5\n" +
                // Prochain palier = (jeux débloqués + 1) * 15 niveaux
                $"Prochain déverrouillage au niveau {currentPlayer.UnlockedGames + 1}",
                "Profil Joueur",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
            );
            if (result == DialogResult.OK)
            {
                textBox1.Visible = false;
                ((Button)sender).Visible = false; // Cache le bouton sur lequel on vient de cliquer

                // On affiche les boutons de jeux (Assure-toi que ces noms existent !)
                // Ici j'utilise des noms génériques, remplace-les par les tiens :
                btnGame1.Visible = true;
                btnGame2.Visible = true;

                // Logique de déblocage
                btnGame2.Enabled = (currentPlayer.Level >= 15);
            }
        }
        

        private void UpdateGameButtons()
        {
            //btnGame1.Enabled = (currentPlayer.UnlockedGames >= 1);
            //btnGame2.Enabled = (currentPlayer.UnlockedGames >= 2);
            //btnGame3.Enabled = (currentPlayer.UnlockedGames >= 3);
            //btnGame4.Enabled = (currentPlayer.UnlockedGames >= 4);
            //btnGame5.Enabled = (currentPlayer.UnlockedGames >= 5);

            // Petit bonus : Ajouter un cadenas visuel sur les boutons verrouillés
            //if (!btnGame2.Enabled) btnGame2.Text = "🔒 Niveau 15";
            //if (!btnGame3.Enabled) btnGame3.Text = "🔒 Niveau 30";
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
            
        }
        
    }
}
