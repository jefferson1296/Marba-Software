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
    public partial class formCatalogoCapsulasAdicionarProdutosAdicionarLocalizacoesAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        bool cadastramento;
        ProdutoLocalizacao localizacao = new ProdutoLocalizacao();
        string prateleira;
        int id_catalogo;

        public formCatalogoCapsulasAdicionarProdutosAdicionarLocalizacoesAdicionar(int ID_Catalogo)
        {
            InitializeComponent();
            cadastramento = true;
            id_catalogo = ID_Catalogo;
        }

        public formCatalogoCapsulasAdicionarProdutosAdicionarLocalizacoesAdicionar(string Prateleira, int ID_Catalogo)
        {
            InitializeComponent();
            prateleira = Prateleira;
            cadastramento = false;
            id_catalogo = ID_Catalogo;
        }

        private void formUtensiliosCapsulasAdicionarProdutosAdicionarLocalizacoesAdicionar_Load(object sender, EventArgs e)
        {
            List<string> estabelecimentos = comandos.PreencherComboEstabelecimentos();
            foreach (string x in estabelecimentos) 
            { 
                comboBoxEstabelecimentos.Items.Add(x);
                comboBoxEstOrigem.Items.Add(x); 
            }

            comboBoxEstabelecimentos.DropDownHeight = 120;
            comboBoxRepOrigem.DropDownHeight = 120;
            comboBoxPrateleiras.DropDownHeight = 120;
            comboBoxReparticoes.DropDownHeight = 120;
            comboBoxIdentificacoes.DropDownHeight = 120;

            if (!cadastramento)
            {
                AtualizarInformacoes();

                localizacao = comandos.InformacoesDaLocalizacao(id_catalogo, prateleira);

                comboBoxEstabelecimentos.SelectedItem = localizacao.Estabelecimento;
                comboBoxReparticoes.SelectedItem = localizacao.Reparticao;
                comboBoxReparticoes.Enabled = false;

                comboBoxPrateleiras.SelectedItem = localizacao.Localizacao;
                comboBoxPrateleiras.Enabled = false;
                comboBoxIdentificacoes.SelectedItem = localizacao.Identificacao;
                textBoxIdeal.Text = localizacao.Qtd_Ideal.ToString();
                textBoxCMR.Text = localizacao.CMR.ToString();
                comboBoxEstOrigem.SelectedItem = localizacao.Estabelecimento_Origem;
                comboBoxRepOrigem.SelectedItem = localizacao.Reparticao_Origem;
            }
        }

        private void comboBoxEstabelecimentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarComboReparticoes();
        }

        private void AtualizarComboReparticoes()
        {
            string estabelecimento = comboBoxEstabelecimentos.Text;

            comboBoxReparticoes.Items.Clear();

            List<Reparticao> Reparticoes = comandos.PreencherComboReparticoesPeloEstabelecimento(estabelecimento);

            comboBoxReparticoes.ValueMember = "ID_Reparticao";
            comboBoxReparticoes.DisplayMember = "Descricao";
            comboBoxReparticoes.DataSource = Reparticoes;

            comboBoxReparticoes.SelectedIndex = -1;
        }

        private void comboBoxEstOrigem_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarComboReparticaoDeOrigem();
        }

        private void AtualizarComboReparticaoDeOrigem()
        {
            string estabelecimento = comboBoxEstOrigem.Text;

            comboBoxRepOrigem.Items.Clear();

            List<Reparticao> Reparticoes = comandos.PreencherComboReparticoesPeloEstabelecimento(estabelecimento);

            comboBoxRepOrigem.ValueMember = "ID_Reparticao";
            comboBoxRepOrigem.DisplayMember = "Descricao";
            comboBoxRepOrigem.DataSource = Reparticoes;

            comboBoxRepOrigem.SelectedIndex = -1;
        }

        private void comboBoxReparticoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarInformacoes();
        }  
        
        private void AtualizarInformacoes()
        {
            comboBoxPrateleiras.Items.Clear();
            comboBoxIdentificacoes.Items.Clear();

            int id = (int)comboBoxReparticoes.SelectedValue;

            comboBoxPrateleiras.Enabled = true;
            List<string> Prateleiras = comandos.PreencherComboPrateleiras(id);
            foreach (string x in Prateleiras) { comboBoxPrateleiras.Items.Add(x); }

            ProdutoLocalizacao Localizacao = comandos.TrazerLocalizacaoDoProdutoNaReparticaoPeloIdDoCatalogo(id_catalogo, id);
            comboBoxPrateleiras.SelectedItem = Localizacao.Localizacao;

            comboBoxIdentificacoes.Enabled = true;
            List<string> Identificacoes = comandos.PreencherComboIdentificacoes(id);
            foreach (string x in Identificacoes) { comboBoxIdentificacoes.Items.Add(x); }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            string reparticao = comboBoxReparticoes.Text;
            string prateleira = comboBoxPrateleiras.Text;
            string identificacao = comboBoxIdentificacoes.Text;
            int estoque = Convert.ToInt32(textBoxIdeal.Text);
            int cmr = Convert.ToInt32(textBoxCMR.Text);
            string origem = comboBoxRepOrigem.Text;

            if (reparticao == string.Empty)
            {
                MessageBox.Show("Informe a repartição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (prateleira == string.Empty)
            {
                MessageBox.Show("Informe a prateleira para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (identificacao == string.Empty)
            {
                MessageBox.Show("Informe a identificação para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (estoque == 0)
            {
                MessageBox.Show("Informe o estoque ideal para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cmr == 0)
            {
                MessageBox.Show("Informe a carga mínima de reposição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comandos.VerificarSeVinculoEntreProdutoELocalizacaoJaExiste(id_catalogo, prateleira) && prateleira != this.prateleira)
            {
                MessageBox.Show("Já existe um vínculo entre esse produto e a prateleira selecionada!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                localizacao.ID_Catalogo = id_catalogo;
                localizacao.ID_Reparticao = (int)comboBoxReparticoes.SelectedValue;
                localizacao.Localizacao = prateleira;
                localizacao.Identificacao = identificacao;
                localizacao.Qtd_Ideal = estoque;
                localizacao.CMR = cmr;
                localizacao.ID_Reparticao_Origem = (int)comboBoxEstOrigem.SelectedValue;

                if (cadastramento)
                {
                    comandos.CadastrarLocalizacoesDoProduto(localizacao);
                    MessageBox.Show("Informações de armazenamento cadastradas.", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    comandos.EditarLocalizacoesDoProduto(localizacao);
                    MessageBox.Show("Informações de armazenamento editadas.", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Dispose();
            }
        }


    }
}
