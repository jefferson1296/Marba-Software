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
    public partial class formGestaoEstabelecimentosReparticoesAtividadesIntervalos : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        Atividade Atividade = new Atividade();

        string atividade;
        int id_reparticao;

        public formGestaoEstabelecimentosReparticoesAtividadesIntervalos()
        {
            InitializeComponent();
        }

        public formGestaoEstabelecimentosReparticoesAtividadesIntervalos(string Atividade, int ID_Reparticao)
        {
            InitializeComponent();
            atividade = Atividade;
            id_reparticao = ID_Reparticao;
        }

        private void formGestaoEstabelecimentosReparticoesAtividadesIntervalos_Load(object sender, EventArgs e)
        {
            Atividade = comandos.TrazerInformacoesDaRotina(atividade, id_reparticao);

            intervaloTextBox.Text = Atividade.Intervalo.ToString();
            dateTimePicker.Value = Atividade.Proxima_Execucao.Date;
        }

        private void intervaloTextBox_Enter(object sender, EventArgs e)
        {
            if (intervaloTextBox.Text == "0")
                intervaloTextBox.Text = string.Empty;
        }

        private void intervaloTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void intervaloTextBox_Leave(object sender, EventArgs e)
        {
            if (intervaloTextBox.Text == string.Empty)
                intervaloTextBox.Text = "0";
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            int intervalo = Convert.ToInt32(intervaloTextBox.Text);
            DateTime proxima = dateTimePicker.Value.Date;

            if (intervalo == 0)
            {
                MessageBox.Show("Informe o intervalo para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (proxima < DateTime.Now.Date)
            {
                MessageBox.Show("Informe uma data que ainda não passou para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Atividade.Descricao = atividade;
                Atividade.Intervalo = intervalo;
                Atividade.Proxima_Execucao = proxima;

                comandos.EditarInformacoesDaRotina(Atividade, id_reparticao);
                Dispose();
            }
        }
    }
}
