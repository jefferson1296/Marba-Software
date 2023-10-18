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
    public partial class formTelaInicial : Form
    {
        formMarbaSoftware pai = new formMarbaSoftware();
        ComandosSQL comandos = new ComandosSQL();

        bool gestor;
        bool gerente;

        bool inicial_gestao;
        bool inicial;

        bool atividades;
        bool cronologico;
        bool horario;

        public bool ir_para_atividade;
        public bool pausar;
        public bool atividade_concluida;

        public formTelaInicial()
        {
            InitializeComponent();
        }

        public formTelaInicial(formMarbaSoftware Pai)
        {
            InitializeComponent();
            pai = Pai;
        }

        private void formTelaInicial_Load(object sender, EventArgs e)
        {
            labelHora.Text = DateTime.Now.ToLongTimeString();  //exibe a hora atual
            labelData.Text = DateTime.Now.ToLongDateString();
            labelData.Left = labelHora.Left - 15;
            timerHora.Enabled = true;

            gestor = Program.Acessos.Where(x => x.Descricao == "Tela Inicial da Gestão").Select(x => x.Permissao).FirstOrDefault();
            gerente = Program.Acessos.Where(x => x.Descricao == "Gerenciamento").Select(x => x.Permissao).FirstOrDefault();

            if (gestor)
            {
                inicial_gestao = true;
                buttonInicio.Visible = true;
            }
            else
            {
                inicial = true;
            }


            try
            {
                labelColaborador.Text = Program.colaborador.Nome_Colaborador + " " + Program.colaborador.Sobrenome;
                labelCargo.Text = Program.colaborador.Cargo;
                labelMatricula.Text = Program.colaborador.Matricula;
                pictureBoxColaborador.Image = comandos.ConverterArrayDeBytesParaImagem(Program.colaborador.Foto);
            }
            catch
            {
                labelColaborador.Text = "Criador";
            }

            DestacarBotoes();

            timerAfazeres.Start();
        }

        private void timerHora_Tick(object sender, EventArgs e)
        {
            labelHora.Text = DateTime.Now.ToLongTimeString();  //exibe a hora atual
            labelData.Text = DateTime.Now.ToLongDateString(); //exibe a data atual
        }

        private void DestacarBotoes()
        {
            if (gestor)
            {
                if (inicial_gestao)
                {
                    buttonGestao.Visible = false;
                    buttonGestao1.Visible = true;
                    formGestao x = new formGestao() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };

                    x.Size = panelCentral.Size;
                    panelCentral.Controls.Clear();
                    panelCentral.Controls.Add(x);
                    x.Show();
                }
                else
                {
                    buttonGestao.Visible = true;
                    buttonGestao1.Visible = false;
                }

                if (atividades)
                {
                    buttonAtividades.Visible = false;
                    buttonAtividades1.Visible = true;
                    formTelaInicialAtividadesEmAndamento x = new formTelaInicialAtividadesEmAndamento() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    x.Size = panelCentral.Size;
                    panelCentral.Controls.Clear();
                    panelCentral.Controls.Add(x);
                    x.Show();
                }
                else
                {
                    buttonAtividades.Visible = true;
                    buttonAtividades1.Visible = false;
                }

                if (cronologico)
                {
                    buttonCronologico.Visible = false;
                    buttonCronologico1.Visible = true;
                    formTelaInicialCronologico x = new formTelaInicialCronologico() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    panelCentral.Controls.Clear();
                    panelCentral.Controls.Add(x);
                    x.Show();
                }
                else
                {
                    buttonCronologico.Visible = true;
                    buttonCronologico1.Visible = false;
                }

                if (inicial)
                {
                    buttonInicio.BackColor = Color.White;
                    formTelaInicialPrincipal x = new formTelaInicialPrincipal() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    panelCentral.Controls.Clear();
                    panelCentral.Controls.Add(x);
                    x.Show();
                }
                else
                {
                    buttonInicio.BackColor = Color.Red;
                }
            }
            else
            {
                buttonGestao.Visible = false;
                buttonGestao1.Visible = false;

                if (inicial)
                {
                    buttonInicial.Visible = false;
                    buttonInicial1.Visible = true;
                    formTelaInicialPrincipal x = new formTelaInicialPrincipal() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    panelCentral.Controls.Clear();
                    panelCentral.Controls.Add(x);
                    x.Show();
                }
                else
                {
                    buttonInicial.Visible = true;
                    buttonInicial1.Visible = false;
                }

                if (gerente)
                {
                    if (atividades)
                    {
                        buttonAtividades.Visible = false;
                        buttonAtividades1.Visible = true;
                        formTelaInicialAtividadesEmAndamento x = new formTelaInicialAtividadesEmAndamento() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                        x.Size = panelCentral.Size;
                        panelCentral.Controls.Clear();
                        panelCentral.Controls.Add(x);
                        x.Show();
                    }
                    else
                    {
                        buttonAtividades.Visible = true;
                        buttonAtividades1.Visible = false;
                    }
                }
            }
        }

        private void buttonAtividades_Click(object sender, EventArgs e)
        {
            if (!atividades)
            {
                inicial = false;
                atividades = true;
                cronologico = false;
                inicial_gestao = false;
                horario = false;

                DestacarBotoes();
            }
        }

        private void buttonGestao_Click(object sender, EventArgs e)
        {
            if (!inicial_gestao)
            {
                inicial = false;
                atividades = false;
                cronologico = false;
                inicial_gestao = true;
                horario = false;

                DestacarBotoes();
            }
        }

        private void buttonInicial_Click(object sender, EventArgs e)
        {
            if (!inicial)
            {
                inicial = true;
                atividades = false;
                cronologico = false;
                inicial_gestao = false;
                horario = false;

                DestacarBotoes();
            }
        }

        private void buttonCronologico_Click(object sender, EventArgs e)
        {
            if (!cronologico)
            {
                inicial = false;
                atividades = false;
                cronologico = true;
                inicial_gestao = false;
                horario = false;

                DestacarBotoes();
            }
        }

        private void labelUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                string colaborador = Program.colaborador.Nome_Colaborador;
                string status = comandos.VerificarStatusDoExpediente(Program.colaborador.ID_Colaborador);
                if (status == "Folga")
                {
                    MessageBox.Show("Você está de folga!");
                }
                else if (!comandos.VerificarInicioDoServico(colaborador))
                {
                    MessageBox.Show("O início do seu expediente ainda não foi registrado.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!comandos.VerificarInicioDoLanche(colaborador) && comandos.VerificarHoraDoLanche(colaborador))
                {
                    Expediente expediente = comandos.HoraDoLanche(colaborador);
                    DateTime lanche_inicio = expediente.Previsao_Lanche_Inicio;
                    DateTime lanche_termino = expediente.Previsao_Lanche_Termino;
                    int tolerancia = Convert.ToInt32(comandos.ObterValorDoParametro("Margem de erro para o ponto eletrônico"));
                    string inicio = lanche_inicio.AddMinutes(-tolerancia).ToShortTimeString();
                    string termino = lanche_inicio.AddMinutes(tolerancia).ToShortTimeString();
                    string mensagem = "você poderá iniciar o intervalo do lanche das " + inicio + " até às " + termino + ".";
                    string horario = lanche_inicio.ToShortTimeString() + " ~ " + lanche_termino.ToShortTimeString();

                    formIntervalo lanche = new formIntervalo(this, "Lanche", mensagem, horario, colaborador);
                    lanche.ShowDialog();
                    if (ir_para_atividade)
                    {
                        ir_para_atividade = false;
                        if (comandos.VerificarAtividadeEmAndamento(colaborador))
                        {
                            formAtividadeEmAndamento andamento = new formAtividadeEmAndamento(this, colaborador);
                            andamento.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Não há atividades para serem executadas. Informe imediatamente ao chefe do seu setor.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
                else if (comandos.VerificarInicioDoLanche(colaborador) && !comandos.VerificarTerminoDoLanche(colaborador))
                {
                    Expediente expediente = comandos.HoraDoLanche(colaborador);
                    DateTime lanche_inicio = expediente.Previsao_Lanche_Inicio;
                    DateTime lanche_termino = expediente.Previsao_Lanche_Termino;
                    int tolerancia = Convert.ToInt32(comandos.ObterValorDoParametro("Margem de erro para o ponto eletrônico"));
                    string inicio = lanche_inicio.AddMinutes(-tolerancia).ToShortTimeString();
                    string termino = lanche_inicio.AddMinutes(tolerancia).ToShortTimeString();
                    string horario = lanche_inicio.ToShortTimeString() + " ~ " + lanche_termino.ToShortTimeString();

                    formFimDoIntervalo fim = new formFimDoIntervalo(this, "Lanche", horario, colaborador);
                    fim.ShowDialog();
                }
                else if (!comandos.VerificarInicioDoAlmoco(colaborador) && comandos.VerificarHoraDoAlmoco(colaborador))
                {
                    Expediente expediente = comandos.HoraDoAlmoco(colaborador);
                    DateTime almoco_inicio = expediente.Previsao_Almoco_Inicio;
                    DateTime almoco_termino = expediente.Previsao_Almoco_Termino;
                    int tolerancia = Convert.ToInt32(comandos.ObterValorDoParametro("Margem de erro para o ponto eletrônico"));
                    string inicio = almoco_inicio.AddMinutes(-tolerancia).ToShortTimeString();
                    string termino = almoco_inicio.AddMinutes(tolerancia).ToShortTimeString();
                    string mensagem = "você poderá iniciar o intervalo do almoço das " + inicio + " até às " + termino + ".";
                    string horario = almoco_inicio.ToShortTimeString() + " ~ " + almoco_termino.ToShortTimeString();

                    formIntervalo almoco = new formIntervalo(this, "Almoço", mensagem, horario, colaborador);
                    almoco.ShowDialog();
                    if (ir_para_atividade)
                    {
                        ir_para_atividade = false;
                        if (comandos.VerificarAtividadeEmAndamento(colaborador))
                        {
                            formAtividadeEmAndamento andamento = new formAtividadeEmAndamento(this, colaborador);
                            andamento.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Não há atividades para serem executadas. Informe imediatamente ao chefe do seu setor.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
                else if (comandos.VerificarInicioDoAlmoco(colaborador) && !comandos.VerificarTerminoDoAlmoco(colaborador))
                {
                    Expediente expediente = comandos.HoraDoAlmoco(colaborador);
                    DateTime almoco_inicio = expediente.Previsao_Almoco_Inicio;
                    DateTime almoco_termino = expediente.Previsao_Almoco_Termino;
                    int tolerancia = Convert.ToInt32(comandos.ObterValorDoParametro("Margem de erro para o ponto eletrônico"));
                    string inicio = almoco_inicio.AddMinutes(-tolerancia).ToShortTimeString();
                    string termino = almoco_inicio.AddMinutes(tolerancia).ToShortTimeString();
                    string horario = almoco_inicio.ToShortTimeString() + " ~ " + almoco_termino.ToShortTimeString();

                    formFimDoIntervalo fim = new formFimDoIntervalo(this, "Almoço", horario, colaborador);
                    fim.ShowDialog();
                }
                else if (comandos.VerificarFimDoServico(colaborador))
                {
                    MessageBox.Show("O fim do expediente já foi registrado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (comandos.VerificarAtividadeEmAndamento(colaborador))
                {
                    formAtividadeEmAndamento andamento = new formAtividadeEmAndamento(this, colaborador);
                    andamento.ShowDialog();
                    if (pausar)
                    {
                        pausar = false;
                        formPausar pause = new formPausar(colaborador);
                        pause.ShowDialog();
                    }

                    if (atividade_concluida)
                    {
                        atividade_concluida = false;
                        comandos.ConcluirAtividade(colaborador);
                    }
                }
                else if (!comandos.VerificarAtividadeEmAndamento(colaborador))
                {
                    comandos.ProximaAtividade(colaborador);
                }
            }
            catch { }
        }

        private void buttonInicio_Click(object sender, EventArgs e)
        {
            if (!inicial)
            {
                inicial = true;
                atividades = false;
                cronologico = false;
                inicial_gestao = false;
                horario = false;

                DestacarBotoes();
            }
        }

        private void timerAfazeres_Tick(object sender, EventArgs e)
        {
            timerAfazeres.Stop();

            if (comandos.VerificarAfazeresPendentes())
            {
                comandos.AtualizarDataDosAfazeresPendentes();
                formGestaoAfazeres afazeres = new formGestaoAfazeres();
                afazeres.ShowDialog();
            }
        }
    }
}
