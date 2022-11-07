
namespace Pendu
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTest = new System.Windows.Forms.Button();
            this.grpTestLettres = new System.Windows.Forms.GroupBox();
            this.txtMot = new System.Windows.Forms.TextBox();
            this.gpmot = new System.Windows.Forms.GroupBox();
            this.btnRejouer = new System.Windows.Forms.Button();
            this.imgPendu = new System.Windows.Forms.PictureBox();
            this.lblResultat = new System.Windows.Forms.Label();
            this.grpTestLettres.SuspendLayout();
            this.gpmot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPendu)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(245, 135);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // grpTestLettres
            // 
            this.grpTestLettres.Controls.Add(this.lblResultat);
            this.grpTestLettres.Controls.Add(this.btnTest);
            this.grpTestLettres.Location = new System.Drawing.Point(12, 103);
            this.grpTestLettres.Name = "grpTestLettres";
            this.grpTestLettres.Size = new System.Drawing.Size(326, 164);
            this.grpTestLettres.TabIndex = 3;
            this.grpTestLettres.TabStop = false;
            this.grpTestLettres.Text = "Lettres cherchées";
            // 
            // txtMot
            // 
            this.txtMot.Location = new System.Drawing.Point(8, 19);
            this.txtMot.Name = "txtMot";
            this.txtMot.Size = new System.Drawing.Size(170, 20);
            this.txtMot.TabIndex = 4;
            this.txtMot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMot_KeyPress);
            // 
            // gpmot
            // 
            this.gpmot.Controls.Add(this.txtMot);
            this.gpmot.Location = new System.Drawing.Point(12, 12);
            this.gpmot.Name = "gpmot";
            this.gpmot.Size = new System.Drawing.Size(326, 85);
            this.gpmot.TabIndex = 6;
            this.gpmot.TabStop = false;
            this.gpmot.Text = "Mot à chercher";
            // 
            // btnRejouer
            // 
            this.btnRejouer.Image = global::Pendu.Properties.Resources.playagain;
            this.btnRejouer.Location = new System.Drawing.Point(12, 273);
            this.btnRejouer.Name = "btnRejouer";
            this.btnRejouer.Size = new System.Drawing.Size(93, 46);
            this.btnRejouer.TabIndex = 8;
            this.btnRejouer.UseVisualStyleBackColor = true;
            this.btnRejouer.Click += new System.EventHandler(this.btnRejouer_Click);
            // 
            // imgPendu
            // 
            this.imgPendu.Location = new System.Drawing.Point(368, 9);
            this.imgPendu.Name = "imgPendu";
            this.imgPendu.Size = new System.Drawing.Size(196, 255);
            this.imgPendu.TabIndex = 7;
            this.imgPendu.TabStop = false;
            // 
            // lblResultat
            // 
            this.lblResultat.AutoSize = true;
            this.lblResultat.Location = new System.Drawing.Point(5, 148);
            this.lblResultat.Name = "lblResultat";
            this.lblResultat.Size = new System.Drawing.Size(35, 13);
            this.lblResultat.TabIndex = 11;
            this.lblResultat.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 708);
            this.Controls.Add(this.btnRejouer);
            this.Controls.Add(this.imgPendu);
            this.Controls.Add(this.gpmot);
            this.Controls.Add(this.grpTestLettres);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpTestLettres.ResumeLayout(false);
            this.grpTestLettres.PerformLayout();
            this.gpmot.ResumeLayout(false);
            this.gpmot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPendu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox grpTestLettres;
        private System.Windows.Forms.TextBox txtMot;
        private System.Windows.Forms.GroupBox gpmot;
        private System.Windows.Forms.PictureBox imgPendu;
        private System.Windows.Forms.Button btnRejouer;
        private System.Windows.Forms.Label lblResultat;
    }
}

