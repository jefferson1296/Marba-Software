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
    public partial class formCatalogo : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        BindingSource binding = new BindingSource();
        int id_catalogo;
        public bool alteracao;

        public formCatalogo()
        {
            InitializeComponent();
        }

        private void formUtensilio_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }
        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewUtensilios.CurrentRow != null)
            {
                primeira_linha = dataGridViewUtensilios.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewUtensilios.CurrentRow.Index;
            }

            comandos.PreencherDataGridCatalogoAtivo(binding, dataGridViewUtensilios);

            try
            {
                dataGridViewUtensilios.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewUtensilios.CurrentCell = dataGridViewUtensilios.Rows[linha_selecionada - 1].Cells[0];
            }
            catch { }

            dataGridViewUtensilios.ClearSelection();
            dataGridViewUtensilios.CurrentCell = null;

            textBoxProdutos.Text = dataGridViewUtensilios.Rows.Count.ToString();
        }
        private void buttonDesejados_Click(object sender, EventArgs e)
        {
            MessageBox.Show("O programa de produtos desejados foi excluído desse sistema e desmembrado para um sistema próprio.", "Indisponível", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dataGridViewUtensilios_FilterStringChanged(object sender, EventArgs e)
        {
            binding.Filter = dataGridViewUtensilios.FilterString;
        }

        private void dataGridViewUtensilios_SortStringChanged(object sender, EventArgs e)
        {
            binding.Sort = dataGridViewUtensilios.SortString;
        }

        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text != "Digite aqui para pesquisar")
                this.binding.Filter = "Produto like '%" + textBoxPesquisa.Text + "%'";
        }

        private void buttonMedias_Click(object sender, EventArgs e)
        {

            string a = "oi";
            string[] o = a.Split(' ');
            MessageBox.Show(o[0]);
            try { MessageBox.Show(o[1]); } catch { MessageBox.Show("Erro"); }
            
        }

        private void dataGridViewUtensilios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_catalogo = Convert.ToInt32(dataGridViewUtensilios.Rows[e.RowIndex].Cells[0].Value);
                formCatalogoCapsulasAdicionarProdutosAdicionar produto = new formCatalogoCapsulasAdicionarProdutosAdicionar(id_catalogo);
                produto.ShowDialog();
                AtualizarDataGrid();
            }
            catch { }
        }

        private void buttonUtensilios_Click(object sender, EventArgs e)
        {
            formCatalogoUtensilios utensilios = new formCatalogoUtensilios();
            utensilios.ShowDialog();
        }

        private void dataGridViewUtensilios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_catalogo = Convert.ToInt32(dataGridViewUtensilios.Rows[e.RowIndex].Cells[0].Value);

                if (e.ColumnIndex == 7)
                {
                    bool instagram = Convert.ToBoolean(dataGridViewUtensilios.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                    dataGridViewUtensilios.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !instagram;
                    comandos.AlterarStatusDoInstagramDoProduto(id_catalogo);

                    if (!instagram)
                    {
                        MessageBox.Show("Instagram OK.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Instagram pendente.", "Pendente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (e.ColumnIndex == 8)
                {
                    bool disponibilidade = Convert.ToBoolean(dataGridViewUtensilios.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                    dataGridViewUtensilios.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !disponibilidade;
                    comandos.AlterarStatusDoWhatsappDoProduto(id_catalogo);

                    if (!disponibilidade)
                    {
                        MessageBox.Show("Whatsapp OK.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Whatsapp pendente.", "Pendente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch { }
        }

        private void buttonCapsulas_Click(object sender, EventArgs e)
        {
            formCatalogoCapsulas capsulas = new formCatalogoCapsulas();
            capsulas.ShowDialog();
            AtualizarDataGrid();
        }

        private void dataGridViewUtensilios_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        dataGridViewUtensilios.CurrentCell = dataGridViewUtensilios.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dataGridViewUtensilios.Rows[e.RowIndex].Selected = true;
                        dataGridViewUtensilios.Focus();

                        id_catalogo = Convert.ToInt32(dataGridViewUtensilios.Rows[e.RowIndex].Cells[0].Value);
                        imagensToolStripMenuItem.Visible = true;
                    }
                    else
                    {
                        id_catalogo = 0;
                    }
                }
                catch { }
            }
        }

        private void imagensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_catalogo != 0)
            {
                Catalogo produto = comandos.InformacoesDoProdutoDoCatalogo(id_catalogo);
                formCatalogoImagens imagens = new formCatalogoImagens(produto);
                imagens.ShowDialog();
                AtualizarDataGrid();
            }
        }

        private void removerDoCatálogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_catalogo != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("O produto será excluído do catálogo.\r\nAlém disso, fotos do catálogo e definições de armazenamento serão desvinculadas do produto.\r\nTem certeza que deseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarProdutoDoCatalogo(id_catalogo);
                    AtualizarDataGrid();
                }
            }
        }

        private void buttonLinhas_Click(object sender, EventArgs e)
        {
            formCatalogoLinhas linhas = new formCatalogoLinhas();
            linhas.ShowDialog();
            AtualizarDataGrid();
        }

        private void buttonIdentificacao_Click(object sender, EventArgs e)
        {
            formCatalogoIdentificacoes linhas = new formCatalogoIdentificacoes();
            linhas.ShowDialog();
        }

        private void buttonTransformar_Click(object sender, EventArgs e)
        {
            formCatalogoTransformacoes transformacoes = new formCatalogoTransformacoes();
            transformacoes.ShowDialog();
            AtualizarDataGrid();
        }
    }
}
