using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApplication5
{
    public partial class Information : UserControl
    {
        private static Information _instance;
        public static Information Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Information();
                return _instance;
            }
        }
        public Information()
        {
            InitializeComponent();
        }

        private void Information_Load(object sender, EventArgs e)
        {
            //remplir datagridview
            try
            {
                Declaration.connecter();
                Declaration.cmd = new SqlCommand("Select Contrat.CIN,Date_Depart,Date_retour,Heur_Depart,Heur_retour,Locataire.Prenom, Locataire.Nom, Locataire.Tel, Matricule from Locataire, Contrat  where Locataire.CIN = Contrat.CIN AND DATEDIFF(Year, getdate(), Date_retour) = 0 AND DATEDIFF(MONTH, getdate(), Date_retour) = 0 AND DATEDIFF(Day, getdate(), Date_retour) = 0 ", Declaration.cn);
                SqlDataReader rd = Declaration.cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                dataGridView1.DataSource = dt;
                Declaration.Fermer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }
    }
}
