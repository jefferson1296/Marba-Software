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
    public partial class formAtividadesCadastrarAtividade : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        formAtividadesCadastrar form_cadastrar = new formAtividadesCadastrar();
        formAtividadesEditar form_editar = new formAtividadesEditar();

        bool cadastramento;

        string categoria;

        public formAtividadesCadastrarAtividade()
        {
            InitializeComponent();
        }

        public formAtividadesCadastrarAtividade(formAtividadesCadastrar Form_cadastrar)
        {
            InitializeComponent();
            form_cadastrar = Form_cadastrar;
            cadastramento = true;
        }

        public formAtividadesCadastrarAtividade(formAtividadesEditar Form_editar)
        {
            InitializeComponent();
            form_editar = Form_editar;
            cadastramento = false;
        }

        private void formAtividadesCadastrarAtividade_Load(object sender, EventArgs e)
        {
            List<string> lista_setores = comandos.preencherComboSetores();
            comboBoxSetores.Items.Add("Todos");

            foreach (string x in lista_setores) { comboBoxSetores.Items.Add(x); }
            prioridadeComboBox.SelectedIndex = 0;

            categoria = form_editar.Atividade.Categoria;

            AtualizarComboBoxCategorias();

            if (!cadastramento)
            {
                radioButtonRotina.Enabled = false;
                radioButtonAtividade.Enabled = false;

                //descricaoTextBox.ReadOnly = true;
                //descricaoTextBox.BackColor = Color.Gainsboro;
                descricaoTextBox.Text = form_editar.Atividade.Descricao;
                descricaoTextBox.SelectionStart = descricaoTextBox.Text.Length;

                comboBoxSetores.SelectedItem = form_editar.Atividade.Setor;
                comboBoxCargos.SelectedItem = form_editar.Atividade.Cargo;
                comboBoxCategoria.SelectedItem = categoria;
                prioridadeComboBox.SelectedItem = form_editar.Atividade.Prioridade;
                radioButtonRotina.Checked = form_editar.Atividade.Rotina;

                if (form_editar.Atividade.Rotina)
                {
                    intervaloTextBox.Text = form_editar.Atividade.Intervalo.ToString();
                }
            }
        }

        private void AtualizarComboBoxCategorias()
        {

            List<string> categorias = comandos.PreencherComboCategoriasDeAtividades();
            AutoCompleteStringCollection colecao = new AutoCompleteStringCollection();

            comboBoxCategoria.DataSource = categorias;

            foreach (string atividade in categorias)
            {
                colecao.Add(atividade);
            }

            comboBoxCategoria.AutoCompleteCustomSource = colecao;
        }
        private void radioButtonRotina_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRotina.Checked)
            {
                label5.Visible = true;
                intervaloTextBox.Visible = true;

                if (cadastramento)
                {
                    form_cadastrar.Height = form_cadastrar.Height + 35;
                }
                else
                {
                    form_editar.Height = form_editar.Height + 35;
                }
            }
            else
            {
                label5.Visible = false;
                intervaloTextBox.Visible = false;
                intervaloTextBox.Text = "0";

                if (cadastramento)
                {
                    form_cadastrar.Height = form_cadastrar.Height - 35;
                }
                else
                {
                    form_editar.Height = form_editar.Height - 35;
                }
            }

            if (cadastramento)
            {
                form_cadastrar.Atividade.Rotina = radioButtonRotina.Checked;
            }
            else
            {
                form_editar.Atividade.Rotina = radioButtonRotina.Checked;
            }
        }

        private void descricaoTextBox_Leave(object sender, EventArgs e)
        {
            if (cadastramento)
            {
                form_cadastrar.Atividade.Descricao = descricaoTextBox.Text;
            }
            else
            {
                form_editar.Atividade.Descricao = descricaoTextBox.Text;
            }
        }

        private void comboBoxSetores_SelectedIndexChanged(object sender, EventArgs e)
        {
            string setor = comboBoxSetores.Text;
            comboBoxCargos.Items.Clear();

            comboBoxCargos.Items.Add("Todos");

            List<string> cargos = comandos.PreencherComboCargosPeloSetor(setor);
            foreach (string x in cargos) { comboBoxCargos.Items.Add(x); }

            if (setor == "Todos")
            {
                comboBoxCargos.SelectedItem = "Todos";
                comboBoxCargos.Enabled = false;
            }
            else
            {
                comboBoxCargos.Enabled = true;
            }

            if (cadastramento)
            {
                form_cadastrar.Atividade.Setor = comboBoxSetores.Text;
            }
            else
            {
                form_editar.Atividade.Setor = comboBoxSetores.Text;
            }
        }

        private void comboBoxCargos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cadastramento)
            {
                form_cadastrar.Atividade.Cargo = comboBoxCargos.Text;
            }
            else
            {
                form_editar.Atividade.Cargo = comboBoxCargos.Text;
            }
        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cadastramento)
            {
                form_cadastrar.Atividade.Categoria = comboBoxCategoria.Text;
            }
            else
            {
                form_editar.Atividade.Categoria = comboBoxCategoria.Text;
            }
        }

        private void prioridadeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cadastramento)
            {
                try
                {
                    form_cadastrar.Atividade.Prioridade = Convert.ToInt32(prioridadeComboBox.Text);
                }
                catch
                {
                    form_cadastrar.Atividade.Prioridade = 0;
                }          
            }
            else
            {
                try
                {
                    form_editar.Atividade.Prioridade = Convert.ToInt32(prioridadeComboBox.Text);
                }
                catch
                {
                    form_editar.Atividade.Prioridade = 0;
                }
            }
        }

        private void intervaloTextBox_Enter(object sender, EventArgs e)
        {
            if (intervaloTextBox.Text == "0")
                intervaloTextBox.Text = string.Empty;
        }

        private void intervaloTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void intervaloTextBox_Leave(object sender, EventArgs e)
        {
            if (intervaloTextBox.Text == string.Empty)
                intervaloTextBox.Text = "0";

            if (cadastramento)
            {
                try
                {
                    form_cadastrar.Atividade.Intervalo = Convert.ToInt32(intervaloTextBox.Text);
                }
                catch
                {
                    form_cadastrar.Atividade.Intervalo = 0;
                }
            }
            else
            {
                try
                {
                    form_editar.Atividade.Intervalo = Convert.ToInt32(intervaloTextBox.Text);
                }
                catch
                {
                    form_editar.Atividade.Intervalo = 0;
                }
            }
        }

        private void comboBoxCategoria_Leave(object sender, EventArgs e)
        {
            if (cadastramento)
            {
                form_cadastrar.Atividade.Categoria = comboBoxCategoria.Text;
            }
            else
            {
                form_editar.Atividade.Categoria = comboBoxCategoria.Text;
            }
        }
    }
}
