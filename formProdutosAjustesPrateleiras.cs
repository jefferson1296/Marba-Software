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
    public partial class formProdutosAjustesPrateleiras : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public int id_prateleira;

        public formProdutosAjustesPrateleiras()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void formProdutosPrateleiras_Load(object sender, EventArgs e)
        {
            dataGridViewLista.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewLista.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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

            comandos.PreencherDataGridPrateleiras(dataGridViewLista, bindingSource);

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
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

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formProdutosAjustesPrateleirasAdicionar adicionar = new formProdutosAjustesPrateleirasAdicionar();
            adicionar.ShowDialog();
            AtualizarDataGrid();
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

        private void ocupadasCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void vaziasCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }



        private void buttonArmazenamento_Click(object sender, EventArgs e)
        {
            formProdutosAjustesPrateleirasArmazenamentos armazenamentos = new formProdutosAjustesPrateleirasArmazenamentos();
            armazenamentos.ShowDialog();
        }

        private void buttonExpositores_Click(object sender, EventArgs e)
        {
            formProdutosAjustesPrateleirasExpositores expositores = new formProdutosAjustesPrateleirasExpositores();
            expositores.ShowDialog();
        }

        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dataGridViewLista.Rows[e.RowIndex].Cells[4].Value.ToString() == "- - -")
            //{
            //    dataGridViewLista.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            //    dataGridViewLista.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Red;
            //}
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_prateleira = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                formProdutosAjustesPrateleirasAdicionar editar = new formProdutosAjustesPrateleirasAdicionar(id_prateleira);
                editar.ShowDialog();
                AtualizarDataGrid();
            }
            catch { }
        }

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    id_prateleira = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                }
                else
                {
                    id_prateleira = 0;
                }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_prateleira != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("A prateleira e seu vínculo com produto, ferramenta\r\nou qualquer outro objeto registrado serão excluídos permanentemente.\r\nTem certeza que deseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarPrateleira(id_prateleira);
                    AtualizarDataGrid();
                    MessageBox.Show("Prateleira excluída.", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #region Pesquisa de Produtos
        private void textBoxPesquisa_Enter(object sender, EventArgs e)
        {
            textBoxPesquisa.Text = string.Empty;
            textBoxPesquisa.ForeColor = Color.Firebrick;
            textBoxPesquisa.CharacterCasing = CharacterCasing.Upper;

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }

        private void textBoxPesquisa_Leave(object sender, EventArgs e)
        {
            textBoxPesquisa.CharacterCasing = CharacterCasing.Normal;
            textBoxPesquisa.Text = "Digite aqui para pesquisar";
            textBoxPesquisa.ForeColor = Color.IndianRed;
        }

        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text != "Digite aqui para pesquisar" && textBoxPesquisa.Text != string.Empty)
            {
                bindingSource.Filter = "Localizacao like '%" + textBoxPesquisa.Text + "%'";
            }
        }

        private void textBoxPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bindingSource.Filter = "Localizacao like '%" + textBoxPesquisa.Text + "%'";
            }
        }
        #endregion

        private void dataGridViewLista_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSource.Filter = dataGridViewLista.FilterString;
        }

        private void dataGridViewLista_SortStringChanged(object sender, EventArgs e)
        {
            bindingSource.Sort = dataGridViewLista.SortString;
        }
    }
}
