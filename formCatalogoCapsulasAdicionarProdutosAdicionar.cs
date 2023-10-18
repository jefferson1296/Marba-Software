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
    public partial class formCatalogoCapsulasAdicionarProdutosAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        Produto_Variacao produto = new Produto_Variacao();
        int id_capsula;

        Catalogo produto_catalogo = new Catalogo();

        int id_catalogo;

        bool cadastramento;
        bool transformacao;

        decimal custo;
        decimal preco_venda;

        string nome_catalogo;

        List<Abreviacao> Abreviacoes = new List<Abreviacao>();

        public formCatalogoCapsulasAdicionarProdutosAdicionar()
        {
            InitializeComponent();
        }

        public formCatalogoCapsulasAdicionarProdutosAdicionar(Produto_Variacao Produto, int ID_Capsula)
        {
            InitializeComponent();
            produto = Produto;
            id_capsula = ID_Capsula;
            cadastramento = true;
        }

        public formCatalogoCapsulasAdicionarProdutosAdicionar(int ID_Catalogo)
        {
            InitializeComponent();
            id_catalogo = ID_Catalogo;
            cadastramento = false;
            transformacao = false;
        }

        public formCatalogoCapsulasAdicionarProdutosAdicionar(int ID_Catalogo, int ID_Capsula)
        {
            InitializeComponent();
            id_catalogo = ID_Catalogo;
            cadastramento = false;
            id_capsula = ID_Capsula;
            transformacao = true;
        }


        private void formUtensilioCapsulaProdutosAdicionar_Load(object sender, EventArgs e)
        {
            buttonCadastrar.Focus();

            List<string> Linhas = comandos.preencherComboLinhas();
            foreach (string x in Linhas) { comboBoxLinhas.Items.Add(x); }
            comboBoxLinhas.DropDownHeight = 120;

            AtualizarListaDeAbreviacoes();

            if (cadastramento)
            {
                string nome_sistema = comandos.DefinirNomeDoSistema(produto.ID_ProdutoVariacao);
                textBoxDescricao.Text = nome_sistema;
                textBoxEtiquetas.Text = comandos.DefinirNomeDoPreco(nome_sistema);


                decimal preco_base = produto.Preco_Base;
                decimal ipi = preco_base / 100 * produto.Aliquota_IPI;
                decimal icms = preco_base / 100 * produto.Aliquota_ICMS;
                custo = preco_base + ipi + icms;

                textBoxBase.Text = preco_base.ToString("C");
                textBoxICMS.Text = produto.Aliquota_ICMS.ToString("C");
                textBoxIPI.Text = produto.Aliquota_IPI.ToString("C");
                textBoxCusto.Text = custo.ToString("C");
                SugerirPrecoDeVenda();
                
                buttonArmazenagem.Enabled = false;
            }
            else
            {
                Text = "Editar produto";
                produto_catalogo = comandos.InformacoesDoProdutoDoCatalogo(id_catalogo);

                custo = produto_catalogo.Preco_Base;

                nome_catalogo = produto_catalogo.Nome;
                textBoxDescricao.Text = produto_catalogo.Nome;
                textBoxIdeal.Text = produto_catalogo.Estoque_Ideal.ToString();
                textBoxEtiquetas.Text = produto_catalogo.Nome_Preco;
                textBoxCusto.Text = custo.ToString("C");
                checkBoxInsta.Checked = produto_catalogo.Instagram;
                checkBoxWhats.Checked = produto_catalogo.Whatsapp;
                comboBoxLinhas.SelectedItem = produto_catalogo.Linha;
                preco_venda = produto_catalogo.Preco_Venda;
                decimal markup = preco_venda / custo;
                textBoxMarkup.Text = markup.ToString("F");
                vendaTextBox.Text = preco_venda.ToString("C");
            }
        }

        private void vendaTextBox_Enter(object sender, EventArgs e)
        {
            vendaTextBox.ForeColor = Color.Black;
            if (vendaTextBox.Text == "R$0,00")
            {
                vendaTextBox.Text = string.Empty;
            }
            else
            {
                string[] partir = vendaTextBox.Text.Split('$');
                vendaTextBox.Text = partir[1];
            }
        }
        private void vendaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
            (e.KeyChar != ',' && e.KeyChar != '.' &&
            e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!vendaTextBox.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (Char)0;
                    }
                }
            }
        }
        private void vendaTextBox_Leave(object sender, EventArgs e)
        {
            if (vendaTextBox.Text == string.Empty)
            {
                preco_venda = 0;
                vendaTextBox.ForeColor = Color.Gray;
            }
            else
            {
                preco_venda = Convert.ToDecimal(vendaTextBox.Text);
                vendaTextBox.ForeColor = Color.Black;
            }

            vendaTextBox.Text = preco_venda.ToString("C");
            decimal markup = preco_venda / custo;
            textBoxMarkup.Text = markup.ToString("F");
        }
        private void buttonArmazenagem_Click(object sender, EventArgs e)
        {
            formCatalogoCapsulasAdicionarProdutosAdicionarLocalizacoes localizacoes = new formCatalogoCapsulasAdicionarProdutosAdicionarLocalizacoes(this, id_catalogo);
            localizacoes.ShowDialog();            
        }
        private void textBoxIdeal_Enter(object sender, EventArgs e)
        {
            if (textBoxIdeal.Text == "0")
                textBoxIdeal.Text = string.Empty;
        }
        private void textBoxIdeal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
        private void textBoxIdeal_Leave(object sender, EventArgs e)
        {
            if (textBoxIdeal.Text == string.Empty)
                textBoxIdeal.Text = "0";
        }
        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            string nome = textBoxDescricao.Text;
            int estoque = Convert.ToInt32(textBoxIdeal.Text);
            string nome_preco = textBoxEtiquetas.Text;
            bool instagram = checkBoxInsta.Checked;
            bool whatsapp = checkBoxWhats.Checked;
            string linha = comboBoxLinhas.Text;

            if (nome == string.Empty)
            {
                MessageBox.Show("Informe o nome do produto para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comandos.VerificarSeNomeDoProdutoJaExiste(nome) && nome != nome_catalogo)
            {
                MessageBox.Show("Já existe um produto cadastrado com esse nome!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (linha == string.Empty)
            {
                MessageBox.Show("Informe a linha do catálogo para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (estoque == 0)
            {
                MessageBox.Show("Informe o estoque ideal para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (nome_preco == string.Empty)
            {
                MessageBox.Show("Informe o nome que será impresso nas etiquetas para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (preco_venda == 0)
            {
                MessageBox.Show("Informe o preço de venda para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                produto_catalogo.Nome = nome;
                produto_catalogo.Estoque_Ideal = estoque;
                produto_catalogo.Nome_Preco = nome_preco;
                produto_catalogo.Preco_Venda = preco_venda;
                produto_catalogo.Instagram = instagram;
                produto_catalogo.Whatsapp = whatsapp;
                produto_catalogo.Linha = linha;

                if (cadastramento)
                {
                    produto_catalogo.ID_Capsula = id_capsula;
                    produto_catalogo.ID_ProdutoVariacao = produto.ID_ProdutoVariacao;
                    comandos.CadastrarProdutoDoCatalogo(produto_catalogo);

                    if (DialogResult.Yes == MessageBox.Show("Produto catalogado!\r\nDeseja preencher também as definições de armazenamento?", "Armazenamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        produto_catalogo.ID_Catalogo = comandos.IdDoUltimoProdutoCatalogado();
                        formCatalogoCapsulasAdicionarProdutosAdicionarLocalizacoes localizacoes = new formCatalogoCapsulasAdicionarProdutosAdicionarLocalizacoes(this, id_catalogo);
                        localizacoes.ShowDialog();
                    }
                }
                else
                {
                    if (transformacao)
                    {
                        produto_catalogo.ID_Capsula = id_capsula;
                        comandos.TransformarProdutoDoCatalogo(produto_catalogo);
                    }
                    else
                    {
                        comandos.EditarProdutoDoCatalogo(produto_catalogo);
                    }
                }

                Dispose();
            }



        }
        private void comboBoxLinhas_SelectedIndexChanged(object sender, EventArgs e)
        {
            SugerirPrecoDeVenda();
        }
        private void SugerirPrecoDeVenda()
        {
            string linha = comboBoxLinhas.Text;
            decimal multiplicador = comandos.MultplicadorDePrecoDeVenda(linha);

            preco_venda = custo * multiplicador;

            textBoxMarkup.Text = multiplicador.ToString("F");
            labelMarkup.Text = "Sugerido: " + multiplicador.ToString("F");
            vendaTextBox.Text = preco_venda.ToString("C");
            labelVenda.Text = "Sugerido: " + preco_venda.ToString("C");
        }
        private void textBoxDescricao_TextChanged(object sender, EventArgs e)
        {
            string nome = textBoxDescricao.Text;
            textBoxEtiquetas.Text = DefinirNomeDoPreco(nome);
        }
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void AtualizarListaDeAbreviacoes()
        {
            Abreviacoes = comandos.ListaDeAbreviacoes();
        }

        private string DefinirNomeDoPreco(string nome)
        {
            string[] palavras = nome.Split(' ');
            int vetores = palavras.Length;
            string novo_nome;

            if (vetores == 1)
            {
                novo_nome = nome;
            }
            else
            {
                novo_nome = string.Empty;
                int vetor_atual = 1;

                foreach (string palavra in palavras)
                {
                    string y = palavra;

                    if (Abreviacoes.Any(x => x.Texto == palavra))
                    {
                        y = Abreviacoes.Where(x => x.Texto == palavra).Select(x => x.Descricao).FirstOrDefault();
                    }

                    if (vetor_atual == 1) { novo_nome = y; }
                    else { novo_nome = novo_nome + " " + y; }
                    vetor_atual++;
                }
            }

            if (novo_nome.Length > 30) { novo_nome = novo_nome.Substring(0, 30); } //Retorna o nome do preço abreviado com no máximo 30 caracteres

            return novo_nome;
        }

        private void buttonAbreviacoes_Click(object sender, EventArgs e)
        {
            formGestaoConfiguracaoesAbreviacoes abreviacoes = new formGestaoConfiguracaoesAbreviacoes();
            abreviacoes.ShowDialog();
            AtualizarListaDeAbreviacoes();
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }


        #region Movimentacao do Formulario
        bool clique;
        Point clickedAt;
        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique)
            {
                Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
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
