using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace laboprogarcadeIA
{
    public partial class FormPendu : Form
    {
        const int TAILLE_BOUTON = 40; // Légèrement réduit pour bien rentrer dans la fenêtre
        const int NB_BOUTONS_PAR_LIGNE = 7;

        internal PenduGame Jeu { get; }

        public FormPendu(PenduGame jeu)
        {
            this.Jeu = jeu;
            InitializeComponent();
            CréerClavier();
            AfficherMotATrouver(Jeu.Mot, Jeu.BonnesLettres);
        }

        private void CréerClavier()
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < alphabet.Length; i++)
            {
                char c = alphabet[i];
                Button button = new Button();
                button.Font = new Font("Segoe UI", 12F);
                button.Location = new Point((i % NB_BOUTONS_PAR_LIGNE) * TAILLE_BOUTON, (i / NB_BOUTONS_PAR_LIGNE) * TAILLE_BOUTON);
                button.Size = new Size(TAILLE_BOUTON, TAILLE_BOUTON);
                button.TabIndex = 0;
                button.Text = c.ToString();
                button.UseVisualStyleBackColor = true;
                button.Click += clavier_Click;
                clavierPanel.Controls.Add(button);
            }
        }

        public void AfficherMotATrouver(string mot, List<char> bonnesLettres)
        {
            if (string.IsNullOrEmpty(mot)) return;

            string motAffiché = "";
            foreach (char lettre in mot)
            {
                if (lettre == ' ') // Pour gérer les espaces dans "tarte aux pommes"
                {
                    motAffiché += "  ";
                    continue;
                }

                if (bonnesLettres.Contains(lettre))
                    motAffiché += lettre + " ";
                else
                    motAffiché += "_ ";
            }
            motATrouverLabel.Text = motAffiché;
            this.Refresh();
        }

        private void clavier_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string lettre = btn.Text.ToLower();
            btn.Enabled = false; // Désactive le bouton pour ne pas cliquer 2 fois sur la même lettre !

            this.Jeu.ProposerLettre(lettre[0]);
            this.AfficherMotATrouver(Jeu.Mot, Jeu.BonnesLettres);

            // Si le jeu est terminé (La vérification a lieu dans ProposerLettre)
            if (!this.Jeu.IsPlaying) 
            {
                this.Close(); // On ferme la fenêtre WinForms
            }
        }
    }
}
