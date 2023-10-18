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
using Microsoft.Reporting.WinForms;
using clModelo.funcoes;
using System.Speech.Synthesis;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace MarbaSoftware
{
    public partial class formMarbaSoftware : Form
    {
        #region Inicialização
        ComandosSQL comandos = new ComandosSQL();

        bool destravar;

        bool utensilios;
        bool produtos;
        bool vendas;
        bool fornecedores;
        bool promocoes;
        bool financeiro;
        bool inicial;

        bool acesso_utensilios;
        bool acesso_produtos;
        bool acesso_vendas;
        bool acesso_fornecedores;
        bool acesso_promocoes;
        bool acesso_financeiro;
        bool acesso_inicial;

        int ordem = 1;
        int ID_Notificacao;
        List<Notificacao> notificacoes = new List<Notificacao>();

        int intervalo_reposicoes;
        DateTime reexibir_notificacao;

        public formMarbaSoftware()
        {
            InitializeComponent();
            shadowControls.Add(panelNotificacao);
        }
        private void formTelaGestor_Load(object sender, EventArgs e)
        {
            intervalo_reposicoes = (int)comandos.ObterValorDoParametro("Tempo para reexibir notificação");

            notificacoes = comandos.TrazerNotificacoesSemVisto();
            timerNotificacao.Enabled = true;

            TopMost = false;
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            panelSuperior.Visible = false;

            VerificarRestricoesDeAcesso();
            panelLateral.Width = 65;
            panelLinhaBranca.Left = panelLinhaBranca.Left - 135;
            panelLinhaBranca.Height = Height;
            formTelaInicial telaInicial = new formTelaInicial(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            panelCentral.Controls.Clear();
            panelCentral.Controls.Add(telaInicial);
            telaInicial.Show();
            DefinirFeriados();


            //comandos.ImprimirFolhaDePonto(12, 2021, 3);
        }

        #endregion
        #region Interface 
        private void buttonFechar2_Click(object sender, EventArgs e) //Botão de Fechar
        {
            Application.Exit();
            //this.Dispose();
        }
        private void buttonMinimizar_Click(object sender, EventArgs e) //Botão de Minimizar
        {
            this.WindowState = FormWindowState.Minimized;
        }        
        private void panelLinhaBranca_MouseMove(object sender, MouseEventArgs e) //Retração da Barra Lateral
        {
            try
            {
                if (panelLateral.Width == 65 && destravar)
                {
                    panelLateral.Width = 200;
                    panelLinhaBranca.Left = panelLinhaBranca.Left + 135;
                }
                else if (panelLateral.Width == 200 && destravar)
                {
                    panelLateral.Width = 65;
                    panelLinhaBranca.Left = panelLinhaBranca.Left - 135;
                }
            }
            catch
            {
            }
        }
        private void pictureMarba_Click(object sender, EventArgs e) //Botão Modo Windows
        {
            if (FormBorderStyle == FormBorderStyle.FixedSingle)
            {

                this.WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;

                TopMost = true;
                panelSuperior.Visible = true;

            }
            else if (FormBorderStyle == FormBorderStyle.None)
            {
                TopMost = false;
                this.WindowState = FormWindowState.Maximized;
                FormBorderStyle = FormBorderStyle.FixedSingle;
                panelSuperior.Visible = false;
            }
        }
        #endregion

        private void VerificarRestricoesDeAcesso()
        {
            Program.Acessos = comandos.ListaDeAcessos();
            List<int> Permissoes = comandos.ListaDeAcessosDoColaboradorPelaMatricula();

            foreach (Acesso Acesso in Program.Acessos)
            {
                int id = Acesso.ID_Acesso;
                bool permissao = Permissoes.Contains(id);
                Acesso.Permissao = permissao;
            }

            acesso_inicial = Program.Acessos.Where(x => x.Descricao == "Botão de Tela Inicial").Select(x => x.Permissao).FirstOrDefault();
            acesso_utensilios = Program.Acessos.Where(x => x.Descricao == "Botão de Utensílios").Select(x => x.Permissao).FirstOrDefault(); 
            acesso_produtos = Program.Acessos.Where(x => x.Descricao == "Botão de Produtos").Select(x => x.Permissao).FirstOrDefault();
            acesso_vendas = Program.Acessos.Where(x => x.Descricao == "Botão de Vendas").Select(x => x.Permissao).FirstOrDefault();
            acesso_fornecedores = Program.Acessos.Where(x => x.Descricao == "Botão de Fornecedores").Select(x => x.Permissao).FirstOrDefault();
            acesso_promocoes = Program.Acessos.Where(x => x.Descricao == "Botão de Promoções").Select(x => x.Permissao).FirstOrDefault();
            acesso_financeiro = Program.Acessos.Where(x => x.Descricao == "Botão de Finanças").Select(x => x.Permissao).FirstOrDefault();

            PosicoesDosBotoes();
            DestacarBotao();
        }
        private void PosicoesDosBotoes()
        {
            int posicao_inicial = 140;

            if (acesso_utensilios) { buttonUtensilios.Top = posicao_inicial;  buttonUtensilios1.Top = posicao_inicial; posicao_inicial = posicao_inicial + 37; }
            if (acesso_produtos) { buttonProdutos.Top = posicao_inicial; buttonProdutos1.Top = posicao_inicial; posicao_inicial = posicao_inicial + 37; }
            if (acesso_vendas) { buttonVendas.Top = posicao_inicial; buttonVendas1.Top = posicao_inicial; posicao_inicial = posicao_inicial + 37; }
            if (acesso_fornecedores) { buttonFornecedor.Top = posicao_inicial; buttonFornecedores1.Top = posicao_inicial; posicao_inicial = posicao_inicial + 37; }
            if (acesso_promocoes) { buttonPromocoes.Top = posicao_inicial; buttonPromocoes1.Top = posicao_inicial; posicao_inicial = posicao_inicial + 37; }
            if (acesso_financeiro) { buttonFinanceiro.Top = posicao_inicial; buttonFinanceiro1.Top = posicao_inicial; }
        }
        private void pictureBoxConsultaRápida_Click(object sender, EventArgs e) //Botão de Consulta Rápida
        {
            formConsultaRapida consultaRapida = new formConsultaRapida();
            consultaRapida.ShowDialog();
        }
        private void pictureBoxTravar_Click(object sender, EventArgs e)
        {
            if (destravar)
            {
                destravar = false;
                if (panelLateral.Width == 200)
                {
                    panelLateral.Width = 65;
                    panelLinhaBranca.Left = panelLinhaBranca.Left - 135;
                }
            }
            else
            {
                destravar = true;
                if (panelLateral.Width == 65)
                {
                    panelLateral.Width = 200;
                    panelLinhaBranca.Left = panelLinhaBranca.Left + 135;
                }
            }
        }

        #region Botões
        private void DestacarBotao()
        {
            if (acesso_financeiro)
            {
                if (financeiro)
                {
                    buttonFinanceiro.Visible = false;
                    buttonFinanceiro1.Visible = true;
                    formFinanceiro fin = new formFinanceiro() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    panelCentral.Controls.Clear();
                    panelCentral.Controls.Add(fin);
                    fin.Show();
                }
                else
                {
                    buttonFinanceiro.Visible = true;
                    buttonFinanceiro1.Visible = false;
                }
            }
            else
            {
                buttonFinanceiro.Visible = false;
                buttonFinanceiro1.Visible = false;
            }

            if (acesso_utensilios)
            {
                if (utensilios)
                {
                    buttonUtensilios.Visible = false;
                    buttonUtensilios1.Visible = true;
                    formCatalogo utens = new formCatalogo() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    this.panelCentral.Controls.Clear();
                    this.panelCentral.Controls.Add(utens);
                    utens.Show();
                }
                else
                {
                    buttonUtensilios.Visible = true;
                    buttonUtensilios1.Visible = false;
                }
            }
            else
            {
                buttonUtensilios.Visible = false;
                buttonUtensilios1.Visible = false;
            }

            if (acesso_produtos)
            {
                if (produtos == true)
                {
                    buttonProdutos.Visible = false;
                    buttonProdutos1.Visible = true;
                    formProdutos produtos = new formProdutos() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    this.panelCentral.Controls.Clear();
                    this.panelCentral.Controls.Add(produtos);
                    produtos.Show();
                }
                else
                {
                    buttonProdutos.Visible = true;
                    buttonProdutos1.Visible = false;
                }
            }
            else
            {
                buttonProdutos.Visible = false;
                buttonProdutos1.Visible = false;
            }

            if (acesso_vendas)
            {
                if (vendas == true)
                {
                    buttonVendas.Visible = false;
                    buttonVendas1.Visible = true;
                    formVendas x = new formVendas() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    this.panelCentral.Controls.Clear();
                    this.panelCentral.Controls.Add(x);
                    x.Show();
                }
                else
                {
                    buttonVendas.Visible = true;
                    buttonVendas1.Visible = false;
                }
            }
            else
            {
                buttonVendas.Visible = false;
                buttonVendas1.Visible = false;
            }

            if (acesso_fornecedores)
            {
                if (fornecedores == true)
                {
                    buttonFornecedor.Visible = false;
                    buttonFornecedores1.Visible = true;
                    formFornecedores x = new formFornecedores() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    this.panelCentral.Controls.Clear();
                    this.panelCentral.Controls.Add(x);
                    x.Show();
                }
                else
                {
                    buttonFornecedor.Visible = true;
                    buttonFornecedores1.Visible = false;
                }
            }
            else
            {
                buttonFornecedor.Visible = false;
                buttonFornecedores1.Visible = false;
            }

            if (acesso_promocoes)
            {
                if (promocoes == true)
                {
                    buttonPromocoes.Visible = false;
                    buttonPromocoes1.Visible = true;
                    formPromocoes x = new formPromocoes() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    this.panelCentral.Controls.Clear();
                    this.panelCentral.Controls.Add(x);
                    x.Show();
                }
                else
                {
                    buttonPromocoes.Visible = true;
                    buttonPromocoes1.Visible = false;
                }
            }
            else
            {
                buttonPromocoes.Visible = false;
                buttonPromocoes1.Visible = false;
            }

            if (acesso_inicial)
            {
                if (inicial == true)
                {
                    formTelaInicial x = new formTelaInicial() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    panelCentral.Controls.Clear();
                    panelCentral.Controls.Add(x);
                    x.Show();
                }
            }
            else
            {
                pictureCasinha.Visible = false;
            }

        }
        private void pictureCasinha_Click(object sender, EventArgs e) //Tela Inicial
        {
            if (!inicial)
            {
                financeiro = false;
                utensilios = false;
                produtos = false;
                vendas = false;
                fornecedores = false;
                promocoes = false;
                inicial = true;
                DestacarBotao();

                ordem = 1;
                timerNotificacao.Start();
            }
        }
        private void buttonUtensilios_Click(object sender, EventArgs e)
        {
            if (!utensilios)
            {
                financeiro = false;
                utensilios = true;
                produtos = false;
                vendas = false;
                fornecedores = false;
                promocoes = false;
                inicial = false;
                DestacarBotao();
            }
        }
        private void buttonProdutos_Click(object sender, EventArgs e)
        {
            if (!produtos)
            {
                financeiro = false;
                utensilios = false;
                produtos = true;
                vendas = false;
                fornecedores = false;
                promocoes = false;
                inicial = false;
                DestacarBotao();
            }
        }
        private void buttonVendas_Click(object sender, EventArgs e)
        {
            if (!vendas)
            {
                financeiro = false;
                utensilios = false;
                produtos = false;
                vendas = true;
                fornecedores = false;
                promocoes = false;
                inicial = false;
                DestacarBotao();
            }
        }
        private void buttonFornecedor_Click(object sender, EventArgs e)
        {
            if (!fornecedores)
            {
                financeiro = false;
                utensilios = false;
                produtos = false;
                vendas = false;
                fornecedores = true;
                promocoes = false;
                inicial = false;
                DestacarBotao();
            }
        }
        private void buttonPromocoes_Click(object sender, EventArgs e)
        {
            if (!promocoes)
            {
                financeiro = false;
                utensilios = false;
                produtos = false;
                vendas = false;
                fornecedores = false;
                promocoes = true;
                inicial = false;
                DestacarBotao();
            }
        }
        private void buttonFinanceiro_Click(object sender, EventArgs e)
        {
            if (!financeiro)
            {
                financeiro = true;
                utensilios = false;
                produtos = false;
                vendas = false;
                fornecedores = false;
                promocoes = false;
                inicial = false;
                DestacarBotao();
            }
        }
        #endregion

        private void DefinirFeriados()
        {
            int ano = DateTime.Now.Year;

            if (!comandos.VerificarSeFeriadosDoAnoJaForamDefinidos(ano))
            {
                formColaboradoresDefinirFeriados feriados = new formColaboradoresDefinirFeriados(ano);
                feriados.ShowDialog();
            }

            if (DateTime.Now.Month == 12)
            {
                ano = DateTime.Now.AddYears(1).Year;
                if (!comandos.VerificarSeFeriadosDoAnoJaForamDefinidos(ano))
                {
                    formColaboradoresDefinirFeriados feriados = new formColaboradoresDefinirFeriados(ano);
                    feriados.ShowDialog();
                }
            }
        }

        private void formTelaGestor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                formConsultaRapida consultaRapida = new formConsultaRapida();
                consultaRapida.ShowDialog();
            }
        }

        private void formTelaGestor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            Application.Exit();
        }

        #region Notificações
        private void MostrarNotificacao()
        {
            if (notificacoes.Count >= ordem)
            {                
                Notificacao notificacao = notificacoes.Where(x => x.Ordem == ordem).FirstOrDefault();
                labelTipo.Text = notificacao.Tipo.ToUpper();
                labelDescricao.Text = notificacao.Descricao;
                ID_Notificacao = notificacao.ID_Notificacao;
                textBoxNotificacao.Text = notificacao.Detalhes;
                labelDescricao.Left = (panelNotificacao.Width - labelDescricao.Width) / 2;
                labelData.Text = notificacao.Hora.ToShortDateString() + " " + notificacao.Hora.ToLongTimeString();
                labelData.Left = (panelNotificacao.Width - labelData.Width) / 2;
                labelTipo.Left = (panelNotificacao.Width - labelTipo.Width) / 2;
                panelNotificacao.Visible = true;
                informacoes_sombra[0] = 50; informacoes_sombra[1] = 30;
                Refresh();
                comandos.Beep();
                ordem++;
            }
            else
            {
                ordem = 1;
                reexibir_notificacao = DateTime.Now.AddMinutes(intervalo_reposicoes);
                timerReexibir.Start();
                labelNotificacoes.Text = notificacoes.Count.ToString();
                //pictureBoxNotificacoes.Visible = true;
                //labelNotificacoes.Visible = true;


                //Ativou o timer ao abrir o form.
                //Ativa o método e se houver notificação, exibe.
                //Fecha notificação
                //Ativa o timer, se ainda houver notificação, exibe
                //Reinicia a ordem das notificações e liga outro timer, que vai chamar o timer Notificação novamente.
            }
        }

        private void pbFecharNotificacao_Click(object sender, EventArgs e)
        {
            panelNotificacao.Visible = false;
            informacoes_sombra[0] = 0; informacoes_sombra[1] = 0;
            Refresh();
            timerNotificacao.Start();
        }

        private void timerNotificacao_Tick(object sender, EventArgs e)
        {
            MostrarNotificacao();
            timerNotificacao.Stop();
        }

        private void vistoLabel_Click(object sender, EventArgs e)
        {
            notificacoes.RemoveAll(x => x.ID_Notificacao == ID_Notificacao);
            comandos.MarcarNotificacaoComoVisto(ID_Notificacao);
            panelNotificacao.Visible = false;
            informacoes_sombra[0] = 0; informacoes_sombra[1] = 0;
            Refresh();
            timerNotificacao.Start();
        }

        private void timerReexibir_Tick(object sender, EventArgs e)
        {
            if (reexibir_notificacao <= DateTime.Now)
            {
                timerNotificacao.Start();
                timerReexibir.Stop();
            }
        }

        #region Sombra do Painel Notificações

        List<Control> shadowControls = new List<Control>();
        Bitmap shadowBmp = null;
        int[] informacoes_sombra = new int[2];

        private void formMarbaSoftware_Paint(object sender, PaintEventArgs e)
        {
            int intensidade;
            int tamanho_sombra;
            try { intensidade = informacoes_sombra[0]; } catch { intensidade = 0; }
            try { tamanho_sombra = informacoes_sombra[1]; } catch { tamanho_sombra = 0; }

            if (shadowBmp == null || shadowBmp.Size != this.Size)
            {
                shadowBmp?.Dispose();
                shadowBmp = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppArgb);
            }
            foreach (Control control in shadowControls)
            {
                using (GraphicsPath gp = new GraphicsPath())
                {
                    gp.AddRectangle(new Rectangle(control.Location.X, control.Location.Y, control.Size.Width, control.Size.Height));
                    DrawShadowSmooth(gp, intensidade, tamanho_sombra, shadowBmp);
                }
                e.Graphics.DrawImage(shadowBmp, new Point(0, 0));
            }
        }

        private static void DrawShadowSmooth(GraphicsPath gp, int intensity, int radius, Bitmap dest)
        {
            using (Graphics g = Graphics.FromImage(dest))
            {
                g.Clear(Color.Transparent);
                g.CompositingMode = CompositingMode.SourceCopy;
                double alpha = 0;
                double astep = 0;
                double astepstep = (double)intensity / radius / (radius / 2D);
                for (int thickness = radius; thickness > 0; thickness--)
                {
                    using (Pen p = new Pen(Color.FromArgb((int)alpha, 0, 0, 0), thickness))
                    {
                        p.LineJoin = LineJoin.Round;
                        g.DrawPath(p, gp);
                    }
                    alpha += astep;
                    astep += astepstep;
                }
            }
        }


        #endregion

        #endregion

        private void pictureBoxAtualizar_Click(object sender, EventArgs e)
        {
            VerificarRestricoesDeAcesso();
        }
    }
}
