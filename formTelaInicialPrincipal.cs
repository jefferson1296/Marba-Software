using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarbaSoftware
{
    public partial class formTelaInicialPrincipal : Form
    {
        List<AtividadeRealizada> lista_atividades;
        ComandosSQL comando = new ComandosSQL();
        bool centralizar = false;
        int mes;
        int ano;
        public formTelaInicialPrincipal()
        {
            InitializeComponent();
            shadowControls.Add(panelEscala);
            shadowControls.Add(panelBanco);
        }

        private void formTelaInicialPrincipal_Load(object sender, EventArgs e)
        {
            pbAnterior.Visible = false;
            pbProximo.Visible = false;

            lista_atividades = comando.ListaDeAtividadesPorColaborador();
            PreencherDataGrid();
            timerTempo.Enabled = true;
            DateTime now = DateTime.Now;
            mes = now.Month;
            ano = now.Year;
            PreencherCalendario(mes, ano);
            FonteECorDeFundo();
            Refresh();

            textBoxSemanaisTrabalhadas.Text = comando.HorasSemanaisTrabalhadasDoFuncionario().ToString("F");
            textBoxSemanais.Text = comando.HorasSemanaisDoFuncionario().ToString("F");
            textBoxMensais.Text = comando.HorasMensaisDoFuncionario().ToString("F");
            textBoxMensaisTrabalhadas.Text = comando.HorasMensaisTrabalhadasDoFuncionario().ToString("F");
            textBoxRealizadas.Text = comando.HorasExtrasComputadas().ToString("F");

            bool botao_estoque = Program.Acessos.Where(x => x.Descricao == "Botão do estoque na tela inicial").Select(x => x.Permissao).FirstOrDefault();
            bool botao_gerente = Program.Acessos.Where(x => x.Descricao == "Botão de gerente na tela inicial").Select(x => x.Permissao).FirstOrDefault();
            bool botao_instrucoes = Program.Acessos.Where(x => x.Descricao == "Botão de instruções na tela inicial").Select(x => x.Permissao).FirstOrDefault();
            bool botao_atividades = Program.Acessos.Where(x => x.Descricao == "Botão de atividades na tela inicial").Select(x => x.Permissao).FirstOrDefault();

            if (botao_estoque)
                buttonEstoque.Visible = true;
            if (botao_gerente)
                buttonGerente.Visible = true;
            if (botao_instrucoes)
                buttonInstrucoes.Visible = true;
            if (botao_atividades)
                buttonAtividades.Visible = true;
        }

        private void PreencherDataGrid()
        {
            dataGridViewLista.Rows.Clear();
            foreach (AtividadeRealizada atv in lista_atividades)
            {
                string atividade = atv.Descricao;
                string status = atv.Status;
                string data = DateTime.Now.ToShortDateString();

                if (atv.Status == "Em andamento")
                {

                    dataGridViewLista.Rows.Add(data, atividade, status);
                }
                else if (atv.Status == "Pendente")
                {
                    dataGridViewLista.Rows.Add(data, atividade, status);
                }
            }
        }

        private void FonteECorDeFundo()
        {
            Color minha_cor1 = Color.White;
            Color minha_cor2 = Color.Red;

            textBox0.BackColor = minha_cor1;
            textBox0.ForeColor = minha_cor2;
            textBox1.BackColor = minha_cor1;
            textBox1.ForeColor = minha_cor2;
            textBox2.BackColor = minha_cor1;
            textBox2.ForeColor = minha_cor2;
            textBox3.BackColor = minha_cor1;
            textBox3.ForeColor = minha_cor2;
            textBox4.BackColor = minha_cor1;
            textBox4.ForeColor = minha_cor2;
            textBox5.BackColor = minha_cor1;
            textBox5.ForeColor = minha_cor2;
            textBox6.BackColor = minha_cor1;
            textBox6.ForeColor = minha_cor2;
            textBox7.BackColor = minha_cor1;
            textBox7.ForeColor = minha_cor2;
            textBox8.BackColor = minha_cor1;
            textBox8.ForeColor = minha_cor2;
            textBox9.BackColor = minha_cor1;
            textBox9.ForeColor = minha_cor2;
            textBox10.BackColor = minha_cor1;
            textBox10.ForeColor = minha_cor2;
            textBox11.BackColor = minha_cor1;
            textBox11.ForeColor = minha_cor2;
            textBox12.BackColor = minha_cor1;
            textBox12.ForeColor = minha_cor2;
            textBox13.BackColor = minha_cor1;
            textBox13.ForeColor = minha_cor2;
            textBox14.BackColor = minha_cor1;
            textBox14.ForeColor = minha_cor2;
            textBox15.BackColor = minha_cor1;
            textBox15.ForeColor = minha_cor2;
            textBox16.BackColor = minha_cor1;
            textBox16.ForeColor = minha_cor2;
            textBox17.BackColor = minha_cor1;
            textBox17.ForeColor = minha_cor2;
            textBox18.BackColor = minha_cor1;
            textBox18.ForeColor = minha_cor2;
            textBox19.BackColor = minha_cor1;
            textBox19.ForeColor = minha_cor2;
            textBox20.BackColor = minha_cor1;
            textBox20.ForeColor = minha_cor2;
            textBox21.BackColor = minha_cor1;
            textBox21.ForeColor = minha_cor2;
            textBox22.BackColor = minha_cor1;
            textBox22.ForeColor = minha_cor2;
            textBox23.BackColor = minha_cor1;
            textBox23.ForeColor = minha_cor2;
            textBox24.BackColor = minha_cor1;
            textBox24.ForeColor = minha_cor2;
            textBox25.BackColor = minha_cor1;
            textBox25.ForeColor = minha_cor2;
            textBox26.BackColor = minha_cor1;
            textBox26.ForeColor = minha_cor2;
            textBox27.BackColor = minha_cor1;
            textBox27.ForeColor = minha_cor2;
            textBox28.BackColor = minha_cor1;
            textBox28.ForeColor = minha_cor2;
            textBox29.BackColor = minha_cor1;
            textBox29.ForeColor = minha_cor2;
            textBox30.BackColor = minha_cor1;
            textBox30.ForeColor = minha_cor2;
            textBox31.BackColor = minha_cor1;
            textBox31.ForeColor = minha_cor2;
            textBox32.BackColor = minha_cor1;
            textBox32.ForeColor = minha_cor2;
            textBox33.BackColor = minha_cor1;
            textBox33.ForeColor = minha_cor2;
            textBox34.BackColor = minha_cor1;
            textBox34.ForeColor = minha_cor2;
            textBox35.BackColor = minha_cor1;
            textBox35.ForeColor = minha_cor2;
            textBox36.BackColor = minha_cor1;
            textBox36.ForeColor = minha_cor2;
            textBox37.BackColor = minha_cor1;
            textBox37.ForeColor = minha_cor2;
            textBox38.BackColor = minha_cor1;
            textBox38.ForeColor = minha_cor2;
            textBox39.BackColor = minha_cor1;
            textBox39.ForeColor = minha_cor2;
            textBox40.BackColor = minha_cor1;
            textBox40.ForeColor = minha_cor2;
            textBox41.BackColor = minha_cor1;
            textBox41.ForeColor = minha_cor2;
        }

        public void PreencherCalendario(int mes, int ano)
        {
            DateTime data = new DateTime(ano, mes, 1);
            CultureInfo cultura = new CultureInfo("pt-BR");
            DateTimeFormatInfo formato = cultura.DateTimeFormat;

            string mes_ = data.ToString(@"MMMM");
            string Mes = mes_.PrimeiraLetraMaiuscula();
            labelMes.Text = Mes + " / " + Convert.ToString(ano);

            string dia_da_semana = formato.GetDayName(data.DayOfWeek).PrimeiraLetraMaiuscula();
            int i = 0;
            if (dia_da_semana == labelDomingo.Text)
            {
                i = 1;
            }
            else if (dia_da_semana == labelSegunda.Text)
            {
                i = 0;
            }
            else if (dia_da_semana == labelTerca.Text)
            {
                i = -1;
            }
            else if (dia_da_semana == labelQuarta.Text)
            {
                i = -2;
            }
            else if (dia_da_semana == labelQuinta.Text)
            {
                i = -3;
            }
            else if (dia_da_semana == labelSexta.Text)
            {
                i = -4;
            }
            else if (dia_da_semana == labelSabado.Text)
            {
                i = -5;
            }

            LimparInformacoes();

            label0.Text = i.ToString();
            label1.Text = (i + 1).ToString();
            label2.Text = (i + 2).ToString();
            label3.Text = (i + 3).ToString();
            label4.Text = (i + 4).ToString();
            label5.Text = (i + 5).ToString();
            label6.Text = (i + 6).ToString();
            label7.Text = (i + 7).ToString();
            label8.Text = (i + 8).ToString();
            label9.Text = (i + 9).ToString();
            label10.Text = (i + 10).ToString();
            label11.Text = (i + 11).ToString();
            label12.Text = (i + 12).ToString();
            label13.Text = (i + 13).ToString();
            label14.Text = (i + 14).ToString();
            label15.Text = (i + 15).ToString();
            label16.Text = (i + 16).ToString();
            label17.Text = (i + 17).ToString();
            label18.Text = (i + 18).ToString();
            label19.Text = (i + 19).ToString();
            label20.Text = (i + 20).ToString();
            label21.Text = (i + 21).ToString();
            label22.Text = (i + 22).ToString();
            label23.Text = (i + 23).ToString();
            label24.Text = (i + 24).ToString();
            label25.Text = (i + 25).ToString();
            label26.Text = (i + 26).ToString();
            label27.Text = (i + 27).ToString();
            label28.Text = (i + 28).ToString();
            label29.Text = (i + 29).ToString();
            label30.Text = (i + 30).ToString();
            label31.Text = (i + 31).ToString();
            label32.Text = (i + 32).ToString();
            label33.Text = (i + 33).ToString();
            label34.Text = (i + 34).ToString();
            label35.Text = (i + 35).ToString();
            label36.Text = (i + 36).ToString();
            label37.Text = (i + 37).ToString();
            label38.Text = (i + 38).ToString();
            label39.Text = (i + 39).ToString();
            label40.Text = (i + 40).ToString();
            label41.Text = (i + 41).ToString();

            int id_colaborador = comando.TrazerIdDoColaboradorPelaMatricula(Program.matricula);
            string informacoes;

            DateTime promocao;
            try
            {
                promocao = new DateTime(ano, mes, i);
                informacoes = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
                textBox0.Text = informacoes;
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 1);
                informacoes = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
                textBox1.Text = informacoes;
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 2);
                informacoes = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
                textBox2.Text = informacoes;
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 3);
                informacoes = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
                textBox3.Text = informacoes;
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 4);
                informacoes = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
                textBox4.Text = informacoes;
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 5);
                informacoes = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
                textBox5.Text = informacoes;
            }
            catch { }
            promocao = new DateTime(ano, mes, i + 6);
            informacoes = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            textBox6.Text = informacoes;
            promocao = new DateTime(ano, mes, i + 7);
            informacoes = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            textBox7.Text = informacoes;
            promocao = new DateTime(ano, mes, i + 8);
            informacoes = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            textBox8.Text = informacoes;
            promocao = new DateTime(ano, mes, i + 9);
            informacoes = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            textBox9.Text = informacoes;
            promocao = new DateTime(ano, mes, i + 10);
            textBox10.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            promocao = new DateTime(ano, mes, i + 11);
            textBox11.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            promocao = new DateTime(ano, mes, i + 12);
            textBox12.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            promocao = new DateTime(ano, mes, i + 13);
            textBox13.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            promocao = new DateTime(ano, mes, i + 14);
            textBox14.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            promocao = new DateTime(ano, mes, i + 15);
            textBox15.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            promocao = new DateTime(ano, mes, i + 16);
            textBox16.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            promocao = new DateTime(ano, mes, i + 17);
            textBox17.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            promocao = new DateTime(ano, mes, i + 18);
            textBox18.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            promocao = new DateTime(ano, mes, i + 19);
            textBox19.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            promocao = new DateTime(ano, mes, i + 20);
            textBox20.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            promocao = new DateTime(ano, mes, i + 21);
            textBox21.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            promocao = new DateTime(ano, mes, i + 22);
            textBox22.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            promocao = new DateTime(ano, mes, i + 23);
            textBox23.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            promocao = new DateTime(ano, mes, i + 24);
            textBox24.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            promocao = new DateTime(ano, mes, i + 25);
            textBox25.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            promocao = new DateTime(ano, mes, i + 26);
            textBox26.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            promocao = new DateTime(ano, mes, i + 27);
            textBox27.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            try
            {
                promocao = new DateTime(ano, mes, i + 28);
                textBox28.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 29);
                textBox29.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 30);
                textBox30.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 31);
                textBox31.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 32);
                textBox32.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 33);
                textBox33.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 34);
                textBox34.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 35);
                textBox35.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 36);
                textBox36.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 37);
                textBox37.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 38);
                textBox38.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 39);
                textBox39.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 40);
                textBox40.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 41);
                textBox41.Text = comando.TrazerHorariosParaOCalendarioPequeno(promocao, id_colaborador);
            }
            catch { }


            //Corrigir dias dos meses anterior e subsequente
            int diasMesAnterior;
            if (mes == 1)
            {
                diasMesAnterior = DateTime.DaysInMonth(ano, 12);
            }
            else
            {
                diasMesAnterior = DateTime.DaysInMonth(ano, mes - 1);
            }
            int diasMesAtual = DateTime.DaysInMonth(ano, mes);

            if (dia_da_semana == labelDomingo.Text)
            {
                int x = 1;
                if (diasMesAtual == 28)
                {
                    label28.ForeColor = Color.LightGray;
                    label29.ForeColor = Color.LightGray;
                    label30.ForeColor = Color.LightGray;
                    label31.ForeColor = Color.LightGray;
                    label32.ForeColor = Color.LightGray;
                    label33.ForeColor = Color.LightGray;
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label28.Text = x.ToString();
                    label29.Text = (x + 1).ToString();
                    label30.Text = (x + 2).ToString();
                    label31.Text = (x + 3).ToString();
                    label32.Text = (x + 4).ToString();
                    label33.Text = (x + 5).ToString();
                    label34.Text = (x + 6).ToString();
                    label35.Text = (x + 7).ToString();
                    label36.Text = (x + 8).ToString();
                    label37.Text = (x + 9).ToString();
                    label38.Text = (x + 10).ToString();
                    label39.Text = (x + 11).ToString();
                    label40.Text = (x + 12).ToString();
                    label41.Text = (x + 13).ToString();
                }
                else if (diasMesAtual == 29)
                {
                    label29.ForeColor = Color.LightGray;
                    label30.ForeColor = Color.LightGray;
                    label31.ForeColor = Color.LightGray;
                    label32.ForeColor = Color.LightGray;
                    label33.ForeColor = Color.LightGray;
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label29.Text = x.ToString();
                    label30.Text = (x + 1).ToString();
                    label31.Text = (x + 2).ToString();
                    label32.Text = (x + 3).ToString();
                    label33.Text = (x + 4).ToString();
                    label34.Text = (x + 5).ToString();
                    label35.Text = (x + 6).ToString();
                    label36.Text = (x + 7).ToString();
                    label37.Text = (x + 8).ToString();
                    label38.Text = (x + 9).ToString();
                    label39.Text = (x + 10).ToString();
                    label40.Text = (x + 11).ToString();
                    label41.Text = (x + 12).ToString();
                }
                else if (diasMesAtual == 30)
                {
                    label30.ForeColor = Color.LightGray;
                    label31.ForeColor = Color.LightGray;
                    label32.ForeColor = Color.LightGray;
                    label33.ForeColor = Color.LightGray;
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label30.Text = x.ToString();
                    label31.Text = (x + 1).ToString();
                    label32.Text = (x + 2).ToString();
                    label33.Text = (x + 3).ToString();
                    label34.Text = (x + 4).ToString();
                    label35.Text = (x + 5).ToString();
                    label36.Text = (x + 6).ToString();
                    label37.Text = (x + 7).ToString();
                    label38.Text = (x + 8).ToString();
                    label39.Text = (x + 9).ToString();
                    label40.Text = (x + 10).ToString();
                    label41.Text = (x + 11).ToString();
                }
                else if (diasMesAtual == 31)
                {
                    label31.ForeColor = Color.LightGray;
                    label32.ForeColor = Color.LightGray;
                    label33.ForeColor = Color.LightGray;
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label31.Text = x.ToString();
                    label32.Text = (x + 1).ToString();
                    label33.Text = (x + 2).ToString();
                    label34.Text = (x + 3).ToString();
                    label35.Text = (x + 4).ToString();
                    label36.Text = (x + 5).ToString();
                    label37.Text = (x + 6).ToString();
                    label38.Text = (x + 7).ToString();
                    label39.Text = (x + 8).ToString();
                    label40.Text = (x + 9).ToString();
                    label41.Text = (x + 10).ToString();
                }
            }
            else if (dia_da_semana == labelSegunda.Text)
            {
                label0.Text = diasMesAnterior.ToString();
                label0.ForeColor = Color.LightGray;
                int x = 1;
                if (diasMesAtual == 28)
                {
                    label29.ForeColor = Color.LightGray;
                    label30.ForeColor = Color.LightGray;
                    label31.ForeColor = Color.LightGray;
                    label32.ForeColor = Color.LightGray;
                    label33.ForeColor = Color.LightGray;
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label29.Text = x.ToString();
                    label30.Text = (x + 1).ToString();
                    label31.Text = (x + 2).ToString();
                    label32.Text = (x + 3).ToString();
                    label33.Text = (x + 4).ToString();
                    label34.Text = (x + 5).ToString();
                    label35.Text = (x + 6).ToString();
                    label36.Text = (x + 7).ToString();
                    label37.Text = (x + 8).ToString();
                    label38.Text = (x + 9).ToString();
                    label39.Text = (x + 10).ToString();
                    label40.Text = (x + 11).ToString();
                    label41.Text = (x + 12).ToString();
                }
                else if (diasMesAtual == 29)
                {
                    label30.ForeColor = Color.LightGray;
                    label31.ForeColor = Color.LightGray;
                    label32.ForeColor = Color.LightGray;
                    label33.ForeColor = Color.LightGray;
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label30.Text = x.ToString();
                    label31.Text = (x + 1).ToString();
                    label32.Text = (x + 2).ToString();
                    label33.Text = (x + 3).ToString();
                    label34.Text = (x + 4).ToString();
                    label35.Text = (x + 5).ToString();
                    label36.Text = (x + 6).ToString();
                    label37.Text = (x + 7).ToString();
                    label38.Text = (x + 8).ToString();
                    label39.Text = (x + 9).ToString();
                    label40.Text = (x + 10).ToString();
                    label41.Text = (x + 11).ToString();
                }
                else if (diasMesAtual == 30)
                {
                    label31.ForeColor = Color.LightGray;
                    label32.ForeColor = Color.LightGray;
                    label33.ForeColor = Color.LightGray;
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label31.Text = x.ToString();
                    label32.Text = (x + 1).ToString();
                    label33.Text = (x + 2).ToString();
                    label34.Text = (x + 3).ToString();
                    label35.Text = (x + 4).ToString();
                    label36.Text = (x + 5).ToString();
                    label37.Text = (x + 6).ToString();
                    label38.Text = (x + 7).ToString();
                    label39.Text = (x + 8).ToString();
                    label40.Text = (x + 9).ToString();
                    label41.Text = (x + 10).ToString();
                }
                else if (diasMesAtual == 31)
                {
                    label32.ForeColor = Color.LightGray;
                    label33.ForeColor = Color.LightGray;
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label32.Text = x.ToString();
                    label33.Text = (x + 1).ToString();
                    label34.Text = (x + 2).ToString();
                    label35.Text = (x + 3).ToString();
                    label36.Text = (x + 4).ToString();
                    label37.Text = (x + 5).ToString();
                    label38.Text = (x + 6).ToString();
                    label39.Text = (x + 7).ToString();
                    label40.Text = (x + 8).ToString();
                    label41.Text = (x + 9).ToString();
                }
            }
            else if (dia_da_semana == labelTerca.Text)
            {
                label1.Text = diasMesAnterior.ToString();
                label0.Text = (diasMesAnterior - 1).ToString();
                label1.ForeColor = Color.LightGray;
                label0.ForeColor = Color.LightGray;
                int x = 1;

                if (diasMesAtual == 28)
                {
                    label30.ForeColor = Color.LightGray;
                    label31.ForeColor = Color.LightGray;
                    label32.ForeColor = Color.LightGray;
                    label33.ForeColor = Color.LightGray;
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label30.Text = x.ToString();
                    label31.Text = (x + 1).ToString();
                    label32.Text = (x + 2).ToString();
                    label33.Text = (x + 3).ToString();
                    label34.Text = (x + 4).ToString();
                    label35.Text = (x + 5).ToString();
                    label36.Text = (x + 6).ToString();
                    label37.Text = (x + 7).ToString();
                    label38.Text = (x + 8).ToString();
                    label39.Text = (x + 9).ToString();
                    label40.Text = (x + 10).ToString();
                    label41.Text = (x + 11).ToString();
                }
                else if (diasMesAtual == 29)
                {
                    label31.ForeColor = Color.LightGray;
                    label32.ForeColor = Color.LightGray;
                    label33.ForeColor = Color.LightGray;
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label31.Text = x.ToString();
                    label32.Text = (x + 1).ToString();
                    label33.Text = (x + 2).ToString();
                    label34.Text = (x + 3).ToString();
                    label35.Text = (x + 4).ToString();
                    label36.Text = (x + 5).ToString();
                    label37.Text = (x + 6).ToString();
                    label38.Text = (x + 7).ToString();
                    label39.Text = (x + 8).ToString();
                    label40.Text = (x + 9).ToString();
                    label41.Text = (x + 10).ToString();
                }
                else if (diasMesAtual == 30)
                {
                    label32.ForeColor = Color.LightGray;
                    label33.ForeColor = Color.LightGray;
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label32.Text = x.ToString();
                    label33.Text = (x + 1).ToString();
                    label34.Text = (x + 2).ToString();
                    label35.Text = (x + 3).ToString();
                    label36.Text = (x + 4).ToString();
                    label37.Text = (x + 5).ToString();
                    label38.Text = (x + 6).ToString();
                    label39.Text = (x + 7).ToString();
                    label40.Text = (x + 8).ToString();
                    label41.Text = (x + 9).ToString();
                }
                else if (diasMesAtual == 31)
                {
                    label33.ForeColor = Color.LightGray;
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label33.Text = x.ToString();
                    label34.Text = (x + 1).ToString();
                    label35.Text = (x + 2).ToString();
                    label36.Text = (x + 3).ToString();
                    label37.Text = (x + 4).ToString();
                    label38.Text = (x + 5).ToString();
                    label39.Text = (x + 6).ToString();
                    label40.Text = (x + 7).ToString();
                    label41.Text = (x + 8).ToString();
                }

            }
            else if (dia_da_semana == labelQuarta.Text)
            {
                label2.Text = diasMesAnterior.ToString();
                label1.Text = (diasMesAnterior - 1).ToString();
                label0.Text = (diasMesAnterior - 2).ToString();
                label2.ForeColor = Color.LightGray;
                label1.ForeColor = Color.LightGray;
                label0.ForeColor = Color.LightGray;
                int x = 1;

                if (diasMesAtual == 28)
                {
                    label31.ForeColor = Color.LightGray;
                    label32.ForeColor = Color.LightGray;
                    label33.ForeColor = Color.LightGray;
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label31.Text = x.ToString();
                    label32.Text = (x + 1).ToString();
                    label33.Text = (x + 2).ToString();
                    label34.Text = (x + 3).ToString();
                    label35.Text = (x + 4).ToString();
                    label36.Text = (x + 5).ToString();
                    label37.Text = (x + 6).ToString();
                    label38.Text = (x + 7).ToString();
                    label39.Text = (x + 8).ToString();
                    label40.Text = (x + 9).ToString();
                    label41.Text = (x + 10).ToString();
                }
                else if (diasMesAtual == 29)
                {
                    label32.ForeColor = Color.LightGray;
                    label33.ForeColor = Color.LightGray;
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label32.Text = x.ToString();
                    label33.Text = (x + 1).ToString();
                    label34.Text = (x + 2).ToString();
                    label35.Text = (x + 3).ToString();
                    label36.Text = (x + 4).ToString();
                    label37.Text = (x + 5).ToString();
                    label38.Text = (x + 6).ToString();
                    label39.Text = (x + 7).ToString();
                    label40.Text = (x + 8).ToString();
                    label41.Text = (x + 9).ToString();
                }
                else if (diasMesAtual == 30)
                {
                    label33.ForeColor = Color.LightGray;
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label33.Text = x.ToString();
                    label34.Text = (x + 1).ToString();
                    label35.Text = (x + 2).ToString();
                    label36.Text = (x + 3).ToString();
                    label37.Text = (x + 4).ToString();
                    label38.Text = (x + 5).ToString();
                    label39.Text = (x + 6).ToString();
                    label40.Text = (x + 7).ToString();
                    label41.Text = (x + 8).ToString();
                }
                else if (diasMesAtual == 31)
                {
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label34.Text = x.ToString();
                    label35.Text = (x + 2).ToString();
                    label36.Text = (x + 3).ToString();
                    label37.Text = (x + 4).ToString();
                    label38.Text = (x + 5).ToString();
                    label39.Text = (x + 6).ToString();
                    label40.Text = (x + 7).ToString();
                    label41.Text = (x + 8).ToString();
                }
            }
            else if (dia_da_semana == labelQuinta.Text)
            {
                label3.Text = diasMesAnterior.ToString();
                label2.Text = (diasMesAnterior - 1).ToString();
                label1.Text = (diasMesAnterior - 2).ToString();
                label0.Text = (diasMesAnterior - 3).ToString();
                label3.ForeColor = Color.LightGray;
                label2.ForeColor = Color.LightGray;
                label1.ForeColor = Color.LightGray;
                label0.ForeColor = Color.LightGray;
                int x = 1;

                if (diasMesAtual == 28)
                {
                    label32.ForeColor = Color.LightGray;
                    label33.ForeColor = Color.LightGray;
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label32.Text = x.ToString();
                    label33.Text = (x + 1).ToString();
                    label34.Text = (x + 2).ToString();
                    label35.Text = (x + 3).ToString();
                    label36.Text = (x + 4).ToString();
                    label37.Text = (x + 5).ToString();
                    label38.Text = (x + 6).ToString();
                    label39.Text = (x + 7).ToString();
                    label40.Text = (x + 8).ToString();
                    label41.Text = (x + 9).ToString();
                }
                else if (diasMesAtual == 29)
                {
                    label33.ForeColor = Color.LightGray;
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label33.Text = x.ToString();
                    label34.Text = (x + 1).ToString();
                    label35.Text = (x + 2).ToString();
                    label36.Text = (x + 3).ToString();
                    label37.Text = (x + 4).ToString();
                    label38.Text = (x + 5).ToString();
                    label39.Text = (x + 6).ToString();
                    label40.Text = (x + 7).ToString();
                    label41.Text = (x + 8).ToString();
                }
                else if (diasMesAtual == 30)
                {
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label34.Text = x.ToString();
                    label35.Text = (x + 2).ToString();
                    label36.Text = (x + 3).ToString();
                    label37.Text = (x + 4).ToString();
                    label38.Text = (x + 5).ToString();
                    label39.Text = (x + 6).ToString();
                    label40.Text = (x + 7).ToString();
                    label41.Text = (x + 8).ToString();
                }
                else if (diasMesAtual == 31)
                {
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label35.Text = x.ToString();
                    label36.Text = (x + 1).ToString();
                    label37.Text = (x + 2).ToString();
                    label38.Text = (x + 3).ToString();
                    label39.Text = (x + 4).ToString();
                    label40.Text = (x + 5).ToString();
                    label41.Text = (x + 6).ToString();
                }
            }
            else if (dia_da_semana == labelSexta.Text)
            {
                label4.Text = diasMesAnterior.ToString();
                label3.Text = (diasMesAnterior - 1).ToString();
                label2.Text = (diasMesAnterior - 2).ToString();
                label1.Text = (diasMesAnterior - 3).ToString();
                label0.Text = (diasMesAnterior - 4).ToString();
                label4.ForeColor = Color.LightGray;
                label3.ForeColor = Color.LightGray;
                label2.ForeColor = Color.LightGray;
                label1.ForeColor = Color.LightGray;
                label0.ForeColor = Color.LightGray;

                int x = 1;

                if (diasMesAtual == 28)
                {
                    label33.ForeColor = Color.LightGray;
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label33.Text = x.ToString();
                    label34.Text = (x + 1).ToString();
                    label35.Text = (x + 2).ToString();
                    label36.Text = (x + 3).ToString();
                    label37.Text = (x + 4).ToString();
                    label38.Text = (x + 5).ToString();
                    label39.Text = (x + 6).ToString();
                    label40.Text = (x + 7).ToString();
                    label41.Text = (x + 8).ToString();
                }
                else if (diasMesAtual == 29)
                {
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label34.Text = x.ToString();
                    label35.Text = (x + 2).ToString();
                    label36.Text = (x + 3).ToString();
                    label37.Text = (x + 4).ToString();
                    label38.Text = (x + 5).ToString();
                    label39.Text = (x + 6).ToString();
                    label40.Text = (x + 7).ToString();
                    label41.Text = (x + 8).ToString();
                }
                else if (diasMesAtual == 30)
                {
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label35.Text = x.ToString();
                    label36.Text = (x + 1).ToString();
                    label37.Text = (x + 2).ToString();
                    label38.Text = (x + 3).ToString();
                    label39.Text = (x + 4).ToString();
                    label40.Text = (x + 5).ToString();
                    label41.Text = (x + 6).ToString();
                }
                else if (diasMesAtual == 31)
                {
                    label36.ForeColor = Color.LightGray;
                    label36.Text = x.ToString();
                    label37.Text = (x + 1).ToString();
                    label38.Text = (x + 2).ToString();
                    label39.Text = (x + 3).ToString();
                    label40.Text = (x + 4).ToString();
                    label41.Text = (x + 5).ToString();
                }
            }
            else if (dia_da_semana == labelSabado.Text)
            {
                label5.Text = diasMesAnterior.ToString();
                label4.Text = (diasMesAnterior - 1).ToString();
                label3.Text = (diasMesAnterior - 2).ToString();
                label2.Text = (diasMesAnterior - 3).ToString();
                label1.Text = (diasMesAnterior - 4).ToString();
                label0.Text = (diasMesAnterior - 5).ToString();
                label5.ForeColor = Color.LightGray;
                label4.ForeColor = Color.LightGray;
                label3.ForeColor = Color.LightGray;
                label2.ForeColor = Color.LightGray;
                label1.ForeColor = Color.LightGray;
                label0.ForeColor = Color.LightGray;

                int x = 1;
                if (diasMesAtual == 28)
                {
                    label34.ForeColor = Color.LightGray;
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label34.Text = x.ToString();
                    label35.Text = (x + 2).ToString();
                    label36.Text = (x + 3).ToString();
                    label37.Text = (x + 4).ToString();
                    label38.Text = (x + 5).ToString();
                    label39.Text = (x + 6).ToString();
                    label40.Text = (x + 7).ToString();
                    label41.Text = (x + 8).ToString();
                }
                else if (diasMesAtual == 29)
                {
                    label35.ForeColor = Color.LightGray;
                    label36.ForeColor = Color.LightGray;
                    label35.Text = x.ToString();
                    label36.Text = (x + 1).ToString();
                    label37.Text = (x + 2).ToString();
                    label38.Text = (x + 3).ToString();
                    label39.Text = (x + 4).ToString();
                    label40.Text = (x + 5).ToString();
                    label41.Text = (x + 6).ToString();
                }
                else if (diasMesAtual == 30)
                {
                    label36.ForeColor = Color.LightGray;
                    label36.Text = x.ToString();
                    label37.Text = (x + 1).ToString();
                    label38.Text = (x + 2).ToString();
                    label39.Text = (x + 3).ToString();
                    label40.Text = (x + 4).ToString();
                    label41.Text = (x + 5).ToString();
                }
                if (diasMesAtual == 31)
                {
                    label37.Text = x.ToString();
                    label38.Text = (x + 1).ToString();
                    label39.Text = (x + 2).ToString();
                    label40.Text = (x + 3).ToString();
                    label41.Text = (x + 4).ToString();
                }
            }

            label37.ForeColor = Color.LightGray;
            label38.ForeColor = Color.LightGray;
            label39.ForeColor = Color.LightGray;
            label40.ForeColor = Color.LightGray;
            label41.ForeColor = Color.LightGray;

            CentralizarDias();
        }

        private void LimparInformacoes()
        {
            textBox0.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
            textBox22.Clear();
            textBox23.Clear();
            textBox24.Clear();
            textBox25.Clear();
            textBox26.Clear();
            textBox27.Clear();
            textBox28.Clear();
            textBox29.Clear();
            textBox30.Clear();
            textBox31.Clear();
            textBox32.Clear();
            textBox33.Clear();
            textBox34.Clear();
            textBox35.Clear();
            textBox36.Clear();
            textBox37.Clear();
            textBox38.Clear();
            textBox39.Clear();
            textBox40.Clear();
            textBox41.Clear();
        }

        private void CentralizarDias()
        {
            int x = (panel14.Size.Width - label20.Size.Width) / 2;
            int y = (panel14.Size.Height - label20.Size.Height) / 2;
            label0.Location = new Point(x, y);
            label1.Location = new Point(x, y);
            label2.Location = new Point(x, y);
            label3.Location = new Point(x, y);
            label4.Location = new Point(x, y);
            label5.Location = new Point(x, y);
            label6.Location = new Point(x, y);
            label7.Location = new Point(x, y);
            label8.Location = new Point(x, y);
            label9.Location = new Point(x, y);
            label10.Location = new Point(x, y);
            label11.Location = new Point(x, y);
            label12.Location = new Point(x, y);
            label13.Location = new Point(x, y);
            label14.Location = new Point(x, y);
            label15.Location = new Point(x, y);
            label16.Location = new Point(x, y);
            label17.Location = new Point(x, y);
            label18.Location = new Point(x, y);
            label19.Location = new Point(x, y);
            label20.Location = new Point(x, y);
            label21.Location = new Point(x, y);
            label22.Location = new Point(x, y);
            label23.Location = new Point(x, y);
            label24.Location = new Point(x, y);
            label25.Location = new Point(x, y);
            label26.Location = new Point(x, y);
            label27.Location = new Point(x, y);
            label28.Location = new Point(x, y);
            label29.Location = new Point(x, y);
            label30.Location = new Point(x, y);
            label31.Location = new Point(x, y);
            label32.Location = new Point(x, y);
            label33.Location = new Point(x, y);
            label34.Location = new Point(x, y);
            label35.Location = new Point(x, y);
            label36.Location = new Point(x, y);
            label37.Location = new Point(x, y);
            label38.Location = new Point(x, y);
            label39.Location = new Point(x, y);
            label40.Location = new Point(x, y);
            label41.Location = new Point(x, y);
        }

        private void FormatarCorDaFonte()
        {
            Color minhaCor = Color.Black;

            label0.ForeColor = minhaCor;
            label1.ForeColor = minhaCor;
            label2.ForeColor = minhaCor;
            label3.ForeColor = minhaCor;
            label4.ForeColor = minhaCor;
            label5.ForeColor = minhaCor;
            label6.ForeColor = minhaCor;
            label7.ForeColor = minhaCor;
            label8.ForeColor = minhaCor;
            label9.ForeColor = minhaCor;
            label10.ForeColor = minhaCor;
            label11.ForeColor = minhaCor;
            label12.ForeColor = minhaCor;
            label13.ForeColor = minhaCor;
            label14.ForeColor = minhaCor;
            label15.ForeColor = minhaCor;
            label16.ForeColor = minhaCor;
            label17.ForeColor = minhaCor;
            label18.ForeColor = minhaCor;
            label19.ForeColor = minhaCor;
            label20.ForeColor = minhaCor;
            label21.ForeColor = minhaCor;
            label22.ForeColor = minhaCor;
            label23.ForeColor = minhaCor;
            label24.ForeColor = minhaCor;
            label25.ForeColor = minhaCor;
            label26.ForeColor = minhaCor;
            label27.ForeColor = minhaCor;
            label28.ForeColor = minhaCor;
            label29.ForeColor = minhaCor;
            label30.ForeColor = minhaCor;
            label31.ForeColor = minhaCor;
            label32.ForeColor = minhaCor;
            label33.ForeColor = minhaCor;
            label34.ForeColor = minhaCor;
            label35.ForeColor = minhaCor;
            label36.ForeColor = minhaCor;
            label37.ForeColor = minhaCor;
            label38.ForeColor = minhaCor;
            label39.ForeColor = minhaCor;
            label40.ForeColor = minhaCor;
            label41.ForeColor = minhaCor;
        }

        private void pbProximo_Click(object sender, EventArgs e)
        {
            if (mes == 12)
            {
                mes = 1;
                ano++;
            }
            else
            {
                mes++;
            }
            try { PreencherCalendario(mes, ano); }
            catch { PreencherCalendario(mes, ano); }
            FormatarCorDaFonte();
        }

        private void pbAnterior_Click(object sender, EventArgs e)
        {
            if (mes == 1)
            {
                mes = 12;
                ano--;
            }
            else
            {
                mes--;
            }
            try { PreencherCalendario(mes, ano); }
            catch { PreencherCalendario(mes, ano); }
            FormatarCorDaFonte();
        }

        private void timerTempo_Tick(object sender, EventArgs e)
        {
            string hora = DateTime.Now.ToLongTimeString();
            string data = DateTime.Now.ToLongDateString();
            labelHora.Text = hora;
            labelData.Text = data;

            labelHora.Left = panelLinha.Left + ((panelLinha.Width - labelHora.Width) / 2);
            if (!centralizar)
            {
                labelData.Left = panelLinha.Left + ((panelLinha.Width - labelData.Width) / 2);
                centralizar = true;
            }
        }

        #region Sombra do Painel Notificações

        List<Control> shadowControls = new List<Control>();
        Bitmap shadowBmp = null;
        int[] informacoes_sombra = new int[2];
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
        private void formTelaInicialPrincipal_Paint(object sender, PaintEventArgs e)
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

        #endregion

        private void buttonReclamacoes_Click(object sender, EventArgs e)
        {
            formTelaInicialPrincipalAssuntos sugestoes = new formTelaInicialPrincipalAssuntos();
            sugestoes.ShowDialog();
        }

        private void buttonEquipar_Click(object sender, EventArgs e)
        {
            formProdutosAlmoxarifadoApetrechos apetrechos = new formProdutosAlmoxarifadoApetrechos(true);
            apetrechos.ShowDialog();
        }

        private void buttonEstoque_Click(object sender, EventArgs e)
        {
            formTelaInicialPrincipalEstoque estoque = new formTelaInicialPrincipalEstoque();
            estoque.ShowDialog();
        }

        private void panelAtividades_SizeChanged(object sender, EventArgs e)
        {
            labelAtividades.Left = (panelAtividades.Width / 2) - (labelAtividades.Width / 2);
        }

        private void buttonGerente_Click(object sender, EventArgs e)
        {
            formTelaInicialPrincipalGerente gerente = new formTelaInicialPrincipalGerente();
            gerente.ShowDialog();
        }

        private void buttonInstrucoes_Click(object sender, EventArgs e)
        {
            formTelaInicialPrincipalInstrucoes instrucoes = new formTelaInicialPrincipalInstrucoes();
            instrucoes.ShowDialog();
        }

        private void buttonAtividades_Click(object sender, EventArgs e)
        {
            formTelaInicialPrincipalAtividades atividades = new formTelaInicialPrincipalAtividades();
            atividades.ShowDialog();
        }

        private void buttonSolucoes_Click(object sender, EventArgs e)
        {

        }

        private void buttonAfazeres_Click(object sender, EventArgs e)
        {
            formGestaoAfazeres afazeres = new formGestaoAfazeres();
            afazeres.ShowDialog();
        }
    }
}
