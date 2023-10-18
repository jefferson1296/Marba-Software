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
    public partial class formProdutosEditarVariacoes : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public bool cadastramento;
        public bool alteracao;
        public formProdutosCadastrar form_cadastrar;
        public formProdutosEditar form_editar;

        int id;

        public List<Produto_Variacao> Variacoes = new List<Produto_Variacao>();
        Produto produto;


        public formProdutosEditarVariacoes()
        {
            InitializeComponent();
        }
        public formProdutosEditarVariacoes(formProdutosCadastrar Form_Cadastrar, Produto Produto)
        {
            InitializeComponent();
            form_cadastrar = Form_Cadastrar;
            cadastramento = true;
            produto = Produto;
        }
        public formProdutosEditarVariacoes(formProdutosEditar Form_Editar, Produto Produto)
        {
            InitializeComponent();
            form_editar = Form_Editar;
            cadastramento = false;
            produto = Produto;
        }

        private void formProdutosEditarVariacoes_Load(object sender, EventArgs e)
        {
            textBoxID.Text = produto.ID_Produto.ToString();
            textBoxNome.Text = produto.Nome_Produto;

            if (cadastramento)
            {
                formProdutosEditarVariacoesCadastrar cadastrar = new formProdutosEditarVariacoesCadastrar(this, produto.ID_Produto);
                cadastrar.ShowDialog();
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

            Variacoes = comandos.TrazerVariacoesDoProduto(produto.ID_Produto);

            dataGridViewLista.Rows.Clear();

            foreach(Produto_Variacao Variacao in Variacoes)
            {
                string produto = Variacao.Nome_Produto;
                string cor = Variacao.Cor;
                string estampa = Variacao.Estampa;

                if (cor != "SORTIDO" && estampa == "SEM ESTAMPA") { produto = produto + " " + cor; }
                else if (cor == "SORTIDO" && estampa != "SEM ESTAMPA") { produto = produto + " " + estampa; }
                else if (cor != "SORTIDO" && estampa != "SEM ESTAMPA") { produto = produto + " " + cor + " " + estampa; }

                dataGridViewLista.Rows.Add(Variacao.ID_ProdutoVariacao, produto, Variacao.Cod_Barras, Variacao.Ativacao, Variacao.Disponibilidade);
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

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formProdutosEditarVariacoesCadastrar cadastrar = new formProdutosEditarVariacoesCadastrar(this, produto.ID_Produto);
            cadastrar.ShowDialog();
            AtualizarDataGrid();
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                Produto_Variacao Variacao = Variacoes.Where(x => x.ID_ProdutoVariacao == id).FirstOrDefault();
                formProdutosEditarVariacoesCadastrar cadastrar = new formProdutosEditarVariacoesCadastrar(this, Variacao);
                cadastrar.ShowDialog();
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

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.ApagarVariacaoDoProduto(id);
                AtualizarDataGrid();
            }
        }
    }
}
