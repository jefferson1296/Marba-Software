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
    public partial class formProdutosEtiquetasImprimir : Form
    {
        List<ProdutoEtiqueta> lista;
        formProdutosEtiquetas etiquetas = new formProdutosEtiquetas();
        formProdutosEntradaDarEntrada entrada = new formProdutosEntradaDarEntrada();
        
        ComandosSQL comandos = new ComandosSQL();
        public formProdutosEtiquetasImprimir()
        {
            InitializeComponent();
        }
        public formProdutosEtiquetasImprimir(List<ProdutoEtiqueta> Lista, formProdutosEtiquetas Etiquetas)
        {
            lista = Lista;
            etiquetas = Etiquetas;
            InitializeComponent();
        }
        public formProdutosEtiquetasImprimir(List<ProdutoEtiqueta> Lista, formProdutosEntradaDarEntrada Entrada)
        {
            lista = Lista;
            entrada = Entrada;
            InitializeComponent();
        }
        private void tipoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tipoComboBox.SelectedIndex == 0 || tipoComboBox.SelectedIndex == 1)
            {
                if (posicaoTextBox.Enabled == false)
                    posicaoTextBox.Enabled = true;
            }
            else
            {
                if (posicaoTextBox.Enabled == true)
                {
                    posicaoTextBox.Text = "1";
                    posicaoTextBox.Enabled = false;
                }
            }

            if (tipoComboBox.Text == "Etiqueta 32x17mm" || tipoComboBox.Text == "Etiqueta 20x10mm" || tipoComboBox.Text == "Preço na Peça 32x17mm")
            {
                comboBoxImpressora.Items.Clear();

                PrinterSettings.StringCollection impressoras = PrinterSettings.InstalledPrinters;
                foreach (string i in impressoras)
                {
                    comboBoxImpressora.Items.Add(i);
                }

                comboBoxImpressora.SelectedItem = "ELGIN L42Pro";
            }
            else
            {
                comboBoxImpressora.SelectedIndex = -1;
                comboBoxImpressora.Enabled = false;
            }
        }
        private void tipoComboBox_DropDown(object sender, EventArgs e)
        {
            if (tipoComboBox.Items.IndexOf(string.Empty) == 0)
            {
                tipoComboBox.Items.RemoveAt(0);
            }
        }
        private void posicaoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void carregarButton_Click(object sender, EventArgs e)
        {
            lista.RemoveAll(x => x.Imprimir == false);
            etiquetas.alteracao = true;
            entrada.alteracao = true;
            int inicial = Convert.ToInt32(posicaoTextBox.Text);
            comandos.ListaParaImprimirEtiquetas(inicial, lista);
            //

            string etiqueta = tipoComboBox.Text;
            if (etiqueta == "Código (Nome e Código)")
            {
                formRepEtiquetasA4351 imprimir_etiquetas = new formRepEtiquetasA4351();
                imprimir_etiquetas.ShowDialog();
            }
            else if (etiqueta == "Preço 14x10")
            {
                formRepPreco14x10 imprimir_etiquetas = new formRepPreco14x10();
                imprimir_etiquetas.ShowDialog();
            }
            else if (etiqueta == "Preço 14x10 Promocional")
            {
                formRepPreco14x10Promocao imprimir_etiquetas = new formRepPreco14x10Promocao();
                imprimir_etiquetas.ShowDialog();
            }
            else if (etiqueta == "Preço 14x10 Desconto")
            {
                formRepPreco14x10Desconto imprimir_etiquetas = new formRepPreco14x10Desconto(lista);
                imprimir_etiquetas.ShowDialog();
            }
            else if (etiqueta == "Preço Meia Página Desconto")
            {
                formRepPrecoMeiaPaginaDesconto imprimir_etiquetas = new formRepPrecoMeiaPaginaDesconto(lista);
                imprimir_etiquetas.ShowDialog();
            }
            else if (etiqueta == "Etiqueta 32x17mm")
            {
                string impressora = comboBoxImpressora.Text;

                try
                {
                    ImprimirEtiquetaTermica32x17mm(inicial, impressora);
                }
                catch
                {
                    MessageBox.Show("Verifique se a impressora selecionada é uma impressora térmica!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }              
            }
            else if (etiqueta == "Preço na Peça 32x17mm")
            {
                string impressora = comboBoxImpressora.Text;

                try
                {
                    ImprimirPrecoNaPeca_32x17mm(inicial, impressora);
                }
                catch
                {
                    MessageBox.Show("Verifique se a impressora selecionada é uma impressora térmica!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (etiqueta == "Etiqueta 20x10mm")
            {
                string impressora = comboBoxImpressora.Text;

                try
                {
                    ImprimirEtiquetaTermica20x10mm(inicial, impressora);
                }
                catch
                {
                    MessageBox.Show("Verifique se a impressora selecionada é uma impressora térmica!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (etiqueta == "Código (Nome, Código e Preço)")
            {
                formRepEtiquetaPrecoNomeCodigo imprimir_etiquetas = new formRepEtiquetaPrecoNomeCodigo();
                imprimir_etiquetas.ShowDialog();
            }
            else if (etiqueta == "Preço individual")
            {
                formRepEtiquetaNomePreco imprimir_etiquetas = new formRepEtiquetaNomePreco();
                imprimir_etiquetas.ShowDialog();
            }
            else if (etiqueta == "Preço (Prateleira)")
            {
                formRepPrecoPrateleira imprimir_etiquetas = new formRepPrecoPrateleira();
                imprimir_etiquetas.ShowDialog();
            }
            else if (etiqueta == "Preço 1/4 Página")
            {
                formRepPrecoUmQuarto imprimir_etiquetas = new formRepPrecoUmQuarto();
                imprimir_etiquetas.ShowDialog();
            }
            else if (etiqueta == "Preço 1/4 Jardinagem")
            {
                formRepPrecoJardinagem imprimir_etiquetas = new formRepPrecoJardinagem();
                imprimir_etiquetas.ShowDialog();
            }
            else if (etiqueta == "Preço 1/2 Página")
            {
                formRepPrecoMeiaPagina imprimir_etiquetas = new formRepPrecoMeiaPagina();
                imprimir_etiquetas.ShowDialog();
            }
            else if (etiqueta == "Preço Redondo")
            {
                formRepPrecoRedondo imprimir_etiquetas = new formRepPrecoRedondo();
                imprimir_etiquetas.ShowDialog();
            }
            else if (etiqueta == "Preço Redondo Promoção")
            {
                formRepPrecoRedondoPromocao imprimir_etiquetas = new formRepPrecoRedondoPromocao();
                imprimir_etiquetas.ShowDialog();
            }
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

        private void ImprimirPrecoNaPeca_32x17mm(int coluna, string impressora)
        {
            int posicao_texto_y = 24;
            int posicao_texto2_y = 48;
            int posicao_codigo_y = 72;

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
                string preco = "R$";
                if (etiqueta.Promocao) 
                {
                    preco = preco + etiqueta.Venda_Promocional; 
                }
                else 
                {
                    preco = preco + etiqueta.Venda;
                }

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

                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A96,{1},0,4,1,1,N,\"{0}\"", preco, posicao_texto_y));
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A40,{1},0,1,1,1,N,\"{0}\"", produto, posicao_texto2_y));
                    //sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B32,{1},0,1A,1,1,48,B,\"{0}\"", codigo, posicao_codigo_y));
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B40,{1},0,{2},{3},{4},48,B,\"{0}\"", codigo, posicao_codigo_y, tipo_codigo, linha_fina, linha_grossa));

                    coluna++;
                }
                else if (coluna == 2)
                {
                    //Inicia com 4mm da borda de impressão (2mm do rolo + 2mm da margem da etiqueta)

                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A348,{1},0,4,1,1,N,\"{0}\"", preco, posicao_texto_y));
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A296,{1},0,1,1,1,N,\"{0}\"", produto, posicao_texto2_y));
                    //sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B288,{1},0,1A,1,1,48,B,\"{0}\"", codigo, posicao_codigo_y));
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B296,{1},0,{2},{3},{4},48,B,\"{0}\"", codigo, posicao_codigo_y, tipo_codigo, linha_fina, linha_grossa));

                    coluna++;
                }
                else if (coluna == 3)
                {
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A608,{1},0,4,1,1,N,\"{0}\"", preco, posicao_texto_y));
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A608,{1},0,1,1,1,N,\"{0}\"", produto, posicao_texto2_y));
                    //sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B544,{1},0,1A,1,1,48,B,\"{0}\"", codigo, posicao_codigo_y));
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B552,{1},0,{2},{3},{4},48,B,\"{0}\"", codigo, posicao_codigo_y, tipo_codigo, linha_fina, linha_grossa));

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

        private void ImprimirEtiquetaTermica20x10mm(int coluna, string impressora)
        {
            int posicao_texto_y = 16;
            int posicao_codigo_y = 32;

            StringBuilder sb = new StringBuilder();

            int linhas = lista.Count / 5;
            if (lista.Count % 5 > 0) { linhas++; }

            sb.AppendLine();
            sb.AppendLine("N"); //Limpa completamente o Buffer
            sb.AppendLine("D15"); //Configura a densidade ou aquecimento da cabeça de impressão para 9
            sb.AppendLine("S3"); //Velocidade de impressão: 3 polegadas / segundo
            sb.AppendLine("JF"); //Habilita o 'backfeed', para que o espaço entre as etiquetas pare em direção à serrilha
            sb.AppendLine("ZT"); //Indica que a impressão deve começar a partir do topo, ou seja, de cabeça para baixo
            sb.AppendLine("Q80,16"); //Configura a altura da etiqueta Q136/8 = 17mm e altura do espaço entre etiquetas 24/8 = 3mm)
            sb.AppendLine("q848"); //Configura a largura total da etiqueta: 848/8 = 106mm)

            int i = 0;

            string tipo_codigo;
            int linha_fina;
            int linha_grossa;

            foreach (ProdutoEtiqueta etiqueta in lista)
            {
                string produto = etiqueta.Produto;
                if (produto.Length > 10) { produto = produto.Substring(0, 10); }
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
                    linha_fina = 1;
                    linha_grossa = 1;
                }
                else if (codigo.Length == 8)
                {
                    tipo_codigo = "E80";
                    linha_fina = 1;
                    linha_grossa = 1;
                }
                else
                {
                    tipo_codigo = "1E";
                    linha_fina = 1;
                    linha_grossa = 1;
                }

                tipo_codigo = "E30";
                linha_fina = 1;
                linha_grossa = 1;

                if (coluna == 1)
                {
                    //Inicia com 4mm da borda de impressão (2mm do rolo + 2mm da margem da etiqueta)

                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A40,{1},0,1,1,1,N,\"{0}\"", produto, posicao_texto_y));
                    //sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B32,{1},0,1A,1,1,48,B,\"{0}\"", codigo, posicao_codigo_y));
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B40,{1},0,{2},{3},{4},24,B,\"{0}\"", codigo, posicao_codigo_y, tipo_codigo, linha_fina, linha_grossa));

                    coluna++;
                }
                else if (coluna == 2)
                {
                    //Inicia com 4mm da borda de impressão (2mm do rolo + 2mm da margem da etiqueta)

                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A200,{1},0,1,1,1,N,\"{0}\"", produto, posicao_texto_y));
                    //sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B288,{1},0,1A,1,1,48,B,\"{0}\"", codigo, posicao_codigo_y));
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B200,{1},0,{2},{3},{4},24,B,\"{0}\"", codigo, posicao_codigo_y, tipo_codigo, linha_fina, linha_grossa));

                    coluna++;
                }
                else if (coluna == 3)
                {
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A360,{1},0,1,1,1,N,\"{0}\"", produto, posicao_texto_y));
                    //sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B544,{1},0,1A,1,1,48,B,\"{0}\"", codigo, posicao_codigo_y));
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B360,{1},0,{2},{3},{4},24,B,\"{0}\"", codigo, posicao_codigo_y, tipo_codigo, linha_fina, linha_grossa));

                    coluna++;
                    //posicao_texto_y = posicao_texto_y + 160;
                    //posicao_codigo_y = posicao_codigo_y + 160;
                }
                else if (coluna == 4)
                {
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A520,{1},0,1,1,1,N,\"{0}\"", produto, posicao_texto_y));
                    //sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B544,{1},0,1A,1,1,48,B,\"{0}\"", codigo, posicao_codigo_y));
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B520,{1},0,{2},{3},{4},24,B,\"{0}\"", codigo, posicao_codigo_y, tipo_codigo, linha_fina, linha_grossa));

                    coluna++;
                }
                else if (coluna == 5)
                {
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A680,{1},0,1,1,1,N,\"{0}\"", produto, posicao_texto_y));
                    //sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B544,{1},0,1A,1,1,48,B,\"{0}\"", codigo, posicao_codigo_y));
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B680,{1},0,{2},{3},{4},24,B,\"{0}\"", codigo, posicao_codigo_y, tipo_codigo, linha_fina, linha_grossa));

                    coluna = 1;
                }

                i++;
                if (coluna == 1 || lista.Count == i)
                {
                    sb.AppendLine("P1");
                    RawPrinterHelper.SendStringToPrinter(impressora, sb.ToString());

                    sb.Clear();
                    sb.AppendLine();
                    sb.AppendLine("N"); //Limpa completamente o Buffer
                    sb.AppendLine("D15"); //Configura a densidade ou aquecimento da cabeça de impressão para 9
                    sb.AppendLine("S3"); //Velocidade de impressão: 3 polegadas / segundo
                    sb.AppendLine("JF"); //Habilita o 'backfeed', para que o espaço entre as etiquetas pare em direção à serrilha
                    sb.AppendLine("ZT"); //Indica que a impressão deve começar a partir do topo, ou seja, de cabeça para baixo
                    sb.AppendLine("Q80,16"); //Configura a altura da etiqueta Q136/8 = 17mm e altura do espaço entre etiquetas 24/8 = 3mm)
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
