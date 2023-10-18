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
    public partial class formProdutosAjustesPrateleirasAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id_prateleira;
        string localizacao;
        bool cadastramento;

        Prateleira Prateleira = new Prateleira();

        public formProdutosAjustesPrateleirasAdicionar()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            cadastramento = true;
        }
        public formProdutosAjustesPrateleirasAdicionar(int ID_Prateleira)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            id_prateleira = ID_Prateleira;
            cadastramento = false;
        }
        private void formProdutosPrateleirasAdicionar_Load(object sender, EventArgs e)
        {
            comboBoxEstabelecimentos.DropDownHeight = 150;
            comboBoxArmazenamentos.DropDownHeight = 150;
            expositorComboBox.DropDownHeight = 150;
            comboBoxReparticoes.DropDownHeight = 150;

            List<string> estabelecimentos = comandos.PreencherComboEstabelecimentos();
            foreach (string x in estabelecimentos)
            {
                comboBoxEstabelecimentos.Items.Add(x);
            }

            List<string> armazenamentos = comandos.PreencherComboArmazenamentos();
            foreach (string x in armazenamentos)
            {
                comboBoxArmazenamentos.Items.Add(x);
            }

            List<string> expositores = comandos.PreencherComboExpositores();
            foreach (string x in expositores)
            {
                expositorComboBox.Items.Add(x);
            }

            if (!cadastramento)
            {
                labelTitulo.Text = "Editar prateleira";
                Prateleira = comandos.InformacoesDaPrateleira(id_prateleira);

                localizacao = Prateleira.Localizacao;
                localizacaoTextBox.Text = localizacao;
                comboBoxEstabelecimentos.SelectedItem = Prateleira.Estabelecimento;
                comboBoxReparticoes.SelectedValue = Prateleira.ID_Reparticao;

                expositorComboBox.SelectedItem = Prateleira.Expositor;
                comboBoxArmazenamentos.SelectedItem = Prateleira.Armazenamento;

                if (Prateleira.Altura != string.Empty) 
                {
                    try
                    {
                        string[] partir = Prateleira.Altura.Split(' ');
                        alturaTextBox.Text = partir[0];
                        altComboBox.SelectedItem = partir[1];
                    }
                    catch { }                  
                }
                if (Prateleira.Largura != string.Empty)
                {
                    try
                    {
                        string[] partir = Prateleira.Largura.Split(' ');
                        larguraTextBox.Text = partir[0];
                        larComboBox.SelectedItem = partir[1];
                    }
                    catch { }
                }
                if (Prateleira.Comprimento != string.Empty)
                {
                    try
                    {
                        string[] partir = Prateleira.Comprimento.Split(' ');
                        comprimentoTextBox.Text = partir[0];
                        comComboBox.SelectedItem = partir[1];
                    }
                    catch { }
                }
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
        #region Formatação
        private void alturaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
        private void larguraTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
        private void comprimentoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
        #endregion

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
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

        private void buttonConcluir_Click(object sender, EventArgs e)
        {
            string localizacao = localizacaoTextBox.Text;
            string expositor = expositorComboBox.Text;
            string armazenamento = comboBoxArmazenamentos.Text;
            string reparticao = comboBoxReparticoes.Text;

            if (localizacao == string.Empty)
            {
                MessageBox.Show("Informe a referência da prateleira para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (reparticao == string.Empty)
            {
                MessageBox.Show("Informe a repartição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (expositor == string.Empty)
            {
                MessageBox.Show("Informe o tipo de expositor para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (armazenamento == string.Empty)
            {
                MessageBox.Show("Informe o tipo de armazenamento para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (alturaTextBox.Text == string.Empty && altComboBox.Text != string.Empty || alturaTextBox.Text != string.Empty && altComboBox.Text == string.Empty)
            {
                MessageBox.Show("É necessário informar o valor e a unidade de medida da Altura!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (larguraTextBox.Text == string.Empty && larComboBox.Text != string.Empty || larguraTextBox.Text != string.Empty && larComboBox.Text == string.Empty)
            {
                MessageBox.Show("É necessário informar o valor e a unidade de medida da Largura!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comprimentoTextBox.Text == string.Empty && comComboBox.Text != string.Empty || comprimentoTextBox.Text != string.Empty && comComboBox.Text == string.Empty)
            {
                MessageBox.Show("É necessário informar o valor e a unidade de medida do Cumprimento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string altura = alturaTextBox.Text + " " + altComboBox.Text; 
                if (altura == " ")
                {
                    altura = string.Empty;
                }
                
                string largura = larguraTextBox.Text + " " + larComboBox.Text;
                if (largura == " ")
                {
                    largura = string.Empty;
                }

                string comprimento = comprimentoTextBox.Text + " " + comComboBox.Text;
                if (comprimento == " ")
                {
                    comprimento = string.Empty;
                }

                Prateleira.Localizacao = localizacao;
                Prateleira.Altura = altura;
                Prateleira.Largura = largura;
                Prateleira.Comprimento = comprimento;
                Prateleira.ID_Reparticao = (int)comboBoxReparticoes.SelectedValue;
                Prateleira.Expositor = expositor;
                Prateleira.Armazenamento = armazenamento;
           

                if (cadastramento)
                {
                    if (comandos.VerificarSePrateleiraJaExiste(localizacao))
                    {
                        MessageBox.Show("Já existe uma prateleira cadastrada com essa localização!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        comandos.CadastrarPrateleira(Prateleira);
                        Dispose();
                    }
                }
                else
                {
                    if (comandos.VerificarSePrateleiraJaExiste(localizacao) && localizacao != this.localizacao)
                    {
                        MessageBox.Show("Já existe uma prateleira cadastrada com essa localização!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        comandos.EditarPrateleira(Prateleira);
                        Dispose();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
