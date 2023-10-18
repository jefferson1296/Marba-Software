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
    public partial class formProdutosAjustesAvarias : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Avaria> Avarias = new List<Avaria>();
        formProdutosAvarias pai = new formProdutosAvarias();
        public formProdutosAjustesAvarias()
        {
            InitializeComponent();
        }
        public formProdutosAjustesAvarias(formProdutosAvarias Pai)
        {
            InitializeComponent();
            pai = Pai;
            new Sombra().ApplyShadows(this);
        }
        private void formProdutosAjustesAvarias_Load(object sender, EventArgs e)
        {
            List<Colaborador> colaboradores = comandos.PreencherComboColaboradores();
            comboBoxResponsavel.ValueMember = "ID_Colaborador";
            comboBoxResponsavel.DisplayMember = "Nome_Colaborador";
            comboBoxResponsavel.DataSource = colaboradores;

            comboBoxResponsavel.SelectedIndex = -1;
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        #region Formatação
        private void comboBoxSetor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string origem = comboBoxSetor.Text;
            textBoxProduto.Enabled = true;
            ComandosSQL comandos = new ComandosSQL();
            textBoxProduto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxProduto.AutoCompleteCustomSource = comandos.PreencherProdutosPorSetor(origem);
            comboBoxSetor.Enabled = false;
        }
        private void textBoxProduto_TextChanged(object sender, EventArgs e)
        {
            string origem = comboBoxSetor.Text;

            ComandosSQL comandos = new ComandosSQL();
            string produto = textBoxProduto.Text;
            try
            {
                int quantidade_atual = comandos.PreencherQuantidadeAtual(produto, origem);
                labelQtdAtual.Text = "/ " + Convert.ToString(quantidade_atual);
                if (comandos.VerificarNomeDoSistema(produto))
                {                 
                    comboBoxAvaria.Enabled = true;
                }
                else
                {
                    comboBoxAvaria.Enabled = false;
                }
            }
            catch { }
        }
        private void comboBoxAvaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxQuantidade.Enabled = true;
            textBoxQuantidade.Focus();
        }
        private void textBoxQuantidade_Enter(object sender, EventArgs e)
        {
            if (textBoxQuantidade.Text == "0")
            {
                textBoxQuantidade.Text = string.Empty;
            }
        }
        private void textBoxQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
        private void textBoxQuantidade_Leave(object sender, EventArgs e)
        {
            if (textBoxQuantidade.Text == string.Empty)
            {
                textBoxQuantidade.Text = "0";
            }
        }
        #endregion
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Avaria Avaria = new Avaria();
            Avaria.Setor = comboBoxSetor.Text;
            Avaria.Nome_Sistema = textBoxProduto.Text;
            string responsavel = comboBoxResponsavel.Text;
            Avaria.Tipo = comboBoxAvaria.Text;
            Avaria.Quantidade = Convert.ToInt32(textBoxQuantidade.Text);
            string[] partir1 = labelQtdAtual.Text.Split(' ');
            int quantidade_atual = Convert.ToInt32(partir1[1]);

            if (Avaria.Nome_Sistema == string.Empty)
            {
                MessageBox.Show("Informe o produto para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (Avaria.Setor == string.Empty)
            {
                MessageBox.Show("Informe o setor onde a avaria foi localizada para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (responsavel == string.Empty)
            {
                MessageBox.Show("Informe o responsável para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (Avaria.Quantidade == 0)
            {
                MessageBox.Show("Informe a quantidade para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (Avaria.Tipo == string.Empty)
            {
                MessageBox.Show("Informe o tipo de avaria para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (Avaria.Quantidade > quantidade_atual)
            {
                MessageBox.Show("A quantidade encontrada não pode ser superior a quantidade atual!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                Avaria.ID_Responsavel = Convert.ToInt32(comboBoxResponsavel.SelectedValue);
                Avaria.ID_Produto = comandos.TrazerIdDoProdutoPeloNomeDoSistema(Avaria.Nome_Sistema);
                Avarias.Add(Avaria);

                dataGridViewLista.ClearSelection();
                textBoxQuantidade.Text = "0";
                textBoxProduto.Clear();
                textBoxProduto.Focus();
                comboBoxAvaria.SelectedIndex = -1;
                comboBoxSetor.SelectedIndex = -1;
                comboBoxResponsavel.SelectedIndex = -1;

                AtualizarDataGrid();
            }

        }
        private void buttonConcluir_Click(object sender, EventArgs e)
        {
            if (Avarias.Count == 0)
            {
                MessageBox.Show("Informe os produtos para concluir a transação!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                comandos.RegistrarAvariasIdentificadas(Avarias);
                pai.alteracao = true;
                Dispose();
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

            dataGridViewLista.Rows.Clear();
            foreach (Avaria Avaria in Avarias)
            {           
                dataGridViewLista.Rows.Add(Avaria.ID_Produto, Avaria.Nome_Sistema, Avaria.Quantidade, Avaria.Tipo, comandos.TrazerColaboradorPeloID(Avaria.ID_Responsavel));
            }

            textBoxProdutos.Text = Avarias.Count.ToString();

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }


        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int id_produto = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                Avarias.RemoveAll(x => x.ID_Produto == id_produto);
                AtualizarDataGrid();
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
    }
}
