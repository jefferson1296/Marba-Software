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
    public partial class formCatalogoTransformacoesCapsulas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id_catalogo;
        int id_capsula;

        public formCatalogoTransformacoesCapsulas()
        {
            InitializeComponent();
        }
        public formCatalogoTransformacoesCapsulas(int ID_Catalogo)
        {
            InitializeComponent();
            id_catalogo = ID_Catalogo;
        }

        private void formCatalogoTransformacoesCapsulas_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void textBoxPesquisa_Enter(object sender, EventArgs e)
        {
            textBoxPesquisa.Text = string.Empty;
            textBoxPesquisa.ForeColor = Color.Firebrick;
            textBoxPesquisa.CharacterCasing = CharacterCasing.Upper;

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }

        private void textBoxPesquisa_Leave(object sender, EventArgs e)
        {
            textBoxPesquisa.CharacterCasing = CharacterCasing.Normal;
            textBoxPesquisa.Text = "Digite aqui para pesquisar";
            textBoxPesquisa.ForeColor = Color.IndianRed;
        }

        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text != "Digite aqui para pesquisar" && textBoxPesquisa.Text != string.Empty)
            {
                binding.Filter = "Nome like '%" + textBoxPesquisa.Text + "%' OR Utensilio like '%" + textBoxPesquisa.Text + "%'";
            }
        }

        private void textBoxPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                binding.Filter = "Nome like '%" + textBoxPesquisa.Text + "%' OR Utensilio like '%" + textBoxPesquisa.Text + "%'";
            }
        }

        private void dataGridViewLista_FilterStringChanged(object sender, EventArgs e)
        {
            binding.Filter = dataGridViewLista.FilterString;
        }

        private void dataGridViewLista_SortStringChanged(object sender, EventArgs e)
        {
            binding.Sort = dataGridViewLista.SortString;
        }

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            comandos.PreencherDataGridCapsulas(binding, dataGridViewLista);

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            if (id_capsula == 0)
            {
                MessageBox.Show("Informe a cápsula para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                formCatalogoCapsulasAdicionarProdutosAdicionar transformar = new formCatalogoCapsulasAdicionarProdutosAdicionar(id_catalogo, id_capsula);
                transformar.ShowDialog();
                Dispose();
            }
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_capsula = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                formCatalogoCapsulasAdicionarProdutosAdicionar transformar = new formCatalogoCapsulasAdicionarProdutosAdicionar(id_catalogo, id_capsula);
                transformar.ShowDialog();
                Dispose();
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

                        id_capsula = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    }
                    else
                    {
                        id_capsula = 0;
                    }
                }
                catch { }
            }
        }

        private void encapsularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_capsula != 0)
            {
                formCatalogoCapsulasAdicionarProdutos produtos = new formCatalogoCapsulasAdicionarProdutos(id_capsula);
                produtos.ShowDialog();
                AtualizarDataGrid();
            }
        }

        private void buttonCapsula_Click(object sender, EventArgs e)
        {
            formCatalogoTransformacoesCapsulasSimples capsula = new formCatalogoTransformacoesCapsulasSimples();
            capsula.ShowDialog();
            AtualizarDataGrid();
        }

        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridViewLista.CurrentCell = dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dataGridViewLista.Rows[e.RowIndex].Selected = true;
                    dataGridViewLista.Focus();

                    id_capsula = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                }
                else
                {
                    id_capsula = 0;
                }
            }
            catch { }
        }

        private void editarCápsulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_capsula != 0)
            {
                formCatalogoTransformacoesCapsulasSimples editar = new formCatalogoTransformacoesCapsulasSimples(id_capsula);
                editar.ShowDialog();
                AtualizarDataGrid();
            }
        }
    }
}
