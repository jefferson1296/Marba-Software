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
    public partial class formGestaoConfiguracaoesAbreviacoes : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Abreviacao> Abreviacoes = new List<Abreviacao>();
        int id;

        public formGestaoConfiguracaoesAbreviacoes()
        {
            InitializeComponent();
        }

        private void formGestaoConfiguracaoesAbreviacoes_Load(object sender, EventArgs e)
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

            Abreviacoes = comandos.ListaDeAbreviacoes();
            dataGridViewLista.Rows.Clear();

            foreach (Abreviacao Abreviacao in Abreviacoes)
            {
                dataGridViewLista.Rows.Add(Abreviacao.ID_Abreviacao, Abreviacao.Texto, Abreviacao.Descricao);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formGestaoConfiguracaoesAbreviacoesAdicionar adicionar = new formGestaoConfiguracaoesAbreviacoesAdicionar();
            adicionar.ShowDialog();
            AtualizarDataGrid();
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

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);

                if (id != 0)
                {
                    Abreviacao abreviacao = Abreviacoes.Where(x => x.ID_Abreviacao == id).FirstOrDefault();
                    formGestaoConfiguracaoesAbreviacoesAdicionar alterar = new formGestaoConfiguracaoesAbreviacoesAdicionar(abreviacao);
                    alterar.ShowDialog();
                    AtualizarDataGrid();
                }
            }
            catch { }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar a abreviação?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarAbreviacao(id);
                    AtualizarDataGrid();
                }
            }
        }
    }
}
