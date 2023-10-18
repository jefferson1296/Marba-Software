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
    public partial class formFinanceiroSimulador : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Simulador> simulacoes = new List<Simulador>();

        int mes;
        int ano;

        decimal saldo_atual;
        decimal dividas_circulantes;
        decimal saldo_total;

        public formFinanceiroSimulador()
        {
            InitializeComponent();
        }

        private void formFinanceiroSimulador2_Load(object sender, EventArgs e)
        {
            DateTime hoje = DateTime.Now.Date;
            mes = hoje.Month;
            ano = hoje.Year;

            saldo_atual = comandos.TrazerSaldo(hoje);
            dividas_circulantes = comandos.DividasCirculantes();

            saldo_total = saldo_atual + dividas_circulantes;

            PreencherDiasDaTabela(hoje);
            AtualizarDataGrid();
        }

        private void PreencherDiasDaTabela(DateTime hoje)
        {
            CultureInfo cultura = new CultureInfo("pt-BR");
            DateTimeFormatInfo formato = cultura.DateTimeFormat;

            decimal saldo_total = this.saldo_total;

            DateTime dia_final = DateTime.Now.AddMonths(3).Date;

            int dias = Convert.ToInt32(dia_final.Subtract(hoje).TotalDays);

            for (int i = 0; i < dias; i++)
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

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            dataGridViewLista.Rows.Clear();

            foreach (Simulador simulacao in simulacoes)
            {
                dataGridViewLista.Rows.Add(simulacao.Dia_da_semana, simulacao.Dia.ToShortDateString(), simulacao.Despesas.ToString("C"), simulacao.Receitas.ToString("C"), simulacao.Saldo_Dia.ToString("C"), simulacao.Saldo_Total.ToString("C"));
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }
    }
}
