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
    public partial class formFinanceiroPrevisoesAtrasados : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Previsao> Previsoes = new List<Previsao>();
        int id;
        string descricao;
        string data;
        public formFinanceiroPrevisoesAtrasados()
        {
            InitializeComponent();
        }

        private void formFinanceiroPrevisoesAtrasados_Load(object sender, EventArgs e)
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

            Previsoes = comandos.ListaDePagamentosAtrasados();
            dataGridViewLista.Rows.Clear();

            foreach (Previsao Previsao in Previsoes)
            {
                if (Convert.ToDateTime(Previsao.Data) < DateTime.Now.Date && Previsao.Status == "Pendente")
                {
                    dataGridViewLista.Rows.Add(Previsao.ID_Previsao, Previsao.Tipo, Previsao.Descricao, Previsao.Valor.ToString("C"), Previsao.Data, "Atrasado");
                }
                else if (Convert.ToDateTime(Previsao.Data) <= DateTime.Now.Date && Previsao.Status == "Pago")
                {
                    dataGridViewLista.Rows.Add(Previsao.ID_Previsao, Previsao.Tipo, Previsao.Descricao, Previsao.Valor.ToString("C"), Previsao.Data, "Pago");
                }
                else
                {
                    dataGridViewLista.Rows.Add(Previsao.ID_Previsao, Previsao.Tipo, Previsao.Descricao, Previsao.Valor.ToString("C"), Previsao.Data, "Hoje");
                }
            }
            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;

            Font minhafonte = new Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point);
            Font minhafonte2 = new Font("Arial", 8, FontStyle.Strikeout, GraphicsUnit.Point);

            foreach (DataGridViewRow Linha in dataGridViewLista.Rows)
            {
                string situacao = dataGridViewLista.Rows[Linha.Index].Cells[5].Value.ToString();

                if (situacao == "Atrasado")
                {
                    DataGridViewRow linhaestilizada = dataGridViewLista.Rows[Linha.Index];
                    linhaestilizada.DefaultCellStyle.Font = minhafonte;
                    linhaestilizada.DefaultCellStyle.ForeColor = Color.DarkRed;
                    linhaestilizada.DefaultCellStyle.SelectionForeColor = Color.DarkRed;
                }
                else if (situacao == "Pago")
                {
                    DataGridViewRow linhaestilizada = dataGridViewLista.Rows[Linha.Index];
                    linhaestilizada.DefaultCellStyle.Font = minhafonte2;
                    linhaestilizada.DefaultCellStyle.ForeColor = Color.Gray;
                    linhaestilizada.DefaultCellStyle.SelectionForeColor = Color.Gray;
                }
            }
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                string descricao = Previsoes.Where(x => x.ID_Previsao == id).Select(x => x.Descricao).FirstOrDefault();
                string tipo = Previsoes.Where(x => x.ID_Previsao == id).Where(x => x.Descricao == descricao).Select(x => x.Tipo).FirstOrDefault();

                if (tipo == "Boleto")
                {
                    Boleto Boleto = comandos.InformacoesDoBoleto(id);
                    formFinanceiroPrevisoesBoletosAdicionar pagamento = new formFinanceiroPrevisoesBoletosAdicionar(Boleto, tipo);
                    pagamento.ShowDialog();
                }
                else
                {
                    Previsao Previsao = comandos.InformacoesDaPrevisao(id);
                    formFinanceiroPrevisoesBoletosAdicionar pagamento = new formFinanceiroPrevisoesBoletosAdicionar(Previsao, tipo);
                    pagamento.ShowDialog();
                }

                AtualizarDataGrid();
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

                        id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                        descricao = dataGridViewLista.Rows[e.RowIndex].Cells[2].Value.ToString();
                        data = dataGridViewLista.Rows[e.RowIndex].Cells[4].Value.ToString();
                    }
                    else
                    {
                        id = 0;
                    }
                }
                catch { }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                string tipo = Previsoes.Where(x => x.ID_Previsao == id && x.Descricao == descricao && x.Data == data).Select(x => x.Tipo).FirstOrDefault();

                if (DialogResult.Yes == MessageBox.Show("O agendamento do pagamento " + id.ToString() + " será excluído permanentemente.\r\nDeseja continuar mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (tipo == "Previsão")
                    {
                        comandos.ApagarPrevisao(id);
                        AtualizarDataGrid();
                    }
                    else if (tipo == "Boleto")
                    {
                        comandos.ApagarBoleto(id);
                        AtualizarDataGrid();
                    }
                }
            }
        }
    }
}
