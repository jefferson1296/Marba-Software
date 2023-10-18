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
    public partial class formCatalogoCapsulasAdicionarProdutos : Form
    {
        int id_catalogo;
        int id_capsula;
        Produto_Variacao produto;
        bool cadastramento;
        ComandosSQL comandos = new ComandosSQL();

        List<Catalogo> Produtos = new List<Catalogo>();

        public formCatalogoCapsulasAdicionarProdutos(int ID_Capsula)
        {
            InitializeComponent();

            id_capsula = ID_Capsula;
            cadastramento = false;
        }

        public formCatalogoCapsulasAdicionarProdutos(Produto_Variacao Produto, int ID_Capsula)
        {
            InitializeComponent();

            produto = Produto;

            id_capsula = ID_Capsula;
            cadastramento = true;
        }

        private void formUtensilioCapsulaProdutos_Load(object sender, EventArgs e)
        {
            if (cadastramento)
            {
                formCatalogoCapsulasAdicionarProdutosAdicionar adicionar = new formCatalogoCapsulasAdicionarProdutosAdicionar(produto, id_capsula);
                adicionar.ShowDialog();                
            }

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

            Produtos = comandos.ListaDeProdutosCatalogadosDaCapsula(id_capsula);

            foreach (Catalogo Produto in Produtos)
            {
                dataGridViewLista.Rows.Add(Produto.ID_Catalogo, Produto.Nome, Produto.Fabricante, Produto.Preco_Venda.ToString("C"), Produto.Ativacao, Produto.Disponibilidade);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }
        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_catalogo = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                formCatalogoCapsulasAdicionarProdutosAdicionar editar = new formCatalogoCapsulasAdicionarProdutosAdicionar(id_catalogo);
                editar.ShowDialog();
                AtualizarDataGrid();
            }
            catch { }
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

                        id_catalogo = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    }
                    else
                    {
                        id_catalogo = 0;
                    }
                }
                catch { }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_catalogo != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("O produto será excluído do catálogo.\r\nTem certeza que deseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarProdutoDoCatalogo(id_catalogo);
                    AtualizarDataGrid();
                }
            }
        }

        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_catalogo = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);

                if (e.ColumnIndex == 4)
                {
                    bool ativacao = Convert.ToBoolean(dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                    dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !ativacao;
                    comandos.AlterarAtivacaoDoProdutoNoCatalogo(id_catalogo);

                    if (!ativacao)
                    {
                        MessageBox.Show("O produto foi ativado e relacionado ao catálogo.", "Produto ativado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("O produto foi desativado.\r\nEssa variação não será relacionada ao catálogo e os seus pedidos automáticos foram desativados.", "Desativado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (e.ColumnIndex == 5)
                {
                    bool disponibilidade = Convert.ToBoolean(dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                    dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !disponibilidade;
                    comandos.AlterarDisponibilidadeDoProdutoNoCatalogo(id_catalogo);

                    if (!disponibilidade)
                    {
                        MessageBox.Show("Produto disponível.", "Disponível", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("O produto está indisponível.\r\nÉ necessário substituí-lo o quanto antes.", "Indisponível", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch { }
        }
    }
}
