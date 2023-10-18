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
    public partial class formGestaoFerramentasPlanos : Form
    {
        List<Projeto> planos = new List<Projeto>();
        ComandosSQL comandos = new ComandosSQL();
        int id;

        public formGestaoFerramentasPlanos()
        {
            InitializeComponent();
        }

        private void formGestaoPlanosDeAcao_Load(object sender, EventArgs e)
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

            planos = comandos.ListaDePlanosDeAcao();

            dataGridViewLista.Rows.Clear();


            foreach (Projeto plano in planos)
            {
                dataGridViewLista.Rows.Add(plano.ID_Projeto, plano.Descricao, plano.Onde, plano.Colaborador);
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

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formGestaoFerramentasPlanosAdicionar projeto = new formGestaoFerramentasPlanosAdicionar();
            projeto.ShowDialog();
            AtualizarDataGrid();
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    id = Convert.ToInt32(dataGridViewLista[0, e.RowIndex].Value);
                    formGestaoFerramentasPlanosAdicionar projeto = new formGestaoFerramentasPlanosAdicionar(id);
                    projeto.ShowDialog();
                    AtualizarDataGrid();
                }
            }
            catch
            {
                id = 0;
            }
        }

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    id = Convert.ToInt32(dataGridViewLista[0, e.RowIndex].Value);
                }
                catch
                {
                    id = 0;
                }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("O plano de ação será apagado permanentemente.\r\nDeseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarPlanoDeAcao(id);
                    AtualizarDataGrid();
                }
            }
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.ImprimirPlanoDeAcao(id, true);
            }
        }

        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.ImprimirPlanoDeAcao(id, false);
            }
        }
    }
}
