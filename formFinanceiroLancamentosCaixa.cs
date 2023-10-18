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
    public partial class formFinanceiroLancamentosCaixa : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<MovimentacaoCaixa> lista = new List<MovimentacaoCaixa>();
        public bool Alteracao;
        DateTime data;
        int id;

        int id_estabelecimento;

        public formFinanceiroLancamentosCaixa()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void formFinanceiroFluxoSangrias_Load(object sender, EventArgs e)
        {
            id_estabelecimento = comandos.TrazerIdDoEstabelecimentoPelaReparticao(Program.Computador.ID_Reparticao);
            AtualizarEstabelecimentos();
            comboBoxEstabelecimentos.SelectedValue = id_estabelecimento;

            data = dateTimePicker.Value;

            AtualizarDataGrid(); 
        }

        private void AtualizarEstabelecimentos()
        {
            comboBoxEstabelecimentos.DataSource = null;

            List<Estabelecimento> estabelecimentos = comandos.TrazerEstabelecimentosComerciais();
            comboBoxEstabelecimentos.DataSource = estabelecimentos;
            comboBoxEstabelecimentos.ValueMember = "ID_Estabelecimento";
            comboBoxEstabelecimentos.DisplayMember = "Descricao";

            comboBoxEstabelecimentos.SelectedIndex = -1;
        }

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            lista = comandos.TrazerSangriasESuprimentos(data, id_estabelecimento);
            dataGridViewLista.Rows.Clear();
            foreach (MovimentacaoCaixa movimentacao in lista)
            {
                int id = movimentacao.ID;
                string tipo = movimentacao.Tipo;
                string valor = movimentacao.Valor.ToString("C");
                string hora = movimentacao.Hora;
                string status;

                if (movimentacao.Operador == string.Empty && movimentacao.Recebedor != string.Empty && movimentacao.Tipo == "Suprimento")
                {
                    status = "Pendente";
                }
                else if (movimentacao.Operador != string.Empty && movimentacao.Recebedor == string.Empty && movimentacao.Tipo == "Sangria")
                {
                    status = "Pendente";
                }
                else
                {
                    status = "Concluído";
                }

                dataGridViewLista.Rows.Add(id, tipo, valor, hora, status, movimentacao.Operador);

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

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
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

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string tipo = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();
                int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                string status = dataGridViewLista.Rows[e.RowIndex].Cells[4].Value.ToString();

                if (status == "Concluído")
                {
                    MessageBox.Show("Essa movimentação já foi confirmada.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (tipo == "Suprimento")
                {
                    MessageBox.Show("Os suprimentos devem ser confirmados no caixa.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MovimentacaoCaixa sangria = lista.Where(x => x.ID == id).FirstOrDefault();
                    formFinanceiroLancamentosCaixaConfirmar confirmar = new formFinanceiroLancamentosCaixaConfirmar(sangria, this);
                    confirmar.ShowDialog();

                    AtualizarDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSuprimento_Click(object sender, EventArgs e)
        {
            formFinanceiroLancamentosCaixaRegistrar suprimento = new formFinanceiroLancamentosCaixaRegistrar(this);
            suprimento.ShowDialog();

            string data = dateTimePicker.Value.ToShortDateString();
            AtualizarDataGrid();
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
                        string status = dataGridViewLista.Rows[e.RowIndex].Cells[4].Value.ToString();
                        if (status == "Pendente") { apagarToolStripMenuItem.Visible = true; }
                        else { apagarToolStripMenuItem.Visible = false; }
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
            try
            {
                if (DialogResult.Yes == MessageBox.Show("A movimentação será excluída permanentemente.\r\nDeseja continuar?", "Tem certeza?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarMovimentacaoDeCaixaPendente(id);
                    string data = dateTimePicker.Value.ToShortDateString();
                    AtualizarDataGrid();
                }
            }
            catch { }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            data = dateTimePicker.Value;
            AtualizarDataGrid();
        }

        private void comboBoxEstabelecimentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxEstabelecimentos.SelectedValue != null)
                    id_estabelecimento = (int)comboBoxEstabelecimentos.SelectedValue;

                AtualizarDataGrid();
            }
            catch { }
        }
    }
}
