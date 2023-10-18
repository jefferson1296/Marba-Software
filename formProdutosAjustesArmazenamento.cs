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
    public partial class formProdutosAjustesArmazenamento : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Produto> Produtos = new List<Produto>();
        string fornecedor;
        public bool alteracao;
        public formProdutosAjustesArmazenamento()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void formProdutosAjustesArmazenamento_Load(object sender, EventArgs e)
        {
            comboBoxFornecedor.DataSource = comandos.TrazerFornecedoresPorLista();
            comboBoxFornecedor.Update();
        }
        private void comboBoxFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            fornecedor = comboBoxFornecedor.Text;
            AtualizarDataGrid();
        }
        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridArmazenamento.CurrentRow != null)
            {
                primeira_linha = dataGridArmazenamento.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridArmazenamento.CurrentRow.Index;
            }

            dataGridArmazenamento.Rows.Clear();
            Produtos = comandos.PreencherDataGridViewArmazenamento(fornecedor);
            foreach (Produto Produto in Produtos)
            {
                int id_produto = Produto.ID_Produto;
                string produto = Produto.Nome_Produto;

                string local_estoque;
                if (Produto.Local_Estoque == string.Empty) { local_estoque = "- - -"; }
                else { local_estoque = Produto.Local_Estoque; }

                string local_loja;
                if (Produto.Local_Loja == string.Empty) { local_loja = "- - -"; }
                else { local_loja = Produto.Local_Loja; }


                int qtd_caixa = Produto.qtd_Caixa;
                int cmr_estoque = Produto.CMR_Estoque;
                int cmr_loja = Produto.CMR_Loja;
                int ideal_estoque = Produto.Ideal_Estoque;
                int ideal_loja = Produto.Ideal_Loja;


                dataGridArmazenamento.Rows.Add(id_produto, produto, qtd_caixa, cmr_estoque, cmr_loja, local_estoque, local_loja, ideal_estoque, ideal_loja);
            }

            try
            {
                dataGridArmazenamento.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridArmazenamento.CurrentCell = dataGridArmazenamento.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }
        private void dataGridArmazenamento_SortStringChanged(object sender, EventArgs e)
        {
            bindingSource.Sort = dataGridArmazenamento.SortString;
        }
        private void dataGridArmazenamento_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSource.Filter = dataGridArmazenamento.FilterString;
        }
        private void dataGridArmazenamento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridArmazenamento.Rows[e.RowIndex].Cells[e.ColumnIndex] == dataGridArmazenamento.Rows[e.RowIndex].Cells[2])
                {
                    dataGridArmazenamento.CurrentCell = dataGridArmazenamento.CurrentRow.Cells[2];
                }
            }
            catch { }
        }
        private void buttonConcluir_Click(object sender, EventArgs e)
        {
            ComandosSQL comando = new ComandosSQL();
            comando.ConcluirDefinicoesDeArmazenamento(dataGridArmazenamento);
            this.Dispose();
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

        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxPesquisa.Text != "Digite aqui para pesquisar")
                    bindingSource.Filter = "Nome_Produto like '%" + textBoxPesquisa.Text + "%'";
            }
            catch { }
        }
        private void textBoxPesquisa_Enter(object sender, EventArgs e)
        {
            {
                textBoxPesquisa.Text = string.Empty;
                textBoxPesquisa.ForeColor = Color.Black;
                textBoxPesquisa.CharacterCasing = CharacterCasing.Upper;
            }
        }
        private void textBoxPesquisa_Leave(object sender, EventArgs e)
        {
            textBoxPesquisa.CharacterCasing = CharacterCasing.Normal;
            textBoxPesquisa.Text = "Digite aqui para pesquisar";
            textBoxPesquisa.ForeColor = Color.Gray;
        }
        private void dataGridArmazenamento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id_produto = Convert.ToInt32(dataGridArmazenamento.Rows[e.RowIndex].Cells[0].Value);
                formProdutosArmazenamentoEditar editar = new formProdutosArmazenamentoEditar(id_produto, this);
                editar.ShowDialog();
                if (alteracao)
                {
                    alteracao = false;
                    AtualizarDataGrid();
                }
            }
            catch { }
        }

        private void dataGridArmazenamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridArmazenamento.Rows[e.RowIndex].Cells[5].Value.ToString() == "- - -")
            {
                dataGridArmazenamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                dataGridArmazenamento.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Red;
            }
            else if (dataGridArmazenamento.Rows[e.RowIndex].Cells[5].Value.ToString() != "- - -" && dataGridArmazenamento.Rows[e.RowIndex].Cells[6].Value.ToString() == "- - -")
            {
                dataGridArmazenamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Yellow;
                dataGridArmazenamento.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Yellow;
            }
        }
    }
}
