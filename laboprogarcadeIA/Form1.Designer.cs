/************************************************************
 * ==========================================================
 *  PROJECT ARCAD'IA – Plateforme Arcade (C# WinForms)
 * ==========================================================
 * Fichier     : Form1.Designer.cs
 * Auteurs     : Timothé CLINQUART, Clément CAULIEZ,
 *               Tristan DESPELCHIN, Jean-Sébastien BURLANDY
 * Date        : 24 avril 2026
 * Objet       : Code auto-généré par le Designer WinForms.
 *               Définition des contrôles de l'écran de login :
 *               label "Entrez votre nom", champ de saisie,
 *               bouton "Se connecter".
 *
 * NOTE        : Ne pas modifier manuellement ce fichier,
 *               utiliser le Designer visuel de Visual Studio.
 * ==========================================================
 ************************************************************/
namespace laboprogarcadeIA
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            labelLogin = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(32, 32);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Location = new Point(160, 84);
            labelLogin.Margin = new Padding(2, 0, 2, 0);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(103, 15);
            labelLogin.TabIndex = 4;
            labelLogin.Text = "Entrez votre nom :";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(160, 103);
            textBox1.Margin = new Padding(2, 1, 2, 1);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(110, 23);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged_1;
            // 
            // button1
            // 
            button1.Location = new Point(124, 128);
            button1.Margin = new Padding(2, 1, 2, 1);
            button1.Name = "button1";
            button1.Size = new Size(179, 22);
            button1.TabIndex = 3;
            button1.Text = "Se connecter";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Gamechoise_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 211);
            Controls.Add(labelLogin);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Margin = new Padding(2, 1, 2, 1);
            Name = "Form1";
            Text = "ArcadIA";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private Label labelLogin;
        private TextBox textBox1;
        private Button button1;
        private Button btnGame1;
        private Button btnGame2;
        private Button btnGame3;
        private Button btnGame4;
        private Button btnGame5;
    }
}
