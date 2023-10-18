using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MarbaSoftware
{
    public partial class formProdutosEditarProduto : Form
    {
        #region Inicialização

        ComandosSQL comandos = new ComandosSQL();

        bool cadastramento;
        formProdutosCadastrar form_cadastrar;
        formProdutosEditar form_editar;
        public List<string> Fornecedores = new List<string>();

        public formProdutosEditarProduto()
        {
            InitializeComponent();
        }
        public formProdutosEditarProduto(formProdutosCadastrar Cadastrar)
        {
            InitializeComponent();
            form_cadastrar = Cadastrar;
            cadastramento = true;
        }
        public formProdutosEditarProduto(formProdutosEditar Editar)
        {
            InitializeComponent();
            form_editar = Editar;
            cadastramento = false;
        }
        private void formProdutosEditar_Load(object sender, EventArgs e)
        {
            comboBoxFabricante.DropDownHeight = 120;
            utensilioComboBox.DropDownHeight = 120;
            comboBoxMateriaPrima.DropDownHeight = 120;
            comboBoxMateriaPrima.DropDownWidth = 180;

            List<string> Fabricantes = comandos.TrazerFabricantes();
            foreach(string x in Fabricantes) { comboBoxFabricante.Items.Add(x); }
            comboBoxFabricante.Update();
            comboBoxFabricante.DropDownHeight = 120;

            List<string> Utensilios = comandos.TrazerUtensilios();
            foreach (string x in Utensilios) { utensilioComboBox.Items.Add(x); }
            utensilioComboBox.Update();
            //utensilioComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //utensilioComboBox.AutoCompleteCustomSource = comandos.AutoCompleteUtensilios();
            utensilioComboBox.SelectedIndex = -1;

            List<string> Materiais = comandos.TrazerMateriaPrima();
            foreach (string x in Materiais) { comboBoxMateriaPrima.Items.Add(x); }
            comboBoxMateriaPrima.Update();
            comboBoxMateriaPrima.SelectedIndex = -1;

            if (cadastramento)
            {
                if (form_cadastrar.cadastrar_conjunto)
                {
                    string fabricante = form_cadastrar.conjunto.Fabricante;
                    string Tipo_Venda = form_cadastrar.conjunto.Tipo_Venda;
                    decimal Base = form_cadastrar.conjunto.Custo_Base;
                    decimal Qtd_Produtos = form_cadastrar.conjunto.Qtd_Produtos;
                    decimal Aliquota_ICMS = form_cadastrar.conjunto.Aliquota_ICMS;
                    decimal Aliquota_IPI = form_cadastrar.conjunto.Aliquota_IPI;
                    string cod_extra = form_cadastrar.conjunto.Cod_Extra;

                    codExtraTextBox.Text = cod_extra;
                    codExtraTextBox.ReadOnly = true;
                    codExtraTextBox.BackColor = Color.WhiteSmoke;
                    codExtraTextBox.ForeColor = Color.DimGray;

                    comboBoxFabricante.SelectedItem = fabricante;
                    comboBoxFabricante.Enabled = false;

                    if (Tipo_Venda == "UNIDADE")
                    {
                        Base = Base / Qtd_Produtos;
                        baseTextBox.Text = Base.ToString("C");
                    }
                    else
                    {
                        baseTextBox.Text = Base.ToString("C");
                    }

                    icmsTextBox.Text = Aliquota_ICMS.ToString("F") + "%";
                    ipiTextBox.Text = Aliquota_IPI.ToString("F") + "%";
                    custoTextBox.Text = (Base + (Base / 100 * Aliquota_ICMS) + (Base / 100 * Aliquota_IPI)).ToString("C");

                    baseTextBox.Enabled = false;
                    icmsTextBox.Enabled = false;
                    ipiTextBox.Enabled = false;
                    custoTextBox.Enabled = false;
                }
            }
            else
            {
                nomeTextBox.Text = form_editar.Produto.Nome_Produto;
                codBarrasTextBox.Text = form_editar.Produto.Cod_Barras;
                utensilioComboBox.SelectedItem = form_editar.Produto.Utensilio;
                especificacaoComboBox.SelectedItem = form_editar.Produto.Especificacao;
                comboBoxMateriaPrima.SelectedItem = form_editar.Produto.MateriaPrima;
                comboBoxFabricante.SelectedItem = form_editar.Produto.Fabricante;
                caixaTextBox.Text = form_editar.Produto.Caixa.ToString();
                codExtraTextBox.Text = form_editar.Produto.Cod_Extra;
                baseTextBox.Text = form_editar.Produto.Preco_Base.ToString("C");
                ipiTextBox.Text = form_editar.Produto.Aliquota_IPI.ToString("F") + "%";
                icmsTextBox.Text = form_editar.Produto.Aliquota_ICMS.ToString("F") + "%";
                custoTextBox.Text = (form_editar.Produto.Preco_Base + (form_editar.Produto.Preco_Base / 100 * form_editar.Produto.Aliquota_ICMS) + (form_editar.Produto.Preco_Base / 100 * form_editar.Produto.Aliquota_IPI)).ToString("C");

                try
                {
                    string[] capacidade = form_editar.Produto.Capacidade.Split(' ');
                    medidaTextBox.Text = capacidade[0];
                    medidaComboBox.Text = capacidade[1];
                }
                catch { }

                try
                {
                    string[] altura = form_editar.Produto.Altura.Split(' ');
                    altTextBox.Text = altura[0];
                    altComboBox.Text = altura[1];
                }
                catch { }

                try
                {
                    string[] largura = form_editar.Produto.Largura.Split(' ');
                    larTextBox.Text = largura[0];
                    larComboBox.Text = largura[1];
                }
                catch { }

                try
                {
                    string[] comprimento = form_editar.Produto.Comprimento.Split(' ');
                    comTextBox.Text = comprimento[0];
                    comComboBox.Text = comprimento[1];
                }
                catch { }

                try
                {
                    string[] diametro = form_editar.Produto.Diametro.Split(' ');
                    diTextBox.Text = diametro[0];
                    diComboBox.Text = diametro[1];
                }
                catch { }
            }
        }

        #endregion

        #region Botões
        private void espPictureBox_Click(object sender, EventArgs e)
        {
            string especificacao = especificacaoComboBox.Text;
            string utensilio = utensilioComboBox.Text;

            if (utensilio == string.Empty)
            {
                MessageBox.Show("Informe o utensílio!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (especificacao == string.Empty)
            {
                MessageBox.Show("Informe a Especificação que deseja cadastrar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comandos.VerificarSeEspecificacaoJaExiste(utensilio, especificacao))
            {
                MessageBox.Show("Essa especificação já está cadastrada!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                comandos.InserirEspecificacao(utensilio, especificacao);
                MessageBox.Show("Especificação cadastrada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarComboEspecificacoes();
            }
        }

        private void buttonUtensilio_Click(object sender, EventArgs e)
        {
            formCatalogoUtensiliosCadastrar utensilio = new formCatalogoUtensiliosCadastrar();
            utensilio.ShowDialog();

            utensilioComboBox.Items.Clear();
            List<string> Utensilios = comandos.TrazerUtensilios();
            foreach (string x in Utensilios) { utensilioComboBox.Items.Add(x); }
            utensilioComboBox.Update();
            utensilioComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            utensilioComboBox.AutoCompleteCustomSource = comandos.AutoCompleteUtensilios();
            utensilioComboBox.SelectedIndex = -1;
        }


        #endregion
        #region Eventos
        private void formProdutosEditar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }  
        private void caixaTextBox_Leave(object sender, EventArgs e)
        {
            if (caixaTextBox.Text == string.Empty)
                caixaTextBox.Text = "0";

            if (cadastramento)
            {
                form_cadastrar.Produto.Caixa = Convert.ToInt32(caixaTextBox.Text);
            }
            else
            {
                form_editar.Produto.Caixa = Convert.ToInt32(caixaTextBox.Text);
            }
        }
        private void caixaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
        private void caixaTextBox_Enter(object sender, EventArgs e)
        {
            if (caixaTextBox.Text == "0")
                caixaTextBox.Text = string.Empty;
        }

        private void nomeTextBox_Enter(object sender, EventArgs e)
        {
            nomeTextBox.SelectionStart = nomeTextBox.Text.Length;
        }
        private void codExtraTextBox_Leave(object sender, EventArgs e)
        {

            if (cadastramento)
            {
                form_cadastrar.Produto.Cod_Extra = codExtraTextBox.Text;
            }
            else
            {
                form_editar.Produto.Cod_Extra = codExtraTextBox.Text;
            }
        }
        private void utensilioComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarComboEspecificacoes();
        }
        private void AtualizarComboEspecificacoes()
        {
            especificacaoComboBox.Items.Clear();
            string utensilio = utensilioComboBox.Text;
            try
            {
                List<string> lista = comandos.PreencherComboEspecificacao(utensilio);
                foreach (string x in lista) { especificacaoComboBox.Items.Add(x); }
                especificacaoComboBox.AutoCompleteCustomSource = comandos.AutoCompleteEspecificacao(utensilio);
            }
            catch { }
        }
        private void icmsTextBox_Enter(object sender, EventArgs e)
        {
            icmsTextBox.ForeColor = Color.Black;
            if (icmsTextBox.Text == "0,00%")
            {
                icmsTextBox.Text = string.Empty;
            }
            else
            {
                string[] partir = icmsTextBox.Text.Split('%');
                icmsTextBox.Text = partir[0];
            }
        }
        private void icmsTextBox_Leave(object sender, EventArgs e)
        {
            decimal aliquota_icms;

            if (icmsTextBox.Text == string.Empty)
            {
                aliquota_icms = 0;
                icmsTextBox.ForeColor = Color.Gray;
            }
            else
            {
                aliquota_icms = Convert.ToDecimal(icmsTextBox.Text);
                icmsTextBox.ForeColor = Color.Black;
            }

            icmsTextBox.Text = aliquota_icms.ToString("F") + "%";

            if (cadastramento)
            {
                form_cadastrar.Produto.Aliquota_ICMS = aliquota_icms;
            }
            else
            {
                form_editar.Produto.Aliquota_ICMS = aliquota_icms;
            }

            CalcularPrecoDeCusto();
        }
        private void ipiTextBox_Leave(object sender, EventArgs e)
        {
            decimal aliquota_ipi;

            if (ipiTextBox.Text == string.Empty)
            {
                aliquota_ipi = 0;
                ipiTextBox.ForeColor = Color.Gray;
            }
            else
            {
                aliquota_ipi = Convert.ToDecimal(ipiTextBox.Text);
                ipiTextBox.ForeColor = Color.Black;
            }

            ipiTextBox.Text = aliquota_ipi.ToString("F") + "%";

            if (cadastramento)
            {
                form_cadastrar.Produto.Aliquota_IPI = aliquota_ipi;
            }
            else
            {
                form_editar.Produto.Aliquota_IPI = aliquota_ipi;
            }

            CalcularPrecoDeCusto();
        }
        private void ipiTextBox_Enter(object sender, EventArgs e)
        {
            ipiTextBox.ForeColor = Color.Black;
            if (ipiTextBox.Text == "0,00%")
            {
                ipiTextBox.Text = string.Empty;
            }
            else
            {
                string[] partir = ipiTextBox.Text.Split('%');
                ipiTextBox.Text = partir[0];
            }
        }
        private void baseTextBox_Leave(object sender, EventArgs e)
        {
            decimal base_custo;

            if (baseTextBox.Text == string.Empty)
            {
                base_custo = 0;
                baseTextBox.ForeColor = Color.Gray;
            }
            else
            {
                base_custo = Convert.ToDecimal(baseTextBox.Text);
                baseTextBox.ForeColor = Color.Black;
            }

            baseTextBox.Text = base_custo.ToString("C");

            if (cadastramento)
            {
                form_cadastrar.Produto.Preco_Base = base_custo;
            }
            else
            {
                form_editar.Produto.Preco_Base = base_custo;
            }

            CalcularPrecoDeCusto();
        }
        private void baseTextBox_Enter(object sender, EventArgs e)
        {
            baseTextBox.ForeColor = Color.Black;
            if (baseTextBox.Text == "R$0,00")
            {
                baseTextBox.Text = string.Empty;
            }
            else
            {
                string[] partir = baseTextBox.Text.Split('$');
                baseTextBox.Text = partir[1];
            }
        }
        private void baseTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!baseTextBox.Text.Contains(','))
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
        private void ipiTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!ipiTextBox.Text.Contains(','))
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
        private void icmsTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!icmsTextBox.Text.Contains(','))
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

        private void nomeTextBox_Leave(object sender, EventArgs e)
        {
            if (cadastramento)
            {
                form_cadastrar.Produto.Nome_Produto = nomeTextBox.Text;
            }
            else
            {
                form_editar.Produto.Nome_Produto = nomeTextBox.Text;
            }
        }

        private void utensilioComboBox_Leave(object sender, EventArgs e)
        {
            if (cadastramento)
            {
                form_cadastrar.Produto.Utensilio = utensilioComboBox.Text;
            }
            else
            {
                form_editar.Produto.Utensilio = utensilioComboBox.Text;
            }
        }

        private void especificacaoComboBox_Leave(object sender, EventArgs e)
        {
            if (cadastramento)
            {
                form_cadastrar.Produto.Especificacao = especificacaoComboBox.Text;
            }
            else
            {
                form_editar.Produto.Especificacao = especificacaoComboBox.Text;
            }
        }

        private void comboBoxMateriaPrima_Leave(object sender, EventArgs e)
        {
            if (cadastramento)
            {
                form_cadastrar.Produto.MateriaPrima = comboBoxMateriaPrima.Text;
            }
            else
            {
                form_editar.Produto.MateriaPrima = comboBoxMateriaPrima.Text;
            }
        }

        private void comboBoxFabricante_Leave(object sender, EventArgs e)
        {
            if (cadastramento)
            {
                form_cadastrar.Produto.Fabricante = comboBoxFabricante.Text;
            }
            else
            {
                form_editar.Produto.Fabricante = comboBoxFabricante.Text;
            }
        }

        private void altTextBox_Leave(object sender, EventArgs e)
        {
            if (altTextBox.Text != string.Empty && altComboBox.Text != string.Empty)
            {
                if (cadastramento)
                {
                    form_cadastrar.Produto.Altura = altTextBox.Text + " " + altComboBox.Text;
                }
                else
                {
                    form_editar.Produto.Altura = altTextBox.Text + " " + altComboBox.Text;
                }
            }
            else
            {
                if (cadastramento)
                {
                    form_cadastrar.Produto.Altura = string.Empty;
                }
                else
                {
                    form_editar.Produto.Altura = string.Empty;
                }
            }
        }

        private void altComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (altTextBox.Text != string.Empty && altComboBox.Text != string.Empty)
            {
                if (cadastramento)
                {
                    form_cadastrar.Produto.Altura = altTextBox.Text + " " + altComboBox.Text;
                }
                else
                {
                    form_editar.Produto.Altura = altTextBox.Text + " " + altComboBox.Text;
                }
            }
            else
            {
                if (cadastramento)
                {
                    form_cadastrar.Produto.Altura = string.Empty;
                }
                else
                {
                    form_editar.Produto.Altura = string.Empty;
                }
            }
        }

        private void larTextBox_Leave(object sender, EventArgs e)
        {
            if (larTextBox.Text != string.Empty && larComboBox.Text != string.Empty)
            {
                if (cadastramento)
                {
                    form_cadastrar.Produto.Largura = larTextBox.Text + " " + larComboBox.Text;
                }
                else
                {
                    form_editar.Produto.Largura = larTextBox.Text + " " + larComboBox.Text;
                }
            }
            else
            {
                if (cadastramento)
                {
                    form_cadastrar.Produto.Largura = string.Empty;
                }
                else
                {
                    form_editar.Produto.Largura = string.Empty;
                }
            }
        }

        private void larComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (larTextBox.Text != string.Empty && altComboBox.Text != string.Empty)
            {
                if (cadastramento)
                {
                    form_cadastrar.Produto.Largura = larTextBox.Text + " " + larComboBox.Text;
                }
                else
                {
                    form_editar.Produto.Largura = larTextBox.Text + " " + larComboBox.Text;
                }
            }
            else
            {
                if (cadastramento)
                {
                    form_cadastrar.Produto.Largura = string.Empty;
                }
                else
                {
                    form_editar.Produto.Largura = string.Empty;
                }
            }
        }

        private void comTextBox_Leave(object sender, EventArgs e)
        {
            if (comTextBox.Text != string.Empty && comComboBox.Text != string.Empty)
            {
                if (cadastramento)
                {
                    form_cadastrar.Produto.Comprimento = comTextBox.Text + " " + comComboBox.Text;
                }
                else
                {
                    form_editar.Produto.Comprimento = comTextBox.Text + " " + comComboBox.Text;
                }
            }
            else
            {
                if (cadastramento)
                {
                    form_cadastrar.Produto.Comprimento = string.Empty;
                }
                else
                {
                    form_editar.Produto.Comprimento = string.Empty;
                }
            }
        }

        private void comComboBox_Leave(object sender, EventArgs e)
        {
            if (comTextBox.Text != string.Empty && comComboBox.Text != string.Empty)
            {
                if (cadastramento)
                {
                    form_cadastrar.Produto.Comprimento = comTextBox.Text + " " + comComboBox.Text;
                }
                else
                {
                    form_editar.Produto.Comprimento = comTextBox.Text + " " + comComboBox.Text;
                }
            }
            else
            {
                if (cadastramento)
                {
                    form_cadastrar.Produto.Comprimento = string.Empty;
                }
                else
                {
                    form_editar.Produto.Comprimento = string.Empty;
                }
            }
        }

        private void diTextBox_Leave(object sender, EventArgs e)
        {
            if (diTextBox.Text != string.Empty && diComboBox.Text != string.Empty)
            {
                if (cadastramento)
                {
                    form_cadastrar.Produto.Diametro = diTextBox.Text + " " + diComboBox.Text;
                }
                else
                {
                    form_editar.Produto.Diametro = diTextBox.Text + " " + diComboBox.Text;
                }
            }
            else
            {
                if (cadastramento)
                {
                    form_cadastrar.Produto.Diametro = string.Empty;
                }
                else
                {
                    form_editar.Produto.Diametro = string.Empty;
                }
            }
        }

        private void diComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (diTextBox.Text != string.Empty && diComboBox.Text != string.Empty)
            {
                if (cadastramento)
                {
                    form_cadastrar.Produto.Diametro = diTextBox.Text + " " + diComboBox.Text;
                }
                else
                {
                    form_editar.Produto.Diametro = diTextBox.Text + " " + diComboBox.Text;
                }
            }
            else
            {
                if (cadastramento)
                {
                    form_cadastrar.Produto.Diametro = string.Empty;
                }
                else
                {
                    form_editar.Produto.Diametro = string.Empty;
                }
            }
        }

        private void medidaTextBox_Leave(object sender, EventArgs e)
        {
            if (medidaTextBox.Text != string.Empty && medidaComboBox.Text != string.Empty)
            {
                if (cadastramento)
                {
                    form_cadastrar.Produto.Capacidade = medidaTextBox.Text + " " + medidaComboBox.Text;
                }
                else
                {
                    form_editar.Produto.Capacidade = medidaTextBox.Text + " " + medidaComboBox.Text;
                }
            }
            else
            {
                if (cadastramento)
                {
                    form_cadastrar.Produto.Capacidade = string.Empty;
                }
                else
                {
                    form_editar.Produto.Capacidade = string.Empty;
                }
            }
        }

        private void medidaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (medidaTextBox.Text != string.Empty && medidaComboBox.Text != string.Empty)
            {
                if (cadastramento)
                {
                    form_cadastrar.Produto.Capacidade = medidaTextBox.Text + " " + medidaComboBox.Text;
                }
                else
                {
                    form_editar.Produto.Capacidade = medidaTextBox.Text + " " + medidaComboBox.Text;
                }
            }
            else
            {
                if (cadastramento)
                {
                    form_cadastrar.Produto.Capacidade = string.Empty;
                }
                else
                {
                    form_editar.Produto.Capacidade = string.Empty;
                }
            }
        }

        #endregion
        #region Métodos criados
        private void CalcularPrecoDeCusto()
        {
            decimal base_custo;
            decimal a_ipi;
            decimal a_icms;

            decimal custo;

            if (cadastramento)
            {
                base_custo = form_cadastrar.Produto.Preco_Base;
                a_ipi = form_cadastrar.Produto.Aliquota_IPI;
                a_icms = form_cadastrar.Produto.Aliquota_ICMS;
            }
            else
            {
                base_custo = form_editar.Produto.Preco_Base;
                a_ipi = form_editar.Produto.Aliquota_IPI;
                a_icms = form_editar.Produto.Aliquota_ICMS;
            }

            custo = base_custo + (base_custo / 100 * a_icms) + (base_custo / 100 * a_ipi);
            custoTextBox.Text = custo.ToString("C");
        }
        #endregion

        private void buttonMaterial_Click(object sender, EventArgs e)
        {
            formProdutosMaterialCadastrar material = new formProdutosMaterialCadastrar();
            material.ShowDialog();

            comboBoxMateriaPrima.Items.Clear();
            List<string> Materiais = comandos.TrazerMateriaPrima();
            foreach (string x in Materiais) { comboBoxMateriaPrima.Items.Add(x); }
            comboBoxMateriaPrima.Update();
            comboBoxMateriaPrima.SelectedIndex = -1;
        }

        private void buttonFabricante_Click(object sender, EventArgs e)
        {
            formFornecedoresFabricantesCadastrar fabricante = new formFornecedoresFabricantesCadastrar();
            fabricante.ShowDialog();

            comboBoxFabricante.Items.Clear();
            List<string> Fabricantes = comandos.TrazerFabricantes();
            foreach (string x in Fabricantes) { comboBoxFabricante.Items.Add(x); }
            comboBoxFabricante.Update();
            comboBoxFabricante.DropDownHeight = 120;
        }

        private void codBarrasTextBox_Leave(object sender, EventArgs e)
        {
            if (cadastramento)
            {
                form_cadastrar.Produto.Cod_Barras = codBarrasTextBox.Text;
            }
            else
            {
                form_editar.Produto.Cod_Barras = codBarrasTextBox.Text;
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
    }
}
