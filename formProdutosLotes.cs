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
    public partial class formProdutosLotes : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id_lote;
        int id_produto;
        string produto;
        string localizacao;
        string status;
        int quantidade;

        int registros;
        bool mostrar_tudo;

        public formProdutosLotes()
        {
            InitializeComponent();
        }

        private void formProdutosLotes_Load(object sender, EventArgs e)
        {
            mostrar_tudo = false;
            registros = 100;
            textBoxRegistros.Text = registros.ToString();
            AtualizarDataGrid();

            dataGridProdutos.AutoGenerateColumns = false;
        }

        public void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridProdutos.CurrentRow != null)
            {
                primeira_linha = dataGridProdutos.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridProdutos.CurrentRow.Index;
            }

            comandos.PreencherDataGridLotes(dataGridProdutos, tblProdutosBindingSource, mostrar_tudo, registros);

            try
            {
                dataGridProdutos.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridProdutos.CurrentCell = dataGridProdutos.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridProdutos.CurrentRow != null)
                dataGridProdutos.CurrentRow.Selected = false;
        }

        #region Pesquisa de Produtos
        private void textBoxPesquisa_Enter(object sender, EventArgs e)
        {
            textBoxPesquisa.Text = string.Empty;
            textBoxPesquisa.ForeColor = Color.Firebrick;
            textBoxPesquisa.CharacterCasing = CharacterCasing.Upper;

            if (dataGridProdutos.CurrentRow != null)
                dataGridProdutos.CurrentRow.Selected = false;
        }

        private void textBoxPesquisa_Leave(object sender, EventArgs e)
        {
            textBoxPesquisa.CharacterCasing = CharacterCasing.Normal;
            textBoxPesquisa.Text = "Digite aqui para pesquisar";
            textBoxPesquisa.ForeColor = Color.IndianRed;
        }

        private void dataGridProdutos_FilterStringChanged(object sender, EventArgs e)
        {
            tblProdutosBindingSource.Filter = dataGridProdutos.FilterString;
        }

        private void dataGridProdutos_SortStringChanged(object sender, EventArgs e)
        {
            tblProdutosBindingSource.Sort = dataGridProdutos.SortString;
        }

        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text != "Digite aqui para pesquisar" && textBoxPesquisa.Text != string.Empty)
            {
                tblProdutosBindingSource.Filter = "Produto like '%" + textBoxPesquisa.Text + "%' OR Fornecedor like '%" + textBoxPesquisa.Text + "%' OR Cod_Barras like '%" + textBoxPesquisa.Text + "%' OR CONVERT(ID_Lote, System.String) like '%" + textBoxPesquisa.Text + "%' OR Localizacao like '%" + textBoxPesquisa.Text + "%'";
            }
        }

        private void textBoxPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tblProdutosBindingSource.Filter = "Produto like '%" + textBoxPesquisa.Text + "%' OR Fornecedor like '%" + textBoxPesquisa.Text + "%' OR Cod_Barras like '%" + textBoxPesquisa.Text + "%' OR CONVERT(ID_Lote, System.String) like '%" + textBoxPesquisa.Text + "%' OR Localizacao like '%" + textBoxPesquisa.Text + "%'";
            }
        }
        #endregion

        private void buttonTransferencias_Click(object sender, EventArgs e)
        {
            formProdutosLotesTransferencias transferencias = new formProdutosLotesTransferencias();
            transferencias.ShowDialog();
            AtualizarDataGrid();
        }

        private void buttonEntradas_Click(object sender, EventArgs e)
        {
            formProdutosLotesEntradas entradas = new formProdutosLotesEntradas();
            entradas.ShowDialog();
            AtualizarDataGrid();
        }

        private void buttonSaidas_Click(object sender, EventArgs e)
        {
            formProdutosLotesSaidas saidas = new formProdutosLotesSaidas();
            saidas.ShowDialog();
            AtualizarDataGrid();
        }

        private void buttonPecas_Click(object sender, EventArgs e)
        {
            formProdutosPecas pecas = new formProdutosPecas();
            pecas.ShowDialog();
        }

        private void buttonUnidades_Click(object sender, EventArgs e)
        {
            formProdutosSobrando sobrando = new formProdutosSobrando();
            sobrando.ShowDialog();
        }

        private void buttonTrocados_Click(object sender, EventArgs e)
        {
            formProdutosTrocados trocados = new formProdutosTrocados();
            trocados.ShowDialog();
        }

        private void buttonPedidos_Click(object sender, EventArgs e)
        {
            formFornecedoresPedido pedidos = new formFornecedoresPedido();
            pedidos.ShowDialog();
        }

        private void buttonPrateleiras_Click(object sender, EventArgs e)
        {
            formProdutosAjustesPrateleiras prateleiras = new formProdutosAjustesPrateleiras();
            prateleiras.ShowDialog();
        }

        private void dataGridProdutos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        id_lote = Convert.ToInt32(dataGridProdutos.Rows[e.RowIndex].Cells[0].Value);
                        id_produto = Convert.ToInt32(dataGridProdutos.Rows[e.RowIndex].Cells[1].Value);
                        produto = dataGridProdutos.Rows[e.RowIndex].Cells[3].Value.ToString();
                        string[] prateleira = dataGridProdutos.Rows[e.RowIndex].Cells[6].Value.ToString().Split(' ');
                        localizacao = prateleira[0];
                        status = dataGridProdutos.Rows[e.RowIndex].Cells[7].Value.ToString();
                        quantidade = Convert.ToInt32(dataGridProdutos.Rows[e.RowIndex].Cells[4].Value);
                    }
                }
                catch
                {
                    id_lote = 0;
                    id_produto = 0;
                    produto = string.Empty;
                    status = string.Empty;
                }
            }
        }

        private void historicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formProdutosLotesHistorico historico = new formProdutosLotesHistorico(id_lote, id_produto, produto); ;
            historico.ShowDialog();
        }

        private void buttonQuarentena_Click(object sender, EventArgs e)
        {
            formProdutosLotesQuarentenas quarentenas = new formProdutosLotesQuarentenas();
            quarentenas.ShowDialog();
            AtualizarDataGrid();
        }

        private void avariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_lote != 0)
            {
                Produto_Lote Produto = new Produto_Lote { Nome = produto, ID_Lote = id_lote, ID_ProdutoVariacao = id_produto, Status = status, Localizacao = localizacao, Quantidade = quantidade };
                formProdutosLotesAvarias avarias = new formProdutosLotesAvarias(Produto);
                avarias.ShowDialog();
                AtualizarDataGrid();
            }
        }

        private void extravioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_lote != 0)
            {
                Produto_Lote Produto = new Produto_Lote { Nome = produto, ID_Lote = id_lote, ID_ProdutoVariacao = id_produto, Status = status, Localizacao = localizacao, Quantidade = quantidade };
                formProdutosLotesExtravios extravios = new formProdutosLotesExtravios(Produto);
                extravios.ShowDialog();
                AtualizarDataGrid();
            }
        }

        private void dataGridProdutos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Font minhafonte = new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Point);
            Font minhafonte2 = new Font("Arial", 9, FontStyle.Strikeout, GraphicsUnit.Point);

            string status = dataGridProdutos.Rows[e.RowIndex].Cells[7].Value.ToString();

            if (status == "Avariado")
            {
                DataGridViewRow linhaestilizada = dataGridProdutos.Rows[e.RowIndex];
                linhaestilizada.DefaultCellStyle.Font = minhafonte;
                linhaestilizada.DefaultCellStyle.ForeColor = Color.DarkRed;
                linhaestilizada.DefaultCellStyle.SelectionForeColor = Color.DarkRed;
            }
            else if (status == "Extraviado")
            {
                DataGridViewRow linhaestilizada = dataGridProdutos.Rows[e.RowIndex];
                linhaestilizada.DefaultCellStyle.Font = minhafonte2;
                linhaestilizada.DefaultCellStyle.ForeColor = Color.DarkGray;
                linhaestilizada.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
            else if (status == "Vendido")
            {
                DataGridViewRow linhaestilizada = dataGridProdutos.Rows[e.RowIndex];
                linhaestilizada.DefaultCellStyle.Font = minhafonte;
                linhaestilizada.DefaultCellStyle.ForeColor = Color.MidnightBlue;
                linhaestilizada.DefaultCellStyle.SelectionForeColor = Color.MidnightBlue;
            }
        }

        private void buttonSaida_Click(object sender, EventArgs e)
        {
            formProdutosLotesSaida saidas = new formProdutosLotesSaida();
            saidas.ShowDialog();
            AtualizarDataGrid();
        }

        private void buttonAcabamentos_Click(object sender, EventArgs e)
        {
            formProdutosAcabamentos acabamentos = new formProdutosAcabamentos();
            acabamentos.ShowDialog();
        }

        private void buttonExibir_Click(object sender, EventArgs e)
        {
            mostrar_tudo = false;
            registros = Convert.ToInt32(textBoxRegistros.Text);
            AtualizarDataGrid();
        }

        private void textBoxRegistros_Enter(object sender, EventArgs e)
        {
            if (textBoxRegistros.Text == "0")
            {
                textBoxRegistros.Text = string.Empty;
            }
        }

        private void textBoxRegistros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void textBoxRegistros_Leave(object sender, EventArgs e)
        {
            if (textBoxRegistros.Text == string.Empty)
            {
                textBoxRegistros.Text = registros.ToString();
            }
        }

        private void buttonTodos_Click(object sender, EventArgs e)
        {
            mostrar_tudo = true;
            AtualizarDataGrid();
        }

        private void localizarQuantidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_produto != 0)
            {
                formProdutosQuantidades editar = new formProdutosQuantidades(id_produto, "Variação");
                editar.ShowDialog();
            }
        }
    }
}
