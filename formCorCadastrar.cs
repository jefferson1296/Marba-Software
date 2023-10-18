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
    public partial class formCorCadastrar : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        bool cor;
        bool estampa;

        public formCorCadastrar(string cadastramento)
        {
            InitializeComponent();

            if (cadastramento == "Cor")
            {
                cor = true;
                estampa = false;
            }
            else
            {
                cor = false;
                estampa = true;
            }
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            if (cor)
            {
                string Cor = corTextBox.Text;

                if (Cor == string.Empty)
                {
                    MessageBox.Show("Preencha a cor para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (comandos.VerificarSeCorJaExiste(Cor))
                {
                    MessageBox.Show("Essa cor já está cadastrada!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    comandos.CadastrarCor(Cor);
                }
            }
            else if (estampa)
            {
                string Estampa = corTextBox.Text;

                if (Estampa == string.Empty)
                {
                    MessageBox.Show("Preencha a estampa para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (comandos.VerificarSeCorJaExiste(Estampa))
                {
                    MessageBox.Show("Essa estampa já está cadastrada!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    comandos.CadastrarEstampa(Estampa);
                }
            }

            Dispose();
        }

        private void formCorCadastrar_Load(object sender, EventArgs e)
        {
            if (estampa)
            {
                Text = "Cadastrar estampa";
                label1.Text = "Estampa:";
            }
        }
    }
}
