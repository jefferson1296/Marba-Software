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
    public partial class formRelatorioVisualizarPedido : Form
    {
        public formRelatorioVisualizarPedido()
        {
            InitializeComponent();
        }

        private void formRelatorioVisualizarPedido_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'ProcedureVisualizarPedidos.VisualizarPedidos'. Você pode movê-la ou removê-la conforme necessário.
            this.VisualizarPedidosTableAdapter.Fill(this.ProcedureVisualizarPedidos.VisualizarPedidos);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
