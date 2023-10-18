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
    public partial class formColaboradoresDefinirFeriadosEditar : Form
    {
        formColaboradoresDefinirFeriados pai = new formColaboradoresDefinirFeriados();
        Data feriado = new Data();
        int ano;
        public formColaboradoresDefinirFeriadosEditar()
        {
            InitializeComponent();
        }
        public formColaboradoresDefinirFeriadosEditar(Data Feriado, int Ano, formColaboradoresDefinirFeriados Pai)
        {
            InitializeComponent();
            feriado = Feriado;
            ano = Ano;
            pai = Pai;
        }

        private void formTelaInicialDefinirFeriadosEditar_Load(object sender, EventArgs e)
        {
            textBoxDescricao.Text = feriado.Descricao;
            comboBoxFuncionamento.SelectedItem = feriado.Loja;
            checkBoxPromocao.Checked = feriado.Promocao;
            textBoxObs.Text = feriado.Observacao;
            if (feriado.Dia != string.Empty)
            {
                dateTimePicker.Text = feriado.Dia;
                dateTimePicker.Enabled = false;
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            feriado.Loja = comboBoxFuncionamento.Text;
            feriado.Promocao = checkBoxPromocao.Checked;
            feriado.Observacao = textBoxObs.Text;
            DateTime data = new DateTime(ano, dateTimePicker.Value.Month, dateTimePicker.Value.Day);
            feriado.Dia = data.ToShortDateString();

            foreach (Data Feriado in pai.Feriados)
            {
                if (Feriado.ID_Data == feriado.ID_Data)
                {
                    Feriado.Loja = feriado.Loja;
                    Feriado.Promocao = feriado.Promocao;
                    Feriado.Observacao = feriado.Observacao;
                    Feriado.Dia = feriado.Dia;
                }
            }

            Dispose();
        }
    }
}
