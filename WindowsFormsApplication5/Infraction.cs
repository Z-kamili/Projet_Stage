using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApplication5
{
    public partial class Infraction : Form
    {
        public Infraction()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Declaration.connecter();
            if (Mt.Text == "" || dateTimePicker1.Value == DateTime.Now)
            {
                MessageBox.Show("la zone et vide vous devez choisir le matricule et la date");
            }
            else
            {
                try
            {

                Declaration.cmd = new SqlCommand("select  Locataire.CIN,Nom,Prenom,Tel,Date_Contrat,Contrat.Matricule from Contrat,Locataire,Voiture where Locataire.CIN = Contrat.CIN And Voiture.Matricule = Contrat.Matricule And  '" + dateTimePicker1.Value.Date + "' Between Date_Depart And Date_retour And Contrat.Matricule = '" + Mt.Text + "'", Declaration.cn);
                //  MessageBox.Show("select * from Contrat where Matricule = '" + comboBox1.Text + "'And " + dateTimePicker1.Value.Date + " Between  Date_Depart And Date_retour");
                SqlDataReader dr = Declaration.cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count == 0)
                {
                    dataGridView1.DataSource = dt;
                    MessageBox.Show("Aucun enregistrement se trouve");
                }
                else
                {
                    dataGridView1.DataSource = dt;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Declaration.Fermer();
        }

        private void Infraction_Load(object sender, EventArgs e)
        {
            Declaration.connecter();
            remplirMatricule();
            Declaration.Fermer();

    }
        public void remplirMatricule()
        {
            Declaration.cmd = new SqlCommand("Select * from Voiture", Declaration.cn);
            SqlDataReader rd = Declaration.cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd);
            if (Mt.Items.Count != 0)
            {
                Mt.Items.Clear();

            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Mt.Items.Add(dt.Rows[i][0].ToString());


            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
