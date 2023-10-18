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
    public partial class formGestaoConfiguracoes : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public List<Parametro> Parametros = new List<Parametro>();
        public CPU Computador = new CPU();

        bool tela_parametros;
        bool tela_computador;
        bool tela_personalizacao;

        public formGestaoConfiguracoes()
        {
            InitializeComponent();
        }
        public formGestaoConfiguracoes(string Configurar)
        {
            InitializeComponent();
            if (Configurar == "Parâmetros")
            {
                tela_parametros = true;
                tela_computador = false;
                tela_personalizacao = false;
            }
            else if (Configurar == "Computador")
            {
                tela_parametros = false;
                tela_computador = true;
                tela_personalizacao = false;
            }
            else
            {
                tela_parametros = false;
                tela_computador = false;
                tela_personalizacao = true;
            }
        }

        private void formGestaoConfiguracoes_Load(object sender, EventArgs e)
        {
            AtualizarInformacoes();
            DestacarBotão();
        }

        public void AtualizarInformacoes()
        {
            Computador.ID_Reparticao = Program.Computador.ID_Reparticao;
            Parametros = comandos.TrazerListaDeParametros();
            Computador = comandos.InformacoesDoComputador(Program.Computador.ID, Program.Computador.Usuario);
            Computador.Impressora_A4 = Program.Computador.Impressora_A4;
            Computador.Impressora_Termica = Program.Computador.Impressora_Termica;
        }

        private void DestacarBotão()
        {
            if (tela_parametros)
            {
                formGestaoConfiguracoesParametros parametros = new formGestaoConfiguracoesParametros(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(parametros);
                parametros.Show();
                buttonParametros2.Visible = true;
                buttonParametros1.Visible = false;
            }
            else
            {
                buttonParametros2.Visible = false;
                buttonParametros1.Visible = true;
            }

            if (tela_computador)
            {
                formGestaoConfiguracoesDefinicoes definicoes = new formGestaoConfiguracoesDefinicoes(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(definicoes);
                definicoes.Show();

                buttonDefinicoes2.Visible = true;
                buttonDefinicoes1.Visible = false;
            }
            else
            {
                buttonDefinicoes2.Visible = false;
                buttonDefinicoes1.Visible = true;
            }

            if (tela_personalizacao)
            {
                formGestaoConfiguracoesPersonalizar personalizacoes = new formGestaoConfiguracoesPersonalizar(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(personalizacoes);
                personalizacoes.Show();

                buttonPersonalizacao2.Visible = true;
                buttonPersonalizacao1.Visible = false;
            }
            else
            {
                buttonPersonalizacao2.Visible = false;
                buttonPersonalizacao1.Visible = true;
            }
        }

        private void buttonParametros1_MouseEnter(object sender, EventArgs e)
        {
            if (!tela_parametros)
            {
                buttonParametros1.Visible = false;
                buttonParametros2.Visible = true;
            }
        }
        private void buttonParametros2_Click(object sender, EventArgs e)
        {
            if (!tela_parametros)
            {
                tela_personalizacao = false;
                tela_parametros = true;
                tela_computador = false;
                DestacarBotão();
            }
        }
        private void buttonParametros2_MouseLeave(object sender, EventArgs e)
        {
            if (!tela_parametros)
            {
                buttonParametros1.Visible = true;
                buttonParametros2.Visible = false;
            }
        }

        private void buttonDefinicoes1_MouseEnter(object sender, EventArgs e)
        {
            if (!tela_computador)
            {
                buttonDefinicoes1.Visible = false;
                buttonDefinicoes2.Visible = true;
            }
        }
        private void buttonDefinicoes2_Click(object sender, EventArgs e)
        {
            if (!tela_computador)
            {
                tela_personalizacao = false;
                tela_parametros = false;
                tela_computador = true;
                DestacarBotão();
            }
        }
        private void buttonDefinicoes2_MouseLeave(object sender, EventArgs e)
        {
            if (!tela_computador)
            {
                buttonDefinicoes1.Visible = true;
                buttonDefinicoes2.Visible = false;
            }
        }

        private void buttonPersonalizacao1_MouseEnter(object sender, EventArgs e)
        {
            if (!tela_personalizacao)
            {
                buttonPersonalizacao1.Visible = false;
                buttonPersonalizacao2.Visible = true;
            }
        }
        private void buttonPersonalizacao2_Click(object sender, EventArgs e)
        {
            if (!tela_personalizacao)
            {
                tela_personalizacao = true;
                tela_parametros = false;
                tela_computador = false;
                DestacarBotão();
            }
        }
        private void buttonPersonalizacao2_MouseLeave(object sender, EventArgs e)
        {
            if (!tela_personalizacao)
            {
                buttonPersonalizacao1.Visible = true;
                buttonPersonalizacao2.Visible = false;
            }
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            int parametros_editados = Parametros.Where(x => x.Edicao).Count();
            bool atualizacao = false;

            if (parametros_editados > 0)
            {
                comandos.EditarParametros(Parametros);
                atualizacao = true;
            }

            if (Computador.Edicao)
            {
                comandos.EditarDefinicoesDoComputador(Computador);
                Program.Computador.Impressora_A4 = Computador.Impressora_A4;
                Program.Computador.Impressora_Termica = Computador.Impressora_Termica;
                Program.Computador.Porta_Serial = Computador.Porta_Serial;
                atualizacao = true;
            }

            if (atualizacao)
            {
                MessageBox.Show("Informações atualizadas com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            formGestaoConfiguracoesParametrosEditar cadastrar = new formGestaoConfiguracoesParametrosEditar(this);
            cadastrar.ShowDialog();
            AtualizarInformacoes();
            DestacarBotão();
        }

        private void buttonAbreviacoes_Click(object sender, EventArgs e)
        {
            formGestaoConfiguracaoesAbreviacoes abreviacoes = new formGestaoConfiguracaoesAbreviacoes();
            abreviacoes.ShowDialog();
        }
    }
}
