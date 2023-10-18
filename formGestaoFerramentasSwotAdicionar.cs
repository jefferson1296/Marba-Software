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
    public partial class formGestaoFerramentasSwotAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        SWOT swot = new SWOT();

        public formGestaoFerramentasSwotAdicionar()
        {
            InitializeComponent();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string descricao = textBoxDescricao.Text;
            string categoria = comboBoxCategoria.Text;

            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe a descrição para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (categoria == string.Empty)
            {
                MessageBox.Show("Informe a categoria para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                swot.Descricao = descricao;
                swot.Categoria = categoria;
                comandos.CadastrarSwot(swot);

                MessageBox.Show(categoria + " adicionada!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
