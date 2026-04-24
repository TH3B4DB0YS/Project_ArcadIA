using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace laboprogarcadeIA
{
    public class PenduGame : Game
    {
        public string Mot { get; private set; }
        private string MotSansAccent;
        public List<char> BonnesLettres { get; private set; } = new List<char>();
        private List<char> MauvaisesLettres = new List<char>();

        public PenduGame() : base("Pendu", "Devinez le mot avant d'être pendu !", 60)
        {
        }

        public override void StartGame(Player player)
        {
            base.StartGame(player);
            BonnesLettres.Clear();
            MauvaisesLettres.Clear();
            ChoisirMotAleatoire();
        }

        public bool EstUneLettreValide(char lettre)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            return alphabet.Contains(lettre.ToString().ToLower());
        }

        public bool TesteSiLettreEstDansMot(char lettre)
        {
            for (int i = 0; i < this.MotSansAccent.Length; i++)
            {
                if (this.MotSansAccent[i] == lettre)
                {
                    return true;
                }
            }
            return false;
        }

        public void ProposerLettre(char lettre)
        {
            if (TesteSiLettreEstDansMot(lettre))
                BonnesLettres.Add(lettre);
            else
                MauvaisesLettres.Add(lettre);

            // Vérifier les conditions de victoire ou défaite
            if (MotEstTrouvé())
            {
                EndGame();
                MessageBox.Show("Gagné ! Le mot était " + Mot, "Victoire");
            }
            else if (MauvaisesLettres.Count >= 7) // Limite d'erreurs max (pendu)
            {
                EndGame();
                MessageBox.Show("Perdu ! Le mot était " + Mot, "Défaite");
            }
        }

        public bool MotEstTrouvé()
        {
            if (string.IsNullOrEmpty(Mot)) return false;

            foreach (char lettre in Mot)
            {
                if (BonnesLettres.Contains(lettre) == false)
                {
                    return false;
                }
            }
            return true;
        }

        private void RetirerAccent()
        {
            this.MotSansAccent = "";
            string avecAccents = "àâäçéèêëîïôöù";
            string sansAccents = "aaaceeeeiioou";

            foreach (char lettre in this.Mot)
            {
                int index = avecAccents.IndexOf(lettre);
                if (index == -1)
                {
                    this.MotSansAccent += lettre;
                }
                else
                {
                    this.MotSansAccent += sansAccents[index];
                }
            }
        }

        public void ChoisirMotAleatoire()
        {
            string[] lignes = ["pom", "bananes", "cerise", "lasagnes", "pizzas", "couscous", "choucroute", "tarte aux pommes", "crêpes", "gaufres", "croissants", "pain au chocolat", "éclair au chocolat", "macarons", "mille-feuille", "tiramisu", "cheesecake", "brownies", "cookies", "glace à la vanille", "sorbet au citron"];

            Random random = new Random();
            int indiceAleatoire = random.Next(lignes.Length);

            this.Mot = lignes[indiceAleatoire].ToLower();
            this.RetirerAccent();
        }

        protected override int CalculateXP()
        {
            if (MotEstTrouvé())
            {
                int xp = (Mot.Length * 10) - (MauvaisesLettres.Count * 5);
                return xp > 0 ? xp : 0;
            }
            return 0; // Pas d'XP si on perd
        }

        public override void Launch()
        {
            // Le "Program.cs" d'origine est remplacé par cette méthode
            // On s'assure d'abord qu'une partie est bien démarrée (si on teste manuellement)
            if (string.IsNullOrEmpty(Mot))
            {
                StartGame(this.CurrentPlayer);
            }

            FormPendu form = new FormPendu(this);
            form.ShowDialog();
        }
    }
}
