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
    public partial class formGestaoAtividadesDelegaveis : Form
    {
        public formGestaoAtividadesDelegaveis()
        {
            InitializeComponent();
        }

        private void buttonDelegavel_Click(object sender, EventArgs e)
        {
            formGestaoAtividadesDelegaveisDelegavel delegavel = new formGestaoAtividadesDelegaveisDelegavel();
            delegavel.ShowDialog();
        }

        private void buttonAtividade_Click(object sender, EventArgs e)
        {
            formTelaInicialAtividadesDelegar delegavel = new formTelaInicialAtividadesDelegar();
            delegavel.ShowDialog();
        }

        private void buttonAberto_Click(object sender, EventArgs e)
        {
            formGestaoAtividadesDelegaveisEmAberto em_aberto = new formGestaoAtividadesDelegaveisEmAberto();
            em_aberto.ShowDialog();
        }
    }
}
