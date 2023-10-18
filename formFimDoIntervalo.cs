using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarbaSoftware
{
    public partial class formFimDoIntervalo : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        bool lanche = false;
        bool almoco = false;
        string horario;
        string colaborador;
        string mensagem;
        formTelaInicial pai = new formTelaInicial();
        DateTime inicio;
        public formFimDoIntervalo()
        {
            InitializeComponent();
        }
        public formFimDoIntervalo(formTelaInicial Pai, string Intervalo, string Horario, string Colaborador)
        {
            InitializeComponent();
            if (Intervalo == "Almoço") { almoco = true; lanche = false; }
            else if (Intervalo == "Lanche") { lanche = true; almoco = false; }
            horario = Horario;
            pai = Pai;
            colaborador = Colaborador;
        }

        private void formFimDoIntervalo_Load(object sender, EventArgs e)
        {
            inicio = DateTime.Now;
            int Periodo = 0;

            if (lanche)
            {
                inicio = comandos.HoraQueOLancheComecou(colaborador);
                Periodo = Convert.ToInt32(comandos.ObterValorDoParametro("Período do Lanche"));
            }
            else if (almoco)
            {
                inicio = comandos.HoraQueOAlmocoComecou(colaborador);
                Periodo = Convert.ToInt32(comandos.ObterValorDoParametro("Período do Almoço"));
            }

            DateTime periodo = Convert.ToDateTime("00:00:00").AddMinutes(Periodo);
            DateTime agora = DateTime.Now;


            int segundos = Convert.ToInt32((agora - inicio).TotalSeconds);
            DateTime intervalo = Convert.ToDateTime("00:00:00").AddSeconds(segundos);
            int Diferenca = Convert.ToInt32(periodo.Subtract(intervalo).TotalSeconds);
            DateTime diferenca = Convert.ToDateTime("00:00:00").AddMinutes(Diferenca);

            if (periodo > intervalo)
            {
                mensagem = "O intervalo se encerra em " + diferenca.ToLongTimeString();
                timer.Enabled = true;
            }
            else
            {
                mensagem = "O intervalo acabou! Clique em finalizar para retomar as atividades.";
            }
            labelMensagem.Text = mensagem;
            labelHorario.Text = horario;
            if (lanche)
            {
                labelIntervalo.Text = "Fim do intervalo - Lanche";
            }
            else if (almoco)
            {
                labelIntervalo.Text = "Fim do intervalo - Almoço";
            }

            labelMensagem.Left = (panelSuperior.Width - labelMensagem.Width) / 2;
            labelIntervalo.Left = (panelLinha.Width - labelIntervalo.Width) / 2;
            labelHorario.Left = (panelLinha.Width - labelHorario.Width) / 2;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int Periodo = 0;

            if (lanche)
            {
                inicio = comandos.HoraQueOLancheComecou(colaborador);
                Periodo = Convert.ToInt32(comandos.ObterValorDoParametro("Período do Lanche"));
            }
            else if (almoco)
            {
                inicio = comandos.HoraQueOAlmocoComecou(colaborador);
                Periodo = Convert.ToInt32(comandos.ObterValorDoParametro("Período do Almoço"));
            }

            DateTime periodo = Convert.ToDateTime("00:00:00").AddMinutes(Periodo);
            DateTime agora = DateTime.Now;


            int segundos = Convert.ToInt32((agora - inicio).TotalSeconds);
            DateTime intervalo = Convert.ToDateTime("00:00:00").AddSeconds(segundos);
            int Diferenca = Convert.ToInt32(periodo.Subtract(intervalo).TotalSeconds);
            DateTime diferenca = Convert.ToDateTime("00:00:00").AddMinutes(Diferenca);

            if (periodo > intervalo)
            {
                mensagem = "O intervalo se encerra em " + diferenca.ToLongTimeString();
                timer.Enabled = true;
            }
            else
            {
                mensagem = "O intervalo acabou! Clique em finalizar para retomar as atividades.";
            }
            labelMensagem.Text = mensagem;
            labelMensagem.Left = (panelSuperior.Width - labelMensagem.Width) / 2;
        }

        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonFinalizar_Click(object sender, EventArgs e)
        {
            int Periodo = 0;

            if (lanche)
            {
                inicio = comandos.HoraQueOLancheComecou(colaborador);
                Periodo = Convert.ToInt32(comandos.ObterValorDoParametro("Período do Lanche"));
            }
            else if (almoco)
            {
                inicio = comandos.HoraQueOAlmocoComecou(colaborador);
                Periodo = Convert.ToInt32(comandos.ObterValorDoParametro("Período do Almoço"));
            }

            DateTime agora = DateTime.Now;
            DateTime termino = inicio.AddMinutes(Periodo);
            bool continuar = false;

            if (termino > agora)
            {
                if (DialogResult.Yes == MessageBox.Show("Seu intervalo ainda não chegou ao fim, tem certeza que deseja finalizá-lo?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    continuar = true;
                }
            }
            else
            {
                continuar = true;
            }
            if (continuar)
            {
                if (lanche)
                {
                    comandos.FinalizarLanche(colaborador);
                    Dispose();
                }
                else if (almoco)
                {
                    comandos.FinalizarAlmoco(colaborador);
                    Dispose();
                }
            }
        }
    }
}
