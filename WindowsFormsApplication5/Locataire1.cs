using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApplication5
{
    public partial class Locataire1 : Form
    {
        Contracteur c;
        public Locataire1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Declaration.connecter();
            

            if (Cin.Text == "" || Prn.Text == "" || Name.Text == "" || Nat.Text == "" || Adr.Text == "" || permi.Text == "" || Tel.Text == "" )
            {
                MessageBox.Show("vous devez remplir touts les champs", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            else
            {
                try
                {
                    if (Pass.Text == "") Pass.Text = "0";
                    c = new Contracteur(Cin.Text, Name.Text, Prn.Text, Nat.Text, Adr.Text,int.Parse(Pass.Text),int.Parse(permi.Text),int.Parse(Tel.Text), DateTime.Parse(date_permis.Value.ToString()));
                    string req = "Select * from Locataire where CIN = '" + Cin.Text + "'";
                    SqlCommand cmd;
                    cmd = new SqlCommand("Insert into Locataire (CIN,Prenom,Nom,Nat,Adr,Passp,Permis,Date_permis,Tel) values ( '" + c.CIN + "','" + c.PRENOM + "','" + c.NOM + "','" + c.NAT + "','" + c.ADR + "','" + c.PASSP + "','" + c.PERMIS + "','" + c.DATEPERMIS + "','" + c.TEL  + "' )", Declaration.cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ajoute bien effectuer");


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Deja existe ou bien La forme d'une champs n'est pas valide", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

                }

            }
            Declaration.Fermer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            effacer();
          
        }

        private void Locataire1_Load(object sender, EventArgs e)
        {

        }
        public void effacer()
        {
            Cin.Text = "";
            Prn.Clear();
            Name.Clear();
            Nat.Clear();
            Adr.Clear();
            date_permis.Value = DateTime.Now;
            Pass.Clear();
            Tel.Clear();
            permi.Clear();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
