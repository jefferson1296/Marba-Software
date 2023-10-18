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
    public partial class formRepCupomCaixaAtual : Form
    {
        public formRepCupomCaixaAtual()
        {
            InitializeComponent();
        }

        private void formCupomCaixaAtual_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
