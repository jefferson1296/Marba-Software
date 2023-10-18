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
    public partial class formProdutosLotesEntradasAjuste : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Produto_Lote> Produtos = new List<Produto_Lote>();

        string produto_informado;
        string cod_barras;
        string status;

        string codigo_selecionado;

        int id_reparticao;

        public formProdutosLotesEntradasAjuste()
        {
            InitializeComponent();
        }

        private void formProdutosLotesEntradasAjuste_Load(object sender, EventArgs e)
        {
            comboBoxLocalizacoes.DropDownHeight = 120;
            comboBoxEstabelecimentos.DropDownHeight = 120;
            List<string> estabelecimentos = comandos.PreencherComboEstabelecimentos();
            foreach (string x in estabelecimentos) { comboBoxEstabelecimentos.Items.Add(x); }

            textBoxPesquisa.AutoCompleteCustomSource = comandos.SugestaoDeProdutosDoCatalogo();

            bool botao_massa = Program.Acessos.Where(x => x.Descricao == "Botão de ajuste de entrada em massa").Select(x => x.Permissao).FirstOrDefault();

            if (botao_massa)
                buttonMassa.Visible = true;
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
                    ProdutoLocalizacao Localizacao = comandos.TrazerLocalizacaoDoProdutoNaReparticaoPeloCodigoDeBarras(cod_barras, id_reparticao);
                    comboBoxLocalizacoes.SelectedItem = Localizacao.Localizacao;
                }
            }
        }

        private void comboBoxEstabelecimentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxReparticoes.DataSource = null;
            comboBoxReparticoes.SelectedIndex = -1;
            comboBoxLocalizacoes.Items.Clear();            

            string estabelecimento = comboBoxEstabelecimentos.Text;
            List<Reparticao> Reparticoes = comandos.PreencherComboReparticoesPeloEstabelecimento(estabelecimento);

            comboBoxReparticoes.ValueMember = "ID_Reparticao";
            comboBoxReparticoes.DisplayMember = "Descricao";
            comboBoxReparticoes.DataSource = Reparticoes;

            comboBoxReparticoes.SelectedIndex = -1;

            try { comboBoxLocalizacoes.SelectedIndex = 0; } catch { }
        }

        private void comboBoxReparticoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxLocalizacoes.Items.Clear();

            try { id_reparticao = (int)comboBoxReparticoes.SelectedValue; }
            catch { id_reparticao = 0; }

            comboBoxLocalizacoes.Enabled = true;
            List<string> localizacoes = comandos.PreencherComboPrateleiras(id_reparticao);
            foreach (string x in localizacoes) { comboBoxLocalizacoes.Items.Add(x); }
        }

        private void textBoxQuantidade_Enter(object sender, EventArgs e)
        {
            if (textBoxQuantidade.Text == "0")
                textBoxQuantidade.Clear();
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
                textBoxQuantidade.Text = "0";
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            int quantidade = Convert.ToInt32(textBoxQuantidade.Text);
            string prateleira = comboBoxLocalizacoes.Text;

            if (produto_informado == string.Empty || cod_barras == string.Empty)
            {
                MessageBox.Show("Informe um produto válido para continuar!", "Produto não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (quantidade == 0)
            {
                MessageBox.Show("Informe a quantidade para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (prateleira == string.Empty)
            {
                MessageBox.Show("Informe a localização para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string estabelecimento = comboBoxEstabelecimentos.Text;
                string centro_distribuicao = comandos.TrazerCentroDeDistribuicaoCentral();
                bool etiquetas = checkBoxEtiqueta.Checked;
                bool acabamento = checkBoxAcabamento.Checked;

                status = "Armazenado";

                for( int i = 0; i < quantidade; i++)
                {
                    Produtos.Add(new Produto_Lote
                    {
                        Nome = produto_informado,
                        Cod_Barras = cod_barras,
                        Localizacao = prateleira,
                        Status = status,
                        Imprimir_Codigo = etiquetas,
                        Acabamento_bool = acabamento,
                        Quantidade = 1
                    });
                }

                textBoxPesquisa.Clear();
                textBoxQuantidade.Text = "0";
                textBoxPesquisa.Focus();
                comboBoxLocalizacoes.SelectedIndex = -1;

                comboBoxEstabelecimentos.Enabled = false;                

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

            var lista = Produtos.GroupBy(x => (x.Cod_Barras, x.Nome, x.Localizacao)).Select(g => (g.Key.Cod_Barras, g.Key.Nome, g.Key.Localizacao, Total: g.Sum(x => x.Quantidade)));

            foreach (var produto in lista)
            {
                dataGridViewLista.Rows.Add(produto.Cod_Barras, produto.Nome, produto.Localizacao, produto.Total);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            int total = Produtos.Count();
            textBoxProdutos.Text = total.ToString();

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            int total = Produtos.Count();
            bool fechar = checkBoxFechar.Checked;

            if (total > 0)
            {
                comandos.RegistrarAjusteDeEntrada(Produtos);
                if (status == "Quarentena")
                    comandos.LancarQuarentenaPeloUltimoLoteRegistrado();

                if (fechar)
                {
                    Dispose();
                }
                else
                {
                    Produtos.Clear();
                    comboBoxEstabelecimentos.Enabled = true;
                    AtualizarDataGrid();
                }
            }
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            if (Produtos.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Todos os produtos da lista serão apagados.\r\nTem certeza que deseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Produtos.Clear();
                    AtualizarDataGrid();
                }
            }
        }

        private void formProdutosLotesEntradasAjuste_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Produto_Lote> produtos = comandos.ListaProvisoria();
            status = "Armazenado";

            foreach (Produto_Lote produto in produtos)
            {
                int quantidade = produto.Quantidade;
                string codigo = produto.Cod_Barras;
                string nome = produto.Nome_Produto;


                for (int i = 0; i < quantidade; i++)
                {
                    Produtos.Add(new Produto_Lote
                    {
                        Nome = nome,
                        Cod_Barras = codigo,
                        Localizacao = comboBoxLocalizacoes.Text,
                        Status = status,
                        Imprimir_Codigo = true,
                        Acabamento_bool = true,
                        Quantidade = 1
                    });
                }
            }

            AtualizarDataGrid();
        }

        private void comboBoxLocalizacoes_TextChanged(object sender, EventArgs e)
        {
            comboBoxLocalizacoes.Text = comboBoxLocalizacoes.Text.ToUpper();
            comboBoxLocalizacoes.SelectionStart = comboBoxLocalizacoes.Text.Length;
        }
    }
}
