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
    public partial class formProdutosConjuntos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        
        
        public formProdutosConjuntos()
        {
            InitializeComponent();
        }

        private void formProdutosConjuntos_Load(object sender, EventArgs e)
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

            comandos.PreencherDataGridConjuntos(binding, dataGridViewLista);

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
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
                binding.Filter = "Nome_Original like '%" + textBoxPesquisa.Text + "%' OR Cod_Extra like '%" + textBoxPesquisa.Text + "%'";
            }
        }

        private void textBoxPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                binding.Filter = "Nome_Original like '%" + textBoxPesquisa.Text + "%' OR Cod_Extra like '%" + textBoxPesquisa.Text + "%'";
            }
        }
        #endregion

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formProdutosConjuntosCadastrar cadastrar = new formProdutosConjuntosCadastrar();
            cadastrar.ShowDialog();
        }
    }
}
