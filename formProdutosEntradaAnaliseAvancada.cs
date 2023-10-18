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
    public partial class formProdutosEntradaAnaliseAvancada : Form
    {
        string fornecedor;
        int id_pedido;
        ComandosSQL comandos = new ComandosSQL();

        public List<ProdutoEntrada> Produtos_Fornecedor;
        public List<ProdutoEntrada> Produtos_Entrada = new List<ProdutoEntrada>();
        public List<Produto_Lote> Variacoes = new List<Produto_Lote>();
        public List<Produto_Lote> Lote = new List<Produto_Lote>();
        
        public bool alteracao = false;

        decimal total_esperado;
        decimal total;

        public formProdutosEntradaAnaliseAvancada()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }
        public formProdutosEntradaAnaliseAvancada(string Fornecedor, int ID_Pedido)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            fornecedor = Fornecedor;
            id_pedido = ID_Pedido;
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void formProdutosAnaliseAvancada_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Verifique se todos os Produtos listados constam na nota.\r\nAlém disso, certifique-se também se o Preço Base e a Quantidade são os mesmos do pedido.\r\nCaso haja necessidade de alteração, dê dois cliques no produto desejado.\r\nSe o produto não estiver na nota, remova-o da lista.", "Análise avançada", MessageBoxButtons.OK, MessageBoxIcon.Information);

            foreach (DataGridViewColumn coluna in dataGridViewLista.Columns)
            {
                //if (coluna.Index != 7)
                //{
                    coluna.ReadOnly = true;
                //}
            }

            total_esperado = comandos.TrazerValorDoPedido(id_pedido);
            esperadoTextBox.Text = total_esperado.ToString("C");

            Produtos_Fornecedor = comandos.ListaDeProdutosDisponiveisParaEntrada(fornecedor);
            Variacoes = comandos.ListaDeVariacoesDisponiveisParaEntrada(fornecedor);

            Produtos_Entrada = comandos.ListaDeProdutosParaAnaliseAvancada(id_pedido);
            Lote = comandos.ListaDeVariacoesParaAnaliseAvancada(id_pedido);

            //foreach (Produto P in Produtos_Entrada)
            //{
            //    decimal preco = Produtos_Fornecedor.Where(x => x.ID_Produto == P.ID_Produto).Select(x => x.Preco_Base).FirstOrDefault();
            //    MessageBox.Show(P.ID_Produto.ToString() + "\r\n" + P.Nome_Produto + "\r\n" + P.Preco_Base + " / " + preco);
            //}

            //foreach (Produto_Lote I in Lote)
            //{
            //    MessageBox.Show(I.Nome_Produto + "\r\n" + I.Preco_Base + "\r\n" + I.Quantidade);
            //}

            labelFornecedor.Text = fornecedor;
            AtualizarDataGrid();
        }

        private void AtualizarDataGrid()
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
                string codigo = Produto.Cod_Extra;
                decimal preco_base = Produto.Preco_Base;
                decimal icms = Produto.Aliquota_ICMS;
                decimal ipi = Produto.Aliquota_IPI;
                int quantidade = Produto.Quantidade;
                bool conferido = Produto.Conferido;

                decimal custo = preco_base + (preco_base / 100 * icms) + (preco_base / 100 * ipi);
                decimal total = custo * quantidade;

                dataGridViewLista.Rows.Add(id_produto, codigo, produto, preco_base.ToString("C"), icms + "%", ipi + "%", custo.ToString("C"), quantidade, total.ToString("C"), conferido);

                AlterarValorTotal();
            }
        }
        private void AlterarValorTotal()
        {
            total = Produtos_Entrada.Where(x => x.Conferido).Sum(x => (x.Preco_Base + (x.Preco_Base / 100 * x.Aliquota_ICMS) + (x.Preco_Base / 100 * x.Aliquota_IPI)) * x.Quantidade);
            valorTotalTextBox.Text = total.ToString("C");
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
                if (total == total_esperado)
                {
                    permitir = true;
                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show("O valor dos produtos é diferente do valor esperado.\r\nDeseja continuar mesmo assim?\r\nValor Esperado: " + total_esperado.ToString("C"), "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
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
                    Analise = true,
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
                                string produto = comandos.NomeDoPreco(Produto.ID_ProdutoVariacao);
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

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
                int id_produto = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);

                foreach (ProdutoEntrada Produto in Produtos_Entrada)
                {
                    if (Produto.ID_Produto == id_produto)
                    {
                        string tipo = Produto.Tipo;

                        if (tipo == "CONJUNTO")
                        {
                            formProdutosEntradaReajustarConjunto reajuste = new formProdutosEntradaReajustarConjunto(this, id_produto);
                            reajuste.ShowDialog();
                        }
                        else
                        {
                            formProdutosEntradaReajustar reajuste = new formProdutosEntradaReajustar(this, id_produto);
                            reajuste.ShowDialog();                                
                        }

                        AtualizarDataGrid();
                    }
                }
            //}
            //catch { }
        }
        private void dataGridViewLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id_produto = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);

            if (e.ColumnIndex == 9)
            {
                if (Convert.ToBoolean(dataGridViewLista.Rows[e.RowIndex].Cells[9].Value) == true)
                {
                    dataGridViewLista.Rows[e.RowIndex].Cells[9].Value = false;
                    foreach (ProdutoEntrada Produto in Produtos_Entrada)
                    {
                        if (Produto.ID_Produto == id_produto)
                            Produto.Conferido = false;
                    }
                }
                else
                {
                    dataGridViewLista.Rows[e.RowIndex].Cells[9].Value = true;
                    foreach (ProdutoEntrada Produto in Produtos_Entrada)
                    {
                        if (Produto.ID_Produto == id_produto)
                            Produto.Conferido = true;
                    }
                }

                AlterarValorTotal();
            }
            else if (e.ColumnIndex == 10)
            {
                Produtos_Entrada.RemoveAll(x => x.ID_Produto == id_produto);
                dataGridViewLista.Rows.Remove(dataGridViewLista.Rows[e.RowIndex]);

                AlterarValorTotal();
            }
        }
        private void buttonReajustes_Click(object sender, EventArgs e)
        {
            formProdutosEntradaReajustes reajustes = new formProdutosEntradaReajustes(this);
            reajustes.ShowDialog();
        }

        private void dataGridViewLista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7)
                {
                    if (dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    {
                        dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    }

                    int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    int quantidade = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[7].Value);

                    foreach (ProdutoEntrada Produto in Produtos_Entrada)
                    {
                        if (Produto.ID_Produto == id) { Produto.Quantidade = quantidade; }
                    }

                    
                    foreach (Produto_Lote Produto in Lote)
                    {
                        if (Produto.ID_Produto == id) { Produto.Quantidade = quantidade; }
                    }

                    AtualizarDataGrid();
                }
            }
            catch { }
        }

        private void dataGridViewLista_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
    }
}
