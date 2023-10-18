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
    public partial class formVendasPDVPagamentos : Form
    {
        #region Inicialização
        decimal Total;
        decimal Desconto;
        decimal Subtotal;
        decimal Pago;
        decimal Restante;
        decimal Troco;
        decimal Juros;
        public decimal Taxa_Entrega;

        ComandosSQL comandos = new ComandosSQL();

        int n;
        public bool Atualizar;
        public bool ConfirmarEntrega = false;
        public string DataRetirada = string.Empty;
        public bool ConfirmarRetirada = false;
        public Entrega Entrega;
        public int id_Troca = 0;

        public List<string> listaRetirada = new List<string>();
        public List<string> listaEntrega = new List<string>();  

        public bool confirmar_pgmt_vale_troca;
        public formVendasPDV pdv = new formVendasPDV();

        bool imprimir_cupom;

        public formVendasPDVPagamentos()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);

        }
        public formVendasPDVPagamentos(formVendasPDV PDV)
        {
            InitializeComponent();
            pdv = PDV;

            new Sombra().ApplyShadows(this);
        }
        private void formVendasPDVPagamentos_Load(object sender, EventArgs e)
        {
            Total = pdv.pai.Produtos.Cast<ProdutoVenda>().Sum(i => i.Total);
            Desconto = pdv.pai.Produtos.Cast<ProdutoVenda>().Sum(i => i.Desconto);
            Subtotal = pdv.pai.Produtos.Cast<ProdutoVenda>().Sum(i => i.Subtotal);
            Pago = 0;
            Restante = 0;
            Troco = 0;

            textBoxSubtotal.Text = Subtotal.ToString("C");
            textBoxDesconto.Text = Desconto.ToString("C");
            textBoxTot.Text = Total.ToString("C");
            textBoxTotal.Text = Total.ToString("C");
            AtualizarLista();

            imprimir_cupom = pdv.pai.imprimir_cupom;
            checkBoxImprimir.Checked = imprimir_cupom;

            if (pdv.pai.tipo_de_venda == "Entrega")
            {
                formVendasPDVPagamentosEntregasInformacoes entrega = new formVendasPDVPagamentosEntregasInformacoes(pdv.pai.cliente.CPF, this, pdv.pai.Produtos);
                entrega.ShowDialog();              

                if (!ConfirmarEntrega) { Dispose(); } else { AtualizarLista(); }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Dispose();            
        }
        #endregion
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

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Restante <= 0)
                {
                    MessageBox.Show("Não é possível adicionar pagamentos porque\r\no valor da venda já foi atingido.\r\nClique em finalizar para concluir a transação.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    formVendasPDVPagamentosAdicionar pagamento = new formVendasPDVPagamentosAdicionar(Restante, this);
                    pagamento.ShowDialog();

                    if (Atualizar)
                        AtualizarLista();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarLista()
        {
            dataGridViewLista.Rows.Clear();
            int n = 1;
            foreach (Pagamento pagamento in pdv.pai.Pagamentos)
            {
                string forma = pagamento.Forma;
                decimal juros = pagamento.Juros;
                decimal valor = pagamento.Valor;
                decimal troco = pagamento.Troco;
                decimal pago = valor + troco;

                dataGridViewLista.Rows.Add(n, forma, valor.ToString("C"), pago.ToString("C"), troco.ToString("C"));
                n++;
            }

            Juros = pdv.pai.Pagamentos.Cast<Pagamento>().Sum(i => i.Juros);
            Total = Math.Round(pdv.pai.Produtos.Cast<ProdutoVenda>().Sum(i => i.Total) + Juros + Taxa_Entrega, 2);
            Pago = Math.Round(pdv.pai.Pagamentos.Cast<Pagamento>().Sum(i => i.Valor), 2);
            Troco = Math.Round(pdv.pai.Pagamentos.Cast<Pagamento>().Sum(i => i.Troco), 2);
            Restante = Total - Pago;


            if (Restante == 0) { textBoxFalta.ForeColor = Color.DimGray; }
            else { textBoxFalta.ForeColor = Color.DarkRed; }

            textBoxPago.Text = Pago.ToString("C");
            textBoxFalta.Text = Restante.ToString("C");
            textBoxTroco.Text = Troco.ToString("C");

            if (Juros > 0)
            {
                textBoxJuros.Visible = true;
                panelJuros.Visible = true;
                textBoxJuros.Text = "JUROS    +  " + Juros.ToString("C");
            }
            else
            {
                textBoxJuros.Visible = false;
                panelJuros.Visible = false;
            }

            if (Taxa_Entrega > 0)
            {
                textBoxEntrega.Visible = true;
                textBoxEntrega.Text = "ENTREGA   +  " + Taxa_Entrega.ToString("C");
            }

            textBoxTot.Text = Total.ToString("C");
            textBoxTotal.Text = Total.ToString("C");
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

                        n = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    }
                    else
                    {
                        n = 0;
                    }
                }
                catch { }
            }
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                pdv.pai.Pagamentos.RemoveAt(n - 1);
                AtualizarLista();
            }
            catch { }
        }

        private void buttonFinalizar_Click(object sender, EventArgs e)
        {
            if (Total != Pago)
            {
                MessageBox.Show("O valor do pagamento é inferior ao valor da venda.\r\nRegistre o pagamento do valor restante para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (pdv.pai.tipo_de_venda == "Venda")
                {
                    comandos.RegistrarVenda(pdv.pai.Produtos, pdv.pai.cliente.CPF);
                    comandos.RegistrarPagamento(pdv.pai.Pagamentos);
                    comandos.RegistrarProdutoVendido(pdv.pai.Produtos, pdv.pai.id_reparticao);
                    pdv.venda = true;
                }
                if (pdv.pai.tipo_de_venda == "Retirar")
                {
                    formVendasPDVPagamentosRetirada retirada = new formVendasPDVPagamentosRetirada(this, pdv.pai.Produtos);
                    retirada.ShowDialog();

                    if (ConfirmarRetirada)
                    {
                        comandos.RegistrarVenda(pdv.pai.Produtos, pdv.pai.cliente.CPF);
                        comandos.AgendarRetirada(DataRetirada);
                        comandos.RegistrarProdutoRetirada(listaRetirada);
                        comandos.RegistrarPagamento(pdv.pai.Pagamentos);
                        comandos.RegistrarProdutoVendido(pdv.pai.Produtos, pdv.pai.id_reparticao);
                        pdv.venda = true;
                    }
                }
                else if (pdv.pai.tipo_de_venda == "Entrega")
                {
                    if (ConfirmarEntrega)
                    {


                        comandos.RegistrarVenda(pdv.pai.Produtos, pdv.pai.cliente.CPF);
                        comandos.RegistrarEntrega(Entrega);
                        comandos.RegistrarProdutoEntrega(listaEntrega);
                        comandos.RegistrarPagamento(pdv.pai.Pagamentos);
                        comandos.RegistrarProdutoVendido(pdv.pai.Produtos, pdv.pai.id_reparticao);
                        pdv.venda = true;
                    }
                }

                foreach (Pagamento Pagamento in pdv.pai.Pagamentos)
                {
                    if (Pagamento.Forma == "PICPAY" || Pagamento.Forma == "PIX" || Pagamento.Forma == "VALE-TROCA")
                    {
                        comandos.ImprimirComprovanteDePagamento(Pagamento);
                    }
                }

                pdv.imprimir_cupom = checkBoxImprimir.Checked;
                Dispose();
            }


        }

        private void formVendasPDVPagamentos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                formConsultaRapida consultaRapida = new formConsultaRapida();
                consultaRapida.ShowDialog();
            }
        }

        private void checkBoxImprimir_CheckedChanged(object sender, EventArgs e)
        {
            imprimir_cupom = checkBoxImprimir.Checked;
        }
    }
}
