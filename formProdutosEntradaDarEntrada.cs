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
    public partial class formProdutosEntradaDarEntrada : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        string produto;
        string fornecedor;
        int id_pedido;

        decimal multiplicador = 1;
        decimal aliquota_ICMS;
        decimal aliquota_IPI;
        decimal base_custo;
        int quantidade = 0;

        public List<ProdutoEntrada> Produtos_Fornecedor;
        public List<ProdutoEntrada> Produtos_Entrada = new List<ProdutoEntrada>();
        public List<Produto_Lote> Variacoes = new List<Produto_Lote>();
        public List<Produto_Lote> Lote = new List<Produto_Lote>();

        bool produto_ativo;
        public string codigo;
        public bool alteracao;
        int id_localizacao;

        public formProdutosEntradaDarEntrada()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        public formProdutosEntradaDarEntrada(string Fornecedor, int ID_Pedido)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            fornecedor = Fornecedor;
            id_pedido = ID_Pedido;
        }
        public formProdutosEntradaDarEntrada(string Fornecedor)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            fornecedor = Fornecedor;
        }
        private void formProdutosDarEntrada_Load(object sender, EventArgs e)
        {
            id_localizacao = Convert.ToInt32(comandos.ObterValorDoParametro("Localização padrão da entrada"));

            dataGridViewLista.Rows.Clear();

            produtoTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            Produtos_Fornecedor = comandos.ListaDeProdutosDisponiveisParaEntrada(fornecedor);
            Variacoes = comandos.ListaDeVariacoesDisponiveisParaEntrada(fornecedor);

            AutoCompleteStringCollection colecao = new AutoCompleteStringCollection();

            foreach (ProdutoEntrada Produto in Produtos_Fornecedor)
            {
                if (Produto.ID_Conjunto != 0)
                {
                    colecao.Add(Produto.Nome_Conjunto);
                }
                else
                {
                    colecao.Add(Produto.Nome_Produto);
                }
            }

            produtoTextBox.AutoCompleteCustomSource = colecao;
            label12.Text = "ENTRADA DE PRODUTOS - " + fornecedor;
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            bool continuar = false;

            if (produtoTextBox.Text == string.Empty)
            {
                MessageBox.Show("Informe o nome do Produto para adicionar à lista!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!produto_ativo)
            {
                MessageBox.Show("Informe um Produto válido para adicionar à lista!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Produtos_Entrada.Any(x => x.Cod_Barras == codigo))
            {
                MessageBox.Show("Esse produto já foi adicionado à lista!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);           
            }
            else
            {
                if (quantidadeTextBox.Text == "0")
                {
                    MessageBox.Show("Informe a Quantidade!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    continuar = true;
                }
            }
            
            if (continuar)
            {
                string conjunto = string.Empty;
                string produto = this.produto;
                string tipo = Produtos_Fornecedor.Where(x => x.Cod_Barras == codigo).Select(x => x.Tipo).FirstOrDefault();
                int id_produto = Produtos_Fornecedor.Where(x => x.Cod_Barras == codigo).Select(x => x.ID_Produto).FirstOrDefault();
                int id_conjunto = Produtos_Fornecedor.Where(x => x.Cod_Barras == codigo).Select(x => x.ID_Conjunto).FirstOrDefault();
                string cod_extra = Produtos_Fornecedor.Where(x => x.Cod_Barras == codigo).Select(x => x.Cod_Extra).FirstOrDefault();
                int quantidade = this.quantidade;
                decimal base_custo = this.base_custo;

                int quantidade_produtos = Produtos_Fornecedor.Where(x => x.Cod_Barras == codigo).Select(x => x.Qtd_Produtos).FirstOrDefault();

                if (id_conjunto != 0)
                {
                    conjunto = produto;
                    produto = Produtos_Fornecedor.Where(x => x.Cod_Barras == codigo).Select(x => x.Nome_Produto).FirstOrDefault();
 
                }

                Produtos_Entrada.Add(new ProdutoEntrada
                {
                    ID_Produto = id_produto,
                    ID_Conjunto = id_conjunto,
                    Nome_Conjunto = conjunto,
                    Nome_Produto = produto,
                    Cod_Barras = codigo,
                    Cod_Extra = cod_extra,
                    Preco_Base = base_custo,
                    Aliquota_ICMS = aliquota_ICMS,
                    Aliquota_IPI = aliquota_IPI,
                    Quantidade = quantidade,
                    Qtd_Produtos = quantidade_produtos,
                    Tipo = tipo
                });

                if (id_conjunto != 0)
                {
                    quantidade = quantidade * quantidade_produtos;
                    base_custo = base_custo / quantidade_produtos;
                }

                if (Variacoes.Where(x => x.ID_Produto == id_produto).Any(x => x.Cor == "SORTIDO"))
                {
                    produto = Variacoes.Where(x => x.ID_Produto == id_produto && x.Cor == "SORTIDO").Select(x => x.Nome_Produto).FirstOrDefault();
                    int id = Variacoes.Where(x => x.ID_Produto == id_produto && x.Cor == "SORTIDO").Select(x => x.ID_ProdutoVariacao).FirstOrDefault();
                    int id_capsula = Variacoes.Where(x => x.ID_Produto == id_produto && x.Cor == "SORTIDO").Select(x => x.ID_Capsula).FirstOrDefault();
                    string codbarras = Variacoes.Where(x => x.ID_Produto == id_produto && x.Cor == "SORTIDO").Select(x => x.Cod_Barras).FirstOrDefault();
                    string acabamento = Variacoes.Where(x => x.ID_Produto == id_produto && x.Cor == "SORTIDO").Select(x => x.Acabamento).FirstOrDefault();
                    bool imprimir_codigo = Variacoes.Where(x => x.ID_Produto == id_produto && x.Cor == "SORTIDO").Select(x => x.Imprimir_Codigo).FirstOrDefault();

                    decimal venda;
                    if (Variacoes.Where(x => x.ID_Produto == id_produto && x.Cor == "SORTIDO").Select(x => x.Promocao).FirstOrDefault())
                    {
                        venda = Variacoes.Where(x => x.ID_Produto == id_produto && x.Cor == "SORTIDO").Select(x => x.Preco_Promocional).FirstOrDefault();
                    }
                    else
                    {
                        venda = Variacoes.Where(x => x.ID_Produto == id_produto && x.Cor == "SORTIDO").Select(x => x.Preco_Venda).FirstOrDefault();
                    }


                    for (int i = 0; i < quantidade; i++)
                    {
                        Lote.Add(new Produto_Lote
                        {
                            ID_Capsula = id_capsula,
                            ID_Produto = id_produto,
                            ID_ProdutoVariacao = id,
                            Nome_Produto = produto,
                            Fornecedor = fornecedor,
                            Quantidade = 1,
                            Preco_Base = base_custo,
                            Preco_Venda = venda,
                            Cod_Extra = cod_extra,
                            Cod_Barras = codbarras,
                            Acabamento = acabamento,
                            Imprimir_Codigo = imprimir_codigo,
                            Aliquota_ICMS = aliquota_ICMS,
                            Aliquota_IPI = aliquota_IPI,
                            ID_Localizacao = id_localizacao
                        });
                    }
                }
                else
                {
                    int quantidade_de_variacoes = Variacoes.Where(x => x.ID_Produto == id_produto).Count();

                    int quantidade_por_variacao = quantidade / quantidade_de_variacoes;

                    //Caso a quantidade atribuída não seja divisível pela quantidade inserida
                    int sobra = quantidade % quantidade_de_variacoes;
                    bool definir_sobra = false;

                    int id_capsula = Variacoes.Where(x => x.ID_Produto == id_produto).Select(x => x.ID_Capsula).FirstOrDefault();

                    decimal venda;
 

                    foreach (Produto_Lote Variacao in Variacoes)
                    {
                        if (Variacao.ID_Produto == id_produto)
                        {
                            if (Variacao.Promocao)
                            {
                                venda = Variacao.Preco_Promocional;
                            }
                            else
                            {
                                venda = Variacao.Preco_Venda;
                            }

                            int id = Variacao.ID_ProdutoVariacao;
                            produto = Variacao.Nome_Produto;
                            string codbarras = Variacao.Cod_Barras;
                            string acabamento = Variacao.Acabamento;
                            bool imprimir_codigo = Variacao.Imprimir_Codigo;

                            int repeticoes;

                            if (sobra > 0 && !definir_sobra)
                            {
                                repeticoes = quantidade_por_variacao + sobra;
                                definir_sobra = true;
                            }
                            else
                            {
                                repeticoes = quantidade_por_variacao;
                            }

                            for (int i = 0; i < repeticoes; i++)
                            {
                                Lote.Add(new Produto_Lote
                                {
                                    ID_Capsula = id_capsula,
                                    ID_Produto = id_produto,
                                    ID_ProdutoVariacao = id,
                                    Nome_Produto = produto,
                                    Fornecedor = fornecedor,
                                    Quantidade = 1,
                                    Preco_Base = base_custo,
                                    Preco_Venda = venda,
                                    Cod_Extra = cod_extra,
                                    Cod_Barras = codbarras,
                                    Acabamento = acabamento,
                                    Imprimir_Codigo = imprimir_codigo,
                                    Aliquota_ICMS = aliquota_ICMS,
                                    Aliquota_IPI = aliquota_IPI,
                                    ID_Localizacao = id_localizacao
                                });
                            }
                        }
                    }
                }

                if (dataGridViewLista.CurrentRow != null)
                    dataGridViewLista.CurrentRow.Selected = false;
                produtoTextBox.Text = string.Empty;

                LimparInformacoes();
                CalcularInformacoesFinanceiras();
                PreencherDataGrid();
            }
        }

        private void LimparInformacoes()
        {
            quantidade = 0;
            base_custo = 0;
            quantidadeTextBox.Text = "0";
            baseTextBox.Text = "R$0,00";
            aliquota_IPI = 0;
            aliquota_ICMS = 0;
            AliquotaIPITextBox.Text = "0,00%";
            AliquotaICMSTextBox.Text = "0,00%";
            produto = string.Empty;
            produtoTextBox.Focus();
        }

        private void buttonFinalizar_Click(object sender, EventArgs e)
        {
            bool reajuste = false;

            foreach (ProdutoEntrada Produto in Produtos_Entrada) //Analisar se houve algum reajuste
            {
                int id_produto = Produto.ID_Produto;
                string produto = Produto.Nome_Produto;

                decimal custo_antigo = Produtos_Fornecedor.Where(x => x.ID_Produto == id_produto).Select(x => x.Preco_Base + (x.Preco_Base / 100 * x.Aliquota_ICMS) + (x.Preco_Base / 100 * x.Aliquota_IPI)).FirstOrDefault();
                decimal custo_novo = Produto.Preco_Base + (Produto.Preco_Base / 100 * Produto.Aliquota_ICMS) + (Produto.Preco_Base / 100 * Produto.Aliquota_IPI);
                decimal valor_reajuste = Math.Round(custo_novo - custo_antigo, 2);

                if (valor_reajuste != 0)
                    reajuste = true;
            }

            bool permitir = false;

            if (id_pedido != 0)
            {
                decimal valor_total = Produtos_Entrada.Sum(x => x.Quantidade * x.Preco_Base + (x.Preco_Base / 100 * x.Aliquota_ICMS) + (x.Preco_Base / 100 * x.Aliquota_IPI));
                decimal valor_esperado = comandos.TrazerValorDoPedido(id_pedido);

                if (valor_total == valor_esperado)
                {
                    permitir = true;
                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show("O valor dos produtos é diferente do valor esperado.\r\nDeseja continuar mesmo assim?\r\nValor Esperado: " + valor_esperado.ToString("C"), "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                        permitir = true;
                }
            }
            else
            {
                permitir = true;
            }

            if (reajuste && permitir)
            {
                if (DialogResult.Yes == MessageBox.Show("O sistema identificou reajuste(s) entre os produtos listados\r\nDeseja analisar os reajustes antes de concluir a entrada?", "Reajustes!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    formProdutosEntradaReajustes reajustes = new formProdutosEntradaReajustes(this);
                    reajustes.ShowDialog();
                }
            }

            if (permitir)
            {
                Entrada entrada = new Entrada 
                { 
                    Analise = false, 
                    ID_Pedido = id_pedido, 
                    Fornecedor = fornecedor 
                };
                comandos.DarEntrada(entrada, Lote, Produtos_Entrada);

                int quantidade_etiquetas = Lote.Where(x => x.Imprimir_Codigo).Sum(x => x.Quantidade);

                if (quantidade_etiquetas > 0)
                {                    
                    int paginas = Convert.ToInt32(quantidade_etiquetas / comandos.ObterValorDoParametro("Quantidade de etiquetas por folha do código de barras"));
                    if (quantidade_etiquetas % comandos.ObterValorDoParametro("Quantidade de etiquetas por folha do código de barras") > 0) 
                    { paginas++; }

                    if (DialogResult.OK == MessageBox.Show("Para concluir a entrada, coloque " + paginas + " páginas A4350 na impressora e clique em \"Ok\".\r\nTotal de etiquetas: " + quantidade_etiquetas, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information))
                    {
                        List<ProdutoEtiqueta> etiquetas = new List<ProdutoEtiqueta>();

                        foreach (Produto_Lote Produto in Lote)
                        {
                            if (Produto.Imprimir_Codigo)
                            {
                                string produto =  comandos.NomeDoPreco(Produto.ID_ProdutoVariacao);
                                string cod_barras = Produto.Cod_Barras;
                                string cod_128 = comandos.ConverterStringParaCod128(cod_barras.ToString());

                                etiquetas.Add(new ProdutoEtiqueta
                                {
                                    Produto = produto,
                                    Venda = Produto.Preco_Venda.ToString("C"),
                                    Codigo = cod_barras,
                                    Codigo128 = cod_128
                                });
                            }
                        }
                        formProdutosDarEntradaImprimir imprimir = new formProdutosDarEntradaImprimir(etiquetas);
                        imprimir.ShowDialog();
                    }
                }
                Dispose();
            }            
        }

        private void buttonReajustes_Click(object sender, EventArgs e)
        {
            formProdutosEntradaReajustes reajustes = new formProdutosEntradaReajustes(this);
            reajustes.ShowDialog();
            PreencherDataGrid();
        }

        private void PreencherDataGrid()
        {
            dataGridViewLista.Rows.Clear();
            foreach (ProdutoEntrada Produto in Produtos_Entrada)
            {
                string produto;

                if (Produto.ID_Conjunto != 0)
                {
                    produto = Produto.Nome_Conjunto;
                }
                else
                {
                    produto = Produto.Nome_Produto;
                }

                int id_produto = Produto.ID_Produto;

                int quantidade = Produto.Quantidade;
                string cod_extra = Produto.Cod_Extra;

                decimal preco_base = Produto.Preco_Base;
                decimal aliquota_ipi = Produto.Aliquota_IPI;
                decimal aliquota_icms = Produto.Aliquota_ICMS;

                decimal custo = preco_base + (preco_base / 100 * aliquota_ipi) + (preco_base / 100 * aliquota_icms);
                decimal total = custo * quantidade;
                dataGridViewLista.Rows.Add(id_produto, cod_extra, produto, custo.ToString("C"), quantidade, total.ToString("C"));
            }

            decimal valor_total = Produtos_Entrada.Cast<ProdutoEntrada>().Sum(x => (x.Preco_Base + (x.Preco_Base / 100 * x.Aliquota_IPI) + (x.Preco_Base / 100 * x.Aliquota_ICMS)) * x.Quantidade);
            int quantidade_produtos = Produtos_Entrada.Cast<ProdutoEntrada>().Count();
            valorTotalTextBox.Text = valor_total.ToString("C");
            nprodutosTextBox.Text = quantidade_produtos.ToString();

            //dataGridViewLista.Rows.Clear();
            //foreach (Produto_Lote Produto in Lote)
            //{
            //    int id_produto = Produto.ID_ProdutoVariacao;
            //    string produto = Produto.Nome_Produto;
            //    int quantidade = Produto.Quantidade;
            //    string cod_extra = Produto.Cod_Extra;

            //    decimal preco_base = Produto.Preco_Base;
            //    decimal aliquota_ipi = Produto.Aliquota_IPI;
            //    decimal aliquota_icms = Produto.Aliquota_ICMS;

            //    decimal custo = preco_base + (preco_base / 100 * aliquota_ipi) + (preco_base / 100 * aliquota_icms);
            //    decimal total = custo * quantidade;
            //    dataGridViewLista.Rows.Add(id_produto, cod_extra, produto, custo.ToString("C"), quantidade, total.ToString("C"));
            //}

            //decimal valor_total = Produtos_Entrada.Cast<ProdutoEntrada>().Sum(x => x.Preco_Base + (x.Preco_Base / 100 * x.Aliquota_IPI) + (x.Preco_Base / 100 * x.Aliquota_ICMS) * x.Quantidade);
            //int quantidade_produtos = Produtos_Entrada.Cast<ProdutoEntrada>().Count();
            //valorTotalTextBox.Text = valor_total.ToString("C");
            //nprodutosTextBox.Text = quantidade_produtos.ToString();
        }

        private void CalcularInformacoesFinanceiras()
        {
            decimal ipi = Math.Round(base_custo * aliquota_IPI / 100, 2);
            decimal icms = Math.Round(base_custo * aliquota_ICMS / 100, 2);
            decimal custo = base_custo * multiplicador + ipi + icms;

            decimal total = custo * quantidade;

            ipiTextBox.Text = ipi.ToString("C");
            icmsTextBox.Text = icms.ToString("C");
            CustoTextBox.Text = custo.ToString("C");
            totalTextBox.Text = total.ToString("C");
        }

        #region Formatação
        private void produtoTextBox_Leave(object sender, EventArgs e)
        {
            if (produto == string.Empty)
            {
                produto_ativo = false;
                panelProduto.Visible = true;
            }
            if (produto != produtoTextBox.Text)
            {
                produto = produtoTextBox.Text;

                bool produto_encontrado = Produtos_Fornecedor.Any(x => x.Nome_Produto == produto); //Se o produto encontrado é um produto simples
                bool conjunto_encontrado = Produtos_Fornecedor.Any(x => x.Nome_Conjunto == produto); //Se o produto encontrado é um conjunto

                if (produto_encontrado || conjunto_encontrado)
                {                    
                    int produtos_encontrados = Produtos_Fornecedor.Count(x => x.Nome_Produto == produto); 
                    int conjuntos_encontrados = Produtos_Fornecedor.Count(x => x.Nome_Conjunto == produto);
                    int registros = produtos_encontrados + conjuntos_encontrados;

                    if (registros == 1) //Se encontrou apenas um registro
                    {
                        produto_ativo = true;
                        ProdutoEntrada Produto;

                        if (produto_encontrado)
                        {
                            Produto = Produtos_Fornecedor.Where(x => x.Nome_Produto == produto).FirstOrDefault();
                        }
                        else
                        {
                            Produto = Produtos_Fornecedor.Where(x => x.Nome_Conjunto == produto).FirstOrDefault();
                        }


                        base_custo = Produto.Preco_Base;
                        aliquota_ICMS = Produto.Aliquota_ICMS;
                        aliquota_IPI = Produto.Aliquota_IPI;
                        codigo = Produto.Cod_Barras;

                        AliquotaICMSTextBox.Text = aliquota_ICMS.ToString("F") + "%";
                        AliquotaIPITextBox.Text = aliquota_IPI.ToString("F") + "%";
                        baseTextBox.Text = base_custo.ToString("C");
                        CalcularInformacoesFinanceiras();
                        panelProduto.Visible = false;
                    }
                    else //Se encontrou mais de um registro
                    {
                        formProdutosDarEntradaRepetido repetido = new formProdutosDarEntradaRepetido(produto, Produtos_Fornecedor, this);
                        repetido.ShowDialog();

                        if (alteracao)
                        {
                            alteracao = false;
                            produto_ativo = true;
                            ProdutoEntrada Produto = Produtos_Fornecedor.Where(x => x.Cod_Barras == codigo).FirstOrDefault();
                            base_custo = Produto.Preco_Base;
                            aliquota_ICMS = Produto.Aliquota_ICMS;
                            aliquota_IPI = Produto.Aliquota_IPI;

                            AliquotaICMSTextBox.Text = aliquota_ICMS.ToString("F") + "%";
                            AliquotaIPITextBox.Text = aliquota_IPI.ToString("F") + "%";
                            baseTextBox.Text = base_custo.ToString("C");
                            CalcularInformacoesFinanceiras();
                            panelProduto.Visible = false;
                        }
                        else
                        {
                            produto_ativo = false;
                            panelProduto.Visible = true;
                            baseTextBox.Text = "R$0,00";
                            ipiTextBox.Text = "R$0,00";
                            icmsTextBox.Text = "R$0,00";
                            CustoTextBox.Text = "R$0,00";
                        }
                    }
                }
                else
                {
                    produto_ativo = false;
                    panelProduto.Visible = true;
                    baseTextBox.Text = "R$0,00";
                    ipiTextBox.Text = "R$0,00";
                    icmsTextBox.Text = "R$0,00";
                    CustoTextBox.Text = "R$0,00";
                }
            }
        }
        private void quantidadeTextBox_Leave(object sender, EventArgs e)
        {
            if (quantidadeTextBox.Text == string.Empty)
            {
                quantidadeTextBox.Text = "0";
                quantidade = 0;
            }
            else
            {
                quantidade = Convert.ToInt32(quantidadeTextBox.Text);
                CalcularInformacoesFinanceiras();
            }
        }
        private void quantidadeTextBox_Enter(object sender, EventArgs e)
        {
            if (quantidadeTextBox.Text == "0")
            {
                quantidadeTextBox.Text = string.Empty;
            }
        }
        private void quantidadeTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                quantidade = Convert.ToInt32(quantidadeTextBox.Text);
                CalcularInformacoesFinanceiras();
            }
            catch{}           
        }
        private void quantidadeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
        private void produtoTextBox_Enter(object sender, EventArgs e)
        {
            panelProduto.Visible = false;
        }
        private void AliquotaIPITextBox_Enter(object sender, EventArgs e)
        {
            if (AliquotaIPITextBox.Text == "0,00%")
            {
                AliquotaIPITextBox.Text = string.Empty;
            }
            else
            {
                string[] partir = AliquotaIPITextBox.Text.Split('%');
                AliquotaIPITextBox.Text = partir[0];
            }
        }
        private void AliquotaICMSTextBox_Enter(object sender, EventArgs e)
        {
            if (AliquotaICMSTextBox.Text == "0,00%")
            {
                AliquotaICMSTextBox.Text = string.Empty;
            }
            else
            {
                string[] partir = AliquotaICMSTextBox.Text.Split('%');
                AliquotaICMSTextBox.Text = partir[0];
            }
        }
        private void baseTextBox_Enter(object sender, EventArgs e)
        {
            if (baseTextBox.Text == "R$0,00")
            {
                baseTextBox.Text = string.Empty;
            }
            else
            {
                string[] partir = baseTextBox.Text.Split('$');
                baseTextBox.Text = partir[1];
            }
        }
        private void baseTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
(e.KeyChar != ',' && e.KeyChar != '.' &&
e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!baseTextBox.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (Char)0;
                    }
                }
            }
        }
        private void baseTextBox_Leave(object sender, EventArgs e)
        {
            if (baseTextBox.Text == string.Empty)
            {
                baseTextBox.Text = "R$0,00";
                base_custo = 0;
            }
            else
            {
                base_custo = Convert.ToDecimal(baseTextBox.Text);
                baseTextBox.Text = base_custo.ToString("C");
            }
            CalcularInformacoesFinanceiras();
        }
        private void AliquotaIPITextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
(e.KeyChar != ',' && e.KeyChar != '.' &&
e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!AliquotaIPITextBox.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (Char)0;
                    }
                }
            }
        }
        private void AliquotaIPITextBox_Leave(object sender, EventArgs e)
        {
            if (AliquotaIPITextBox.Text == string.Empty)
            {
                AliquotaIPITextBox.Text = "0,00%";
                aliquota_IPI = 0;
            }
            else
            {
                aliquota_IPI = Convert.ToDecimal(AliquotaIPITextBox.Text);
                AliquotaIPITextBox.Text = aliquota_IPI.ToString("F") + "%";
            }
            CalcularInformacoesFinanceiras();
        }
        private void AliquotaICMSTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
(e.KeyChar != ',' && e.KeyChar != '.' &&
e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!AliquotaICMSTextBox.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (Char)0;
                    }
                }
            }
        }
        private void AliquotaICMSTextBox_Leave(object sender, EventArgs e)
        {
            if (AliquotaICMSTextBox.Text == string.Empty)
            {
                AliquotaICMSTextBox.Text = "0,00%";
                aliquota_ICMS = 0;
            }
            else
            {
                aliquota_ICMS = Convert.ToDecimal(AliquotaICMSTextBox.Text);
                AliquotaICMSTextBox.Text = aliquota_ICMS.ToString("F") + "%";
            }
            CalcularInformacoesFinanceiras();
        }
        private void MultiplicadorTextBox_Enter(object sender, EventArgs e)
        {
            string[] partir = MultiplicadorTextBox.Text.Split('x');
            MultiplicadorTextBox.Text = partir[0];
        }
        private void MultiplicadorTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
        private void MultiplicadorTextBox_Leave(object sender, EventArgs e)
        {
            if (MultiplicadorTextBox.Text == string.Empty || MultiplicadorTextBox.Text == "0")
            {
                multiplicador = 1;
                MultiplicadorTextBox.Text = "1x";
            }
            else
            {
                multiplicador = Convert.ToInt32(MultiplicadorTextBox.Text);
                MultiplicadorTextBox.Text = multiplicador.ToString() + "x";
            }
            CalcularInformacoesFinanceiras();
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

        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                int id_produto = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                Produtos_Entrada.RemoveAll(x => x.ID_Produto == id_produto);
                Lote.RemoveAll(x => x.ID_Produto == id_produto);
                PreencherDataGrid();
            }
        }

        private void formProdutosDarEntrada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void formProdutosDarEntrada_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                formConsultaRapida consultaRapida = new formConsultaRapida();
                consultaRapida.ShowDialog();
            }
        }

        private void formProdutosDarEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (buttonAdicionar.Focused == true)
                {
                    buttonAdicionar_Click(sender, e);
                    e.Handled = true;
                }
                else
                {
                    ProcessTabKey(true);
                    e.Handled = true;
                }
            }
        }
    }
}
