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
    public partial class formPausar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        string colaborador;
        public formPausar()
        {
            InitializeComponent();
        }
        public formPausar(string Colaborador)
        {
            InitializeComponent();
            colaborador = Colaborador;
        }
        private void buttonPausar_Click(object sender, EventArgs e)
        {
            string motivo = textBoxMotivo.Text;
            comandos.PausarAtividadeEmAndamento(colaborador, motivo);
            Dispose();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
