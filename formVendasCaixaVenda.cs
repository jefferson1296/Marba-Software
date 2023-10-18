using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarbaSoftware
{
    public partial class formVendasCaixaVenda : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        Venda venda = new Venda();
        int id;

        bool alterar_pagamentos;

        public formVendasCaixaVenda()
        {
            InitializeComponent();
        }
        public formVendasCaixaVenda(int ID)
        {
            InitializeComponent();
            id = ID;
        }
        private void formVendasCaixaAtualVenda_Load(object sender, EventArgs e)
        {
            venda = comandos.InformacoesDaVenda(id);
            textBoxID.Text = venda.ID_Venda.ToString();
            textBoxOperador.Text = venda.Operador;
            textBoxCliente.Text = venda.Cliente;

            CultureInfo cultura = new CultureInfo("pt-BR");
            DateTimeFormatInfo formato = cultura.DateTimeFormat;

            string dia_da_semana = formato.GetDayName(venda.Data.DayOfWeek).PrimeiraLetraMaiuscula();
            textBoxData.Text = dia_da_semana + ", " + venda.Data.ToShortDateString() + " às " + venda.Data.ToShortTimeString();


            alterar_pagamentos = Program.Acessos.Where(x => x.Descricao == "Alterar forma de pagamento").Select(x => x.Permissao).FirstOrDefault();

            List<string> formas = new List<string>();
            formas.Add("CRÉDITO");
            formas.Add("DÉBITO");
            formas.Add("DINHEIRO");
            formas.Add("PICPAY");
            formas.Add("PIX");
            formas.Add("VALE - TROCA");

            columnForma.DataSource = formas;

            if (alterar_pagamentos)
            {
                foreach (DataGridViewColumn coluna in dataGridViewPagamentos.Columns)
                {
                    if (coluna.Index != 1)
                    {
                        coluna.ReadOnly = true;
                    }
                }
            }
            else
            {
                dataGridViewPagamentos.ReadOnly = true;
            }

            AtualizarDataGridProdutos();
            AtualizarDataGridPagamentos();

            if (dataGridViewProdutos.CurrentRow != null)
                dataGridViewProdutos.CurrentRow.Selected = false;
            if (dataGridViewPagamentos.CurrentRow != null)
                dataGridViewPagamentos.CurrentRow.Selected = false;
        }

        private void AtualizarDataGridProdutos()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewProdutos.CurrentRow != null)
            {
                primeira_linha = dataGridViewProdutos.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewProdutos.CurrentRow.Index;
            }

            dataGridViewProdutos.Rows.Clear();

            foreach (ProdutoVenda Produto in venda.Produtos)
            {                
                dataGridViewProdutos.Rows.Add(Produto.Codigo, Produto.Produto, Produto.Preco.ToString("C"), Produto.Quantidade, Produto.Total.ToString("C"), Produto.Desconto.ToString("C"));
            }

            try
            {
                dataGridViewProdutos.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewProdutos.CurrentCell = dataGridViewProdutos.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            textBoxProdutos.Text = venda.Produtos.Sum(x => x.Quantidade).ToString();
            if (dataGridViewProdutos.CurrentRow != null)
                dataGridViewProdutos.CurrentRow.Selected = false;
        }

        private void AtualizarDataGridPagamentos()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewPagamentos.CurrentRow != null)
            {
                primeira_linha = dataGridViewPagamentos.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewPagamentos.CurrentRow.Index;
            }

            dataGridViewPagamentos.Rows.Clear();

            foreach (Pagamento Pagamento in venda.Pagamentos)
            {
                dataGridViewPagamentos.Rows.Add(Pagamento.ID_Pagamento, Pagamento.Forma, Pagamento.Valor.ToString("C"), Pagamento.Pago.ToString("C"), Pagamento.Troco.ToString("C"), Pagamento.Juros.ToString("C"), Pagamento.Bandeira);
            }

            try
            {
                dataGridViewPagamentos.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewPagamentos.CurrentCell = dataGridViewPagamentos.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            textBoxTotal.Text = venda.Pagamentos.Sum(x => x.Valor).ToString("C");
            textBoxJuros.Text = venda.Pagamentos.Sum(x => x.Juros).ToString("C");
            textBoxTroco.Text = venda.Pagamentos.Sum(x => x.Troco).ToString("C");
            textBoxDescontos.Text = venda.Produtos.Sum(x => x.Desconto).ToString("C");

            if (dataGridViewPagamentos.CurrentRow != null)
                dataGridViewPagamentos.CurrentRow.Selected = false;
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
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

        private void dataGridViewPagamentos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (alterar_pagamentos)
            {
                if (e.ColumnIndex == 1)
                {
                    try
                    {
                        int id_pagamento = Convert.ToInt32(dataGridViewPagamentos[0, e.RowIndex].Value);
                        string forma = dataGridViewPagamentos[1, e.RowIndex].Value.ToString();


                        Pagamento pagamento = new Pagamento { ID_Pagamento = id_pagamento, Forma = forma };
                        comandos.AlterarFormaDePagamento(pagamento);
                    }
                    catch { }
                }
            }
        }

        private void dataGridViewPagamentos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewPagamentos.IsCurrentCellDirty)
            {
                dataGridViewPagamentos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridViewPagamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (alterar_pagamentos)
            {
                string parcelas = dataGridViewPagamentos[6, e.RowIndex].Value.ToString();

                if (parcelas != "- - -")
                {
                    MessageBox.Show("Não é possível alterar a forma de um pagamento parcelado.\r\nVerifique se a transação é realmente necessária.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
