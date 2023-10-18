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
    public partial class formFornecedoresPedidoConfirmar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formFornecedoresPedidoEmAberto pai = new formFornecedoresPedidoEmAberto();
        public List<PedidoProdutos> Produtos = new List<PedidoProdutos>();
        public bool alteracao;
        Pedido pedido = new Pedido();
        int ID_Produto;
        public formFornecedoresPedidoConfirmar()
        {
            InitializeComponent();
        }

        public formFornecedoresPedidoConfirmar(Pedido Pedido, formFornecedoresPedidoEmAberto Pai)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            pedido = Pedido;
            pai = Pai;
        }

        private void formFornecedoresPedidoConfirmar_Load(object sender, EventArgs e)
        {
            int id_pedido = pedido.ID_Pedido;
            Produtos = comandos.ListaDeProdutosParaConfirmacao(id_pedido);
            AtualizarDataGrid();
        }

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            dataGridViewLista.Rows.Clear();

            foreach (PedidoProdutos Produto in Produtos)
            {
                int id_produto = Produto.ID_ProdutoVariacao;
                string produto = Produto.Produto;
                decimal preco_base = Produto.Base_Custo;
                decimal ipi = Produto.Aliquota_IPI;
                decimal icms = Produto.Aliquota_ICMS;
                decimal custo = Produto.Preco;
                int quantidade = Produto.Pedido;
                string cod_extra = Produto.Codigo;
                bool confirmacao = Produto.Confirmacao;

                dataGridViewLista.Rows.Add(id_produto, cod_extra, produto, preco_base.ToString("C"), ipi + "%", icms + "%", custo.ToString("C"), quantidade, confirmacao);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
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

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try { ID_Produto = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value); }
            catch { ID_Produto = 0; }

            if (ID_Produto != 0)
            {
                formFornecedoresPedidoConfirmarProduto produto = new formFornecedoresPedidoConfirmarProduto(this, ID_Produto);
                produto.ShowDialog();
                if (alteracao)
                {
                    alteracao = false;
                    AtualizarDataGrid();
                }
            }
        }

        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                int id_produto = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                bool confirmacao = Produtos.Where(x => x.ID_ProdutoVariacao == id_produto).Select(x => x.Confirmacao).FirstOrDefault();

                if (confirmacao)
                {
                    foreach (PedidoProdutos Produto in Produtos)
                    {
                        if (Produto.ID_ProdutoVariacao == id_produto)
                            Produto.Confirmacao = false;
                    }
                }
                else
                {
                    foreach (PedidoProdutos Produto in Produtos)
                    {
                        if (Produto.ID_ProdutoVariacao == id_produto)
                            Produto.Confirmacao = true;
                    }
                }

                AtualizarDataGrid();
            }
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            pai.alteracao = true;
            pai.Produtos = Produtos;
            Dispose();
        }
    }
}
