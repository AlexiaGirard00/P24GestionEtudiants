namespace TP2_P24_2210075
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();

            GestionEtudiants gestionEtudiants = new GestionEtudiants();

            if (!Directory.Exists("Eleve.Dta"))
            {
                Directory.CreateDirectory("Eleve.Dta");
            }
         
            foreach (string file in Directory.EnumerateFiles("Eleve.Dta", "*.Dta"))
            {
                 FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
                 BinaryReader br = new BinaryReader(fs);

                 string id = br.ReadString();
                 string nom = br.ReadString();
                 string prenom = br.ReadString();
                 string nodi = br.ReadString();
                 char sexe = br.ReadChar();
                 string dateNaissance = br.ReadString();
                 string adresse = br.ReadString();
                 string ville = br.ReadString();
                 string codePostal = br.ReadString();
                 string telephone = br.ReadString();
                 double intra = br.ReadDouble();
                 double final = br.ReadDouble();
                 double tp1 = br.ReadDouble();
                 double tp2 = br.ReadDouble();
                 double noteFinale = br.ReadDouble();

                 br.Close();
                 fs.Close();

                 Student student = new Student(id, nom, prenom, nodi, sexe, dateNaissance, adresse, ville, codePostal, telephone, intra, final, tp1, tp2, noteFinale);

                 Liste.lstEtudiants.Add(student);
            }

            if (!Directory.Exists("EleveSupprimer.Dta"))
            {
                Directory.CreateDirectory("EleveSupprimer.Dta");
                foreach (Student student in Liste.lstEtudiantsSupprimer)
                {
                    gestionEtudiants.EcrireEtudiantFichier(student);
                }
            }

            Application.Run(new Form1());

        }

    }
}