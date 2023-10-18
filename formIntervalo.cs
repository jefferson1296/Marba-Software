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
    public partial class formIntervalo : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        bool lanche = false;
        bool almoco = false;
        string mensagem;
        string horario;
        string colaborador;
        formTelaInicial pai = new formTelaInicial();
        public formIntervalo()
        {
            InitializeComponent();
        }
        public formIntervalo(formTelaInicial Pai, string Intervalo, string Mensagem, string Horario, string Colaborador)
        {
            InitializeComponent();
            if (Intervalo == "Almoço") { almoco = true; lanche = false; }
            else if (Intervalo == "Lanche") { lanche = true; almoco = false; }
            mensagem = Mensagem;
            horario = Horario;
            pai = Pai;
            colaborador = Colaborador;
        }

        private void formIntervalo_Load(object sender, EventArgs e)
        {
            string turno = comandos.TurnoDoDia();
            string inicio_da_mensagem = turno + " " + colaborador + ", ";
            labelMensagem.Text = inicio_da_mensagem + mensagem;
            labelHorario.Text = horario;
            if (lanche)
            {
                labelIntervalo.Text = "Intervalo - Lanche";
                irButton.Text = "Ir para o Lanche";
            }
            else if (almoco)
            {
                labelIntervalo.Text = "Intervalo - Almoço";
                irButton.Text = "Ir para o Almoço";
            }

            labelMensagem.Left = (panelSuperior.Width - labelMensagem.Width) / 2;
            labelIntervalo.Left = (panelLinha.Width - labelIntervalo.Width) / 2;
            labelHorario.Left = (panelLinha.Width - labelHorario.Width) / 2;
        }

        private void atividadesButton_Click(object sender, EventArgs e)
        {
            pai.ir_para_atividade = true;
            Dispose();
        }

        private void irButton_Click(object sender, EventArgs e)
        {
            if (lanche)
            {
                comandos.IniciarLanche(colaborador);
                Dispose();
            }
            else if (almoco)
            {
                comandos.IniciarAlmoco(colaborador);
                Dispose();
            }
        }

        private void buttonPausar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
