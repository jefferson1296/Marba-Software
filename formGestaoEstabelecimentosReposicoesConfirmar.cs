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
    public partial class formGestaoEstabelecimentosReposicoesConfirmar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<ProdutoReposicao> produtos = new List<ProdutoReposicao>();
        Reposicao reposicao = new Reposicao();

        public formGestaoEstabelecimentosReposicoesConfirmar()
        {
            InitializeComponent();
        }

        public formGestaoEstabelecimentosReposicoesConfirmar(Reposicao Reposicao)
        {
            InitializeComponent();
            reposicao = Reposicao;
        }

        private void formGestaoEstabelecimentosReposicoesConfirmar_Load(object sender, EventArgs e)
        {
            reposicaoTextBox.Text = reposicao.ID_Reposicao.ToString();
            textBoxDescricao.Text = reposicao.Descricao;

            AtualizarDataGrid();

            foreach (DataGridViewColumn coluna in dataGridViewLista.Columns)
            {
                if (coluna.Index != 5)
                {
                    coluna.ReadOnly = true;
                }
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

            produtos = comandos.ListaDeProdutosParaConfirmarReposicao(reposicao.ID_Reposicao);
            dataGridViewLista.Rows.Clear();

            foreach (ProdutoReposicao Reposicao in produtos)
            {
                dataGridViewLista.Rows.Add(Reposicao.ID_ProdutoVariacao, Reposicao.Nome_Produto, Reposicao.Local_Origem, Reposicao.Local_Destino, Reposicao.Quantidade, 0);
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

        private void dataGridViewLista_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void dataGridViewLista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    if (dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    {
                        dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    }

                    int id_produto = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    int quantidade = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[5].Value);

                    foreach (ProdutoReposicao Produto in produtos)
                    {
                        if (Produto.ID_ProdutoVariacao == id_produto)
                        {
                            Produto.Confirmacao = quantidade;
                        }
                    }
                }
            }
            catch { }
        }

        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                //dataGridViewLista.Rows[e.RowIndex].Cells[5].Style.BackColor = Color.SlateGray;
                //dataGridViewLista.Rows[e.RowIndex].Cells[5].Style.SelectionForeColor = Color.WhiteSmoke;
                //dataGridViewLista.Rows[e.RowIndex].Cells[5].Style.SelectionBackColor = Color.MidnightBlue;
            }
        }

        private void dataGridViewLista_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewLista.IsCurrentCellDirty)
            {
                dataGridViewLista.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            bool confirmar = false;
            int alterados = produtos.Where(x => x.Quantidade != x.Confirmacao).Count();
            int confirmados = produtos.Where(x => x.Quantidade == x.Confirmacao).Count();
            int total = produtos.Count;

            if (confirmados != total)
            {
                string texto;
                if (alterados == 1) { texto = "O sistema identificou que " + alterados.ToString() + " produto está com a quantidade diferente da solicitada.\r\nDeseja continuar mesmo assim?"; }
                else { texto = "O sistema identificou que " + alterados.ToString() + " produtos estão com a quantidade diferente da solicitada.\r\nDeseja continuar mesmo assim?"; }

                if (DialogResult.Yes == MessageBox.Show(texto, "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    confirmar = true;
                }
            }
            else
            {
                string texto = "Todos os produtos foram confirmados.\r\nDeseja continuar?";
                if (DialogResult.Yes == MessageBox.Show(texto, "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    confirmar = true;
                }
            }

            if (confirmar)
            {
                string status;
                if (reposicao.Tipo == "Abastecimento") { status = "Direcionamento"; }
                else { status = "Exposto"; }

                comandos.ConfirmarReposicao(produtos, status, reposicao.ID_Reposicao);
                Dispose();
            }
        }
    }
}
