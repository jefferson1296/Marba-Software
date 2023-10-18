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
    public partial class formProdutosAjustesPrateleirasArmazenamentos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Armazenamento> Armazenamentos = new List<Armazenamento>();
        int id;

        public formProdutosAjustesPrateleirasArmazenamentos()
        {
            InitializeComponent();
        }

        private void formProdutosAjustesPrateleirasArmazenamentos_Load(object sender, EventArgs e)
        {
            dataGridViewLista.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewLista.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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

            Armazenamentos = comandos.ListaDeArmazenamentos();
            dataGridViewLista.Rows.Clear();

            foreach (Armazenamento Armazenamento in Armazenamentos)
            {
                dataGridViewLista.Rows.Add(Armazenamento.ID_Armazenamento, Armazenamento.Descricao, Armazenamento.Detalhes);
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
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o armazenamento?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarArmazenamento(id);
                    AtualizarDataGrid();
                }
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formProdutosAjustesPrateleirasArmazenamentosAdicionar adicionar = new formProdutosAjustesPrateleirasArmazenamentosAdicionar();
            adicionar.ShowDialog();
            AtualizarDataGrid();
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                Armazenamento armazenamento = Armazenamentos.Where(x => x.ID_Armazenamento == id).FirstOrDefault();
                formProdutosAjustesPrateleirasArmazenamentosAdicionar editar = new formProdutosAjustesPrateleirasArmazenamentosAdicionar(armazenamento);
                editar.ShowDialog();
                AtualizarDataGrid();
            }
        }
    }
}
