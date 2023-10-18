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
    public partial class formProdutosEditarPecas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Peca> Pecas = new List<Peca>();
        int id_produto;
        string peca;
        public formProdutosEditarPecas()
        {
            InitializeComponent();
        }
        public formProdutosEditarPecas(int ID_Produto)
        {
            InitializeComponent();
            id_produto = ID_Produto;
        }

        private void formProdutosEditarPecas_Load(object sender, EventArgs e)
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

            Pecas = comandos.ListaDePecasDoProduto(id_produto);

            dataGridViewLista.Rows.Clear();
            foreach (Peca Peca in Pecas)
            {
                dataGridViewLista.Rows.Add(Peca.Nome_Peca, Peca.Quantidade);
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

                        peca = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                    }
                    else
                    {
                        peca = string.Empty;
                    }
                }
                catch { }
            }
        }

        private void excluirPeçaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (peca != string.Empty)
            {
                Peca Peca = new Peca { ID_Produto = id_produto, Nome_Peca = peca };
                comandos.ApagarPecaDoProduto(Peca);
                AtualizarDataGrid();
            }
        }

        private void pictureBoxAdicionar_Click(object sender, EventArgs e)
        {
            formProdutosEditarPecasAdicionar adicionar = new formProdutosEditarPecasAdicionar(id_produto);
            adicionar.ShowDialog();
            AtualizarDataGrid();
        }
    }
}
