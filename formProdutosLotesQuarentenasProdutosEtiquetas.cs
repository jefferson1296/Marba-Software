using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarbaSoftware
{
    public partial class formProdutosLotesQuarentenasProdutosEtiquetas : Form
    {
        List<ProdutoEtiqueta> lista = new List<ProdutoEtiqueta>();

        public formProdutosLotesQuarentenasProdutosEtiquetas()
        {
            InitializeComponent();
        }

        public formProdutosLotesQuarentenasProdutosEtiquetas(List<ProdutoEtiqueta> Lista)
        {
            InitializeComponent();
            lista = Lista;
        }

        private void formProdutosLotesQuarentenasProdutosEtiquetas_Load(object sender, EventArgs e)
        {
            comboBoxImpressora.Items.Clear();

            PrinterSettings.StringCollection impressoras = PrinterSettings.InstalledPrinters;
            foreach (string i in impressoras)
            {
                comboBoxImpressora.Items.Add(i);
            }

            comboBoxImpressora.SelectedItem = "ELGIN L42Pro";

            AtualizarDataGrid();
        }

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            var etiquetas = lista.GroupBy(x => (x.Produto, x.Codigo, x.Imprimir)).Select(g => (g.Key.Produto, g.Key.Codigo, g.Key.Imprimir, Total: g.Sum(x => x.Quantidade)));

            dataGridViewLista.Rows.Clear();

            foreach (var produto in etiquetas)
            {
                dataGridViewLista.Rows.Add(produto.Produto, produto.Codigo, produto.Total,  produto.Imprimir);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }

        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                bool imprimir = !Convert.ToBoolean(dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                string produto = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                string codigo = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();

                foreach (ProdutoEtiqueta Produto in lista)
                {
                    if (Produto.Produto == produto && Produto.Codigo == codigo)
                    {
                        Produto.Imprimir = imprimir;
                    }
                }

                AtualizarDataGrid();
            }
        }

        private void checkBoxTudo_CheckedChanged(object sender, EventArgs e)
        {
            bool imprimir = checkBoxTudo.Checked;

            foreach (ProdutoEtiqueta Produto in lista)
            {
                Produto.Imprimir = imprimir;
            }

            AtualizarDataGrid();
        }

        private void buttonListas_Click(object sender, EventArgs e)
        {
            string impressora = comboBoxImpressora.Text;

            ImprimirEtiquetaTermica32x17mm(1, impressora);
            Dispose();
        }

        private void ImprimirEtiquetaTermica32x17mm(int coluna, string impressora)
        {
            int posicao_texto_y = 24;
            int posicao_codigo_y = 48;

            StringBuilder sb = new StringBuilder();

            int linhas = lista.Count / 3;
            if (lista.Count % 3 > 0) { linhas++; }
            int altura_da_etiqueta = (20 * linhas * 8) - 24;

            sb.AppendLine();
            sb.AppendLine("N"); //Limpa completamente o Buffer
            sb.AppendLine("D9"); //Configura a densidade ou aquecimento da cabeça de impressão para 9
            sb.AppendLine("S3"); //Velocidade de impressão: 3 polegadas / segundo
            sb.AppendLine("JF"); //Habilita o 'backfeed', para que o espaço entre as etiquetas pare em direção à serrilha
            sb.AppendLine("ZT"); //Indica que a impressão deve começar a partir do topo, ou seja, de cabeça para baixo
            sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "Q{0},24", altura_da_etiqueta)); //Configura a altura da etiqueta Q136/8 = 17mm e altura do espaço entre etiquetas 24/8 = 3mm)
            sb.AppendLine("q800"); //Configura a largura total da etiqueta: 800/8 = 100mm)

            int i = 0;

            string tipo_codigo;
            int linha_fina;
            int linha_grossa;

            foreach (ProdutoEtiqueta etiqueta in lista)
            {
                string produto = etiqueta.Produto;
                if (produto.Length > 24) { produto = produto.Substring(0, 24); }
                string codigo = etiqueta.Codigo;

                #region informações para inserir texto

                //Tipo de dados: Texto + Coordenada x, 
                //Coordenada y, 
                //Rotação da impressão
                //Tamanho da fonte, 
                //Multiplica horizontal, 
                //multiplica vertical, 
                //Reversão, 
                //Dados a serem impressos

                //PARA MAIS DETALHES, CONSULTE O MANUAL DA ELGIN

                #endregion
                #region informações para inserir código de barras

                //Tipo de dados: Código de barras, Coordenada x, 
                //Coordenada y, 
                //Rotação da impressão
                //Simbologia do código, 
                //Largura da barra fina em pontos, 
                //Largura da barra grossa em pontos, 
                //Altura das barras em pontos, 
                //Exibir números (N = não, B = Sim), 
                //Dados a serem impressos

                #endregion

                if (codigo.Length == 13)
                {
                    tipo_codigo = "E30";
                    linha_fina = 2;
                    linha_grossa = 2;
                }
                else if (codigo.Length == 8)
                {
                    tipo_codigo = "E80";
                    linha_fina = 3;
                    linha_grossa = 3;
                }
                else
                {
                    tipo_codigo = "1E";
                    linha_fina = 2;
                    linha_grossa = 2;
                }

                if (coluna == 1)
                {
                    //Inicia com 4mm da borda de impressão (2mm do rolo + 2mm da margem da etiqueta)

                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A32,{1},0,1,1,1,N,\"{0}\"", produto, posicao_texto_y));
                    //sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B32,{1},0,1A,1,1,48,B,\"{0}\"", codigo, posicao_codigo_y));
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B32,{1},0,{2},{3},{4},48,B,\"{0}\"", codigo, posicao_codigo_y, tipo_codigo, linha_fina, linha_grossa));

                    coluna++;
                }
                else if (coluna == 2)
                {
                    //Inicia com 4mm da borda de impressão (2mm do rolo + 2mm da margem da etiqueta)

                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A288,{1},0,1,1,1,N,\"{0}\"", produto, posicao_texto_y));
                    //sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B288,{1},0,1A,1,1,48,B,\"{0}\"", codigo, posicao_codigo_y));
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B288,{1},0,{2},{3},{4},48,B,\"{0}\"", codigo, posicao_codigo_y, tipo_codigo, linha_fina, linha_grossa));

                    coluna++;
                }
                else if (coluna == 3)
                {
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A544,{1},0,1,1,1,N,\"{0}\"", produto, posicao_texto_y));
                    //sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B544,{1},0,1A,1,1,48,B,\"{0}\"", codigo, posicao_codigo_y));
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B544,{1},0,{2},{3},{4},48,B,\"{0}\"", codigo, posicao_codigo_y, tipo_codigo, linha_fina, linha_grossa));

                    coluna = 1;
                    //posicao_texto_y = posicao_texto_y + 160;
                    //posicao_codigo_y = posicao_codigo_y + 160;
                }

                i++;
                if (coluna == 1 || lista.Count == i)
                {
                    sb.AppendLine("P1");
                    RawPrinterHelper.SendStringToPrinter(impressora, sb.ToString());

                    sb.Clear();
                    sb.AppendLine();
                    sb.AppendLine("N"); //Limpa completamente o Buffer
                    sb.AppendLine("D9"); //Configura a densidade ou aquecimento da cabeça de impressão para 9
                    sb.AppendLine("S3"); //Velocidade de impressão: 3 polegadas / segundo
                    sb.AppendLine("JF"); //Habilita o 'backfeed', para que o espaço entre as etiquetas pare em direção à serrilha
                    sb.AppendLine("ZT"); //Indica que a impressão deve começar a partir do topo, ou seja, de cabeça para baixo
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "Q{0},24", altura_da_etiqueta)); //Configura a altura da etiqueta Q136/8 = 17mm e altura do espaço entre etiquetas 24/8 = 3mm)
                    sb.AppendLine("q800"); //Configura a largura total da etiqueta: 800/8 = 100mm)
                }
            }

            //sb.AppendLine("P1"); //Inidica a quantidade etiquetas a serem impressas (neste caso, 1)


            //if (DialogResult.OK == pd.ShowDialog(this))
            //{
            //    RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, sb.ToString());
            //}
        }
    }
}
