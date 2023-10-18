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
    public partial class formGestaoEstabelecimentosDepreciacoes : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Depreciacao> Depreciacoes = new List<Depreciacao>();

        public formGestaoEstabelecimentosDepreciacoes()
        {
            InitializeComponent();
        }

        private void formGestaoEstabelecimentosDepreciacoes_Load(object sender, EventArgs e)
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

            Depreciacoes = comandos.ListaDeDepreciacoes();
            dataGridViewLista.Rows.Clear();

            foreach (Depreciacao Depreciacao in Depreciacoes)
            {
                dataGridViewLista.Rows.Add(Depreciacao.ID_Equipamento, Depreciacao.Categoria, Depreciacao.Percentual.ToString("F") + "%");
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
