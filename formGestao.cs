using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarbaSoftware
{
    public partial class formGestao : Form
    {
        #region Inicialização

        List<Projeto> projetos = new List<Projeto>();
        bool projetos_concluidos;

        List<Etapa> etapas = new List<Etapa>();

        List<Notificacao> eventos = new List<Notificacao>();

        ComandosSQL comandos = new ComandosSQL();
        DateTime data = new DateTime();

        CultureInfo cultura = new CultureInfo("pt-BR");
        DateTimeFormatInfo formato = new DateTimeFormatInfo(); 

        public bool alteracao;
        int ordem = 1;

        int id_projeto;


        public formGestao()
        {
            InitializeComponent();

        }

        private void formTelaInicialPrincipalGestao_Load(object sender, EventArgs e)
        {
            formato = cultura.DateTimeFormat;
            dateTimePickerMeta.Value = DateTime.Now;

            AtualizarDataGridProjetos();

            if (projetos.Count > 0)
            {
                id_projeto = projetos.Min(x => x.ID_Projeto);
                AtualizarDataGridEtapas();
            }

            AtualizarDataGridEventos();

            dataGridViewProjetos.AutoGenerateContextFilters = false;
            dataGridViewProjetos.LoadFilter("(Convert([Status], System.String) IN ('0'))", null);

            dataGridViewEtapas.AutoGenerateColumns = false;

            AtualizarProgressBarMetas();
            timerMetas.Start();
        }

        #endregion

        #region Projetos

        private void AtualizarDataGridProjetos()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewProjetos.CurrentRow != null)
            {
                primeira_linha = dataGridViewProjetos.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewProjetos.CurrentRow.Index;
            }

            projetos = comandos.ListaDeProjetos();
            comandos.PreencherDataGridProjetos(bindingProjetos, dataGridViewProjetos);

            try
            {
                dataGridViewProjetos.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewProjetos.CurrentCell = dataGridViewProjetos.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }

        private void buttonNovoProjeto_Click(object sender, EventArgs e)
        {
            formGestaoCadastrarProjeto projeto = new formGestaoCadastrarProjeto();
            projeto.ShowDialog();
            AtualizarDataGridProjetos();
        }

        private void dataGridViewProjetos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_projeto = Convert.ToInt32(dataGridViewProjetos.Rows[e.RowIndex].Cells[0].Value);
                AtualizarDataGridEtapas();
            }
            catch { }
        }

        private void dataGridViewProjetos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        dataGridViewProjetos.CurrentCell = dataGridViewProjetos.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dataGridViewProjetos.Rows[e.RowIndex].Selected = true;
                        dataGridViewProjetos.Focus();
                        id_projeto = Convert.ToInt32(dataGridViewProjetos.Rows[e.RowIndex].Cells[0].Value);
                        AtualizarDataGridEtapas();
                    }
                    else { }
                }
                catch { }
            }
        }

        private void ordenarEtapasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_projeto != 0)
            {
                formGestaoOrdenarEtapas Ordenar = new formGestaoOrdenarEtapas(id_projeto, true);
                Ordenar.ShowDialog();
                AtualizarDataGridEtapas();
            }
        }

        private void apagarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (id_projeto != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("O projeto e suas etapas serão excluídos.\r\nTem certeza que deseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarProjeto(id_projeto);
                    comandos.ApagarEtapasDoProjeto(id_projeto);
                }
            }
        }

        private void dataGridViewProjetos_FilterStringChanged(object sender, EventArgs e)
        {
            bindingProjetos.Filter = dataGridViewProjetos.FilterString;            
        }

        private void dataGridViewProjetos_SortStringChanged(object sender, EventArgs e)
        {
            bindingProjetos.Sort = dataGridViewProjetos.SortString;
        }

        private void dataGridViewProjetos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!projetos_concluidos)
            {
                projetos_concluidos = true;
                dataGridViewProjetos.LoadFilter("(Convert([Status], System.String) IN ('0', '1'))", null);
                AtualizarDataGridProjetos();
            }
            else
            {
                projetos_concluidos = false;
                dataGridViewProjetos.LoadFilter("(Convert([Status], System.String) IN ('0'))", null);
            }

            id_projeto = Convert.ToInt32(dataGridViewProjetos.Rows[dataGridViewProjetos.CurrentRow.Index].Cells[0].Value);
            AtualizarDataGridEtapas();
        }

        #endregion

        #region Etapas

        private void AtualizarDataGridEtapas()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewEtapas.CurrentRow != null)
            {
                primeira_linha = dataGridViewEtapas.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewEtapas.CurrentRow.Index;
            }

            dataGridViewEtapas.Rows.Clear();
            etapas = comandos.ListaDeEtapas(id_projeto);
            foreach (Etapa Etapa in etapas)
            {
                int ordem = Etapa.Ordem;
                string etapa = Etapa.Descricao;
                string status = Etapa.Status;

                string tempo;
                if (status == "Pendente")
                {
                    tempo = "- - -";
                }
                else if (status == "Em andamento")
                {
                    DateTime inicio = Etapa.Inicio;

                    if (DateTime.Now.Subtract(inicio).TotalHours > 24)
                    {
                        int dias = Convert.ToInt32(DateTime.Now.Subtract(inicio).TotalHours) / 24;
                        int horas = Convert.ToInt32(DateTime.Now.Subtract(inicio).TotalHours) % 24;
                        tempo = dias.ToString() + "d " + horas.ToString() + "h";
                    }
                    else
                    {
                        DateTime Tempo = Convert.ToDateTime(DateTime.Now.Subtract(inicio).ToString());
                        tempo = Tempo.ToLongTimeString();
                    }
                }
                else
                {
                    DateTime inicio = Etapa.Inicio;
                    DateTime termino = Etapa.Termino;

                    if (termino.Subtract(inicio).TotalHours > 24)
                    {
                        int dias = Convert.ToInt32(termino.Subtract(inicio).TotalHours) / 24;
                        int horas = Convert.ToInt32(termino.Subtract(inicio).TotalHours) % 24;
                        tempo = dias.ToString() + "d " + horas.ToString() + "h";
                    }
                    else
                    {
                        DateTime Tempo = Convert.ToDateTime(termino.Subtract(inicio).ToString());
                        tempo = Tempo.ToLongTimeString();
                    }
                }

                dataGridViewEtapas.Rows.Add(ordem, etapa, status , tempo);
                if (etapas.Any(x => x.Status == "Em andamento")) { timerTempo.Enabled = true; }
                else { timerTempo.Enabled = false; }
            }

            try
            {
                dataGridViewEtapas.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewEtapas.CurrentCell = dataGridViewProjetos.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewEtapas.CurrentRow != null)
                dataGridViewEtapas.CurrentRow.Selected = false;
        }

        private void buttonEtapa_Click(object sender, EventArgs e)
        {
            formGestaoAdicionarEtapa etapa = new formGestaoAdicionarEtapa(this);
            etapa.ShowDialog();
            if (alteracao)
            {
                alteracao = false;
                //AtualizarDataGridEtapas();
            }
        }

        private void buttonOrdenarEtapas_Click(object sender, EventArgs e)
        {
            formGestaoOrdenarEtapas Ordenar = new formGestaoOrdenarEtapas();
            Ordenar.ShowDialog();
        }

        private void dataGridViewEtapas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int ordem = Convert.ToInt32(dataGridViewEtapas.Rows[e.RowIndex].Cells[0].Value);
                formGestaoEtapa Etapa = new formGestaoEtapa(ordem, id_projeto);
                Etapa.ShowDialog();
                AtualizarDataGridEtapas();
            }
            catch { }
        }

        private void dataGridViewEtapas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                dataGridViewEtapas.CurrentCell = dataGridViewEtapas.Rows[e.RowIndex].Cells[0];
            }
            catch { }

            try
            {
                if (e.ColumnIndex == 1)
                {
                    int ordem = Convert.ToInt32(dataGridViewEtapas.Rows[e.RowIndex].Cells[0].Value);
                    textBoxDetalhes.Text = comandos.DetalhesDaEtapa(id_projeto, ordem);

                    if (!textBoxDetalhes.Visible)
                    {
                        textBoxDetalhes.Top = Cursor.Position.Y - 80;
                        textBoxDetalhes.Left = Cursor.Position.X - 120;
                        int comprimento = textBoxDetalhes.Text.Length;
                        textBoxDetalhes.Height = 20 * (comprimento / 33 + 1);
                    }

                    textBoxDetalhes.Visible = true;
                }

            }
            catch { }
        }

        private void dataGridViewEtapas_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            textBoxDetalhes.Visible = false;
        }

        private void dataGridViewEtapas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        dataGridViewEtapas.CurrentCell = dataGridViewEtapas.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dataGridViewEtapas.Rows[e.RowIndex].Selected = true;
                        dataGridViewEtapas.Focus();
                        ordem = Convert.ToInt32(dataGridViewEtapas.Rows[e.RowIndex].Cells[0].Value);
                        string status = etapas.Where(x => x.Ordem == ordem).Select(x => x.Status).FirstOrDefault();

                        if (status == "Pendente")
                        {
                            iniciarToolStripMenuItem.Visible = true;
                            ConcluirToolStripMenuItem.Visible = false;
                            retomarToolStripMenuItem.Visible = false;
                            registrarPendenciaToolStripMenuItem.Visible = false;
                            afazeresToolStripMenuItem.Visible = true;
                        }
                        else if (status == "Em andamento")
                        {
                            iniciarToolStripMenuItem.Visible = false;
                            ConcluirToolStripMenuItem.Visible = true;
                            retomarToolStripMenuItem.Visible = false;
                            registrarPendenciaToolStripMenuItem.Visible = true;
                            afazeresToolStripMenuItem.Visible = true;
                        }
                        else if (status == "Concluído")
                        {
                            iniciarToolStripMenuItem.Visible = false;
                            ConcluirToolStripMenuItem.Visible = false;
                            retomarToolStripMenuItem.Visible = true;
                            registrarPendenciaToolStripMenuItem.Visible = true;
                            afazeresToolStripMenuItem.Visible = false;
                        }

                    }
                    else { }
                }
                catch { }
            }
        }


        private void adicionarÀListaDeAfazeresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ordem != 0)
            {
                Afazer afazer = comandos.TrazerAfazerAPartirDaEtapa(id_projeto, ordem);
                formGestaoAfazeresAdicionar adicionar_afazer = new formGestaoAfazeresAdicionar(afazer);
                adicionar_afazer.ShowDialog();
                AtualizarDataGridEtapas();
            }
        }

        private void iniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ordem >= 1)
            {
                comandos.IniciarEtapa(id_projeto, ordem);
                AtualizarDataGridEtapas();
            }
        }

        private void timerTempo_Tick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow linha in dataGridViewEtapas.Rows)
            {
                if (dataGridViewEtapas.Rows[linha.Index].Cells[2].Value.ToString() == "Em andamento")
                {
                    try { dataGridViewEtapas.Rows[linha.Index].Cells[3].Value = Convert.ToDateTime(dataGridViewEtapas.Rows[linha.Index].Cells[3].Value).AddSeconds(1).ToLongTimeString(); }
                    catch { }
                }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ordem >= 1)
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar a etapa?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarEtapa(id_projeto, ordem);
                    comandos.ReordenarEtapas(id_projeto);
                    AtualizarDataGridEtapas();
                }
            }
        }

        private void retomarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ordem >= 1)
            {
                comandos.RetomarEtapa(id_projeto, ordem);
                RetomarProjetoAutomaticamente();
                AtualizarDataGridEtapas();
            }
        }

        private void registrarPendenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ordem >= 1)
            {
                comandos.AlterarStatusDaEtapaParaPendente(id_projeto, ordem);
                AtualizarDataGridEtapas();
            }
        }

        private void RetomarProjetoAutomaticamente()
        {
            bool concluido = true;

            foreach (Etapa etapa in etapas)
            {
                if (etapa.Status != "Concluído" && ordem != etapa.Ordem)
                {
                    concluido = false;
                }
            }

            if (concluido)
            {
                comandos.RetomarProjeto(id_projeto);
                AtualizarDataGridProjetos();

                MessageBox.Show("Projeto retomado!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ConcluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ordem >= 1)
            {
                comandos.ConcluirEtapa(id_projeto, ordem);
                ConcluirProjetoAutomaticamente();
                AtualizarDataGridProjetos();
                AtualizarDataGridEtapas();
            }
        }

        private void ConcluirProjetoAutomaticamente()
        {
            bool concluido = true;

            foreach (Etapa etapa in etapas)
            {
                if (etapa.Status != "Concluído" && ordem != etapa.Ordem)
                {
                    concluido = false;
                }
            }


            if (concluido)
            {
                comandos.ConcluirProjeto(id_projeto);
                AtualizarDataGridProjetos();

                if (projetos_concluidos)
                {
                    id_projeto = projetos.Where(x => x.Status != "Concluído").Min(x => x.ID_Projeto);
                }

                AtualizarDataGridEtapas();

                MessageBox.Show("Projeto concluído!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Eventos

        private void AtualizarDataGridEventos()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewEventos.CurrentRow != null)
            {
                primeira_linha = dataGridViewEventos.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewEventos.CurrentRow.Index;
            }

            dataGridViewEventos.Rows.Clear();
            eventos = comandos.ListaDeEventos();
            
            foreach (Notificacao evento in eventos)
            {
                string hora = evento.Hora.ToShortDateString() + " " + evento.Hora.ToShortTimeString();
                dataGridViewEventos.Rows.Add(evento.Descricao, hora);
            }

            try
            {
                dataGridViewEventos.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewEventos.CurrentCell = dataGridViewEventos.Rows[linha_selecionada].Cells[0];
            }
            catch { }
            
            if (dataGridViewEventos.CurrentRow != null)
                dataGridViewEventos.CurrentRow.Selected = false;
        }

        #endregion

        #region Configurações

        private void buttonConfiguracoes_Click(object sender, EventArgs e)
        {
            formGestaoConfiguracoes configuracoes = new formGestaoConfiguracoes("Computador");
            configuracoes.ShowDialog();
        }

        private void parâmetrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formGestaoConfiguracoes configuracoes = new formGestaoConfiguracoes("Parâmetros");
            configuracoes.ShowDialog();
        }

        private void definiçõesDoComputadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formGestaoConfiguracoes configuracoes = new formGestaoConfiguracoes("Computador");
            configuracoes.ShowDialog();
        }

        private void personalizaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formGestaoConfiguracoes configuracoes = new formGestaoConfiguracoes("Personalização");
            configuracoes.ShowDialog();
        }

        #endregion

        #region Botões

        private void buttonCompromisso_Click(object sender, EventArgs e)
        {
            formGestaoCompromisso compromisso = new formGestaoCompromisso();
            compromisso.ShowDialog();
            AtualizarDataGridEventos();
        }

        private void buttonLembrete_Click(object sender, EventArgs e)
        {
            formGestaoLembrete lembrete = new formGestaoLembrete();
            lembrete.ShowDialog();
            AtualizarDataGridEventos();
        }

        private void buttonDelegaveis_Click(object sender, EventArgs e)
        {
            formGestaoAtividadesDelegaveis delegavel = new formGestaoAtividadesDelegaveis();
            delegavel.ShowDialog();
        }

        private void panelEtapas_Resize(object sender, EventArgs e)
        {
            labelEtapas.Left = (panelEtapas.Width / 2) - (labelEtapas.Width / 2);
        }

        private void buttonColaboradores_Click(object sender, EventArgs e)
        {
            formColaboradores colaboradores = new formColaboradores();
            colaboradores.ShowDialog();
        }

        private void buttonExpediente_Click(object sender, EventArgs e)
        {
            formGestaoExpedientes expedientes = new formGestaoExpedientes();
            expedientes.ShowDialog();
        }

        private void buttonMetas_Click(object sender, EventArgs e)
        {

        }

        private void buttonLicitacao_Click(object sender, EventArgs e)
        {

        }

        private void buttonEstabelecimentos_Click(object sender, EventArgs e)
        {
            formGestaoEstabelecimentos estabelecimentos = new formGestaoEstabelecimentos();
            estabelecimentos.ShowDialog();
        }


        #endregion

        private void adicionarEtapaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Projeto projeto = projetos.Where(x => x.ID_Projeto == id_projeto).FirstOrDefault();
            formGestaoAdicionarEtapa adicionar = new formGestaoAdicionarEtapa(this, projeto);
            adicionar.ShowDialog();
            AtualizarDataGridEtapas();
        }

        private void buttonTreinamentos_Click(object sender, EventArgs e)
        {
            formGestaoCursosTreinamentos treinamentos = new formGestaoCursosTreinamentos();
            treinamentos.ShowDialog();
        }

        private void buttonRegulamento_Click(object sender, EventArgs e)
        {
            formGestaoRegulamentos regulamentos = new formGestaoRegulamentos();
            regulamentos.ShowDialog();
        }

        private void buttonInstrutor_Click(object sender, EventArgs e)
        {
            formTelaInicialPrincipalInstrucoes instrucoes = new formTelaInicialPrincipalInstrucoes();
            instrucoes.ShowDialog();
        }

        private void buttonFerramentas_Click(object sender, EventArgs e)
        {
            formGestaoFerramentas ferramentas = new formGestaoFerramentas();
            ferramentas.ShowDialog();
        }

        private void buttonAfazeres_Click(object sender, EventArgs e)
        {
            formGestaoAfazeres afazeres = new formGestaoAfazeres();
            afazeres.ShowDialog();
            AtualizarDataGridEtapas();
        }

        private void imprimirToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            formGestaoExpedientesImprimir imprimir = new formGestaoExpedientesImprimir();
            imprimir.ShowDialog();
        }

        private void labelMetas_Click(object sender, EventArgs e)
        {
            formGestaoMeta meta = new formGestaoMeta();
            meta.ShowDialog();
        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {
            formGestaoMeta meta = new formGestaoMeta();
            meta.ShowDialog();
        }

        private void AtualizarProgressBarMetas()
        {
            try
            {
                decimal diaria = comandos.PercentualDaMetaDiaria(data);
                string[] valor = diaria.ToString("F").Split(',');

                if (diaria <= 100)
                    circularProgressBarDiaria.Value = Convert.ToInt32(diaria);
                else
                    circularProgressBarDiaria.Value = 100;
                circularProgressBarDiaria.Text = valor[0] + ".";
                circularProgressBarDiaria.SubscriptText = valor[1];

                circularProgressBarDiaria.Refresh();

                decimal mensal = comandos.PercentualDaMetaMensal(data);

                if (mensal <= 100)
                    circularProgressBarMensal.Value = Convert.ToInt32(mensal);
                else
                    circularProgressBarMensal.Value = 100;
                circularProgressBarMensal.Text = mensal.ToString("F") + "%";
            }
            catch { }
        }

        private void timerMetas_Tick(object sender, EventArgs e)
        {
            AtualizarProgressBarMetas();
        }

        private void dateTimePickerMeta_ValueChanged(object sender, EventArgs e)
        {
            data = dateTimePickerMeta.Value;
            string dia_da_semana = formato.GetDayName(data.DayOfWeek).PrimeiraLetraMaiuscula();

            Color cor = new Color();

            switch (dia_da_semana)
            {
                case "Domingo":
                    cor = Color.MidnightBlue;
                    break;
                case "Segunda-feira":
                    cor = Color.DeepPink;
                    break;
                case "Terça-feira":
                    cor = Color.DarkRed;
                    break;
                case "Quarta-feira":
                    cor = Color.Gold;
                    break;
                case "Quinta-feira":
                    cor = Color.Purple;
                    break;
                case "Sexta-feira":
                    cor = Color.DarkGreen;
                    break;
                case "Sábado":
                    cor = Color.OrangeRed;
                    break;
            }

            circularProgressBarDiaria.ProgressColor = cor;
            AtualizarProgressBarMetas();
        }

        private void pbProximo_Click(object sender, EventArgs e)
        {
            dateTimePickerMeta.Value = dateTimePickerMeta.Value.AddDays(1);
        }

        private void pbAnterior_Click(object sender, EventArgs e)
        {
            dateTimePickerMeta.Value = dateTimePickerMeta.Value.AddDays(-1);
        }
    }
}
