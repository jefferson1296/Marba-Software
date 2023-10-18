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
    public partial class formGestaoFerramentas : Form
    {
        public formGestaoFerramentas()
        {
            InitializeComponent();
        }

        private void buttonSwot_Click(object sender, EventArgs e)
        {
            formGestaoFerramentasSwot swot = new formGestaoFerramentasSwot();
            swot.ShowDialog();
        }

        private void buttonPlanos_Click(object sender, EventArgs e)
        {
            formGestaoFerramentasPlanos planos = new formGestaoFerramentasPlanos();
            planos.ShowDialog();
        }

        private void buttonControle_Click(object sender, EventArgs e)
        {
            formGestaoControle controle = new formGestaoControle();
            controle.ShowDialog();
        }

        private void buttonOrcamento_Click(object sender, EventArgs e)
        {
            formFinanceiroSimulador orcamento = new formFinanceiroSimulador();
            orcamento.ShowDialog();
        }

        private void buttonCodigo_Click(object sender, EventArgs e)
        {
            formGestaoFerramentasGerarCodigo codigo = new formGestaoFerramentasGerarCodigo();
            codigo.ShowDialog();
        }
    }
}
