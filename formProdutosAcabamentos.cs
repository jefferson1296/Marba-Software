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
    public partial class formProdutosAcabamentos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Acabamento> Acabamentos = new List<Acabamento>();

        public formProdutosAcabamentos()
        {
            InitializeComponent();
        }

        private void formProdutosAcabamentos_Load(object sender, EventArgs e)
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

            Acabamentos = comandos.ListaDeAcabamentos();

            dataGridViewLista.Rows.Clear();
            foreach (Acabamento Acabamento in Acabamentos)
            {
                dataGridViewLista.Rows.Add(Acabamento.ID_Acabamento, Acabamento.Descricao);
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
            string acabamento = textBoxAcabamento.Text;

            if (acabamento == string.Empty)
            {
                MessageBox.Show("Informe a descrição do acabamento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comandos.VerificarSeAcabamentoJaExiste(acabamento))
            {
                MessageBox.Show("Esse acabamento já está cadastrado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                comandos.CadastrarAcabamento(acabamento);
                AtualizarDataGrid();
            }
        }
    }
}
