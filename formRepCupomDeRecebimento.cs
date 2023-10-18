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
    public partial class formRepCupomDeRecebimento : Form
    {
        public formRepCupomDeRecebimento()
        {
            InitializeComponent();
        }

        private void formRepCupomDeRecebimento_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
