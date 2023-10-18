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
    public partial class formGestaoEstabelecimentosEquipamentos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Equipamento> Equipamentos = new List<Equipamento>();
        int id;
        public formGestaoEstabelecimentosEquipamentos()
        {
            InitializeComponent();
        }

        private void formGestaoEstabelecimentosEquipamentos_Load(object sender, EventArgs e)
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

            Equipamentos = comandos.ListaDeEquipamentos();
            dataGridViewLista.Rows.Clear();

            foreach (Equipamento Equipamento in Equipamentos)
            {
                dataGridViewLista.Rows.Add(Equipamento.ID_Equipamento, Equipamento.Descricao, Equipamento.Categoria);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
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
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o equipamento?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarEquipamento(id);
                    AtualizarDataGrid();
                }
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formGestaoEstabelecimentosEquipamentosAdicionar adicionar = new formGestaoEstabelecimentosEquipamentosAdicionar();
            adicionar.ShowDialog();
            AtualizarDataGrid();
        }
    }
}
