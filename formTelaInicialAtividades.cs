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
    public partial class formTelaInicialAtividades : Form
    {
        BindingSource binding = new BindingSource();
        ComandosSQL comandos = new ComandosSQL();
        public bool alteracao;

        string atividade;

        public formTelaInicialAtividades()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void formTelaInicialAtividadesAtiv_Load(object sender, EventArgs e)
        {
            dataGridViewAtividades.AutoGenerateColumns = false;
            AtualizarDataGrid();

            dataGridViewAtividades.AutoGenerateContextFilters = false;
        }
        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewAtividades.CurrentRow != null)
            {
                primeira_linha = dataGridViewAtividades.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewAtividades.CurrentRow.Index;
            }

            comandos.PreencherDataGridAtividades(dataGridViewAtividades, binding);

            try
            {
                dataGridViewAtividades.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewAtividades.CurrentCell = dataGridViewAtividades.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewAtividades.CurrentRow != null)
                dataGridViewAtividades.CurrentRow.Selected = false;
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text != "Digite aqui para pesquisar")
                binding.Filter = "Descricao like '%" + textBoxPesquisa.Text + "%'";
        }
        private void textBoxPesquisa_Enter(object sender, EventArgs e)
        {
            textBoxPesquisa.Text = string.Empty;
            textBoxPesquisa.ForeColor = Color.Black;
            textBoxPesquisa.CharacterCasing = CharacterCasing.Upper;
        }
        private void textBoxPesquisa_Leave(object sender, EventArgs e)
        {
            textBoxPesquisa.CharacterCasing = CharacterCasing.Normal;
            textBoxPesquisa.Text = "Digite aqui para pesquisar";
            textBoxPesquisa.ForeColor = Color.Gray;
        }
        private void buttonAtividade_Click(object sender, EventArgs e)
        {
            formAtividadesCadastrar adicionar = new formAtividadesCadastrar();
            adicionar.ShowDialog();

            AtualizarDataGrid();            
        }
        private void menuItemEditar_Click(object sender, EventArgs e)
        {

        }
        private void menuItemEspecificacoes_Click(object sender, EventArgs e)
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

        private void dataGridViewAtividades_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        dataGridViewAtividades.CurrentCell = dataGridViewAtividades.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dataGridViewAtividades.Rows[e.RowIndex].Selected = true;
                        dataGridViewAtividades.Focus();

                        atividade = dataGridViewAtividades.Rows[e.RowIndex].Cells[1].Value.ToString();
                    }
                    else
                    {
                        atividade = string.Empty;
                    }
                }
                catch { }
            }
        }

        private void dataGridViewAtividades_FilterStringChanged(object sender, EventArgs e)
        {
            binding.Filter = dataGridViewAtividades.FilterString;
        }

        private void dataGridViewAtividades_SortStringChanged(object sender, EventArgs e)
        {
            binding.Sort = dataGridViewAtividades.SortString;
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (atividade != string.Empty)
            {
                if (DialogResult.Yes == MessageBox.Show("A atividade e todos os seus lançamentos serão apagados.\r\nTem certeza que deseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    int id = comandos.TrazerIdDaAtividade(atividade);
                    comandos.ApagarAtividade(id);
                    AtualizarDataGrid();
                }
            }
        }

        private void dataGridViewAtividades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    atividade = dataGridViewAtividades.Rows[e.RowIndex].Cells[1].Value.ToString();
                    formAtividadesEditar editar = new formAtividadesEditar(atividade);
                    editar.ShowDialog();
                    AtualizarDataGrid();
                }
            }
            catch
            {
                atividade = string.Empty;
            }
        }
    }
}
