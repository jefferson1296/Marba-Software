using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarbaSoftware
{
    public partial class formFinanceiroSimuladorCalendario : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int mes;
        int ano;
        decimal saldo_total;

        List<Simulador> simulacoes = new List<Simulador>();

        public formFinanceiroSimuladorCalendario()
        {
            InitializeComponent();
        }

        private void formSimulador_Load(object sender, EventArgs e)
        {
            DateTime hoje = DateTime.Now.Date;
            mes = hoje.Month;
            ano = hoje.Year;

            saldo_total = comandos.TrazerSaldo(hoje);
            PreencherDiasDaTabela(hoje);
            PreencherCalendario(mes, ano, hoje);
            FormatarCorDaFonte();
            DestacarSaldo();
        }

        private void PreencherDiasDaTabela(DateTime hoje)
        {
            CultureInfo cultura = new CultureInfo("pt-BR");
            DateTimeFormatInfo formato = cultura.DateTimeFormat;

            decimal saldo_total = this.saldo_total;

            DateTime dia_final = DateTime.Now.AddMonths(3).Date;
            int dias = Convert.ToInt32(dia_final.Subtract(hoje).TotalDays);

            for (int i = 0; i < dias;i++)
            {
                DateTime dia = hoje.AddDays(i);
                string dia_da_semana = formato.GetDayName(dia.DayOfWeek).PrimeiraLetraMaiuscula();
                decimal despesas = comandos.PagamentosDoDia(dia);
                decimal receitas = comandos.ReceitasDoDia(dia_da_semana);
                decimal saldo_dia = receitas - despesas;
                saldo_total = saldo_total + saldo_dia;

                simulacoes.Add(new Simulador
                {
                    Dia = dia,
                    Dia_da_semana = dia_da_semana,
                    Despesas = despesas,
                    Receitas = receitas,
                    Saldo_Dia = saldo_dia,
                    Saldo_Total = saldo_total
                });
            }
        }

        #region Calendario

        public void PreencherCalendario(int mes, int ano, DateTime hoje)
        {
            DateTime data = new DateTime(ano, mes, 1);
            CultureInfo cultura = new CultureInfo("pt-BR");
            DateTimeFormatInfo formato = cultura.DateTimeFormat;

            string mes_ = data.ToString(@"MMMM");
            string Mes = mes_.PrimeiraLetraMaiuscula();
            labelMes.Text = Mes + " / " + Convert.ToString(ano);

            #region Definindo o 1° dia do mês e todo o restante

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

            #endregion
            #region Atribuindo o saldo de cada dia, desde que seja maior do que o dia atual

            DateTime data_simulacao = new DateTime();
            try
            {
                data_simulacao = new DateTime(ano, mes, i);

            }
            catch { }

            string despesas = "Despesas";
            string receitas = "Receitas";
            string saldo_dia = "Saldo/dia";
            string saldo = "Saldo";

            try
            {
                data_simulacao = new DateTime(ano, mes, i);

                if (data_simulacao < hoje)
                {
                    dataGridView0.Visible = false;
                }
                else
                {
                    dataGridView0.Rows.Clear();
                    dataGridView0.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView0.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView0.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView0.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
                }
            }
            catch { }
            try
            {
                if (data_simulacao < hoje)
                {
                    dataGridView1.Visible = false;
                }
                else
                {
                    data_simulacao = new DateTime(ano, mes, i + 1);
                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView1.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView1.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView1.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
                }
            }
            catch { }
            try
            {
                if (data_simulacao < hoje)
                {
                    dataGridView2.Visible = false;
                }
                else
                {
                    data_simulacao = new DateTime(ano, mes, i + 2);
                    dataGridView2.Rows.Clear();
                    dataGridView2.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView2.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView2.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView2.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
                }
            }
            catch { }
            try
            {
                if (data_simulacao < hoje)
                {
                    dataGridView3.Visible = false;
                }
                else
                {
                    data_simulacao = new DateTime(ano, mes, i + 3);
                    dataGridView3.Rows.Clear();
                    dataGridView3.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView3.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView3.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView3.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
                }
            }
            catch { }
            try
            {
                if (data_simulacao < hoje)
                {
                    dataGridView4.Visible = false;
                }
                else
                {
                    data_simulacao = new DateTime(ano, mes, i + 4);
                    dataGridView4.Rows.Clear();
                    dataGridView4.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView4.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView4.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView4.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
                }
            }
            catch { }
            try
            {
                if (data_simulacao < hoje)
                {
                    dataGridView5.Visible = false;
                }
                else
                {
                    data_simulacao = new DateTime(ano, mes, i + 5);
                    dataGridView5.Rows.Clear();
                    dataGridView5.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView5.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView5.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView5.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
                }
            }
            catch { }
            data_simulacao = new DateTime(ano, mes, i + 6);

            if (data_simulacao < hoje)
            {
                dataGridView6.Visible = false;
            }
            else
            {
                dataGridView6.Rows.Clear();
                dataGridView6.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView6.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView6.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView6.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
            }
            data_simulacao = new DateTime(ano, mes, i + 7);
            if (data_simulacao < hoje)
            {
                dataGridView7.Visible = false;
            }
            else
            {
                dataGridView7.Rows.Clear();
                dataGridView7.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView7.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView7.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView7.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
            }
            data_simulacao = new DateTime(ano, mes, i + 8);
            if (data_simulacao < hoje)
            {
                dataGridView8.Visible = false;
            }
            else
            {
                dataGridView8.Rows.Clear();
                dataGridView8.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView8.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView8.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView8.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
            }
            data_simulacao = new DateTime(ano, mes, i + 9);
            if (data_simulacao < hoje)
            {
                dataGridView9.Visible = false;
            }
            else
            {
                dataGridView9.Rows.Clear();
                dataGridView9.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView9.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView9.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView9.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C")); 
            }
            data_simulacao = new DateTime(ano, mes, i + 10);
            if (data_simulacao < hoje)
            {
                dataGridView10.Visible = false;
            }
            else
            {
                dataGridView10.Rows.Clear();
                dataGridView10.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView10.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView10.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView10.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
            }
            data_simulacao = new DateTime(ano, mes, i + 11);
            if (data_simulacao < hoje)
            {
                dataGridView11.Visible = false;
            }
            else
            {
                dataGridView11.Rows.Clear();
                dataGridView11.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView11.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView11.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView11.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
            }
            data_simulacao = new DateTime(ano, mes, i + 12);
            if (data_simulacao < hoje)
            {
                dataGridView12.Visible = false;
            }
            else
            {
                dataGridView12.Rows.Clear();
                dataGridView12.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView12.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView12.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView12.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
            }
            data_simulacao = new DateTime(ano, mes, i + 13);
            if (data_simulacao < hoje)
            {
                dataGridView13.Visible = false;
            }
            else
            {
                dataGridView13.Rows.Clear();
                dataGridView13.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView13.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView13.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView13.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
            }
            data_simulacao = new DateTime(ano, mes, i + 14);
            if (data_simulacao < hoje)
            {
                dataGridView14.Visible = false;
            }
            else
            {
                dataGridView14.Rows.Clear();
                dataGridView14.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView14.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView14.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView14.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
            }
            data_simulacao = new DateTime(ano, mes, i + 15);
            if (data_simulacao < hoje)
            {
                dataGridView15.Visible = false;
            }
            else
            {
                dataGridView15.Rows.Clear();
                dataGridView15.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView15.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView15.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView15.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
            }
            data_simulacao = new DateTime(ano, mes, i + 16);
            if (data_simulacao < hoje)
            {
                dataGridView16.Visible = false;
            }
            else
            {
                dataGridView16.Rows.Clear();
                dataGridView16.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView16.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView16.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView16.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
            }
            data_simulacao = new DateTime(ano, mes, i + 17);
            if (data_simulacao < hoje)
            {
                dataGridView17.Visible = false;
            }
            else
            {
                dataGridView17.Rows.Clear();
                dataGridView17.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView17.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView17.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView17.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
            }
            data_simulacao = new DateTime(ano, mes, i + 18);
            if (data_simulacao < hoje)
            {
                dataGridView18.Visible = false;
            }
            else
            {
                dataGridView18.Rows.Clear();
                dataGridView18.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView18.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView18.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView18.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
                data_simulacao = new DateTime(ano, mes, i + 19);
            }
            dataGridView19.Rows.Clear();
            if (data_simulacao < hoje)
            {
                dataGridView19.Visible = false;
            }
            else
            {
                dataGridView19.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView19.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView19.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView19.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
            }
            data_simulacao = new DateTime(ano, mes, i + 20);
            if (data_simulacao < hoje)
            {
                dataGridView20.Visible = false;
            }
            else
            {
                dataGridView20.Rows.Clear();
                dataGridView20.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView20.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView20.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView20.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
            }
            data_simulacao = new DateTime(ano, mes, i + 21);
            if (data_simulacao < hoje)
            {
                dataGridView21.Visible = false;
            }
            else
            {
                dataGridView21.Rows.Clear();
                dataGridView21.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView21.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView21.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView21.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
            }
            data_simulacao = new DateTime(ano, mes, i + 22);
            if (data_simulacao < hoje)
            {
                dataGridView22.Visible = false;
            }
            else
            {
                dataGridView22.Rows.Clear();
                dataGridView22.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView22.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView22.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView22.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
            }
            data_simulacao = new DateTime(ano, mes, i + 23);
            if (data_simulacao < hoje)
            {
                dataGridView23.Visible = false;
            }
            else
            {
                dataGridView23.Rows.Clear();
                dataGridView23.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView23.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView23.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView23.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
            }
            data_simulacao = new DateTime(ano, mes, i + 24);
            if (data_simulacao < hoje)
            {
                dataGridView24.Visible = false;
            }
            else
            {
                dataGridView24.Rows.Clear();
                dataGridView24.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView24.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView24.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView24.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
            }
            data_simulacao = new DateTime(ano, mes, i + 25);
            if (data_simulacao < hoje)
            {
                dataGridView25.Visible = false;
            }
            else
            {
                dataGridView25.Rows.Clear();
                dataGridView25.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView25.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView25.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView25.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
            }
            data_simulacao = new DateTime(ano, mes, i + 26);
            if (data_simulacao < hoje)
            {
                dataGridView26.Visible = false;
            }
            else
            {
                dataGridView26.Rows.Clear();
                dataGridView26.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView26.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView26.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView26.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
            }
            data_simulacao = new DateTime(ano, mes, i + 27);
            if (data_simulacao < hoje)
            {
                dataGridView27.Visible = false;
            }
            else
            {
                dataGridView27.Rows.Clear();
                dataGridView27.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                dataGridView27.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                dataGridView27.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                dataGridView27.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
            }
            try
            {
                data_simulacao = new DateTime(ano, mes, i + 28);
                if (data_simulacao < hoje)
                {
                    dataGridView28.Visible = false;
                }
                else
                {
                    dataGridView28.Rows.Clear();
                    dataGridView28.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView28.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView28.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView28.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
                }
            }
            catch { }
            try
            {
                data_simulacao = new DateTime(ano, mes, i + 29);
                if (data_simulacao < hoje)
                {
                    dataGridView29.Visible = false;
                }
                else
                {
                    dataGridView29.Rows.Clear();
                    dataGridView29.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView29.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView29.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView29.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
                }
            }
            catch { }
            try
            {
                data_simulacao = new DateTime(ano, mes, i + 30);
                if (data_simulacao < hoje)
                {
                    dataGridView30.Visible = false;
                }
                else
                {
                    dataGridView30.Rows.Clear();
                    dataGridView30.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView30.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView30.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView30.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
                }
            }
            catch { }
            try
            {
                data_simulacao = new DateTime(ano, mes, i + 31);
                if (data_simulacao < hoje)
                {
                    dataGridView31.Visible = false;
                }
                else
                {
                    dataGridView31.Rows.Clear();
                    dataGridView31.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView31.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView31.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView31.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
                }
            }
            catch { }
            try
            {
                data_simulacao = new DateTime(ano, mes, i + 32);
                if (data_simulacao < hoje)
                {
                    dataGridView32.Visible = false;
                }
                else
                {
                    dataGridView32.Rows.Clear();
                    dataGridView32.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView32.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView32.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView32.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
                }
            }
            catch { }
            try
            {
                data_simulacao = new DateTime(ano, mes, i + 33);
                if (data_simulacao < hoje)
                {
                    dataGridView33.Visible = false;
                }
                else
                {
                    dataGridView33.Rows.Clear();
                    dataGridView33.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView33.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView33.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView33.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
                }
            }
            catch { }
            try
            {
                data_simulacao = new DateTime(ano, mes, i + 34);
                if (data_simulacao < hoje)
                {
                    dataGridView34.Visible = false;
                }
                else
                {
                    dataGridView34.Rows.Clear();
                    dataGridView34.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView34.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView34.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView34.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
                }
            }
            catch { }
            try
            {
                data_simulacao = new DateTime(ano, mes, i + 35);
                if (data_simulacao < hoje)
                {
                    dataGridView35.Visible = false;
                }
                else
                {
                    dataGridView35.Rows.Clear();
                    dataGridView35.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView35.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView35.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView35.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
                }
            }
            catch { }
            try
            {
                data_simulacao = new DateTime(ano, mes, i + 36);
                if (data_simulacao < hoje)
                {
                    dataGridView36.Visible = false;
                }
                else
                {
                    dataGridView36.Rows.Clear();
                    dataGridView36.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView36.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView36.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView36.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
                }
            }
            catch { }
            try
            {
                data_simulacao = new DateTime(ano, mes, i + 37);
                if (data_simulacao < hoje)
                {
                    dataGridView37.Visible = false;
                }
                else
                {
                    dataGridView37.Rows.Clear();
                    dataGridView37.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView37.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView37.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView37.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
                }
            }
            catch { }
            try
            {
                data_simulacao = new DateTime(ano, mes, i + 38);
                if (data_simulacao < hoje)
                {
                    dataGridView38.Visible = false;
                }
                else
                {
                    dataGridView38.Rows.Clear();
                    dataGridView38.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView38.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView38.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView38.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
                }
            }
            catch { }
            try
            {
                data_simulacao = new DateTime(ano, mes, i + 39);
                if (data_simulacao < hoje)
                {
                    dataGridView39.Visible = false;
                }
                else
                {
                    dataGridView39.Rows.Clear();
                    dataGridView39.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView39.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView39.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView39.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
                }
            }
            catch { }
            try
            {
                data_simulacao = new DateTime(ano, mes, i + 40);
                if (data_simulacao < hoje)
                {
                    dataGridView40.Visible = false;
                }
                else
                {
                    dataGridView40.Rows.Clear();
                    dataGridView40.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView40.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView40.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView40.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
                }
            }
            catch { }
            try
            {
                data_simulacao = new DateTime(ano, mes, i + 41);
                if (data_simulacao < hoje)
                {
                    dataGridView41.Visible = false;
                }
                else
                {
                    dataGridView41.Rows.Clear();
                    dataGridView41.Rows.Add(despesas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView41.Rows.Add(receitas, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView41.Rows.Add(saldo_dia, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView41.Rows.Add(saldo, simulacoes.Where(x => x.Dia == data_simulacao).Select(x => x.Saldo_Total).FirstOrDefault().ToString("C"));
                }
            }
            catch { }

            #endregion

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

                    //REGISTROS DO PRÓXIMO MÊS

                    DateTime proximo_dia_1 = data.AddMonths(1);

                    dataGridView28.Rows.Clear();
                    dataGridView28.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView28.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView28.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView28.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView29.Rows.Clear();
                    dataGridView29.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(1)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView29.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(1)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView29.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(1)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView29.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(1)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView30.Rows.Clear();
                    dataGridView30.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(2)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView30.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(2)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView30.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(2)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView30.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(2)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView31.Rows.Clear();
                    dataGridView31.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(3)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView31.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(3)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView31.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(3)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView31.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(3)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView32.Rows.Clear();
                    dataGridView32.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(4)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView32.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(4)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView32.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(4)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView32.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(4)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView33.Rows.Clear();
                    dataGridView33.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(5)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView33.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(5)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView33.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(5)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView33.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(5)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView34.Rows.Clear();
                    dataGridView34.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(6)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView34.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(6)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView34.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(6)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView34.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(6)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView35.Rows.Clear();
                    dataGridView35.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(7)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView35.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(7)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView35.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(7)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView35.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(7)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView36.Rows.Clear();
                    dataGridView36.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(8)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView36.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(8)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView36.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(8)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView36.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(8)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView37.Rows.Clear();
                    dataGridView37.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(9)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView37.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(9)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView37.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(9)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView37.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(9)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView38.Rows.Clear();
                    dataGridView38.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(10)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView38.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(10)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView38.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(10)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView38.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(10)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView39.Rows.Clear();
                    dataGridView39.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(11)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView39.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(11)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView39.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(11)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView39.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(11)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView40.Rows.Clear();
                    dataGridView40.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(12)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView40.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(12)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView40.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(12)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView40.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(12)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView41.Rows.Clear();
                    dataGridView41.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(13)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView41.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(13)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView41.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(13)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView41.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(13)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));
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

                    DateTime proximo_dia_1 = data.AddMonths(1);

                    dataGridView29.Rows.Clear();
                    dataGridView29.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView29.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView29.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView29.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView30.Rows.Clear();
                    dataGridView30.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(1)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView30.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(1)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView30.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(1)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView30.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(1)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView31.Rows.Clear();
                    dataGridView31.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(2)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView31.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(2)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView31.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(2)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView31.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(2)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView32.Rows.Clear();
                    dataGridView32.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(3)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView32.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(3)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView32.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(3)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView32.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(3)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView33.Rows.Clear();
                    dataGridView33.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(4)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView33.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(4)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView33.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(4)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView33.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(4)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView34.Rows.Clear();
                    dataGridView34.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(5)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView34.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(5)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView34.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(5)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView34.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(5)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView35.Rows.Clear();
                    dataGridView35.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(6)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView35.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(6)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView35.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(6)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView35.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(6)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView36.Rows.Clear();
                    dataGridView36.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(7)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView36.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(7)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView36.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(7)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView36.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(7)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView37.Rows.Clear();
                    dataGridView37.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(8)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView37.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(8)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView37.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(8)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView37.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(8)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView38.Rows.Clear();
                    dataGridView38.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(9)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView38.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(9)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView38.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(9)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView38.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(9)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView39.Rows.Clear();
                    dataGridView39.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(10)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView39.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(10)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView39.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(10)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView39.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(10)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView40.Rows.Clear();
                    dataGridView40.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(11)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView40.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(11)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView40.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(11)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView40.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(11)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView41.Rows.Clear();
                    dataGridView41.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(12)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView41.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(12)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView41.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(12)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView41.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(12)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));
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

                    DateTime proximo_dia_1 = data.AddMonths(1);

                    dataGridView30.Rows.Clear();
                    dataGridView30.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView30.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView30.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView30.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView31.Rows.Clear();
                    dataGridView31.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(1)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView31.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(1)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView31.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(1)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView31.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(1)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView32.Rows.Clear();
                    dataGridView32.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(2)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView32.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(2)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView32.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(2)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView32.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(2)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView33.Rows.Clear();
                    dataGridView33.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(3)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView33.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(3)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView33.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(3)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView33.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(3)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView34.Rows.Clear();
                    dataGridView34.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(4)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView34.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(4)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView34.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(4)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView34.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(4)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView35.Rows.Clear();
                    dataGridView35.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(5)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView35.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(5)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView35.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(5)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView35.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(5)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView36.Rows.Clear();
                    dataGridView36.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(6)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView36.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(6)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView36.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(6)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView36.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(6)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView37.Rows.Clear();
                    dataGridView37.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(7)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView37.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(7)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView37.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(7)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView37.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(7)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView38.Rows.Clear();
                    dataGridView38.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(8)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView38.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(8)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView38.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(8)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView38.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(8)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView39.Rows.Clear();
                    dataGridView39.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(9)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView39.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(9)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView39.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(9)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView39.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(9)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView40.Rows.Clear();
                    dataGridView40.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(10)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView40.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(10)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView40.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(10)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView40.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(10)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView41.Rows.Clear();
                    dataGridView41.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(11)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView41.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(11)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView41.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(11)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView41.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(11)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));
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

                    DateTime proximo_dia_1 = data.AddMonths(1);

                    dataGridView31.Rows.Clear();
                    dataGridView31.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView31.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView31.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView31.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView32.Rows.Clear();
                    dataGridView32.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(1)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView32.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(1)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView32.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(1)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView32.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(1)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView33.Rows.Clear();
                    dataGridView33.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(2)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView33.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(2)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView33.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(2)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView33.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(2)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView34.Rows.Clear();
                    dataGridView34.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(3)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView34.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(3)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView34.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(3)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView34.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(3)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView35.Rows.Clear();
                    dataGridView35.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(4)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView35.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(4)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView35.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(4)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView35.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(4)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView36.Rows.Clear();
                    dataGridView36.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(5)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView36.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(5)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView36.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(5)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView36.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(5)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView37.Rows.Clear();
                    dataGridView37.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(6)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView37.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(6)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView37.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(6)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView37.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(6)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView38.Rows.Clear();
                    dataGridView38.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(7)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView38.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(7)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView38.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(7)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView38.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(7)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView39.Rows.Clear();
                    dataGridView39.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(8)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView39.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(8)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView39.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(8)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView39.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(8)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView40.Rows.Clear();
                    dataGridView40.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(9)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView40.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(9)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView40.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(9)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView40.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(9)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView41.Rows.Clear();
                    dataGridView41.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(10)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView41.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(10)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView41.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(10)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView41.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(10)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));
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

                    DateTime proximo_dia_1 = data.AddMonths(1);

                    dataGridView31.Rows.Clear();
                    dataGridView31.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView31.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView31.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView31.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView32.Rows.Clear();
                    dataGridView32.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(1)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView32.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(1)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView32.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(1)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView32.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(1)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView33.Rows.Clear();
                    dataGridView33.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(2)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView33.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(2)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView33.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(2)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView33.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(2)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView34.Rows.Clear();
                    dataGridView34.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(3)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView34.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(3)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView34.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(3)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView34.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(3)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView35.Rows.Clear();
                    dataGridView35.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(4)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView35.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(4)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView35.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(4)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView35.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(4)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView36.Rows.Clear();
                    dataGridView36.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(5)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView36.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(5)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView36.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(5)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView36.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(5)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView37.Rows.Clear();
                    dataGridView37.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(6)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView37.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(6)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView37.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(6)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView37.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(6)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView38.Rows.Clear();
                    dataGridView38.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(7)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView38.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(7)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView38.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(7)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView38.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(7)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView39.Rows.Clear();
                    dataGridView39.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(8)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView39.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(8)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView39.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(8)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView39.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(8)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView40.Rows.Clear();
                    dataGridView40.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(9)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView40.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(9)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView40.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(9)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView40.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(9)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));

                    dataGridView41.Rows.Clear();
                    dataGridView41.Rows.Add(despesas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(10)).Select(z => z.Despesas).FirstOrDefault().ToString("C"));
                    dataGridView41.Rows.Add(receitas, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(10)).Select(z => z.Receitas).FirstOrDefault().ToString("C"));
                    dataGridView41.Rows.Add(saldo_dia, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(10)).Select(z => z.Saldo_Dia).FirstOrDefault().ToString("C"));
                    dataGridView41.Rows.Add(saldo, simulacoes.Where(z => z.Dia == proximo_dia_1.AddDays(10)).Select(z => z.Saldo_Total).FirstOrDefault().ToString("C"));
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
                    label35.Text = (x + 1).ToString();
                    label36.Text = (x + 2).ToString();
                    label37.Text = (x + 3).ToString();
                    label38.Text = (x + 4).ToString();
                    label39.Text = (x + 5).ToString();
                    label40.Text = (x + 6).ToString();
                    label41.Text = (x + 7).ToString();
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
        private void DestacarSaldo()
        {
            Font minhafonte = new Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point);

            if (dataGridView0.Visible)
            {
                foreach (DataGridViewRow row in dataGridView0.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView0.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView0.Rows[row.Index].Cells[1].Value.ToString();

                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView0.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView0.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView0.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView0.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView1.Visible)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView1.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView1.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView1.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView1.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView1.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView1.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView2.Visible)
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView2.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView2.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView2.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView2.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView2.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView2.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView3.Visible)
            {
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView3.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView3.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView3.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView3.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView3.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView3.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView4.Visible)
            {
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView4.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView4.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView4.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView4.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView4.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView4.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView5.Visible)
            {
                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView5.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView5.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView5.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView5.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView5.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView5.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView6.Visible)
            {
                foreach (DataGridViewRow row in dataGridView6.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView6.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView6.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView6.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView6.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView6.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView6.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView7.Visible)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView7.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView7.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView7.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView7.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView7.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView7.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView8.Visible)
            {
                foreach (DataGridViewRow row in dataGridView8.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView8.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView8.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView8.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView8.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView8.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView8.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView9.Visible)
            {
                foreach (DataGridViewRow row in dataGridView9.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView9.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView9.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView9.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView9.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView9.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView9.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView10.Visible)
            {
                foreach (DataGridViewRow row in dataGridView10.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView10.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView10.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView10.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView10.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView10.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView10.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView11.Visible)
            {
                foreach (DataGridViewRow row in dataGridView11.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView11.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView11.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView11.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView11.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView11.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView11.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView12.Visible)
            {
                foreach (DataGridViewRow row in dataGridView12.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView12.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView12.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView12.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView12.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView12.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView12.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }
            if (dataGridView13.Visible)
            {
                foreach (DataGridViewRow row in dataGridView13.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView13.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView13.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView13.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView13.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView13.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView13.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView14.Visible)
            {
                foreach (DataGridViewRow row in dataGridView14.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView14.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView14.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView14.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView14.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView14.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView14.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView15.Visible)
            {
                foreach (DataGridViewRow row in dataGridView15.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView15.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView15.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView15.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView15.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView15.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView15.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView16.Visible)
            {
                foreach (DataGridViewRow row in dataGridView16.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView16.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView16.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView16.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView16.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView16.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView16.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }
            if (dataGridView17.Visible)
            {
                foreach (DataGridViewRow row in dataGridView17.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView17.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView17.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView17.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView17.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView17.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView17.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView18.Visible)
            {
                foreach (DataGridViewRow row in dataGridView18.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView18.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView18.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView18.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView18.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView18.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView18.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView19.Visible)
            {
                foreach (DataGridViewRow row in dataGridView19.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView19.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView19.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView19.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView19.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView19.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView19.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView20.Visible)
            {
                foreach (DataGridViewRow row in dataGridView20.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView20.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView20.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView20.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView20.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView20.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView20.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }
            if (dataGridView21.Visible)
            {
                foreach (DataGridViewRow row in dataGridView21.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView21.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView21.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView21.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView21.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView21.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView21.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView22.Visible)
            {
                foreach (DataGridViewRow row in dataGridView22.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView22.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView22.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView22.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView22.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView22.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView22.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView23.Visible)
            {
                foreach (DataGridViewRow row in dataGridView23.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView23.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView23.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView23.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView23.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView23.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView23.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView24.Visible)
            {
                foreach (DataGridViewRow row in dataGridView24.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView24.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView24.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView24.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView24.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView24.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView24.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }
            if (dataGridView25.Visible)
            {
                foreach (DataGridViewRow row in dataGridView25.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView25.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView25.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView25.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView25.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView25.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView25.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView26.Visible)
            {
                foreach (DataGridViewRow row in dataGridView26.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView26.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView26.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView26.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView26.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView26.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView26.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView27.Visible)
            {
                foreach (DataGridViewRow row in dataGridView27.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView27.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView27.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView27.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView27.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView27.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView27.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView28.Visible)
            {
                foreach (DataGridViewRow row in dataGridView28.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView28.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView28.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView28.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView28.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView28.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView28.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }
            if (dataGridView29.Visible)
            {
                foreach (DataGridViewRow row in dataGridView29.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView29.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView29.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView29.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView29.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView29.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView29.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView30.Visible)
            {
                foreach (DataGridViewRow row in dataGridView30.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView30.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView30.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView30.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView30.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView30.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView30.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView31.Visible)
            {
                foreach (DataGridViewRow row in dataGridView31.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView31.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView31.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView31.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView31.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView31.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView31.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView32.Visible)
            {
                foreach (DataGridViewRow row in dataGridView32.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView32.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView32.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView32.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView32.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView32.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView32.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }
            if (dataGridView33.Visible)
            {
                foreach (DataGridViewRow row in dataGridView33.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView33.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView33.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView33.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView33.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView33.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView33.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView34.Visible)
            {
                foreach (DataGridViewRow row in dataGridView34.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView34.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView34.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView34.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView34.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView34.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView34.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView35.Visible)
            {
                foreach (DataGridViewRow row in dataGridView35.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView35.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView35.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView35.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView35.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView35.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView35.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView36.Visible)
            {
                foreach (DataGridViewRow row in dataGridView36.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView36.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView36.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView36.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView36.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView36.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView36.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }
            if (dataGridView37.Visible)
            {
                foreach (DataGridViewRow row in dataGridView37.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView37.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView37.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView37.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView37.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView37.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView37.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView38.Visible)
            {
                foreach (DataGridViewRow row in dataGridView38.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView38.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView38.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView38.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView38.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView38.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView38.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView39.Visible)
            {
                foreach (DataGridViewRow row in dataGridView39.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView39.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView39.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView39.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView39.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView39.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView39.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView40.Visible)
            {
                foreach (DataGridViewRow row in dataGridView40.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView40.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView40.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView40.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView40.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView40.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView40.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }

            if (dataGridView41.Visible)
            {
                foreach (DataGridViewRow row in dataGridView41.Rows)
                {
                    if (row.Index == 3)
                    {
                        DataGridViewRow linhaestilizada = dataGridView41.Rows[row.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        string valor = dataGridView41.Rows[row.Index].Cells[1].Value.ToString();


                        if (valor.Substring(0, 1) == "-")
                        {
                            dataGridView41.Rows[row.Index].Cells[1].Style.ForeColor = Color.DarkRed;
                            dataGridView41.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.DarkRed;
                        }
                        else if (valor.Substring(0, 2) == "R$" && valor != "R$0,00")
                        {
                            dataGridView41.Rows[row.Index].Cells[1].Style.ForeColor = Color.Green;
                            dataGridView41.Rows[row.Index].Cells[1].Style.SelectionForeColor = Color.Green;
                        }
                    }
                }
            }
        }

        #endregion

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

            DateTime hoje = DateTime.Now.Date;

            FormatarCorDaFonte();
            PreencherCalendario(mes, ano, hoje);
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

            DateTime hoje = DateTime.Now.Date;

            FormatarCorDaFonte();
            PreencherCalendario(mes, ano, hoje);
        }
    }
}
