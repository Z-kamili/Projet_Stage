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
    public partial class F2 : Form
    {
        public F2()
        {
            InitializeComponent();
        }

        private void F2_Load(object sender, EventArgs e)
        {
            Declaration.connecter();
            try
            {
                Remplir_grid();
                Remplir_combo();
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
        //Methode
        public void Remplir_combo()
        {
            Declaration.cmd = new SqlCommand("Select * from Voiture", Declaration.cn);
            SqlDataReader rd = Declaration.cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd);
            if (Mtrc.Items.Count != 0)
            {
                Mtrc.Items.Clear();

            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Mtrc.Items.Add(dt.Rows[i][0].ToString());

            }

        }
        private void Remplir_grid()
        {

            try
            {
                Declaration.cmd = new SqlCommand("select Matricule,Nom_M,Nom_Mod,Annee,Etats from Voiture,Marque,Modele where Voiture.Num_M = Marque.N_M And Voiture.N_M = Modele.N_Mod ", Declaration.cn);
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
                    str = "Insert into Voiture (Matricule,Annee,Num_M,Etats,N_M) values ( '" + Mtrc.Text + "','" + Annee.Text + "','" + j + "','" + "Luoer" + "','" + j2 + "')";
                }
                else if (radioButton2.Checked)
                {
                    str = "Insert into Voiture (Matricule,Annee,Num_M,Etats,N_M) values ( '" + Mtrc.Text + "','" + Annee.Text + "','" + j + "','" + "nom Luoer" + "','" + j2 + "')";
                }

                SqlCommand cmd4;
                cmd4 = new SqlCommand(str, Declaration.cn);

                try
                {
                    cmd4.ExecuteNonQuery();
                    MessageBox.Show("Ajoute bien effectuer");
                    Remplir_grid();
                    Remplir_combo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur l'ajoute n'est pas effectuer", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);


                }

            }
            Declaration.Fermer();
        }

        private void button4_Click(object sender, EventArgs e)
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
                    str = "Update Voiture set Matricule = '" + Mtrc.Text + "', Annee = '" + Annee.Text + "', Num_M = '" + j + "', N_M = '" + j2 + "', Etats = '" + "Luoer" + "' where Matricule = '" + Mtrc.Text + "'";
                }
                else if (radioButton2.Checked)
                {
                    str = "Update Voiture set Matricule = '" + Mtrc.Text + "', Annee = '" + Annee.Text + "', Num_M = '" + j + "', N_M = '" + j2 + "', Etats = '" + "nom Luoer" + "' where Matricule = '" + Mtrc.Text + "'";
                }
                SqlCommand cmd4;
                cmd4 = new SqlCommand(str, Declaration.cn);

                try
                {
                    cmd4.ExecuteNonQuery();
                    MessageBox.Show("Modification bien effectuer");
                    Remplir_grid();
                    Remplir_combo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur dans la Modification la forme d'une champs et incorect", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);


                }

            }
            Declaration.Fermer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Declaration.connecter();
            if (Mtrc.Text == "")
            {
                MessageBox.Show("Choisir le Matricule", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            else
            {
                try
                {
                    if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        SqlCommand cmd;
                        cmd = new SqlCommand("delete from Voiture where Matricule = '" + Mtrc.Text + "'", Declaration.cn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Suppression bien effectuer");
                        Remplir_combo();
                        Remplir_grid();
                        effacer();

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Suppression n'est pas effectuer", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
            }
            Declaration.Fermer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            effacer();
            Declaration.connecter();
            Remplir_grid();
            Declaration.Fermer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    DataSet ds = new DataSet();
            //    DataTable dt = new DataTable();
            //    dt.Columns.Add("Matricule", typeof(string));
            //    dt.Columns.Add("Nom Marque", typeof(string));
            //    dt.Columns.Add("Nom Modele", typeof(string));
            //    dt.Columns.Add("Annee", typeof(string));
            //    foreach (DataGridViewRow dgv in dataGridView1.Rows)
            //    {
            //        dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2]);
            //    }
            //    ds.Tables.Add(dt);

            //    Imprimer_voiture im = new Imprimer_voiture(ds);

            //    im.Show();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
          
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
       
            Bitmap objmap = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(objmap, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(objmap, 250, 90);
            e.Graphics.DrawString("Liste DU Voiture", new Font("Century Gothic", 30, FontStyle.Bold), Brushes.Black, new Point(320, 30));
      
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Mtrc_SelectedIndexChanged(object sender, EventArgs e)
        {
              Declaration.connecter();
            Declaration.cmd = new SqlCommand("select Matricule,Nom_M,Nom_Mod,Annee,Etats from Voiture,Marque,Modele where Voiture.Num_M = Marque.N_M And Voiture.N_M = Modele.N_Mod And Matricule =  '" + Mtrc.Text + "'", Declaration.cn);
            SqlDataReader dr = Declaration.cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            Declaration.Fermer();
            Mtrc.Text = dt.Rows[0][0].ToString();
            Marque2.Text = dt.Rows[0][1].ToString();
            Modele.Text = dt.Rows[0][2].ToString();
            Annee.Text = dt.Rows[0][3].ToString();
            string s = dt.Rows[0][4].ToString();
            dataGridView1.DataSource = dt;
            if(s == "Luoer")
            {
                radioButton1.Checked = true;
            }
            else if( s == "nom Luoer")
            {
                radioButton2.Checked = true;
            }
         
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
    }
}
