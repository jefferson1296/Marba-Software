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
    public partial class formColaboradoresDatasCadastrar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formColaboradoresDatas pai = new formColaboradoresDatas();
        public bool alteracao;
        public formColaboradoresDatasCadastrar()
        {
            InitializeComponent();
        }
        public formColaboradoresDatasCadastrar(formColaboradoresDatas Pai)
        {
            InitializeComponent();
            pai = Pai;
        }
        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (textBoxDescricao.Text == string.Empty)
            {
                MessageBox.Show("Informe a Descrição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBoxFuncionamento.Text == string.Empty)
            {
                MessageBox.Show("Informe o funcionamento para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Data Feriado = new Data();
                Feriado.Descricao = textBoxDescricao.Text;
                Feriado.Loja = comboBoxFuncionamento.Text;

                if (checkBoxPromocao.Checked) { Feriado.Promocao = true; } else { Feriado.Promocao = false; }
                if (checkBoxData.Checked) { Feriado.Dia = dateTimePicker.Text; } else { Feriado.Dia = string.Empty; }

                Feriado.Promocao = checkBoxPromocao.Checked;
                Feriado.Observacao = textBoxObs.Text;
                if (radioButtonFeriado.Checked) { Feriado.Tipo = "FERIADO"; } else { Feriado.Tipo = "DATA COMEMORATIVA"; }

                comandos.CadastrarFeriado(Feriado);

                if (Feriado.Dia != string.Empty)
                {
                    DateTime data_selecionada = Convert.ToDateTime(Feriado.Dia);
                    DateTime data = new DateTime(DateTime.Now.Year, data_selecionada.Month, data_selecionada.Day);

                    if (data >= DateTime.Now.Date)
                    {
                        if (DialogResult.Yes == MessageBox.Show("Deseja definir o feriado cadastrado para o ano que vem?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            Feriado.Dia = data.AddYears(1).ToShortDateString();
                            comandos.DefinirFeriado(Feriado);
                        }
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Deseja definir o feriado cadastrado para esse ano?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            Feriado.Dia = data.ToShortDateString();
                            comandos.DefinirFeriado(Feriado);
                        }
                    }
                }

                pai.alteracao = true;
                Dispose();
            }
        }

        private void checkBoxData_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxData.Checked) 
            {
                dateTimePicker.Visible = true;
                textBoxData.Visible = false;
            }
            else
            {
                dateTimePicker.Visible = false;
                textBoxData.Visible = true;
            }
        }
    }
}
