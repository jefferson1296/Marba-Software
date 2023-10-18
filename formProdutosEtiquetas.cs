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
    public partial class formProdutosEtiquetas : Form
    {
        public List<ProdutoEtiqueta> lista = new List<ProdutoEtiqueta>();
        ComandosSQL comandos = new ComandosSQL();
        ProdutoEtiqueta Produto = new ProdutoEtiqueta();
        public bool alteracao;

        string produto_informado;

        string codigo_selecionado;

        public formProdutosEtiquetas()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void formProdutosEtiquetas_Load(object sender, EventArgs e)
        {
            textBoxPesquisa.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxPesquisa.AutoCompleteCustomSource = comandos.AutoCompleteVendas();
            alteracao = false;
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPesquisa_Enter(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text == "Digite o código ou o nome do produto")
            {
                textBoxPesquisa.Clear();
                textBoxPesquisa.ForeColor = Color.Black;
                textBoxPesquisa.CharacterCasing = CharacterCasing.Upper;
            }
        }

        private void textBoxPesquisa_Leave(object sender, EventArgs e)
        {
            string produto = textBoxPesquisa.Text;

            if (produto != string.Empty)
            {
                //if (produto != produto_informado)\
                //{
                    try
                    {
                        long x = Convert.ToInt64(produto);
                        Produto = comandos.TrazerInformacoesDoProdutoParaEtiqueta(produto, true);
                    }
                    catch
                    {
                        Produto = comandos.TrazerInformacoesDoProdutoParaEtiqueta(produto, false);

                        if (Produto.Produto != string.Empty)
                        {
                            //MessageBox.Show("O sistema registrou que você digitou o nome do produto.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                //}

                produto_informado = produto;
                textBoxPesquisa.Text = Produto.Produto;

                buttonAdicionar_Click(sender, e);
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            int quantidade = Convert.ToInt32(quantidadeTextBox.Text);

            if (Produto.Produto == string.Empty || Produto.Produto == null || textBoxPesquisa.Text == "Digite o código ou o nome do Produto")
            {
                MessageBox.Show("Informe um produto válido para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (quantidade == 0)
            {
                MessageBox.Show("Informe o a quantidade de etiquetas para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try { Produto.Codigo128 = comandos.ConverterStringParaCod128(Produto.Codigo.ToString()); }
                catch { Produto.Codigo128 = string.Empty; }
                Produto.Quantidade = 1;

                if (lista.Any(x => x.Produto == Produto.Produto))
                {
                    Produto.Imprimir = lista.Where(x => x.Produto == Produto.Produto).Select(x => x.Imprimir).FirstOrDefault();
                }
                else
                {
                    if (TudoCheckBox.Checked)
                    {
                        Produto.Imprimir = true;
                    }
                    else
                    {
                        Produto.Imprimir = false;
                    }
                }

                for (int i = 0; i < quantidade; i++)
                {
                    lista.Add(Produto);
                }

                PreencherDataGrid();
                Produto = new ProdutoEtiqueta();
                textBoxPesquisa.Text = string.Empty;
                quantidadeTextBox.Text = "1";
                textBoxPesquisa.Focus();
            }
        }
        private void PreencherDataGrid()
        {
            int linha_selecionada = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            dataGridViewLista.Rows.Clear();

            var lista = this.lista.GroupBy(x => (x.Codigo, x.Produto, x.Imprimir)).Select(g => (g.Key.Codigo, g.Key.Produto, g.Key.Imprimir, Total: g.Sum(x => x.Quantidade)));

            foreach (var Produto in lista)
            {
                dataGridViewLista.Rows.Add(Produto.Produto, Produto.Codigo, Produto.Total, Produto.Imprimir);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = dataGridViewLista.Rows.GetLastRow(DataGridViewElementStates.Visible);
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            int quantidade_produtos = this.lista.Cast<ProdutoEtiqueta>().Where(x => x.Imprimir == true).Count();

            nEtiquetasTextBox.Text = quantidade_produtos.ToString();
        }
        private void TudoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TudoCheckBox.Checked)
            {
                foreach(ProdutoEtiqueta row in lista)
                {
                    row.Imprimir = true;
                }
            }
            else
            {
                foreach (ProdutoEtiqueta row in lista)
                {
                    row.Imprimir = false;
                }
            }
            PreencherDataGrid();
        }
        private void dataGridViewLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string codigo = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();
            bool imprimir = Convert.ToBoolean(dataGridViewLista[3, e.RowIndex].Value);

            if (e.ColumnIndex == 3)
            {
                foreach (ProdutoEtiqueta row in lista)
                {
                    if (row.Codigo == codigo)
                    {
                        row.Imprimir = !imprimir;
                    }
                }

                PreencherDataGrid();
            }


        }
        private void formProdutosEtiquetas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void labelLimparTudo_Click(object sender, EventArgs e)
        {
            if (lista.Count() > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Todos os produtos da lista serão apagados.\r\nDeseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    lista.RemoveAll(x => x.Produto != null);
                    PreencherDataGrid();
                }
            }
        }

        private void buttonCarregar_Click(object sender, EventArgs e)
        {
            formProdutosEtiquetasCarregar carregar = new formProdutosEtiquetasCarregar(this);
            carregar.ShowDialog();
            if (alteracao)
            {
                PreencherDataGrid();
                alteracao = false;
            }
        }

        private void buttonConcluir_Click(object sender, EventArgs e)
        {
            formProdutosEtiquetasImprimir imprimir = new formProdutosEtiquetasImprimir(lista, this);
            imprimir.ShowDialog();
            if (alteracao)
            {
                PreencherDataGrid();
                alteracao = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lista = lista.GroupBy(x => x.Produto).Select(x => x.First()).ToList();
            PreencherDataGrid();
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

        private void buttonAdicionar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (buttonAdicionar.Focused == true)
                {
                    buttonAdicionar_Click(sender, e);
                    e.Handled = true;
                }
                else
                {
                    ProcessTabKey(true);
                    e.Handled = true;
                }
            }
        }

        private void buttonAdicionar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !dataGridViewLista.Focused)
            {
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (codigo_selecionado != string.Empty)
            {
                lista.RemoveAll(x => x.Codigo == codigo_selecionado);
                PreencherDataGrid();
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

                        codigo_selecionado = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();
                    }
                    else
                    {
                        codigo_selecionado = string.Empty;
                    }
                }
                catch { }
            }
        }
    }
}
