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
    public partial class formTelaInicialPrincipalGerenteFinanceiro : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formTelaInicialPrincipalGerenteFinanceiro()
        {
            InitializeComponent();
        }

        private void buttonSangrias_Click(object sender, EventArgs e)
        {
            formFinanceiroLancamentosCaixa sangrias = new formFinanceiroLancamentosCaixa();
            sangrias.ShowDialog();
        }

        private void formTelaInicialPrincipalGerenteFinanceiro_Load(object sender, EventArgs e)
        {
            DataGridViewFluxo.AutoGenerateColumns = false;
            AtualizarDataGrid();
        }
        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (DataGridViewFluxo.CurrentRow != null)
            {
                primeira_linha = DataGridViewFluxo.FirstDisplayedScrollingRowIndex;
                linha_selecionada = DataGridViewFluxo.CurrentRow.Index;
            }

            comandos.PreencherDataGridFluxoIndividual(DataGridViewFluxo, bindingSourceFluxo);

            try
            {
                DataGridViewFluxo.FirstDisplayedScrollingRowIndex = primeira_linha;
                DataGridViewFluxo.CurrentCell = DataGridViewFluxo.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (DataGridViewFluxo.CurrentRow != null)
                DataGridViewFluxo.CurrentRow.Selected = false;
        }

        private void DataGridViewFluxo_SortStringChanged(object sender, EventArgs e)
        {
            bindingSourceFluxo.Sort = DataGridViewFluxo.SortString;
        }
        private void DataGridViewFluxo_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSourceFluxo.Filter = DataGridViewFluxo.FilterString;
        }
        private void DataGridViewFluxo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Font minhafonte = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);
            DataGridViewFluxo.Rows[e.RowIndex].Cells[2].Style.Font = minhafonte;

            if (e.ColumnIndex == 2)
            {
                if (DataGridViewFluxo.Rows[e.RowIndex].Cells[3].Value.ToString() == "TRANSFERÊNCIA")
                {
                    DataGridViewFluxo.Rows[e.RowIndex].Cells[2].Style.ForeColor = Color.Blue;
                    DataGridViewFluxo.Rows[e.RowIndex].Cells[2].Style.SelectionForeColor = Color.Blue;
                }
                else if (Convert.ToDecimal(DataGridViewFluxo.Rows[e.RowIndex].Cells[2].Value) < 0)
                {
                    DataGridViewFluxo.Rows[e.RowIndex].Cells[2].Style.ForeColor = Color.Red;
                    DataGridViewFluxo.Rows[e.RowIndex].Cells[2].Style.SelectionForeColor = Color.Red;
                }
                else if (Convert.ToDecimal(DataGridViewFluxo.Rows[e.RowIndex].Cells[2].Value) > 0)
                {
                    DataGridViewFluxo.Rows[e.RowIndex].Cells[2].Style.ForeColor = Color.LimeGreen;
                    DataGridViewFluxo.Rows[e.RowIndex].Cells[2].Style.SelectionForeColor = Color.LimeGreen;
                }
                else
                {
                    DataGridViewFluxo.Rows[e.RowIndex].Cells[2].Style.ForeColor = Color.Black;
                    DataGridViewFluxo.Rows[e.RowIndex].Cells[2].Style.SelectionForeColor = Color.Black;
                }
            }
        }

        private void buttonMovimentacao_Click(object sender, EventArgs e)
        {
            formFinanceiroLancamentosAdicionar movimentacao = new formFinanceiroLancamentosAdicionar(false);
            movimentacao.ShowDialog();                
            AtualizarDataGrid();
        }

        private void buttonTranferencias_Click(object sender, EventArgs e)
        {
            formFinanceiroLancamentosTransferencias transferencias = new formFinanceiroLancamentosTransferencias();
            transferencias.ShowDialog();
            AtualizarDataGrid();
        }
    }
}
