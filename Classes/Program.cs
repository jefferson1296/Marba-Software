using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MarbaSoftware
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]

        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);

        //    Application.Run(new formFinanceiroSimulador2());
        //}

        //public static string usuario = "JEFFERSON";
        //public static string matricula = "20191001001";

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ComandosSQL comandos = new ComandosSQL();

            string computador = SystemInformation.ComputerName;
            string usuario = SystemInformation.UserName;
            ID_Computador id = new ID_Computador();
            string id_computador = id.Valor().ToString();


            if (comandos.VerificarComputadorRegistrado(computador, usuario, id_computador))
            {
                //if (comandos.VerificarServidorAberto())
                //{
                    Application.Run(new formLogin(id_computador, usuario));
                //}
                //else
                //{
                //    MessageBox.Show("Servidor desconectado.\r\nInforme imediatamente à gestão.",
                // "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Este computador ainda não foi registrado. Deseja registrá-lo agora mesmo?", "Computador não identificado", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    formRegistrarComputador registrar = new formRegistrarComputador(computador, usuario, id_computador, true);
                    registrar.ShowDialog();
                }
            }
        }

        public static Colaborador colaborador;
        //public static string usuario;
        public static string matricula;

        public static CPU Computador;
        public static List<Acesso> Acessos;        
    }
}
