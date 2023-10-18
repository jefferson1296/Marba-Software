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
    public partial class formGestaoExpedientesImprimir : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formGestaoExpedientesImprimir()
        {
            InitializeComponent();
        }

        public formGestaoExpedientesImprimir(DateTime Data)
        {
            InitializeComponent();
            dateTimePicker1.Value = Data;
        }

        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            bool imprimir = radioButtonImprimir.Checked;
            DateTime data = dateTimePicker1.Value.Date;

            comandos.ImprimirExpedienteDoDia(data, imprimir);
            Dispose();
        }
    }
}
