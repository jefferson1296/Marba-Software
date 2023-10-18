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
    public partial class formProdutosEditarAcabamentos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Acabamento> Acabamentos = new List<Acabamento>();
        int id_produto;
        string acabamento;
        public formProdutosEditarAcabamentos()
        {
            InitializeComponent();
        }
        public formProdutosEditarAcabamentos(int ID_Produto)
        {
            InitializeComponent();
            id_produto = ID_Produto;
        }
        private void formProdutosEditarAcabamentos_Load(object sender, EventArgs e)
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

            Acabamentos = comandos.ListaDeAcabamentosDoProduto(id_produto);

            dataGridViewLista.Rows.Clear();
            foreach (Acabamento Acabamento in Acabamentos)
            {
                dataGridViewLista.Rows.Add(Acabamento.Descricao);
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

                        acabamento = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                    }
                    else
                    {
                        acabamento = string.Empty;
                    }
                }
                catch { }
            }
        }

        private void excluirPeçaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (acabamento != string.Empty)
            {
                Acabamento Acabamento = new Acabamento { ID_Produto = id_produto, Descricao = acabamento };
                comandos.ApagarAcabamentoDoProduto(Acabamento);
                AtualizarDataGrid();
            }
        }

        private void pictureBoxAdicionar_Click(object sender, EventArgs e)
        {
            formProdutosEditarAcabamentosAdicionar adicionar = new formProdutosEditarAcabamentosAdicionar(id_produto);
            adicionar.ShowDialog();
            AtualizarDataGrid();
        }
    }
}
