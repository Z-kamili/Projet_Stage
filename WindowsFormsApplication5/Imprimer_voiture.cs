using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Imprimer_voiture : Form
    {
        DataSet dr = new DataSet();
        public Imprimer_voiture(DataSet ds)
        {
            InitializeComponent();
            dr = ds;
          
        }

        private void Imprimer_voiture_Load(object sender, EventArgs e)
        {
            CrystalReport1 cr = new CrystalReport1();
            cr.SetDataSource(dr);
            crystalReportViewer1.ReportSource = cr;
           
        }
    }
}
