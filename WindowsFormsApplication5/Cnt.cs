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
    public partial class Cnt : Form
    {
        public Cnt()
        {
            InitializeComponent();
        }
        int[] choix = new int[13];

        private void button4_Click(object sender, EventArgs e)
        {
            Declaration.connecter();
            if (CIN.Text == "" || CIN_conducteur.Text == "" || Mtrc.Text == "" || HD.Text == ""  || FR.Text == "" || Prix.Text == "" || Duree.Text == "")
            {
                MessageBox.Show("vous devez remplir touts les champs obligatoire", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            else
            {
                try
                {
                    int a, entree;
                    float av, au;
                    if (Depart.Text == "") a = 0;
                    else a = int.Parse(Depart.Text);
                    if (Av.Text == "") av = 0;
                    else av = float.Parse(Av.Text);
                    if (As.Text == "") au = 0;
                    else au = float.Parse(As.Text);
                    if (Entree.Text == "") entree = 0;
                    else entree = int.Parse(Entree.Text);
                    float net_location = float.Parse(Prix.Text) * int.Parse(Duree.Text);
                    float Prix_totale = net_location + au;
                    float prixrest = Prix_totale - av;
                    Net.Text = (net_location).ToString();
                    Tt.Text = (Prix_totale).ToString();
                    if (prixrest < 0) prixrest = 0;
                    Re.Text = (prixrest).ToString();
                    dateTimePicker2.Value = dateTimePicker1.Value.AddDays(double.Parse(Duree.Text));
                    HR.Text = HD.Text;
                    SqlCommand cmd2;
                    cmd2 = new SqlCommand("Insert into Contrat(CIN,CIN_Conducteur,Date_Contrat,Matricule, Date_Depart,Date_retour,Heur_Depart,Heur_retour, Prix, Duree,A_S,F_Assurance,Avances,Depart,Entree,prix_total,prix_rest,Net_location,Roue_secour,chric,Equip_securiter,Eclairage,Carts_gris,Assurance,Aurisation,Vignette,Visite_technique,F,F2,F3,E) values('" + CIN.Text + "','" + CIN_conducteur.Text + "','" + DateTime.Now + "','" + Mtrc.Text + "','" + dateTimePicker1.Value + "','" + dateTimePicker2.Value + "','" + TimeSpan.Parse(HR.Text) + "','" + TimeSpan.Parse(HR.Text) + "','" + Prix.Text + "', '" + Duree.Text + "','" + au + "','" + FR.Text + "','" + av + "','" + a + "','" + entree + "','" + Tt.Text + "','" + Re.Text + "','" + Net.Text + "','" + choix[0] + "','" + choix[1] + "','" + choix[2] + "','" + choix[3] + "','" + choix[4] + "','" + choix[5] + "','" + choix[6] + "','" + choix[7] + "','" + choix[8] + "','" + choix[9] + "','" + choix[10] + "','" + choix[11] + "','" + choix[12] + " ')", Declaration.cn);
                    cmd2.ExecuteNonQuery();
                    Contrat_remplir();
                   imprimer_contrat(int.Parse(Serie.Text));
                    MessageBox.Show("Ajoute bien effectuer vous pouvez faire imprimer");
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                  
                    //  Serie.Enabled = true;
                    //Remplir_combo();

                
               
                 
                




            }
            Declaration.Fermer();
        }
          public void imprimer_contrat(int N_serie)
        {
            Declaration.connecter();
            try
            {
                SqlCommand cmd = new SqlCommand("select * from Contrat where N_Serie = '" + N_serie + "'", Declaration.cn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                CINN.Text = dt.Rows[0][2].ToString();
                Matricule.Text = dt.Rows[0][3].ToString();
                CIN2.Text = dt.Rows[0][13].ToString();
                Departs.Text = dt.Rows[0][4].ToString();
                Retours.Text = dt.Rows[0][5].ToString();
                HDD.Text = dt.Rows[0][6].ToString();
                HRR.Text = dt.Rows[0][7].ToString();
                D.Text = dt.Rows[0][16].ToString();
                E.Text = dt.Rows[0][15].ToString();
                Prix_unite.Text = dt.Rows[0][8].ToString();
                quantite.Text = dt.Rows[0][9].ToString();
                Net_location.Text = dt.Rows[0][14].ToString();
                Autre_service.Text = dt.Rows[0][10].ToString();
                Total_payer.Text = dt.Rows[0][18].ToString();
                Reste_payer.Text = dt.Rows[0][17].ToString();
                Franchisse_Assurance.Text = dt.Rows[0][11].ToString();
                Avance.Text = dt.Rows[0][12].ToString();
                label21.Text = DateTime.Now.Date.ToString();
                label18.Text = Serie.Text;
                if (dt.Rows[0][23].ToString() == "True")
                {

                 Roue_secour.Checked = true;
                    //  choix[0] = 1;
                }
                else
                {
                    Roue_secour.Checked = false;
                }
                if (dt.Rows[0][24].ToString() == "True")
                {
                   chric_cle.Checked = true;
                    //  choix[1] = 1;
                }
                else
                {
                    chric_cle.Checked = false;

                }
                if (dt.Rows[0][25].ToString() == "True")
                {
                    Equipement_securite.Checked = true;
                    //  choix[2] = 1;
                }
                else
                {
                    Equipement_securite.Checked = false;
                }
                if (dt.Rows[0][26].ToString() == "True")
                {

                    Eclairage.Checked = true;
                    //  choix[3] = 1;
                }
                else
                {
                    Eclairage.Checked = false;
                }
                if (dt.Rows[0][27].ToString() == "True")
                {
                    Carts_gris.Checked = true;
                    //  choix[4] = 1;
                }
                else
                {
                    Carts_gris.Checked = false;
                }
                if (dt.Rows[0][28].ToString() == "True")
                {
                   Assurance.Checked = true;
                    //   choix[5] = 1;
                }
                else
                {
                    Assurance.Checked = false;
                }
                if (dt.Rows[0][29].ToString() == "True")
                { 
                   Autorisation.Checked = true;
                    //  choix[6] = 1;
                }
                else
                {
                    Autorisation.Checked = false;
                }
                if (dt.Rows[0][30].ToString() == "True")
                {
                   Vignette.Checked = true;
                    // choix[7] = 1;
                }
                else
                {
                    Vignette.Checked = false;
                }
                if (dt.Rows[0][31].ToString() == "True")
                {
                    Visite_technique.Checked = true;
                    // choix[8] = 1;
                }
                else
                {
                    Visite_technique.Checked = false;
                }
                if (dt.Rows[0][19].ToString() == "True")
                {
                    FF1.Checked = true;
                    //  choix[9] = 1;
                }
                else
                {
                    FF1.Checked = false;
                }
                if (dt.Rows[0][20].ToString() == "True")
                {
                    FF2.Checked = true;
                    // choix[10] = 1;
                }
                else
                {
                    FF2.Checked = false;
                }
                if (dt.Rows[0][21].ToString() == "True")
                {
                    FF3.Checked = true;
                    // choix[11] = 1;
                }
                else
                {
                    FF3.Checked = false;
                }

                if (dt.Rows[0][22].ToString() == "True")
                {
                    FF4.Checked = true;
                    // choix[12] = 1;
                }
                else
                {
                    FF4.Checked = false;
                }

                remplir_cin(dt.Rows[0][2].ToString(), dt.Rows[0][13].ToString());
                remplirMarque(dt.Rows[0][3].ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Declaration.Fermer();
        }
        public void remplir_cin(string s1, string s2)
        {
            Declaration.connecter();
            try
            {

                SqlCommand cmd = new SqlCommand("select * from Locataire where CIN = '" + s1 + "'", Declaration.cn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                Prenom.Text = dt.Rows[0][1].ToString();
                Name.Text = dt.Rows[0][2].ToString();
                Nationaliter.Text = dt.Rows[0][3].ToString();
                Adr.Text = dt.Rows[0][4].ToString();
                Pass.Text = dt.Rows[0][5].ToString();
                Permis.Text = dt.Rows[0][6].ToString();
                Tel.Text = dt.Rows[0][7].ToString();
                SqlCommand cmd2 = new SqlCommand("select * from Conducteur where CIN_conducteur = '" + s2 + "'", Declaration.cn);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                Prenom2.Text = dt2.Rows[0][1].ToString();
                Name2.Text = dt2.Rows[0][2].ToString();
                Nationaliter2.Text = dt2.Rows[0][3].ToString();
                ADR2.Text = dt2.Rows[0][4].ToString();
                Pass2.Text = dt2.Rows[0][5].ToString();
                Permis2.Text = dt2.Rows[0][6].ToString();
                Tel2.Text = dt2.Rows[0][7].ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Declaration.Fermer();
        }
        public void remplirMarque(string s)
        {
            Declaration.connecter();
            try
            {

                SqlCommand cmd = new SqlCommand("select Num_M from Voiture where Matricule = '" + s + "'", Declaration.cn);
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                int n = int.Parse(dt.Rows[0][0].ToString());
                SqlCommand cmd2 = new SqlCommand("select Nom_M from Marque where N_M = '" + n + "'", Declaration.cn);
                SqlDataReader rd2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(rd2);
                vehicule1.Text = dt2.Rows[0][0].ToString();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Declaration.Fermer();
        }
        public void Contrat_remplir()
        {

            SqlCommand cmd = new SqlCommand("Select Max(N_Serie) from Contrat", Declaration.cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            Serie.Text = dt.Rows[0][0].ToString();


        }
        private void button3_Click(object sender, EventArgs e)
        {
            Declaration.connecter();
            if (Serie.Text == "")
            {
                MessageBox.Show("Le champs de num serie et vide ?", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

            }
            else
            {
                try
                {
                    int a;
                    float av, au;
                    if (Depart.Text == "") a = 0;
                    else a = int.Parse(Depart.Text);
                    if (Av.Text == "") av = 0;
                    else av = float.Parse(Av.Text);
                    if (As.Text == "") au = 0;
                    else au = float.Parse(As.Text);
                    float net_location = float.Parse(Prix.Text) * int.Parse(Duree.Text);
                    float Prix_totale = net_location + au;
                    float prixrest = Prix_totale - av;
                    if (prixrest < 0) prixrest = 0;
                    Net.Text = (net_location).ToString();
                    Tt.Text = (Prix_totale).ToString();
                    Re.Text = (prixrest).ToString();
                    HR.Text = HD.Text;
                    dateTimePicker2.Value = dateTimePicker1.Value.AddDays(double.Parse(Duree.Text));
                    Declaration.cmd = new SqlCommand("Update Contrat  set CIN = '" + CIN.Text + "', CIN_Conducteur = '" + CIN_conducteur.Text + "', Matricule = '" + Mtrc.Text + "', Date_Depart = '" + dateTimePicker1.Value + "', Date_retour = '" + dateTimePicker2.Value + "',Heur_Depart = '" + TimeSpan.Parse(HD.Text) + "',Heur_retour = '" + TimeSpan.Parse(HR.Text) + "',Prix = '" + Prix.Text + "',Duree = '" + Duree.Text + "',A_S = '" + au + "',F_Assurance = '" + FR.Text + "',Avances ='" + av + "',Net_location ='" + Net.Text + "',prix_rest = '" + Re.Text + "',Depart = '" + a + "',Prix_total = '" + Tt.Text + "',Roue_secour = '" + choix[0] + "',chric = '" + choix[1] + "',Equip_securiter = '" + choix[2] + "',Eclairage = '" + choix[3] + "',Carts_gris = '" + choix[4] + "',Assurance  = '" + choix[5] + "',Vignette = '" + choix[6] + "',Visite_technique = '" + choix[7] + "',F = '" + choix[8] + "',F2 = '" + choix[9] + "',F3 = '" + choix[10] + "',E = '" + choix[11] + "',Entree =  '" + Entree.Text + "' where N_Serie = '" + Serie.Text + "'", Declaration.cn);
                    Declaration.cmd.ExecuteNonQuery();
                    MessageBox.Show("Modification bien effectuer");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            Declaration.Fermer();
        }
        public void Valider()
        {
            for (int i = 0; i < 13; i++)
            {
                choix[i] = 0;
            }
        }
        private void Contrat_Nouveau_Load(object sender, EventArgs e)
        {
            Declaration.connecter();
            try
            {
                pnl1.Visible = false;
                Valider();
             
                //Remplir_combo();
                remplircin();
                remplirMatricule();
                SqlCommand cmd3 = new SqlCommand("Select  count(N_Serie) from Contrat", Declaration.cn);
                SqlDataReader dr3 = cmd3.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr3);
                Tt.Enabled = false;
                //  Serie.Enabled = false;
                Net.Enabled = false;
                Re.Enabled = false;
                //  Entree.Enabled = false;
                HR.Enabled = false;
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "dd-MM-yyyy";
                dateTimePicker2.Format = DateTimePickerFormat.Custom;
                dateTimePicker2.CustomFormat = "dd-MM-yyyy";
                // Serie.DropDownStyle = ComboBoxStyle.DropDownList;
                Serie.Enabled = false;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            Declaration.Fermer();
        }
        public void remplircin()
        {
            Declaration.cmd = new SqlCommand("Select * from Locataire", Declaration.cn);
            SqlDataReader rd = Declaration.cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd);
            if (CIN.Items.Count != 0)
            {
                CIN.Items.Clear();
                CIN_conducteur.Items.Clear();
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CIN.Items.Add(dt.Rows[i][0].ToString());
                CIN_conducteur.Items.Add(dt.Rows[i][0].ToString());

            }

        }
        public void remplirMatricule()
        {
            Declaration.cmd = new SqlCommand("Select * from Voiture where Etats = 'nom Luoer' ", Declaration.cn);
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
        public void vider()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox) c.Text = String.Empty;
                else if (c is ComboBox) c.Text = String.Empty;
                RS.Checked = false;
                Ch.Checked = false;
                Es.Checked = false;
                Ec.Checked = false;
                Cg.Checked = false;
                Ass.Checked = false;
                Au.Checked = false;
                Vig.Checked = false;
                Visite.Checked = false;
                F1.Checked = false;
                F2.Checked = false;
                F3.Checked = false;
                F4.Checked = false;
                Serie.Enabled = false;
                //    Serie.DropDownStyle = ComboBoxStyle.DropDownList;
              //  Serie.Enabled = false;

            }


        }
        private void button7_Click(object sender, EventArgs e)
        {
            Declaration.connecter();

            try
            {
                if (Serie.Text == "")
                {
                    MessageBox.Show("Le champs de num serie et vide ?", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
                else
                {
                    Declaration.cmd = new SqlCommand("Select * from Contrat where N_Serie = '" + Serie.Text + "'", Declaration.cn);
                    SqlDataReader rd = Declaration.cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Le numero de seire n'existe pas vous devez faire ajouter avant de le faire supprimer", "ATTENTION !!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

                    }
                    else
                    {
                        if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            Declaration.cmd = new SqlCommand("Delete from Contrat where N_Serie = '" + Serie.Text + "'", Declaration.cn);
                            Declaration.cmd.ExecuteNonQuery();
                            MessageBox.Show("Suppression bien effectuer");
                            //Remplir_combo();
                            vider();

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Declaration.Fermer();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            vider();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RS_CheckedChanged(object sender, EventArgs e)
        {
            choix[0] = 1;
        }

        private void Ch_CheckedChanged(object sender, EventArgs e)
        {
            choix[1] = 1;
        }

        private void Es_CheckedChanged(object sender, EventArgs e)
        {
            choix[2] = 1;
        }

        private void Ec_CheckedChanged(object sender, EventArgs e)
        {
            choix[3] = 1;
        }

        private void Cg_CheckedChanged(object sender, EventArgs e)
        {
            choix[4] = 1;
        }

        private void Ass_CheckedChanged(object sender, EventArgs e)
        {
            choix[5] = 1;
        }

        private void Au_CheckedChanged(object sender, EventArgs e)
        {
            choix[6] = 1;
        }

        private void Vig_CheckedChanged(object sender, EventArgs e)
        {
            choix[7] = 1;
        }

        private void Visite_CheckedChanged(object sender, EventArgs e)
        {
            choix[8] = 1;
        }

        private void F1_CheckedChanged(object sender, EventArgs e)
        {
            choix[9] = 1;
        }

        private void F2_CheckedChanged(object sender, EventArgs e)
        {
            choix[10] = 1;
        }

        private void F3_CheckedChanged(object sender, EventArgs e)
        {
            choix[11] = 1;
        }

        private void F4_CheckedChanged(object sender, EventArgs e)
        {
            choix[12] = 1;
        }

        private void Serie_SelectedIndexChanged(object sender, EventArgs e)
        {
            Declaration.connecter();
            try
            {

                /*   RS.Checked = false;
                   Ch.Checked = false;
                   Es.Checked = false;
                   Ec.Checked = false;
                   Cg.Checked = false;
                   Ass.Checked = false;
                   Au.Checked = false;
                   Vig.Checked = false;
                   Visite.Checked = false;
                   F1.Checked = false;
                   F2.Checked = false;
                   F3.Checked = false;
                   F4.Checked = false; */
                Declaration.cmd = new SqlCommand("select * from Contrat where N_Serie = '" + Serie.Text + "'", Declaration.cn);
                SqlDataReader dr = Declaration.cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                CIN.Text = dt.Rows[0][2].ToString();
                CIN_conducteur.Text = dt.Rows[0][13].ToString();
                Mtrc.Text = dt.Rows[0][3].ToString();
                dateTimePicker1.Value = DateTime.Parse(dt.Rows[0][4].ToString());
                dateTimePicker2.Value = DateTime.Parse(dt.Rows[0][5].ToString());
                HD.Text = dt.Rows[0][6].ToString();
                HR.Text = dt.Rows[0][7].ToString();
                Prix.Text = dt.Rows[0][10].ToString();
                Duree.Text = dt.Rows[0][9].ToString();
                As.Text = dt.Rows[0][10].ToString();
                FR.Text = dt.Rows[0][11].ToString();
                Av.Text = dt.Rows[0][12].ToString();
                Net.Text = dt.Rows[0][14].ToString();
                Re.Text = dt.Rows[0][17].ToString();
                Depart.Text = dt.Rows[0][16].ToString();
                Tt.Text = dt.Rows[0][18].ToString();
                Entree.Text = dt.Rows[0][15].ToString();
                if (dt.Rows[0][19].ToString() == "True")
                {

                    RS.Checked = true;
                    //  choix[0] = 1;
                }
                else
                {
                    RS.Checked = false;
                }
                if (dt.Rows[0][20].ToString() == "True")
                {
                    Ch.Checked = true;
                    //  choix[1] = 1;
                }
                else
                {
                    Ch.Checked = false;

                }
                if (dt.Rows[0][21].ToString() == "True")
                {
                    Es.Checked = true;
                    //  choix[2] = 1;
                }
                else
                {
                    Es.Checked = false;
                }
                if (dt.Rows[0][22].ToString() == "True")
                {
                    Ec.Checked = true;
                    //  choix[3] = 1;
                }
                else
                {
                    Ec.Checked = false;
                }
                if (dt.Rows[0][23].ToString() == "True")
                {
                    Cg.Checked = true;
                    //  choix[4] = 1;
                }
                else
                {
                    Cg.Checked = false;
                }
                if (dt.Rows[0][24].ToString() == "True")
                {
                    Ass.Checked = true;
                    //   choix[5] = 1;
                }
                else
                {
                    Ass.Checked = false;
                }
                if (dt.Rows[0][25].ToString() == "True")
                {
                    Au.Checked = true;
                    //  choix[6] = 1;
                }
                else
                {
                    Au.Checked = false;
                }
                if (dt.Rows[0][26].ToString() == "True")
                {
                    Vig.Checked = true;
                    // choix[7] = 1;
                }
                else
                {
                    Vig.Checked = false;
                }
                if (dt.Rows[0][27].ToString() == "True")
                {
                    Visite.Checked = true;
                    // choix[8] = 1;
                }
                else
                {
                    Visite.Checked = false;
                }
                if (dt.Rows[0][28].ToString() == "True")
                {
                    F1.Checked = true;
                    //  choix[9] = 1;
                }
                else
                {
                    F1.Checked = false;
                }
                if (dt.Rows[0][29].ToString() == "True")
                {
                    F2.Checked = true;
                    // choix[10] = 1;
                }
                else
                {
                    F2.Checked = false;
                }
                if (dt.Rows[0][30].ToString() == "True")
                {
                    F3.Checked = true;
                    // choix[11] = 1;
                }
                else
                {
                    F3.Checked = false;
                }

                if (dt.Rows[0][31].ToString() == "True")
                {
                    F4.Checked = true;
                    // choix[12] = 1;
                }
                else
                {
                    F4.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Declaration.Fermer();
        }

        private void Mtrc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                PrintPreviewDialog print = new PrintPreviewDialog();
                print.Document = printDocument1;
                print.Show();
                printDocument1.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.pnl1.Width, this.pnl1.Height);
            pnl1.DrawToBitmap(bm, new Rectangle(0, 0, this.pnl1.Width, this.pnl1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void D_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void E_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
