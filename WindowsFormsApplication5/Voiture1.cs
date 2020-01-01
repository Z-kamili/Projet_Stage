using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Voiture1 : UserControl
    {
        private static Voiture1 _instance;
        public static Voiture1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Voiture1();
                return _instance;
            }
        }
        public Voiture1()
        {
            InitializeComponent();
        }

        private void Voiture1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ajoute_voiture v = new Ajoute_voiture();
            v.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Marque m = new Marque();
            m.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Miseajourvoiture mj = new Miseajourvoiture();
            mj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Miseajourvoiture ms = new Miseajourvoiture();
            ms.Show();
        }
    }
}
