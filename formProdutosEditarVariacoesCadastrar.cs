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
    public partial class formProdutosEditarVariacoesCadastrar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formProdutosEditarVariacoes pai = new formProdutosEditarVariacoes();
        bool cadastramento;
        public Produto_Variacao variacao = new Produto_Variacao();
        public List<string> Cores;
        public List<string> Estampas;


        public formProdutosEditarVariacoesCadastrar()
        {
            InitializeComponent();
        }
        public formProdutosEditarVariacoesCadastrar(formProdutosEditarVariacoes Pai, int ID_Produto)
        {
            InitializeComponent();
            pai = Pai;
            cadastramento = true;
            variacao.ID_Produto = ID_Produto;
        }
        public formProdutosEditarVariacoesCadastrar(formProdutosEditarVariacoes Pai, Produto_Variacao Variacao)
        {
            InitializeComponent();
            pai = Pai;
            cadastramento = false;
            variacao = Variacao;
        }

        private void formProdutosEditarVariacoesCadastrar_Load(object sender, EventArgs e)
        {
            variacao.Fornecedores = comandos.FornecedoresDaVariacao(variacao.ID_ProdutoVariacao);
            corComboBox.DropDownHeight = 120;

            Cores = comandos.PreencherComboBoxCores();
            foreach(string x in Cores) { corComboBox.Items.Add(x); }

            Estampas = comandos.PreencherComboBoxEstampas();
            foreach (string x in Estampas) { comboBoxEstampa.Items.Add(x); }

            codBarrasTextBox.MaxLength = 13;
            textBoxNome.Text = pai.textBoxNome.Text;

            if (!cadastramento)
            {
                codBarrasTextBox.Text = variacao.Cod_Barras;
                corComboBox.SelectedItem = variacao.Cor;
                comboBoxEstampa.SelectedItem = variacao.Estampa;
                checkBoxAtivo.Checked = variacao.Ativacao;
                checkBoxDisponibilidade.Checked = variacao.Disponibilidade;
                checkBoxCodigo.Checked = variacao.Imprimir_Codigo;
            }
            else
            {
                if (pai.Variacoes.Count == 0)
                {
                    try
                    {
                        codBarrasTextBox.Text = pai.form_cadastrar.Produto.Cod_Barras;
                        codBarrasTextBox.ReadOnly = true;
                        checkBoxCodigo.Checked = false;
                    }
                    catch { }
                }

                corComboBox.SelectedItem = "SORTIDO";
                comboBoxEstampa.SelectedItem = "SEM ESTAMPA";
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            bool continuar = false;

            string codbarras = codBarrasTextBox.Text;
            string cor = corComboBox.Text;
            string estampa = comboBoxEstampa.Text;
            bool ativacao = checkBoxAtivo.Checked;
            bool disponibilidade = checkBoxDisponibilidade.Checked;
            bool imprimir_codigo = checkBoxCodigo.Checked;

            if (cor == "SORTIDO" && pai.Variacoes.Any(x => x.Cor == "SORTIDO" && x.ID_ProdutoVariacao != variacao.ID_ProdutoVariacao))
            {
                MessageBox.Show("Esse produto já possui uma variação com a cor \"SORTIDO\"!\r\n\r\nAviso: Uma variação da cor \"SORTIDO\" significa que o produto não tem suas variações bem definidas e que ao dar entrada será necessário avaliar individualmente cada unidade na expedição.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cor == "SORTIDO" && estampa != "SEM ESTAMPA")
            {
                MessageBox.Show("Não é possível definir uma estampa sem definir uma cor para a variação!\r\nCaso o produto tenha a mesma estampa e diferentes cores,\r\ncadastre cada cor como uma variação diferente.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (codbarras == string.Empty)
            {
                Random codigo_aleatorio = new Random();

                if (DialogResult.Yes == MessageBox.Show("Você não definiu um código de barras. \r\nPor isso, o sistema criará um código de barras aleatório.\r\nDeseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    int i = 0;
                    while (i < 1)
                    {
                        codbarras = codigo_aleatorio.Next(78900000, 78999999).ToString();
                        if (comandos.VerificarCodigo(codbarras) != codbarras) { i++; continuar = true; }
                    }
                }
            }
            else
            {
                continuar = true;
            }            

            if (continuar)
            {
                variacao.Cod_Barras = codbarras;
                variacao.Cor = cor;
                variacao.Estampa = estampa;
                variacao.Ativacao = ativacao;
                variacao.Disponibilidade = disponibilidade;
                variacao.Imprimir_Codigo = imprimir_codigo;

                if (cadastramento)
                {
                    comandos.CadastrarVariacao(variacao);
                }
                else
                {
                    comandos.EditarVariacao(variacao);
                }
                Dispose();
            }
        }

        private void buttonFornecedores_Click(object sender, EventArgs e)
        {
            formProdutosEditarVariacoesFornecedores fornecedores = new formProdutosEditarVariacoesFornecedores(this);
            fornecedores.ShowDialog();
        }

        private void buttonCor_Click(object sender, EventArgs e)
        {
            formCorCadastrar cor = new formCorCadastrar("Cor");
            cor.ShowDialog();

            corComboBox.Items.Clear();
            Cores = comandos.PreencherComboBoxCores();
            foreach (string x in Cores) { corComboBox.Items.Add(x); }
        }

        private void buttonEstampa_Click(object sender, EventArgs e)
        {
            formCorCadastrar cor = new formCorCadastrar("Estampa");
            cor.ShowDialog();

            comboBoxEstampa.Items.Clear();
            Estampas = comandos.PreencherComboBoxEstampas();
            foreach (string x in Estampas) { comboBoxEstampa.Items.Add(x); }
        }
    }
}
