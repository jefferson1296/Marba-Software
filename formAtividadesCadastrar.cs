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
    public partial class formAtividadesCadastrar : Form
    {
        public Atividade Atividade = new Atividade();
        public List<Procedimento> Procedimentos = new List<Procedimento>();
        public List<string> Correcoes = new List<string>();
        public List<string> equipamentos = new List<string>();

        ComandosSQL comandos = new ComandosSQL();

        bool atividade;
        bool procedimentos;
        bool resultado;

        public formAtividadesCadastrar()
        {
            InitializeComponent();
        }

        private void formAtividadesCadastrar_Load(object sender, EventArgs e)
        {
            Atividade.Descricao = string.Empty;
            Atividade.Categoria = string.Empty;
            Atividade.Setor = string.Empty;
            Atividade.Cargo = string.Empty;
            Atividade.Resultado = string.Empty;

            atividade = true;
            procedimentos = false;
            resultado = false;

            AlterarTela();
        }

        private void AvancarButton_Click(object sender, EventArgs e)
        {
            if (atividade)
            {
                if (Atividade.Descricao == string.Empty)
                {
                    MessageBox.Show("Informe a descrição da Atividade para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (comandos.VerificarNomeDaAtividade(Atividade.Descricao))
                {
                    MessageBox.Show("Já existe uma atividade cadastrada com esse nome!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Atividade.Categoria == string.Empty)
                {
                    MessageBox.Show("Informe a categoria para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Atividade.Setor == string.Empty)
                {
                    MessageBox.Show("Informe o setor para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Atividade.Cargo == string.Empty)
                {
                    MessageBox.Show("Informe o cargo para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Atividade.Rotina && Atividade.Intervalo == 0)
                {
                    MessageBox.Show("Informe o intervalo padrão para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    atividade = false;
                    procedimentos = true;
                    resultado = false;
                    AlterarTela();
                }
            }
            else if (procedimentos)
            {

                atividade = false;
                procedimentos = false;
                resultado = true;
                AlterarTela();

            }
            else if (resultado)
            {
                formTelaInicialProcedimentosFerramentas Ferramentas = new formTelaInicialProcedimentosFerramentas(this);
                Ferramentas.ShowDialog();
                comandos.CadastrarAtividade(Atividade, Procedimentos, Correcoes, equipamentos);
                Dispose();
            }
        }

        private void AlterarTela()
        {
            if (atividade)
            {
                Height = 260;
                formAtividadesCadastrarAtividade cadastrar_atividade = new formAtividadesCadastrarAtividade(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(cadastrar_atividade);
                cadastrar_atividade.Show();
                CenterToScreen();
            }

            if (procedimentos)
            {
                Height = 463;
                Width = Width + 141;
                formAtividadesCadastrarProcedimentos cadastrar_procedimentos = new formAtividadesCadastrarProcedimentos(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(cadastrar_procedimentos);
                cadastrar_procedimentos.Show();
                CenterToScreen();
            }

            if (resultado)
            {
                formAtividadesCadastrarResultado resultado = new formAtividadesCadastrarResultado(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(resultado);
                resultado.Show();
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

        private void fecharPictureBox_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonContinuar_Click(object sender, EventArgs e)
        {

        }
    }
}
