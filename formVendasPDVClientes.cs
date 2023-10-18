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
    public partial class formVendasPDVClientes : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formVendasPDV pdv;
        int id_cliente;

        Cliente cliente = new Cliente();

        List<Cliente> clientes = new List<Cliente>();

        public formVendasPDVClientes()
        {
            InitializeComponent();
        }
        public formVendasPDVClientes(formVendasPDV PDV)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            pdv = PDV;
        }

        private void formVendasPDVClientes_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void buttonDescontos_Click(object sender, EventArgs e)
        {            
            formVendasPDVClientesCadastrar cadastro = new formVendasPDVClientesCadastrar();
            cadastro.ShowDialog();
        }



        private void buttonBalanco_Click(object sender, EventArgs e)
        {
            if (id_cliente == 0)
            {
                MessageBox.Show("Escolha o cliente para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                pdv.textBoxCliente.Text = cliente.Nome;
                pdv.pai.cliente = cliente;
                Dispose();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {               
                try
                {
                    id_cliente = Convert.ToInt32(dataGridViewLista[0, e.RowIndex].Value);
                    cliente = clientes.Where(x => x.ID_Cliente == id_cliente).FirstOrDefault();
                }
                catch { }
            }
        }

        private void textBoxPesquisa_Enter(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text == "Insira o nome do cliente")
                textBoxPesquisa.Text = string.Empty;
        }

        private void textBoxPesquisa_Leave(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text == string.Empty)
                textBoxPesquisa.Text = "Insira o nome do cliente";
        }

        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text != "Insira o nome do cliente")
                this.bindingSourceClientes.Filter = "Nome_Cliente like '%" + textBoxPesquisa.Text + "%'";
        }
        public void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            clientes = comandos.ListaDeClientes();

            dataGridViewLista.Rows.Clear();

            foreach (Cliente cliente in clientes)
            {
                string desconto;
                if (cliente.Especial) { desconto = "Especial"; }
                else { desconto = "Normal"; }

                dataGridViewLista.Rows.Add(cliente.ID_Cliente, cliente.Nome, cliente.CPF, desconto);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;

            int quantidade = dataGridViewLista.Rows.Count;
            textBoxClientes.Text = quantidade.ToString();
        }


        #region Movimentacao do Formulario
        bool clique;
        Point clickedAt;
        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique)
            {
                this.Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
            }
        }

        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            clique = true;
            clickedAt = e.Location;
        }

        private void panelSuperior_MouseUp(object sender, MouseEventArgs e)
        {
            clique = false;
        }
        #endregion

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

                        id_cliente = Convert.ToInt32(dataGridViewLista[0, e.RowIndex].Value);
                    }
                    else
                    {
                        id_cliente = 0;
                    }
                }
                catch { }
            }
        }

        private void produtoDesejadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_cliente != 0)
            {
                if (cliente.Nome != "Consumidor Final")
                {
                    formVendasPDVClientesProdutosDesejados Produtos = new formVendasPDVClientesProdutosDesejados(id_cliente, cliente.Nome);
                    Produtos.ShowDialog();
                }
            }
        }

        private void interessesDoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_cliente != 0)
            {
                if (cliente.Nome != "Consumidor Final")
                {
                    formVendasPDVClientesHabitos Habitos = new formVendasPDVClientesHabitos(id_cliente, cliente.Nome);
                    Habitos.ShowDialog();
                }
            }
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {               
            formVendasPDVClientesCadastrar cadastro = new formVendasPDVClientesCadastrar();               
            cadastro.ShowDialog();         
        }
    }
}
