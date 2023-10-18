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
    public partial class formCatalogoTransformacoes : Form
    {
        List<Catalogo> Produtos = new List<Catalogo>();
        ComandosSQL comandos = new ComandosSQL();

        int id;
        int id_catalogo;
        string status;

        public formCatalogoTransformacoes()
        {
            InitializeComponent();
        }

        private void formCatalogoTransformacoes_Load(object sender, EventArgs e)
        {
            dataGridViewLista.AutoGenerateColumns = false;
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

            Produtos = comandos.ProdutosDoCatalogoParaTransformacao();
            comandos.PreencherDataGridTransformacoes(binding, dataGridViewLista);

            //dataGridViewLista.Rows.Clear();

            //foreach (Catalogo Produto in Produtos)
            //{
            //    int id = Produto.ID_ProdutoVariacao;
            //    string produto = Produto.Nome_Produto;

            //    decimal preco_base = Produto.Preco_Base;
            //    decimal ipi = preco_base / 100 * Produto.Aliquota_IPI;
            //    decimal icms = preco_base / 100 * Produto.Aliquota_ICMS;
            //    decimal custo = preco_base + ipi + icms;

            //    string cor = Produto.Cor;
            //    string estampa = Produto.Estampa;
            //    string fabricante = Produto.Fabricante;

            //    if (cor != "SORTIDO" && estampa == "SEM ESTAMPA") { produto = produto + " " + cor; }
            //    else if (cor == "SORTIDO" && estampa != "SEM ESTAMPA") { produto = produto + " " + estampa; }
            //    else if (cor != "SORTIDO" && estampa != "SEM ESTAMPA") { produto = produto + " " + cor + " " + estampa; }

            //    dataGridViewLista.Rows.Add(fabricante, id, Produto.Utensilio, produto, custo.ToString("C"));
            //}

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }

        private void buttonCapsula_Click(object sender, EventArgs e)
        {
            formCatalogoCapsulasAdicionar adicionar = new formCatalogoCapsulasAdicionar();
            adicionar.ShowDialog();
        }

        private void buttonCapsulas_Click(object sender, EventArgs e)
        {
            formCatalogoCapsulas capsulas = new formCatalogoCapsulas();
            capsulas.ShowDialog();
        }

        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Font minhafonte = new Font("Arial", 9, FontStyle.Strikeout, GraphicsUnit.Point);
            Font minhafonte2 = new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Point);

            int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells["ID_Produto"].Value);
            string status = Produtos.Where(x => x.ID_ProdutoVariacao == id).Select(x => x.Status).FirstOrDefault();       

            DataGridViewRow linhaestilizada = dataGridViewLista.Rows[e.RowIndex];

            if (status == "Descartado")
            {
                linhaestilizada.DefaultCellStyle.Font = minhafonte;
                linhaestilizada.DefaultCellStyle.ForeColor = Color.Red;
                linhaestilizada.DefaultCellStyle.SelectionForeColor = Color.Red;
            }
            else if (status == "Provisório")
            {
                linhaestilizada.DefaultCellStyle.ForeColor = Color.Black;
                linhaestilizada.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
            else if (status == "Catalogado")
            {
                linhaestilizada.DefaultCellStyle.Font = minhafonte2;
                linhaestilizada.DefaultCellStyle.ForeColor = Color.RoyalBlue;
                linhaestilizada.DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.ApagarProdutoDoCatalogoPeloIdDaVariacao(id);
                AtualizarDataGrid();
            }
        }

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridViewLista.CurrentCell = dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dataGridViewLista.Rows[e.RowIndex].Selected = true;
                    dataGridViewLista.Focus();

                    id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells["ID_Produto"].Value);

                    id_catalogo = Produtos.Where(x => x.ID_ProdutoVariacao == id).Select(x => x.ID_Catalogo).FirstOrDefault();
                    status = Produtos.Where(x => x.ID_ProdutoVariacao == id).Select(x => x.Status).FirstOrDefault();

                    if (status == "Provisório")
                    {
                        editarCatalogoToolStripMenuItem.Visible = true;                        
                    }
                    else { editarCatalogoToolStripMenuItem.Visible = false; }

                    if (comandos.VerificarSeProdutoEstaNaPromocao(id))
                    {
                        promoçaoToolStripMenuItem.Visible = true;
                    }
                    else { promoçaoToolStripMenuItem.Visible = false; }
                }
                else
                {
                    id = 0;
                }
            }
            catch { }
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridViewLista.CurrentCell = dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dataGridViewLista.Rows[e.RowIndex].Selected = true;
                    dataGridViewLista.Focus();

                    id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells["ID_Produto"].Value);
                    id_catalogo = Produtos.Where(x => x.ID_ProdutoVariacao == id).Select(x => x.ID_Catalogo).FirstOrDefault();
                    status = Produtos.Where(x => x.ID_ProdutoVariacao == id).Select(x => x.Status).FirstOrDefault();

                    if (status == "Provisório")
                    {
                        formCatalogoTransformacoesCapsulas capsulas = new formCatalogoTransformacoesCapsulas(id_catalogo);
                        capsulas.ShowDialog();
                        AtualizarDataGrid();
                    }
                    else if (status == "Catalogado")
                    {
                        formCatalogoCapsulasAdicionarProdutosAdicionar transformar = new formCatalogoCapsulasAdicionarProdutosAdicionar(id_catalogo);
                        transformar.ShowDialog();
                        AtualizarDataGrid();
                    }
                }
                else
                {
                    id = 0;
                }
            }
            catch { }
        }

        private void catalogarTemporariamenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.CatalogarOProdutoPeloIdDaVariacao(id);
                AtualizarDataGrid();
            }
        }

        private void textBoxPesquisa_Enter(object sender, EventArgs e)
        {
            textBoxPesquisa.Text = string.Empty;
            textBoxPesquisa.ForeColor = Color.Black;
            textBoxPesquisa.CharacterCasing = CharacterCasing.Upper;
        }

        private void textBoxPesquisa_Leave(object sender, EventArgs e)
        {
            textBoxPesquisa.CharacterCasing = CharacterCasing.Normal;
            textBoxPesquisa.Text = "Digite aqui para pesquisar";
            textBoxPesquisa.ForeColor = Color.Gray;
        }

        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text != "Digite aqui para pesquisar")
                binding.Filter = "Produto like '%" + textBoxPesquisa.Text + "%'";
        }

        private void dataGridViewLista_SortStringChanged(object sender, EventArgs e)
        {
            binding.Sort = dataGridViewLista.SortString;
        }

        private void dataGridViewLista_FilterStringChanged(object sender, EventArgs e)
        {
            binding.Filter = dataGridViewLista.FilterString;
        }

        private void editarProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                int id_produto = Produtos.Where(x => x.ID_ProdutoVariacao == id).Select(x => x.ID_Produto).FirstOrDefault();
                formProdutosEditar editar = new formProdutosEditar(id_produto, "Produto");
                editar.ShowDialog();
                AtualizarDataGrid();
            }
        }

        private void apagarProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                int id_produto = Produtos.Where(x => x.ID_ProdutoVariacao == id).Select(x => x.ID_Produto).FirstOrDefault();

                if (comandos.QuantidadeDeProdutosEmEstoque(id_produto) > 0)
                {
                    MessageBox.Show("Não é possível apagar produtos que tem quantidade em estoque!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (comandos.QuantidadeDeVariacoesDoProduto(id_produto) > 1)
                {
                    MessageBox.Show("Não é possível apagar produtos com mais de uma variação.\r\nApague as variações para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o produto?\r\nSe você continuar, o produto e suas variações serão excluídos permanentemente.", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarProduto(id_produto);
                    AtualizarDataGrid();
                }
            }
        }

        private void editarCatalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_catalogo != 0)
            {
                formCatalogoCapsulasAdicionarProdutosAdicionar transformar = new formCatalogoCapsulasAdicionarProdutosAdicionar(id_catalogo);
                transformar.ShowDialog();
                AtualizarDataGrid();
            }
        }

        private void imagensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_catalogo != 0)
            {
                Catalogo produto = comandos.InformacoesDoProdutoDoCatalogo(id_catalogo);
                formCatalogoImagens imagens = new formCatalogoImagens(produto);
                imagens.ShowDialog();
                AtualizarDataGrid();
            }
        }

        private void promoçaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                formCatalogoTransformacoesPromocoes promocoes = new formCatalogoTransformacoesPromocoes(id);
                promocoes.ShowDialog();

                AtualizarDataGrid();
            }
        }
    }
}
