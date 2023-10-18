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
    public partial class formFinanceiroRelatorios : Form
    {
        public formFinanceiroRelatorios()
        {
            InitializeComponent();
        }

        private void buttonDiario_Click(object sender, EventArgs e)
        {
            formFinanceiroRelatoriosDiario diario = new formFinanceiroRelatoriosDiario();
            diario.ShowDialog();
        }

        private void buttonDRE_Click(object sender, EventArgs e)
        {
            formFinanceiroRelatoriosDRE dre = new formFinanceiroRelatoriosDRE("DRE");
            dre.ShowDialog();
        }

        private void buttonDespesa_Click(object sender, EventArgs e)
        {
            formFinanceiroRelatoriosDRE dre = new formFinanceiroRelatoriosDRE("Despesas por categoria");
            dre.ShowDialog();
        }
    }
}
