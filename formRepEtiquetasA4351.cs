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
    public partial class formRepEtiquetasA4351 : Form
    {
        public formRepEtiquetasA4351()
        {
            InitializeComponent();
        }

        private void formRepEtiquetasA4351_Load(object sender, EventArgs e)
        {
            this.GerarEtiquetasTableAdapter.Fill(this.GerarEtiquetasDataSet.GerarEtiquetas);
            // TODO: esta linha de código carrega dados na tabela 'GerarEtiquetasDataSet.GerarEtiquetas'. Você pode movê-la ou removê-la conforme necessário.
            this.reportViewer1.RefreshReport();
        }
    }
}
