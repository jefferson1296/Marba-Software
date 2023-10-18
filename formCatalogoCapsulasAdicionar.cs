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
    public partial class formCatalogoCapsulasAdicionar : Form
    {
        #region Inicialização

        ComandosSQL comandos = new ComandosSQL();

        Capsula Capsula = new Capsula();

        public List<Catalogo> Produtos_encapsulados = new List<Catalogo>();

        public List<Produto_Variacao> Produtos_disponiveis = new List<Produto_Variacao>();
        List<Produto_Variacao> Filtro = new List<Produto_Variacao>();
        public List<string> Fabricantes_excluidos = new List<string>();

        public bool alteracao;
        bool cadastramento;

        int id_produto;

        public formCatalogoCapsulasAdicionar()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            cadastramento = true;
        }
        public formCatalogoCapsulasAdicionar(int ID_Capsula)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            Capsula.ID_Capsula = ID_Capsula;
            cadastramento = false;
        }
        private void formUtensilioAdicionarCapsula_Load(object sender, EventArgs e)
        {
            List<string> lista_utens = comandos.preencherComboUtens();
            foreach (string x in lista_utens) { utensilioComboBox.Items.Add(x); }

            utensilioComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            utensilioComboBox.AutoCompleteCustomSource = comandos.AutoCompleteUtens();
            utensilioComboBox.DropDownHeight = 150;

            List<string> cores = comandos.preencherComboCores();
            foreach (string x in cores) { corComboBox.Items.Add(x); }
            corComboBox.DropDownHeight = 120;

            List<string> estampas = comandos.PreencherComboBoxEstampas();
            foreach (string x in estampas) { comboBoxEstampa.Items.Add(x); }
            comboBoxEstampa.DropDownHeight = 120;

            List<string> materiais = comandos.preencherComboMaterial();
            foreach (string x in materiais) { comboBoxMaterial.Items.Add(x); }
            comboBoxMaterial.DropDownHeight = 120;

            Produtos_disponiveis = comandos.ListaDeProdutosParaEncapsulamento();

            if (cadastramento)
            {
                pictureBoxPesquisar.Visible = true;
                labelFiltrar.Visible = true;
                pictureBoxInativo.Visible = false;
                Capsula.Ideal_Produtos = 1;
            }
            else
            {
                pictureBoxPesquisar.Visible = false;
                labelFiltrar.Visible = false;
                pictureBoxInativo.Visible = true;

                Capsula = comandos.TrazerInformacoesDaCapsula(Capsula.ID_Capsula);

                sistemaTextBox.Text = Capsula.Nome_Sistema;
                utensilioComboBox.SelectedItem = Capsula.Nome_Utensilio;
                espComboBox.SelectedItem = Capsula.Especificacao;
                comboBoxMaterial.SelectedItem = Capsula.Material;
                corComboBox.SelectedItem = Capsula.Cor;
                comboBoxEstampa.SelectedItem = Capsula.Estampa;
                textBoxObs.Text = Capsula.Observacao;
                textBoxProdutos.Text = Capsula.Ideal_Produtos.ToString();

                if (Capsula.Menor_Preco > 0) { textBoxMenor.Text = Capsula.Menor_Preco.ToString("C"); }
                if (Capsula.Maior_Preco > 0) { textBoxMaior.Text = Capsula.Maior_Preco.ToString("C"); }
                if (Capsula.Altura_Min > 0) { alturaMinTextBox.Text = Capsula.Altura_Min.ToString(); }
                if (Capsula.Altura_Max > 0) { alturaMaxTextBox.Text = Capsula.Altura_Max.ToString(); }
                if (Capsula.Largura_Min > 0) { larguraMinTextBox.Text = Capsula.Largura_Min.ToString(); }
                if (Capsula.Largura_Max > 0) { larguraMaxTextBox.Text = Capsula.Largura_Max.ToString(); }
                if (Capsula.Comprimento_Min > 0) { comprimentoMinTextBox.Text = Capsula.Comprimento_Min.ToString(); }
                if (Capsula.Comprimento_Max > 0) { comprimentoMaxTextBox.Text = Capsula.Comprimento_Max.ToString(); }
                if (Capsula.Diametro_Min > 0) { diametroMinTextBox.Text = Capsula.Diametro_Min.ToString(); }
                if (Capsula.Diametro_Max > 0) { diametroMaxTextBox.Text = Capsula.Diametro_Max.ToString(); }
                if (Capsula.Capacidade_Min > 0) { medidaMinTextBox.Text = Capsula.Capacidade_Min.ToString(); }
                if (Capsula.Capacidade_Max > 0) { medidaMaxTextBox.Text = Capsula.Capacidade_Max.ToString(); }

                medidaComboBox.SelectedItem = Capsula.Capacidade_Un;

                if (Capsula.Conjunto == "Sim") { radioButtonConjunto.Checked = true; }
                else if (Capsula.Conjunto == "Não") { radioButtonUnidade.Checked = true; }
                else { radioButtonConjuntos.Checked = true; }
                AtualizarCapsula();
                FiltrarProdutos();
            }
        }
        #endregion

        #region Botões
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void pictureBoxPesquisar_Click(object sender, EventArgs e)
        {
            AtualizarCapsula();
            FiltrarProdutos();
        }

        private void buttonFornecedores_Click(object sender, EventArgs e)
        {
            formCatalogoCapsulasAdicionarFabricantes fornecedores = new formCatalogoCapsulasAdicionarFabricantes(this);
            fornecedores.ShowDialog();
            if (alteracao)
            {
                alteracao = false;
                MessageBox.Show("As alterações serão aplicadas ao realizar o próximo filtro.", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void labelFiltrar_Click(object sender, EventArgs e)
        {
            AtualizarCapsula();
            FiltrarProdutos();
        }

        private void buttonProdutos_Click(object sender, EventArgs e)
        {
            if (Capsula.ID_Capsula != 0)
            {
                formCatalogoCapsulasAdicionarProdutos produtos = new formCatalogoCapsulasAdicionarProdutos(Capsula.ID_Capsula);
                produtos.ShowDialog();
                AtualizarDataGrid();
            }
            else
            {
                MessageBox.Show("Cadastre a cápsula para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            radioButtonConjuntos.Checked = true;
            comboBoxEstampa.SelectedIndex = -1;
            comboBoxMaterial.SelectedIndex = -1;
            utensilioComboBox.SelectedIndex = -1;
            corComboBox.SelectedIndex = -1;
            espComboBox.SelectedIndex = -1;

            textBoxMenor.Clear();
            textBoxMaior.Clear();
            alturaMinTextBox.Clear();
            alturaMaxTextBox.Clear();
            larguraMinTextBox.Clear();
            larguraMaxTextBox.Clear();
            comprimentoMinTextBox.Clear();
            comprimentoMaxTextBox.Clear();
            diametroMinTextBox.Clear();
            diametroMaxTextBox.Clear();
            medidaMinTextBox.Clear();
            medidaMaxTextBox.Clear();

            id_produto = 0;
            sistemaTextBox.Clear();

            AtualizarCapsula();
            Filtro = Produtos_disponiveis;
            AtualizarDataGrid();

            if (Fabricantes_excluidos.Count() > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Deseja limpar os filtros dos fornecedores também?", "Limpar filtros", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Fabricantes_excluidos.Clear();
                }
            }
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            string nome_sistema = sistemaTextBox.Text;
            int ideal_produtos = Convert.ToInt32(textBoxProdutos.Text);

            if (cadastramento)
            {
                if (DialogResult.Yes == MessageBox.Show("Não há produtos inseridos nesta cápsula. Deseja salvar uma cápsula vazia?", "Cápsula vazia!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (nome_sistema == string.Empty)
                    {
                        MessageBox.Show("Informe o nome do sistema para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (comandos.VerificarSeNomeDoSistemaJaExiste(nome_sistema))
                    {
                        MessageBox.Show("O nome do sistema já existe. Informe um nome do sistema válido para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sistemaTextBox.Focus();
                    }
                    else
                    {
                        Capsula.Nome_Sistema = nome_sistema;
                        Capsula.Ideal_Produtos = ideal_produtos;
                        comandos.CadastrarCapsula(Capsula);
                        Dispose();
                    }
                }
            }
            else
            {
                if (nome_sistema != Capsula.Nome_Sistema || ideal_produtos != Capsula.Ideal_Produtos)
                {
                    if (nome_sistema != Capsula.Nome_Sistema && comandos.VerificarSeNomeDoSistemaJaExiste(nome_sistema))
                    {
                        MessageBox.Show("O nome do sistema já existe. Informe um nome do sistema válido para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sistemaTextBox.Focus();
                    }
                    else
                    {
                        Capsula.Nome_Sistema = nome_sistema;
                        Capsula.Ideal_Produtos = ideal_produtos;
                        comandos.AlterarInformacoesDaCapsula(Capsula);
                        MessageBox.Show("Informações atualizadas!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Dispose();
                    }
                }
                else
                {
                    Dispose();
                }
            }
        }
        #endregion

        #region Funções do DataGridView
        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (cadastramento)
                {
                    int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[1].Value);

                    if (id != id_produto && Capsula.Nome_Sistema == null)
                    {
                        id_produto = id;

                        if (Capsula.Nome_Sistema == null)
                        {
                            sistemaTextBox.Text = comandos.DefinirNomeDoSistema(id_produto);
                        }
                    }
                }
                else
                {
                    id_produto = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[1].Value);
                }
            }
            catch { }
        }

        private void encapsularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_produto != 0)
            {
                bool permitir = false;

                if (Produtos_encapsulados.Any(x => x.ID_ProdutoVariacao == id_produto)) //
                {
                    MessageBox.Show("Esse produto já está catalogado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (cadastramento)
                {
                    if (DialogResult.Yes == MessageBox.Show("Para adicionar um produto é necessário cadastrar a cápsula primeiro.\r\nCaso você opte por cadastrar agora, não será possível alterar os filtros posteriormente.\r\nDeseja cadastrar a cápsula agora?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        string nome_sistema = sistemaTextBox.Text;
                        int ideal_produtos = Convert.ToInt32(textBoxProdutos.Text);

                        if (comandos.VerificarSeNomeDoSistemaJaExiste(nome_sistema))
                        {
                            MessageBox.Show("O nome do sistema já existe. Informe um nome do sistema válido para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sistemaTextBox.Focus();
                        }
                        else
                        {
                            permitir = true;
                            cadastramento = false;
                            Capsula.Nome_Sistema = nome_sistema;
                            Capsula.Ideal_Produtos = ideal_produtos;
                            comandos.CadastrarCapsula(Capsula);
                            Capsula.ID_Capsula = comandos.IdDaUltimaCapsulaCadastrada();                            
                            pictureBoxPesquisar.Visible = false;
                            labelFiltrar.Visible = false;
                            pictureBoxInativo.Visible = true;
                        }
                    }
                }
                else
                {
                    permitir = true;
                }

                if (permitir)
                {
                    Produto_Variacao Produto = Filtro.Where(x => x.ID_ProdutoVariacao == id_produto).FirstOrDefault();
                    formCatalogoCapsulasAdicionarProdutos encapsular = new formCatalogoCapsulasAdicionarProdutos(Produto, Capsula.ID_Capsula);
                    encapsular.ShowDialog();
                    AtualizarDataGrid();
                }
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

                        int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[1].Value);

                        if (id != id_produto)
                        {
                            id_produto = id;

                            if (Capsula.Nome_Sistema == null)
                            {
                                sistemaTextBox.Text = comandos.DefinirNomeDoSistema(id_produto);
                            }
                        }
                    }
                    else
                    {
                        id_produto = 0;
                    }
                }
                catch { }

            }
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (id_produto != 0)
            {
                bool permitir = false;

                if (Produtos_encapsulados.Any(x => x.ID_ProdutoVariacao == id_produto)) //
                {
                    MessageBox.Show("Esse produto já está catalogado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (cadastramento)
                {
                    if (DialogResult.Yes == MessageBox.Show("Para adicionar um produto é necessário cadastrar a cápsula primeiro.\r\nCaso você opte por cadastrar agora, não será possível alterar os filtros posteriormente.\r\nDeseja cadastrar a cápsula agora?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        string nome_sistema = sistemaTextBox.Text;
                        int ideal_produtos = Convert.ToInt32(textBoxProdutos.Text);

                        if (comandos.VerificarSeNomeDoSistemaJaExiste(nome_sistema))
                        {
                            MessageBox.Show("O nome do sistema já existe. Informe um nome do sistema válido para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sistemaTextBox.Focus();
                        }
                        else
                        {
                            permitir = true;
                            cadastramento = false;
                            Capsula.Nome_Sistema = nome_sistema;
                            Capsula.Ideal_Produtos = ideal_produtos;
                            comandos.CadastrarCapsula(Capsula);
                            Capsula.ID_Capsula = comandos.IdDaUltimaCapsulaCadastrada();
                            pictureBoxPesquisar.Visible = false;
                            labelFiltrar.Visible = false;
                            pictureBoxInativo.Visible = true;
                        }
                    }
                }
                else
                {
                    permitir = true;
                }

                if (permitir)
                {
                    Produto_Variacao Produto = Filtro.Where(x => x.ID_ProdutoVariacao == id_produto).FirstOrDefault();
                    formCatalogoCapsulasAdicionarProdutos encapsular = new formCatalogoCapsulasAdicionarProdutos(Produto, Capsula.ID_Capsula);
                    encapsular.ShowDialog();
                    AtualizarDataGrid();
                }
            }
        }

        #endregion

        #region Métodos do Formulário
        private void AtualizarCapsula()
        {
            Capsula.Nome_Utensilio = utensilioComboBox.Text;
            Capsula.Especificacao = espComboBox.Text;
            Capsula.Material = comboBoxMaterial.Text;
            Capsula.Cor = corComboBox.Text;
            Capsula.Estampa = comboBoxEstampa.Text;
            Capsula.Observacao = textBoxObs.Text;


            if (radioButtonConjunto.Checked) { Capsula.Conjunto = "Sim"; }
            else if (radioButtonUnidade.Checked) { Capsula.Conjunto = "Não"; }
            else { Capsula.Conjunto = "Todos"; }

            string menor_preco = textBoxMenor.Text;
            string maior_preco = textBoxMaior.Text;
            string altura_min = alturaMinTextBox.Text;
            string altura_max = alturaMaxTextBox.Text;
            string altura_un = alturaComboBox.Text;
            string largura_min = larguraMinTextBox.Text;
            string largura_max = larguraMaxTextBox.Text;
            string largura_un = larguraComboBox.Text;
            string comprimento_min = comprimentoMinTextBox.Text;
            string comprimento_max = comprimentoMaxTextBox.Text;
            string comprimento_un = comprimentoComboBox.Text;
            string diametro_min = diametroMinTextBox.Text;
            string diametro_max = diametroMaxTextBox.Text;
            string diametro_un = diametroComboBox.Text;
            string medida_min = medidaMinTextBox.Text;
            string medida_max = medidaMaxTextBox.Text;
            string medida_un = medidaComboBox.Text;

            if (menor_preco != string.Empty)
            {
                Capsula.Menor_Preco = comandos.ConverterDinheiroEmDecimal(textBoxMenor.Text);
            }
            else
            {
                Capsula.Menor_Preco = 0;
            }
            if (maior_preco != string.Empty)
            {
                Capsula.Maior_Preco = comandos.ConverterDinheiroEmDecimal(textBoxMaior.Text);
            }
            else
            {
                Capsula.Maior_Preco = 0;
            }

            if (altura_min != string.Empty)
            {
                Capsula.Altura_Min = Convert.ToInt32(altura_min);
            }
            else
            {
                Capsula.Altura_Min = 0;
            }
            if (altura_max != string.Empty)
            {
                Capsula.Altura_Max = Convert.ToInt32(altura_max);
            }
            else
            {
                Capsula.Altura_Max = 0;
            }
            if (altura_un != string.Empty)
            {
                Capsula.Altura_Un = altura_un;
            }
            else
            {
                Capsula.Altura_Un = string.Empty;
            }
            if (largura_min != string.Empty)
            {
                Capsula.Largura_Min = Convert.ToInt32(largura_min);
            }
            else
            {
                Capsula.Largura_Min = 0;
            }
            if (largura_max != string.Empty)
            {
                Capsula.Largura_Max = Convert.ToInt32(largura_max);
            }
            else
            {
                Capsula.Largura_Max = 0;
            }
            if (largura_un != string.Empty)
            {
                Capsula.Largura_Un = largura_un;
            }
            else
            {
                Capsula.Largura_Un = string.Empty;
            }
            if (comprimento_min != string.Empty)
            {
                Capsula.Comprimento_Min = Convert.ToInt32(comprimento_min);
            }
            else
            {
                Capsula.Comprimento_Min = 0;
            }
            if (comprimento_max != string.Empty)
            {
                Capsula.Comprimento_Max = Convert.ToInt32(comprimento_max);
            }
            else
            {
                Capsula.Comprimento_Max = 0;
            }
            if (comprimento_un != string.Empty)
            {
                Capsula.Comprimento_Un = comprimento_un;
            }
            else
            {
                Capsula.Comprimento_Un = string.Empty;
            }
            if (diametro_min != string.Empty)
            {
                Capsula.Diametro_Min = Convert.ToInt32(diametro_min);
            }
            else
            {
                Capsula.Diametro_Min = 0;
            }
            if (diametro_max != string.Empty)
            {
                Capsula.Diametro_Max = Convert.ToInt32(diametro_max);
            }
            else
            {
                Capsula.Diametro_Max = 0;
            }
            if (diametro_un != string.Empty)
            {
                Capsula.Diametro_Un = diametro_un;
            }
            else
            {
                Capsula.Diametro_Un = string.Empty;
            }
            if (medida_min != string.Empty)
            {
                Capsula.Capacidade_Min = Convert.ToInt32(medida_min);
            }
            else
            {
                Capsula.Capacidade_Min = 0;
            }
            if (medida_max != string.Empty)
            {
                Capsula.Capacidade_Max = Convert.ToInt32(medida_max);
            }   
            else
            {
                Capsula.Capacidade_Max = 0;
            }

            Capsula.Capacidade_Un = medida_un;
        }

        private void FiltrarProdutos()
        {
            string utensilio = Capsula.Nome_Utensilio;
            string especificacao = Capsula.Especificacao;
            string material = Capsula.Material;
            string cor = Capsula.Cor;
            string conjunto = Capsula.Conjunto;
            string estampa = Capsula.Estampa;

            decimal menor_preco = Capsula.Menor_Preco;
            decimal maior_preco = Capsula.Maior_Preco;

            int altura_min = Capsula.Altura_Min;
            int altura_max = Capsula.Altura_Max;
            string altura_un = Capsula.Altura_Un;
            int largura_min = Capsula.Largura_Min;
            int largura_max = Capsula.Largura_Max;
            string largura_un = Capsula.Largura_Un;
            int comprimento_min = Capsula.Comprimento_Min;
            int comprimento_max = Capsula.Comprimento_Max;
            string comprimento_un = Capsula.Comprimento_Un;
            int diametro_min = Capsula.Diametro_Min;
            int diametro_max = Capsula.Diametro_Max;
            string diametro_un = Capsula.Diametro_Un;
            int medida_min = Capsula.Capacidade_Min;
            int medida_max = Capsula.Capacidade_Max;
            string medida_un = Capsula.Capacidade_Un;

            if (utensilio == string.Empty)
            {
                MessageBox.Show("Informe o utensílio para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!comandos.VerificarSeUtensilioJaExiste(utensilio))
            {
                MessageBox.Show("Informe um utensílio válido para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                salvarButton.Enabled = true;
                Filtro = Produtos_disponiveis.Where(x => x.Utensilio == utensilio).ToList();

                //foreach (Catalogo Produto in Produtos_encapsulados) //Remove da lista os produtos que já estão nessa cápsula
                //{
                //    Filtro.RemoveAll(x => x.ID_ProdutoVariacao == Produto.ID_ProdutoVariacao);
                //}

                foreach (string fabricante in Fabricantes_excluidos)
                {
                    Filtro.RemoveAll(x => x.Fabricante == fabricante);
                }

                if (especificacao != string.Empty)
                {
                    Filtro = Filtro.Where(x => x.Especificacao == especificacao).ToList();
                }

                if (material != string.Empty)
                {
                    Filtro = Filtro.Where(x => x.MateriaPrima == material).ToList();
                }

                if (cor != string.Empty)
                {
                    Filtro = Filtro.Where(x => x.Cor == cor).ToList();
                }

                if (estampa != string.Empty)
                {
                    Filtro = Filtro.Where(x => x.Estampa == estampa).ToList();
                }

                if (conjunto == "Sim")
                {
                    Filtro = Filtro.Where(x => x.ID_Conjunto != 0).ToList();
                }
                else if (conjunto == "Não")
                {
                    Filtro = Filtro.Where(x => x.ID_Conjunto == 0).ToList();
                }

                if (menor_preco != 0)
                {
                    Filtro = Filtro.Where(x => x.Preco_Base + (x.Preco_Base / 100 * x.Aliquota_ICMS) + (x.Preco_Base / 100 * x.Aliquota_IPI) >= menor_preco).ToList();
                }

                if (maior_preco != 0)
                {
                    Filtro = Filtro.Where(x => x.Preco_Base + (x.Preco_Base / 100 * x.Aliquota_ICMS) + (x.Preco_Base / 100 * x.Aliquota_IPI) <= maior_preco).ToList();
                }

                if (altura_min != 0 || altura_max != 0)
                {
                    Filtro = Filtro.Where(x => x.Altura != string.Empty && x.Altura != " ").ToList();

                    if (altura_min != 0)
                    {
                        Filtro = Filtro.Where(x => comandos.TrazerValorSemUnidadeDeMedida(x.Altura) >= altura_min).ToList();
                    }
                    if (altura_max != 0)
                    {
                        Filtro = Filtro.Where(x => comandos.TrazerValorSemUnidadeDeMedida(x.Altura) <= altura_max).ToList();
                    }
                }

                if (largura_min != 0 || largura_max != 0)
                {
                    Filtro = Filtro.Where(x => x.Largura != string.Empty && x.Largura != " ").ToList();

                    if (largura_min != 0)
                    {
                        Filtro = Filtro.Where(x => comandos.TrazerValorSemUnidadeDeMedida(x.Largura) >= largura_min).ToList();
                    }
                    if (largura_max != 0)
                    {
                        Filtro = Filtro.Where(x => comandos.TrazerValorSemUnidadeDeMedida(x.Largura) <= largura_max).ToList();
                    }
                }

                if (comprimento_min != 0 || comprimento_max != 0)
                {
                    Filtro = Filtro.Where(x => x.Comprimento != string.Empty && x.Comprimento != " ").ToList();

                    if (comprimento_min != 0)
                    {
                        Filtro = Filtro.Where(x => comandos.TrazerValorSemUnidadeDeMedida(x.Comprimento) >= comprimento_min).ToList();
                    }
                    if (comprimento_max != 0)
                    {
                        Filtro = Filtro.Where(x => comandos.TrazerValorSemUnidadeDeMedida(x.Comprimento) <= comprimento_max).ToList();
                    }
                }

                if (diametro_min != 0 || diametro_max != 0)
                {
                    Filtro = Filtro.Where(x => x.Diametro != string.Empty && x.Diametro != " ").ToList();

                    if (diametro_min != 0)
                    {
                        Filtro = Filtro.Where(x => comandos.TrazerValorSemUnidadeDeMedida(x.Diametro) >= diametro_min).ToList();
                    }
                    if (diametro_max != 0)
                    {
                        Filtro = Filtro.Where(x => comandos.TrazerValorSemUnidadeDeMedida(x.Diametro) <= diametro_max).ToList();
                    }
                }

                if (medida_min != 0 || medida_max != 0)
                {
                    Filtro = Filtro.Where(x => x.Capacidade != string.Empty && x.Capacidade != " " && comandos.TrazerUnidadeDeMedidaSemValor(x.Capacidade) == medida_un).ToList();

                    if (medida_min != 0)
                    {
                        Filtro = Filtro.Where(x => comandos.TrazerValorSemUnidadeDeMedida(x.Capacidade) >= medida_min).ToList();
                    }
                    if (medida_max != 0)
                    {
                        Filtro = Filtro.Where(x => comandos.TrazerValorSemUnidadeDeMedida(x.Capacidade) <= medida_max).ToList();
                    }
                }

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

            foreach (Produto_Variacao Produto in Filtro)
            {
                bool permitir_cadastrados = false;
                bool permitir_desejados = false;
                bool adicionar = true;

                if (cadatradosCheckBox.Checked) { permitir_cadastrados = true; }
                if (desejadoCheckBox.Checked) { permitir_desejados = true; }

                int id = Produto.ID_ProdutoVariacao;
                string produto = Produto.Nome_Produto;

                decimal preco_base = Produto.Preco_Base;
                decimal ipi = preco_base / 100 * Produto.Aliquota_IPI;
                decimal icms = preco_base / 100 * Produto.Aliquota_ICMS;
                decimal custo = preco_base + ipi + icms;

                string cor = Produto.Cor;
                string estampa = Produto.Estampa;
                string fabricante = Produto.Fabricante;

                if (cor != "SORTIDO" && estampa == "SEM ESTAMPA") { produto = produto + " " + cor; }
                else if (cor == "SORTIDO" && estampa != "SEM ESTAMPA") { produto = produto + " " + estampa; }
                else if (cor != "SORTIDO" && estampa != "SEM ESTAMPA") { produto = produto + " " + cor + " " + estampa; }

                string tipo = Produto.Tipo;
                if (!permitir_cadastrados && tipo == "Produto") { adicionar = false; }
                if (!permitir_desejados && tipo == "Desejado") { adicionar = false; }

                if (adicionar)
                {
                    dataGridViewLista.Rows.Add(fabricante, id, produto, custo.ToString("C"), cor, estampa);
                }
            }

            Font minhafonte = new Font("Arial", 8, FontStyle.Strikeout, GraphicsUnit.Point);

            AtualizarListaDeProdutosEncapsulados();

            if (Filtro.Any(x => !x.Disponibilidade || !x.Ativacao || x.Catalogado))
            {
                foreach (DataGridViewRow Linha in dataGridViewLista.Rows)
                {
                    int id = Convert.ToInt32(dataGridViewLista.Rows[Linha.Index].Cells[1].Value);
                    bool ativacao = Filtro.Where(x => x.ID_ProdutoVariacao == id).Select(x => x.Ativacao).FirstOrDefault();
                    bool disponibilidade = Filtro.Where(x => x.ID_ProdutoVariacao == id).Select(x => x.Disponibilidade).FirstOrDefault();
                    bool catalogado = Produtos_encapsulados.Any(x => x.ID_ProdutoVariacao == id);

                    DataGridViewRow linhaestilizada = dataGridViewLista.Rows[Linha.Index];

                    if (!ativacao || !disponibilidade)
                    {
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        linhaestilizada.DefaultCellStyle.ForeColor = Color.Red;
                        linhaestilizada.DefaultCellStyle.SelectionForeColor = Color.Red;
                    }

                    if (catalogado)
                    {
                        linhaestilizada.DefaultCellStyle.ForeColor = Color.RoyalBlue;
                        linhaestilizada.DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                    }
                }
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }

        public void AtualizarListaDeProdutosEncapsulados()
        {
            Produtos_encapsulados = comandos.ListaDeProdutosCatalogados();

            foreach(Produto_Variacao produto in Filtro)
            {
                if (Produtos_encapsulados.Any(x => x.ID_ProdutoVariacao == produto.ID_ProdutoVariacao))
                {
                    produto.Catalogado = true;
                }
            }
        }
        #endregion

        #region Observações
        private void pictureBoxObs_Click(object sender, EventArgs e)
        {
            panelObs.Visible = true;
        }

        private void pictureBoxCancelar_Click(object sender, EventArgs e)
        {
            AtualizarObservacao();
            panelObs.Visible = false;
        }

        private void textBoxObs_Leave(object sender, EventArgs e)
        {
            AtualizarObservacao();
        }

        private void AtualizarObservacao()
        {
            string obs = textBoxObs.Text;
            if (!cadastramento)
            {
                comandos.AtualizarObservacaoDaCapsula(obs, Capsula.ID_Capsula);
            }
            else
            {
                Capsula.Observacao = obs;
            }
        }
        #endregion

        #region Eventos em geral
        private void utensilioComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            espComboBox.Text = string.Empty;
            AtualizarComboEspecificacoes();
        }
        private void AtualizarComboEspecificacoes()
        {
            espComboBox.Items.Clear();
            string utensilio = utensilioComboBox.Text;

            try
            {
                List<string> lista = comandos.PreencherComboEspecificacao(utensilio);
                foreach (string x in lista) { espComboBox.Items.Add(x); }
            }
            catch { }
        }
        private void cadatradosCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }
        private void desejadoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }
        #endregion

        #region Eventos de texto
        private void textBoxMenor_Enter(object sender, EventArgs e)
        {
            if (textBoxMenor.Text != string.Empty)
            {
                comandos.ConverterDinheiroEmDecimal(textBoxMenor.Text);
            }
        }
        private void textBoxMenor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
            e.KeyChar != ',' && e.KeyChar != '.' &&
            e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.KeyChar = (char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!textBoxMenor.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (char)0;
                    }
                }
            }
        }
        private void textBoxMenor_Leave(object sender, EventArgs e)
        {
            if (textBoxMenor.Text != string.Empty)
            {
                decimal menor = Convert.ToDecimal(textBoxMenor.Text);
                if (menor != 0)
                {
                    textBoxMenor.Text = comandos.ConverterDecimalEmDinheiro(menor);
                }
                else
                {
                    textBoxMenor.Text = string.Empty;
                }
            }
        }
        private void textBoxMaior_Enter(object sender, EventArgs e)
        {
            if (textBoxMaior.Text != string.Empty)
            {
                comandos.ConverterDinheiroEmDecimal(textBoxMaior.Text);
            }
        }
        private void textBoxMaior_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
            e.KeyChar != ',' && e.KeyChar != '.' &&
            e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.KeyChar = (char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!textBoxMaior.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (char)0;
                    }
                }
            }
        }
        private void textBoxMaior_Leave(object sender, EventArgs e)
        {
            if (textBoxMaior.Text != string.Empty)
            {
                decimal maior = Convert.ToDecimal(textBoxMaior.Text);
                if (maior != 0)
                {
                    textBoxMaior.Text = comandos.ConverterDecimalEmDinheiro(maior);
                }
                else
                {
                    textBoxMaior.Text = string.Empty;
                }
            }
        }
        private void alturaMinTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void formCatalogoCapsulasAdicionar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void formCatalogoCapsulasAdicionar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                formConsultaRapida consultaRapida = new formConsultaRapida();
                consultaRapida.ShowDialog();
            }
        }

        private void textBoxProdutos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void textBoxProdutos_Leave(object sender, EventArgs e)
        {
            int produtos;

            if (textBoxProdutos.Text == string.Empty || textBoxProdutos.Text == "0")
            {
                produtos = 1;
                textBoxProdutos.Text = produtos.ToString();
            }
        }

        #endregion

        #region Movimentacao do Formulário
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
