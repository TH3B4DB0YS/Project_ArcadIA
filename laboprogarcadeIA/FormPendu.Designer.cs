namespace laboprogarcadeIA
{
    partial class FormPendu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label motATrouverLabel;
        private System.Windows.Forms.Panel clavierPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.motATrouverLabel = new System.Windows.Forms.Label();
            this.clavierPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // motATrouverLabel
            // 
            this.motATrouverLabel.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.motATrouverLabel.Location = new System.Drawing.Point(12, 20);
            this.motATrouverLabel.Name = "motATrouverLabel";
            this.motATrouverLabel.Size = new System.Drawing.Size(400, 50);
            this.motATrouverLabel.TabIndex = 0;
            this.motATrouverLabel.Text = "_ _ _ _";
            this.motATrouverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clavierPanel
            // 
            this.clavierPanel.Location = new System.Drawing.Point(75, 100);
            this.clavierPanel.Name = "clavierPanel";
            this.clavierPanel.Size = new System.Drawing.Size(280, 160);
            this.clavierPanel.TabIndex = 1;
            // 
            // FormPendu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 301);
            this.Controls.Add(this.clavierPanel);
            this.Controls.Add(this.motATrouverLabel);
            this.Name = "FormPendu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Jeu du Pendu";
            this.ResumeLayout(false);
        }
    }
}
