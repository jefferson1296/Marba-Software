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
    public partial class formVendasCaixasAnteriores : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formVendas pai = new formVendas();
        int id;

        public formVendasCaixasAnteriores()
        {
            InitializeComponent();
        }
        public formVendasCaixasAnteriores(formVendas Pai)
        {
            InitializeComponent();
            pai = Pai;
        }

        private void formVendasCaixasAnteriores_Load(object sender, EventArgs e)
        {
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

            comandos.PreencherDataGridCaixasAnteriores(dataGridViewLista, bindingSource);

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }

        private void textBoxPesquisa_Enter(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text == "Digite o número do caixa")
            {
                textBoxPesquisa.Text = string.Empty;
            }
            textBoxPesquisa.ForeColor = Color.Black;
        }
        private void textBoxPesquisa_Leave(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text == string.Empty)
            {
                textBoxPesquisa.Text = "Digite o número do caixa";
                textBoxPesquisa.ForeColor = Color.DarkGray;
            }
        }
        private void textBoxPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text != "Digite o número do caixa")
                bindingSource.Filter = "CONVERT(ID_Caixa, System.String) like '%" + textBoxPesquisa.Text + "%'";
        }

        private void panelBarra_Resize(object sender, EventArgs e)
        {
            labelVendas.Left = (panelBarra.Width / 2) - (labelVendas.Width / 2);
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dataGridViewLista["id_caixa", e.RowIndex].Value);
                DateTime data = Convert.ToDateTime(dataGridViewLista["data", e.RowIndex].Value);
                string colaborador = dataGridViewLista["colaborador", e.RowIndex].Value.ToString();

                formVendasCaixasAnterioresVendas caixa = new formVendasCaixasAnterioresVendas(id, colaborador, data);
                caixa.ShowDialog();
            }
            catch { }
        }

        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string status = dataGridViewLista["status", e.RowIndex].Value.ToString();
            decimal quebra = comandos.ConverterDinheiroEmDecimal(dataGridViewLista["quebra", e.RowIndex].Value.ToString());

            if (status == "Aberto")
            {
                dataGridViewLista[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.DarkGray;
                dataGridViewLista[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.DarkGray;
            }

            Font minha_fonte = new Font("Arial", dataGridViewLista.Font.Size, FontStyle.Bold, GraphicsUnit.Point);

            if (quebra < 0)
            {
                dataGridViewLista["quebra", e.RowIndex].Style.ForeColor = Color.Red;
                dataGridViewLista["quebra", e.RowIndex].Style.SelectionForeColor = Color.DarkRed;
            }
            else if (quebra > 0)
            {
                dataGridViewLista["quebra", e.RowIndex].Style.ForeColor = Color.LimeGreen;
                dataGridViewLista["quebra", e.RowIndex].Style.SelectionForeColor = Color.DarkGreen;
            }
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

        private void dataGridViewLista_SortStringChanged(object sender, EventArgs e)
        {
            bindingSource.Filter = dataGridViewLista.FilterString;
        }

        private void dataGridViewLista_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSource.Filter = dataGridViewLista.FilterString;
        }

        private void apagarVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("O caixa e todas as suas vendas registradas\r\n serão apagados permanentemente.\r\n\r\nDeseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    comandos.ApagarCaixaETodasAsSuasVendas(id);
                    AtualizarDataGrid();
                }
            }
        }

        private void fecharCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                formVendasCaixaFecharCaixa fecharCaixa = new formVendasCaixaFecharCaixa(id);
                fecharCaixa.ShowDialog();
                AtualizarDataGrid();
            }
        }
    }
}
