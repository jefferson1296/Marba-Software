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
    public partial class formTelaInicialAtividadesDelegar : Form
    {
        #region Inicialização

        ComandosSQL comandos = new ComandosSQL();
        bool multi_setores;

        AtividadeDelegada atividade_delegada = new AtividadeDelegada();
        AtividadeLancada atividade_lancada = new AtividadeLancada();

        bool atividade_registrada;

        public formTelaInicialAtividadesDelegar()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        public formTelaInicialAtividadesDelegar(AtividadeLancada Atividade_lancada)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            atividade_lancada = Atividade_lancada;
            atividade_registrada = true;
        }

        private void formTelaInicialAtividadesDelegar_Load(object sender, EventArgs e)
        {
            multi_setores = Program.Acessos.Where(x => x.Descricao == "Multi-setores").Select(x => x.Permissao).FirstOrDefault();

            Height = Height - 115;

            List<Colaborador> colaboradores = comandos.PreencherComboColaboradoresPorSetor();

            List<string> lista_setores = comandos.preencherComboSetores();
            foreach (string x in lista_setores) { comboBoxSetores.Items.Add(x); }

            if (atividade_registrada)
            {
                comboBoxSetores.SelectedItem = comandos.TrazerSetorPelaAtividade(atividade_lancada.Descricao);
                atividadeComboBox.SelectedItem = atividade_lancada.Descricao;
                atividadeComboBox.Enabled = false;

                List<string> empenhados = comandos.ListaDeColaboradoresEmpenhados(atividade_lancada.ID_AtividadeLancada);

                foreach (string colaborador in empenhados)
                {
                    colaboradores.RemoveAll(x => x.Nome_Colaborador == colaborador);
                }
            }
            else
            {
                if (multi_setores)
                {
                    comboBoxSetores.Enabled = true;
                }
                else
                {
                    comboBoxSetores.SelectedItem = comandos.SetorPeloColaborador();
                }
            }

            multiplicadorComboBox.SelectedIndex = 0;

            colaboradorComboBox.ValueMember = "ID_Colaborador";
            colaboradorComboBox.DisplayMember = "Nome_Colaborador";
            colaboradorComboBox.DataSource = colaboradores;
            colaboradorComboBox.SelectedIndex = -1;
        }

        #endregion

        #region Fechar

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #endregion

        private void comboBoxSetores_SelectedIndexChanged(object sender, EventArgs e)
        {
            string setor = comboBoxSetores.Text;
            atividadeComboBox.Items.Clear();

            if (setor != string.Empty)
            {
                List<string> atividades = comandos.PreencherComboAtividadesPeloSetor(setor);
                AutoCompleteStringCollection sugestao = new AutoCompleteStringCollection();

                foreach (string x in atividades)
                {
                    atividadeComboBox.Items.Add(x);
                    sugestao.Add(x);
                }

                atividadeComboBox.AutoCompleteCustomSource = sugestao;
                atividadeComboBox.Enabled = true;
            }
            else
            {
                atividadeComboBox.Enabled = false;
            }
        }

        private void atividadeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string atividade = atividadeComboBox.Text;

            Atividade Atividade = comandos.PrioridadeETempoDaAtividade(atividade);
            prioridadeComboBox.SelectedItem = Atividade.Prioridade.ToString();

            colaboradorComboBox.Enabled = true;
            //tempoTextBox.Text = Atividade.Tempo.ToString();
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            string colaborador = colaboradorComboBox.Text;
            string atividade = atividadeComboBox.Text;

            int prioridade = Convert.ToInt32(prioridadeComboBox.Text); 
            
            if (colaborador == string.Empty)
            {
                MessageBox.Show("Informe o nome do colaborador!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (atividade == string.Empty)
            {
                MessageBox.Show("Informe a Atividade!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                bool permitir;

                bool rotina = comandos.VerificarSeAtividadeERotina(atividade);

                if (rotina)
                {
                    if (DialogResult.Yes == MessageBox.Show("Essa atividade é uma rotina.\r\nIsso signifca que a atividade já tem uma data\r\npré-estabelecida para ser lançada.\r\nDeseja delegá-la mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        permitir = true;
                    else
                        permitir = false;
                }
                else
                {
                    permitir = true;
                }

                if (permitir)
                {
                    int id_colaborador = Convert.ToInt32(colaboradorComboBox.SelectedValue);

                    atividade_delegada.Descricao = atividade;
                    atividade_delegada.Status = "Pendente";
                    atividade_delegada.ID_Colaborador = id_colaborador;
                    atividade_delegada.Prioridade = prioridade;

                    atividade_lancada.ID_Colaborador = id_colaborador;

                    if (atividade_registrada)
                    {
                        comandos.DelegarAtividade(atividade_lancada);
                    }
                    else
                    {
                        comandos.LancarAtividade(atividade_delegada);
                        comandos.DelegarAtividadeAoLancar(atividade_delegada);
                    }

                    Dispose();
                }

            }
        }

        #region Formatação

        private void tempoTextBox_Leave(object sender, EventArgs e)
        {
            if (tempoTextBox.Text == string.Empty)
            {
                tempoTextBox.Text = "0";
            }

            if (tempoTextBox.Text == "0")
            {
                tempoTextBox.ForeColor = Color.DimGray;
            }
        }

        private void tempoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void tempoTextBox_Enter(object sender, EventArgs e)
        {
            if (tempoTextBox.Text == "0")
            {
                tempoTextBox.Text = string.Empty;
                tempoTextBox.ForeColor = Color.Black;
            }
        }

        #endregion

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


    }
}
