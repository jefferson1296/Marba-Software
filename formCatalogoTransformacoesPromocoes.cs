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
    public partial class formCatalogoTransformacoesPromocoes : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id_produtovariacao;
        ProdutoVenda Produto = new ProdutoVenda();

        public formCatalogoTransformacoesPromocoes()
        {
            InitializeComponent();
        }

        public formCatalogoTransformacoesPromocoes(int ID_ProdutoVariacao)
        {
            InitializeComponent();
            id_produtovariacao = ID_ProdutoVariacao;
        }

        private void formCatalogoTransformacoesPromocoes_Load(object sender, EventArgs e)
        {
            Produto = comandos.TrazerInformacoesDoProdutoNaPromocao(id_produtovariacao);

            textBoxProduto.Text = Produto.Produto;
            textBoxCusto.Text = Produto.Custo.ToString("C");
            textBoxVenda.Text = Produto.Preco.ToString("C");
            textBoxPromocao.Text = Produto.Preco_Promocional.ToString("C");
            textBoxPercentual.Text = (100 - Produto.Preco_Promocional / (Produto.Preco / 100)).ToString("F") + "%";

            CalcularMargem();
        }



        private void textBoxPromocao_Enter(object sender, EventArgs e)
        {
            if (textBoxPromocao.Text == "R$0,00")
            {
                textBoxPromocao.Text = string.Empty;
            }
            else
            {
                string[] partir = textBoxPromocao.Text.Split('$');
                textBoxPromocao.Text = partir[1];
            }
        }

        private void textBoxPromocao_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!textBoxPromocao.Text.Contains(','))
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

        private void textBoxPromocao_Leave(object sender, EventArgs e)
        {
            if (textBoxPromocao.Text != string.Empty)
            {
                Produto.Preco_Promocional = Convert.ToDecimal(textBoxPromocao.Text);
            }

            textBoxPromocao.Text = Produto.Preco_Promocional.ToString("C");

            textBoxPercentual.Text = (100 - Produto.Preco_Promocional / (Produto.Preco / 100)).ToString("F") + "%";

            CalcularMargem();
        }

        private void textBoxPercentual_Enter(object sender, EventArgs e)
        {
            if (textBoxPercentual.Text == "R$0,00")
            {
                textBoxPercentual.Text = string.Empty;
            }
            else
            {
                string[] partir = textBoxPercentual.Text.Split('%');
                textBoxPercentual.Text = partir[0];
            }
        }

        private void textBoxPercentual_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!textBoxPercentual.Text.Contains(','))
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

        private void textBoxPercentual_Leave(object sender, EventArgs e)
        {
            decimal percentual = 0;

            if (textBoxPercentual.Text != string.Empty)
            {
                percentual = Convert.ToDecimal(textBoxPercentual.Text);
            }

            textBoxPercentual.Text = percentual.ToString("F") + "%";

            Produto.Preco_Promocional = (Produto.Preco / 100) * (100 - percentual);
            textBoxPromocao.Text = Produto.Preco_Promocional.ToString("C");

            CalcularMargem();
        }

        private void CalcularMargem()
        {
            decimal lucro_bruto = Produto.Preco_Promocional - Produto.Custo;
            decimal margem = lucro_bruto / (Produto.Custo / 100);

            textBoxMargem.Text = margem.ToString("F") + "%";
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            comandos.EditarProdutoDaPromocao(Produto);
            Dispose();
        }
    }
}
