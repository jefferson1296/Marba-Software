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
    public partial class formVendasPDVClientesProdutosDesejados : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Produto> Produtos = new List<Produto>();
        int id_cliente;
        string cliente;

        public formVendasPDVClientesProdutosDesejados()
        {
            InitializeComponent();
        }
        public formVendasPDVClientesProdutosDesejados(int ID_Cliente, string Cliente)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            id_cliente = ID_Cliente;
            cliente = Cliente;
        }

        private void formVendasPDVClientesProdutosDesejados_Load(object sender, EventArgs e)
        {
            textBoxCliente.Text = cliente;
            textBoxProduto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxProduto.AutoCompleteCustomSource = comandos.AutoCompleteVendas();

        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            string produto = textBoxProduto.Text;
            if (!comandos.VerificarNomeDoSistema(produto))
            {
                MessageBox.Show("Produto inválido. Verifique se o produto está Ativo!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Produtos.Any(x => x.Nome_Produto == produto))
            {
                MessageBox.Show("Esse produto já foi inserido na lista!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Produtos.Add(new Produto
                {
                    Nome_Produto = produto,
                    ID_Produto = comandos.TrazerIdDoProdutoPeloNomeDoSistema(produto)
                });
                AtualizarDataGrid();
            }
        }

        private void AtualizarDataGrid()
        {
            dataGridViewLista.Rows.Clear();
            foreach(Produto Produto in Produtos)
            {
                dataGridViewLista.Rows.Add(Produto.Nome_Produto);
            }
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

        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                string produto = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                Produtos.RemoveAll(x => x.Nome_Produto == produto);
                AtualizarDataGrid();
            }
            catch { }
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (Produtos.Count == 0)
            {
                MessageBox.Show("Adicione produtos à lista para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                comandos.RegistrarProdutoDesejado(id_cliente, Produtos);
                Dispose();
            }
        }

        private void formVendasPDVClientesProdutosDesejados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }
    }
}
