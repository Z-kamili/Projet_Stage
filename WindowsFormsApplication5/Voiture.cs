using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication5
{
    class Voiture
    {
        private string Matricule;
        private string date;
        private int N_Marque;
        private int N_Modele;
        private string etas;

        public string MATRICULE
        {
            get
            {
                return Matricule;
            }
            set
            {
                Matricule = value;
            }
        }
        public string DATE
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }
        public int  NMarque
        {
            get
            {
                return N_Marque;
            }
            set
            {
                N_Marque = value;
            }
        }
        public int NModele
        {
            get
            {
                return N_Modele;
            }
            set
            {
                N_Modele = value;
            }
        }
        public string ETAT
        {
            get
            {
                return etas;
            }
            set
            {
                etas = value;
            }
        }
        public Voiture(string Mtrc,string date,int Nm,int Nmod,string Etas)
        {
            this.MATRICULE = Mtrc;
            this.DATE = date;
            this.NMarque = Nm;
            this.NModele = Nmod;
            this.ETAT = Etas;
        }
    }
}
