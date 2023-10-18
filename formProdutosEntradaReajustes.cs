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
    public partial class formProdutosEntradaReajustes : Form
    {
        formProdutosEntradaDarEntrada entrada = new formProdutosEntradaDarEntrada();
        formProdutosEntradaAnaliseAvancada analise = new formProdutosEntradaAnaliseAvancada();
        bool analise_avancada;

        int id;
        public formProdutosEntradaReajustes()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }
        public formProdutosEntradaReajustes(formProdutosEntradaDarEntrada Entrada)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            entrada = Entrada;
            analise_avancada = false;
        }
        public formProdutosEntradaReajustes(formProdutosEntradaAnaliseAvancada Analise)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            analise = Analise;
            analise_avancada = true;
        }
        private void formProdutosEntradaReajustes_Load(object sender, EventArgs e)
        {
            PreencherDataGrid();
        }
        private void PreencherDataGrid()
        {
            dataGridViewLista.Rows.Clear();

            if (analise_avancada)
            {
                foreach (ProdutoEntrada Produto in analise.Produtos_Entrada)
                {
                    int id_produto = Produto.ID_Produto;
                    string produto = Produto.Nome_Produto;

                    decimal custo_antigo = analise.Produtos_Fornecedor.Where(x => x.ID_Produto == id_produto).Select(x => x.Preco_Base + (x.Preco_Base / 100 * x.Aliquota_ICMS) + (x.Preco_Base / 100 * x.Aliquota_IPI)).FirstOrDefault();
                    decimal custo_novo = Produto.Preco_Base + (Produto.Preco_Base / 100 * Produto.Aliquota_ICMS) + (Produto.Preco_Base / 100 * Produto.Aliquota_IPI);
                    decimal reajuste = Math.Round(custo_novo - custo_antigo, 2);

                    int id_conjunto = Produto.ID_Conjunto;

                    if (id_conjunto != 0)
                    {
                        produto = Produto.Nome_Conjunto;
                    }

                    if (reajuste != 0)
                    {
                        dataGridViewLista.Rows.Add(id_produto, produto, custo_antigo.ToString("C"), custo_novo.ToString("C"), reajuste.ToString("C"));
                    }
                }
            }
            else
            {
                foreach (ProdutoEntrada Produto in entrada.Produtos_Entrada)
                {
                    int id_produto = Produto.ID_Produto;
                    string produto = Produto.Nome_Produto;

                    decimal custo_antigo = entrada.Produtos_Fornecedor.Where(x => x.ID_Produto == id_produto).Select(x => x.Preco_Base + (x.Preco_Base / 100 * x.Aliquota_ICMS) + (x.Preco_Base / 100 * x.Aliquota_IPI)).FirstOrDefault();
                    decimal custo_novo = Produto.Preco_Base + (Produto.Preco_Base / 100 * Produto.Aliquota_ICMS) + (Produto.Preco_Base / 100 * Produto.Aliquota_IPI);
                    decimal reajuste = Math.Round(custo_novo - custo_antigo, 2);

                    int id_conjunto = Produto.ID_Conjunto;

                    if (id_conjunto != 0)
                    {
                        produto = Produto.Nome_Conjunto;
                    }

                    if (reajuste != 0)
                    {
                        dataGridViewLista.Rows.Add(id_produto, produto, custo_antigo.ToString("C"), custo_novo.ToString("C"), reajuste.ToString("C"));
                    }
                }
            }
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);

                if (analise_avancada)
                {
                    int id_conjunto = analise.Produtos_Entrada.Where(x => x.ID_Produto == id).Select(x => x.ID_Conjunto).FirstOrDefault();

                    if (id_conjunto != 0)
                    {
                        formProdutosEntradaReajustarConjunto reajustar = new formProdutosEntradaReajustarConjunto(analise, id);
                        reajustar.ShowDialog();
                    }
                    else
                    {
                        formProdutosEntradaReajustar reajustar = new formProdutosEntradaReajustar(analise, id);
                        reajustar.ShowDialog();
                    }
                }
                else
                {
                    int id_conjunto = entrada.Produtos_Entrada.Where(x => x.ID_Produto == id).Select(x => x.ID_Conjunto).FirstOrDefault();

                    if (id_conjunto != 0)
                    {
                        formProdutosEntradaReajustarConjunto reajustar = new formProdutosEntradaReajustarConjunto(entrada, id);
                        reajustar.ShowDialog();
                    }
                    else
                    {
                        formProdutosEntradaReajustar reajustar = new formProdutosEntradaReajustar(entrada, id);
                        reajustar.ShowDialog();
                    }
                }

                PreencherDataGrid();
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

        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        dataGridViewLista.CurrentCell = dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dataGridViewLista.Rows[e.RowIndex].Selected = true;
                        dataGridViewLista.Focus();

                        id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    }
                    else
                    {
                        id = 0;
                    }
                }
                catch { }
            }
        }

        private void analisarPrecoDeVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                if (analise_avancada)
                {
                    formProdutosEntradaReajustesVariacoes variacoes = new formProdutosEntradaReajustesVariacoes(analise, id);
                    variacoes.ShowDialog();
                }
                else
                {
                    formProdutosEntradaReajustesVariacoes variacoes = new formProdutosEntradaReajustesVariacoes(entrada, id);
                    variacoes.ShowDialog();
                }

            }
        }
    }
}
