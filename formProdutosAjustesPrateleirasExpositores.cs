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
    public partial class formProdutosAjustesPrateleirasExpositores : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Expositor> Expositores = new List<Expositor>();
        int id;

        public formProdutosAjustesPrateleirasExpositores()
        {
            InitializeComponent();
        }

        private void formProdutosAjustesPrateleirasExpositores_Load(object sender, EventArgs e)
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

            Expositores = comandos.ListaDeExpositores();
            dataGridViewLista.Rows.Clear();

            foreach (Expositor Expositor in Expositores)
            {
                dataGridViewLista.Rows.Add(Expositor.ID_Expositor, Expositor.Imagem, Expositor.Descricao, Expositor.Detalhes);
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
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o expositor?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarExpositor(id);
                    AtualizarDataGrid();
                }
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formProdutosAjustesPrateleirasExpositoresAdicionar adicionar = new formProdutosAjustesPrateleirasExpositoresAdicionar();
            adicionar.ShowDialog();
            AtualizarDataGrid();
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                Expositor expositor = Expositores.Where(x => x.ID_Expositor == id).FirstOrDefault();
                formProdutosAjustesPrateleirasExpositoresAdicionar editar = new formProdutosAjustesPrateleirasExpositoresAdicionar(expositor);
                editar.ShowDialog();
                AtualizarDataGrid();
            }
        }
    }
}
