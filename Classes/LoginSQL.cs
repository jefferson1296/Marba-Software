using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbaSoftware
{
    class LoginSQL
    {
        public bool confirmacao = false;
        public string mensagem = "";
        SqlCommand comando = new SqlCommand();
        Conexao conexao = new Conexao();
        SqlDataReader leitor;

        public bool verificarMatricula (string matricula, string senha)
        {
            //comando para consultar sql
            comando.CommandText = "SELECT * FROM tbl_Colaboradores WHERE Matricula = @usuario AND Senha = @senha AND Ativacao = 1";
            comando.Parameters.AddWithValue("@usuario", matricula);
            comando.Parameters.AddWithValue("@senha", senha);

            try
            {
                comando.Connection = conexao.Conectar();
                leitor = comando.ExecuteReader();
                
                if (leitor.HasRows)
                {
                    confirmacao = true;
                }
            }
            catch (SqlException)
            {
                mensagem = "Erro ao se conectar";
            }

            return confirmacao;
        }

        public bool verificarLogin(string login, string senha)
        {
            //comando para consultar sql
            comando.CommandText = "SELECT * FROM tbl_Colaboradores WHERE Login_Sistema = @usuario AND Senha = @senha AND Ativacao = 1";
            comando.Parameters.AddWithValue("@usuario", login);
            comando.Parameters.AddWithValue("@senha", senha);
            try
            {
                comando.Connection = conexao.Conectar();
                leitor = comando.ExecuteReader();
                if (leitor.HasRows)
                {
                    confirmacao = true;
                }
            }
            catch (SqlException)
            {
                mensagem = "Erro ao se conectar";
            }

            return confirmacao;
        }

        public string Cadastrar(string login, string senha, string confirmar)
        {
            return mensagem;
        }
    }
}
