using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TP2_P24_2210075
{
    public partial class GestionEtudiants : Form
    {

        public GestionEtudiants()
        {
            InitializeComponent();
        }

        public void GestionEtudiants_Load(object sender, EventArgs e)
        {
            foreach(Control ctrl in gbGestionEtudiant.Controls)
            {
                ctrl.Enabled = false;
            }

            btnSupprimer.Enabled = false;
            btnAjouter.Enabled = true;
            btnModifier.Enabled = false;
            btnEnregistrer.Enabled = false;

            dtpDateDeNaissance.MinDate = new DateTime(1900, 1, 1);
            dtpDateDeNaissance.MaxDate = new DateTime(2018, 1, 1);

            txtId.ReadOnly = true;
            txtNoteFinale.ReadOnly = true;

            lblBoxId.Hide();
            foreach(Control c in gbGestionEtudiant.Controls)
            {
                if(c is Label && c.Name.Length > 5)
                {
                    if ((c.Name.Substring(0,6)) == "lblBox")
                    {
                        c.Hide();
                    }
                }
                
            }

        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {

            ChercherEtudiant();
            
            btnSupprimer.Enabled = true;
            btnAjouter.Enabled = false;
            btnModifier.Enabled = true;
            btnEnregistrer.Enabled = true;

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Êtes-vous sûr de vouloir supprimer l'étudiant ?" + Environment.NewLine +
                "La suppression est définitive.", "Attention", MessageBoxButtons.YesNo);

            if(dr == DialogResult.Yes)
            {
                foreach (Student student in Liste.lstEtudiants)
                {
                    if (student.noId == txtNoId.Text)
                    {
                        try
                        {
                            Liste.lstEtudiantsSupprimer.Add(student);
                            Liste.lstEtudiants.Remove(student);

                            string currentPath = Directory.GetCurrentDirectory();

                            string sourcePath = currentPath + "\\Eleve.Dta\\" + student.codePermanent + "_" + student.nom + "_" + student.prenom + ".Dta";
                            string destiPath = currentPath + "\\EleveSupprimer.Dta\\" + student.codePermanent + "_" + student.nom + "_" + student.prenom + ".Dta";

                            File.Move(sourcePath, destiPath);

                            MessageBox.Show("L'étudiant a été supprimer.", "Terminer");

                            ClearInput();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Erreur");
                        }

                        return;
                        
                    }
                }

                
            }
            
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            ClearInput();

            foreach (Control control in gbGestionEtudiant.Controls)
            {
                control.Enabled = true;
            }

            btnAjouter.Enabled = false;
            btnSupprimer.Enabled = false;
            btnModifier.Enabled = false;
            btnEnregistrer.Enabled = true;
            
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            btnSupprimer.Enabled = true;
            btnAjouter.Enabled = false;
            btnEnregistrer.Enabled = true;

            txtAdresse.Enabled = true;
            txtVille.Enabled = true;
            mskCodePostal.Enabled = true;
            mskTelephone.Enabled = true;
            txtTP1.Enabled = true;
            txtTP2.Enabled = true;
            txtIntra.Enabled = true;
            txtFinal.Enabled = true;

            txtId.Enabled = false;
            txtPrenom.Enabled = false;
            txtNom.Enabled = false; 
            rbFemme.Enabled = false;
            rbHomme.Enabled = false;
            dtpDateDeNaissance.Enabled = false; 

        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            btnEnregistrer.Enabled = false;
            btnModifier.Enabled = true;
            btnAjouter.Enabled = true;

            if (InputValide())
            {
                if(txtId.Text == "")
                {
                    NouveauEtudiant();
                }else
                {
                    ModifierEtudiant();            
                }
                
            }
            
        }

        private bool ValideNom(TextBox txt, PictureBox pictureBox, Label lblBox)
        {
            pictureBox.Visible = false;

            if (txt.Text == "")
            {
                pictureBox.Visible = true;
                return false;
            }


            if(txt.Name == "txtNom") 
            { 
                if(txt.Text.Length < 3)
                {
                    lblBox.Text = "Le minimum de caractères est trois.";
                    pictureBox.Visible = true;
                    return false;
                }
                else if (IsNumeric(txt.Text))
                {
                    lblBox.Text = ("Veuillez entrer des données valide pour le " + lblBox.Name.Substring(6));
                    pictureBox.Visible = true;
                    return false;
                } 
            }
            else if ((txt.Text.Length < 2) || (IsNumeric(txt.Text)))
            {
                lblBox.Text = ("Veuillez entrer des données valide pour le " + lblBox.Name.Substring(6));
                pictureBox.Visible = true;
                return false;
            }
            return true;
        }

        private bool ValideSexe()
        {
            pictureBoxSexe.Visible = false;

            if ((!rbHomme.Checked) && (!rbFemme.Checked))
            {
                pictureBoxSexe.Visible = true;
                return false;
            }
            return true;
        }

        private bool ValideMsk(MaskedTextBox c, PictureBox pictureBox)
        {
            pictureBox.Visible = false;

            if(!c.MaskFull)
            {
                pictureBox.Visible = true;
                return false;
            }
            return true;
        }

        private bool ValideAdresseOuVille(TextBox txt, PictureBox pictureBox, Label lblBox)
        {
            pictureBox.Visible = false;

            if (txt.Text == "")
            {
                lblBox.Text = ("Veuillez entrer une " + lblBox.Name.Substring(6));
                pictureBox.Visible = true;
                return false;
            }
            else if (txt.Name == "txtVille")
            {
                foreach (char c in txt.Text)
                {
                    if (IsNumeric(c.ToString()))
                    {
                        lblBox.Text = ("Vous ne pouvez pas entrer de nombre");
                        pictureBox.Visible = true;
                        return false;
                    }
                }
            }
            else if (txt.Text.Length < 2)
            {
                lblBox.Text = ("Veuillez entrer des données valide");
                pictureBox.Visible = true;
                return false;
            }
            return true;

        }

        private bool ValideNote(TextBox txt, PictureBox pictureBox, Label lblBox)
        {
            string str = txt.Text;
            pictureBox.Visible = false;
            double note= default;
            

            if (txt.Text == "")
            {
                pictureBox.Visible = true;
                return false;
            }
            else if (!IsNumeric(str))
            {
                lblBox.Text = ("Veuillez entrer des" + Environment.NewLine + "données valide pour le " + Environment.NewLine + lblBox.Name.Substring(6));
                pictureBox.Visible = true;
                return false;
            }
            else if(double.TryParse(str, out note))
            {
                if(note < 0 || note > 100)
                {
                    lblBox.Text = ("Veuillez entrer une note" + Environment.NewLine + "entre 0 et 100. ");
                    pictureBox.Visible = true;
                    return false;

                }
            }
            return true;
        }


        private bool IsNumeric(string str)
        {
            if (int.TryParse(str, out int test))
            {
                return true;
            }
            return false;
        }


        private bool InputValide()
        {
            if(ValideNom(txtPrenom, pictureBoxPrenom, lblBoxPrenom) &&
               ValideNom(txtNom, pictureBoxNom, lblBoxNom) &&
               ValideSexe() &&
               ValideMsk(mskTelephone, pictureBoxTel) &&
               ValideAdresseOuVille(txtAdresse, pictureBoxAdresse, lblBoxAdresse) &&
               ValideAdresseOuVille(txtVille, pictureBoxVille, lblBoxVille) &&
               ValideMsk(mskCodePostal, pictureBoxCodePostal) &&
               ValideNote(txtTP1, pictureBoxTP1, lblBoxTP1) &&
               ValideNote(txtTP2, pictureBoxTP2, lblBoxTP2) &&
               ValideNote(txtIntra, pictureBoxIntra, lblBoxIntra) &&
               ValideNote(txtFinal, pictureBoxFinal, lblBoxFinal))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Veuillez coriger les erreurs avant de continuer.", "Erreur");
                return false;
            }
        }

        //*****************************NouveauEtudiant*****************************

        private void NouveauEtudiant()
        {
            string codePerm = CreerCodePerm();
            txtId.Text = codePerm;
            string noId = CreerNodi();
            txtNoId.Text = noId;
            char sexeChar = EtudiantSexe();

            string nom = txtNom.Text;
            nom = char.ToUpper(nom[0]) + nom.Substring(1);

            string prenom = txtPrenom.Text;
            prenom = char.ToUpper(prenom[0]) + prenom.Substring(1);

            foreach (Student student in Liste.lstEtudiants)
            {
                if (student.codePermanent == txtId.Text)
                {
                    MessageBox.Show("Impossible de créer l'étudiant. Ce code permanent a déjà été attribuer à un autre étudiant.", "Code permament indisponible");
                    return;
                }
            }

            double noteFinale = calculerNoteFinale();
            txtNoteFinale.Text = noteFinale.ToString("N2");

            Student newStudent = new Student(codePerm, nom.PadRight(15), prenom.PadRight(15), noId, sexeChar,
                   (dtpDateDeNaissance.Text).PadRight(10), (txtAdresse.Text).PadRight(30), (txtVille.Text).PadRight(20), mskCodePostal.Text, mskTelephone.Text,
                   Convert.ToDouble(txtIntra.Text), Convert.ToDouble(txtFinal.Text), Convert.ToDouble(txtTP1.Text),
                   Convert.ToDouble(txtTP2.Text), noteFinale);

            Liste.lstEtudiants.Add(newStudent);

            EcrireEtudiantFichier(newStudent);

            MessageBox.Show("L'étudiant " + txtPrenom.Text + " " + txtNom.Text  + " a été ajouté.", "Terminer");
        }

        private string CreerCodePerm()
        {
            Random rnd = new Random();
            string numRnd;

            string nomLettres = txtNom.Text.Substring(0, 3).ToUpper();
            string prenomLettre = txtPrenom.Text.Substring(0, 1).ToUpper();

            string dateNaissance = dtpDateDeNaissance.Value.ToString("yyyy-MM-dd");
            string[] splitDate = dateNaissance.Split('-');

            string anneeNaissance = splitDate[0].Substring(2);

            int moisNaissance = Convert.ToInt32(splitDate[1]);
            string jourNaissance = splitDate[2];

            string moisStr = "";

            if (rbFemme.Checked)
            {
                moisNaissance += 50;
            }

            if(moisNaissance < 10)
            {
                moisStr = "0" + moisNaissance.ToString();
            }
            else
            {
                moisStr = moisNaissance.ToString();
            }

            numRnd = rnd.Next(0, 9).ToString();
            numRnd += rnd.Next(0, 9).ToString();

            string codePerm = nomLettres.ToUpper() + prenomLettre.ToUpper() + jourNaissance + moisStr + anneeNaissance + numRnd;
            
            return codePerm;


        }

        private string CreerNodi()
        {
            string nomLettres = txtNom.Text.Substring(0, 3).ToUpper();
            string prenomLettre = txtPrenom.Text.Substring(0,1).ToUpper();

            Random rnd = new Random();
            int nbRandom = rnd.Next(0,9);

            string noId = nomLettres + prenomLettre + nbRandom.ToString();

            if (Liste.lstNoId.Contains(noId))
            {
                while (Liste.lstNoId.Contains(noId))
                {
                    noId = noId.Substring(noId.Length - 2);
                    nbRandom = rnd.Next(0, 9);
                    noId += nbRandom.ToString();
                }
            }

            Liste.lstNoId.Add(noId);
            return noId;
        }

        private char EtudiantSexe()
        {
            if (rbFemme.Checked)
            {
                return 'F';
            }
            else
            {
                return 'H';
            }
        }

        public void EcrireEtudiantFichier(Student student)
        {
            string path = "Eleve.Dta\\" + txtId.Text + "_" + txtNom.Text + "_" + txtPrenom.Text + ".Dta";

            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(student.codePermanent);
            bw.Write(student.nom);
            bw.Write(student.prenom);
            bw.Write(student.noId);
            bw.Write(student.sexe);
            bw.Write(student.dateNaissance);
            bw.Write(student.adresse);
            bw.Write(student.ville);
            bw.Write(student.codePostal);
            bw.Write(student.telephone);
            bw.Write(student.intra);
            bw.Write(student.final);
            bw.Write(student.tp1);
            bw.Write(student.tp2);
            bw.Write(student.noteFinale);

            bw.Close();
            fs.Close();
        }

        private void ChercherEtudiant()
        {
            if (txtGestionIdRechercher.Text == "")
            {
                MessageBox.Show("Veuillez entrer le code permanent ou le nom suivi du prénom.");
                return;
            }

            foreach (Student student in Liste.lstEtudiants)
            {
                if (txtGestionIdRechercher.Text == student.codePermanent)
                {
                    AfficherEtudiant(student);
                    return;
                }
                else if (txtGestionIdRechercher.Text == student.nom + " " + student.prenom)
                {
                    AfficherEtudiant(student);
                    return;
                }
            }

            MessageBox.Show("Aucun étudiant ne correspond à la recherche. Veuillez vérifier l'orthogrape", "Invalide");

        }

        public void AfficherEtudiant(Student student)
        {
            txtId.Text = student.codePermanent;
            txtNom.Text = student.nom;
            txtPrenom.Text = student.prenom;
            txtNoId.Text = student.noId;
            
            if(student.sexe == 'F')
            {
                rbFemme.Checked = true;
            }
            else
            {
                rbHomme.Checked = true;
            }

            dtpDateDeNaissance.Value = Convert.ToDateTime(student.dateNaissance);
            txtAdresse.Text = student.adresse;
            txtVille.Text = student.ville;
            mskCodePostal.Text = student.codePostal;
            mskTelephone.Text = student.telephone;
            txtIntra.Text = student.intra.ToString("N2");
            txtFinal.Text = student.final.ToString("N2");
            txtTP1.Text = student.tp1.ToString("N2");
            txtTP2.Text = student.tp2.ToString("N2");
            txtNoteFinale.Text = student.noteFinale.ToString("N2");


            foreach (Control control in gbGestionEtudiant.Controls)
            {
               control.Enabled = false;
            }
            btnSupprimer.Enabled = true;
            btnModifier.Enabled = true;

        }

        private void ModifierEtudiant()
        {
            foreach(Student student in Liste.lstEtudiants)
            {
                if (txtId.Text == student.codePermanent)
                {
                    double noteFinale = calculerNoteFinale();
                    txtNoteFinale.Text = String.Format(noteFinale.ToString(), 0.00);

                    student.adresse = txtAdresse.Text;
                    student.ville = txtVille.Text;
                    student.codePostal = mskCodePostal.Text;
                    student.telephone = mskTelephone.Text;
                    student.intra = Convert.ToDouble(txtIntra.Text);
                    student.final = Convert.ToDouble(txtFinal.Text);
                    student.tp1 = Convert.ToDouble(txtTP1.Text);
                    student.tp2 = Convert.ToDouble(txtTP2.Text);
                    student.noteFinale = Convert.ToDouble(txtNoteFinale.Text);

                    EcrireEtudiantFichier(student);

                    MessageBox.Show("L'étudiant " + txtPrenom.Text + " " + txtNom.Text + " " + " a été modifié.", "Terminer");

                    btnAjouter.Enabled = true;

                }
                
            }
           
        }
        
        private double calculerNoteFinale()
        {

            double inputTP1 = Convert.ToDouble(txtTP1.Text) * 10 / 100;
            double inputTP2 = Convert.ToDouble(txtTP2.Text) * 10 / 100;
            double inputIntra = Convert.ToDouble(txtIntra.Text) * 40 / 100;
            double inputFiale = Convert.ToDouble(txtFinal.Text) * 40 / 100;
            double resultNoteFinale = inputTP1 + inputTP2 + inputIntra + inputFiale;

            return resultNoteFinale;
        }

        private void ClearInput()
        {
            foreach (Control ctrl in gbGestionEtudiant.Controls)
            {
                if(ctrl is TextBox || ctrl is MaskedTextBox)
                {
                    ctrl.Text = default;
                }
            }

            rbFemme.Checked = false;
            rbHomme.Checked = false;

            dtpDateDeNaissance.Value = new DateTime(2018, 1, 1);

            txtNoId.Text = "";
        }


        //******************************events***************************************
        public void ShowError(PictureBox pb)
        {
            string pbLastChar = pb.Name.Substring(11);
            string lblLastChar;
            
            foreach(Control lbl in gbGestionEtudiant.Controls)
            {
                if((lbl is Label) && (lbl.Name.Length > 7 ) && (lbl.Name.Substring(0,6) == "lblBox"))
                {
                    lblLastChar = lbl.Name.Substring(7);
                    if (lblLastChar == pbLastChar)
                    {
                        lbl.Show();
                    }
                }
            }
        
        }

        public void HideError(PictureBox pb)
        {
            string pbLastChar = pb.Name.Substring(11);
            string lblLastChar;

            foreach (Control lbl in gbGestionEtudiant.Controls)
            {
                if ((lbl is Label) && (lbl.Name.Length > 7) && (lbl.Name.Substring(0, 6) == "lblBox"))
                {
                    lblLastChar = lbl.Name.Substring(7);
                    if (lblLastChar == pbLastChar)
                    {
                        lbl.Hide();
                    }
                }
            }
        }



        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox) sender;
            {
                ShowError(pb);
            }
            
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox) sender;
            {
                HideError(pb);
            }
        }

        private void txtBox_Leave(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            
            if(txt.Name == "txtPrenom") { ValideNom(txt, pictureBoxPrenom, lblBoxPrenom);}
            else if(txt.Name == "txtNom") { ValideNom(txt, pictureBoxNom, lblBoxNom);}
            else if(txt.Name == "txtSexe") { ValideSexe(); }
            else if(txt.Name == "txtAdresse") { ValideAdresseOuVille(txt, pictureBoxAdresse, lblBoxAdresse);}
            else if(txt.Name == "txtVille") { ValideAdresseOuVille(txt, pictureBoxVille, lblBoxVille); }
            else if(txt.Name == "txtTP1") { ValideNote(txt, pictureBoxTP1, lblBoxTP1); }
            else if(txt.Name == "txtTP2") { ValideNote(txt, pictureBoxTP2, lblBoxTP2); }
            else if(txt.Name == "txtIntra") { ValideNote(txt, pictureBoxIntra, lblBoxIntra); }
            else if(txt.Name == "txtFinal") { ValideNote(txt, pictureBoxFinal, lblBoxFinal); }
            
        }

        private void mskBox_Leave(object sender, EventArgs e)
        {
            MaskedTextBox msk = (MaskedTextBox)sender;
            if (msk.Name == "mskTelephone") { ValideMsk(mskTelephone, pictureBoxTel); }
            else if (msk.Name == "mskCodePostal") { ValideMsk(mskCodePostal, pictureBoxCodePostal); }
        }

        private void rb_Leave(object sender, EventArgs e)
        {
            ValideSexe();
        }

        private void pbLoupe_MouseHover(object sender, EventArgs e)
        {
            lblLoupe.Visible = true;
        }

        private void pbLoupe_MouseLeave(object sender, EventArgs e)
        {
            lblLoupe.Visible = false;
        }
    }
}
