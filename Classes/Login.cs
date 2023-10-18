using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbaSoftware
{
    public class Login
    {
        public bool confirmacao;
        public string mensagem = "";
        public bool AcessarComMatricula(string login, string senha)
        {
            LoginSQL loginSQL = new LoginSQL();
            confirmacao = loginSQL.verificarMatricula(login, senha);

            if (!loginSQL.mensagem.Equals(""))
            {
                mensagem = loginSQL.mensagem;
            }
            return confirmacao;
        }

        public bool AcessarComLogin(string login, string senha)
        {
            LoginSQL loginSQL = new LoginSQL();
            confirmacao = loginSQL.verificarLogin(login, senha);

            if (!loginSQL.mensagem.Equals(""))
            {
                mensagem = loginSQL.mensagem;
            }
            return confirmacao;
        }

        public string Cadastrar(string login, string senha, string confirmar)
        {
            return mensagem;
        }

    }

    public class CPU
    {
        public string ID { get; set; }
        public string Computador { get; set; }
        public string Usuario { get; set; }
        public string Reparticao { get; set; }
        public string Impressora_A4 { get; set; }
        public string Impressora_Termica { get; set; }
        public string Porta_Serial { get; set; }
        public int ID_Estabelecimento { get; set; }
        public int ID_Reparticao { get; set; }
        public bool Edicao { get; set; } //Utilizado apenas para editar configurações
    }
}
