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
    public partial class formProdutosEditarVariacoesFornecedores : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<string> Fornecedores = new List<string>();
        formProdutosEditarVariacoesCadastrar pai = new formProdutosEditarVariacoesCadastrar();

        string fornecedor;

        public formProdutosEditarVariacoesFornecedores()
        {
            InitializeComponent();
        }
        public formProdutosEditarVariacoesFornecedores(formProdutosEditarVariacoesCadastrar Pai)
        {
            InitializeComponent();
            pai = Pai;
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void formProdutosEditarProdutosFornecedores_Load(object sender, EventArgs e)
        {
            comboBoxFornecedor.DropDownHeight = 150;
            AtualizarComboBoxFornecedores();

            AtualizarLista();
        }

        private void AtualizarComboBoxFornecedores()
        {

            List<string> fornecedores_disponiveis = comandos.preencherComboFornecedores();
            AutoCompleteStringCollection colecao = new AutoCompleteStringCollection();

            foreach (string fornecedor in fornecedores_disponiveis) 
            { 
                comboBoxFornecedor.Items.Add(fornecedor);
                colecao.Add(fornecedor);
            }

            comboBoxFornecedor.AutoCompleteCustomSource = colecao;
        }

        private void buttonFornecedor_Click(object sender, EventArgs e)
        {
            formFornecedoresCadastrar fornecedor = new formFornecedoresCadastrar();
            fornecedor.ShowDialog();

            AtualizarLista();
        }
        private void salvarButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #region DataGridView

        private void AtualizarLista()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            dataGridViewLista.Rows.Clear();

            if (pai.variacao.Fornecedores.Count == 0) { labelRegistros.Visible = true; }
            else { labelRegistros.Visible = false; }

            foreach (Fornecedor Fornecedor in pai.variacao.Fornecedores)
            {
                dataGridViewLista.Rows.Add(Fornecedor.Nome_Fornecedor, Fornecedor.Ativacao, Fornecedor.Disponibilidade);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }

        #endregion

        #region Movimentacao do Formulário

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

                        fornecedor = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                    }
                    else
                    {
                        fornecedor = string.Empty;
                    }
                }
                catch { }

            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fornecedor != string.Empty)
            {
                pai.variacao.Fornecedores.RemoveAll(x => x.Nome_Fornecedor == fornecedor);
                AtualizarLista();
            }
        }

        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string fornecedor = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                bool ativacao = Convert.ToBoolean(dataGridViewLista.Rows[e.RowIndex].Cells[1].Value);

                dataGridViewLista.Rows[e.RowIndex].Cells[1].Value = !ativacao;

                foreach (Fornecedor Fornecedor in pai.variacao.Fornecedores)
                {
                    if (Fornecedor.Nome_Fornecedor == fornecedor)
                    {
                        Fornecedor.Ativacao = !ativacao;
                    }
                }
            }

            if (e.ColumnIndex == 2)
            {
                string fornecedor = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                bool disponibilidade = Convert.ToBoolean(dataGridViewLista.Rows[e.RowIndex].Cells[2].Value);

                dataGridViewLista.Rows[e.RowIndex].Cells[2].Value = !disponibilidade;

                foreach (Fornecedor Fornecedor in pai.variacao.Fornecedores)
                {
                    if (Fornecedor.Nome_Fornecedor == fornecedor)
                    {
                        Fornecedor.Disponibilidade = !disponibilidade;
                    }
                }
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            string fornecedor = comboBoxFornecedor.Text;

            if (fornecedor == string.Empty)
            {
                MessageBox.Show("Informe o fornecedor para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!comandos.VerificarSeFornecedorJaExiste(fornecedor))
            {
                MessageBox.Show("Informe um fornecedor válido para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (pai.variacao.Fornecedores.Any(x => x.Nome_Fornecedor == fornecedor))
            {
                MessageBox.Show("Esse fornecedor já consta na lista!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                pai.variacao.Fornecedores.Add(new Fornecedor { Nome_Fornecedor = fornecedor, Ativacao = true, Disponibilidade = true });
                AtualizarLista();
                comboBoxFornecedor.SelectedIndex = -1;
            }
        }
    }
}
