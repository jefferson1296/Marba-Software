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
    public partial class formVendasPDVDescontoProduto : Form
    {
        ProdutoVenda produto = new ProdutoVenda();
        List<ProdutoVenda> lista = new List<ProdutoVenda>();
        List<ProdutoVenda> listaIndividual = new List<ProdutoVenda>();
        formVendasPDV pdv = new formVendasPDV();

        decimal preco;
        decimal desconto;
        bool desconto_percentual = false;

        public formVendasPDVDescontoProduto()
        {
            InitializeComponent();
        }
        public formVendasPDVDescontoProduto(formVendasPDV PDV, ProdutoVenda Produto)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);

            produto = Produto;
            pdv = PDV;
        }
        private void formVendasPDVDescontoProduto_Load(object sender, EventArgs e)
        {
            textBoxProduto.Text = produto.Produto;

            foreach (ProdutoVenda produto in pdv.pai.Produtos)
            {
                if (produto.Codigo == this.produto.Codigo)
                {
                    lista.Add(new ProdutoVenda()
                    {
                        Tipo = produto.Tipo,
                        Produto = produto.Produto,
                        Codigo = produto.Codigo,
                        Quantidade = produto.Quantidade,
                        Preco = produto.Preco,
                        Total = produto.Total,
                        Desconto = produto.Desconto,
                        Subtotal = produto.Subtotal
                    });
                }
            }

            AtualizarLista();
        }
        private void AtualizarLista()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            dataGridViewLista.Rows.Clear();

            foreach (ProdutoVenda produto in lista)
            {
                decimal percentual = (produto.Desconto * 100) / produto.Preco;
                string tipo;
                if (produto.Promocao) { tipo = "Promoção"; }
                { tipo = "Padrão"; }

                if (produto.Codigo == this.produto.Codigo)
                {
                    dataGridViewLista.Rows.Add(tipo, produto.Quantidade, produto.Subtotal, percentual.ToString("F"), produto.Desconto.ToString("F"), produto.Total.ToString("F"));
                }
            }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;

            decimal total = lista.Sum(i => i.Total);
            int quantidade_produtos = lista.Sum(i => i.Quantidade);
            decimal desconto = lista.Sum(i => i.Desconto);
            decimal subtotal = lista.Sum(i => i.Subtotal);

            decimal preco = lista.Select(i => i.Subtotal).FirstOrDefault();

            try
            {
                    textBoxPreco.Text = preco.ToString("F");
                    textBoxQtd.Text = quantidade_produtos.ToString();

                    textBoxTotal.Text = total.ToString("C");
                    labelDesconto.Text = desconto.ToString("C");
                    labelSubtotal.Text = subtotal.ToString("C");

                    textBoxDesconto.Text = ((desconto * 100) / total).ToString("F");
            }
            catch { }
        }
        private void buttonAplicar_Click(object sender, EventArgs e)
        {
            decimal desconto = lista.Select(i => i.Desconto).FirstOrDefault();
            decimal subtotal = lista.Select(i => i.Subtotal).FirstOrDefault();
            decimal total = lista.Select(i => i.Total).FirstOrDefault();

            foreach (ProdutoVenda linha in pdv.pai.Produtos)
            {
                if (linha.Codigo == produto.Codigo)
                {
                    linha.Desconto = desconto;
                    linha.Subtotal = subtotal;
                    linha.Total = total;
                }
            }

            pdv.AtualizarDataGrid();
            Dispose();
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        #region Formatação de Texto
        private void textBoxQtd_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBoxQtd_Enter(object sender, EventArgs e)
        {
            if (textBoxQtd.Text == "0")
                textBoxQtd.Text = string.Empty;
        }
        private void textBoxQtd_Leave(object sender, EventArgs e)
        {

        }
        #endregion

        private void textBoxDesconto_Leave(object sender, EventArgs e)
        {
            desconto_percentual = true;

            if (textBoxDesconto.Text == string.Empty)
            {
                textBoxDesconto.Text = "0,00";
            }
            else
            {
                decimal percentual = Convert.ToDecimal(textBoxDesconto.Text);
                textBoxDesconto.Text = percentual.ToString("F");
            }
        }
        private void textBoxPreco_Leave(object sender, EventArgs e)
        {
            desconto_percentual = false;
            if (textBoxPreco.Text == string.Empty)
            {
                textBoxPreco.Text = "0,00";

            }
            else
            {
                decimal percentual = Convert.ToDecimal(textBoxPreco.Text);
                textBoxPreco.Text = percentual.ToString("F");
            }
        }
        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            if (desconto_percentual)
            {
                try
                {
                    desconto = Convert.ToDecimal(textBoxDesconto.Text);
                }
                catch { desconto = 0; }

                textBoxDesconto.Text = desconto.ToString("F");

                foreach (ProdutoVenda produto in lista)
                {
                    decimal valor = lista.Select(i => i.Preco).FirstOrDefault();

                    produto.Desconto = desconto * valor / 100;
                    produto.Total = produto.Subtotal - produto.Desconto;
                }

                AtualizarLista();
            }
            else
            {


                try
                {
                    preco = Convert.ToDecimal(textBoxPreco.Text);
                }
                catch { preco = 0; }

                textBoxPreco.Text = preco.ToString("F");

                foreach (ProdutoVenda produto in lista)
                {
                    produto.Total = preco;
                    produto.Desconto = produto.Subtotal - produto.Total;
                }

                AtualizarLista();
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

        private void textBoxDesconto_Enter(object sender, EventArgs e)
        {
            if (textBoxDesconto.Text == "0,00")
                textBoxDesconto.Clear();
        }

        private void textBoxDesconto_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!textBoxDesconto.Text.Contains(','))
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

        private void textBoxPreco_Enter(object sender, EventArgs e)
        {
            if (textBoxPreco.Text == "0,00")
                textBoxPreco.Clear();
        }

        private void textBoxPreco_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!textBoxPreco.Text.Contains(','))
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

        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString() == "Promoção")
            {
                dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Gray;
                dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.Gray;
            }
            else
            {
                dataGridViewLista.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.WhiteSmoke;
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.WhiteSmoke;
                dataGridViewLista.Rows[e.RowIndex].Cells[5].Style.BackColor = Color.WhiteSmoke;
            }
        }
    }
}
