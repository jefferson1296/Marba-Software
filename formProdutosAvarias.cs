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
    public partial class formProdutosAvarias : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Avaria> Avarias = new List<Avaria>();
        int id_selecionado;
        public bool alteracao;
        bool pendentes;
        bool definidos;
        bool loja;
        bool estoque;
        bool deposito;
        public formProdutosAvarias()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void formProdutosAvarias_Load(object sender, EventArgs e)
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

            if (pendentesCheckBox.Checked) { pendentes = true; }
            else { pendentes = false; }
            if (definidosCheckBox.Checked) { definidos = true; }
            else { definidos = false; }
            if (lojaCheckBox.Checked) { loja = true; }
            else { loja = false; }
            if (estoqueCheckBox.Checked) { estoque = true; }
            else { estoque = false; }
            if (depositoCheckBox.Checked) { deposito = true; }
            else { deposito = false; }

            dataGridViewLista.Rows.Clear();
            Avarias = comandos.ListaDeAvarias(pendentes, definidos, loja, estoque, deposito);
            foreach (Avaria Avaria in Avarias)
            {
                int id_avaria = Avaria.ID_Avaria;
                string produto = Avaria.Nome_Sistema;
                int quantidade = Avaria.Quantidade;
                string fornecedor = Avaria.Fornecedor;
                string tipo = Avaria.Tipo;

                dataGridViewLista.Rows.Add(id_avaria, produto, quantidade, fornecedor, tipo);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void lojaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void estoqueCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void depositoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void pendentesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void definidosCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formProdutosAjustesAvarias avarias = new formProdutosAjustesAvarias(this);
            avarias.ShowDialog();
            if (alteracao)
            {
                AtualizarDataGrid();
            }
        }

        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
            string status = Avarias.Where(x => x.ID_Avaria == id).Select(x => x.Status).FirstOrDefault();

            Font minhafonte = new Font("Microsoft Sans Serif", 12, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.Font = minhafonte;

            if (status == "Pendente")
            {
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.ForeColor = Color.Black;
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.SelectionForeColor = Color.Black;
            }
            if (status == "Trocar")
            {
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.ForeColor = Color.Blue;
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.SelectionForeColor = Color.Blue;
            }
            if (status == "Vender")
            {
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.ForeColor = Color.Green;
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.SelectionForeColor = Color.Green;
            }
            if (status == "Descartar")
            {
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.ForeColor = Color.Red;
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.SelectionForeColor = Color.Red;
            }
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

                        id_selecionado = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                        string status = Avarias.Where(x => x.ID_Avaria == id_selecionado).Select(x => x.Status).FirstOrDefault();

                        if (status == "Pendente")
                        {
                            concluirToolStripMenuItem.Visible = false;
                            direcionarToolStripMenuItem.Visible = true;
                        }
                        else
                        {
                            concluirToolStripMenuItem.Visible = true;
                            direcionarToolStripMenuItem.Visible = false;
                        }
                    }
                    else
                    {
                        id_selecionado = 0;
                        concluirToolStripMenuItem.Visible = false;
                        direcionarToolStripMenuItem.Visible = false;
                    }
                }
                catch
                {
                    concluirToolStripMenuItem.Visible = false;
                    direcionarToolStripMenuItem.Visible = false;
                }
            }
        }

        private void concluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_selecionado > 0)
            {
                comandos.ConcluirDirecionamentoDeAvaria(Avarias.Where(x => x.ID_Avaria == id_selecionado).FirstOrDefault());
                AtualizarDataGrid();
            }
        }

        private void descarteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_selecionado > 0)
            {
                comandos.DirecionarAvaria(Avarias.Where(x => x.ID_Avaria == id_selecionado).FirstOrDefault(), "Descartar");
                AtualizarDataGrid();
            }
        }

        private void trocaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_selecionado > 0)
            {
                comandos.DirecionarAvaria(Avarias.Where(x => x.ID_Avaria == id_selecionado).FirstOrDefault(), "Trocar");
                AtualizarDataGrid();
            }
        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_selecionado > 0)
            {
                comandos.DirecionarAvaria(Avarias.Where(x => x.ID_Avaria == id_selecionado).FirstOrDefault(), "Vender");
                AtualizarDataGrid();
            }
        }
    }
}
