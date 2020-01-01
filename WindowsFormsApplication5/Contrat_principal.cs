using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Contrat_principal : UserControl
    {
        private static Contrat_principal _instance;
        public static Contrat_principal Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Contrat_principal();
                return _instance;
            }
        }
        public Contrat_principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cnt cn = new Cnt();
            cn.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MDF m = new MDF();
            m.Show();
        }

        private void Contrat_principal_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Infraction ins = new Infraction();
            ins.Show();
        }
    }
}
