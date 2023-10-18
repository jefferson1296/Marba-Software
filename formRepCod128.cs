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
    public partial class formRepCod128 : Form
    {
        string codigo;
        string cod128;
        public formRepCod128()
        {
            InitializeComponent();
        }
        public formRepCod128(string Codigo, string Cod128)
        {
            InitializeComponent();
            codigo = Codigo;
            cod128 = Cod128;
        }

        private void formRepCod128_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.SetParameters(new ReportParameter("codigo", codigo));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("cod128", cod128));
            reportViewer1.RefreshReport();
        }
    }
}
