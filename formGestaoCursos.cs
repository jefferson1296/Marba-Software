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
    public partial class formGestaoCursos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        BindingSource binding = new BindingSource();
        int id;

        public formGestaoCursos()
        {
            InitializeComponent();
        }

        private void formGestaoTreinamentos_Load(object sender, EventArgs e)
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

            comandos.ListaDeCursos(dataGridViewLista, binding);

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formGestaoCursosAdicionar adicionar = new formGestaoCursosAdicionar();
            adicionar.ShowDialog();
            AtualizarDataGrid();
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                formGestaoCursosAdicionar adicionar = new formGestaoCursosAdicionar(id);
                adicionar.ShowDialog();
                AtualizarDataGrid();
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

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("O curso será excluído permanentemente.\r\nDeseja continuar mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarCurso(id);
                    AtualizarDataGrid();
                }
            }
        }

        private void buttonSessoes_Click(object sender, EventArgs e)
        {
            formGestaoCursosTreinamentosSessoes sessoes = new formGestaoCursosTreinamentosSessoes();
            sessoes.ShowDialog();
        }

        private void treinamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                formGestaoCursosTreinamentosAdicionar adicionar = new formGestaoCursosTreinamentosAdicionar(id);
                adicionar.ShowDialog();
            }
        }
    }
}
