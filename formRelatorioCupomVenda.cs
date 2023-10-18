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
    public partial class formRelatorioCupomVenda : Form
    {
        public formRelatorioCupomVenda()
        {
            InitializeComponent();
        }

        private void formRelatorioCupomVenda_Load(object sender, EventArgs e)
        {
            using (bd_MarbaConnection marba = new bd_MarbaConnection())
            {
                string matricula = Program.matricula;
                PreencherCupomVendas_ResultBindingSource.DataSource = marba.PreencherCupomVendas(matricula).ToList();
                //reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("operador", operador));
            }
            reportViewer1.RefreshReport();
        }
        public void Imprimir()
        {
            LocalReport report = reportViewer1.LocalReport;
            //report.ReportEmbeddedResource = @"RepCupomVendas.rdlc";
            report.DataSources.Add(new ReportDataSource("DataSet1", PreencherCupomVendas_ResultBindingSource));
            report.PrintToPrinter();
        }

    }
}
