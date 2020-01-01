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
    public partial class Menu_Locataire : UserControl
    {
        private static Menu_Locataire _instance;
        public static Menu_Locataire Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Menu_Locataire();
                return _instance;
            }
        }
        public Menu_Locataire()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Locataire1 l1 = new Locataire1();
            l1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mise_ajour_locataire ms = new Mise_ajour_locataire();
            ms.Show();
        }

        private void Menu_Locataire_Load(object sender, EventArgs e)
        {

        }
    }
}
