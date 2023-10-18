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
    public partial class formAtividadesProcessos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Processo> processos = new List<Processo>();
        int id_processo;
        string processo;

        public formAtividadesProcessos()
        {
            InitializeComponent();
        }

        private void formAtividadesProcessos_Load(object sender, EventArgs e)
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

            processos = comandos.ListaDeProcessos();
            dataGridViewLista.Rows.Clear();

            foreach (Processo processo in processos)
            {
                dataGridViewLista.Rows.Add(processo.ID_Processo, processo.Descricao, processo.Atividades);
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
                id_processo = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                processo = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();

                if (id_processo != 0)
                {
                    formAtividadesProcessosAdicionar alterar = new formAtividadesProcessosAdicionar(id_processo, processo);
                    alterar.ShowDialog();
                    AtualizarDataGrid();
                }
            }
            catch { }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formAtividadesProcessosAdicionar adicionar = new formAtividadesProcessosAdicionar();
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

                        id_processo = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    }
                    else
                    {
                        id_processo = 0;
                    }
                }
                catch { }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_processo != 0)
            {
                comandos.ApagarProcesso(id_processo);
                AtualizarDataGrid();
            }
        }
    }
}
