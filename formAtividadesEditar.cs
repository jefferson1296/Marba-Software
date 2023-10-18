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
    public partial class formAtividadesEditar : Form
    {
        public Atividade Atividade = new Atividade();
        public List<Procedimento> Procedimentos = new List<Procedimento>();
        public List<Acao_Corretiva> Correcoes = new List<Acao_Corretiva>();
        public List<string> equipamentos = new List<string>();

        ComandosSQL comandos = new ComandosSQL();

        bool atividade;
        bool procedimentos;
        bool resultado;

        public string descricao;

        public formAtividadesEditar()
        {
            InitializeComponent();
        }

        public formAtividadesEditar(string Descricao)
        {
            InitializeComponent();
            descricao = Descricao;
        }

        private void formAtividadesEditar_Load(object sender, EventArgs e)
        {
            Atividade = comandos.TrazerInformacoesDaAtividade(descricao);
            AtualizarAcoesCorretivas();
            AtualizarProcedimentos();
            AtualizarEquipamentos();

            atividade = true;
            procedimentos = false;
            resultado = false;

            DestacarBotão();
        }

        public void AtualizarAcoesCorretivas()
        {
            Correcoes = comandos.ListaDeAcoesCorretivasDaAtividade(descricao);
        }

        public void AtualizarProcedimentos()
        {
            Procedimentos = comandos.TrazerProcedimentosDaAtividade(descricao);
        }

        public void AtualizarEquipamentos()
        {
            equipamentos = comandos.ListaDeEquipamentosDaAtividade(descricao);
        }

        private void DestacarBotão()
        {
            if (atividade)
            {
                int largura_botao = 206;

                Height = 310;
                Width = 631; //- 13
                buttonAtividade1.Width = largura_botao;
                buttonAtividade2.Width = largura_botao;
                buttonProcedimentos1.Width = largura_botao;
                buttonProcedimentos2.Width = largura_botao;
                buttonResultado1.Width = largura_botao;
                buttonResultado2.Width = largura_botao;

                buttonProcedimentos1.Left = 206;
                buttonProcedimentos2.Left = 206;
                buttonResultado1.Left = 412;
                buttonResultado2.Left = 412;

                formAtividadesCadastrarAtividade cadastrar_atividade = new formAtividadesCadastrarAtividade(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(cadastrar_atividade);
                cadastrar_atividade.Show();
                CenterToScreen();

                buttonAtividade2.Visible = true;
                buttonAtividade1.Visible = false;
            }
            else
            {
                buttonAtividade2.Visible = false;
                buttonAtividade1.Visible = true;
            }

            if (procedimentos)
            {
                Height = 515;
                Width = 772;

                int largura_botao = 253;

                buttonAtividade1.Width = largura_botao;
                buttonAtividade2.Width = largura_botao;
                buttonProcedimentos1.Width = largura_botao;
                buttonProcedimentos2.Width = largura_botao;
                buttonResultado1.Width = largura_botao;
                buttonResultado2.Width = largura_botao;

                buttonProcedimentos1.Left = 253;
                buttonProcedimentos2.Left = 253;
                buttonResultado1.Left = 506;
                buttonResultado2.Left = 506;

                formAtividadesCadastrarProcedimentos cadastrar_procedimentos = new formAtividadesCadastrarProcedimentos(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(cadastrar_procedimentos);
                cadastrar_procedimentos.Show();
                CenterToScreen();

                buttonProcedimentos2.Visible = true;
                buttonProcedimentos1.Visible = false;
            }
            else
            {
                buttonProcedimentos2.Visible = false;
                buttonProcedimentos1.Visible = true;
            }

            if (resultado)
            {
                Height = 515;
                Width = 772;

                int largura_botao = 253;

                buttonAtividade1.Width = largura_botao;
                buttonAtividade2.Width = largura_botao;
                buttonProcedimentos1.Width = largura_botao;
                buttonProcedimentos2.Width = largura_botao;
                buttonResultado1.Width = largura_botao;
                buttonResultado2.Width = largura_botao;

                buttonProcedimentos1.Left = 253;
                buttonProcedimentos2.Left = 253;
                buttonResultado1.Left = 506;
                buttonResultado2.Left = 506;

                formAtividadesCadastrarResultado resultado = new formAtividadesCadastrarResultado(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(resultado);
                resultado.Show();

                buttonResultado2.Visible = true;
                buttonResultado1.Visible = false;
            }
            else
            {
                buttonResultado2.Visible = false;
                buttonResultado1.Visible = true;
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

        private void buttonAtividade1_MouseEnter(object sender, EventArgs e)
        {
            if (!atividade)
            {
                buttonAtividade1.Visible = false;
                buttonAtividade2.Visible = true;
            }
        }

        private void buttonAtividade2_MouseLeave(object sender, EventArgs e)
        {
            if (!atividade)
            {
                buttonAtividade1.Visible = true;
                buttonAtividade2.Visible = false;
            }
        }

        private void buttonAtividade2_Click(object sender, EventArgs e)
        {
            if (!atividade)
            {
                atividade = true;
                procedimentos = false;
                resultado = false;
                DestacarBotão();
            }
        }

        private void buttonProcedimentos1_MouseEnter(object sender, EventArgs e)
        {
            if (!procedimentos)
            {
                buttonProcedimentos1.Visible = false;
                buttonProcedimentos2.Visible = true;
            }
        }

        private void buttonProcedimentos2_MouseLeave(object sender, EventArgs e)
        {
            if (!procedimentos)
            {
                buttonProcedimentos1.Visible = true;
                buttonProcedimentos2.Visible = false;
            }
        }

        private void buttonProcedimentos2_Click(object sender, EventArgs e)
        {
            if (!procedimentos)
            {
                atividade = false;
                procedimentos = true;
                resultado = false;
                DestacarBotão();
            }
        }

        private void buttonResultado1_MouseEnter(object sender, EventArgs e)
        {
            if (!resultado)
            {
                buttonResultado1.Visible = false;
                buttonResultado2.Visible = true;
            }
        }

        private void buttonResultado2_MouseLeave(object sender, EventArgs e)
        {
            if (!resultado)
            {
                buttonResultado1.Visible = true;
                buttonResultado2.Visible = false;
            }
        }

        private void buttonResultado2_Click(object sender, EventArgs e)
        {
            if (!resultado)
            {
                atividade = false;
                procedimentos = false;
                resultado = true;
                DestacarBotão();
            }
        }

        private void fecharPictureBox_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {

            if (Atividade.Descricao == string.Empty)
            {
                MessageBox.Show("Informe a descrição da Atividade para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comandos.VerificarNomeDaAtividade(Atividade.Descricao) && Atividade.Descricao != descricao)
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
                comandos.EditarAtividade(Atividade);
                Dispose();
            }
        }

        private void buttonEquipamentos_Click(object sender, EventArgs e)
        {
            formTelaInicialProcedimentosFerramentas Ferramentas = new formTelaInicialProcedimentosFerramentas(this, descricao);
            Ferramentas.ShowDialog();
        }
    }
}
