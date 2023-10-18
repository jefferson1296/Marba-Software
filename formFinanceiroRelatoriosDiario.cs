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
    public partial class formFinanceiroRelatoriosDiario : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formFinanceiroRelatoriosDiario()
        {
            InitializeComponent();
        }

        private void buttonDiario_Click(object sender, EventArgs e)
        {
            DateTime data = dateTimePicker1.Value.Date;
            comandos.RelatorioFinanceiroDiario(data, true);
        }

        private void buttonVisualizar_Click(object sender, EventArgs e)
        {
            DateTime data = dateTimePicker1.Value.Date;
            comandos.RelatorioFinanceiroDiario(data, false);
        }
    }
}
