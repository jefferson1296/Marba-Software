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
    public partial class formCatalogoCapsulas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id;

        public formCatalogoCapsulas()
        {
            InitializeComponent();
        }
        private void formUtensilioCapsulas_Load(object sender, EventArgs e)
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
            formCatalogoCapsulasAdicionar adicionar = new formCatalogoCapsulasAdicionar();
            adicionar.ShowDialog();
            AtualizarDataGrid();
        }



        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
               if (DialogResult.Yes == MessageBox.Show("A cápsula será excluída permanentemente e os produtos encapsulados serão retirados do catálogo.\r\nAlém disso, fotos do catálogo e definições de armazenamento serão desvinculadas do produto.\r\nTem certeza que deseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    comandos.ApagarCapsula(id);                    
                    AtualizarDataGrid();
                }
            }
        }

        #region Pesquisa de Produtos
        private void dataGridViewLista_FilterStringChanged(object sender, EventArgs e)
        {
            binding.Filter = dataGridViewLista.FilterString;
        }

        private void dataGridViewLista_SortStringChanged(object sender, EventArgs e)
        {
            binding.Sort = dataGridViewLista.SortString;
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
                binding.Filter = "Nome like '%" + textBoxPesquisa.Text + "%' OR Utensilio like '%" + textBoxPesquisa.Text + "%' OR Material like '%" + textBoxPesquisa.Text + "%'";
            }
        }

        private void textBoxPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                binding.Filter = "Nome like '%" + textBoxPesquisa.Text + "%' OR Utensilio like '%" + textBoxPesquisa.Text + "%' OR Material like '%" + textBoxPesquisa.Text + "%'";
            }
        }
        #endregion

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                formCatalogoCapsulasAdicionar cadastrar = new formCatalogoCapsulasAdicionar(id);
                cadastrar.ShowDialog();
                AtualizarDataGrid();
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

        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    bool catalogo = Convert.ToBoolean(dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !catalogo;
                    comandos.AlterarStatusDaCapsula(id);

                    if (!catalogo)
                    {
                        MessageBox.Show("A cápsula foi ativada.\r\nOs produtos serão inseridos no catálogo\r\ne relacionados nos pedidos automáticos.", "Cápsula ativada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("A cápsula foi desativada.\r\nOs produtos serão retirados do catálogo\r\ne não serão mais relacionados nos pedidos automáticos.", "Cápsula desativada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch { }
        }
    }
}
