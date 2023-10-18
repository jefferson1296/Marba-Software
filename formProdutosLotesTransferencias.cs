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
    public partial class formProdutosLotesTransferencias : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int registros;
        int id;
        public formProdutosLotesTransferencias()
        {
            InitializeComponent();
        }

        private void formProdutosLotesTransferencias_Load(object sender, EventArgs e)
        {
            registros = 100;
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

            comandos.PreencherDataGridTransferencias(dataGridViewLista, binding, registros);

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }

        private void buttonTransferencia_Click(object sender, EventArgs e)
        {
            formProdutosLotesTransferenciasTransferir transferencia = new formProdutosLotesTransferenciasTransferir();
            transferencia.ShowDialog();
            AtualizarDataGrid();
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

        private void buttonDirecionamento_Click(object sender, EventArgs e)
        {
            formProdutosLotesTransferenciasDirecionamentos direcionamentos = new formProdutosLotesTransferenciasDirecionamentos();
            direcionamentos.ShowDialog();
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    formProdutosLotesTransferenciasProdutos produtos = new formProdutosLotesTransferenciasProdutos(id);
                    produtos.ShowDialog();
                }
                else
                {
                    id = 0;
                }
            }
            catch { id = 0; }
        }
    }
}
