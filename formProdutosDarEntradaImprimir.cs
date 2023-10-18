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
    public partial class formProdutosDarEntradaImprimir : Form
    {
        List<ProdutoEtiqueta> etiquetas = new List<ProdutoEtiqueta>();
        ComandosSQL comandos = new ComandosSQL();
        bool cancelar = true;

        public formProdutosDarEntradaImprimir()
        {
            InitializeComponent();
        }
        public formProdutosDarEntradaImprimir(List<ProdutoEtiqueta> Etiquetas)
        {
            InitializeComponent();
            etiquetas = Etiquetas;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int inicial = Convert.ToInt32(posicaoTextBox.Text);
            comandos.ListaParaImprimirEtiquetas(inicial, etiquetas);
            formRepEtiquetasA4351 imprimir_etiquetas = new formRepEtiquetasA4351();
            imprimir_etiquetas.ShowDialog();
            cancelar = false;
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int inicial = Convert.ToInt32(posicaoTextBox.Text);
            comandos.ListaParaImprimirEtiquetas(inicial, etiquetas);
            formRepEtiquetaPrecoNomeCodigo imprimir_etiquetas = new formRepEtiquetaPrecoNomeCodigo();
            imprimir_etiquetas.ShowDialog();
            cancelar = false;
            Dispose();
        }

        private void formProdutosDarEntradaImprimir_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cancelar)
            {
                string texto = "Tem certeza que deseja cancelar a impressão?\r\nA lista de impressão foi gerada automaticamente. Se continuar, talvez você não possa acessá-la novamente.";

                if (DialogResult.Yes == MessageBox.Show(texto, "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
