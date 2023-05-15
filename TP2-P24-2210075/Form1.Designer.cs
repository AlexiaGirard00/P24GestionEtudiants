namespace TP2_P24_2210075
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsGestionEtudiants = new System.Windows.Forms.ToolStripButton();
            this.tsListeEtudiants = new System.Windows.Forms.ToolStripButton();
            this.tsStatistiques = new System.Windows.Forms.ToolStripButton();
            this.tsQuitter = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsGestionEtudiants,
            this.tsListeEtudiants,
            this.tsStatistiques,
            this.tsQuitter});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1782, 99);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsGestionEtudiants
            // 
            this.tsGestionEtudiants.Image = global::TP2_P24_2210075.Properties.Resources.reg;
            this.tsGestionEtudiants.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsGestionEtudiants.Name = "tsGestionEtudiants";
            this.tsGestionEtudiants.Size = new System.Drawing.Size(236, 93);
            this.tsGestionEtudiants.Text = "Gestion Étudiants";
            this.tsGestionEtudiants.Click += new System.EventHandler(this.tsGestionEtudiants_Click);
            // 
            // tsListeEtudiants
            // 
            this.tsListeEtudiants.Image = global::TP2_P24_2210075.Properties.Resources.liste;
            this.tsListeEtudiants.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsListeEtudiants.Name = "tsListeEtudiants";
            this.tsListeEtudiants.Size = new System.Drawing.Size(203, 93);
            this.tsListeEtudiants.Text = "Liste Étudiants";
            this.tsListeEtudiants.Click += new System.EventHandler(this.tsListeEtudiants_Click);
            // 
            // tsStatistiques
            // 
            this.tsStatistiques.Image = global::TP2_P24_2210075.Properties.Resources.stats;
            this.tsStatistiques.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsStatistiques.Name = "tsStatistiques";
            this.tsStatistiques.Size = new System.Drawing.Size(171, 93);
            this.tsStatistiques.Text = "Statistiques";
            this.tsStatistiques.Click += new System.EventHandler(this.tsStatistiques_Click);
            // 
            // tsQuitter
            // 
            this.tsQuitter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsQuitter.Image = global::TP2_P24_2210075.Properties.Resources.quitter;
            this.tsQuitter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsQuitter.Name = "tsQuitter";
            this.tsQuitter.Size = new System.Drawing.Size(125, 93);
            this.tsQuitter.Text = "Quitter";
            this.tsQuitter.Click += new System.EventHandler(this.tsQuitter_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1782, 1111);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsGestionEtudiants;
        private ToolStripButton tsListeEtudiants;
        private ToolStripButton tsStatistiques;
        private ToolStripButton tsQuitter;
    }
}