using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TP2_P24_2210075
{

    public class Student
    {
        private string CodePermanent;
        public string codePermanent
        {
            get { return CodePermanent; }
            set { CodePermanent = value; }
        }
        private string Nom;
        public string nom
        {
            get { return Nom.TrimEnd(); }
            set { Nom = value.PadRight(15); }
        }
        private string Prenom;
        public string prenom
        {
            get { return Prenom.TrimEnd(); }
            set { Prenom = value.PadRight(15); }
        }
        private string NoId;
        public string noId
        {
            get { return NoId; }
            set{ NoId = value;}
        }
        private char Sexe;
        public char sexe
        {
            get { return Sexe; }
            set { Sexe = value; }
        }

        private string DateNaissance;
        public string dateNaissance
        {
            get { return DateNaissance.TrimEnd(); }
            set{ DateNaissance = value.PadRight(10); }
        }
        private string Adresse;
        public string adresse
        {
            get { return Adresse.TrimEnd(); }
            set { Adresse = value.PadRight(30); }
        }
        private string Ville;
        public string ville
        {
            get { return Ville.TrimEnd(); }
            set { Ville = value.PadRight(20); }
        }
        private string CodePostal;
        public string codePostal
        {
            get { return CodePostal; }
            set { CodePostal = value; }
        }
        private string Telephone;
        public string telephone
        {
            get { return Telephone; }
            set { Telephone = value; }
        }
        private double Intra;
        public double intra
        {
            get { return Intra; }
            set { Intra = value; }
        }
        private double Final;
        public double final
        {
            get { return Final; }
            set { Final = value; }
        }
        private double TP1;
        public double tp1
        {
            get { return TP1; }
            set { TP1 = value; }
        }
        private double TP2;
        public double tp2
        {
            get { return TP2; }
            set { TP2 = value; }
        }
        private double NoteFinale;
        public double noteFinale
        {
            get { return NoteFinale; }
            set { NoteFinale = value; }
        }


        public Student(string codePermanent, string nom, string prenomm, string noId, char sexe,
            string dateNaissance, string adresse, string ville, string codePostal, string telephone,
            double intra, double final, double tp1, double tp2, double noteFinale)
        {
            CodePermanent = codePermanent;
            Nom = nom;
            Prenom = prenomm;
            NoId = noId;
            Sexe = sexe;
            DateNaissance = dateNaissance;
            Adresse = adresse;
            Ville = ville;
            CodePostal = codePostal;
            Telephone = telephone;
            Intra = intra;
            Final = final;
            TP1 = tp1;
            TP2 = tp2;
            NoteFinale = noteFinale;

        }

        public override string ToString()
        {
            return CodePermanent + Environment.NewLine + Nom + Environment.NewLine + Prenom + Environment.NewLine +
                NoId + Environment.NewLine + Sexe + Environment.NewLine + DateNaissance + Environment.NewLine +
                Adresse + Environment.NewLine + Ville + Environment.NewLine + CodePostal + Environment.NewLine +
                Telephone + Environment.NewLine + Intra + Environment.NewLine + Final + Environment.NewLine +
                TP1 + Environment.NewLine + TP2 + Environment.NewLine + NoteFinale;
        }

        public IEnumerator<PropertyInfo> GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}
