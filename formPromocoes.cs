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
    public partial class formPromocoes : Form
    {
        int mes;
        int ano;
        public formPromocoes()
        {
            InitializeComponent();
        }

        private void formPromocoes_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            mes = now.Month;
            ano = now.Year;
            PreencherCalendario(mes, ano);
        }
        #region Calendario
        public void PreencherCalendario(int mes, int ano)
        {
            ComandosSQL comando = new ComandosSQL();

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

            DateTime promocao = new DateTime();
            try
            {
                promocao = new DateTime(ano, mes, i);
                textBox0.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 1);
                textBox1.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 2);
                textBox2.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 3);
                textBox3.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 4);
                textBox4.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 5);
                textBox5.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            }
            catch { }
            promocao = new DateTime(ano, mes, i + 6);
            textBox6.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 7);
            textBox7.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 8);
            textBox8.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 9);
            textBox9.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 10);
            textBox10.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 11);
            textBox11.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 12);
            textBox12.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 13);
            textBox13.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 14);
            textBox14.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 15);
            textBox15.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 16);
            textBox16.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 17);
            textBox17.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 18);
            textBox18.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 19);
            textBox19.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 20);
            textBox20.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 21);
            textBox21.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 22);
            textBox22.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 23);
            textBox23.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 24);
            textBox24.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 25);
            textBox25.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 26);
            textBox26.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 27);
            textBox27.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            try
            {
                promocao = new DateTime(ano, mes, i + 28);
                textBox28.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 29);
                textBox29.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 30);
                textBox30.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 31);
                textBox31.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 32);
                textBox32.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 33);
                textBox33.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 34);
                textBox34.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 35);
                textBox35.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 36);
                textBox36.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 37);
                textBox37.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 38);
                textBox38.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 39);
                textBox39.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 40);
                textBox40.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 41);
                textBox41.Text = comando.TrazerPromocoesPelaData(promocao.ToString());
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
            FormatarCorDaFonte();
            PreencherCalendario(mes, ano);
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
            FormatarCorDaFonte();
            PreencherCalendario(mes, ano);
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
        #endregion
        private void buttonNovaPromocao_Click(object sender, EventArgs e)
        {
            formPromocoesCriarPromocao criarPromocao = new formPromocoesCriarPromocao();
            criarPromocao.ShowDialog();
            PreencherCalendario(mes,ano);
        }
        private void buttonQueima_Click(object sender, EventArgs e)
        {
            formPromocoesCriarQueima queima = new formPromocoesCriarQueima();
            queima.ShowDialog();
        }
        private void buttonTabelas_Click(object sender, EventArgs e)
        {
            formPromocoesTabelas desconto = new formPromocoesTabelas();
            desconto.ShowDialog();
        }

        private void buttonCombos_Click(object sender, EventArgs e)
        {
            formPromocoesCombos combos = new formPromocoesCombos();
            combos.ShowDialog();
        }
    }
}
