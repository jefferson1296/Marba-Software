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
    public partial class formProdutosLotesTransferenciasProdutos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<ProdutoReposicao> Produtos = new List<ProdutoReposicao>();
        int id_transferencia;
        public formProdutosLotesTransferenciasProdutos()
        {
            InitializeComponent();
        }

        public formProdutosLotesTransferenciasProdutos(int ID_Transferencia)
        {
            InitializeComponent();
            id_transferencia = ID_Transferencia;
        }

        private void formProdutosLotesTransferenciasProdutos_Load(object sender, EventArgs e)
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

            Produtos = comandos.ListaDeProdutosDaTransferencia(id_transferencia);
            dataGridViewLista.Rows.Clear();

            foreach (ProdutoReposicao Produto in Produtos)
            {
                dataGridViewLista.Rows.Add(Produto.Nome_Produto, Produto.Cod_Barras, Produto.Local_Origem, Produto.Quantidade, Produto.Local_Destino);
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
