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
    public partial class formCatalogoCapsulasAdicionarProdutosAdicionarLocalizacoes : Form
    {
        formCatalogoCapsulasAdicionarProdutosAdicionar pai = new formCatalogoCapsulasAdicionarProdutosAdicionar();
        public List<ProdutoLocalizacao> Localizacoes = new List<ProdutoLocalizacao>();

        int id_catalogo;
        ComandosSQL comandos = new ComandosSQL();
        string prateleira;

        public formCatalogoCapsulasAdicionarProdutosAdicionarLocalizacoes()
        {
            InitializeComponent();
        }
        public formCatalogoCapsulasAdicionarProdutosAdicionarLocalizacoes(formCatalogoCapsulasAdicionarProdutosAdicionar Pai, int ID_Catalogo)
        {
            InitializeComponent();
            id_catalogo = ID_Catalogo;
            pai = Pai;
        }
        private void formUtensiliosCapsulasAdicionarProdutosAdicionarLocalizacoes_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void AtualizarDataGrid()
        {
            prateleira = string.Empty;

            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            dataGridViewLista.Rows.Clear();

            Localizacoes = comandos.LocalizacoesDoProdutoDoCatalogo(id_catalogo);

            foreach (ProdutoLocalizacao localizacao in Localizacoes)
            {
                dataGridViewLista.Rows.Add(localizacao.Localizacao, localizacao.Reparticao, localizacao.Reparticao_Origem, localizacao.Qtd_Ideal, localizacao.CMR);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formCatalogoCapsulasAdicionarProdutosAdicionarLocalizacoesAdicionar adicionar = new formCatalogoCapsulasAdicionarProdutosAdicionarLocalizacoesAdicionar(id_catalogo);
            adicionar.ShowDialog();
            AtualizarDataGrid();
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    prateleira = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();

                    formCatalogoCapsulasAdicionarProdutosAdicionarLocalizacoesAdicionar editar = new formCatalogoCapsulasAdicionarProdutosAdicionarLocalizacoesAdicionar(prateleira, id_catalogo);
                    editar.ShowDialog();
                    AtualizarDataGrid();
                }
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

                        prateleira = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                    }
                    else
                    {
                        prateleira = string.Empty;
                    }
                }
                catch { }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (prateleira != string.Empty)
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar a localização do produto?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarLocalizacaoDoProduto(prateleira, id_catalogo);
                    AtualizarDataGrid();
                }
            }
        }
    }
}
