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
    public partial class formGestaoMeta : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<MetaDiaria> Metas = new List<MetaDiaria>();

        int id_estabelecimento;
        List<Estabelecimento> estabelecimentos = new List<Estabelecimento>();

        public formGestaoMeta()
        {
            InitializeComponent();
        }

        private void formTelaInicialPrincipalGestaoMeta_Load(object sender, EventArgs e)
        {
            id_estabelecimento = comandos.TrazerIdDoEstabelecimentoPelaReparticao(Program.Computador.ID_Reparticao);
            AtualizarEstabelecimentos();
            comboBoxEstabelecimentos.SelectedValue = id_estabelecimento;

            List<string> Meses = comandos.MesesDeVendaMarbaSoftware();
            foreach (string Mes in Meses) { comboBoxMes.Items.Add(Mes); }

            comboBoxMes.SelectedItem = comandos.ConverterMesIntParaExtenso(DateTime.Now.Month).ToUpper() + "/" + DateTime.Now.Year.ToString();
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

        private void AtualizarDataGrid(int mes, int ano)
        {
            Metas = comandos.ListaDeMetasDiariasDoMes(mes, ano, id_estabelecimento);

            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            dataGridViewLista.Rows.Clear();

            foreach (MetaDiaria Meta in Metas)
            {
                DateTime data = Meta.Dia;
                string dia_da_semana = Meta.Dia_da_semana;
                decimal equilibrio = Meta.Equilibrio;
                decimal simulador = Meta.Simulador;
                decimal meta = Meta.Meta;
                decimal apurado = Meta.Vendido;

                string status;
                bool feriado = comandos.VerificarFeriadoComLojaFechada(data);
                if (feriado) { status = "Feriado"; }
                else { status = "Aberto"; }

                if (status == "Feriado")
                {
                    dataGridViewLista.Rows.Add(data.ToShortDateString(), dia_da_semana, status, status, status, status);
                }
                else
                {
                    if (apurado > 0)
                    {
                        dataGridViewLista.Rows.Add(data.ToShortDateString(), dia_da_semana, equilibrio.ToString("C"), simulador.ToString("C"), meta.ToString("C"), apurado.ToString("C"));
                    }
                    else
                    {
                        dataGridViewLista.Rows.Add(data.ToShortDateString(), dia_da_semana, equilibrio.ToString("C"), simulador.ToString("C"), meta.ToString("C"), "- - -");
                    }
                }
                
            }

            foreach (DataGridViewRow linha in dataGridViewLista.Rows)
            {
                string valor = dataGridViewLista.Rows[linha.Index].Cells[5].Value.ToString();
                if (valor != "Feriado" && valor != "- - -")
                {
                    decimal equilibrio = comandos.ConverterDinheiroEmDecimal(dataGridViewLista.Rows[linha.Index].Cells[2].Value.ToString());
                    decimal simulador = comandos.ConverterDinheiroEmDecimal(dataGridViewLista.Rows[linha.Index].Cells[3].Value.ToString());
                    decimal meta = comandos.ConverterDinheiroEmDecimal(dataGridViewLista.Rows[linha.Index].Cells[4].Value.ToString());
                    decimal apurado = comandos.ConverterDinheiroEmDecimal(dataGridViewLista.Rows[linha.Index].Cells[5].Value.ToString());

                    if (equilibrio > apurado) { dataGridViewLista.Rows[linha.Index].Cells[2].Style.ForeColor = Color.DarkRed; dataGridViewLista.Rows[linha.Index].Cells[2].Style.SelectionForeColor = Color.DarkRed; }
                    else { dataGridViewLista.Rows[linha.Index].Cells[2].Style.ForeColor = Color.Green; dataGridViewLista.Rows[linha.Index].Cells[2].Style.SelectionForeColor = Color.Green; }
                    if (simulador > apurado) { dataGridViewLista.Rows[linha.Index].Cells[3].Style.ForeColor = Color.DarkRed; dataGridViewLista.Rows[linha.Index].Cells[3].Style.SelectionForeColor = Color.DarkRed; }
                    else { dataGridViewLista.Rows[linha.Index].Cells[3].Style.ForeColor = Color.Green; dataGridViewLista.Rows[linha.Index].Cells[3].Style.SelectionForeColor = Color.Green; }
                    if (meta > apurado) { dataGridViewLista.Rows[linha.Index].Cells[4].Style.ForeColor = Color.DarkRed; dataGridViewLista.Rows[linha.Index].Cells[4].Style.SelectionForeColor = Color.DarkRed; }
                    else { dataGridViewLista.Rows[linha.Index].Cells[4].Style.ForeColor = Color.Green; dataGridViewLista.Rows[linha.Index].Cells[4].Style.SelectionForeColor = Color.Green; }
                }
            }

            decimal equilibrio_total = Metas.Where(x => x.Vendido > 0).Sum(x => x.Equilibrio);
            decimal simulador_total = Metas.Where(x => x.Vendido > 0).Sum(x => x.Simulador);
            decimal meta_total = Metas.Where(x => x.Vendido > 0).Sum(x => x.Meta);
            decimal apurado_total = Metas.Where(x => x.Vendido > 0).Sum(x => x.Vendido);

            textBoxEquilibrio.Text = equilibrio_total.ToString("C");
            textBoxEstimativa.Text = simulador_total.ToString("C");
            textBoxMeta.Text = meta_total.ToString("C");
            textBoxApurado.Text = apurado_total.ToString("C");

            if (equilibrio_total > apurado_total) { textBoxEquilibrio.ForeColor = Color.DarkRed; } else { textBoxEquilibrio.ForeColor = Color.Green; }
            if (simulador_total > apurado_total) { textBoxEstimativa.ForeColor = Color.DarkRed; } else { textBoxEstimativa.ForeColor = Color.Green; }
            if (meta_total > apurado_total) { textBoxMeta.ForeColor = Color.DarkRed; } else { textBoxMeta.ForeColor = Color.Green; }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }
        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                try
                {
                    if (dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Feriado" || dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "- - -")
                    {
                        DataGridViewRow linhaestilizada = dataGridViewLista.Rows[e.RowIndex];
                        //linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        linhaestilizada.DefaultCellStyle.ForeColor = Color.Silver;
                        linhaestilizada.DefaultCellStyle.SelectionForeColor = Color.Silver;
                    }
                }
                catch { }
            }
        }

        private void comboBoxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarData();
        }

        private void AtualizarData()
        {
            string periodo = comboBoxMes.Text;

            if (periodo != string.Empty)
            {
                string[] partir = periodo.Split('/');
                string Mes = partir[0];
                int mes = comandos.ConverterMesPorExtensoEmInt(Mes);
                int ano = Convert.ToInt32(partir[1]);

                AtualizarDataGrid(mes, ano);
                InformacoesDaMeta(periodo);
            }
        }

        private void InformacoesDaMeta(string periodo)
        {
            try
            {
                decimal meta = comandos.MetaDoMes(periodo, id_estabelecimento);
                textBoxMetaMes.Text = meta.ToString("C");

                decimal apurado = comandos.ConverterDinheiroEmDecimal(textBoxApurado.Text);
                decimal restante = meta - apurado;
                decimal percentual = apurado / (meta / 100);

                if (restante < 0) { restante = 0; percentual = 0; }

                textBoxRestante.Text = restante.ToString("C");
                textBoxProgresso.Text = percentual.ToString("F") + "%";
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void comboBoxEstabelecimentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxEstabelecimentos.SelectedValue != null)
                {
                    id_estabelecimento = (int)comboBoxEstabelecimentos.SelectedValue;
                    AtualizarData(); 
                }
            }
            catch { }
        }
    }
}
