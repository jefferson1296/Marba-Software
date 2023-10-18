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
    public partial class formFinanceiroPrevisoes : Form
    {
        int mes;
        int ano;
        public bool alteracao = false;
        List<Previsao> Previsoes = new List<Previsao>();
        ComandosSQL comando = new ComandosSQL();

        int id;
        string descricao;
        string data;

        public formFinanceiroPrevisoes()
        {
            InitializeComponent();
        }
        private void formFinanceiroPrevisoes_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
            DateTime now = DateTime.Now;
            mes = now.Month;
            ano = now.Year;
            FonteECorDeFundo();
            PreencherCalendario(mes, ano);
        }

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;

            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            Previsoes = comando.ListaDePrevisoesDePagamentos();
            dataGridViewLista.Rows.Clear();
            foreach (Previsao Previsao in Previsoes)
            {
                dataGridViewLista.Rows.Add(Previsao.ID_Previsao, Previsao.Descricao, Previsao.Valor.ToString("C"), Previsao.Data);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;



            Font minhafonte = new Font("Arial", 8, FontStyle.Strikeout, GraphicsUnit.Point);
            Font minhafonte2 = new Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point);

            foreach (DataGridViewRow Linha in dataGridViewLista.Rows)
            {
                int id = Convert.ToInt32(dataGridViewLista.Rows[Linha.Index].Cells[0].Value);
                string status = Previsoes.Where(x => x.ID_Previsao == id).Select(x => x.Status).FirstOrDefault();
                DateTime data = Convert.ToDateTime(Previsoes.Where(x => x.ID_Previsao == id).Select(x => x.Data).FirstOrDefault());

                if (data < DateTime.Now.Date && status == "Pendente")
                    status = "Atrasado";


                if (status == "Pago")
                {
                    DataGridViewRow linhaestilizada = dataGridViewLista.Rows[Linha.Index];
                    linhaestilizada.DefaultCellStyle.Font = minhafonte;
                    linhaestilizada.DefaultCellStyle.ForeColor = Color.DimGray;
                    linhaestilizada.DefaultCellStyle.SelectionForeColor = Color.DimGray;
                }
                else if (status == "Atrasado")
                {
                    DataGridViewRow linhaestilizada = dataGridViewLista.Rows[Linha.Index];
                    linhaestilizada.DefaultCellStyle.Font = minhafonte2;
                    linhaestilizada.DefaultCellStyle.ForeColor = Color.DarkRed;
                    linhaestilizada.DefaultCellStyle.SelectionForeColor = Color.DarkRed;
                }
            }

            int mes_atual = DateTime.Now.Month;
            decimal restante = Previsoes.Where(x => Convert.ToDateTime(x.Data).Month == mes_atual).Sum(x => x.Valor);
            decimal total = Previsoes.Sum(x => x.Valor);
            DateTime proximo = Previsoes.Min(x => Convert.ToDateTime(x.Data));
            DateTime ultimo = Previsoes.Max(x => Convert.ToDateTime(x.Data));

            textBoxRestante.Text = restante.ToString("C");
            textBoxTotal.Text = total.ToString("C");
            textBoxProximo.Text = proximo.ToShortDateString();
            textBoxUltimo.Text = ultimo.ToShortDateString();

            if (proximo.Date == DateTime.Now.Date) { textBoxProximo.Text = "Hoje"; }
            if (ultimo.Date == DateTime.Now.Date) { textBoxUltimo.Text = "Hoje"; }
        }

        #region Calendario
        private void FonteECorDeFundo()
        {
            int red = 75, green = 75, blue = 75; //Cores da fonte;
            Color Cor_do_Fundo = Color.WhiteSmoke;

            textBox0.BackColor = Cor_do_Fundo;
            textBox0.ForeColor = Color.FromArgb(red, green, blue);
            textBox1.BackColor = Cor_do_Fundo;
            textBox1.ForeColor = Color.FromArgb(red, green, blue);
            textBox2.BackColor = Cor_do_Fundo;
            textBox2.ForeColor = Color.FromArgb(red, green, blue);
            textBox3.BackColor = Cor_do_Fundo;
            textBox3.ForeColor = Color.FromArgb(red, green, blue);
            textBox4.BackColor = Cor_do_Fundo;
            textBox4.ForeColor = Color.FromArgb(red, green, blue);
            textBox5.BackColor = Cor_do_Fundo;
            textBox5.ForeColor = Color.FromArgb(red, green, blue);
            textBox6.BackColor = Cor_do_Fundo;
            textBox6.ForeColor = Color.FromArgb(red, green, blue);
            textBox7.BackColor = Cor_do_Fundo;
            textBox7.ForeColor = Color.FromArgb(red, green, blue);
            textBox8.BackColor = Cor_do_Fundo;
            textBox8.ForeColor = Color.FromArgb(red, green, blue);
            textBox9.BackColor = Cor_do_Fundo;
            textBox9.ForeColor = Color.FromArgb(red, green, blue);
            textBox10.BackColor =Cor_do_Fundo;
            textBox10.ForeColor =Color.FromArgb(red, green, blue);
            textBox11.BackColor =Cor_do_Fundo;
            textBox11.ForeColor =Color.FromArgb(red, green, blue);
            textBox12.BackColor =Cor_do_Fundo;
            textBox12.ForeColor =Color.FromArgb(red, green, blue);
            textBox13.BackColor =Cor_do_Fundo;
            textBox13.ForeColor =Color.FromArgb(red, green, blue);
            textBox14.BackColor =Cor_do_Fundo;
            textBox14.ForeColor =Color.FromArgb(red, green, blue);
            textBox15.BackColor =Cor_do_Fundo;
            textBox15.ForeColor =Color.FromArgb(red, green, blue);
            textBox16.BackColor =Cor_do_Fundo;
            textBox16.ForeColor =Color.FromArgb(red, green, blue);
            textBox17.BackColor =Cor_do_Fundo;
            textBox17.ForeColor =Color.FromArgb(red, green, blue);
            textBox18.BackColor = Cor_do_Fundo;
            textBox18.ForeColor =Color.FromArgb(red, green, blue);
            textBox19.BackColor =Cor_do_Fundo;
            textBox19.ForeColor =Color.FromArgb(red, green, blue);
            textBox20.BackColor =Cor_do_Fundo;
            textBox20.ForeColor =Color.FromArgb(red, green, blue);
            textBox21.BackColor =Cor_do_Fundo;
            textBox21.ForeColor =Color.FromArgb(red, green, blue);
            textBox22.BackColor =Cor_do_Fundo;
            textBox22.ForeColor =Color.FromArgb(red, green, blue);
            textBox23.BackColor =Cor_do_Fundo;
            textBox23.ForeColor =Color.FromArgb(red, green, blue);
            textBox24.BackColor =Cor_do_Fundo;
            textBox24.ForeColor =Color.FromArgb(red, green, blue);
            textBox25.BackColor =Cor_do_Fundo;
            textBox25.ForeColor =Color.FromArgb(red, green, blue);
            textBox26.BackColor =Cor_do_Fundo;
            textBox26.ForeColor =Color.FromArgb(red, green, blue);
            textBox27.BackColor = Cor_do_Fundo;
            textBox27.ForeColor =Color.FromArgb(red, green, blue);
            textBox28.BackColor =Cor_do_Fundo;
            textBox28.ForeColor =Color.FromArgb(red, green, blue);
            textBox29.BackColor =Cor_do_Fundo;
            textBox29.ForeColor =Color.FromArgb(red, green, blue);
            textBox30.BackColor =Cor_do_Fundo;
            textBox30.ForeColor =Color.FromArgb(red, green, blue);
            textBox31.BackColor =Cor_do_Fundo;
            textBox31.ForeColor =Color.FromArgb(red, green, blue);
            textBox32.BackColor =Cor_do_Fundo;
            textBox32.ForeColor =Color.FromArgb(red, green, blue);
            textBox33.BackColor =Cor_do_Fundo;
            textBox33.ForeColor =Color.FromArgb(red, green, blue);
            textBox34.BackColor =Cor_do_Fundo;
            textBox34.ForeColor =Color.FromArgb(red, green, blue);
            textBox35.BackColor =Cor_do_Fundo;
            textBox35.ForeColor =Color.FromArgb(red, green, blue);
            textBox36.BackColor = Cor_do_Fundo;
            textBox36.ForeColor =Color.FromArgb(red, green, blue);
            textBox37.BackColor =Cor_do_Fundo;
            textBox37.ForeColor =Color.FromArgb(red, green, blue);
            textBox38.BackColor =Cor_do_Fundo;
            textBox38.ForeColor =Color.FromArgb(red, green, blue);
            textBox39.BackColor =Cor_do_Fundo;
            textBox39.ForeColor =Color.FromArgb(red, green, blue);
            textBox40.BackColor =Cor_do_Fundo;
            textBox40.ForeColor =Color.FromArgb(red, green, blue);
            textBox41.BackColor = Cor_do_Fundo;
            textBox41.ForeColor =Color.FromArgb(red, green, blue);
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

            DateTime promocao = new DateTime();
            try
            {
                promocao = new DateTime(ano, mes, i);
                textBox0.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 1);
                textBox1.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 2);
                textBox2.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 3);
                textBox3.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 4);
                textBox4.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 5);
                textBox5.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            }
            catch { }
            promocao = new DateTime(ano, mes, i + 6);
            textBox6.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 7);
            textBox7.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 8);
            textBox8.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 9);
            textBox9.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 10);
            textBox10.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 11);
            textBox11.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 12);
            textBox12.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 13);
            textBox13.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 14);
            textBox14.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 15);
            textBox15.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 16);
            textBox16.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 17);
            textBox17.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 18);
            textBox18.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 19);
            textBox19.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 20);
            textBox20.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 21);
            textBox21.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 22);
            textBox22.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 23);
            textBox23.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 24);
            textBox24.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 25);
            textBox25.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 26);
            textBox26.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            promocao = new DateTime(ano, mes, i + 27);
            textBox27.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            try
            {
                promocao = new DateTime(ano, mes, i + 28);
                textBox28.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 29);
                textBox29.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 30);
                textBox30.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 31);
                textBox31.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 32);
                textBox32.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 33);
                textBox33.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 34);
                textBox34.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 35);
                textBox35.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 36);
                textBox36.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 37);
                textBox37.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 38);
                textBox38.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 39);
                textBox39.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 40);
                textBox40.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
            }
            catch { }
            try
            {
                promocao = new DateTime(ano, mes, i + 41);
                textBox41.Text = comando.TrazerPrevisoesDePagamento(promocao.ToString());
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

        #endregion

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formFinanceiroPrevisoesAdicionar adicionar = new formFinanceiroPrevisoesAdicionar(this);
            adicionar.ShowDialog();
            if (alteracao)
            {
                PreencherCalendario(mes, ano);
                AtualizarDataGrid();
                alteracao = false;
            }
        }
        private void formFinanceiroPrevisoes_Resize(object sender, EventArgs e)
        {
            labelProximos.Left = (panelLinha.Width / 2) - (labelProximos.Width / 2);
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                string descricao = Previsoes.Where(x => x.ID_Previsao == id).Select(x => x.Descricao).FirstOrDefault();
                string tipo = Previsoes.Where(x => x.ID_Previsao == id).Where(x => x.Descricao == descricao).Select(x => x.Tipo).FirstOrDefault();

                if (tipo == "Boleto")
                {
                    Boleto Boleto = comando.InformacoesDoBoleto(id);
                    formFinanceiroPrevisoesBoletosAdicionar pagamento = new formFinanceiroPrevisoesBoletosAdicionar(Boleto, tipo);
                    pagamento.ShowDialog();
                }
                else
                {
                    Previsao Previsao = comando.InformacoesDaPrevisao(id);
                    formFinanceiroPrevisoesBoletosAdicionar pagamento = new formFinanceiroPrevisoesBoletosAdicionar(Previsao, tipo);
                    pagamento.ShowDialog();
                }
                AtualizarDataGrid();
            }
            catch { }
        }

        private void buttonBoletos_Click(object sender, EventArgs e)
        {
            formFinanceiroPrevisoesBoletos boletos = new formFinanceiroPrevisoesBoletos();
            boletos.ShowDialog();
        }

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        dataGridViewLista.CurrentCell = dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dataGridViewLista.Rows[e.RowIndex].Selected = true;
                        dataGridViewLista.Focus();

                        id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                        descricao = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();
                        data = dataGridViewLista.Rows[e.RowIndex].Cells[3].Value.ToString();
                    }
                    else
                    {
                        id = 0;
                    }
                }
                catch { }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int registros = dataGridViewLista.SelectedRows.Count;

            if (registros > 0)
            {
                int i = 0;
                string texto = "Deseja apagar definitivamente ";

                foreach (DataGridViewRow linha in dataGridViewLista.SelectedRows)
                {
                    i++;
                    int id_previsao = Convert.ToInt32(dataGridViewLista.Rows[linha.Index].Cells[0].Value);

                    if (registros == 1)
                    {
                        texto = texto + "a previsão " + id_previsao.ToString() + "?";
                    }
                    else if (i == 1)
                    {
                        texto = texto + "as previsões " + id_previsao.ToString() + ", ";
                    }
                    else if (i > 1 && i != registros)
                    {
                        texto = texto + id_previsao.ToString() + ", ";
                    }
                    else if (i > 1 && i == registros)
                    {
                        texto = texto + id_previsao.ToString() + "?";
                    }
                }

                if (DialogResult.Yes == MessageBox.Show(texto, "Apagar previsões", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    foreach (DataGridViewRow linha in dataGridViewLista.SelectedRows)
                    {
                        int id_previsao = Convert.ToInt32(dataGridViewLista.Rows[linha.Index].Cells[0].Value);

                        string descricao = dataGridViewLista.Rows[linha.Index].Cells[1].Value.ToString();
                        string data = dataGridViewLista.Rows[linha.Index].Cells[3].Value.ToString();
                        string tipo = Previsoes.Where(x => x.ID_Previsao == id_previsao && x.Descricao == descricao && x.Data == data).Select(x => x.Tipo).FirstOrDefault();


                        if (tipo == "Previsão")
                        {
                            comando.ApagarPrevisao(id_previsao);
                        }
                        else if (tipo == "Boleto")
                        {
                            comando.ApagarBoleto(id_previsao);
                        }

                    }

                    string mensagem;
                    if (registros == 1) { mensagem = "Previsão apagada com sucesso!"; }
                    else { mensagem = registros.ToString() + " previsões apagadas com sucesso!"; }
                    MessageBox.Show(mensagem, "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizarDataGrid();
                }
            }
        }

        private void buttonAtrasados_Click(object sender, EventArgs e)
        {
            if (comando.VerificarSeHaBoletosAtrasados())
            {
                formFinanceiroPrevisoesAtrasados atrasados = new formFinanceiroPrevisoesAtrasados();
                atrasados.ShowDialog();
            }
            else
            {
                MessageBox.Show("Não há pagamentos atrasados!", "Tudo pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewLista_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    DateTime Data = Convert.ToDateTime(dataGridViewLista.Rows[e.RowIndex].Cells[3].Value);
                    textBoxDetalhes.Text = "Pagamentos do dia " + Data.ToShortDateString() + "\r\n" + comando.PagamentosDoDia(Data).ToString("C");

                    if (!textBoxDetalhes.Visible)
                    {
                        textBoxDetalhes.Top = Cursor.Position.Y - 90;
                        textBoxDetalhes.Left = Cursor.Position.X - 120;
                        int comprimento = textBoxDetalhes.Text.Length;
                        textBoxDetalhes.Height = 20 * (comprimento / 33 + 1);
                    }

                    textBoxDetalhes.Visible = true;
                }
                else if (e.ColumnIndex == 1)
                {
                    id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    descricao = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();
                    data = dataGridViewLista.Rows[e.RowIndex].Cells[3].Value.ToString();

                    string tipo = Previsoes.Where(x => x.ID_Previsao == id && x.Descricao == descricao && x.Data == data).Select(x => x.Tipo).FirstOrDefault();
                    string texto = string.Empty;

                    if (tipo == "Previsão")
                    {
                        //comando.InformacoesDeTextoDoPagamento(id);
                    }
                    else if (tipo == "Boleto")
                    {
                        texto = comando.InformacoesDeTextoDoBoleto(id);

                        textBoxDetalhes.Text = texto;
                        if (!textBoxDetalhes.Visible)
                        {
                            textBoxDetalhes.Top = Cursor.Position.Y - 90;
                            textBoxDetalhes.Left = Cursor.Position.X - 120;
                            int comprimento = textBoxDetalhes.Text.Length;
                            textBoxDetalhes.Height = 60;
                        }

                        textBoxDetalhes.Visible = true;
                    }
                }
            }
            catch { }
        }

        private void dataGridViewLista_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            textBoxDetalhes.Visible = false;
        }

        private void somatorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decimal total = 0;

            foreach (DataGridViewRow linha in dataGridViewLista.SelectedRows)
            {
                total = total + comando.ConverterDinheiroEmDecimal(dataGridViewLista.Rows[linha.Index].Cells[2].Value.ToString());
            }

            MessageBox.Show("Total: " + total.ToString("C"));
        }
    }
}
