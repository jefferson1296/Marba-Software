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
    public partial class formProdutosAlmoxarifado : Form
    {
        List<Almoxarifado> Itens = new List<Almoxarifado>();
        ComandosSQL comandos = new ComandosSQL();
        int id_selecionado;
        public bool alteracao;
        bool inativos;

        public formProdutosAlmoxarifado()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id_item = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                Almoxarifado Item = Itens.Where(x => x.ID_Almoxarifado == id_item).FirstOrDefault();
                formProdutosAlmoxarifadoSaida saida = new formProdutosAlmoxarifadoSaida(Item, this);
                saida.ShowDialog();
                if (alteracao)
                {
                    alteracao = false;
                    AtualizarDataGrid();
                }
            }
            catch { }

        }

        private void formProdutosAlmoxarifado_Load(object sender, EventArgs e)
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

            Itens = comandos.ListaDoAlmoxarifado();
            dataGridViewLista.Rows.Clear();
            if (!inativos)
            {
                foreach (Almoxarifado Item in Itens)
                {

                    if (Item.Status == "Ativo")
                    {
                        dataGridViewLista.Rows.Add(Item.ID_Almoxarifado, Item.Item, Item.Estoque_Ideal, Item.Estoque_Atual);
                    }
                }
            }
            else
            {
                foreach (Almoxarifado Item in Itens)
                { 
                    dataGridViewLista.Rows.Add(Item.ID_Almoxarifado, Item.Item, Item.Estoque_Ideal, Item.Estoque_Atual); 
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

            Font minhafonte = new Font("Microsoft Sans Serif", 10, FontStyle.Strikeout, GraphicsUnit.Point);

            foreach (DataGridViewRow Linha in dataGridViewLista.Rows)
            {
                int id = Convert.ToInt32(dataGridViewLista.Rows[Linha.Index].Cells[0].Value);
                string status = Itens.Where(x => x.ID_Almoxarifado == id).Select(x => x.Status).FirstOrDefault();

                if (status == "Inativo")
                {
                    DataGridViewRow linhaestilizada = dataGridViewLista.Rows[Linha.Index];
                    linhaestilizada.DefaultCellStyle.Font = minhafonte;
                    linhaestilizada.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void MostrarInativosCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MostrarInativosCheckBox.Checked)
            {
                inativos = true;
            }
            else
            {
                inativos = false;
            }

            AtualizarDataGrid();
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

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            formProdutosAlmoxarifadoEditar cadastrar = new formProdutosAlmoxarifadoEditar(this, true);
            cadastrar.ShowDialog();
            if (alteracao)
            {
                alteracao = false;
                AtualizarDataGrid();
            }
        }

        private void buttonReposicao_Click(object sender, EventArgs e)
        {
            formProdutosAlmoxarifadoNovaReposicao reposicao = new formProdutosAlmoxarifadoNovaReposicao();
            reposicao.ShowDialog();
            AtualizarDataGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formProdutosAlmoxarifadoReposicaoEscolher escolher = new formProdutosAlmoxarifadoReposicaoEscolher();
            escolher.ShowDialog();
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

                        id_selecionado = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                        if (Itens.Where(x => x.ID_Almoxarifado == id_selecionado).Select(x => x.Status == "Ativo").First())
                        {
                            ativarToolStripMenuItem.Visible = false;
                            inativarToolStripMenuItem.Visible = true;
                        }
                        else
                        {
                            inativarToolStripMenuItem.Visible = false;
                            ativarToolStripMenuItem.Visible = true;
                        }
                    }
                    else
                    {
                        id_selecionado = 0;
                    }
                }
                catch { }
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_selecionado != 0)
            {
                formProdutosAlmoxarifadoEditar editar = new formProdutosAlmoxarifadoEditar(id_selecionado, this, false);
                editar.ShowDialog();
                if (alteracao)
                {
                    alteracao = false;
                    AtualizarDataGrid();
                }
            }
        }

        private void saídaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_selecionado != 0)
            {
                Almoxarifado Item = Itens.Where(x => x.ID_Almoxarifado == id_selecionado).FirstOrDefault();
                formProdutosAlmoxarifadoSaida saida = new formProdutosAlmoxarifadoSaida(Item, this);
                saida.ShowDialog();
                if (alteracao)
                {
                    alteracao = false;
                    AtualizarDataGrid();
                }
            }
        }

        private void ativarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_selecionado != 0)
            {
                comandos.AtivarItemDoAlmoxarifado(id_selecionado);
                AtualizarDataGrid();
            }
        }

        private void inativarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_selecionado != 0)
            {
                comandos.InativarItemDoAlmoxarifado(id_selecionado);
                AtualizarDataGrid();
            }
        }

        private void buttonEntrada_Click(object sender, EventArgs e)
        {
            formProdutosAlmoxarifadoEntrada entrada = new formProdutosAlmoxarifadoEntrada(this);
            entrada.ShowDialog();
            if (alteracao)
            {
                AtualizarDataGrid();
                alteracao = false;
            }
        }
    }
}
