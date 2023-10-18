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
    public partial class formCatalogoTransformacoesCapsulasSimples : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        Capsula Capsula = new Capsula();
        bool cadastramento;
        int id_capsula;

        string nome_sistema;

        public formCatalogoTransformacoesCapsulasSimples()
        {
            InitializeComponent();
            cadastramento = true;
        }

        public formCatalogoTransformacoesCapsulasSimples(int ID_Capsula)
        {
            InitializeComponent();
            id_capsula = ID_Capsula;
            cadastramento = false;
        }

        private void formCatalogoTransformacoesCapsulasSimples_Load(object sender, EventArgs e)
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

            if (!cadastramento)
            {
                Capsula = comandos.TrazerInformacoesDaCapsula(id_capsula);

                nome_sistema = Capsula.Nome_Sistema;
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
            }
        }

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

        private void textBoxProdutos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void formCatalogoTransformacoesCapsulasSimples_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                formConsultaRapida consultaRapida = new formConsultaRapida();
                consultaRapida.ShowDialog();
            }
        }

        private void formCatalogoTransformacoesCapsulasSimples_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);
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

        private void salvarButton_Click(object sender, EventArgs e)
        {
            AtualizarCapsula();

            string nome_sistema = sistemaTextBox.Text;
            int ideal_produtos = Convert.ToInt32(textBoxProdutos.Text);

            if (nome_sistema == string.Empty)
            {
                MessageBox.Show("Informe o nome do sistema para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comandos.VerificarSeNomeDoSistemaJaExiste(nome_sistema) && nome_sistema != this.nome_sistema)
            {
                MessageBox.Show("O nome do sistema já existe. Informe um nome do sistema válido para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sistemaTextBox.Focus();
            }
            else
            {
                Capsula.Nome_Sistema = nome_sistema;
                Capsula.Ideal_Produtos = ideal_produtos;

                if (cadastramento)
                {
                    comandos.CadastrarCapsula(Capsula);
                }
                else
                {
                    Capsula.ID_Capsula = id_capsula;
                    comandos.EditarCapsula(Capsula);
                }

                Dispose();
            }
        }

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

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void utensilioComboBox_TextChanged(object sender, EventArgs e)
        {
            utensilioComboBox.Text = utensilioComboBox.Text.ToUpper();
            utensilioComboBox.SelectionStart = utensilioComboBox.Text.Length;
        }

        private void espComboBox_TextChanged(object sender, EventArgs e)
        {
            espComboBox.Text = espComboBox.Text.ToUpper();
            espComboBox.SelectionStart = espComboBox.Text.Length;
        }
    }
}
