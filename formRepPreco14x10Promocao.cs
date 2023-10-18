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
    public partial class formRepPreco14x10Promocao : Form
    {
        public formRepPreco14x10Promocao()
        {
            InitializeComponent();
        }

        private void formRepPreco14x10Promocao_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'GerarEtiquetasDataSet.GerarEtiquetas'. Você pode movê-la ou removê-la conforme necessário.
            this.GerarEtiquetasTableAdapter.Fill(this.GerarEtiquetasDataSet.GerarEtiquetas);

            this.reportViewer1.RefreshReport();
        }
    }
}
