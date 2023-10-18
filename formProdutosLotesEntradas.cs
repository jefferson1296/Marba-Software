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
    public partial class formProdutosLotesEntradas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int registros;
        int id;
        public formProdutosLotesEntradas()
        {
            InitializeComponent();
        }
        private void formProdutosLotesEntradas_Load(object sender, EventArgs e)
        {
            registros = 100;
            dataGridViewLista.AutoGenerateColumns = false;
            AtualizarDataGrid();
        }

        #region Métodos

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            comandos.PreencherDataGridEntradas(dataGridViewLista, binding, registros);

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }

        #endregion

        #region Botões

        private void buttonEntrada_Click(object sender, EventArgs e)
        {
            formProdutoEscolherFornecedor entrada = new formProdutoEscolherFornecedor();
            entrada.ShowDialog();
            AtualizarDataGrid();
        }

        private void buttonAjuste_Click(object sender, EventArgs e)
        {
            formProdutosLotesEntradasAjuste ajuste = new formProdutosLotesEntradasAjuste();
            ajuste.ShowDialog();
            AtualizarDataGrid();
        }

        #endregion

        #region Filtro

        private void dataGridViewLista_FilterStringChanged(object sender, EventArgs e)
        {
            binding.Filter = dataGridViewLista.FilterString;
        }

        private void dataGridViewLista_SortStringChanged(object sender, EventArgs e)
        {
            binding.Sort = dataGridViewLista.SortString;
        }

        #endregion

        #region Funções do DataGrid

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
                        string status = dataGridViewLista.Rows[e.RowIndex].Cells[6].Value.ToString();

                        if (status == "Confirmado")
                        {
                            confirmarRecebimentoToolStripMenuItem.Enabled = false;
                        }
                        else
                        {
                            confirmarRecebimentoToolStripMenuItem.Enabled = true;
                        }
                    }
                    else
                    {
                        id = 0;
                    }
                }
                catch { }
            }
        }

        #endregion

        private void confirmarRecebimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.ConfirmarProdutosRecebidosAPartirDaEntrada(id);

                AtualizarDataGrid();
            }
        }

        private void textBoxRegistros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void buttonRegistros_Click(object sender, EventArgs e)
        {
            registros = Convert.ToInt32(textBoxRegistros.Text);
            AtualizarDataGrid();
        }

        private void textBoxRegistros_Enter(object sender, EventArgs e)
        {
            if (textBoxRegistros.Text == "0")
                textBoxRegistros.Clear();
        }

        private void textBoxRegistros_Leave(object sender, EventArgs e)
        {
            if (textBoxRegistros.Text == string.Empty)
                textBoxRegistros.Text = "1";
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    formProdutosLotesEntradasProdutos produtos = new formProdutosLotesEntradasProdutos(id);
                    produtos.ShowDialog();
                }
                else
                {
                    id = 0;
                }
            }
            catch { id = 0; }
        }

        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewLista[6, e.RowIndex].Value.ToString() == "Confirmado")
            {
                DataGridViewRow linhaestilizada = dataGridViewLista.Rows[e.RowIndex];
                linhaestilizada.DefaultCellStyle.ForeColor = Color.DarkGray;
                linhaestilizada.DefaultCellStyle.SelectionForeColor = Color.DarkGray;
            }
        }

        private void excluirLoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Todos os produtos referentes à esse lote serão apagados permanentemente.\r\nEsta ação não pode ser revertida e poderá trazer danos permanentes ao histórico e outras funcionalidades do programa.\r\n\r\nDeseja continuar mesmo assim?","Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
                {
                    comandos.ApagarEntradaEProdutosDaEntrada(id);
                    AtualizarDataGrid();
                }
            }
        }
    }
}
