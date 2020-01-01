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
    public partial class Mise_ajour_locataire : Form
    {
        public Mise_ajour_locataire()
        {
            InitializeComponent();
        }
        Contracteur c;

        private void button4_Click(object sender, EventArgs e)
        {
            Declaration.connecter();
            if (Cin.Text == "" || Prn.Text == "" || Nom.Text == "" || Nat.Text == "" || Nat.Text == "" || permi.Text == "")
            {
                MessageBox.Show("vous devez remplir touts les champs", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

            }
            else
            {

                try
                {
                    c = new Contracteur(Cin.Text, Nom.Text, Prn.Text, Nat.Text, Adr.Text, int.Parse(Pass.Text), int.Parse(permi.Text), int.Parse(Tel.Text), DateTime.Parse(date_permis.Value.ToString()));
                    string req = "Select * from Locataire where CIN = '" + Cin.Text + "'";
                    SqlCommand cmd;
                    cmd = new SqlCommand("Update Locataire set Prenom = '" + c.PRENOM + "',Nom = '" + c.NOM + "',Nat = '" + c.NAT + "',Adr = '" + c.ADR + "',Passp = '" + c.PASSP + "',Tel = '" + c.TEL + "',Permis =  '" + c.PERMIS + "',Date_permis =  '" + c.DATEPERMIS + "' where CIN  = '" + c.CIN + "'", Declaration.cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Modification bien effectuer");
                    Remplir_grid(req);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur dans la modification");
                }





            }
            Declaration.Fermer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Declaration.connecter();
            if (Cin.Text == "")
            {
                MessageBox.Show("vous devez selectionner une ligne", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            else
            {
                try
                {
                    if(MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        string req = "Select * from Locataire where CIN = '" + Cin.Text + "'";
                        SqlCommand cmd;
                        cmd = new SqlCommand("delete from Locataire where CIN = '" + Cin.Text + "'", Declaration.cn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Suppression bien effectuer");
                        Remplir_grid(req);
                        Remplir_combo();
                        effacer();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            Declaration.Fermer();
        }
        private void Remplir_grid(string req)
        {

            try
            {
                Declaration.cmd = new SqlCommand(req, Declaration.cn);
                SqlDataReader dr = Declaration.cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void Remplir_combo()
        {
            Declaration.cmd = new SqlCommand("Select * from Locataire", Declaration.cn);
            SqlDataReader rd = Declaration.cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd);
            if (Cin.Items.Count != 0)
            {
                Cin.Items.Clear();

            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Cin.Items.Add(dt.Rows[i][0].ToString());

            }

        }
        public void effacer()
        {
            Cin.Text = "";
            Prn.Clear();
            Nom.Clear();
            Adr.Clear();
            Nat.Clear();
            date_permis.Value = DateTime.Now;
            Pass.Clear();
            Nom.Clear();
            permi.Clear();
            Tel.Clear();

        }

        private void Mise_ajour_locataire_Load(object sender, EventArgs e)
        {
            Declaration.connecter();
            Remplir_combo();
            Declaration.Fermer();
        }

        private void Cin_SelectedIndexChanged(object sender, EventArgs e)
        {
            Declaration.connecter();
            try
            {
                Declaration.cmd = new SqlCommand("Select * from Locataire where CIN = '" + Cin.Text + "'", Declaration.cn);
                SqlDataReader dr = Declaration.cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                Cin.Text = dt.Rows[0][0].ToString();
                Prn.Text = dt.Rows[0][1].ToString();
                Nat.Text = dt.Rows[0][3].ToString();
               Nom.Text  = dt.Rows[0][2].ToString();
                Adr.Text = dt.Rows[0][4].ToString();
                Pass.Text = dt.Rows[0][5].ToString();
                permi.Text = dt.Rows[0][6].ToString();
                Tel.Text = dt.Rows[0][7].ToString();
                date_permis.Text = dt.Rows[0][8].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Declaration.Fermer();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            effacer();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
