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
    public partial class formFinanceiroPeriodosMeta : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        decimal meta_mensal;
        List<decimal> pesos = new List<decimal>();
        decimal lucro_desejado;
        List<MetaDiaria> metas_diarias = new List<MetaDiaria>();
        Meta meta = new Meta();

        public formFinanceiroPeriodosMeta()
        {
            InitializeComponent();
        }
        public formFinanceiroPeriodosMeta(List<decimal> Pesos, decimal Meta_mensal, decimal Lucro_desejado, int ID_Estabelecimento)
        {
            InitializeComponent();
            pesos = Pesos;
            meta_mensal = Meta_mensal;
            lucro_desejado = Lucro_desejado;

            meta.ID_Estabelecimento = ID_Estabelecimento;
        }

        private void formFinanceiroPeriodosMeta_Load(object sender, EventArgs e)
        {
            List<string> Meses = new List<string>();
            if (lucro_desejado == 0) { buttonEquilibrio.Visible = true; }

            for (int i = 0; i <= 12; i++)
            {
                DateTime data = DateTime.Now.AddMonths(i);
                string mes_ = data.ToString(@"MMMM");
                string Mes = mes_.ToUpper() + "/" + data.Year.ToString();

                Meses.Add(Mes);
            }
            foreach (string mes in Meses) { comboBoxMes.Items.Add(mes); }
        }

        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            string periodo = comboBoxMes.Text;

            if (periodo == string.Empty)
            {
                MessageBox.Show("Informe o período.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string[] partir = periodo.Split('/');
                string mes = partir[0];
                int Mes = comandos.ConverterMesPorExtensoEmInt(mes);
                int Ano = Convert.ToInt32(partir[1]);

                int dias_do_mes = DateTime.DaysInMonth(Ano, Mes);

                for (int i = 1; i <= dias_do_mes; i++)
                {
                    DateTime data = new DateTime(Ano, Mes, i);
                    string dia_da_semana = comandos.ConverterDataParaDiaDaSemana(data);
                    string status;
                    if (comandos.VerificarFeriadoComLojaFechada(data)) { status = "Fechado"; }
                    else { status = "Aberto"; }

                    metas_diarias.Add(new MetaDiaria
                    {
                        Dia = data,
                        Dia_da_semana = dia_da_semana,
                        Status = status
                    });
                }

                dataGridViewDias.Rows.Clear();

                int dias_funcionamento = metas_diarias.Where(x => x.Status == "Aberto").Count();
                decimal media_dias_da_semana = dias_funcionamento.ToDecimal() / 7;

                int dias_domingo = metas_diarias.Where(x => x.Dia_da_semana == "Domingo" && x.Status == "Aberto").Count();
                int dias_segunda = metas_diarias.Where(x => x.Dia_da_semana == "Segunda-feira" && x.Status == "Aberto").Count();
                int dias_terca = metas_diarias.Where(x => x.Dia_da_semana == "Terça-feira" && x.Status == "Aberto").Count();
                int dias_quarta = metas_diarias.Where(x => x.Dia_da_semana == "Quarta-feira" && x.Status == "Aberto").Count();
                int dias_quinta = metas_diarias.Where(x => x.Dia_da_semana == "Quinta-feira" && x.Status == "Aberto").Count();
                int dias_sexta = metas_diarias.Where(x => x.Dia_da_semana == "Sexta-feira" && x.Status == "Aberto").Count();
                int dias_sabado = metas_diarias.Where(x => x.Dia_da_semana == "Sábado" && x.Status == "Aberto").Count();

                dataGridViewDias.Rows.Add("Dias", dias_funcionamento + "/" + dias_do_mes, dias_domingo, dias_segunda, dias_terca, dias_quarta, dias_quinta, dias_sexta, dias_sabado);
                dataGridViewDias.Rows.Add("Peso", 10.00, pesos[0].ToString("F"), pesos[1].ToString("F"), pesos[2].ToString("F"), pesos[3].ToString("F"), pesos[4].ToString("F"), pesos[5].ToString("F"), pesos[6].ToString("F"));

                decimal meta_domingo = meta_mensal / 10 / (media_dias_da_semana / dias_domingo) * pesos[0] / dias_domingo;
                decimal meta_segunda = meta_mensal / 10 / (media_dias_da_semana / dias_segunda) * pesos[1] / dias_segunda;
                decimal meta_terca = meta_mensal / 10 / (media_dias_da_semana / dias_terca) * pesos[2] / dias_terca;
                decimal meta_quarta = meta_mensal / 10 / (media_dias_da_semana / dias_quarta) * pesos[3] / dias_quarta;
                decimal meta_quinta = meta_mensal / 10 / (media_dias_da_semana / dias_quinta) * pesos[4] / dias_quinta;
                decimal meta_sexta = meta_mensal / 10 / (media_dias_da_semana / dias_sexta) * pesos[5] / dias_sexta;
                decimal meta_sabado = meta_mensal / 10 / (media_dias_da_semana / dias_sabado) * pesos[6] / dias_sabado;

                decimal meta_semanal = meta_domingo + meta_segunda + meta_terca + meta_quarta + meta_quinta + meta_sexta + meta_sabado;

                dataGridViewDias.Rows.Add("Meta por semana", meta_semanal.ToString("C"), meta_domingo.ToString("C"), meta_segunda.ToString("C"), meta_terca.ToString("C"), meta_quarta.ToString("C"), meta_quinta.ToString("C"), meta_sexta.ToString("C"), meta_sabado.ToString("C"));
                dataGridViewDias.Rows.Add("Meta total", meta_mensal.ToString("C"), (meta_domingo * dias_domingo).ToString("C"), (meta_segunda * dias_segunda).ToString("C"), (meta_terca * dias_terca).ToString("C"), (meta_quarta * dias_quarta).ToString("C"), (meta_quinta * dias_quinta).ToString("C"), (meta_sexta * dias_sexta).ToString("C"), (meta_sabado * dias_sabado).ToString("C"));

                meta.Periodo = periodo;
                meta.Mes = meta_mensal;
                meta.Domingo = meta_domingo;
                meta.Segunda = meta_segunda;
                meta.Terca = meta_terca;
                meta.Quarta = meta_quarta;
                meta.Quinta = meta_quinta;
                meta.Sexta = meta_sexta;
                meta.Sabado = meta_sabado;

                foreach (MetaDiaria metaDiaria in metas_diarias)
                {
                    if (metaDiaria.Dia_da_semana == "Domingo") { metaDiaria.Meta = meta_domingo; }
                    if (metaDiaria.Dia_da_semana == "Segunda-feira") { metaDiaria.Meta = meta_segunda; }
                    if (metaDiaria.Dia_da_semana == "Terça-feira") { metaDiaria.Meta = meta_terca; }
                    if (metaDiaria.Dia_da_semana == "Quarta-feira") { metaDiaria.Meta = meta_quarta; }
                    if (metaDiaria.Dia_da_semana == "Quinta-feira") { metaDiaria.Meta = meta_quinta; }
                    if (metaDiaria.Dia_da_semana == "Sexta-feira") { metaDiaria.Meta = meta_sexta; }
                    if (metaDiaria.Dia_da_semana == "Sábado") { metaDiaria.Meta = meta_sabado; }
                }
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {            
            comandos.DefinirMeta(meta, metas_diarias);
            Dispose();
        }

        private void buttonEquilibrio_Click(object sender, EventArgs e)
        {
            meta.Periodo = "Ponto de equilíbrio";
            comandos.EditarMeta(meta);
            Dispose();
        }
    }
}
