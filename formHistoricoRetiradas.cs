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
    public partial class formHistoricoRetiradas : Form
    {
        BindingSource binding = new BindingSource();
        ComandosSQL comandos = new ComandosSQL();
        public formHistoricoRetiradas()
        {
            InitializeComponent();
        }

        private void formHistoricoRetiradas_Load(object sender, EventArgs e)
        {
            comandos.PreencherDataGridHistoricoRetiradas(binding, dataGridViewLista);
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonFinalizar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void textBoxPesquisa_Enter(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text == "Informe o N° da Retirada")
            {
                textBoxPesquisa.Text = string.Empty;
                textBoxPesquisa.ForeColor = Color.Black;
            }
        }
        private void textBoxPesquisa_Leave(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text == string.Empty)
            {
                textBoxPesquisa.Text = "Informe o N° da Retirada";
                textBoxPesquisa.ForeColor = Color.Gray;
            }
        }
        private void textBoxPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text != "Informe o N° da Retirada")
                this.binding.Filter = "CPF like '%" + textBoxPesquisa.Text + "%'";
        }
    }
}
