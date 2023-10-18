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
    public partial class formGestaoEstabelecimentosAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        bool cadastramento;
        Estabelecimento Estabelecimento = new Estabelecimento();
        public formGestaoEstabelecimentosAdicionar()
        {
            InitializeComponent();
            cadastramento = true;
        }
        public formGestaoEstabelecimentosAdicionar(int ID_Estabelecimento)
        {
            InitializeComponent();
            Estabelecimento.ID_Estabelecimento = ID_Estabelecimento;
            cadastramento = false;
        }
        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            string descricao = textBoxDescricao.Text;
            string categoria = comboBoxCategoria.Text;
            int metros = Convert.ToInt32(textBoxMetros.Text);
            string endereco = txbEndereco.Text;
            string numero = txbNumero.Text;
            string bairro = txbBairro.Text;
            string cidade = txbCidade.Text;
            string estado = comboBoxEstado.Text;
            string cep = maskedTextBoxCEP.Text;

            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe o nome do estabelecimento para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (categoria == string.Empty)
            {
                MessageBox.Show("Informe a categoria para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cidade == string.Empty)
            {
                MessageBox.Show("Informe a cidade para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (estado == string.Empty)
            {
                MessageBox.Show("Informe o estado para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Estabelecimento.Descricao = descricao;
                Estabelecimento.Categoria = categoria;
                Estabelecimento.Metros = metros;
                Estabelecimento.Endereco = endereco;
                Estabelecimento.Numero = numero;
                Estabelecimento.Bairro = bairro;
                Estabelecimento.Cidade = cidade;
                Estabelecimento.Estado = estado;
                Estabelecimento.CEP = cep;
                if (radioButtonFuncionando.Checked) { Estabelecimento.Status = "Funcionando"; }
                else { Estabelecimento.Status = "Planejamento"; }

                if (cadastramento)
                {
                    comandos.CadastrarEstabelecimento(Estabelecimento);
                    Dispose();
                }
                else
                {
                    comandos.EditarEstabelecimento(Estabelecimento);
                    Dispose();
                }
            }
        }

        private void formGestaoEstabelecimentosAdicionar_Load(object sender, EventArgs e)
        {
            List<string> categorias = comandos.PreencherComboCategoriasDosEstabelecimentos();
            foreach (string x in categorias) { comboBoxCategoria.Items.Add(x); }
            comboBoxCategoria.DropDownHeight = 120;

            List<string> estados = comandos.PreencherComboBoxEstado();
            foreach (string x in estados) { comboBoxEstado.Items.Add(x); }
            comboBoxEstado.DropDownHeight = 120;

            if (!cadastramento)
            {
                int id = Estabelecimento.ID_Estabelecimento;
                Estabelecimento = comandos.InformacoesDoEstabelecimento(id);

                textBoxDescricao.Text = Estabelecimento.Descricao;
                comboBoxCategoria.SelectedItem = Estabelecimento.Categoria;
                textBoxMetros.Text = Estabelecimento.Metros.ToString();
                txbEndereco.Text = Estabelecimento.Endereco;
                txbNumero.Text = Estabelecimento.Numero;
                txbBairro.Text = Estabelecimento.Bairro;
                txbCidade.Text = Estabelecimento.Cidade;
                comboBoxEstado.SelectedItem = Estabelecimento.Estado;
                maskedTextBoxCEP.Text = Estabelecimento.CEP;

                if (Estabelecimento.Status == "Planejamento") { radioButtonPlanejamento.Checked = true; }
                else { radioButtonFuncionando.Checked = true; }
            }
        }

        private void textBoxMetros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void textBoxMetros_Enter(object sender, EventArgs e)
        {
            if (textBoxMetros.Text == "0")
                textBoxMetros.Text = string.Empty;
        }

        private void textBoxMetros_Leave(object sender, EventArgs e)
        {
            if (textBoxMetros.Text == string.Empty)
                textBoxMetros.Text = "0";
        }
    }
}
