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
    public partial class formRelatorioCupomMovimentacoes : Form
    {
        public formRelatorioCupomMovimentacoes()
        {
            InitializeComponent();
        }

        private void formCupomMovimentacoes_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
