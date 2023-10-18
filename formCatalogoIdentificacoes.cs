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
    public partial class formCatalogoIdentificacoes : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Identificacao> Identificacoes = new List<Identificacao>();
        int id;
        public formCatalogoIdentificacoes()
        {
            InitializeComponent();
        }

        private void formPrateleirasIdentificacoes_Load(object sender, EventArgs e)
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

            Identificacoes = comandos.ListaDeIdentificacoes();
            dataGridViewLista.Rows.Clear();

            foreach (Identificacao Identificacao in Identificacoes)
            {
                dataGridViewLista.Rows.Add(Identificacao.ID_Identificacao, Identificacao.Descricao, Identificacao.Setor, Identificacao.Auto_Impressao);
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
            formCatalogoIdentificacoesAdicionar adicionar = new formCatalogoIdentificacoesAdicionar();
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
                    formCatalogoIdentificacoesAdicionar alterar = new formCatalogoIdentificacoesAdicionar(id);
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
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar a identificação?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarIdentificacao(id);
                    AtualizarDataGrid();
                }
            }
        }

        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);

            if (e.ColumnIndex == 3)
            {
                bool impressao = Convert.ToBoolean(dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !impressao;
                comandos.AlterarImpressaoAutomaticaDaIdentificacao(id);

                if (!impressao)
                {
                    MessageBox.Show("Auto-impressão ativada.", "Auto-impressão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Auto-impressão desativada.", "Auto-impressão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
