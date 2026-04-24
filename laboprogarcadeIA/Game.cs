/************************************************************
 * ==========================================================
 *  PROJECT ARCAD'IA – Plateforme Arcade (C# WinForms)
 * ==========================================================
 * Fichier     : Game.cs
 * Auteurs     : Timothé CLINQUART, Clément CAULIEZ,
 *               Tristan DESPELCHIN, Jean-Sébastien BURLANDY
 * Date        : 24 avril 2026
 * Objet       : Classe abstraite servant de base OO pour les
 *               5 mini-jeux de la plateforme ArcadIA.
 *               Définit les propriétés communes (nom, score,
 *               niveau requis) et force chaque jeu à implémenter
 *               sa propre logique de calcul d'XP et de lancement.
 *
 * Dépendances : Player.cs
 * ==========================================================
 ************************************************************/
using System;

namespace laboprogarcadeIA
{
    /// <summary>
    /// Classe abstraite servant de base pour tous les mini-jeux de la plateforme ArcadIA.
    /// Chaque jeu doit hériter de cette classe et implémenter ses propres règles.
    /// </summary>
    public abstract class Game
    {
        /// <summary>Nom du jeu affiché dans le menu.</summary>
        public string Name { get; protected set; }

        /// <summary>Description courte du jeu.</summary>
        public string Description { get; protected set; }

        /// <summary>Niveau minimum requis pour débloquer ce jeu.</summary>
        public int RequiredLevel { get; protected set; }

        /// <summary>Référence vers le joueur en cours.</summary>
        protected Player CurrentPlayer { get; set; }

        /// <summary>Score de la partie en cours (utilisé pour calculer l'XP).</summary>
        public int Score { get; protected set; }

        /// <summary>Indique si une partie est en cours.</summary>
        public bool IsPlaying { get; protected set; }

        protected Game(string name, string description, int requiredLevel)
        {
            Name = name;
            Description = description;
            RequiredLevel = requiredLevel;
            Score = 0;
            IsPlaying = false;
        }

        /// <summary>
        /// Démarre une nouvelle partie pour le joueur donné.
        /// </summary>
        public virtual void StartGame(Player player)
        {
            CurrentPlayer = player;
            Score = 0;
            IsPlaying = true;
        }

        /// <summary>
        /// Termine la partie en cours et retourne l'XP gagnée.
        /// Chaque jeu définit sa propre logique de conversion score → XP.
        /// </summary>
        public virtual int EndGame()
        {
            IsPlaying = false;
            int xpGained = CalculateXP();
            return xpGained;
        }

        /// <summary>
        /// Calcule l'XP gagnée à partir du score.
        /// Chaque jeu doit implémenter sa propre formule.
        /// </summary>
        protected abstract int CalculateXP();

        /// <summary>
        /// Vérifie si le joueur a le niveau requis pour jouer à ce jeu.
        /// </summary>
        public bool IsUnlocked(Player player)
        {
            return player.Level >= RequiredLevel;
        }

        /// <summary>
        /// Ouvre le formulaire du jeu.
        /// Chaque jeu doit implémenter l'ouverture de son propre Form.
        /// </summary>
        public abstract void Launch();
    }
}
