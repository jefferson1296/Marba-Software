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
    public partial class formFornecedoresPedidoRecebimentos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Pedido> Pedidos = new List<Pedido>();
        int id_selecionado;
        bool clique;
        Point clickedAt;
        public formFornecedoresPedidoRecebimentos()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void formFornecedoresPedidoProximos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            clique = true;
            clickedAt = e.Location;
        }

        private void formFornecedoresPedidoProximos_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique)
            {
                this.Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
            }
        }

        private void formFornecedoresPedidoProximos_MouseUp(object sender, MouseEventArgs e)
        {
            clique = false;
        }

        private void formFornecedoresPedidoProximos_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }


        private void alterarDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_selecionado != 0)
            {
                formFornecedoresPedidoEmAbertoAlterarPrevisao proximo = new formFornecedoresPedidoEmAbertoAlterarPrevisao(id_selecionado);
                proximo.ShowDialog();
                AtualizarDataGrid();
            }
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

                        id_selecionado = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                        string status = Pedidos.Where(x => x.ID_Pedido == id_selecionado).Select(x => x.Status).FirstOrDefault();
                    
                        if (status == "Recebido")
                        {
                            confirmarRecebimentoToolStripMenuItem.Visible = false;
                            alterarDataToolStripMenuItem.Visible = false;
                        }
                        else
                        {
                            confirmarRecebimentoToolStripMenuItem.Visible = true;
                            alterarDataToolStripMenuItem.Visible = true;
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

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            Pedidos = comandos.ProximosRecebimentos();
            dataGridViewLista.Rows.Clear();
            foreach (Pedido Pedido in Pedidos)
            {
                dataGridViewLista.Rows.Add(Pedido.ID_Pedido, Pedido.Fornecedor, Pedido.Previsao_Entrega.ToShortDateString() + " " + Pedido.Previsao_Entrega.ToShortTimeString());
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;

            Font minhafonte = new Font("Arial", 10, FontStyle.Strikeout, GraphicsUnit.Point);

            foreach (DataGridViewRow Linha in dataGridViewLista.Rows)
            {
                int id = Convert.ToInt32(dataGridViewLista.Rows[Linha.Index].Cells[0].Value);
                string status = Pedidos.Where(x => x.ID_Pedido == id).Select(x => x.Status).FirstOrDefault();

                if (status == "Recebido")
                {
                    DataGridViewRow linhaestilizada = dataGridViewLista.Rows[Linha.Index];
                    linhaestilizada.DefaultCellStyle.Font = minhafonte;
                    linhaestilizada.DefaultCellStyle.ForeColor = Color.Red;
                    linhaestilizada.DefaultCellStyle.SelectionForeColor = Color.Red;
                }
            }
        }

        private void confirmarRecebimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_selecionado > 0)
            {

                if (!comandos.VerificarVinculoEntreEntradaEPedido(id_selecionado))
                {
                    MessageBox.Show("Não há entrada vinculada a esse pedido. Informe imediatamente à gestão.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string alteracao = string.Empty;
                    bool permitir;
                    DialogResult Resposta = MessageBox.Show("Houve algum problema com o recebimento?", "Concluir recebimento", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (DialogResult.Yes == Resposta)
                    {
                        permitir = true;
                        alteracao = "Sim";
                    }
                    else if (DialogResult.No == Resposta)
                    {
                        permitir = true;
                        alteracao = "Não";
                    }
                    else
                    {
                        permitir = false;
                    }

                    if (permitir)
                    {
                        comandos.RegistrarRecebimento(id_selecionado, alteracao);
                        comandos.ConfirmarProdutosRecebidosAPartirDoPedido(id_selecionado);
                        MessageBox.Show("Recebimento registrado! Os produtos recebidos estão em estado de quarentena.", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AtualizarDataGrid();
                    }
                }
            }
        }

        private void imprimirCupomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_selecionado > 0)
            {
                string fornecedor = Pedidos.Where(x => x.ID_Pedido == id_selecionado).Select(x => x.Fornecedor).FirstOrDefault();
                comandos.ImprimirCupomDeRecebimento(id_selecionado, fornecedor);
            }
        }

    }
}
