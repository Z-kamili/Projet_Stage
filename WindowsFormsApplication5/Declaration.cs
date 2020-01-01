using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApplication5
{
    class Declaration
    {
        public static SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-14BHUMG\SQLEXPRESS;Initial Catalog=LPC_CARS2;Integrated Security=true");
        public static  SqlCommand cmd;
        public static void connecter()
        {
            if (Declaration.cn.State == ConnectionState.Closed || Declaration.cn.State == ConnectionState.Broken)
            {
                Declaration.cn.Open();
            }
        }
        public static void Fermer()
        {
            Declaration.cn.Close();
        }
    }
}
