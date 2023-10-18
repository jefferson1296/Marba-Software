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
    public partial class formFinanceiroLancamentosCaixaRegistrar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formFinanceiroLancamentosCaixa pai = new formFinanceiroLancamentosCaixa();
        public formFinanceiroLancamentosCaixaRegistrar()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }
        public formFinanceiroLancamentosCaixaRegistrar(formFinanceiroLancamentosCaixa Pai)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            pai = Pai;
        }

        private void formFinanceiroFluxoRegistrarSuprimento_Load(object sender, EventArgs e)
        {
            comboBoxConta.SelectedIndex = 5;
            List<string> lista = comandos.ListaDeCaixasAbertos();
            foreach (string x in lista) { comboBoxCaixa.Items.Add(x); }
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string[] partir = comboBoxCaixa.Text.Split(' ');
            string[] partir1 = textBoxValor.Text.Split('$');

            string conta = comboBoxConta.Text;
            decimal valor = Convert.ToDecimal(partir1[1]);
            if (comboBoxCaixa.Text == string.Empty)
            {
                MessageBox.Show("Informe o caixa para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (conta == string.Empty)
            {
                MessageBox.Show("Informe a conta para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (valor == 0)
            {
                MessageBox.Show("Informe o valor para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int caixa = Convert.ToInt32(partir[0]);
                comandos.RegistrarSuprimentoDeCaixa(caixa, conta, valor);
                pai.Alteracao = true;
                Dispose();
            }
        }

        #region Movimentacao do Formulario
        bool clique;
        Point clickedAt;
        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique)
            {
                this.Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
            }
        }

        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            clique = true;
            clickedAt = e.Location;
        }

        private void panelSuperior_MouseUp(object sender, MouseEventArgs e)
        {
            clique = false;
        }
        #endregion

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
e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
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
                        e.KeyChar = (Char)0;
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
