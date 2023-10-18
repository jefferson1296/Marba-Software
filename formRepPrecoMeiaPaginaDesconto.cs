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
    public partial class formRepPrecoMeiaPaginaDesconto : Form
    {
        List<ProdutoEtiqueta> produtos = new List<ProdutoEtiqueta>();

        public formRepPrecoMeiaPaginaDesconto(List<ProdutoEtiqueta> Produtos)
        {
            InitializeComponent();
            produtos = Produtos;
        }

        private void formRepPrecoMeiaPaginaDesconto_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();

            foreach (ProdutoEtiqueta produto in produtos)
            {
                decimal diferenca = Convert.ToDecimal(produto.Venda) - Convert.ToDecimal(produto.Venda_Promocional);
                decimal desconto = diferenca / (Convert.ToDecimal(produto.Venda) / 100);
                produto.Desconto = Convert.ToInt32(desconto);
            }

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", produtos));
            this.reportViewer1.RefreshReport();
        }
    }
}
