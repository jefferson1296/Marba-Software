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
    public partial class formFinanceiroLancamentosContas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Conta> contas = new List<Conta>();

        int id_conta;
        public formFinanceiroLancamentosContas()
        {
            InitializeComponent();
        }

        private void formFinanceiroFluxoContas_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formFinanceiroLancamentosContasAdicionar adicionar = new formFinanceiroLancamentosContasAdicionar();
            adicionar.ShowDialog();
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

            contas = comandos.ListaDeContas();
            dataGridViewLista.Rows.Clear();

            foreach (Conta Conta in contas)
            {
                dataGridViewLista.Rows.Add(Conta.ID_Conta, Conta.Descricao, Conta.Categoria, Conta.Saldo.ToString("C"));
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

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_conta = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);

                if (id_conta != 0)
                {
                    formFinanceiroLancamentosContasAdicionar alterar = new formFinanceiroLancamentosContasAdicionar(id_conta);
                    alterar.ShowDialog();
                    AtualizarDataGrid();
                }
            }
            catch { }
        }

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        dataGridViewLista.CurrentCell = dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dataGridViewLista.Rows[e.RowIndex].Selected = true;
                        dataGridViewLista.Focus();

                        id_conta = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    }
                    else
                    {
                        id_conta = 0;
                    }
                }
                catch { }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_conta != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar a conta?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarConta(id_conta);
                    AtualizarDataGrid();
                }
            }
        }
    }
}
