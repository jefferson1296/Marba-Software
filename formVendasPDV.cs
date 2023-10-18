using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MarbaSoftware
{
    public partial class formVendasPDV : Form
    {
        #region Inicialização

        ComandosSQL comandos = new ComandosSQL();
        public formVendas pai = new formVendas();

        ProdutoVenda Produto = new ProdutoVenda();

        string produto_informado;

        public decimal juros = 0;

        public bool venda = false;

        public string codigo;

        // bool retirada_concluida = false;
        //// bool venda_concluida = false;
        // bool entrega_agendada = false;

        public bool concessao;
        public bool imprimir_cupom;

        public formVendasPDV()
        {
            InitializeComponent();
        }
        public formVendasPDV(formVendas Pai)
        {
            InitializeComponent();
            pai = Pai;
        }
        private void formVendasPDV_Load(object sender, EventArgs e)
        {
            textBoxCliente.Text = pai.cliente.Nome;

            dataGridViewLista.AutoGenerateColumns = false;

            checkBoxCupom.Checked = pai.imprimir_cupom;

            textBoxProduto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxProduto.AutoCompleteCustomSource = pai.Sugestao_Produtos;

            if (pai.caixa_aberto)
            {
                textBoxProduto.Enabled = true;
                labelCaixaFechado.Visible = false;
            }
            else
            {
                textBoxProduto.Enabled = false;
                labelCaixaFechado.Visible = true;
            }

            textBoxProduto.Focus();

            AtualizarDataGrid();
        }
        #endregion

        #region Formatação de Texto



        private void textBoxProduto_TextChanged(object sender, EventArgs e)
        {
            if (textBoxProduto.Text != Produto.Produto)
            {
                textBoxPreco.Text = "0,00";
                labelTotalProduto.Text = "R$0,00";
            }
            else { }
        }

        private void textBoxQtd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxProduto.Text != string.Empty && textBoxPreco.Text != "0,00")
                {
                    double venda = Convert.ToDouble(textBoxPreco.Text);
                    double quantidade = Convert.ToDouble(textBoxQtd.Text);
                    double totalproduto = venda * quantidade;
                    labelTotalProduto.Text = totalproduto.ToString("C");
                }
            }
            catch { }
        }

        private void textBoxQtd_Leave(object sender, EventArgs e)
        {
            if (textBoxQtd.Text == "0" || textBoxQtd.Text == string.Empty)
            {
                textBoxQtd.Text = "0";
                labelTotalProduto.Text = "R$0,00";
            }
        }

        private void textBoxQtd_Enter(object sender, EventArgs e)
        {
            if (textBoxQtd.Text == "0" && textBoxProduto.Text != string.Empty)
                textBoxQtd.Text = string.Empty;
        }

        private void formVendasPDV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void textBoxQtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        #endregion

        #region Adicionar Produto

        private void textBoxProduto_Leave(object sender, EventArgs e)
        {
            string produto = textBoxProduto.Text;
            int quantidade = Convert.ToInt32(textBoxQtd.Text);

            //try
            //{
            //    if (textBoxProduto.Text.Contains("*"))
            //    {
            //        string[] partir = textBoxProduto.Text.Split('*');
            //        quantidade = Convert.ToInt32(partir[0]);
            //        produto = partir[1];
            //    }
            //    else
            //    {
            //        quantidade = 1;
            //        produto = textBoxProduto.Text;
            //    }
            //}
            //catch
            //{
            //    quantidade = 1;
            //    produto = textBoxProduto.Text;
            //}

            if (produto != string.Empty)
            {
                if (produto != produto_informado)
                {
                    try
                    {
                        long x = Convert.ToInt64(produto);
                        Produto = comandos.TrazerInformacoesDoProdutoParaVenda(produto, true);
                    }
                    catch
                    {
                        Produto = comandos.TrazerInformacoesDoProdutoParaVenda(produto, false);

                        if (Produto.Produto != string.Empty)
                        {
                            //MessageBox.Show("O sistema registrou que você digitou o nome do produto.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                produto_informado = produto;
                textBoxProduto.Text = Produto.Produto;

                if (Produto.Produto != string.Empty || Produto.Produto == null)
                {
                    textBoxQtd.Text = quantidade.ToString();
                    textBoxPreco.Text = Produto.Preco.ToString("F");
                    labelTotalProduto.Text = Produto.Preco.ToString("C");
                    buttonAdicionar.Focus();
                    textBoxProduto.TabStop = false;


                    buttonAdicionar_Click(sender, e);
                }
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            int quantidade = Convert.ToInt32(textBoxQtd.Text);

            if (Produto.Produto == string.Empty || Produto.Produto == null)
            {
                MessageBox.Show("Informe um produto válido para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxProduto.Focus();
            }
            else if (quantidade == 0)
            {
                MessageBox.Show("Informe a Quantidade!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxQtd.Focus();
            }
            else
            {
                Produto.Index = pai.Produtos.Count() + 1;
                Produto.Quantidade = 1;
                Produto.Subtotal = Produto.Preco;

                decimal subtotal = quantidade * Produto.Preco;

                string faixa = VerificarFaixaDeDesconto(subtotal);

                if (faixa != pai.faixa_atual) //Se a faixa for diferente da faixa atual, recalcular tudo
                {
                    for (int i = 0; i < quantidade; i++)
                    {
                        pai.Produtos.Add(Produto);
                    }

                    pai.faixa_atual = faixa;

                    AplicarCombos();
                    RecalcularDescontoDeTodosOsProdutos(faixa);
                }
                else
                {
                    CalcularValorTotalPelaFaixa();

                    for (int i = 0; i < quantidade; i++)
                    {
                        pai.Produtos.Add(Produto);
                    }

                    AplicarCombos();
                }

                AtualizarDataGrid();

                //PreencherDataGridView(total);
                textBoxProduto.Text = string.Empty;
                produto_informado = string.Empty;
                textBoxProduto.TabStop = false;
                textBoxQtd.Text = "1";
                textBoxProduto.Focus();

                Produto = new ProdutoVenda();
            }
        }

        private string VerificarFaixaDeDesconto(decimal subtotal)
        {            
            string faixa = string.Empty;

            if (pai.cliente.Nome != "Consumidor Final")
            {
                subtotal = pai.Produtos.Sum(x => x.Subtotal) + subtotal;

                foreach (Tabela_Descontos tabela in pai.Descontos)
                {
                    if (subtotal > tabela.Inicio && (subtotal < tabela.Termino || tabela.Termino == 0))
                    {
                        if (pai.cliente.Especial && (tabela.Descricao == "Revendedor1" || tabela.Descricao == "Revendedor2" || tabela.Descricao == "Revendedor3"))
                        {
                            faixa = tabela.Descricao;
                            break;
                        }
                        else if (!pai.cliente.Especial && (tabela.Descricao == "Cliente1" || tabela.Descricao == "Cliente2" || tabela.Descricao == "Cliente3"))
                        {
                            faixa = tabela.Descricao;
                            break;
                        }
                    }
                }
            }
            else
            {
                faixa = string.Empty;
            }

            return faixa;
        }

        private void CalcularValorTotalPelaFaixa()
        {
            if (pai.faixa_atual == string.Empty)
            {
                Produto.Total = Produto.Subtotal;
            }
            else
            {
                decimal percentual;

                switch (pai.faixa_atual)
                {
                    case "Cliente1":
                        percentual = pai.Categorias.Where(x => x.ID_Categoria == Produto.ID_Categoria).Select(x => x.Cliente1).FirstOrDefault();
                        Produto.Total = Produto.Subtotal - (Produto.Subtotal / 100 * percentual);
                        Produto.Desconto = Produto.Subtotal - Produto.Total;
                        break;
                    case "Cliente2":
                        percentual = pai.Categorias.Where(x => x.ID_Categoria == Produto.ID_Categoria).Select(x => x.Cliente2).FirstOrDefault();
                        Produto.Total = Produto.Subtotal - (Produto.Subtotal / 100 * percentual);
                        Produto.Desconto = Produto.Subtotal - Produto.Total;
                        break;
                    case "Cliente3":
                        percentual = pai.Categorias.Where(x => x.ID_Categoria == Produto.ID_Categoria).Select(x => x.Cliente3).FirstOrDefault();
                        Produto.Total = Produto.Subtotal - (Produto.Subtotal / 100 * percentual);
                        Produto.Desconto = Produto.Subtotal - Produto.Total;
                        break;
                    case "Revendedor1":
                        percentual = pai.Categorias.Where(x => x.ID_Categoria == Produto.ID_Categoria).Select(x => x.Revendedor1).FirstOrDefault();
                        Produto.Total = Produto.Subtotal - (Produto.Subtotal / 100 * percentual);
                        Produto.Desconto = Produto.Subtotal - Produto.Total;
                        break;
                    case "Revendedor2":
                        percentual = pai.Categorias.Where(x => x.ID_Categoria == Produto.ID_Categoria).Select(x => x.Revendedor2).FirstOrDefault();
                        Produto.Total = Produto.Subtotal - (Produto.Subtotal / 100 * percentual);
                        Produto.Desconto = Produto.Subtotal - Produto.Total;
                        break;
                    case "Revendedor3":
                        percentual = pai.Categorias.Where(x => x.ID_Categoria == Produto.ID_Categoria).Select(x => x.Revendedor3).FirstOrDefault();
                        Produto.Total = Produto.Subtotal - (Produto.Subtotal / 100 * percentual);
                        Produto.Desconto = Produto.Subtotal - Produto.Total;
                        break;
                }
            }
        }

        private void RecalcularDescontoDeTodosOsProdutos(string faixa)
        {
            foreach (ProdutoVenda produto in pai.Produtos)
            {
                if (!produto.Promocao)
                {
                    if (faixa == string.Empty)
                    {
                        produto.Total = produto.Subtotal;
                    }
                    else
                    {
                        decimal percentual;

                        switch (pai.faixa_atual)
                        {
                            case "Cliente1":
                                percentual = pai.Categorias.Where(x => x.ID_Categoria == produto.ID_Categoria).Select(x => x.Cliente1).FirstOrDefault();
                                produto.Total = produto.Subtotal - (produto.Subtotal / 100 * percentual);
                                produto.Desconto = produto.Subtotal - produto.Total;
                                break;
                            case "Cliente2":
                                percentual = pai.Categorias.Where(x => x.ID_Categoria == produto.ID_Categoria).Select(x => x.Cliente2).FirstOrDefault();
                                produto.Total = produto.Subtotal - (produto.Subtotal / 100 * percentual);
                                produto.Desconto = produto.Subtotal - produto.Total;
                                break;
                            case "Cliente3":
                                percentual = pai.Categorias.Where(x => x.ID_Categoria == produto.ID_Categoria).Select(x => x.Cliente3).FirstOrDefault();
                                produto.Total = produto.Subtotal - (produto.Subtotal / 100 * percentual);
                                produto.Desconto = produto.Subtotal - produto.Total;
                                break;
                            case "Revendedor1":
                                percentual = pai.Categorias.Where(x => x.ID_Categoria == produto.ID_Categoria).Select(x => x.Revendedor1).FirstOrDefault();
                                produto.Total = produto.Subtotal - (produto.Subtotal / 100 * percentual);
                                produto.Desconto = produto.Subtotal - produto.Total;
                                break;
                            case "Revendedor2":
                                percentual = pai.Categorias.Where(x => x.ID_Categoria == produto.ID_Categoria).Select(x => x.Revendedor2).FirstOrDefault();
                                produto.Total = produto.Subtotal - (produto.Subtotal / 100 * percentual);
                                produto.Desconto = produto.Subtotal - produto.Total;
                                break;
                            case "Revendedor3":
                                percentual = pai.Categorias.Where(x => x.ID_Categoria == produto.ID_Categoria).Select(x => x.Revendedor3).FirstOrDefault();
                                produto.Total = produto.Subtotal - (produto.Subtotal / 100 * percentual);
                                produto.Desconto = produto.Subtotal - produto.Total;
                                break;
                        }
                    }
                }
            }
        }

        #endregion

        public void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            dataGridViewLista.Rows.Clear();

            var lista = pai.Produtos.GroupBy(x => (x.Codigo, x.Produto, x.Preco)).Select(g => (g.Key.Codigo, g.Key.Produto, g.Key.Preco, Quantidade: g.Sum(x => x.Quantidade), Subtotal: g.Sum(x => x.Subtotal), Desconto: g.Sum(x => x.Desconto), Total: g.Sum(x => x.Total)));

            foreach (var Produto in lista)
            {
                dataGridViewLista.Rows.Add(Produto.Codigo, Produto.Produto, Produto.Preco.ToString("C"), Produto.Quantidade, Produto.Subtotal.ToString("C"), Produto.Desconto.ToString("C"), Produto.Total.ToString("C"));
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;

            decimal total = pai.Produtos.Sum(x => x.Total);
            decimal subtotal = pai.Produtos.Sum(x => x.Subtotal);
            decimal desconto = pai.Produtos.Sum(x => x.Desconto);
            decimal percentutal;
            try { percentutal = desconto / (subtotal / 100); }
            catch { percentutal = 0; }


            textBoxProdutos.Text = pai.Produtos.Count().ToString();
            labelSubtotal.Text = subtotal.ToString("C");
            labelDesconto.Text = desconto.ToString("C");
            labelTotal.Text = total.ToString("C");

            if (percentutal > 0)
            {
                labelOff.Visible = true;
                labelOff.Text = comandos.ConverterDecimalEmPercentual(percentutal) + " OFF";
            }
            else
            {
                labelOff.Visible = false;
            }
        }

        public void VerificarTabela()
        {
            decimal total = pai.Produtos.Sum(x => x.Total);
        }

        private void buttonConcluir_Click(object sender, EventArgs e)
        {
            ComandosSQL comando = new ComandosSQL();
            int qtd_produtos = pai.Produtos.Count;

            if (radioButtonVenda.Checked)
            {
                pai.tipo_de_venda = "Venda";
            }
            else if (radioButtonRetirar.Checked)
            {
                pai.tipo_de_venda = "Retirar";
            }
            else if (radioButtonReserva.Checked)
            {
                pai.tipo_de_venda = "Reserva";
            }
            else if (radioButtonEntrega.Checked)
            {
                pai.tipo_de_venda = "Entrega";
            }

            if (qtd_produtos == 0)
            {
                MessageBox.Show("Informe os produtos para concluir a venda!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxProduto.Focus();
            }
            else
            {
                if (pai.tipo_de_venda == "Reserva")
                {
                    if (textBoxCliente.Text == "Consumidor Final")
                    {
                        MessageBox.Show("É necessário selecionar um cliente\r\npara concluir a reserva!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("A opção 'Reservar' está marcada.\r\nDeseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            comando.RegistrarReserva(pai.cliente.CPF);
                            comando.RegistrarProdutosReserva(pai.cliente.CPF, pai.Produtos);
                            LimparInformacoes();
                            MessageBox.Show("pai.Produtos reservados com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            comando.ImprimirCupomReserva();
                        }
                    }
                }
                else
                {
                    if (pai.tipo_de_venda == "Entrega" || pai.tipo_de_venda == "Retirar")
                    {
                        if (textBoxCliente.Text == "Consumidor Final" && pai.tipo_de_venda == "Entrega")
                        {
                            MessageBox.Show("É necessário escolher o cliente quando\r\na opção 'Agendar Entrega' estiver marcada.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (textBoxCliente.Text == "Consumidor Final" && pai.tipo_de_venda == "Retirar")
                        {
                            MessageBox.Show("É necessário escolher o cliente quando\r\na opção 'Retirar Posteriormente' estiver marcada.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (pai.tipo_de_venda == "Entrega")
                            {
                                if (DialogResult.Yes == MessageBox.Show("A opção 'Agendar Entrega' está marcada.\r\nDeseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                                {
                                    Venda Venda = new Venda() { Tipo = pai.tipo_de_venda, CPF_Cliente = pai.cliente.CPF, Operador = pai.operador, Produtos = pai.Produtos };

                                    formVendasPDVPagamentos pagamento = new formVendasPDVPagamentos(this);
                                    pagamento.ShowDialog();
                                    if (venda)
                                    {
                                        LimparInformacoes();
                                        //entrega_agendada = true;
                                        decimal prazo = comando.ObterValorDoParametro("Prazo de Entrega");
                                        string data_entrega = DateTime.Now.AddDays(Convert.ToInt32(prazo)).ToShortDateString();

                                        if (imprimir_cupom)
                                        {
                                            comando.ImprimirCupom();
                                            comando.ImprimirCupomEntrega();
                                        }
                                    }
                                }
                            }
                            else if (pai.tipo_de_venda == "Retirar")
                            {
                                if (DialogResult.Yes == MessageBox.Show("A opção 'Retirar posteriormente' está marcada.\r\nDeseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                                {
                                    Venda Venda = new Venda() { Tipo = pai.tipo_de_venda, CPF_Cliente = pai.cliente.CPF, Operador = pai.operador, Produtos = pai.Produtos };

                                    formVendasPDVPagamentos pagamento = new formVendasPDVPagamentos(this);
                                    pagamento.ShowDialog();
                                    if (venda)
                                    {
                                        LimparInformacoes();
                                        //retirada_concluida = true;
                                        decimal prazo = comando.ObterValorDoParametro("Prazo de Retirada");
                                        string data_entrega = DateTime.Now.AddDays(Convert.ToInt32(prazo)).ToShortDateString();

                                        if (imprimir_cupom)
                                        {
                                            comando.ImprimirCupom();
                                            comando.ImprimirCupomRetirada();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Venda Venda = new Venda() { Tipo = pai.tipo_de_venda, CPF_Cliente = pai.cliente.CPF, Operador = pai.operador, Produtos = pai.Produtos };

                        formVendasPDVPagamentos pagamento = new formVendasPDVPagamentos(this);
                        pagamento.ShowDialog();
                        if (venda)
                        {
                            //venda_concluida = true;

                            if (imprimir_cupom)
                            {
                                //comando.ImprimirCupom();

                                comando.ImprimirCupomAlternativo(pai.Produtos, pai.Pagamentos, pai.cliente);
                            }

                            LimparInformacoes();
                        }
                    }
                }

                textBoxProduto.Focus();

                if (venda)
                {
                    string faixa = VerificarFaixaDeDesconto(0);
                    RecalcularDescontoDeTodosOsProdutos(faixa);
                }

                AtualizarDataGrid();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if (dataGridViewLista.Rows.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja cancelar a venda?", "Cancelar venda", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    LimparInformacoes();
                }
            }
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //formVendasPDVDigital digital = new formVendasPDVDigital(this);
            //digital.ShowDialog();

            formVendasPDVConfirmacao confirmacao = new formVendasPDVConfirmacao(this, "Desconto individual por produto");
            confirmacao.ShowDialog();

            if (concessao)
            {
                concessao = false;

                try
                {
                    string codigo = dataGridViewLista[0, e.RowIndex].Value.ToString();
                    ProdutoVenda produto = pai.Produtos.Where(x => x.Codigo == codigo).FirstOrDefault();

                    formVendasPDVDescontoProduto formDescontoProduto = new formVendasPDVDescontoProduto(this, produto);
                    formDescontoProduto.ShowDialog();
                }
                catch { }
            }
        }

        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string codigo = dataGridViewLista[0, e.RowIndex].Value.ToString();
            bool promocao = pai.Produtos.Where(x => x.Codigo == codigo).Select(i => i.Promocao).FirstOrDefault();

            if (promocao)
            {
                dataGridViewLista[0, e.RowIndex].Style.SelectionForeColor = Color.Chocolate;
                dataGridViewLista[0, e.RowIndex].Style.ForeColor = Color.Gold;
                dataGridViewLista[1, e.RowIndex].Style.SelectionForeColor = Color.Chocolate;
                dataGridViewLista[1, e.RowIndex].Style.ForeColor = Color.Gold;
            }
        }


        #region Instanciar Formulários

        private void buttonClientes_Click(object sender, EventArgs e)
        {
            formVendasPDVClientes clientes = new formVendasPDVClientes(this);
            clientes.ShowDialog();

            string faixa = VerificarFaixaDeDesconto(0);

            pai.faixa_atual = faixa;
            RecalcularDescontoDeTodosOsProdutos(faixa);

            AtualizarDataGrid();
        }
        private void buttonDescontos_Click(object sender, EventArgs e)
        {
            formVendasPDVConfirmacao confirmacao = new formVendasPDVConfirmacao(this, "Desconto total da venda");
            confirmacao.ShowDialog();

            if (concessao)
            {
                concessao = false;
                formVendasPDVDescontos descontos = new formVendasPDVDescontos(this);
                descontos.ShowDialog();

                AtualizarDataGrid();
            }
        }
        private void buttonReservas_Click(object sender, EventArgs e)
        {
            formVendasPDVReservas preVenda = new formVendasPDVReservas(this);
            preVenda.ShowDialog();
        }
        private void buttonRetiradas_Click(object sender, EventArgs e)
        {
            formVendasPDVRetiradas retiradas = new formVendasPDVRetiradas(pai.operador);
            retiradas.ShowDialog();
        }
        private void buttonEntregas_Click(object sender, EventArgs e)
        {
            formVendasPDVEntregas entregas = new formVendasPDVEntregas();
            entregas.ShowDialog();
        }
        private void buttonSimular_Click(object sender, EventArgs e)
        {
            decimal Subtotal = pai.Produtos.Cast<ProdutoVenda>().Sum(i => i.Subtotal);
            formVendasPDVSimulacao simulacao = new formVendasPDVSimulacao(Subtotal, this);
            simulacao.ShowDialog();
        }
        private void buttonTroca_Click(object sender, EventArgs e)
        {
            formVendasPDVTrocas troca = new formVendasPDVTrocas(pai.operador);
            troca.ShowDialog();
        }

        #endregion

        #region Métodos do Formulário

        public void ValorTotal()
        {
            //VerificarValorTotal
            decimal colunaTotal;
            int quantidadeProdutos;
            decimal colunaDesconto;
            decimal colunaSubtotal;
            decimal off;
            try
            {
                colunaTotal = pai.Produtos.Cast<ProdutoVenda>().Sum(i => i.Total);
                quantidadeProdutos = pai.Produtos.Cast<ProdutoVenda>().Sum(i => i.Quantidade);
                colunaDesconto = pai.Produtos.Cast<ProdutoVenda>().Sum(i => i.Desconto);
                colunaSubtotal = pai.Produtos.Cast<ProdutoVenda>().Sum(i => i.Subtotal);
                off = (colunaDesconto * 100) / colunaTotal;
            }
            catch
            {
                colunaTotal = 0;
                quantidadeProdutos = 0;
                colunaDesconto = 0;
                colunaSubtotal = 0;
                off = 0;
            }

            labelSubtotal.Text = colunaTotal.ToString("C");
            textBoxProdutos.Text = quantidadeProdutos.ToString();
            labelTotal.Text = colunaSubtotal.ToString("C");
            labelDesconto.Text = colunaDesconto.ToString("C");
        }

        public void AplicarCombos()
        {
            foreach (Combo Combo in pai.Combos)
            {
                int registros = pai.Produtos.Where(x => x.ID_Combo == Combo.ID_Combo).Count();

                int multiplicador = Combo.Multiplicador;
                int quantidade_registrada = Combo.Quantidade;

                int quantidade_combos = registros / multiplicador;
                int quantidade_contemplada = quantidade_combos * multiplicador;


                if (quantidade_contemplada != quantidade_registrada)
                {
                    int i = 0;

                    foreach (ProdutoVenda produto in pai.Produtos)
                    {
                        if (produto.ID_Combo == Combo.ID_Combo && i < quantidade_contemplada)
                        {
                            produto.Total = Combo.Preco;
                            produto.Desconto = produto.Subtotal - produto.Total;
                            produto.Promocao = true;
                            i++;
                        }
                        else
                        {
                            produto.Total = produto.Subtotal;
                            produto.Desconto = produto.Subtotal - produto.Total;
                            produto.Promocao = false;
                        }
                    }

                    Combo.Quantidade = quantidade_contemplada;
                }
            }
        }



        private void LimparInformacoes()
        {
            radioButtonVenda.Checked = true;
            pai.ClienteGenerico();
            textBoxCliente.Text = pai.cliente.Nome;
            pai.Produtos.Clear();
            pai.Pagamentos.Clear();
            pai.Vales.Clear();
            pai.desconto = 0;
            venda = false;

            textBoxProduto.Focus();
        }

        #endregion;        

        private void formVendasPDV_Resize(object sender, EventArgs e)
        {
            labelCaixaFechado.Left = (panel4.Width / 2) - (labelCaixaFechado.Width / 2);
        }

        private void textBoxProduto_Resize(object sender, EventArgs e)
        {
            Refresh();
        }

        private void formVendasPDV_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                buttonConcluir_Click(sender, e);
                e.Handled = true;
            }

            if (e.KeyCode == Keys.F3)
            {
                buttonCancelar_Click(sender, e);
                e.Handled = true;
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (codigo != string.Empty)
            {
                ProdutoVenda produto = pai.Produtos.Where(x => x.Codigo == codigo).FirstOrDefault();
                pai.Produtos.Remove(produto);

                string faixa = VerificarFaixaDeDesconto(0);
                RecalcularDescontoDeTodosOsProdutos(faixa);

                AplicarCombos();
                AtualizarDataGrid();
            }
        }

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    codigo = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
                else
                {
                    codigo = string.Empty;
                }
            }
        }

        private void checkBoxCupom_CheckedChanged(object sender, EventArgs e)
        {
            pai.imprimir_cupom = checkBoxCupom.Checked;
        }

        private void formVendasPDV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42)
            {
                try
                {
                    int quantidade = Convert.ToInt32(textBoxProduto.Text);
                    e.Handled = true;
                    textBoxQtd.Text = quantidade.ToString();

                    textBoxProduto.Clear();
                }
                catch
                {

                }
            }
        }

        private void apagarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (codigo != string.Empty)
            {
                pai.Produtos.RemoveAll(x => x.Codigo == codigo);

                string faixa = VerificarFaixaDeDesconto(0);
                RecalcularDescontoDeTodosOsProdutos(faixa);

                AplicarCombos();
                AtualizarDataGrid();
            }
        }
    }
}
