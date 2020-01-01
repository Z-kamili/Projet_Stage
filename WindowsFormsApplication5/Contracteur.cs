using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication5
{
    class Contracteur
    {
        private string Cin;
        private string Prenom;
        private string Nom;
        private string Nat;
        private string Adr;
        private int Passp;
        private int Permis;
        private int Tel;
        private DateTime Date_permis;
        private DateTime dateinscription;
       

        public string CIN
        {
            get
            {
                return Cin;
            }
            set
            {
                Cin = value;
            }
        }
        public string PRENOM
        {
            get
            {
                return Prenom;
            }
            set
            {
                Prenom = value;
            }
        }
        public string NOM
        {
            get
            {
                return Nom;
            }
            set
            {
                Nom = value;
            }
        }
        public string NAT
        {
            get
            {
                return Nat;
            }
            set
            {
                Nat = value;
            }
        }
        public string ADR
        {
            get
            {
                return Adr;
            }
            set
            {
                Adr = value;
            }
        }
        public int PASSP
        {
            get
            {
                return Passp;
            }
            set
            {
                Passp = value;
            }
        }
        public int PERMIS
        {
            get
            {
                return Permis;
            }
            set
            {
                Permis = value;
            }
        }
        public int TEL
        {
            get
            {
                return Tel;
            }
            set
            {
                Tel = value;
            }
        }
        public DateTime DATEPERMIS
        {
            get
            {
                return  Date_permis;
            }
            set
            {
                Date_permis = value;
            }
        }
        public DateTime DATEINSCRIPTION
        {
            get
            {
                return dateinscription;
            }
            set
            {
                dateinscription = value;
            }
        }
        public Contracteur(string cin,string nom,string prenom,string nat,string adr,int passp,int permis,int tel,DateTime datepermis)
        {
            this.CIN = cin;
            this.NOM = nom;
            this.PRENOM = prenom;
            this.NAT = nat;
            this.ADR = adr;
            this.PASSP = passp;
            this.PERMIS = permis;
            this.TEL = tel;
            this.DATEPERMIS = datepermis;
            this.dateinscription =DateTime.Now;
        }

    }
}
