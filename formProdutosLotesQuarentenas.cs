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
    public partial class formProdutosLotesQuarentenas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Quarentena> Quarentenas = new List<Quarentena>();
        int id;

        public formProdutosLotesQuarentenas()
        {
            InitializeComponent();
        }

        private void formProdutosLotesQuarentenas_Load(object sender, EventArgs e)
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
            Quarentenas = comandos.ListaDeQuarentenas();

            foreach (Quarentena quarentena in Quarentenas)
            {
                dataGridViewLista.Rows.Add(quarentena.ID_Quarentena, quarentena.ID_Lote, quarentena.Descricao, quarentena.Status);
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

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    formProdutosLotesQuarentenasProdutos produtos = new formProdutosLotesQuarentenasProdutos(id);
                    produtos.ShowDialog();
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
                if (e.RowIndex >= 0)
                {
                    id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                }
                else
                {
                    id = 0;
                }
            }
        }

        private void imprimirListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.ImprimirListaDeQuarentena(id);
            }
        }
    }
}
