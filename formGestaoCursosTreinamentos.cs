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
    public partial class formGestaoCursosTreinamentos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Treinamento> treinamentos = new List<Treinamento>();
        BindingSource binding = new BindingSource();

        int id;

        public formGestaoCursosTreinamentos()
        {
            InitializeComponent();
        }

        private void formGestaoCursosTreinamentos_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
            dataGridViewLista.AutoGenerateContextFilters = false;
        }

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            comandos.ListaDeTreinamentos(dataGridViewLista, binding);

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }

        private void buttonCursos_Click(object sender, EventArgs e)
        {
            formGestaoCursos cursos = new formGestaoCursos();
            cursos.ShowDialog();
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

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("O treinamento será excluído permanentemente.\r\nDeseja continuar mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarTreinamento(id);
                    AtualizarDataGrid();
                }
            }
        }
    }
}
