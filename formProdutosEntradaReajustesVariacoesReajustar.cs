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
    public partial class formProdutosEntradaReajustesVariacoesReajustar : Form
    {
        formProdutosEntradaDarEntrada entrada = new formProdutosEntradaDarEntrada();
        formProdutosEntradaAnaliseAvancada analise = new formProdutosEntradaAnaliseAvancada();

        decimal venda;
        int id;

        bool analise_avancada;

        public formProdutosEntradaReajustesVariacoesReajustar()
        {
            InitializeComponent();
        }
        public formProdutosEntradaReajustesVariacoesReajustar(formProdutosEntradaDarEntrada Entrada, int ID)
        {
            InitializeComponent();
            entrada = Entrada;
            analise_avancada = false;
            id = ID;
        }
        public formProdutosEntradaReajustesVariacoesReajustar(formProdutosEntradaAnaliseAvancada Analise, int ID)
        {
            InitializeComponent();
            analise = Analise;
            analise_avancada = true;
            id = ID;
        }

        private void vendaNovoTextBox_Enter(object sender, EventArgs e)
        {
            if (vendaNovoTextBox.Text == "R$0,00")
            {
                vendaNovoTextBox.Text = string.Empty;
            }
            else
            {
                string[] partir = vendaNovoTextBox.Text.Split('$');
                vendaNovoTextBox.Text = partir[1];
            }
        }
        private void vendaNovoTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!vendaNovoTextBox.Text.Contains(','))
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
        private void vendaNovoTextBox_Leave(object sender, EventArgs e)
        {
            if (vendaNovoTextBox.Text == string.Empty)
            {
                venda = 0;
                vendaNovoTextBox.Text = venda.ToString("C");
            }
            else
            {
                venda = Convert.ToDecimal(vendaNovoTextBox.Text);
                vendaNovoTextBox.Text = venda.ToString("C"); 
            }

            CalcularInformacoesFinanceiras();
        }
        private void buttonReajustar_Click(object sender, EventArgs e)
        {
            if (analise_avancada)
            {
                foreach (Produto_Lote Variacao in analise.Lote)
                {
                    if (Variacao.ID_ProdutoVariacao == id)
                    {
                        Variacao.Preco_Venda = venda;
                    }
                }
            }
            else
            {
                foreach (Produto_Lote Variacao in entrada.Lote)
                {
                    if (Variacao.ID_ProdutoVariacao == id)
                    {
                        Variacao.Preco_Venda = venda;
                    }
                }
            }

            Dispose();
        }
        private void CalcularInformacoesFinanceiras()
        {
            int id_produto;

            int id_conjunto;
            int quantidade_produtos;

            decimal base_antigo;
            decimal base_novo;
            decimal aliquota_ipi_antigo;
            decimal aliquota_ipi_novo;
            decimal aliquota_icms_antigo;
            decimal aliquota_icms_novo;
            decimal ipi_antigo;
            decimal ipi_novo;
            decimal icms_antigo;
            decimal icms_novo;
            decimal custo_antigo;
            decimal custo_novo;
            decimal venda_antigo;
            decimal venda_novo;
            decimal lucro_antigo;
            decimal margem_antiga;
            decimal lucro_novo;
            decimal margem_nova;


            if (analise_avancada)
            {
                id_produto = analise.Lote.Where(x => x.ID_ProdutoVariacao == id).Select(x => x.ID_Produto).FirstOrDefault();

                base_antigo = analise.Produtos_Fornecedor.Where(x => x.ID_Produto == id_produto).Select(x => x.Preco_Base).FirstOrDefault();
                base_novo = analise.Produtos_Entrada.Where(x => x.ID_Produto == id_produto).Select(x => x.Preco_Base).FirstOrDefault();

                aliquota_ipi_antigo = analise.Produtos_Fornecedor.Where(x => x.ID_Produto == id_produto).Select(x => x.Aliquota_IPI).FirstOrDefault();
                aliquota_ipi_novo = analise.Produtos_Entrada.Where(x => x.ID_Produto == id_produto).Select(x => x.Aliquota_IPI).FirstOrDefault();

                aliquota_icms_antigo = analise.Produtos_Fornecedor.Where(x => x.ID_Produto == id_produto).Select(x => x.Aliquota_ICMS).FirstOrDefault();
                aliquota_icms_novo = analise.Produtos_Entrada.Where(x => x.ID_Produto == id_produto).Select(x => x.Aliquota_ICMS).FirstOrDefault();

                id_conjunto = analise.Produtos_Entrada.Where(x => x.ID_Produto == id_produto).Select(x => x.ID_Conjunto).FirstOrDefault();

                if (id_conjunto != 0)
                {
                    quantidade_produtos = analise.Produtos_Entrada.Where(x => x.ID_Produto == id_produto).Select(x => x.Qtd_Produtos).FirstOrDefault();

                    base_antigo = base_antigo / quantidade_produtos;
                    base_novo = base_novo / quantidade_produtos;
                }

                venda_antigo = analise.Variacoes.Where(x => x.ID_ProdutoVariacao == id).Select(x => x.Preco_Venda).FirstOrDefault();
            }
            else
            {
                id_produto = entrada.Lote.Where(x => x.ID_ProdutoVariacao == id).Select(x => x.ID_Produto).FirstOrDefault();

                base_antigo = entrada.Produtos_Fornecedor.Where(x => x.ID_Produto == id_produto).Select(x => x.Preco_Base).FirstOrDefault();
                base_novo = entrada.Produtos_Entrada.Where(x => x.ID_Produto == id_produto).Select(x => x.Preco_Base).FirstOrDefault();

                aliquota_ipi_antigo = entrada.Produtos_Fornecedor.Where(x => x.ID_Produto == id_produto).Select(x => x.Aliquota_IPI).FirstOrDefault();
                aliquota_ipi_novo = entrada.Produtos_Entrada.Where(x => x.ID_Produto == id_produto).Select(x => x.Aliquota_IPI).FirstOrDefault();
                
                aliquota_icms_antigo = entrada.Produtos_Fornecedor.Where(x => x.ID_Produto == id_produto).Select(x => x.Aliquota_ICMS).FirstOrDefault();
                aliquota_icms_novo = entrada.Produtos_Entrada.Where(x => x.ID_Produto == id_produto).Select(x => x.Aliquota_ICMS).FirstOrDefault();

                id_conjunto = entrada.Produtos_Entrada.Where(x => x.ID_Produto == id_produto).Select(x => x.ID_Conjunto).FirstOrDefault();

                if (id_conjunto != 0)
                {
                    quantidade_produtos = entrada.Produtos_Entrada.Where(x => x.ID_Produto == id_produto).Select(x => x.Qtd_Produtos).FirstOrDefault();

                    base_antigo = base_antigo / quantidade_produtos;
                    base_novo = base_novo / quantidade_produtos;
                }

                venda_antigo = entrada.Variacoes.Where(x => x.ID_ProdutoVariacao == id).Select(x => x.Preco_Venda).FirstOrDefault();
            }

            ipi_antigo = base_antigo / 100 * aliquota_ipi_antigo;
            ipi_novo = base_novo / 100 * aliquota_ipi_novo;

            icms_antigo = base_antigo / 100 * aliquota_icms_antigo;
            icms_novo = base_novo / 100 * aliquota_icms_novo;

            custo_antigo = base_antigo + ipi_antigo + icms_antigo;
            custo_novo = base_novo + ipi_novo + icms_novo;

            venda_novo = venda;

            lucro_antigo = venda_antigo - custo_antigo;
            margem_antiga = lucro_antigo / venda_antigo * 100;

            lucro_novo = venda_novo - custo_novo;
            margem_nova = lucro_novo / venda_novo * 100;

            baseTextBox.Text = base_novo.ToString("C");
            AliquotaICMSTextBox.Text = aliquota_icms_novo.ToString("F") + "%";
            AliquotaIPITextBox.Text = aliquota_ipi_novo.ToString("F") + "%";
            ipiTextBox.Text = ipi_novo.ToString("C");
            icmsTextBox.Text = icms_novo.ToString("C");
            custoAntigoTextBox.Text = custo_antigo.ToString("C");
            custoNovoTextBox.Text = custo_novo.ToString("C");
            vendaAntigoTextBox.Text = venda_antigo.ToString("C");
            vendaNovoTextBox.Text = venda_novo.ToString("C");

            margemAnteriorTxb.Text = margem_antiga.ToString("F") + "%";
            margemAtualTxb.Text = margem_nova.ToString("F") + "%";
        }
        private void formProdutosEntradaReajustesVariacoesReajustar_Load(object sender, EventArgs e)
        {
            if (analise_avancada)
            {
                string produto = analise.Lote.Where(x => x.ID_ProdutoVariacao == id).Select(x => x.Nome_Produto).FirstOrDefault();
                produtoTextBox.Text = produto;

                venda = analise.Lote.Where(x => x.ID_ProdutoVariacao == id).Select(x => x.Preco_Venda).FirstOrDefault();
            }
            else
            {
                string produto = entrada.Lote.Where(x => x.ID_ProdutoVariacao == id).Select(x => x.Nome_Produto).FirstOrDefault();
                produtoTextBox.Text = produto;

                venda = entrada.Lote.Where(x => x.ID_ProdutoVariacao == id).Select(x => x.Preco_Venda).FirstOrDefault();
            }

            CalcularInformacoesFinanceiras();
        }
    }
}
