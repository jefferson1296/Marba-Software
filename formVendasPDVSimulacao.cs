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
    public partial class formVendasPDVSimulacao : Form
    {
        string bandeira;
        int parcelas = 0;

        ComandosSQL comandos = new ComandosSQL();
        formVendasPDV pdv = new formVendasPDV();
        bool calculado = false;
        decimal valor_total;
        public formVendasPDVSimulacao()
        {
            InitializeComponent();
        }
        public formVendasPDVSimulacao(decimal Valor_Total, formVendasPDV PDV)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            valor_total = Valor_Total;
            pdv = PDV;
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            if (comboBoxBandeira.Text == string.Empty)
            {
                MessageBox.Show("Informe a bandeira do Cartão para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBoxParcelas.Text == string.Empty || parcelas == 0)
            {
                MessageBox.Show("Informe a quantidade de parcelas para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxValor.Text == string.Empty || textBoxValor.Text == "R$0,00")
            {
                MessageBox.Show("Informe o valor para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (parcelas < Convert.ToInt32(comandos.ObterValorDoParametro("Limite de Parcelas sem Juros")))
                {
                    MessageBox.Show("O estabelecimento não cobra juros em compras parceladas em até " + Convert.ToInt32(comandos.ObterValorDoParametro("Limite de Parcelas sem Juros")).ToString() + "x!", "Sem juros!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (parcelas > 12)
                {
                    MessageBox.Show("O limite de parcelamento é 12x!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string[] partir = textBoxValor.Text.Split('$');
                    decimal valor = Convert.ToDecimal(partir[1]);
                    decimal taxa = comandos.TaxaDeJurosDoCartao(bandeira, parcelas, "Crédito");

                    decimal valor_com_juros = (100 * valor / (100 - taxa));
                    decimal juros_total = valor_com_juros - valor;
                    decimal juros_parcela = juros_total / parcelas;

                    //decimal juros_total = valor_antecipacao * juros / 100 + diferenca;

                    textBoxPercentual.Text = taxa.ToString() + "%";
                    textBoxJurosParcela.Text = juros_parcela.ToString("C");
                    textBoxJurosTotal.Text = juros_total.ToString("C");
                    textBoxTotalComJuros.Text = valor_com_juros.ToString("C");
                }
            }
            calculado = true;
        }

        private void textBoxValor_Enter(object sender, EventArgs e)
        {
            calculado = false;
            textBoxValor.ForeColor = Color.Black;
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

        private void textBoxValor_Leave(object sender, EventArgs e)
        {
            if (textBoxValor.Text == string.Empty)
            {
                textBoxValor.Text = "R$0,00";
                textBoxValor.ForeColor = Color.Gray;
            }
            else
            {
                string valor = textBoxValor.Text;
                textBoxValor.Text = Convert.ToDouble(valor).ToString("C");
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

        private void comboBoxBandeira_SelectedIndexChanged(object sender, EventArgs e)
        {
            bandeira = comboBoxBandeira.Text;
            List<string> parcelas = comandos.ParcelasDosCartoes(bandeira, "Crédito");
            comboBoxParcelas.Items.Clear();
            foreach (string parcela in parcelas) { comboBoxParcelas.Items.Add(parcela); }
            comboBoxParcelas.Enabled = true;
        }

        private void comboBoxParcelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            parcelas = Convert.ToInt32(comboBoxParcelas.Text);
        }

        private void formVendasPDVSimular_Load(object sender, EventArgs e)
        {
            List<string> bandeiras = comandos.BandeirasDosCartoes("Crédito");
            comboBoxBandeira.Items.Clear();
            foreach (string bandeira in bandeiras) { comboBoxBandeira.Items.Add(bandeira); }
        }

        #region Movimentacao do Formulario
        bool clique;
        Point clickedAt;
        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique)
            {
                Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
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
    }
}
