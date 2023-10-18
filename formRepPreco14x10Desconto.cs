using Microsoft.Reporting.WinForms;
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
    public partial class formRepPreco14x10Desconto : Form
    {
        List<ProdutoEtiqueta> produtos = new List<ProdutoEtiqueta>();
        public formRepPreco14x10Desconto()
        {
            InitializeComponent();
        }
        public formRepPreco14x10Desconto(List<ProdutoEtiqueta> Produtos)
        {
            InitializeComponent();
            produtos = Produtos;
        }

        private void formRepPreco14x10Desconto_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetDesconto", produtos));
            this.reportViewer1.RefreshReport();
        }
    }
}
