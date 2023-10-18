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
    public partial class formFornecedoresPedidoConfirmarProduto : Form
    {
        formFornecedoresPedidoConfirmar pai = new formFornecedoresPedidoConfirmar();
        int id_produto;
        public formFornecedoresPedidoConfirmarProduto()
        {
            InitializeComponent();
        }
        public formFornecedoresPedidoConfirmarProduto(formFornecedoresPedidoConfirmar Pai, int ID_Produto)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            pai = Pai;
            id_produto = ID_Produto;
        }

        private void formFornecedoresPedidoConfirmarProduto_Load(object sender, EventArgs e)
        {
            string produto = pai.Produtos.Where(x => x.ID_ProdutoVariacao == id_produto).Select(x => x.Produto).FirstOrDefault();
            decimal preco_base = pai.Produtos.Where(x => x.ID_ProdutoVariacao == id_produto).Select(x => x.Base_Custo).FirstOrDefault();
            decimal ipi = pai.Produtos.Where(x => x.ID_ProdutoVariacao == id_produto).Select(x => x.Aliquota_IPI).FirstOrDefault();
            decimal icms = pai.Produtos.Where(x => x.ID_ProdutoVariacao == id_produto).Select(x => x.Aliquota_ICMS).FirstOrDefault();
            decimal custo = pai.Produtos.Where(x => x.ID_ProdutoVariacao == id_produto).Select(x => x.Preco).FirstOrDefault();
            int quantidade = pai.Produtos.Where(x => x.ID_ProdutoVariacao == id_produto).Select(x => x.Pedido).FirstOrDefault();

            produtoTextBox.Text = produto;
            baseTextBox.Text = preco_base.ToString("C");
            ipiTextBox.Text = ipi.ToString("F") + "%";
            icmsTextBox.Text = icms.ToString("F") + "%";
            precoTextBox.Text = custo.ToString("C");
            quantidadeTextBox.Text = quantidade.ToString();
        }

        private void baseTextBox_Enter(object sender, EventArgs e)
        {
            if (baseTextBox.Text == "R$0,00")
            {
                baseTextBox.Text = string.Empty;
            }
            else
            {
                string[] partir = baseTextBox.Text.Split('$');
                baseTextBox.Text = partir[1];
            }
        }
        private void baseTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!baseTextBox.Text.Contains(','))
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
        private void baseTextBox_Leave(object sender, EventArgs e)
        {
            if (baseTextBox.Text == String.Empty)
            {
                baseTextBox.Text = "R$0,00";
            }
            else
            {
                decimal base_custo = Convert.ToDecimal(baseTextBox.Text);
                baseTextBox.Text = base_custo.ToString("C");
            }
            CalcularInformacoesFinanceiras();
        }
        private void ipiTextBox_Enter(object sender, EventArgs e)
        {
            if (ipiTextBox.Text == "0,00%")
            {
                ipiTextBox.Text = string.Empty;
            }
            else
            {
                string[] partir = ipiTextBox.Text.Split('%');
                ipiTextBox.Text = partir[0];
            }
        }
        private void ipiTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!ipiTextBox.Text.Contains(','))
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
        private void ipiTextBox_Leave(object sender, EventArgs e)
        {
            if (ipiTextBox.Text == string.Empty)
            {
                ipiTextBox.Text = "0,00%";
                ipiTextBox.ForeColor = Color.Gray;
            }
            else
            {
                decimal aliquota_ipi = Convert.ToDecimal(ipiTextBox.Text);
                ipiTextBox.Text = aliquota_ipi.ToString("F") + "%";
            }
            CalcularInformacoesFinanceiras();
        }
        private void icmsTextBox_Enter(object sender, EventArgs e)
        {
            if (icmsTextBox.Text == "0,00%")
            {
                icmsTextBox.Text = string.Empty;
            }
            else
            {
                string[] partir = icmsTextBox.Text.Split('%');
                icmsTextBox.Text = partir[0];
            }
        }
        private void icmsTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!icmsTextBox.Text.Contains(','))
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
        private void icmsTextBox_Leave(object sender, EventArgs e)
        {
            if (icmsTextBox.Text == string.Empty)
            {
                icmsTextBox.Text = "0,00%";
                icmsTextBox.ForeColor = Color.Gray;
            }
            else
            {
                decimal aliquota_ipi = Convert.ToDecimal(icmsTextBox.Text);
                icmsTextBox.Text = aliquota_ipi.ToString("F") + "%";
            }
            CalcularInformacoesFinanceiras();
        }
        private void CalcularInformacoesFinanceiras()
        {
            string[] partir_base = baseTextBox.Text.Split('$');
            string[] partir_aicms = icmsTextBox.Text.Split('%');
            string[] partir_aipi = ipiTextBox.Text.Split('%');

            decimal base_custo = Convert.ToDecimal(partir_base[1]);
            decimal aliquota_icms = Convert.ToDecimal(partir_aicms[0]);
            decimal aliquota_ipi = Convert.ToDecimal(partir_aipi[0]);

            decimal ipi = Math.Round(base_custo * aliquota_ipi / 100, 2);
            decimal icms = Math.Round(base_custo * aliquota_icms / 100, 2);
            decimal custo = base_custo  + ipi + icms;

            precoTextBox.Text = custo.ToString("C");
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string[] partir_base = baseTextBox.Text.Split('$');
            string[] partir_aicms = icmsTextBox.Text.Split('%');
            string[] partir_aipi = ipiTextBox.Text.Split('%');
            string[] partir_custo = precoTextBox.Text.Split('$');

            decimal base_custo = Convert.ToDecimal(partir_base[1]);
            decimal aliquota_icms = Convert.ToDecimal(partir_aicms[0]);
            decimal aliquota_ipi = Convert.ToDecimal(partir_aipi[0]);
            decimal preco_custo = Convert.ToDecimal(partir_custo[1]);
            int quantidade = Convert.ToInt32(quantidadeTextBox.Text);

            foreach (PedidoProdutos Produto in pai.Produtos)
            {
                if (Produto.ID_ProdutoVariacao == id_produto)
                {
                    Produto.Preco = preco_custo;
                    Produto.Base_Custo = base_custo;
                    Produto.Aliquota_ICMS = aliquota_icms;
                    Produto.Aliquota_IPI = aliquota_ipi;
                    Produto.Pedido = quantidade;
                }
            }

            pai.alteracao = true;
            Dispose();
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

        private void quantidadeTextBox_Enter(object sender, EventArgs e)
        {
            if (quantidadeTextBox.Text == "0")
                quantidadeTextBox.Text = string.Empty;
        }

        private void quantidadeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void quantidadeTextBox_Leave(object sender, EventArgs e)
        {
            if (quantidadeTextBox.Text == string.Empty)
                quantidadeTextBox.Text = "0";
        }
    }
}
