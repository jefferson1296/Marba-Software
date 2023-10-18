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
    public partial class formFornecedores : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id_fornecedor;
        public formFornecedores()
        {
            InitializeComponent();
        }

        private void formFornecedores_Load(object sender, EventArgs e)
        {
            dataGridFornecedores.AutoGenerateColumns = false;
            AtualizarDataGrid();
        }

        private void AtualizarDataGrid()
        {
            comandos.PreencherDataGridFornecedores(dataGridFornecedores, bindingSourceFornecedores);
            if (dataGridFornecedores.CurrentRow != null)
                dataGridFornecedores.CurrentRow.Selected = false;
        }
        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            formFornecedoresCadastrar cadastrar = new formFornecedoresCadastrar();
            cadastrar.ShowDialog();
        }

        private void buttonPedidos_Click(object sender, EventArgs e)
        {
            formFornecedoresPedido pedidos = new formFornecedoresPedido();
            pedidos.ShowDialog();
        }

        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text != "Digite aqui para pesquisar")
            {
                bindingSourceFornecedores.Filter = "Fornecedor like '%" + textBoxPesquisa.Text + "%'";
                AtualizarDataGrid();
            }
        }

        private void textBoxPesquisa_Enter(object sender, EventArgs e)
        {
            textBoxPesquisa.Text = string.Empty;
            textBoxPesquisa.ForeColor = Color.Black;
            textBoxPesquisa.CharacterCasing = CharacterCasing.Upper;
        }

        private void textBoxPesquisa_Leave(object sender, EventArgs e)
        {
            textBoxPesquisa.CharacterCasing = CharacterCasing.Normal;
            textBoxPesquisa.Text = "Digite aqui para pesquisar";
            textBoxPesquisa.ForeColor = Color.Gray;
        }

        private void dataGridFornecedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_fornecedor = Convert.ToInt32(dataGridFornecedores.Rows[e.RowIndex].Cells[0].Value);
                formFornecedoresEditar editar = new formFornecedoresEditar(id_fornecedor);
                editar.ShowDialog();
            }
            catch { }
        }

        private void dataGridFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { id_fornecedor = Convert.ToInt32(dataGridFornecedores.Rows[e.RowIndex].Cells[0].Value); }
            catch { }            
        }

        private void formFornecedores_Resize(object sender, EventArgs e)
        {
            labelLista.Left = (panelBarra.Width / 2) - (labelLista.Width / 2);
            pictureBoxCaminhao.Left = labelLista.Left - 20;
        }
    }
}
