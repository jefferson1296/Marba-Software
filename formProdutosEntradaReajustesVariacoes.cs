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
    public partial class formProdutosEntradaReajustesVariacoes : Form
    {
        formProdutosEntradaDarEntrada entrada = new formProdutosEntradaDarEntrada();
        formProdutosEntradaAnaliseAvancada analise = new formProdutosEntradaAnaliseAvancada();
        bool analise_avancada;
        int id_produto;

        public formProdutosEntradaReajustesVariacoes()
        {
            InitializeComponent();
        }
        public formProdutosEntradaReajustesVariacoes(formProdutosEntradaDarEntrada Entrada, int ID_Produto)
        {
            InitializeComponent();
            entrada = Entrada;
            analise_avancada = false;
            id_produto = ID_Produto;
        }
        public formProdutosEntradaReajustesVariacoes(formProdutosEntradaAnaliseAvancada Analise, int ID_Produto)
        {
            InitializeComponent();
            analise = Analise;
            analise_avancada = true;
            id_produto = ID_Produto;
        }

        private void formProdutosEntradaReajustesVariacoes_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void AtualizarDataGrid()
        {
            List<int> inseridos = new List<int>();
            dataGridViewLista.Rows.Clear();

            if (analise_avancada)
            {
                foreach (Produto_Lote Produto in analise.Lote)
                {
                    if (Produto.ID_Produto == id_produto)
                    {
                        if (!inseridos.Contains(Produto.ID_ProdutoVariacao))
                        {
                            int id = Produto.ID_ProdutoVariacao;
                            string produto = Produto.Nome_Produto;
                            decimal venda_antigo = analise.Variacoes.Where(x => x.ID_ProdutoVariacao == id).Select(x => x.Preco_Venda).FirstOrDefault();
                            decimal venda = Produto.Preco_Venda;
                            decimal reajustes = venda - venda_antigo;

                            dataGridViewLista.Rows.Add(id, produto, venda_antigo.ToString("C"), venda.ToString("C"), reajustes.ToString("C"));
                            inseridos.Add(Produto.ID_ProdutoVariacao);
                        }
                    }
                }
            }
            else
            {
                foreach (Produto_Lote Produto in entrada.Lote)
                {
                    if (Produto.ID_Produto == id_produto)
                    {
                        if (!inseridos.Contains(Produto.ID_ProdutoVariacao))
                        {
                            int id = Produto.ID_ProdutoVariacao;
                            string produto = Produto.Nome_Produto;
                            decimal venda_antigo = entrada.Variacoes.Where(x => x.ID_ProdutoVariacao == id).Select(x => x.Preco_Venda).FirstOrDefault();
                            decimal venda = Produto.Preco_Venda;
                            decimal reajustes = venda - venda_antigo;

                            dataGridViewLista.Rows.Add(id, produto, venda_antigo.ToString("C"), venda.ToString("C"), reajustes.ToString("C"));
                            inseridos.Add(Produto.ID_ProdutoVariacao);
                        }
                    }
                }
            }
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                formProdutosEntradaReajustesVariacoesReajustar reajustar;

                if (analise_avancada)
                {
                    reajustar = new formProdutosEntradaReajustesVariacoesReajustar(analise, id);
                }
                else
                {
                    reajustar = new formProdutosEntradaReajustesVariacoesReajustar(entrada, id);
                }

                reajustar.ShowDialog();
                AtualizarDataGrid();
            }
        }
    }
}
