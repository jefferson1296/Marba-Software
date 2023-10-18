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
    public partial class formGestaoControleLocalizacoes : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<ProdutoLocalizacao> Localizacoes = new List<ProdutoLocalizacao>();
        ProdutoLocalizacao Localizacao = new ProdutoLocalizacao();

        string produto_informado;
        string cod_barras;
        string status;

        string codigo_selecionado;

        int id_reparticao;

        public formGestaoControleLocalizacoes()
        {
            InitializeComponent();
        }

        private void formGestaoControleLocalizacoes_Load(object sender, EventArgs e)
        {
            comboBoxAtual.DropDownHeight = 120;
            comboBoxEstabelecimentos.DropDownHeight = 120;
            List<string> estabelecimentos = comandos.PreencherComboEstabelecimentos();
            foreach (string x in estabelecimentos) { comboBoxEstabelecimentos.Items.Add(x); }

            textBoxPesquisa.AutoCompleteCustomSource = comandos.SugestaoDeProdutosDoCatalogo();
        }

        private void textBoxPesquisa_Enter(object sender, EventArgs e)
        {
            panelLinhaVermelha.Visible = false;
            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;

            if (textBoxPesquisa.Text == "Digite o produto")
            {
                textBoxPesquisa.Text = string.Empty;
                textBoxPesquisa.CharacterCasing = CharacterCasing.Upper;
                textBoxPesquisa.ForeColor = Color.Black;
            }
        }

        private void textBoxPesquisa_Leave(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text == string.Empty) //Se o produto estiver vazio...
            {
                textBoxPesquisa.CharacterCasing = CharacterCasing.Normal;
                textBoxPesquisa.Text = "Digite o produto";

                produto_informado = string.Empty;
                cod_barras = string.Empty;

                textBoxPesquisa.ForeColor = Color.Gray;
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
                {
                    panelLinhaVermelha.Visible = true;
                }
                else
                {
                    panelLinhaVermelha.Visible = false;
                    Localizacao = comandos.TrazerLocalizacaoDoProdutoNaReparticaoPeloCodigoDeBarras(cod_barras, id_reparticao);
                    comboBoxAtual.SelectedItem = Localizacao.Localizacao;
                    textBoxIdeal.Text = Localizacao.Qtd_Ideal.ToString();
                    textBoxCMR.Text = Localizacao.CMR.ToString();
                    checkBoxIdentificacao.Checked = Localizacao.Identificado;
                    comboBoxOrigem.SelectedValue = Localizacao.ID_Reparticao_Origem;
                } 
            }
        }

        private void comboBoxEstabelecimentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxReparticoes.Items.Clear();
            comboBoxReparticoes.SelectedIndex = -1;
            comboBoxAtual.Items.Clear();

            string estabelecimento = comboBoxEstabelecimentos.Text;
            List<Reparticao> Reparticoes = comandos.PreencherComboReparticoesPeloEstabelecimento(estabelecimento);

            comboBoxReparticoes.ValueMember = "ID_Reparticao";
            comboBoxReparticoes.DisplayMember = "Descricao";
            comboBoxReparticoes.DataSource = Reparticoes;

            comboBoxReparticoes.SelectedIndex = -1;

            try { comboBoxAtual.SelectedIndex = 0; } catch { }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void textBoxIdeal_Enter(object sender, EventArgs e)
        {
            if (textBoxIdeal.Text == "0")
                textBoxIdeal.Clear();
        }

        private void textBoxIdeal_Leave(object sender, EventArgs e)
        {
            if (textBoxIdeal.Text == string.Empty)
                textBoxIdeal.Text = "0";
        }

        private void textBoxCMR_Enter(object sender, EventArgs e)
        {
            if (textBoxCMR.Text == "0")
                textBoxCMR.Clear();
        }

        private void textBoxCMR_Leave(object sender, EventArgs e)
        {
            if (textBoxCMR.Text == string.Empty)
                textBoxCMR.Text = "0";
        }

        private void comboBoxReparticoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxAtual.Items.Clear();

            try { id_reparticao = (int)comboBoxReparticoes.SelectedValue; }
            catch { id_reparticao = 0; }

            if (id_reparticao != 0)
            {
                comboBoxEstabelecimentos.Enabled = false;
                comboBoxReparticoes.Enabled = false;

                List<string> Prateleiras = comandos.PreencherComboPrateleiras(id_reparticao);
                foreach (string x in Prateleiras) { comboBoxAtual.Items.Add(x); comboBoxNova.Items.Add(x); }

                List<Reparticao> Reparticoes = comandos.PreencherComboReparticoes();
                Reparticoes.RemoveAll(x => x.ID_Reparticao == id_reparticao);

                comboBoxOrigem.ValueMember = "ID_Reparticao";
                comboBoxOrigem.DisplayMember = "Descricao";
                comboBoxOrigem.DataSource = Reparticoes;

                comboBoxOrigem.SelectedIndex = -1;

                textBoxPesquisa.Enabled = true;
                textBoxPesquisa.Text = "Digite o produto";
            }
            else
            {
                comboBoxEstabelecimentos.Enabled = true;
                comboBoxReparticoes.Enabled = true;
            }
        }

        private void comboBoxNova_TextChanged(object sender, EventArgs e)
        {
            comboBoxNova.Text = comboBoxNova.Text.ToUpper();
            comboBoxNova.SelectionStart = comboBoxNova.Text.Length;
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            int quantidade_ideal = Convert.ToInt32(textBoxIdeal.Text);
            int cmr = Convert.ToInt32(textBoxCMR.Text);
            string prateleira = comboBoxNova.Text;

            if (produto_informado == string.Empty || cod_barras == string.Empty)
            {
                MessageBox.Show("Informe um produto válido para continuar.", "Produto não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (quantidade_ideal == 0)
            {
                MessageBox.Show("Informe a quantidade para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmr == 0)
            {
                MessageBox.Show("Informe a carga mínima de reposição.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (prateleira == string.Empty)
            {
                MessageBox.Show("Defina a localização para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Localizacoes.Any(x => x.Cod_Barras == cod_barras))
            {
                MessageBox.Show("Esse produto já teve sua localização redefinida.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Localizacao.Localizacao = prateleira;
                Localizacao.Qtd_Ideal = quantidade_ideal;
                Localizacao.CMR = cmr;
                Localizacao.Identificado = checkBoxIdentificacao.Checked;
                Localizacao.Cod_Barras = cod_barras;
                Localizacao.Nome = produto_informado;


                Localizacoes.Add(Localizacao);

                Localizacao = new ProdutoLocalizacao();
                comboBoxAtual.SelectedIndex = -1;
                comboBoxNova.SelectedIndex = -1;
                comboBoxOrigem.SelectedIndex = -1;
                textBoxPesquisa.Clear();
                textBoxCMR.Text = "1";
                textBoxIdeal.Text = "1";
                textBoxPesquisa.Focus();

                AtualizarDataGrid();
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            int total = Localizacoes.Count();
            bool fechar = checkBoxFechar.Checked;

            if (total > 0)
            {
                comandos.AlterarLocalizacoesDosProdutos(Localizacoes);

                if (fechar)
                {
                    Dispose();
                }
                else
                {
                    Localizacoes.Clear();
                    comboBoxEstabelecimentos.Enabled = true;
                    AtualizarDataGrid();
                }
            }
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            if (Localizacoes.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Todos os produtos da lista serão apagados.\r\nTem certeza que deseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Localizacoes.Clear();
                    AtualizarDataGrid();
                }
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


            foreach (var produto in Localizacoes)
            {
                dataGridViewLista.Rows.Add(produto.Cod_Barras, produto.Nome, produto.Localizacao, produto.Qtd_Ideal, produto.CMR);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            int total = Localizacoes.Count();
            textBoxProdutos.Text = total.ToString();

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }

        private void formGestaoControleLocalizacoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }
    }
}
