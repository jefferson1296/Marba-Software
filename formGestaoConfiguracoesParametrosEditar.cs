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
    public partial class formGestaoConfiguracoesParametrosEditar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        bool cadastramento;
        formGestaoConfiguracoes configuracoes = new formGestaoConfiguracoes();
        Parametro parametro = new Parametro();
        public formGestaoConfiguracoesParametrosEditar()
        {
            InitializeComponent();
        }
        public formGestaoConfiguracoesParametrosEditar(formGestaoConfiguracoes Configuracoes, Parametro Parametro)
        {
            InitializeComponent();
            configuracoes = Configuracoes;
            parametro = Parametro;
            cadastramento = false;
        }
        public formGestaoConfiguracoesParametrosEditar(formGestaoConfiguracoes Configuracoes)
        {
            InitializeComponent();
            configuracoes = Configuracoes;
            cadastramento = true;
        }
        private void formGestaoConfiguracoesParametrosEditar_Load(object sender, EventArgs e)
        {
            if (cadastramento)
            {
                radioButtonDecimal.Checked = true;
                textBoxParametro.ReadOnly = false;
                textBoxParametro.TabStop = true;
                Text = "Cadastrar parâmetro";
            }
            else
            {
                textBoxParametro.Text = parametro.Descricao;

                if (parametro.Tipo == "Booleano")
                {
                    radioButtonBool.Checked = true;
                    comboBoxValor.Visible = true;
                    textBoxValor.Visible = false;
                    if (Convert.ToBoolean(parametro.Valor)) { comboBoxValor.SelectedItem = "Verdadeiro"; }
                    else { comboBoxValor.SelectedItem = "Falso"; }
                }
                else if (parametro.Tipo == "Decimal")
                {
                    radioButtonDecimal.Checked = true;
                    textBoxValor.Text = parametro.Valor;
                }
                else
                {
                    radioButtonTexto.Checked = true;
                    textBoxValor.Text = parametro.Valor;
                }

                radioButtonBool.Enabled = false;
                radioButtonDecimal.Enabled = false;
                radioButtonTexto.Enabled = false;
            }
        }

        private void textBoxValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (parametro.Tipo == "Decimal")
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
                        if (!textBoxValor.Text.Contains(','))
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
        }

        private void textBoxValor_Leave(object sender, EventArgs e)
        {
            string valor = textBoxValor.Text;

            if (parametro.Tipo == "Decimal")
            {
                decimal conversao;

                if (valor == string.Empty) { conversao = 0; }
                else { conversao = Convert.ToDecimal(valor); }

                parametro.Valor = conversao.ToString("F");
                textBoxValor.Text = parametro.Valor;
            }
            else if (parametro.Tipo == "Texto")
            {
                parametro.Valor = valor;
            }
        }

        private void comboBoxValor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valor = comboBoxValor.Text;
            if (valor == "Verdadeiro") { parametro.Valor = "true"; }
            else { parametro.Valor = "false"; }
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            if (cadastramento)
            {
                string descricao = textBoxParametro.Text;
                string valor = parametro.Valor;

                if (descricao == string.Empty)
                {
                    MessageBox.Show("Informe o nome do parâmetro para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (valor == string.Empty)
                {
                    MessageBox.Show("Informe o valor do parâmetro para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    parametro.Descricao = descricao;
                    comandos.CadastrarParametro(parametro);
                    Dispose();
                }
            }
            else
            {
                foreach (Parametro Parametro in configuracoes.Parametros)
                {
                    if (Parametro.Descricao == parametro.Descricao)
                    {
                        Parametro.Valor = parametro.Valor;
                        Parametro.Edicao = true;
                    }
                }

                Dispose();
            }
        }

        private void radioButtonDecimal_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDecimal.Checked && cadastramento)
            {
                comboBoxValor.Visible = false;
                textBoxValor.Visible = true;
                textBoxValor.Clear();
                parametro.Tipo = "Decimal";
            }
        }

        private void radioButtonBool_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBool.Checked && cadastramento)
            {
                comboBoxValor.Visible = true;
                textBoxValor.Visible = false;
                comboBoxValor.SelectedIndex = 0;
                parametro.Tipo = "Booleano";
            }
        }

        private void radioButtonTexto_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTexto.Checked && cadastramento)
            {
                comboBoxValor.Visible = false;
                textBoxValor.Visible = true;
                textBoxValor.Clear();
                parametro.Tipo = "Texto";
            }
        }
    }
}
