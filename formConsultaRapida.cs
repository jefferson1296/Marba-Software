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
    public partial class formConsultaRapida : Form
    {
        BindingSource binding = new BindingSource();
        ComandosSQL comandos = new ComandosSQL();
        int id_reparticao;
        int id_produto;

        public formConsultaRapida()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void formConsultaRapida_Load(object sender, EventArgs e)
        {
            List<Reparticao> Reparticoes = comandos.PreencherComboReparticoes();

            comboBoxReparticoes.ValueMember = "ID_Reparticao";
            comboBoxReparticoes.DisplayMember = "Descricao";
            comboBoxReparticoes.DataSource = Reparticoes;

            comboBoxReparticoes.DropDownHeight = 150;

            comboBoxReparticoes.SelectedValue = Program.Computador.ID_Reparticao;

            AtualizarDataGrid();

            dataGridProdutos.CurrentRow.Selected = false;
        }
        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridProdutos.CurrentRow != null)
            {
                primeira_linha = dataGridProdutos.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridProdutos.CurrentRow.Index;
            }

            comandos.ListaDeProdutosParaConsultaRapida(binding, dataGridProdutos);

            try
            {
                dataGridProdutos.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridProdutos.CurrentCell = dataGridProdutos.Rows[linha_selecionada].Cells[0];
            }
            catch { }
            if (dataGridProdutos.CurrentRow != null)
                dataGridProdutos.CurrentRow.Selected = false;
        }
        private void textBoxPesquisa_Enter(object sender, EventArgs e)
        {
            textBoxPesquisa.Text = string.Empty;
            textBoxPesquisa.ForeColor = Color.Black;
            textBoxPesquisa.CharacterCasing = CharacterCasing.Upper;

            if (dataGridProdutos.CurrentRow != null)
                dataGridProdutos.CurrentRow.Selected = false;

            LimparInformacoes();
        }
        private void textBoxPesquisa_Leave(object sender, EventArgs e)
        {
            textBoxPesquisa.CharacterCasing = CharacterCasing.Normal;
            textBoxPesquisa.Text = "Digite aqui para pesquisar";
            textBoxPesquisa.ForeColor = Color.Gray;
        }
        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxPesquisa.Text != "Digite aqui para pesquisar")
                    binding.Filter = "Produto like '%" + textBoxPesquisa.Text + "%'  OR Utensilio like '%" + textBoxPesquisa.Text + "%' OR CONVERT(Codigo, System.String) like '%" + textBoxPesquisa.Text + "%'";
                AtualizarDataGrid();

                if (dataGridProdutos.Rows.Count == 1)
                {
                    id_produto = Convert.ToInt32(dataGridProdutos[0, 0].Value);
                    AtualizarInformacoes();
                }
                else
                {
                    LimparInformacoes();
                }
            }
            catch { }
        }
        private void dataGridProdutos_FilterStringChanged(object sender, EventArgs e)
        {
            binding.Filter = dataGridProdutos.FilterString;
        }
        private void dataGridProdutos_SortStringChanged(object sender, EventArgs e)
        {
            binding.Sort = dataGridProdutos.SortString;
        }
        private void dataGridProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    id_produto = Convert.ToInt32(dataGridProdutos[0, e.RowIndex].Value);
                    AtualizarInformacoes();
                }
            }
            catch { }
        }
        private void buttonConcluir_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void AtualizarInformacoes()
        {
            try
            {
                Produto_Lote Produto = comandos.TrazerInformacoesDaConsultaRapida(id_produto, id_reparticao);

                dataGridProdutos.CurrentRow.Selected = true;

                string produto = Produto.Nome_Produto;
                string codigo = Produto.Cod_Barras;
                int atual = Produto.Qtd_Produtos;
                int local = Produto.Quantidade;
                //string local = Produto.Localizacao;
                decimal venda = Produto.Preco_Venda;

                produtoTextBox.Text = produto;
                codigoTextBox.Text = codigo;
                atualTextBox.Text = atual.ToString();
                localTextBox.Text = local.ToString();
                localizacaoTextBox.Text = " - - - ";
                precoTextBox.Text = venda.ToString("C");
            }
            catch { }
        }

        private void LimparInformacoes()
        {
            produtoTextBox.Clear();
            codigoTextBox.Clear();
            atualTextBox.Clear();
            //lojaTextBox.Clear();
            //estoqueTextBox.Clear();
            localTextBox.Clear();
            localizacaoTextBox.Clear();
            precoTextBox.Clear();
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

        private void comboBoxReparticoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxReparticoes.Text != string.Empty)
            {
                id_reparticao = (int)comboBoxReparticoes.SelectedValue;
                AtualizarInformacoes();
            }
        }
    }
}
