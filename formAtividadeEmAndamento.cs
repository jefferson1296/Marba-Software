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
    public partial class formAtividadeEmAndamento : Form
    {
        string colaborador;
        ComandosSQL comandos = new ComandosSQL();
        formTelaInicial pai = new formTelaInicial();
        public formAtividadeEmAndamento()
        {
            InitializeComponent();
        }

        public formAtividadeEmAndamento(formTelaInicial Pai, string Colaborador)
        {
            InitializeComponent();
            colaborador = comandos.PrimeiraLetraMaiuscula(Colaborador);
            pai = Pai;
        }

        private void formAtividadeEmAndamento_Load(object sender, EventArgs e)
        {
            string atividade = comandos.NomeDaAtividadeEmAndamento(colaborador);
            DateTime agora = DateTime.Now;
            DateTime manha = Convert.ToDateTime("00:00");
            DateTime tarde = Convert.ToDateTime("12:00");
            DateTime noite = Convert.ToDateTime("18:00");
            DateTime fim_da_noite = Convert.ToDateTime("23:59");

            if (agora >= manha && agora < tarde)
            {
                label1.Text = "Bom dia " + colaborador + ".";
            }
            else if (agora >= tarde && agora < noite)
            {
                label1.Text = "Boa tarde " + colaborador + ".";
            }
            else if (agora >= noite && agora <= fim_da_noite)
            {
                label1.Text = "Boa noite " + colaborador + ".";
            }

            label2.Text = "Atividade em Andamento: " + atividade;
            label1.Left = (panelSuperior.Width - label1.Width) / 2;
            label2.Left = (panelSuperior.Width - label2.Width) / 2;
        }
        private void continuarButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonPausar_Click(object sender, EventArgs e)
        {
            pai.pausar = true;
            Dispose();
        }

        private void buttonEncerrar_Click(object sender, EventArgs e)
        {
            pai.atividade_concluida = true;
            Dispose();
        }
    }
}
