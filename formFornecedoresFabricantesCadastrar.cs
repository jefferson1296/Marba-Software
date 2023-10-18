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
    public partial class formFornecedoresFabricantesCadastrar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formFornecedoresFabricantesCadastrar()
        {
            InitializeComponent();
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            string fabricante = textBoxFabricante.Text;
            string cnpj = textBoxCNPJ.Text;
            string endereco = textBoxEndereco.Text;

            if (fabricante == string.Empty)
            {
                MessageBox.Show("Preencha o fabricante para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Fabricante Fabricante = new Fabricante { Nome_Fabricante = fabricante, CNPJ = cnpj, Endereco = endereco };
                comandos.CadastrarFabricante(Fabricante);
                Dispose();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void textBoxCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
    }
}
