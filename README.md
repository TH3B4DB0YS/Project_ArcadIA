
            PROJECT ARCAD'IA
   Plateforme Arcade en Programmation Orientée Objet


Langage / Framework : C# WinForms (.NET)

-----------------------------------------------
1. DESCRIPTION DU PROJET
-----------------------------------------------

ArcadIA est une plateforme arcade regroupant 5 mini-jeux développés
en programmation orientée objet (C# WinForms). Le joueur se connecte
avec un identifiant (ex : nom GitHub), progresse en gagnant de l'XP
dans chaque jeu, et débloque progressivement de nouveaux jeux en
fonction de son niveau.

-----------------------------------------------
2. LES 5 JEUX CHOISIS (Orienté Objet)
-----------------------------------------------

  1. Démineur       → Code de base disponible dans le cours, à adapter en OO.
  2. Snake          → Code existant à modifier/restructurer en orienté objet.
  3. Mastermind     → Code de base disponible dans le cours, à adapter en OO.
  4. Tic Tac Boom   → Jeu à développer entièrement de zéro.
  5. Pendu          → Jeu à développer entièrement de zéro.

-----------------------------------------------
3. INTERFACE UTILISATEUR (WinForms)
-----------------------------------------------

  Page 1 — Écran de Login
  ─────────────────────────
  - Champ de saisie pour le nom d'utilisateur (ex : nom GitHub).
  - Bouton de connexion.
  - Le profil du joueur est chargé depuis une base de données XML.
  - Si le joueur n'existe pas, un nouveau profil est créé automatiquement.

  Page 2 — Menu Principal / Sélection des Jeux
  ──────────────────────────────────────────────
  - Affichage des jeux disponibles en fonction du niveau du compte.
  - De base, un seul jeu est débloqué (le Démineur).
  - Les autres jeux se débloquent progressivement avec la montée en niveau.
  - Barre de progression (ProgressBar WinForms) affichant l'avancement
    de l'XP vers le prochain niveau.
  - Affichage du niveau actuel et du nombre de jeux débloqués.

-----------------------------------------------
4. SYSTÈME DE PROGRESSION (XP & NIVEAUX)
-----------------------------------------------

  Principe général :
  - Chaque jeu rapporte de l'XP selon les performances du joueur.
  - L'XP accumulée permet de monter en niveau (Level).
  - Un nouveau jeu est débloqué tous les 15 niveaux.
  - Le niveau maximum est 100.

  Paliers de déblocage :
  ┌─────────┬─────────────────────┐
  │ Niveau  │ Jeux débloqués      │
  ├─────────┼─────────────────────┤
  │  0      │ 1 (Démineur)        │
  │  15     │ 2 (+Snake)          │
  │  30     │ 3 (+Mastermind)     │
  │  45     │ 4 (+Tic Tac Boom)   │
  │  60     │ 5 (+Pendu)          │
  └─────────┴─────────────────────┘

-----------------------------------------------
5. GESTION DE L'XP PAR JEU
-----------------------------------------------

  🐍 Snake
     → XP = nombre de pommes mangées durant la partie.
     → Plus le joueur survit longtemps et mange de pommes, plus il gagne d'XP.

  💣 Démineur
     → XP = nombre de cases révélées sans toucher de mine.
     → Bonus d'XP si la grille est complétée avec succès.

  🎨 Mastermind
     → XP = nombre de codes couleur trouvés (combinaisons correctes).
     → Moins le joueur utilise de tentatives, plus le bonus d'XP est élevé.

  💥 Tic Tac Boom
     → XP = nombre de mots trouvés avant l'explosion.
     → Chaque mot valide rapporte de l'XP.

  📝 Pendu
     → XP = nombre de mots devinés correctement (idem que Tic Tac Boom).
     → Bonus si le mot est trouvé avec peu d'erreurs.

-----------------------------------------------
6. ARCHITECTURE TECHNIQUE (Classes principales)
-----------------------------------------------

  Player.cs
  ─────────
  - Propriétés : GameID, Level, UnlockedGames, NbGames
  - Méthodes : AddLevel(), NextGame(), Reset(), LevelMaximum()
  - Sérialisable en XML pour la sauvegarde.

  GameDatabase.cs
  ───────────────
  - Gestion de la base de données des joueurs (fichier XML).
  - Méthodes : GetOrCreatePlayer(), UpdatePlayerLevel(),
               GetAllPlayers(), LoadDatabase(), SaveDatabase()

  Form1.cs
  ────────
  - Interface principale (login + affichage profil joueur).
  - Interaction avec GameDatabase pour charger/créer les profils.

  Program.cs
  ──────────
  - Point d'entrée de l'application WinForms.

===============================================
