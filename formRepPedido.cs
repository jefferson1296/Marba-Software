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
    public partial class formRepPedido : Form
    {
        public formRepPedido()
        {
            InitializeComponent();
        }

        private void formRepPedido_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'DataSetVisualizarPedidos.VisualizarPedidos'. Você pode movê-la ou removê-la conforme necessário.
            this.VisualizarPedidosTableAdapter.Fill(this.DataSetVisualizarPedidos.VisualizarPedidos);

            this.reportViewer1.RefreshReport();
        }
    }
}
