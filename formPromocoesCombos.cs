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
    public partial class formPromocoesCombos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Combo> combos = new List<Combo>();
        int id;

        public formPromocoesCombos()
        {
            InitializeComponent();
        }

        private void buttonCombo_Click(object sender, EventArgs e)
        {
            formPromocoesCriarCombo combo = new formPromocoesCriarCombo();
            combo.ShowDialog();
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

            combos = comandos.TrazerCombos();
            dataGridViewLista.Rows.Clear();

            foreach (Combo combo in combos)
            {
                dataGridViewLista.Rows.Add(combo.ID_Combo, combo.Descricao, combo.Multiplicador, combo.Preco.ToString("C"), combo.Inicio.ToShortDateString(), combo.Termino.ToShortDateString());
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

        private void formPromocoesCombos_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
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

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.ApagarCombo(id);
                AtualizarDataGrid();
            }
        }
    }
}
