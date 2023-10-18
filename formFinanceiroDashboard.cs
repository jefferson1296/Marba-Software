using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MarbaSoftware
{
    public partial class formFinanceiroDashboard : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        DateTime data = new DateTime();

        int mes;
        int ano;
        public formFinanceiroDashboard()
        {
            InitializeComponent();
        }

        private void buttonDespesas_Click(object sender, EventArgs e)
        {
            formFinanceiroDespesas despesas = new formFinanceiroDespesas();
            despesas.ShowDialog();
        }

        private void formFinanceiroGeral_Load(object sender, EventArgs e)
        {
            dateTimePicker.Value = DateTime.Now.Date;

            List<string> Meses = comandos.MesesDoDRE();
            foreach (string mes in Meses) { comboBoxMes.Items.Add(mes); }

            string Mes = comandos.ConverterMesIntParaExtenso(DateTime.Now.Month).ToUpper() + "/" + DateTime.Now.Year.ToString();
            comboBoxMes.Text = Mes;
        }

        private void AtualizarTudo()
        {
            PreencherDashboard();
            PreencherInformacoesDeVenda();
            PreencherGraficoDeVendasPorHora();
            PreencherGraficoDeFormasDePagamento();
        }

        private void PreencherGraficoDeVendasPorHora()
        {
            List<Venda_Por_Hora> vendas_hora = comandos.VendasPorHora(data);

            chartHora.ChartAreas.Clear();
            chartHora.Legends.Clear();
            chartHora.Series.Clear();
            chartHora.Titles.Clear();

            chartHora.ChartAreas.Add("Interior");
            chartHora.ChartAreas["Interior"].Area3DStyle.Enable3D = true;
            chartHora.ChartAreas["Interior"].Area3DStyle.Inclination = 5;
            chartHora.ChartAreas["Interior"].Area3DStyle.IsRightAngleAxes = false;
            chartHora.ChartAreas["Interior"].Area3DStyle.LightStyle = LightStyle.Realistic;
            chartHora.ChartAreas["Interior"].Area3DStyle.PointDepth = 50;
            chartHora.ChartAreas["Interior"].Area3DStyle.PointGapDepth = 150;
            chartHora.ChartAreas["Interior"].Area3DStyle.Rotation = 5;

            //Título

            Title titulo = new Title();
            titulo.Font = new Font("Verdana", 12, FontStyle.Regular, GraphicsUnit.Point);
            titulo.ForeColor = Color.SpringGreen;
            titulo.Text = "Vendas por Hora";
            chartHora.Titles.Add(titulo);

            //Subtítulo
            //Title subtitulo = new Title();
            //subtitulo.Font = new Font("Verdana", 6, FontStyle.Bold, GraphicsUnit.Point);
            //subtitulo.ForeColor = Color.Black;
            //subtitulo.Text = data.ToShortDateString();
            //chartHora.Titles.Add(subtitulo);

            //Legenda

            Legend legenda = new Legend();
            chartHora.Legends.Add(legenda);

            //Valores

            chartHora.Series.Add("Vendas");
            chartHora.Series["Vendas"].LegendText = "Vendas";
            chartHora.Series["Vendas"].ChartArea = "Interior";
            chartHora.Series["Vendas"].ChartType = SeriesChartType.Column;
            chartHora.Series["Vendas"].BorderWidth = 5;
            
            foreach (Venda_Por_Hora vendas in vendas_hora)
            {
                chartHora.Series["Vendas"].Points.AddXY(vendas.Hora, vendas.Valor);
            }

            //Título dos eixos

            chartHora.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 7, FontStyle.Bold, GraphicsUnit.Point);
            chartHora.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 7, FontStyle.Bold, GraphicsUnit.Point);

            //chartHora.ChartAreas["Interior"].AxisX.Title = "Horas";
            chartHora.ChartAreas["Interior"].AxisX.TitleFont = new Font("Verdana", 10, FontStyle.Regular, GraphicsUnit.Point);           
            
            chartHora.ChartAreas["Interior"].AxisY.Title = "Valor R$";
            chartHora.ChartAreas["Interior"].AxisY.TitleFont = new Font("Verdana", 10, FontStyle.Regular, GraphicsUnit.Point);

            //Exibir valores dentro dos gráficos, em formato R$

            chartHora.Series["Vendas"].IsValueShownAsLabel = true;
            chartHora.Series["Vendas"].Font = new Font("Arial", 7, FontStyle.Bold, GraphicsUnit.Point);
            chartHora.Series["Vendas"].Label = "#VALY{R$#,##0.00}";


            //Remover grades verticais
            chartHora.ChartAreas["Interior"].AxisX.MajorGrid.LineWidth = 0;

            //Alterar cor das grades horizontais
            chartHora.ChartAreas["Interior"].AxisY.MajorGrid.LineColor = Color.DarkGray;

            //Escala do eixo X
            try
            {
                chartHora.ChartAreas["Interior"].AxisY.Maximum = Convert.ToDouble(vendas_hora.Max(x => x.Valor)) + 100;
                chartHora.ChartAreas["Interior"].AxisY.Interval = 100;
            }
            catch { }
        }

        private void PreencherGraficoDeFormasDePagamento()
        {
            List<Venda_Por_Forma> vendas_forma = comandos.VendasPorFormaDePagamento(data);

            chartForma.ChartAreas.Clear();
            chartForma.Legends.Clear();
            chartForma.Series.Clear();
            chartForma.Titles.Clear();

            chartForma.ChartAreas.Add("Interior");
            chartForma.ChartAreas["Interior"].Area3DStyle.Enable3D = true;
            chartForma.ChartAreas["Interior"].Area3DStyle.Inclination = 45;
            chartForma.ChartAreas["Interior"].Area3DStyle.IsRightAngleAxes = false;
            chartForma.ChartAreas["Interior"].Area3DStyle.LightStyle = LightStyle.Realistic;
            chartForma.ChartAreas["Interior"].Area3DStyle.PointDepth = 100;
            chartForma.ChartAreas["Interior"].Area3DStyle.PointGapDepth = 150;
            chartForma.ChartAreas["Interior"].Area3DStyle.Rotation = 60;

            //Título

            Title titulo = new Title();
            titulo.Font = new Font("Verdana", 10, FontStyle.Regular, GraphicsUnit.Point);
            titulo.ForeColor = Color.HotPink;
            titulo.Text = "Vendas por forma de pagamento";
            chartForma.Titles.Add(titulo);


            //Valores

            chartForma.Series.Add("Vendas");
            //chartForma.Series["Vendas"].LegendText = "Vendas";
            chartForma.Series["Vendas"].ChartArea = "Interior";
            chartForma.Series["Vendas"].ChartType = SeriesChartType.Pie;
            chartForma.Series["Vendas"].BorderWidth = 5;

            foreach (Venda_Por_Forma vendas in vendas_forma)
            {
                chartForma.Series["Vendas"].Points.AddXY(vendas.Forma_Pagamento, vendas.Valor);
            }

            //Mostrar os valores dentro das fatias de Pizza

            chartForma.Series["Vendas"].IsValueShownAsLabel = true;
            chartForma.Series["Vendas"].Font = new Font("Arial", 7, FontStyle.Bold, GraphicsUnit.Point);
            chartForma.Series["Vendas"].LabelForeColor = Color.Black;
            chartForma.Series["Vendas"].Label = "#VALY{R$#,##0.00}";
            chartForma.Series["Vendas"].LegendText = "#VALX";

            //Legenda

            Legend legenda = new Legend();
            chartForma.Legends.Add(legenda);
            chartForma.Legends[0].Title = "Pagamento";

            //Título dos eixos

            chartForma.ChartAreas["Interior"].AxisX.Title = "Horas";
            chartForma.ChartAreas["Interior"].AxisX.TitleFont = new Font("Verdana", 10, FontStyle.Regular, GraphicsUnit.Point);

            chartForma.ChartAreas["Interior"].AxisY.Title = "Valor R$";
            chartForma.ChartAreas["Interior"].AxisY.TitleFont = new Font("Verdana", 10, FontStyle.Regular, GraphicsUnit.Point);

            //Paleta de cores

            chartForma.Palette = ChartColorPalette.SemiTransparent;
        }

        private void PreencherGraficoDeVendasPorMes()
        {
            List<Informacoes_Vendas> vendas = comandos.VendaPorDiaDoMes(mes, ano);

            chartMes.ChartAreas.Clear();
            chartMes.Legends.Clear();
            chartMes.Series.Clear();
            chartMes.Titles.Clear();

            chartMes.ChartAreas.Add("Interior");
            //chartMes.ChartAreas["Interior"].Area3DStyle.Enable3D = true;
            //chartMes.ChartAreas["Interior"].Area3DStyle.Inclination = 5;
            //chartMes.ChartAreas["Interior"].Area3DStyle.IsRightAngleAxes = false;
            //chartMes.ChartAreas["Interior"].Area3DStyle.LightStyle = LightStyle.Realistic;
            //chartMes.ChartAreas["Interior"].Area3DStyle.PointDepth = 100;
            //chartMes.ChartAreas["Interior"].Area3DStyle.PointGapDepth = 150;
            //chartMes.ChartAreas["Interior"].Area3DStyle.Rotation = 5;

            //Título

            Title titulo = new Title();
            titulo.Font = new Font("Verdana", 10, FontStyle.Regular, GraphicsUnit.Point);
            titulo.ForeColor = Color.HotPink;
            titulo.Text = "Vendas do mês";
            chartMes.Titles.Add(titulo);


            //Valores

            chartMes.Series.Add("Vendas");
            chartMes.Series["Vendas"].ChartArea = "Interior";
            chartMes.Series["Vendas"].ChartType = SeriesChartType.Line;
            chartMes.Series["Vendas"].BorderWidth = 3;

            foreach (Informacoes_Vendas venda in vendas)
            {
                chartMes.Series["Vendas"].Points.AddXY(venda.Data.Day.ToString(), venda.Receita_Vendas);
            }

            //Mostrar os valores dentro das fatias de Pizza

            chartMes.Series["Vendas"].IsValueShownAsLabel = true;
            chartMes.Series["Vendas"].Font = new Font("Arial", 7, FontStyle.Bold, GraphicsUnit.Point);
            chartMes.Series["Vendas"].LabelForeColor = Color.Black;
            chartMes.Series["Vendas"].Label = "#VALY{R$#,##0.00}";
            //chartMes.Series["Vendas"].LegendText = "#VALX";

            //Legenda

            Legend legenda = new Legend();
            chartMes.Legends.Add(legenda);
            chartMes.Legends[0].Title = "Pagamento";

            //Título dos eixos

            chartMes.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 7, FontStyle.Bold, GraphicsUnit.Point);
            chartMes.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 7, FontStyle.Bold, GraphicsUnit.Point);

            chartMes.ChartAreas["Interior"].AxisX.Title = "Horas";
            chartMes.ChartAreas["Interior"].AxisX.TitleFont = new Font("Verdana", 10, FontStyle.Regular, GraphicsUnit.Point);

            chartMes.ChartAreas["Interior"].AxisY.Title = "Valor R$";
            chartMes.ChartAreas["Interior"].AxisY.TitleFont = new Font("Verdana", 10, FontStyle.Regular, GraphicsUnit.Point);

            //Remover grades verticais
            chartMes.ChartAreas["Interior"].AxisX.MajorGrid.LineWidth = 0;

            //Alterar cor das grades horizontais
            chartMes.ChartAreas["Interior"].AxisY.MajorGrid.LineColor = Color.LightGray;

            //Escala do eixo X
            try
            {
                chartMes.ChartAreas["Interior"].AxisY.Maximum = Convert.ToDouble(vendas.Max(x => x.Receita_Vendas)) + 500;
                chartMes.ChartAreas["Interior"].AxisY.Interval = 1000;
                chartMes.ChartAreas["Interior"].AxisX.Interval = 1;
            }
            catch { }

            //Paleta de cores

            chartMes.Palette = ChartColorPalette.Fire;
        }

        private void PreencherInformacoesDeVenda()
        {
            AtualizarDataGridVendas();

            Informacoes_Vendas Vendas_Dia = comandos.VendasDoDia(data);
            Produto Produto_dia = comandos.ProdutoMaisVendidoDoDia(data);
            decimal Meta = comandos.MetaDoDia(data);

            int produtos_vendidos_dia = Vendas_Dia.Produtos_Vendidos;
            int vendas_dia = Vendas_Dia.Qtd_Vendas;
            decimal receita_dia = Vendas_Dia.Receita_Vendas;

            decimal tm_dia = Vendas_Dia.Ticket_Medio;


            string mais_vendido_dia = Produto_dia.Nome_Produto;
            decimal qtd_vendido_dia = Produto_dia.Caixa;

            textBoxVendido.Text = receita_dia.ToString("C");
            textBoxProdutos.Text = produtos_vendidos_dia.ToString();
            textBoxVendas.Text = vendas_dia.ToString();
            textBoxTicket.Text = tm_dia.ToString("C");
            textBoxMeta.Text = Meta.ToString("C");
            textBoxTop.Text = mais_vendido_dia + " (" + qtd_vendido_dia + ")";
        }


        private void PreencherDashboard()
        {
            Informacoes_Vendas Vendas_Mes = comandos.VendasDoMes(data);

            textBoxReceitas.Text = Vendas_Mes.Receita_Vendas.ToString("F");
        }

        private void buttonSaldo_Click(object sender, EventArgs e)
        {
            formFinanceiroSaldo saldo = new formFinanceiroSaldo();
            saldo.ShowDialog();
        }

        private void dataGridViewVendas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridViewVendas.Rows[e.RowIndex].Cells[0].Value);
                formVendasCaixaVenda venda = new formVendasCaixaVenda(id);
                venda.ShowDialog();
            }
            catch { }
        }

        private void buttonMetas_Click(object sender, EventArgs e)
        {
            formFinanceiroPeriodos periodos = new formFinanceiroPeriodos();
            periodos.ShowDialog();
        }

        private void somatorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decimal total = 0;

            foreach (DataGridViewRow linha in dataGridViewVendas.SelectedRows)
            {
                total = total + comandos.ConverterDinheiroEmDecimal(dataGridViewVendas.Rows[linha.Index].Cells[2].Value.ToString());
            }

            MessageBox.Show("Total: " + total.ToString("C"));
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            data = dateTimePicker.Value.Date;
            AtualizarTudo();
        }


        private void comboBoxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string data = comboBoxMes.Text;
            string[] partir = data.Split('/');
            string Mes = partir[0];
            mes = comandos.ConverterMesPorExtensoEmInt(Mes);
            ano = Convert.ToInt32(partir[1]);

            ColumnAtual.HeaderText = Mes.ToLower().PrimeiraLetraMaiuscula();
            string anterior = comandos.ConverterMesIntParaExtenso( new DateTime(ano, mes, 1).AddMonths(-1).Month);
            ColumnAnterior.HeaderText = anterior.ToLower().PrimeiraLetraMaiuscula();

            AtualizarDataGridDRE();
            PreencherGraficoDeVendasPorMes();
        }

        private void formFinanceiroGeral_Resize(object sender, EventArgs e)
        {
            //labelDRE.Left = dataGridViewDRE.Left;


            labelDRE.Left = dataGridViewDRE.Left + ((dataGridViewDRE.Width / 2) - (labelDRE.Width / 2));
        }

        private void AtualizarDataGridVendas()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewVendas.CurrentRow != null)
            {
                primeira_linha = dataGridViewVendas.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewVendas.CurrentRow.Index;
            }

            List<ProdutoVenda> lista_vendas = comandos.UltimasVendas(data);

            dataGridViewVendas.Rows.Clear();

            if (lista_vendas.Count > 0)
            {
                labelAvisoVendas.Visible = false;
                foreach (ProdutoVenda row in lista_vendas)
                {
                    int id = row.ID_Produto;
                    int quantidade = row.Quantidade;
                    decimal valor = row.Total;
                    string hora = row.Hora;

                    dataGridViewVendas.Rows.Add(id, quantidade, valor.ToString("C"), hora);
                }
            }
            else
            {
                labelAvisoVendas.Visible = true;
            }

            try
            {
                dataGridViewVendas.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewVendas.CurrentCell = dataGridViewVendas.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewVendas.CurrentRow != null)
                dataGridViewVendas.CurrentRow.Selected = false;
        }

        private void AtualizarDataGridDRE()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewDRE.CurrentRow != null)
            {
                primeira_linha = dataGridViewDRE.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewDRE.CurrentRow.Index;
            }

            dataGridViewDRE.Rows.Clear();

            comandos.CarregarDREnoDGV(mes, ano, dataGridViewDRE);

            try
            {
                dataGridViewDRE.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewDRE.CurrentCell = dataGridViewDRE.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewDRE.CurrentRow != null)
                dataGridViewDRE.CurrentRow.Selected = false;
        }

        private void dataGridViewDRE_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (dataGridViewDRE[e.ColumnIndex, e.RowIndex].Value.ToString().Contains("Lucro"))
                {
                    dataGridViewDRE.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Arial", 7, FontStyle.Bold, GraphicsUnit.Point);
                }
            }
        }

        private void pbProximo_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddDays(1);
        }

        private void pbAnterior_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddDays(-1);
        }

        private void pictureBoxAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarTudo();
        }
    }
}
