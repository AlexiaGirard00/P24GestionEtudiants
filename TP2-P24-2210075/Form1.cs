namespace TP2_P24_2210075
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void tsGestionEtudiants_Click(object sender, EventArgs e)
        {

            GestionEtudiants GestionForm = new GestionEtudiants();
            GestionForm.ControlBox = false;       
            GestionForm.MdiParent = this;
            GestionForm.Dock = DockStyle.Fill;
            GestionForm.Show();

        }

        private void tsListeEtudiants_Click(object sender, EventArgs e)
        {
            ListeEtudiants ListeForm = new ListeEtudiants();
            ListeForm.ControlBox = false;
            ListeForm.MdiParent = this;
            ListeForm.Dock = DockStyle.Fill;
            ListeForm.Show();

        }

        private void tsStatistiques_Click(object sender, EventArgs e)
        {
            Statistique statForm = new Statistique();
            statForm.ControlBox = false;
            statForm.MdiParent = this;
            statForm.Dock = DockStyle.Fill;
            statForm.Show();

        }

        private void tsRechercher_Click(object sender, EventArgs e)
        {

        }

        private void tsQuitter_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Êtes-vous sûr de vouloir quitter ?", "Attention", MessageBoxButtons.YesNo);
            
            if(dr == DialogResult.Yes)
            {
                Close();
            }
            
        }
    }
}