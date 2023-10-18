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
    public partial class formColaboradoresEscalaDatasDefinir : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formColaboradoresEscalaDatasDefinir()
        {
            InitializeComponent();
        }

        private void formTelaInicialEscalaDatasDefinir_Load(object sender, EventArgs e)
        {
            List<int> Anos = new List<int>();

            int ano = DateTime.Now.Year;

            for (int i = 0; i < 10; i++)
            {
                Anos.Add(ano);
                ano++;
            }

            foreach(int Ano in Anos)
            {
                comboBoxAno.Items.Add(Ano);
            }
        }

        private void DefinirFeriados(int ano)
        {
            if (!comandos.VerificarSeFeriadosDoAnoJaForamDefinidos(ano))
            {
                formColaboradoresDefinirFeriados feriados = new formColaboradoresDefinirFeriados(ano);
                feriados.ShowDialog();
            }
            else
            {
                MessageBox.Show("Todos os feriados para esse ano foram definidos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (comboBoxAno.Text == string.Empty)
            {
                MessageBox.Show("Informe o ano para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int ano = Convert.ToInt32(comboBoxAno.Text);
                DefinirFeriados(ano);
            }
        }
    }
}
