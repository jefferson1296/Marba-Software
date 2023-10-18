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
    public partial class formProdutosPecas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Peca> Pecas = new List<Peca>();
        string peca;
        int id;

        public formProdutosPecas()
        {
            InitializeComponent();
        }

        private void formProdutosPecas_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            string peca = textBoxPeca.Text;

            if (peca == string.Empty)
            {
                MessageBox.Show("Informe a peça que deseja adicionar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comandos.VerificarSePecaJaExiste(peca))
            {
                MessageBox.Show("Essa peça já está cadastrada!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                comandos.CadastrarPeca(peca);
            }
        }

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            Pecas = comandos.ListaDePecas();

            dataGridViewLista.Rows.Clear();
            foreach (Peca Peca in Pecas)
            {
                dataGridViewLista.Rows.Add(Peca.ID_Peca, Peca.Nome_Peca);
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
                        peca = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                    }
                    else
                    {
                        id = 0;
                    }
                }
                catch { }
            }
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.ApagarPeca(peca);
            }
        }

        private void buttonAvulsas_Click(object sender, EventArgs e)
        {

        }
    }
}
