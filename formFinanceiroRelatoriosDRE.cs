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
    public partial class formFinanceiroRelatoriosDRE : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        string tipo;
        public formFinanceiroRelatoriosDRE()
        {
            InitializeComponent();
        }
        public formFinanceiroRelatoriosDRE(string Tipo)
        {
            InitializeComponent();
            tipo = Tipo;
        }
        private void formFinanceiroRelatoriosDRE_Load(object sender, EventArgs e)
        {
            Text = tipo;
            List<string> Meses = comandos.MesesDoDRE();
            foreach (string mes in Meses) { comboBoxMes.Items.Add(mes); }
        }

        private void buttonDiario_Click(object sender, EventArgs e)
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

                if (tipo == "DRE")
                {
                    comandos.ImprimirDRE(mes, ano, true);

                    if (DialogResult.Yes == MessageBox.Show("Imprimir o detalhamento das despesas referentes à DRE também?", "Detalhamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        comandos.ImprimirDespesasPorCategoria(mes, ano, true);
                    }
                }
                else if (tipo == "Despesas por categoria")
                {
                    comandos.ImprimirDespesasPorCategoria(mes, ano, true);
                }
            }
        }

        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
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

                if (tipo == "DRE")
                {
                    comandos.ImprimirDRE(mes, ano, false);

                    if (DialogResult.Yes == MessageBox.Show("Imprimir o detalhamento das despesas referentes à DRE também?", "Detalhamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        comandos.ImprimirDespesasPorCategoria(mes, ano, false);
                    }
                }
                else if (tipo == "Despesas por categoria")
                {
                    comandos.ImprimirDespesasPorCategoria(mes, ano, false);
                }
            }
        }
    }
}
