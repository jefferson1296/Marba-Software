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
    public partial class formProdutosLotesSaidas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int registros;
        int id;

        public formProdutosLotesSaidas()
        {
            InitializeComponent();
        }

        private void formProdutosLotesSaidas_Load(object sender, EventArgs e)
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

            comandos.PreencherDataGridSaidas(dataGridViewLista, binding, registros);

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
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
    }
}
