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
    public partial class formProdutosAjustesBalanço : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Balanco> Produtos = new List<Balanco>();
        string setor;
        bool fechar;

        public formProdutosAjustesBalanço()
        {
            InitializeComponent();
        }
        public formProdutosAjustesBalanço(string Setor)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            setor = Setor;
        }
        private void formProdutosAjustesBalanço_Load(object sender, EventArgs e)
        {
            textBoxSetor.Text = setor;
            fechar = checkBoxFechar.Checked;
            //List<string> Fornecedores = comandos.preencherComboFornecedores();
            //foreach (string fornecedor in Fornecedores) { comboBoxFornecedor.Items.Add(fornecedor); }
            textBoxPesquisa.AutoCompleteCustomSource = comandos.ListaDeProdutos();
            foreach(DataGridViewColumn Coluna in dataGridViewLista.Columns)
            {
                if (Coluna.Index != 3)
                {
                    dataGridViewLista.Columns[Coluna.Index].ReadOnly = true;
                }
            }
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
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

        private void buttonAplicar_Click(object sender, EventArgs e)
        {
            string fornecedor = comboBoxFornecedor.Text;
            if (fornecedor == string.Empty)
            {
                MessageBox.Show("É necessário informar o fornecedor para inserir os produtos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                List<Balanco> produtos_do_fornecedor = comandos.TrazerProdutosParaBalanco(fornecedor, setor);
                foreach (Balanco Produto in produtos_do_fornecedor)
                {
                    string nome_sistema = Produto.Nome_Sistema;

                    if (Produtos.Any(x => x.Nome_Sistema == nome_sistema))
                    {
                        MessageBox.Show("O produto informado já consta na lista!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        Produtos.Add(Produto);
                    }
                }
                AtualizarDataGrid();
            }
        }

        private void textBoxPesquisa_Leave(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text == string.Empty)
            {
                textBoxPesquisa.CharacterCasing = CharacterCasing.Normal;
                textBoxPesquisa.ForeColor = Color.Gray;
            }

            string produto = textBoxPesquisa.Text;
            if (textBoxPesquisa.Text != string.Empty)
            {
                try
                {
                    string produto_pelo_codigo = string.Empty; //comandos.pesquisarProdutoPeloCodigo(textBoxPesquisa.Text);
                    
                    if (produto_pelo_codigo != string.Empty)
                        produto = produto_pelo_codigo;

                    textBoxPesquisa.Text = produto;
                }
                catch { }
            }
        }

        private void textBoxPesquisa_Enter(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text == "Digite o nome do produto")
            {
                textBoxPesquisa.CharacterCasing = CharacterCasing.Upper;
                textBoxPesquisa.Text = string.Empty;
                textBoxPesquisa.ForeColor = Color.Black;
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            string produto = textBoxPesquisa.Text;

            int quantidade = 0;
            try { quantidade = Convert.ToInt32(textBoxQuantidade.Text); } catch { }

            if (produto == string.Empty)
            {
                MessageBox.Show("Informe o nome do produto para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxPesquisa.Focus();
            }
            else if (!comandos.VerificarProdutoPeloNomeDoSistema(produto))
            {
                MessageBox.Show("O nome informado não foi encontrado.\r\nVerifique se o produto existe e está ativo no momento.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (textBoxQuantidade.Text == string.Empty)
            {
                MessageBox.Show("Informe a quantidade para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (Produtos.Any(x => x.Nome_Sistema == produto))
            {
                MessageBox.Show("O produto informado já consta na lista!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Balanco Balanco = comandos.TrazerInformacoesDoProduto(produto, setor);
                Balanco.Quantidade = quantidade;

                Produtos.Add(Balanco);
                AtualizarDataGrid();
                textBoxPesquisa.Clear();
                textBoxPesquisa.Focus();
                textBoxQuantidade.Clear();
            }
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
            foreach (Balanco Produto in Produtos)
            {
                dataGridViewLista.Rows.Add(Produto.Codigo, Produto.Nome_Sistema, Produto.Quantidade_Atual, Produto.Quantidade);
            }

            textBoxProdutos.Text = Produtos.Count.ToString();

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
                dataGridViewLista.CurrentRow.Selected = false;
            }
            catch { }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (Produtos.Count == 0)
            {
                MessageBox.Show("Adicione produtos para concluir o balanço.", "Nenhum produto encontrado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (DialogResult.Yes == MessageBox.Show("O balanço poderá interferir nas reposições automáticas.\r\nTem certeza que deseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                comandos.ConcluirBalanco(setor, Produtos);
                if (fechar)
                {
                    Dispose();
                }
                else
                {
                    Produtos.Clear();
                    AtualizarDataGrid();
                }
            }
        }

        #region Tratamento do DataGridView

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (e.RowIndex % 2 == 0)
                {
                    dataGridViewLista.Rows[e.RowIndex].Cells[3].Style.SelectionBackColor = Color.White;
                }
                else
                {
                    dataGridViewLista.Rows[e.RowIndex].Cells[3].Style.SelectionBackColor = Color.WhiteSmoke;
                }
            }
        }

        private void dataGridViewLista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    if (dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    {
                        dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    }

                    string produto = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();
                    int quantidade = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[3].Value);

                    foreach (Balanco Produto in Produtos)
                    {
                        if (Produto.Nome_Sistema == produto) { Produto.Quantidade = quantidade; }
                    }
                }
            }
            catch { }
        }

        private void dataGridViewLista_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }
        }

        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex] == dataGridViewLista.Rows[e.RowIndex].Cells[4])
                {
                    string produto = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Produtos.RemoveAll(x => x.Nome_Sistema == produto);
                    AtualizarDataGrid();
                    int quantidade = Convert.ToInt32(textBoxProdutos.Text) - 1;
                    textBoxProdutos.Text = Convert.ToString(quantidade);
                }
            }
            catch { }
        }
        #endregion

        private void formProdutosAjustesBalanço_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !dataGridViewLista.Focused)
            {
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void dataGridViewLista_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            Produtos.Clear();
            AtualizarDataGrid();
        }

        private void checkBoxFechar_CheckedChanged(object sender, EventArgs e)
        {
            fechar = checkBoxFechar.Checked;
        }

        private void textBoxQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void formProdutosAjustesBalanço_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (buttonAdicionar.Focused == true)
                {
                    buttonAdicionar_Click(sender, e);
                    e.Handled = true;
                }
                else
                {
                    ProcessTabKey(true);
                    e.Handled = true;
                }
            }
        }

        private void textBoxQuantidade_Leave(object sender, EventArgs e)
        {
            if (textBoxQuantidade.Text == string.Empty)
                textBoxQuantidade.Text = "0";
        }

        private void textBoxQuantidade_Enter(object sender, EventArgs e)
        {
            if (textBoxQuantidade.Text == "0")
                textBoxQuantidade.Text = string.Empty;
        }
    }
}
