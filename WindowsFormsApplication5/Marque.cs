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
    public partial class Marque : Form
    {
        public Marque()
        {
            InitializeComponent();
        }

        private void Marque_Load(object sender, EventArgs e)
        {
            Declaration.connecter();
            Datagrid("Select * from Marque", 1);
          
            
            Declaration.cmd = new SqlCommand("Select N_M from Marque", Declaration.cn);
            SqlDataReader dr = Declaration.cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            Declaration.Fermer();
        }
        //Methode
        public void Datagrid(string str, int i)
        {
            // dataGridView1.Rows.Clear();
         
            try
            {
                SqlCommand cmd;
                
                cmd = new SqlCommand(str, Declaration.cn);
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
               
                if (i == 1)
                {
                    
                    dataGridView1.DataSource = dt;
                }
                else if (i == 2) dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


          
        }
        public bool Datagrid2(string str)
        {
           
      
            try
            {
               
                Declaration.cmd = new SqlCommand(str, Declaration.cn);
                Declaration.cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
              
                return false;
            }


         
        }
        public void Remplir_combo()
        {
            Declaration.cmd = new SqlCommand("Select * from Marque", Declaration.cn);
            SqlDataReader rd = Declaration.cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd);
            if (comboBox1.Items.Count != 0)
            {
                comboBox1.Items.Clear();

            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0].ToString());

            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Declaration.connecter();
            if(textBox1.Text == "")
            {
                MessageBox.Show("vous devez remplir la champs ", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            else
            {
              try
                {
                    SqlCommand cmd;
                    cmd = new SqlCommand("Insert into Marque values('" + textBox1.Text + " ')",Declaration.cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ajoute  bien effectuer");
                    Datagrid("Select * from Marque"  , 1);
                    Remplir_combo();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ajoute n'est pas effectuer","ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

                }               
            }
           
            Declaration.Fermer();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Declaration.connecter();
            if(textBox1.Text == "")
            {
               MessageBox.Show("vous devez Selectionner une ligne", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            else
            {
              
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                try
                {
                    SqlCommand cmd;
                    cmd = new SqlCommand("Update Marque set Nom_M = '" + textBox1.Text + "' where N_M = '" + dataGridView1.Rows[rowIndex].Cells[0].Value.ToString() + "'",Declaration.cn);
                    cmd.ExecuteNonQuery();
                    Datagrid("Select * from Marque", 1);
                    MessageBox.Show("Modification bien effectuer");
                    
                }
                catch (Exception ex)
                {
                   MessageBox.Show("Modification n'est pas effectuer","ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
                   
           }
               
           Declaration.Fermer();
              
            }
        private void button4_Click(object sender, EventArgs e)
        {
            Declaration.connecter();
            if(textBox1.Text == "")
            {
                MessageBox.Show("Le champs et vide vous devez selectionner un ligne", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

            }else
            {
                if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;

                    try
                    {
                        SqlCommand cmd;
                        cmd = new SqlCommand("Delete from  Marque  where N_M = '" + dataGridView1.Rows[rowIndex].Cells[0].Value.ToString() + "'", Declaration.cn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Suppression bien effectuer");
                        Datagrid("Select * from Marque", 1);
                        Datagrid("Select * from Modele where N_M = '" + dataGridView1.Rows[rowIndex].Cells[0].Value.ToString() + "'", 2);
                        Remplir_combo();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Suppression n'est pas effectuer", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

                    
                    }

                }
            }
            Declaration.Fermer();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Declaration.connecter();
            if (textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("vous devez remplir touts les champs", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            else
            {
                try
                {
                    SqlCommand cmd;
                    cmd = new SqlCommand("Insert into Modele values('" + textBox2.Text + "','" + comboBox1.Text + "')",Declaration.cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ajoute bien effectuer");
                    Datagrid("Select * from Modele where N_M = '" + comboBox1.Text + "'", 2);
                }
               catch(Exception ex)
                {
                    MessageBox.Show("Ajoute n'est pas effectuer", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

                  

                }

            }

            Declaration.Fermer();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Declaration.connecter();
            if (textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("vous devez remplir touts les champs", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            else
            {

                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                int rowIndex2 = dataGridView2.CurrentCell.RowIndex;
              //  int rowindex2 = dataGridView1.CurrentCell.RowIndex;
                try
                {
                    SqlCommand cmd;
                    cmd = new SqlCommand("Update Modele set Nom_Mod = '" + textBox2.Text + "',N_M = '" + comboBox1.Text + "'  where N_Mod = '" + dataGridView2.Rows[rowIndex2].Cells[0].Value.ToString() + "'",Declaration.cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Modification bien effectuer");
                   // MessageBox.Show("Select * from Modele where N_M = '" + int.Parse(dataGridView1.Rows[rowIndex].Cells[0].ToString()) + "'");
                    Datagrid("Select * from Modele where N_Mod = '" + dataGridView2.Rows[rowIndex2].Cells[0].Value.ToString() + "'", 2);
                 

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }

            }

            Declaration.Fermer();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Declaration.connecter();
            if(textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("vous devez faire selectioner une ligne", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

            }else
            {
                if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        int rowIndex = dataGridView2.CurrentCell.RowIndex;
                        int rowindex2 = dataGridView1.CurrentCell.RowIndex;
                        SqlCommand cmd;
                        cmd = new SqlCommand("Delete from  Modele  where N_Mod = '" + dataGridView2.Rows[rowIndex].Cells[0].Value.ToString() + "'", Declaration.cn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Suppression bien effectuer");
                        Datagrid("Select * from Modele where N_M = '" + dataGridView1.Rows[rowindex2].Cells[0].Value.ToString() + "'", 2);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("suppression n'est pas effectuer", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    }
                }
            }

          
            Declaration.Fermer();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Declaration.connecter();
            try
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                textBox1.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                Datagrid("Select * from Modele where N_M = " + dataGridView1.Rows[rowIndex].Cells[0].Value.ToString(), 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Declaration.Fermer();
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int rowIndex = dataGridView2.CurrentCell.RowIndex;
                textBox2.Text = dataGridView2.Rows[rowIndex].Cells[1].Value.ToString();
                comboBox1.Text = dataGridView2.Rows[rowIndex].Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }

     
    }
