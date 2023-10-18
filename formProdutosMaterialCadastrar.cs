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
    public partial class formProdutosMaterialCadastrar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formProdutosMaterialCadastrar()
        {
            InitializeComponent();
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            string material = materialTextBox.Text;

            if (material == string.Empty)
            {
                MessageBox.Show("Preencha o material para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comandos.VerificarSeMaterialJaExiste(material))
            {
                MessageBox.Show("Esse material já está cadastrado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                comandos.CadastrarMateriaPrima(material);
                Dispose();
            }
        }
    }
}
