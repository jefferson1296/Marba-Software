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
    public partial class formColaboradoresFolhaDePonto : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id_colaborador;

        public formColaboradoresFolhaDePonto()
        {
            InitializeComponent();
        }

        public formColaboradoresFolhaDePonto(int ID_Colaborador)
        {
            InitializeComponent();
            id_colaborador = ID_Colaborador;
        }

        private void formColaboradoresFolhaDePonto_Load(object sender, EventArgs e)
        {
            List<string> Meses = comandos.MesesDaFolhaDePonto();
            foreach (string mes in Meses) { comboBoxMes.Items.Add(mes); }
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            string data = comboBoxMes.Text;

            if (data == string.Empty)
            {
                MessageBox.Show("Informe o mês para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string[] partir = data.Split('/');
                string Mes = partir[0];
                int mes = comandos.ConverterMesPorExtensoEmInt(Mes);
                int ano = Convert.ToInt32(partir[1]);

                comandos.ImprimirFolhaDePonto(mes, ano, id_colaborador, true);
            }
        }

        private void exportarPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string data = comboBoxMes.Text;

            if (data == string.Empty)
            {
                MessageBox.Show("Informe o mês para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string[] partir = data.Split('/');
                string Mes = partir[0];
                int mes = comandos.ConverterMesPorExtensoEmInt(Mes);
                int ano = Convert.ToInt32(partir[1]);

                comandos.ImprimirFolhaDePonto(mes, ano, id_colaborador, false);
            }
        }
    }
}
