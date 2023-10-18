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
    public partial class formTelaInicialPrincipalAssuntos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Assunto> assuntos = new List<Assunto>();

        public formTelaInicialPrincipalAssuntos()
        {
            InitializeComponent();
        }

        private void formTelaInicialPrincipalAssuntos_Load(object sender, EventArgs e)
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

            assuntos = comandos.MeusAssuntos();
            dataGridViewLista.Rows.Clear();

            foreach (Assunto assunto in assuntos)
            {
                string registro = assunto.Registro.ToShortDateString() + " " + assunto.Registro.ToShortTimeString();

                dataGridViewLista.Rows.Add(assunto.Descricao, registro, assunto.Impressao);
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

        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                bool impressao = Convert.ToBoolean(dataGridViewLista[e.ColumnIndex, e.RowIndex].Value);

                if (impressao)
                {
                    dataGridViewLista[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.DarkGray;
                }
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formTelaInicialPrincipalAssuntosAdicionar sugestoes = new formTelaInicialPrincipalAssuntosAdicionar();
            sugestoes.ShowDialog();
            AtualizarDataGrid();
        }
    }
}
