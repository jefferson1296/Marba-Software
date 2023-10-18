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
    public partial class formProdutosQuantidades : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Produto_Lote> Quantidades = new List<Produto_Lote>();
        Produto produto = new Produto();
        int id_produto;

        string tipo;

        public formProdutosQuantidades()
        {
            InitializeComponent();
        }

        public formProdutosQuantidades(int ID_Produto, string Tipo)
        {
            InitializeComponent();
            id_produto = ID_Produto;
            tipo = Tipo;
        }

        private void formProdutosQuantidades_Load(object sender, EventArgs e)
        {
            if (tipo == "Variação")
            {
                id_produto = comandos.TrazerIdDoProdutoPelaVariacao(id_produto);
            }

            produto = comandos.TrazerTodasInformacoesDoProduto(id_produto);

            labelCodigo.Text = produto.Cod_Barras;
            textBoxProduto.Text = produto.Nome_Produto;
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

            dataGridViewLista.Rows.Clear();

            Quantidades = comandos.QuantidadesDoProdutoPorReparticao(id_produto);

            foreach (var Localizacao in Quantidades)
            {
                dataGridViewLista.Rows.Add(Localizacao.Localizacao, Localizacao.Quantidade);
            }

            textBoxQuantidade.Text = Convert.ToString(Quantidades.Sum(x => x.Quantidade));

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
