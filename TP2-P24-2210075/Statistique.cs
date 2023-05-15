using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2_P24_2210075
{
    public partial class Statistique : Form
    {
        public Statistique()
        {
            InitializeComponent();
        }


        private void Statistique_Load(object sender, EventArgs e)
        {
            int nbEleves = 0;
            double moyenneTP1 = 0;
            double moyenneTP2 = 0;
            double moyenneIntra = 0;
            double moyenneFinal = 0;
            double moyenneCours = 0;

            int countEleves = 0;
            foreach(Student student in Liste.lstEtudiants)
            {
                countEleves++;
                moyenneTP1 += student.tp1;
                moyenneTP2 += student.tp2;
                moyenneIntra += student.intra;
                moyenneFinal += student.final;
                moyenneCours += student.noteFinale;
            }

            nbEleves = countEleves;
            moyenneTP1 = moyenneTP2 / nbEleves;
            moyenneTP2 = moyenneTP2 / nbEleves;
            moyenneIntra = moyenneIntra / nbEleves;
            moyenneFinal = moyenneFinal / nbEleves;
            moyenneCours = moyenneCours / nbEleves;

            dgvStats.ColumnCount = 6;
            dgvStats.Columns[0].Name = "Nombre d'élèves";
            dgvStats.Columns[1].Name = "Moyenne TP1 (%)";
            dgvStats.Columns[2].Name = "Moyenne TP2 (%)";
            dgvStats.Columns[3].Name = "Moyenne Intra (%)";
            dgvStats.Columns[4].Name = "Moyenne Final (%)";
            dgvStats.Columns[5].Name = "Moyenne Note Finale (%)";

            dgvStats.RowCount = 6;
            dgvStats.Rows[0].Cells[0].Value = nbEleves;
            dgvStats.Rows[0].Cells[1].Value = moyenneTP1.ToString("N2");
            dgvStats.Rows[0].Cells[2].Value = moyenneTP2.ToString("N2");
            dgvStats.Rows[0].Cells[3].Value = moyenneIntra.ToString("N2");
            dgvStats.Rows[0].Cells[4].Value = moyenneFinal.ToString("N2");
            dgvStats.Rows[0].Cells[5].Value = moyenneCours.ToString("N2");


            dgvStats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
    }
}
