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
    public partial class formProdutosLotesEntradasProdutos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id_lote;
        List<Produto_Lote> Produtos = new List<Produto_Lote>();

        public formProdutosLotesEntradasProdutos()
        {
            InitializeComponent();
        }

        public formProdutosLotesEntradasProdutos(int ID_Lote)
        {
            InitializeComponent();
            id_lote = ID_Lote;
        }

        private void formProdutosLotesEntradasProdutos_Load(object sender, EventArgs e)
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

            Produtos = comandos.ListaDeProdutosDaEntrada(id_lote);
            dataGridViewLista.Rows.Clear();

            foreach (Produto_Lote Produto in Produtos)
            {
                dataGridViewLista.Rows.Add(Produto.Nome, Produto.Cod_Barras, Produto.Quantidade, Produto.Localizacao);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }
    }
}
