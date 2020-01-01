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
    public partial class Ajoute_voiture : Form
    {
        Voiture v;
        public Ajoute_voiture()
        {
            InitializeComponent();
        }

        private void Ajoute_voiture_Load(object sender, EventArgs e)
        {
            Declaration.connecter();
            try
            {
               
                
                Modele.Enabled = false;
                SqlCommand cmd = new SqlCommand("Select Nom_M from Marque", Declaration.cn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Marque2.Items.Add(dt.Rows[i][0].ToString());
                }
                effacer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Declaration.Fermer();
        }
       
       
        public void effacer()
        {
            Mtrc.Text = "";
            Annee.Clear();
            Marque2.Text = "";
            Modele.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            Modele.Enabled = false;

        }

        private void Marque2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Declaration.connecter();
            Modele.Items.Clear();
            Modele.Enabled = true;
            Declaration.cmd = new SqlCommand("Select Nom_Mod from Modele where N_M IN (select N_M from Marque where Nom_M = '" + Marque2.Text + "')", Declaration.cn);
            SqlDataReader dr2 = Declaration.cmd.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                Modele.Items.Add(dt2.Rows[i][0].ToString());
            }
            Declaration.Fermer();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Declaration.connecter();
            if (Mtrc.Text == "" || Marque2.Text == "" || Modele.Text == "" || Annee.Text == "" || (radioButton1.Checked == false && radioButton2.Checked == false))
            {
                MessageBox.Show("vous devez remplir touts les champs", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            else
            {


                SqlCommand cmd2 = new SqlCommand("Select N_M from Marque where Nom_M = '" + Marque2.Text + "'", Declaration.cn);
                SqlDataReader dr = cmd2.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                int j = int.Parse(dt.Rows[0][0].ToString());
                SqlCommand cmd3 = new SqlCommand("Select N_Mod from Modele where Nom_Mod = '" + Modele.Text + "'", Declaration.cn);
                SqlDataReader dr2 = cmd3.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                int j2 = int.Parse(dt2.Rows[0][0].ToString());
                string str = "";
                if (radioButton1.Checked)
                {
                    v = new Voiture(Mtrc.Text, Annee.Text, j, j2, "Luoer");
                    str = "Insert into Voiture (Matricule,Annee,Num_M,Etats,N_M) values ( '" + v.MATRICULE + "','" + v.DATE + "','" + v.NMarque + "','" + v.ETAT + "','" + v.NModele + "')";
                }
                else if (radioButton2.Checked)
                {
                    v = new Voiture(Mtrc.Text, Annee.Text, j, j2, "nom Luoer");
                    str = "Insert into Voiture (Matricule,Annee,Num_M,Etats,N_M) values ( '" + v.MATRICULE + "','" + v.DATE + "','" + v.NMarque + "','" + v.ETAT + "','" + v.NModele + "')";
                }

                SqlCommand cmd4;
                cmd4 = new SqlCommand(str, Declaration.cn);

                try
                {
                    cmd4.ExecuteNonQuery();
                    MessageBox.Show("Ajoute bien effectuer");
                   
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur l'ajoute n'est pas effectuer", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);


                }

            }
            Declaration.Fermer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            effacer();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
