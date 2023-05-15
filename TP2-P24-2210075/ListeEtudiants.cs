using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2_P24_2210075
{
    public partial class ListeEtudiants : Form
    {
        public ListeEtudiants()
        {
            InitializeComponent();
        }

        private void ResultSearch(Student student)
        {
            ActivateMdiChild(GestionEtudiants.ActiveForm);

            GestionEtudiants GestionForm = new GestionEtudiants();
            this.Hide();
            GestionForm.MdiParent = this.MdiParent;
            GestionForm.ControlBox = false;
            GestionForm.Dock = DockStyle.Fill;
            GestionForm.BringToFront();
            GestionForm.Show();
            GestionForm.AfficherEtudiant(student);
        }

        private void ListeEtudiants_Load(object sender, EventArgs e)
        {
            lstViewEtudiant.View = View.Details;
            lstViewEtudiant.GridLines = true;
            lstViewEtudiant.FullRowSelect = true;

            //Column header
            lstViewEtudiant.Columns.Add("");
            lstViewEtudiant.Columns.Add("No.");
            lstViewEtudiant.Columns.Add("Code Permanent"); 
            lstViewEtudiant.Columns.Add("Nom");
            lstViewEtudiant.Columns.Add("Prénom");
            lstViewEtudiant.Columns.Add("No. Identificatiom");
            lstViewEtudiant.Columns.Add("Sexe");
            lstViewEtudiant.Columns.Add("Date Naissance");
            lstViewEtudiant.Columns.Add("Adresse");
            lstViewEtudiant.Columns.Add("Ville");
            lstViewEtudiant.Columns.Add("Code Postal");
            lstViewEtudiant.Columns.Add("Téléphone");
            lstViewEtudiant.Columns.Add("Intra (%)");
            lstViewEtudiant.Columns.Add("Final (%)");
            lstViewEtudiant.Columns.Add("TP1 (%)");
            lstViewEtudiant.Columns.Add("TP2 (%)");
            lstViewEtudiant.Columns.Add("Note Finale (%)");


            int i = 1;
            foreach (Student student in Liste.lstEtudiants)
            {
                ListViewItem item = new ListViewItem();

                item.SubItems.Add(i.ToString());

                foreach (PropertyInfo property in student.GetType().GetProperties())
                {
                    var propriValue = property.GetValue(student);

                    if (propriValue != null)
                    {
                        item.SubItems.Add(propriValue.ToString());
                    }
                    
                }

                lstViewEtudiant.Items.Add(item);
                i++;
            }

            foreach (ColumnHeader column in lstViewEtudiant.Columns)
            {
                if(column.Text.Length <= 2)
                {
                    column.Width = -1;
                }else
                {
                    column.Width = -2;
                }

                column.TextAlign = HorizontalAlignment.Center;
            }

            lstViewEtudiant.Columns[0].Dispose();

            //J'ai ajouter une colonne vide au début pour ensuite la cacher, car sinon je n'arrivais pas à center le texte dans la première cellule.

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lstViewEtudiant.Items[0].Selected = false;

            

            if(txtSearch.Text == "")
            {
                MessageBox.Show("Veuillez entrer un ID ou le nom suivi du prénom.", "Champs vide");
                return;
            }

            foreach (Student student in Liste.lstEtudiants)
            {
                if (txtSearch.Text == student.codePermanent)
                {
                    ResultSearch(student);
                    return;
                }
                else if (txtSearch.Text == student.nom + " " + student.prenom)
                {
                    ResultSearch(student);
                    return;
                }

            }
            MessageBox.Show("Aucun étudiant ne correspond à la recherche. Veuillez vérifier l'orthogrape", "Invalide");


        }

        private void lstViewEtudiant_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var itemIndex = lstViewEtudiant.SelectedItems.Count;

            string pathStudent;

            foreach(Student student in Liste.lstEtudiants)
            {
                for(int i = 0; i < Liste.lstEtudiants.Count -1; i++)
                {
                    if(i == itemIndex)
                    {
                        pathStudent = ("Eleve.Dta\\" + student.codePermanent + "_" + student.nom + "_" + student.prenom + ".txt");

                        
                    }
                }
            }
                
  
        }
    }
}
