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
    public partial class formRepListaReajustes : Form
    {
        public formRepListaReajustes()
        {
            InitializeComponent();
        }

        private void formRepListaReajustes_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'DataSetGerarListas.GerarListas'. Você pode movê-la ou removê-la conforme necessário.
            this.GerarListasTableAdapter.Fill(this.DataSetGerarListas.GerarListas);

            this.reportViewer1.RefreshReport();
        }
    }
}
