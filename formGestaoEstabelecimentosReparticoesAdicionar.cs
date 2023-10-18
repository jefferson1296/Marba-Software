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
    public partial class formGestaoEstabelecimentosReparticoesAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id_estabelecimento;
        Reparticao reparticao = new Reparticao();

        bool estabelecimento;
        bool cadastramento;

        public formGestaoEstabelecimentosReparticoesAdicionar()
        {
            InitializeComponent();
        }
        public formGestaoEstabelecimentosReparticoesAdicionar(int ID_Estabelecimento, Reparticao Reparticao)
        {
            InitializeComponent();
            cadastramento = false;
            reparticao = Reparticao;
            id_estabelecimento = ID_Estabelecimento;

            if (ID_Estabelecimento != 0)
                estabelecimento = true;
        }
        public formGestaoEstabelecimentosReparticoesAdicionar(int ID_Estabelecimento)
        {
            InitializeComponent();
            cadastramento = true;
            id_estabelecimento = ID_Estabelecimento;

            if (ID_Estabelecimento != 0)
                estabelecimento = true;
        }

        private void formGestaoEstabelecimentosReparticoesAdicionar_Load(object sender, EventArgs e)
        {
            List<string> estabelecimentos = comandos.PreencherComboEstabelecimentos();
            foreach (string x in estabelecimentos) { comboBoxEstabelecimentos.Items.Add(x); }
            comboBoxEstabelecimentos.DropDownHeight = 120;

            List<string> setores = comandos.preencherComboSetores();
            foreach (string x in setores) { comboBoxSetores.Items.Add(x); }
            comboBoxSetores.DropDownHeight = 120;

            List<Colaborador> colaboradores = comandos.ListaDeColaboradoresTaticos();
            colaboradorComboBox.ValueMember = "ID_Colaborador";
            colaboradorComboBox.DisplayMember = "Nome_Colaborador";
            colaboradorComboBox.DataSource = colaboradores;

            if (estabelecimento)
            {
                comboBoxEstabelecimentos.SelectedItem = comandos.TrazerEstabelecimento(id_estabelecimento);
                comboBoxEstabelecimentos.Enabled = false;
            }

            if (!cadastramento)
            {
                comboBoxEstabelecimentos.SelectedItem = reparticao.Estabelecimento;
                textBoxReparticao.Text = reparticao.Descricao;
                textBoxMetros.Text = reparticao.Metros.ToString();
                comboBoxSetores.SelectedItem = reparticao.Setor;
                colaboradorComboBox.SelectedValue = reparticao.ID_Gerente;
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

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            string estabelecimento = comboBoxEstabelecimentos.Text;
            string setor = comboBoxSetores.Text;
            string reparticao = textBoxReparticao.Text;
            string gerente = colaboradorComboBox.Text;
            int metros = Convert.ToInt32(textBoxMetros.Text);

            if (reparticao == string.Empty)
            {
                MessageBox.Show("Informe a repetição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (estabelecimento == string.Empty)
            {
                MessageBox.Show("Informe o estabelecimento para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (setor == string.Empty)
            {
                MessageBox.Show("Informe o setor para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (gerente == string.Empty)
            {
                MessageBox.Show("Informe o gerente para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.reparticao.Descricao = reparticao;
                this.reparticao.Estabelecimento = estabelecimento;
                this.reparticao.Setor = setor;
                this.reparticao.Metros = metros;
                this.reparticao.ID_Gerente = (int)colaboradorComboBox.SelectedValue;

                if (cadastramento)
                {
                    comandos.CadastrarReparticao(this.reparticao);
                }
                else
                {
                    comandos.EditarReparticao(this.reparticao);
                }

                Dispose();
            }
        }
    }
}
