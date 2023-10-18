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
    public partial class formFornecedoresPedidoEmAberto : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Pedido> Pedidos = new List<Pedido>();
        public List<PedidoProdutos> Produtos = new List<PedidoProdutos>();
        public bool alteracao;
        int id_selecionado;
        public formFornecedoresPedidoEmAberto()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void formFornecedoresPedidoEmAberto_Load(object sender, EventArgs e)
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

            dataGridViewLista.Rows.Clear();
            Pedidos = comandos.ListaDePedidosEmAberto();

            foreach (Pedido Pedido in Pedidos)
            {
                int id_pedido = Pedido.ID_Pedido;
                string fornecedor = Pedido.Fornecedor;
                int produtos = Pedido.Qtd_Produtos;
                string solicitacao = Pedido.Solicitacao.ToShortDateString();
                string previsao = Pedido.Previsao_Entrega.ToShortDateString();
                string status = Pedido.Status;

                dataGridViewLista.Rows.Add(id_pedido, fornecedor, produtos, solicitacao, previsao, status);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
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

                        id_selecionado = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                        string status = dataGridViewLista.Rows[e.RowIndex].Cells[5].Value.ToString();

                        if (status == "Envio Pendente")
                        {
                            confirmarEnvioToolStripMenuItem.Visible = true;
                            confirmarProdutosToolStripMenuItem.Visible = false;
                            reagendarToolStripMenuItem.Visible = false;
                        }
                        else if (status == "Confirmação Pendente")
                        {
                            confirmarEnvioToolStripMenuItem.Visible = false;
                            confirmarProdutosToolStripMenuItem.Visible = true;
                            reagendarToolStripMenuItem.Visible = true;
                        }
                        else
                        {
                            confirmarEnvioToolStripMenuItem.Visible = false;
                            confirmarProdutosToolStripMenuItem.Visible = false;
                            reagendarToolStripMenuItem.Visible = false;
                        }
                    }
                    else
                    {
                        id_selecionado = 0;
                    }
                }
                catch { }
            }
        }

        private void confirmarEnvioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comandos.ConfirmarEnvio(id_selecionado);
            AtualizarDataGrid();
        }

        private void cancelarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comandos.CancelarPedido(id_selecionado);
            AtualizarDataGrid();
        }

        private void confirmarProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_selecionado != 0)
            {
                Pedido Pedido = Pedidos.Where(x => x.ID_Pedido == id_selecionado).FirstOrDefault();
                formFornecedoresPedidoConfirmar confirmar = new formFornecedoresPedidoConfirmar(Pedido, this);
                confirmar.ShowDialog();
                if (alteracao)
                {
                    alteracao = false;
                    comandos.ConfirmarProdutos(id_selecionado, Produtos);
                    AtualizarDataGrid();
                }
            }
        }

        private void reagendarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_selecionado != 0)
            {
                formFornecedoresPedidoEmAbertoProximoContato proximo = new formFornecedoresPedidoEmAbertoProximoContato(id_selecionado);
                proximo.ShowDialog();
            }
        }
    }
}
