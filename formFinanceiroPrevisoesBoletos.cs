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
    public partial class formFinanceiroPrevisoesBoletos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Boleto> Boletos = new List<Boleto>();
        public bool alteracao = false;

        int id;
        string tipo;
        string descricao;

        public formFinanceiroPrevisoesBoletos()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void formFinanceiroBoletos_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonPagamento_Click(object sender, EventArgs e)
        {
        }

        #region Movimentacao do Formulario
        bool clique;
        Point clickedAt;
        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique)
            {
                this.Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
            }
        }

        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            clique = true;
            clickedAt = e.Location;
        }

        private void panelSuperior_MouseUp(object sender, MouseEventArgs e)
        {
            clique = false;
        }
        #endregion

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            Boletos = comandos.ListaDeBoletos();
            dataGridViewLista.Rows.Clear();
            foreach (Boleto Boleto in Boletos)
            {
                dataGridViewLista.Rows.Add(Boleto.ID_Boleto, Boleto.Tipo, Boleto.Descricao + " - " + Boleto.Parcela, Boleto.Vencimento, Boleto.Valor.ToString("C"), Boleto.Fornecedor);
            }

            textBoxTotal.Text = Boletos.Sum(x => x.Valor).ToString("C");
            try { textBoxProximo.Text = Boletos.Min(x => Convert.ToDateTime(x.Vencimento)).ToShortDateString(); }
            catch { textBoxProximo.Text = " - - - "; }
            try { textBoxUltimo.Text = Boletos.Max(x => Convert.ToDateTime(x.Vencimento)).ToShortDateString(); }
            catch { textBoxUltimo.Text = " - - - "; }

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
            int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
            Boleto boleto = Boletos.Where(x => x.ID_Boleto == id).FirstOrDefault();
            formFinanceiroPrevisoesBoletosAdicionar pagamento = new formFinanceiroPrevisoesBoletosAdicionar(boleto, "Boleto");
            pagamento.ShowDialog();
            AtualizarDataGrid();
        }

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    tipo = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();
                    descricao = dataGridViewLista.Rows[e.RowIndex].Cells[2].Value.ToString();
                }
                else
                {
                    id = 0;
                }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja excluir o pagamento?\r\nPagamento: " + tipo + "\r\nDescrição: " + descricao, "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarBoleto(id);
                    AtualizarDataGrid();
                }
            }
        }
    }
}
