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
    public partial class formProdutosLotesHistorico : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Status> Status = new List<Status>();
        int id_lote;
        int id_produto;
        string produto;
        public formProdutosLotesHistorico()
        {
            InitializeComponent();
        }
        public formProdutosLotesHistorico(int ID_Lote, int ID_Produto, string Produto)
        {
            InitializeComponent();
            id_lote = ID_Lote;
            id_produto = ID_Produto;
            produto = Produto;
        }
        private void formProdutosLotesHistorico_Load(object sender, EventArgs e)
        {
            textBoxProduto.Text = produto;
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

            Status = comandos.TrazerHistoricoDoProduto(id_lote, id_produto);

            foreach(Status status in Status)
            {
                dataGridViewLista.Rows.Add(status.ID_Status, status.Status, status.Data, status.Colaborador);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }
    }
}
