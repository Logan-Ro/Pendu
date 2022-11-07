/**
 * Jeu du pendu
 * Logan Robillard
 * 18/10/2022
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pendu
{
    public partial class Form1 : Form
    {
        private string mot;
        private int etapePendu;
        private int maxPendu = 10;

        public Form1()
        {
            InitializeComponent();
        }

        private void CreeBoutons()
        {
            // variables locales
            char[] tAlpha = new char[26]; // tableau des lettres
            int sizeButton = 30; // taille du côté d'un bouton de lettre
            int posXButton = 6; // position du 1er bouton à partir de la gauche 
            int posYButton = 18; // position du 1er bouton à partir du haut
            int nbLettreParLigne = 9; // détermine le nombre de boutons de lettres par ligne
            // remplissage du tableau de lettres
            for (int k = 0; k < tAlpha.Length; k++)
            {
                tAlpha[k] = (char)('A' + k);
            }
            // création et positionnement des boutons
            int line = -1, col = 0;
            for (int k = 0; k < tAlpha.Length; k++)
            {
                // création du bouton
                Button btn = new Button();
                // ajout du bouton dans le groupe de boutons pour l'affichage
                grpTestLettres.Controls.Add(btn);
                // Ajoute la lettre correspondante au bouton
                btn.Text = tAlpha[k].ToString();
                // fixe la taille du bouton
                btn.Size = new Size(sizeButton, sizeButton);
                // ajout d'une écoute sur le clic du bouton
                btn.Click += new System.EventHandler(btnAlpha_Click);
                // changement de ligne au bout d'un certain nombre de boutons affichés
                col++;
                if (k % nbLettreParLigne == 0)
                {
                    line++;
                    col = 0;
                }
                // positionne le bouton dans le groupe
                btn.Location = new Point(posXButton + sizeButton * col, posYButton + sizeButton * line);
            }
        }
        private void ActiveBoutons()
        {
            // active les boutons
            for (int k = 0; k < grpTestLettres.Controls.Count; k++)
            {
                grpTestLettres.Controls[k].Enabled = true;
            }
            grpTestLettres.Controls[0].Focus();
        }
        private void GestionFocusBoutonLettre()
        {
            int k = 0;
            while (!grpTestLettres.Controls[k].Enabled)
            {
                k++;
            }
            grpTestLettres.Controls[k].Focus();
        }
        private void btnAlpha_Click(object sender, EventArgs e)
        {
            // récupération du bouton concerné par l'événement
            Button btnLettre = ((Button)sender);
            // désactive le bouton et donne le focus au premier bouton accessible
            btnLettre.Enabled = false;
            GestionFocusBoutonLettre();
            // recherche la lettre
            char lettre = char.Parse(btnLettre.Text);
            if (!RechercheLettreDansMot(lettre))
            {
                // lettre non trouvée : affichage du pendu
                if (AffichePendu())
                {
                    // si totalement pendu, perdu et fin du jeu
                    FinJeu("PERDU");
                }
            }
            else
            {
                // il n'y a plus de lettre à trouver
                if (txtMot.Text.IndexOf('-') == -1)
                {
                    // s'il n'y a plus de tiret (toutes les lettres trouvées) c'est gagné
                    FinJeu("GAGNE");
                }
            }
        }
        private void PreparationPhase1()
        {
            // réinitialise l'étape du pendu et affiche l'image vide
            etapePendu = 0;
            AfficheImage(etapePendu);
            // désactive la zone de la phase 2 (proposition de lettres)
            grpTestLettres.Enabled = false;
            // supprime le message
            lblResultat.Text = "";
            // active, vide et se positionne sur la zone de saisie du mot
            txtMot.Enabled = true;
            txtMot.Text = "";
            txtMot.Focus();
        }

        private void PreparationPhase2()
        {
            // active les boutons et la zone de la phase 2 (proposition de lettres)
            ActiveBoutons();
            // active la zone de la phase 2 (proposition de lettres)
            grpTestLettres.Enabled = true;
            // positionne le focus sur le premier bouton (lettre A)
            grpTestLettres.Controls[0].Focus();
            // désactive la zone de texte contenant le mot
            txtMot.Enabled = false;
        }
        private void AfficheImage(int num)
        {
            imgPendu.Image = (Image)Properties.Resources.ResourceManager.GetObject("pendu" + num);
        }
        private bool AffichePendu()
        {
            etapePendu++;
            AfficheImage(etapePendu);
            return (etapePendu == maxPendu);
        }

        private bool RechercheLettreDansMot(char lettre)
        {
            int position = -1; // position de la lettre dans le mot
            bool trouve = false; // pour savoir si la lettre a été trouvée
            // boucle sur la recherche de la lettre (qui peut être présente plusieurs fois)
            do
            {
                // récupère la position de la lettre (ou -1)
                position = mot.IndexOf(lettre, position + 1);
                if (position != -1)
                {
                    trouve = true;
                    // remplace le tiret par la lettre dans la zone de texte
                    txtMot.Text = txtMot.Text.Remove(position, 1);
                    txtMot.Text = txtMot.Text.Insert(position, lettre.ToString());
                }
            } while (position != -1);
            return trouve;
        }

        private void FinJeu(string message)
        {
            // affichage du message (gagné ou perdu)
            lblResultat.Text = message;
            // affiche le mot correct
            txtMot.Text = mot;
            // désactive la zone de proposition de lettre
            grpTestLettres.Enabled = false;
            // se positionne sur le bouton pour recommencer
            btnRejouer.Focus();
        }

        private bool MotCorrect(string unMot)
        {
            unMot = unMot.ToUpper();
            bool correct = true;
            for (int k = 0; k < unMot.Length; k++)
            {
                //   if (char.Parse(unMot.Substring(k, 1)) < 'A' || char.Parse(unMot.Substring(k, 1)) > 'Z')
                if (unMot[k] < 'A' || unMot[k] > 'Z')
                {
                    correct = false;
                }
            }
            return correct;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // création des boutons des lettres
            CreeBoutons();
            // préparation des objets graphiques pour la phase 1 (saisie du mot)
            PreparationPhase1();
        }

        private void txtMot_KeyPress(object sender, KeyPressEventArgs e)
        {
            // validation donc fin de la saisie du mot
            if (e.KeyChar == (char)Keys.Enter)
            {
                // vérifie qu'un mot a été tapé et qu'il est correct (uniquement lettres)
                if (!txtMot.Text.Equals("") && MotCorrect(txtMot.Text))
                {
                    // met le mot en majuscule et le mémorise dans une propriété
                    mot = txtMot.Text.ToUpper();
                    // remplit la zone de tirets à la place des lettres
                    txtMot.Text = "";
                    for (int k = 0; k < mot.Length; k++)
                    {
                        txtMot.Text += "-";
                    }
                    // préparation des objets graphiques pour la phase 2 (recherche du mot)
                    PreparationPhase2();
                }
                else
                {
                    // le mot n'est pas correct : efface la zone
                    MessageBox.Show("Le mot ne doit comporter que des lettres alphabétiques (pas d'espace, pas d'accent)");
                    txtMot.Text = "";
                    txtMot.Focus();
                }
            }
        }

        private void cboLettre_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnTest.Focus();
        }

        private void btnRejouer_Click(object sender, EventArgs e)
        {
            // préparation des objets graphiques pour la phase 1 (saisie du mot)
            PreparationPhase1();
        }
    }
}
