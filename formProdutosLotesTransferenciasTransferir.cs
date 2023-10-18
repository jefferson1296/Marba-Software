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
    public partial class formProdutosLotesTransferenciasTransferir : Form
    {
        string origem;
        ComandosSQL comandos = new ComandosSQL();
        List<ProdutoReposicao> Produtos = new List<ProdutoReposicao>();

        string cod_barras;
        string localizacao_origem;
        string localizacao_destino;
        string produto_informado;
        int quantidade_no_sistema;

        string codigo_selecionado;

        int id_reparticao_origem;
        int id_reparticao_destino;

        List<string> estabelecimentos = new List<string>();

        public formProdutosLotesTransferenciasTransferir()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void formProdutosAjustesTransferencia_Load(object sender, EventArgs e)
        {
            comboBoxEstDestino.DropDownHeight = 120;
            comboBoxEstOrigem.DropDownHeight = 120;
            comboBoxRepOrigem.DropDownHeight = 120;
            comboBoxRepDestino.DropDownHeight = 120;
            comboBoxOrigem.DropDownHeight = 120;
            comboBoxDestino.DropDownHeight = 120;

            estabelecimentos = comandos.PreencherComboEstabelecimentos();
            foreach (string x in estabelecimentos) { comboBoxEstOrigem.Items.Add(x); }

            textBoxPesquisa.AutoCompleteCustomSource = comandos.SugestaoDeProdutosDoCatalogo();

            bool botao_massa = Program.Acessos.Where(x => x.Descricao == "Botão de ajuste de entrada em massa").Select(x => x.Permissao).FirstOrDefault();

            if (botao_massa)
                buttonMassa.Visible = true;
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int quantidade = Convert.ToInt32(textBoxTransferir.Text); ;

            if (produto_informado == string.Empty || cod_barras == string.Empty)
            {
                MessageBox.Show("Informe um produto válido para continuar!", "Produto não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (quantidade > quantidade_no_sistema)
            {
                MessageBox.Show("O sistema detectou que só temos " + quantidade_no_sistema + " unidades desse produto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxTransferir.Focus();
            }
            else if (quantidade == 0)
            {
                MessageBox.Show("Informe a quantidade para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxTransferir.Focus();
            }
            else if (localizacao_origem == string.Empty || localizacao_origem == null || localizacao_destino == string.Empty || localizacao_destino == null)
            {
                MessageBox.Show("É necessário informar as localizações de origem e destino para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Produtos.Add(new ProdutoReposicao
                {
                    Nome_Produto = produto_informado,
                    Cod_Barras = cod_barras,
                    Local_Origem = localizacao_origem,
                    Local_Destino = localizacao_destino,
                    Quantidade = quantidade
                });

                textBoxPesquisa.Clear();
                produto_informado = string.Empty;
                cod_barras = string.Empty;

                textBoxTransferir.Text = "0";
                textBoxPesquisa.Focus();
                labelAtual.Text = "/ 0";
                comboBoxOrigem.SelectedIndex = -1;
                comboBoxDestino.SelectedIndex = -1;

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

            dataGridViewLista.Rows.Clear();

            var lista = Produtos.GroupBy(x => (x.Cod_Barras, x.Nome_Produto, x.Local_Origem, x.Local_Destino)).Select(g => (g.Key.Cod_Barras, g.Key.Nome_Produto, g.Key.Local_Origem, g.Key.Local_Destino, Total: g.Sum(x => x.Quantidade)));

            foreach (var Produto in lista)
            {
                dataGridViewLista.Rows.Add(Produto.Cod_Barras, Produto.Nome_Produto, Produto.Local_Origem, Produto.Local_Destino, Produto.Total);
            }

            textBoxProdutos.Text = Convert.ToString(lista.Count());

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }

        private void buttonConcluir_Click(object sender, EventArgs e)
        {
            if (Produtos.Count < 1)
            {
                MessageBox.Show("Nenhum produto informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("As transferências manuais podem\r\ninterferir nas reposições automáticas.\r\n\r\nDeseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    int id_origem = (int)comboBoxRepOrigem.SelectedValue;
                    int id_destino = (int)comboBoxRepDestino.SelectedValue;

                    comandos.RegistrarTransferencia(id_origem, id_destino);
                    comandos.RegistrarProdutosDaTransferencia(Produtos);

                    Dispose();
                }
            }
        }


        #region Formatação

        private void textBoxTransferir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
        private void textBoxTransferir_Enter(object sender, EventArgs e)
        {
            if (textBoxTransferir.Text == "0")
                textBoxTransferir.Text = string.Empty;
        }
        private void textBoxTransferir_Leave(object sender, EventArgs e)
        {
            if (textBoxTransferir.Text == string.Empty)
                textBoxTransferir.Text = "0";
        }
        #endregion

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

        private void textBoxPesquisa_Enter(object sender, EventArgs e)
        {
            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;

            if (textBoxPesquisa.Text == "Digite o nome ou código do produto")
            {
                textBoxPesquisa.CharacterCasing = CharacterCasing.Upper;
                textBoxPesquisa.Text = string.Empty;
                textBoxPesquisa.ForeColor = Color.Black;
            }
        }

        private void textBoxPesquisa_Leave(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text == string.Empty) //Se o produto estiver vazio...
            {
                textBoxPesquisa.CharacterCasing = CharacterCasing.Normal;
                textBoxPesquisa.Text = "Digite o nome ou código do produto";

                produto_informado = string.Empty;
                cod_barras = string.Empty;

                textBoxPesquisa.ForeColor = Color.Gray;

                comboBoxOrigem.SelectedIndex = -1;
                comboBoxDestino.SelectedIndex = -1;
            }
            else
            {
                //Verificar se foi digitado produto ou código
                //Se foi o produto 
                string produto = textBoxPesquisa.Text;

                if (produto != produto_informado && produto != cod_barras) //Verifica se não é o produto informado anteriormente
                {
                    bool codigo;
                    try
                    {
                        long x = 0; x = Convert.ToInt64(produto);
                        if (x != 0) { codigo = true; }
                        else { codigo = false; }
                    }
                    catch { codigo = false; }

                    if (codigo)
                    {
                        cod_barras = produto;

                        produto_informado = comandos.pesquisarProdutoPeloCodigo(cod_barras);
                        if (produto_informado == string.Empty)
                            produto_informado = comandos.pesquisarProdutoPorCodigoAvulso(cod_barras);

                        if (produto_informado == string.Empty)
                            cod_barras = string.Empty;
                        else
                            textBoxPesquisa.Text = produto_informado;
                    }
                    else
                    {
                        produto_informado = produto;

                        cod_barras = comandos.pesquisarCodigoPeloProduto(produto_informado);
                        if (cod_barras == string.Empty)
                            produto_informado = string.Empty;
                    }
                }

                if (produto_informado == string.Empty)
                    panelLinhaVermelha.Visible = true;
                else
                    panelLinhaVermelha.Visible = false;

                try
                {
                    ProdutoReposicao localizacoes = comandos.LocalizacoesDeOrigemEDestino(id_reparticao_origem, id_reparticao_destino, cod_barras);

                    comboBoxOrigem.SelectedItem = localizacoes.Local_Origem;
                    comboBoxDestino.SelectedItem = localizacoes.Local_Destino;
                }
                catch { }

                AtualizarQuantidadeAtual();
            }
        }

        private void formProdutosAjustesTransferencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !dataGridViewLista.Focused)
            {
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void formProdutosAjustesTransferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (buttonAdd.Focused == true)
                {
                    buttonAdd_Click(sender, e);
                    e.Handled = true;
                }
                else
                {
                    ProcessTabKey(true);
                    e.Handled = true;
                }
            }
        }

        private void dataGridViewLista_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
        }

        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                Font minhafonte = new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Point);
                dataGridViewLista[e.ColumnIndex, e.RowIndex].Style.Font = minhafonte;
            }
        }

        private void dataGridViewLista_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void formProdutosAjustesTransferencia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                formConsultaRapida consultaRapida = new formConsultaRapida();
                consultaRapida.ShowDialog();
            }
        }

        #region Origem e Destino

        private void comboBoxRepOrigem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRepOrigem.Text != string.Empty)
            {
                comboBoxEstDestino.SelectedIndex = -1;
                comboBoxRepDestino.SelectedIndex = -1;

                comboBoxOrigem.Items.Clear();

                id_reparticao_origem = (int)comboBoxRepOrigem.SelectedValue;

                comboBoxOrigem.Enabled = true;
                List<string> localizacoes = comandos.PreencherComboPrateleiras(id_reparticao_origem);
                foreach (string x in localizacoes) { comboBoxOrigem.Items.Add(x); }

                comboBoxEstOrigem.Enabled = false;
                comboBoxRepOrigem.Enabled = false;

                comboBoxEstDestino.Enabled = true;
                comboBoxRepDestino.Enabled = true;

                estabelecimentos = comandos.PreencherComboEstabelecimentos();
                foreach (string x in estabelecimentos) { comboBoxEstDestino.Items.Add(x); }
            }
            else
            {
                comboBoxEstOrigem.Enabled = true;
                comboBoxRepOrigem.Enabled = true;

                comboBoxEstDestino.Enabled = false;
                comboBoxRepDestino.Enabled = false;
            }
        }

        private void comboBoxEstOrigem_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxRepOrigem.DataSource = null;
            comboBoxRepOrigem.SelectedIndex = -1;

            string estabelecimento = comboBoxEstOrigem.Text;
            List<Reparticao> Reparticoes = comandos.PreencherComboReparticoesPeloEstabelecimento(estabelecimento);

            comboBoxRepOrigem.ValueMember = "ID_Reparticao";
            comboBoxRepOrigem.DisplayMember = "Descricao";
            comboBoxRepOrigem.DataSource = Reparticoes;

            comboBoxRepOrigem.SelectedIndex = -1;

            try { comboBoxOrigem.SelectedIndex = 0; } catch { }
        }

        private void comboBoxEstDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxRepDestino.DataSource = null;
            comboBoxRepDestino.SelectedIndex = -1;

            string estabelecimento = comboBoxEstDestino.Text;
            List<Reparticao> Reparticoes = comandos.PreencherComboReparticoesPeloEstabelecimento(estabelecimento);
            Reparticoes.RemoveAll(x => x.ID_Reparticao == (int)comboBoxRepOrigem.SelectedValue);

            comboBoxRepDestino.ValueMember = "ID_Reparticao";
            comboBoxRepDestino.DisplayMember = "Descricao";
            comboBoxRepDestino.DataSource = Reparticoes;

            comboBoxRepDestino.SelectedIndex = -1;
        }

        private void comboBoxRepDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRepDestino.Text != string.Empty)
            {
                comboBoxDestino.Items.Clear();

                id_reparticao_destino = (int)comboBoxRepDestino.SelectedValue;

                comboBoxOrigem.Enabled = true;
                List<string> localizacoes = comandos.PreencherComboPrateleiras(id_reparticao_destino);
                foreach (string x in localizacoes) { comboBoxDestino.Items.Add(x); }

                comboBoxEstDestino.Enabled = false;
                comboBoxRepDestino.Enabled = false;

                textBoxPesquisa.Enabled = true;
            }
            else
            {
                comboBoxEstDestino.Enabled = true;
                comboBoxRepDestino.Enabled = true;
            }
        }

        private void comboBoxOrigem_SelectedIndexChanged(object sender, EventArgs e)
        {
            localizacao_origem = comboBoxOrigem.Text;
            AtualizarQuantidadeAtual();
        }

        private void comboBoxDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            localizacao_destino = comboBoxDestino.Text;
        }

        #endregion

        private void AtualizarQuantidadeAtual()
        {
            try
            {
                if (cod_barras != string.Empty && localizacao_origem!= string.Empty)
                {
                    quantidade_no_sistema = comandos.QuantidadeDeProdutosComOCodigoDeBarras(cod_barras, localizacao_origem) - Produtos.Where(x => x.Cod_Barras == cod_barras).Sum(x => x.Quantidade);
                    labelAtual.Text = "/ " + quantidade_no_sistema;
                }
                else
                {
                    labelAtual.Text = "/ 0";
                }
            }
            catch
            {
                labelAtual.Text = "/ 0";
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

                        codigo_selecionado = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                    }
                    else
                    {
                        codigo_selecionado = string.Empty;
                    }
                }
                catch { }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (codigo_selecionado != string.Empty)
            {
                Produtos.RemoveAll(x => x.Cod_Barras == codigo_selecionado);
                AtualizarDataGrid();
            }
        }

        private void buttonMassa_Click(object sender, EventArgs e)
        {
            List<Produto_Lote> produtos = comandos.ListaProvisoria();

            foreach (Produto_Lote produto in produtos)
            {
                int quantidade = produto.Quantidade;
                string codigo = produto.Cod_Barras;
                string nome = produto.Nome_Produto;

                for (int i = 0; i < quantidade; i++)
                {
                    Produtos.Add(new ProdutoReposicao
                    {
                        Nome_Produto = nome,
                        Cod_Barras = codigo,
                        Local_Origem = localizacao_origem,
                        Local_Destino = localizacao_destino,
                        Quantidade = 1
                    });
                }
            }

            AtualizarDataGrid();
        }
    }
}
