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
    public partial class formGestaoFerramentasGerarCodigo : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formGestaoFerramentasGerarCodigo()
        {
            InitializeComponent();
        }

        private void carregarButton_Click(object sender, EventArgs e)
        {
            string codigo = textBoxCodigo.Text;

            if (codigo == string.Empty)
            {
                MessageBox.Show("Informe o texto para continuar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string cod128 = comandos.ConverterStringParaCod128(codigo);
                formRepCod128 gerar_codigo = new formRepCod128(codigo, cod128);
                gerar_codigo.ShowDialog();
            }
        }
    }
}
