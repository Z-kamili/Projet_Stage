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
    public partial class Agence : Form
    {
        public Agence()
        {
            InitializeComponent();
            if (!panel5.Controls.Contains(Generale.Instance))
            {

                panel5.Controls.Add(Generale.Instance);
                Generale.Instance.Dock = DockStyle.Fill;
                Generale.Instance.BringToFront();
            }
            else
                Generale.Instance.BringToFront();

        }

        private void btnslide_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 89;
            }
            else
                MenuVertical.Width = 250;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //  locataire1.BringToFront();
            // locataire1.Invalidate();
            /*  locataire1.Show();
              information1.Hide();
              voiture1.Hide();
              contrat1.Hide();
              generale1.Hide();
              //panel5.Show();*/
            if (!panel5.Controls.Contains(Menu_Locataire.Instance))
            {
                panel5.Controls.Add(Menu_Locataire.Instance);
                Menu_Locataire.Instance.Dock = DockStyle.Fill;
                Menu_Locataire.Instance.BringToFront();
            }
            else
                Menu_Locataire.Instance.BringToFront();

        }

        private void btnprod_Click(object sender, EventArgs e)
        {
          
            if (!panel5.Controls.Contains(Information.Instance))
            {
                panel5.Controls.Add(Information.Instance);
                Information.Instance.Dock = DockStyle.Fill;
                Information.Instance.BringToFront();
            }
            else
                Information.Instance.BringToFront();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //voiture1.BringToFront();
            /*  voiture1.Refresh();
              locataire1.Hide();
              information1.Hide();
              voiture1.Show();

              contrat1.Hide();
              generale1.Hide();*/
            if (!panel5.Controls.Contains(Voiture1.Instance))
            {
                panel5.Controls.Add(Voiture1.Instance);
                Voiture1.Instance.Dock = DockStyle.Fill;
                Voiture1.Instance.BringToFront();
            }
            else
                Voiture1.Instance.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //contrat1.BringToFront();
            //contrat1.Show();

            /*    locataire1.Hide();
                information1.Hide();
                voiture1.Hide();
                contrat1.Show();
                generale1.Hide();*/

            if (!panel5.Controls.Contains(Contrat_principal.Instance))
            {
                panel5.Controls.Add(Contrat_principal.Instance);
                Contrat_principal.Instance.Dock = DockStyle.Fill;
                Contrat_principal.Instance.BringToFront();
            }
            else
                Contrat_principal.Instance.BringToFront();

        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void iconrestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconrestaurar.Visible = false;
            iconmaximizar.Visible = true;
        }

        private void iconmaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconrestaurar.Visible = true;
            iconmaximizar.Visible = false;
        }

        private void iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void information1_Load(object sender, EventArgs e)
        {
          /*  locataire1.Hide();
            information1.Hide();
            voiture1.Hide();
            contrat1.Hide();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //locataire1.Hide();
            //information1.Hide();
            //voiture1.Hide();
            //contrat1.Hide();
            //generale1.Show();
          


        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
