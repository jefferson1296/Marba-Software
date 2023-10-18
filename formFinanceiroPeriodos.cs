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
    public partial class formFinanceiroPeriodos : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        List<Informacoes_Vendas> Vendas = new List<Informacoes_Vendas>();

        Meta periodo_simulador = new Meta();
        //Meta ponto_de_equilibrio = new Meta();

        bool calculo;
        public bool alteracao;
        decimal total;
        int dias;
        decimal media;
        decimal media_dia_da_semana;

        decimal custo_unitario;
        decimal venda_unitario;

        decimal custo_variavel_unitario;
        decimal custo_fixo;

        decimal lucro_desejado;

        int Qtd_Vendas;
        int Produtos;
        decimal Receita;

        List<decimal> pesos = new List<decimal>();
        decimal meta_mensal;

        int id_estabelecimento;
        List<Estabelecimento> estabelecimentos = new List<Estabelecimento>();

        public formFinanceiroPeriodos()
        {
            InitializeComponent();
        }
        private void formMedias_Load(object sender, EventArgs e)
        {
            id_estabelecimento = comandos.TrazerIdDoEstabelecimentoPelaReparticao(Program.Computador.ID_Reparticao);
            AtualizarEstabelecimentos();
            comboBoxEstabelecimentos.SelectedValue = id_estabelecimento;

            custo_variavel_unitario = comandos.ObterValorDoParametro("Custo variável unitário");
        }

        private void AtualizarEstabelecimentos()
        {
            comboBoxEstabelecimentos.DataSource = null;

            estabelecimentos = comandos.TrazerEstabelecimentosComerciais();
            comboBoxEstabelecimentos.DataSource = estabelecimentos;
            comboBoxEstabelecimentos.ValueMember = "ID_Estabelecimento";
            comboBoxEstabelecimentos.DisplayMember = "Descricao";

            comboBoxEstabelecimentos.SelectedIndex = -1;
        }

        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            DateTime inicio = dateInicio.Value.Date;
            DateTime termino = dateTermino.Value.Date;

            if (termino < inicio)
            {
                MessageBox.Show("O término do período deve ser uma data posterior ao início do período.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Vendas = comandos.TrazerVendasNoPeriodo(inicio, termino, id_estabelecimento);
                AtualizarDataGridVendas();
                AtualizarTudo();
            }
        }

        private void AtualizarTudo()
        {
            decimal fixos_da_rede = comandos.CustosFixosDaRede();

            decimal fixos_do_estabelecimento = comandos.CustosFixosPorEstabelecimento(id_estabelecimento);
            int estabelecimentos_comerciais = estabelecimentos.Count();

            try { custo_fixo = (fixos_da_rede / estabelecimentos_comerciais) + fixos_do_estabelecimento; }
            catch { custo_fixo = 0; }

            AtualizarDataGridVendas();
            CalcularInformacoes();
            AtualizarDataGridDias();
            AtualizarDataGridMeses();
            CalcularPontoDeEquilibrio();
            CalcularMetas();
            calculo = true;

        }

        private void AtualizarDataGridVendas()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewVendas.CurrentRow != null)
            {
                primeira_linha = dataGridViewVendas.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewVendas.CurrentRow.Index;
            }

            dataGridViewVendas.Rows.Clear();

            foreach (Informacoes_Vendas Venda in Vendas)
            {
                dataGridViewVendas.Rows.Add(Venda.Data.ToShortDateString(), Venda.Dia_da_semana, Venda.CMV.ToString("C"), Venda.Receita_Vendas.ToString("C"), Venda.Simulacao);
            }

            try
            {
                dataGridViewVendas.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewVendas.CurrentCell = dataGridViewVendas.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }
        private void CalcularInformacoes()
        {
            total = Vendas.Where(x => x.Simulacao).Sum(x => x.Receita_Vendas);
            dias = Vendas.Count;
            media = total / dias;
            media_dia_da_semana = dias.ToDecimal() / 7;

            textBoxTotal.Text = total.ToString("C");
            textBoxDias.Text = dias.ToString();
            textBoxMedia.Text = media.ToString("C");
            textBoxDiaDaSemana.Text = media_dia_da_semana.ToString("F");
        }

        private void AtualizarDataGridDias()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewDias.CurrentRow != null)
            {
                primeira_linha = dataGridViewDias.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewDias.CurrentRow.Index;
            }

            dataGridViewDias.Rows.Clear();


            int dias_domingo = Vendas.Where(x => x.Dia_da_semana == "Domingo" && x.Simulacao).Count();
            int dias_segunda = Vendas.Where(x => x.Dia_da_semana == "Segunda-feira" && x.Simulacao).Count();
            int dias_terça = Vendas.Where(x => x.Dia_da_semana == "Terça-feira" && x.Simulacao).Count();
            int dias_quarta = Vendas.Where(x => x.Dia_da_semana == "Quarta-feira" && x.Simulacao).Count();
            int dias_quinta = Vendas.Where(x => x.Dia_da_semana == "Quinta-feira" && x.Simulacao).Count();
            int dias_sexta = Vendas.Where(x => x.Dia_da_semana == "Sexta-feira" && x.Simulacao).Count();
            int dias_sabado = Vendas.Where(x => x.Dia_da_semana == "Sábado" && x.Simulacao).Count();

            dataGridViewDias.Rows.Add("Dias", dias_domingo, dias_segunda, dias_terça, dias_quarta, dias_quinta, dias_sexta, dias_sabado);

            decimal total_domingo = Vendas.Where(x => x.Dia_da_semana == "Domingo" && x.Simulacao).Sum(x => x.Receita_Vendas);
            decimal total_segunda = Vendas.Where(x => x.Dia_da_semana == "Segunda-feira" && x.Simulacao).Sum(x => x.Receita_Vendas);
            decimal total_terça = Vendas.Where(x => x.Dia_da_semana == "Terça-feira" && x.Simulacao).Sum(x => x.Receita_Vendas);
            decimal total_quarta = Vendas.Where(x => x.Dia_da_semana == "Quarta-feira" && x.Simulacao).Sum(x => x.Receita_Vendas);
            decimal total_quinta = Vendas.Where(x => x.Dia_da_semana == "Quinta-feira" && x.Simulacao).Sum(x => x.Receita_Vendas);
            decimal total_sexta = Vendas.Where(x => x.Dia_da_semana == "Sexta-feira" && x.Simulacao).Sum(x => x.Receita_Vendas);
            decimal total_sabado = Vendas.Where(x => x.Dia_da_semana == "Sábado" && x.Simulacao).Sum(x => x.Receita_Vendas);

            dataGridViewDias.Rows.Add("Total", total_domingo.ToString("C"), total_segunda.ToString("C"), total_terça.ToString("C"), total_quarta.ToString("C"), total_quinta.ToString("C"), total_sexta.ToString("C"), total_sabado.ToString("C"));

            decimal media_domingo; 
            try { media_domingo = total_domingo / dias_domingo; } 
            catch { media_domingo = 0; }
            decimal media_segunda; 
            try { media_segunda = total_segunda / dias_segunda; }
            catch { media_segunda = 0; }
            decimal media_terça; 
            try { media_terça = total_terça / dias_terça; }
            catch { media_terça = 0; }
            decimal media_quarta ; 
            try { media_quarta = total_quarta / dias_quarta; }
            catch { media_quarta = 0; }
            decimal media_quinta; 
            try { media_quinta = total_quinta / dias_quinta; }
            catch { media_quinta = 0; }
            decimal media_sexta; 
            try { media_sexta = total_sexta / dias_sexta; }
            catch { media_sexta = 0; }
            decimal media_sabado; 
            try { media_sabado = total_sabado / dias_sabado; }
            catch { media_sabado = 0; }

            dataGridViewDias.Rows.Add("Média", media_domingo.ToString("C"), media_segunda.ToString("C"), media_terça.ToString("C"), media_quarta.ToString("C"), media_quinta.ToString("C"), media_sexta.ToString("C"), media_sabado.ToString("C"));

            periodo_simulador = new Meta()
            {
                Periodo = "Simulador",
                Domingo = media_domingo,
                Segunda = media_segunda,
                Terca = media_terça,
                Quarta = media_quarta,
                Quinta = media_quinta,
                Sexta = media_sexta,
                Sabado = media_sabado
            };

            decimal peso_domingo;
            try { peso_domingo = total_domingo / (total / 10) * media_dia_da_semana / dias_domingo; }
            catch { peso_domingo = 0; }
            decimal peso_segunda;
            try { peso_segunda = total_segunda / (total / 10) * media_dia_da_semana / dias_segunda; }
            catch { peso_segunda = 0; }
            decimal peso_terça;
            try { peso_terça = total_terça / (total / 10) * media_dia_da_semana / dias_terça; }
            catch { peso_terça = 0; }
            decimal peso_quarta;
            try { peso_quarta = total_quarta / (total / 10) * media_dia_da_semana / dias_quarta; }
            catch { peso_quarta = 0; }
            decimal peso_quinta;
            try { peso_quinta = total_quinta / (total / 10) * media_dia_da_semana / dias_quinta; }
            catch { peso_quinta = 0; }
            decimal peso_sexta;
            try { peso_sexta = total_sexta / (total / 10) * media_dia_da_semana / dias_sexta; }
            catch { peso_sexta = 0; }
            decimal peso_sabado;
            try { peso_sabado = total_sabado / (total / 10) * media_dia_da_semana / dias_sabado; }
            catch { peso_sabado = 0; }

            pesos.Clear();
            pesos.Add(peso_domingo);
            pesos.Add(peso_segunda);
            pesos.Add(peso_terça);
            pesos.Add(peso_quarta);
            pesos.Add(peso_quinta);
            pesos.Add(peso_sexta);
            pesos.Add(peso_sabado);

            dataGridViewDias.Rows.Add("Peso", peso_domingo.ToString("F"), peso_segunda.ToString("F"), peso_terça.ToString("F"), peso_quarta.ToString("F"), peso_quinta.ToString("F"), peso_sexta.ToString("F"), peso_sabado.ToString("F"));

            try
            {
                dataGridViewDias.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewDias.CurrentCell = dataGridViewDias.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }
        private void AtualizarDataGridMeses()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewMeses.CurrentRow != null)
            {
                primeira_linha = dataGridViewMeses.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewMeses.CurrentRow.Index;
            }

            dataGridViewMeses.Rows.Clear();

            List<string> Meses = Vendas.Select(x => x.Data.ToString(@"MMMM").PrimeiraLetraMaiuscula().Substring(0, 3) + "/" + x.Data.Year.ToString()).Distinct().ToList();

            foreach (string Mes in Meses)
            {
                string[] partir = Mes.Split('/');
                string mes = partir[0];
                int ano = Convert.ToInt32(partir[1]);

                int dias = Vendas.Where(x => x.Data.ToString(@"MMMM").PrimeiraLetraMaiuscula().Substring(0, 3) == mes && x.Data.Year == ano).Count();
                int vendas = Vendas.Where(x => x.Data.ToString(@"MMMM").PrimeiraLetraMaiuscula().Substring(0, 3) == mes && x.Data.Year == ano).Sum(x => x.Qtd_Vendas);
                int produtos = Vendas.Where(x => x.Data.ToString(@"MMMM").PrimeiraLetraMaiuscula().Substring(0, 3) == mes && x.Data.Year == ano).Sum(x => x.Produtos_Vendidos);
                decimal receita = Vendas.Where(x => x.Data.ToString(@"MMMM").PrimeiraLetraMaiuscula().Substring(0, 3) == mes && x.Data.Year == ano).Sum(x => x.Receita_Vendas);
                decimal lucro = Vendas.Where(x => x.Data.ToString(@"MMMM").PrimeiraLetraMaiuscula().Substring(0, 3) == mes && x.Data.Year == ano).Sum(x => x.Receita_Vendas - x.CMV);
                
                decimal receita_produtos;
                try { receita_produtos = receita / produtos; }
                catch { receita_produtos = 0; }
                decimal receita_vendas;
                try { receita_vendas = receita / vendas; }
                catch { receita_vendas = 0; }
                decimal produtos_vendas;
                try { produtos_vendas = produtos.ToDecimal() / vendas.ToDecimal(); }
                catch { produtos_vendas = 0; }
                decimal receita_dias;
                try { receita_dias = receita / dias; }
                catch { receita_dias = 0; }
                decimal vendas_dias;
                try { vendas_dias= vendas.ToDecimal() / dias.ToDecimal(); }
                catch { vendas_dias = 0; }

                dataGridViewMeses.Rows.Add(Mes, vendas, produtos, receita.ToString("C"), lucro.ToString("C"), receita_produtos.ToString("C"), receita_vendas.ToString("C"), produtos_vendas.ToString("F"), receita_dias.ToString("C"), vendas_dias.ToString("F"));
            }

            int meses = Vendas.Select(x => x.Data.Month).Distinct().Count();
            int Dias = Vendas.Count;

            Qtd_Vendas = Vendas.Sum(x => x.Qtd_Vendas);
            Produtos = Vendas.Sum(x => x.Produtos_Vendidos);
            Receita = Vendas.Sum(x => x.Receita_Vendas);
            decimal Lucro = Vendas.Sum(x => x.Receita_Vendas - x.CMV);
            decimal Receita_produtos = Receita / Produtos;
            decimal Receita_vendas = Receita / Qtd_Vendas;
            decimal Produtos_vendas = Produtos.ToDecimal() / Qtd_Vendas.ToDecimal();
            decimal Receita_dias = Receita / Dias;
            decimal Vendas_dias = Qtd_Vendas.ToDecimal() / Dias.ToDecimal();

            custo_unitario = Vendas.Sum(x => x.CMV) / Produtos;
            venda_unitario = Receita_produtos;

            periodo_simulador.Mes = Receita / meses;

            dataGridViewMeses.Rows.Add("Média", Qtd_Vendas / meses, Produtos / meses, (Receita / meses).ToString("C"), (Lucro / meses).ToString("C"), Receita_produtos.ToString("C"), Receita_vendas.ToString("C"), Produtos_vendas.ToString("F"), Receita_dias.ToString("C"), Vendas_dias.ToString("F"));
            dataGridViewMeses.Rows.Add("Total", Qtd_Vendas, Produtos, Receita.ToString("C"), Lucro.ToString("C"));

            try
            {
                dataGridViewMeses.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewMeses.CurrentCell = dataGridViewMeses.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }

        private void CalcularPontoDeEquilibrio()
        {            
            decimal custo = custo_unitario + custo_variavel_unitario;
            decimal margem = venda_unitario - custo;
            decimal ponto_de_equilibrio = custo_fixo / margem;

            textBoxCusto.Text = custo_unitario.ToString("C");
            textBoxVenda.Text = venda_unitario.ToString("C");
            textBoxVariavel.Text = custo_variavel_unitario.ToString("C");
            textBoxFixo.Text = custo_fixo.ToString("C");

            textBoxMargem.Text = margem.ToString("C");
            textBoxEquilibrio.Text = ponto_de_equilibrio.ToString("F");
        }

        private void CalcularMetas()
        {
            decimal custo = custo_unitario + custo_variavel_unitario;
            decimal margem = venda_unitario - custo;
            decimal ponto_de_equilibrio = (lucro_desejado + custo_fixo) / margem;

            decimal Receita_produtos = Receita / Produtos;
            decimal Produtos_vendas = Produtos.ToDecimal() / Qtd_Vendas.ToDecimal();

            int dias_do_mes = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

            decimal produtos_mes = ponto_de_equilibrio;
            decimal vendas_mes = produtos_mes / Produtos_vendas;
            decimal receita_mes = ponto_de_equilibrio * Receita_produtos;
            meta_mensal = receita_mes;
            decimal produtos_dia = produtos_mes / dias_do_mes;
            decimal vendas_dia = vendas_mes / dias_do_mes;
            decimal receita_dia = receita_mes / dias_do_mes;

            string objetivo;
            if (lucro_desejado == 0) { objetivo = "para não obter prejuízos"; }
            else { objetivo = " para gerar " + lucro_desejado.ToString("C") + " de lucro."; }

            labelProdutosMes.Text = "É necessário vender " + Convert.ToInt32(produtos_mes) + " produtos por mês " + objetivo;
            labelVendasMes.Text = "É necessário realizar " + Convert.ToInt32(vendas_mes) + " vendas por mês " + objetivo;
            labelReceitaMes.Text = "É necessário vender " + receita_mes.ToString("C") + " por mês " + objetivo;
            labelProdutosDia.Text = "É necessário vender " + Convert.ToInt32(produtos_dia) + " produtos por dia " + objetivo;
            labelVendasDia.Text = "É necessário realizar " + Convert.ToInt32(vendas_dia) + " vendas por dia " + objetivo;
            labelReceitaDia.Text = "É necessário vender " + receita_dia.ToString("C") + " por dia " + objetivo;
        }

        private void dataGridViewMeses_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Font minhafonte = new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Point);

                dataGridViewMeses.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font = minhafonte;
                try
                {
                    if (dataGridViewMeses.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Média")
                    {
                        DataGridViewRow linhaestilizada = dataGridViewMeses.Rows[e.RowIndex];
                        //linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        linhaestilizada.DefaultCellStyle.ForeColor = Color.Red;
                        linhaestilizada.DefaultCellStyle.SelectionForeColor = Color.Red;
                    }
                }
                catch { }
            }
        }

        #region Formatação
        private void textBoxLucro_Enter(object sender, EventArgs e)
        {
            if (textBoxLucro.Text == "R$0,00")
            {
                textBoxLucro.Text = string.Empty;
            }
            else
            {
                string[] partir = textBoxLucro.Text.Split('$');
                textBoxLucro.Text = partir[1];
            }
        }

        private void textBoxLucro_Leave(object sender, EventArgs e)
        {
            if (textBoxLucro.Text == string.Empty)
            {
                textBoxLucro.Text = "R$0,00";
                lucro_desejado = 0;
            }
            else
            {
                decimal valor = Convert.ToDecimal(textBoxLucro.Text);
                lucro_desejado = valor;
                textBoxLucro.Text = valor.ToString("C");
            }
        }

        private void textBoxLucro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
(e.KeyChar != ',' && e.KeyChar != '.' &&
e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!textBoxLucro.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (Char)0;
                    }
                }
            }
        }
        #endregion

        private void buttonEquilibrio_Click(object sender, EventArgs e)
        {
            try
            {
                CalcularMetas();
                buttonMetas.Enabled = true;
            }
            catch { }
        }
        private void buttonVariavel_Click(object sender, EventArgs e)
        {
            formFinanceiroPeriodosVariavel variavel = new formFinanceiroPeriodosVariavel(this);
            variavel.ShowDialog();

            if (alteracao)
            {
                custo_variavel_unitario = comandos.ObterValorDoParametro("Custo variável unitário");
                if (calculo)
                {
                    CalcularPontoDeEquilibrio();
                    CalcularMetas();
                }
            }
        }
        private void buttonSimulador_Click(object sender, EventArgs e)
        {
            formFinanceiroSimuladorCalendario simulador = new formFinanceiroSimuladorCalendario();
            simulador.ShowDialog();
        }
        private void buttonMetas_Click(object sender, EventArgs e)
        {
            formFinanceiroPeriodosMeta metas = new formFinanceiroPeriodosMeta(pesos, meta_mensal, lucro_desejado, id_estabelecimento);
            metas.ShowDialog();
        }
        private void buttonPeriodoSimulador_Click(object sender, EventArgs e)
        {
            try
            {
                periodo_simulador.ID_Estabelecimento = id_estabelecimento;
                comandos.EditarMeta(periodo_simulador);
            }
            catch { }
        }

        private void comboBoxEstabelecimentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxEstabelecimentos.SelectedValue != null)
                {
                    id_estabelecimento = (int)comboBoxEstabelecimentos.SelectedValue;
                }

            }
            catch { }
        }

        private void dataGridViewVendas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                DateTime data = Convert.ToDateTime(dataGridViewVendas[0, e.RowIndex].Value);
                bool simulacao = Convert.ToBoolean(dataGridViewVendas[e.ColumnIndex, e.RowIndex].Value);
                
                foreach (Informacoes_Vendas venda in Vendas)
                {
                    if (venda.Data == data)
                    {
                        venda.Simulacao = !simulacao;
                    }
                }

                AtualizarTudo();
            }
        }
    }
}
