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
    public partial class formProdutosLotesTransferenciasDirecionamentos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Direcionamento> direcionamentos = new List<Direcionamento>();
        int id;
        string status;

        public formProdutosLotesTransferenciasDirecionamentos()
        {
            InitializeComponent();
        }

        private void formProdutosLotesDirecionamentos_Load(object sender, EventArgs e)
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

            dataGridViewLista.Rows.Clear();

            direcionamentos = comandos.ListadeDirecionamentos();

            foreach (Direcionamento direcionamento in direcionamentos)
            {
                dataGridViewLista.Rows.Add(direcionamento.ID_Direcionamento, direcionamento.Colaborador, direcionamento.Registro.ToShortDateString(), direcionamento.Status);
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

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    status = dataGridViewLista.Rows[e.RowIndex].Cells[3].Value.ToString();
                    if (status != "Pendente") { concluirToolStripMenuItem.Enabled = false; }
                    else { concluirToolStripMenuItem.Enabled = true; }
                }
            }
        }

        private void concluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja concluir o direcionamento " + id + "?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ConcluirDirecionamento(id);
                }
            }
        }

        private void imprimirListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.ImprimirListaDeDirecionamento(id);
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formProdutosLotesTransferenciasDirecionamentosAdicionar adicionar = new formProdutosLotesTransferenciasDirecionamentosAdicionar();
            adicionar.ShowDialog();
            AtualizarDataGrid();
        }
    }
}
