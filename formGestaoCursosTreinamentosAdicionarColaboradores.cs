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
    public partial class formGestaoCursosTreinamentosAdicionarColaboradores : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        int id_curso;

        BindingSource binding = new BindingSource();
        formGestaoCursosTreinamentosAdicionar pai = new formGestaoCursosTreinamentosAdicionar();

        public formGestaoCursosTreinamentosAdicionarColaboradores()
        {
            InitializeComponent();
        }     
        
        public formGestaoCursosTreinamentosAdicionarColaboradores(int ID_Curso, formGestaoCursosTreinamentosAdicionar Pai)
        {
            InitializeComponent();
            id_curso = ID_Curso;
            pai = Pai;
        }

        private void formGestaoCursosTreinamentosAdicionarColaboradores_Load(object sender, EventArgs e)
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

            comandos.PossiveisParticipantesDoTreinamento(dataGridViewLista, binding, id_curso);

            foreach (DataGridViewRow linha in dataGridViewLista.Rows)
            {
                int id = Convert.ToInt32(dataGridViewLista.Rows[linha.Index].Cells[1].Value);

                if (pai.colaboradores.Contains(id))
                {
                    dataGridViewLista.Rows[linha.Index].Cells[0].Value = true;
                }
                else
                {
                    dataGridViewLista.Rows[linha.Index].Cells[0].Value = false;
                }
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }

        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ColumnIndex.ToString());
            //MessageBox.Show(dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[1].Value);

                    if (Convert.ToBoolean(dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                    {
                        dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        pai.colaboradores.Remove(id);
                    }
                    else
                    {
                        dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                        pai.colaboradores.Add(id);
                    }

                    AtualizarDataGrid();
                }

            }
        }

        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dataGridViewLista_FilterStringChanged(object sender, EventArgs e)
        {
            binding.Filter = dataGridViewLista.FilterString;
        }

        private void dataGridViewLista_SortStringChanged(object sender, EventArgs e)
        {
            binding.Sort = dataGridViewLista.SortString;
        }
    }
}
