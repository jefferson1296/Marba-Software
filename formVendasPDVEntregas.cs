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
    public partial class formVendasPDVEntregas : Form
    {
        public formVendasPDVEntregas()
        {
            InitializeComponent();
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formVendasPDVEntregas_Load(object sender, EventArgs e)
        {
            ComandosSQL comando = new ComandosSQL();
            comando.PreencherDataGridEntregas(dataGridViewLista);
        }
    }
}
