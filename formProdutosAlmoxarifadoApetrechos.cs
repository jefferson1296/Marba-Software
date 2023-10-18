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
    public partial class formProdutosAlmoxarifadoApetrechos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        //List<Apetrecho> Apetrechos = new List<Apetrecho>();
        int id_apetrecho;
        public bool alteracao;
        public bool bloquear_cadastro;
        public formProdutosAlmoxarifadoApetrechos()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        public formProdutosAlmoxarifadoApetrechos(bool Bloquear_cadastro)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            bloquear_cadastro = Bloquear_cadastro;
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

        private void formProdutosAlmoxarifadoApetrechos_Load(object sender, EventArgs e)
        {
            dataGridViewLista.AutoGenerateColumns = false;
            AtualizarDataGrid();
            if (bloquear_cadastro)
            {
                buttonAdd.Visible = false;
            }
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewLista_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSourceApetrechos.Filter = dataGridViewLista.FilterString;
        }

        private void dataGridViewLista_SortStringChanged(object sender, EventArgs e)
        {
            bindingSourceApetrechos.Sort = dataGridViewLista.SortString;
        }

        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            bindingSourceApetrechos.Filter = "Nome_Apetrecho like '%" + textBoxPesquisa.Text + "%'";
            string texto = textBoxPesquisa.Text;

            bool nao_encontrado = true;
            int linha_selecionada = 0;

            foreach (DataGridViewRow linha in dataGridViewLista.Rows)
            {

                if (dataGridViewLista.Rows[linha.Index].Cells[1].Value.ToString() == texto)
                {
                    linha_selecionada = linha.Index;
                    nao_encontrado = false;
                }
            }

            if (!nao_encontrado)
            {
                try
                {
                    dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[1];
                    dataGridViewLista.Rows[linha_selecionada].Selected = true;
                }
                catch { }
            }
            else
            {
                if (dataGridViewLista.CurrentRow != null)
                    dataGridViewLista.CurrentRow.Selected = false;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            formProdutosAlmoxarifadoApetrechosCadastrar cadastrar = new formProdutosAlmoxarifadoApetrechosCadastrar(this);
            cadastrar.ShowDialog();
            if (alteracao)
            {
                AtualizarDataGrid();
            }
        }

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            bindingSourceApetrechos.DataSource = comandos.ListaDeApetrechos();
            dataGridViewLista.DataSource = bindingSourceApetrechos;

            //foreach (Apetrecho apetrecho in Apetrechos)
            //{

            //    dataGridViewLista.Rows.Add(apetrecho.ID_Apetrecho, apetrecho.Nome_Apetrecho, apetrecho.Status);
            //}

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;

            Font minhafonte = new Font("Microsoft Sans Serif", 10, FontStyle.Strikeout, GraphicsUnit.Point);

            foreach (DataGridViewRow Linha in dataGridViewLista.Rows)
            {
                string status = dataGridViewLista.Rows[Linha.Index].Cells[2].Value.ToString();

                if (status == "Em uso" || status == "Danificado")
                {
                    DataGridViewRow linhaestilizada = dataGridViewLista.Rows[Linha.Index];
                    linhaestilizada.DefaultCellStyle.Font = minhafonte;
                    linhaestilizada.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
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

                        id_apetrecho = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                        string status = dataGridViewLista.Rows[e.RowIndex].Cells[2].Value.ToString();

                        if (status == "Em uso")
                        {
                            if (comandos.VerificarApetrecho(id_apetrecho))
                            {
                                desequiparToolStripMenuItem.Visible = true;
                                equiparToolStripMenuItem.Visible = false;
                            }
                        }
                        else if (status == "Disponível")
                        {
                            desequiparToolStripMenuItem.Visible = false;
                            equiparToolStripMenuItem.Visible = true;
                        }
                        else
                        {
                            desequiparToolStripMenuItem.Visible = false;
                            equiparToolStripMenuItem.Visible = false;
                        }
                    }
                    else
                    {
                        id_apetrecho = 0;
                    }
                }
                catch { }
            }
        }

        private void equiparToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comandos.EquiparApetrecho(id_apetrecho);
            AtualizarDataGrid();
        }

        private void desequiparToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("O apetrecho está em perfeitas condições de uso?", "Responda:", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                comandos.DesequiparApetrecho(id_apetrecho, "Em condições");
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Se você continuar, estará devolvendo o apetrecho com defeito.\r\nDeseja continuar mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.DesequiparApetrecho(id_apetrecho, "Danificado");
                }
            }
            AtualizarDataGrid();
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }    
}
