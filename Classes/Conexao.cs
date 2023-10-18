using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MarbaSoftware
{
    class Conexao
    {
        SqlConnection conexao = new SqlConnection();

        public Conexao()
        {
            string servidor = @"Data Source=MARBASERVIDOR\SQLEXPRESS;Initial Catalog=bd_Marba;User ID=sa;Password=1296";
            string servidor2 = @"Data Source=DESKTOP-C4A0FDU\SQLEXPRESS;Initial Catalog=bd_Marba;Integrated Security=True";
            string notebook = conexao.ConnectionString = @"Data Source=LAPTOP-FTE9PV73\SQLEXPRESS;Initial Catalog=bd_Marba;Integrated Security=True";
            //conexao.ConnectionString = @"Data Source=MARBASERVIDOR\SQLEXPRESS;Initial Catalog=bd_Marba;Integrated Security=False";

            conexao.ConnectionString = servidor2;
        }

        public SqlConnection Conectar()
        {
            if (conexao.State == System.Data.ConnectionState.Closed)
            {
                conexao.Open();
            }

            return conexao;
        }
        public void Desconectar()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}
