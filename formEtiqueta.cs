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
using Neodynamic.SDK.Printing;

namespace MarbaSoftware
{
    public partial class formEtiqueta : Form
    {
        public formEtiqueta()
        {
            InitializeComponent();
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            string produto = textBoxProduto.Text;
            string codigo = textBoxCodigo.Text;

            StringBuilder sb = new StringBuilder();
            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new System.Drawing.Printing.PrinterSettings();

            sb.AppendLine();
            sb.AppendLine("N"); //Limpa completamente o Buffer
            sb.AppendLine("D9"); //Configura a densidade ou aquecimento da cabeça de impressão para 9
            sb.AppendLine("S3"); //Velocidade de impressão: 3 polegadas / segundo
            sb.AppendLine("JF"); //Habilita o 'backfeed', para que o espaço entre as etiquetas pare em direção à serrilha
            sb.AppendLine("ZT"); //Indica que a impressão deve começar a partir do topo, ou seja, de cabeça para baixo
            sb.AppendLine("Q136,24"); //Configura a altura da etiqueta Q136/8 = 17mm e altura do espaço entre etiquetas 24/8 = 3mm)
            sb.AppendLine("q256"); //Configura a largura total da etiqueta: 256/8 = 32mm)

            //Tipo de dados: Texto, Coordenada x, Coordenada y, Rotação da impressão
            //Tamanho da fonte, Multiplica horizontal, multiplica vertical, Reversão, Dados a serem impressos
            //PARA MAIS DETALHES, CONSULTE O MANUAL DA ELGIN

            sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A24,24,0,1,3,1,N,\"{0}\"", produto));

            //Tipo de dados: Código de barras, Coordenada x, Coordenada y, Rotação da impressão
            //Simbologia do código, Largura da barra fina em pontos, Largura da grossa fina em pontos, 
            //Altura das barras em pontos, Exibir números (N = não, B = Sim), Dados a serem impressos

            sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "B24,96,0,1,2,3,50,B,\"{0}\"", codigo)); 

            sb.AppendLine("P1"); //Inidica a quantidade etiquetas a serem impressas (neste caso, 1)

            if (DialogResult.OK == pd.ShowDialog(this))
            {
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, sb.ToString());
            }



            //Para criar etiquetas, uma ao lado da outra, é necessário criar métodos que transformem os números passados
            //em tabulação.
            //Se a ideia é imprimir 30 etiquetas do mesmo produto por exemplo, basta fazer um 3 sb.AppendLine com a coordenada x diferentes,
            // e enviar o comando de impressão "P10" no final do código.
            //Para facilitar, utilize o loop FOREACH
        }

    }
}
