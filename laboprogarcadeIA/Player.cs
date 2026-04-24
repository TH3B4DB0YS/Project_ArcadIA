/************************************************************
 * ==========================================================
 *  PROJECT ARCAD'IA – Plateforme Arcade (C# WinForms)
 * ==========================================================
 * Fichier     : Player.cs
 * Auteurs     : Timothé CLINQUART, Clément CAULIEZ,
 *               Tristan DESPELCHIN, Jean-Sébastien BURLANDY
 * Date        : 24 avril 2026
 * Objet       : Classe représentant un joueur de la
 *               plateforme. Gère l'identifiant, le niveau,
 *               le nombre de jeux débloqués et la progression.
 *               Sérialisable en XML pour la persistance.
 *
 * Dépendances : System (Serializable)
 * ==========================================================
 ************************************************************/
using System;

namespace laboprogarcadeIA
{
    [Serializable]
    public class Player
    {
        public string GameID { get; set; }
        public int Level { get; set; }
        public int UnlockedGames { get; set; }
       
        public int NbGames { get; set; }

        public Player() { }

        public Player(string gameID, int level = 0)
        {
            GameID = gameID;
            Level = level;
            // 1 jeu débloqué tous les 15 niveaux (cohérent avec GameDatabase)
            UnlockedGames = Level / 15;
        }

        public void AddLevel(int amount = 1)
        {
            if (Level < 100)
            {
                Level += amount;
                // Recalcul des jeux débloqués après montée de niveau
                UnlockedGames = Level / 15;
            }
            else
            {
                LevelMaximum();
            }
        }
        public void NextGame()
        {
            NbGames = UnlockedGames;

        }
        public void Reset()
        {
            Level = 0;
            UnlockedGames = 0;
            NbGames = 0;
        }
        public void LevelMaximum()
        {
            Level = 100;
        }
    }
}