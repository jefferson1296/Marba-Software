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
    public partial class formCatalogoLinhasAdicionarMarkup : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formCatalogoLinhasAdicionar pai = new formCatalogoLinhasAdicionar();

        decimal faturamento;
        decimal fixas;
        decimal variaveis;

        decimal lucro;
        decimal avarias;

        decimal markup;

        public formCatalogoLinhasAdicionarMarkup()
        {
            InitializeComponent();
        }
        public formCatalogoLinhasAdicionarMarkup(formCatalogoLinhasAdicionar Pai)
        {
            InitializeComponent();
            pai = Pai;
        }
        private void formCatalogoLinhasAdicionarMarkup_Load(object sender, EventArgs e)
        {
            fixas = comandos.TotalDespesasPorTipo("Despesa Fixa");
            variaveis = comandos.TotalDespesasPorTipo("Despesa Variável");

            textBoxTotalFixas.Text = fixas.ToString("C");
            textBoxTotalVariaveis.Text = variaveis.ToString("C");

            MessageBox.Show("Selecione o período para calcular as despesas sobre o faturamento.", "Período", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            if (markup == 0)
            {
                MessageBox.Show("Preencha as informações corretamente para calcular o índice multiplicador!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                pai.linha.Lucro = lucro;
                pai.linha.Markup = markup;
                pai.alteracao_markup = true;
                Dispose();
            }
        }

        private void CalcularMarkup()
        {
            if (faturamento != 0)
            {
                decimal fixas_percentual = fixas / (faturamento / 100);
                decimal variaveis_percentual = variaveis / (faturamento / 100);

                textBoxFixas.Text = fixas_percentual.ToString("F") + "%";
                textBoxVariaveis.Text = variaveis_percentual.ToString("F") + "%";

                markup = 1 / (1 - ((fixas_percentual + variaveis_percentual + lucro + avarias) / 100));
            }
            else
            {
                markup = 0;
            }

            textBoxMarkup.Text = markup.ToString("F");
        }

        private void dateTimeTermino_ValueChanged(object sender, EventArgs e)
        {
            DateTime inicio = dateTimeInicio.Value.Date;
            DateTime termino = dateTimeTermino.Value.Date;

            if (termino > inicio)
            {
                faturamento = comandos.FaturamentoNoPeriodo(inicio, termino);
                CalcularMarkup();
            }
            else
            {
                faturamento = 0;
            }

            textBoxFaturamento.Text = faturamento.ToString("C");
        }

        private void textBoxLucro_Enter(object sender, EventArgs e)
        {
            if (textBoxLucro.Text == "0,00%")
            {
                textBoxLucro.Text = string.Empty;
            }
            else
            {
                string[] partir = textBoxLucro.Text.Split('%');
                textBoxLucro.Text = partir[0];
            }
        }

        private void textBoxLucro_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!textBoxLucro.Text.Contains(','))
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

        private void textBoxLucro_Leave(object sender, EventArgs e)
        {
            if (textBoxLucro.Text == string.Empty)
            {
                lucro = 0;
            }
            else
            {
                lucro = Convert.ToDecimal(textBoxLucro.Text);
            }

            textBoxLucro.Text = lucro.ToString("F") + "%";

            CalcularMarkup();
        }

        private void textBoxAvarias_Enter(object sender, EventArgs e)
        {
            if (textBoxAvarias.Text == "0,00%")
            {
                textBoxAvarias.Text = string.Empty;
            }
            else
            {
                string[] partir = textBoxAvarias.Text.Split('%');
                textBoxAvarias.Text = partir[0];
            }
        }

        private void textBoxAvarias_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!textBoxAvarias.Text.Contains(','))
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

        private void textBoxAvarias_Leave(object sender, EventArgs e)
        {
            if (textBoxAvarias.Text == string.Empty)
            {
                avarias = 0;
            }
            else
            {
                avarias = Convert.ToDecimal(textBoxAvarias.Text);
            }

            textBoxAvarias.Text = avarias.ToString("F") + "%";

            CalcularMarkup();
        }
    }
}
