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
    public partial class formFinanceiroPrevisoesBoletosAdicionar : Form
    {
        Boleto boleto = new Boleto();
        Previsao previsao = new Previsao();
        string tipo;
        ComandosSQL comandos = new ComandosSQL();
        public formFinanceiroPrevisoesBoletosAdicionar()
        {
            InitializeComponent();
        }
        public formFinanceiroPrevisoesBoletosAdicionar(Boleto Boleto, string Tipo)
        {
            InitializeComponent();
            boleto = Boleto;
            tipo = Tipo;
        }
        public formFinanceiroPrevisoesBoletosAdicionar(Previsao Previsao, string Tipo)
        {
            InitializeComponent();
            previsao = Previsao;
            tipo = Tipo;
        }
        private void formFinanceiroBoletosPagamento_Load(object sender, EventArgs e)
        {
            if (tipo == "Previsão")
            {
                textBoxDescricao.Text = previsao.Descricao;
                textBoxValor.Text = previsao.Valor.ToString("C");
            }
            else
            {
                textBoxDescricao.Text = boleto.Descricao;
                textBoxValor.Text = boleto.Valor.ToString("C");
            }

            comboBoxFin.DataSource = comandos.PreencherComboPlanoDeContas(false);
            comboBoxFin.DisplayMember = "Categoria";
            comboBoxFin.ValueMember = "ID";
            comboBoxFin.DropDownHeight = 120;
            comboBoxFin.SelectedIndex = -1;


            comboBoxConta.DataSource = comandos.PreencherComboContas();
            comboBoxConta.DisplayMember = "Descricao";
            comboBoxConta.ValueMember = "ID_Conta";
            comboBoxConta.DropDownHeight = 120;
            comboBoxConta.SelectedIndex = -1;
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string conta = comboBoxConta.Text;
            string saldo = comboBoxSaldo.Text;
            string categoria = comboBoxFin.Text;
            DateTime data = dateTimePicker.Value;

            decimal valor = comandos.ConverterDinheiroEmDecimal(textBoxValor.Text);

            if (conta == string.Empty || saldo == string.Empty || categoria == string.Empty)
            {
                MessageBox.Show("Preencha todas as informações para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (valor == 0)
            {
                MessageBox.Show("Informe o valor para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id_catfin = (int)comboBoxFin.SelectedValue;
                int id_conta = (int)comboBoxConta.SelectedValue;

                if (tipo == "Previsão")
                {
                    previsao.Valor = valor;
                    comandos.RealizarPagamentoPrevisto(previsao, id_conta, saldo, id_catfin, data);
                    Dispose();
                }
                else
                {
                    boleto.Valor = valor;
                    comandos.RealizarPagamentoDeBoleto(boleto, id_conta, saldo, id_catfin, data);
                    Dispose();
                }
            }
        }

        private void textBoxValor_Enter(object sender, EventArgs e)
        {
            if (textBoxValor.Text == "R$0,00")
            {
                textBoxValor.Text = string.Empty;
            }
            else
            {
                string[] partir = textBoxValor.Text.Split('$');
                textBoxValor.Text = partir[1];
            }
        }

        private void textBoxValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
            (e.KeyChar != ',' && e.KeyChar != '.' &&
            e.KeyChar != (char)13 && e.KeyChar != (char)8))
            {
                e.KeyChar = (char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!textBoxValor.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (char)0;
                    }
                }
            }
        }

        private void textBoxValor_Leave(object sender, EventArgs e)
        {
            if (textBoxValor.Text == string.Empty)
            {
                textBoxValor.Text = "R$0,00";
            }
            else
            {
                decimal valor = Convert.ToDecimal(textBoxValor.Text);
                textBoxValor.Text = valor.ToString("C");
            }
        }
    }
}
