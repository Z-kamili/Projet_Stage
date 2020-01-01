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
    public partial class Generale : UserControl
    {
        private static Generale _instance;
        public static Generale Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Generale();
                return _instance;
            }
        }
        public Generale()
        {
            InitializeComponent();
        }
    }
}
