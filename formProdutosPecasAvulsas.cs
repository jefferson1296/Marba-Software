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
    public partial class formProdutosPecasAvulsas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<PecaAvulsa> Pecas = new List<PecaAvulsa>();
        public formProdutosPecasAvulsas()
        {
            InitializeComponent();
        }

        private void formProdutosPecasAvulsas_Load(object sender, EventArgs e)
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

            Pecas = comandos.ListaDePecasAvulsas();

            dataGridViewLista.Rows.Clear();
            foreach (PecaAvulsa Peca in Pecas)
            {
                dataGridViewLista.Rows.Add(Peca.ID_Peca, Peca.Nome_Peca, Peca.ID_Produto, Peca.Nome_Produto, Peca.Quantidade, Peca.Setor);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {

        }
    }
}
