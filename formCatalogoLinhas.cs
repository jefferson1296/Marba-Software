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
    public partial class formCatalogoLinhas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Linha> Linhas = new List<Linha>();
        int id;

        public formCatalogoLinhas()
        {
            InitializeComponent();
        }

        private void formCatalogoLinhas_Load(object sender, EventArgs e)
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

            Linhas = comandos.ListaDeLinhasDeProdutos();

            dataGridViewLista.Rows.Clear();

            foreach (Linha Linha in Linhas)
            {
                dataGridViewLista.Rows.Add(Linha.ID_Linha, Linha.Descricao, Linha.Marketing, Linha.Lucro.ToString("F") + "%", Linha.Markup.ToString("F"), Linha.Ativacao);
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
            try
            {
                if (e.RowIndex >= 0)
                {
                    id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    Linha linha = Linhas.Where(x => x.ID_Linha == id).FirstOrDefault();

                    formCatalogoLinhasAdicionar adicionar = new formCatalogoLinhasAdicionar(linha);
                    adicionar.ShowDialog();
                    AtualizarDataGrid();
                }
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
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar a linha?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarLinha(id);
                    AtualizarDataGrid();
                }
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formCatalogoLinhasAdicionar adicionar = new formCatalogoLinhasAdicionar();
            adicionar.ShowDialog();
            AtualizarDataGrid();
        }
    }
}
