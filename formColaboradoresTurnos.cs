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
    public partial class formColaboradoresTurnos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Turno> Turnos = new List<Turno>();

        public formColaboradoresTurnos()
        {
            InitializeComponent();
        }

        private void formTelaInicialEscalaTurnos_Load(object sender, EventArgs e)
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

            Turnos = comandos.ListaDeTurnos();

            dataGridViewLista.Rows.Clear();
            foreach (Turno Turno in Turnos)
            {
                dataGridViewLista.Rows.Add(Turno.ID_Turno, Turno.Descricao);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                string turno = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();

                formColaboradoresTurnosAdicionar adicionar = new formColaboradoresTurnosAdicionar(id, turno);
                adicionar.ShowDialog();
                AtualizarDataGrid();
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formColaboradoresTurnosAdicionar adicionar = new formColaboradoresTurnosAdicionar();
            adicionar.ShowDialog();
            AtualizarDataGrid();
        }
    }
}
