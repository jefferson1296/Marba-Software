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
    public partial class formFinanceiroPeriodosVariavel : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formFinanceiroPeriodos pai = new formFinanceiroPeriodos();
        decimal variavel_unitario;
        public formFinanceiroPeriodosVariavel()
        {
            InitializeComponent();
        }
        public formFinanceiroPeriodosVariavel(formFinanceiroPeriodos Pai)
        {
            InitializeComponent();
            pai = Pai;
        }
        private void formFinanceiroPeriodosVariavel_Load(object sender, EventArgs e)
        {
            List<string> Meses = comandos.MesesDeVendaSoftcom();
            foreach (string mes in Meses) { comboBoxMes.Items.Add(mes); }
        }

        private void comboBoxMes_SelectedIndexChanged(object sender, EventArgs e)
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

                decimal variavel_mensal = comandos.CustoVariavelMensal(mes, ano);
                int qtd_produtos = comandos.QuantidadeDeProdutosVendidosNoMes(mes, ano);

                variavel_unitario = variavel_mensal / qtd_produtos;

                textBoxMensal.Text = variavel_mensal.ToString("C");
                textBoxProdutos.Text = qtd_produtos.ToString();
                textBoxUnitario.Text = variavel_unitario.ToString("C");
            }
        }

        private void buttonAplicar_Click(object sender, EventArgs e)
        {
            comandos.AtualizarCustoVariavelUnitario(variavel_unitario);
            pai.alteracao = true;
            Dispose();
        }
    }
}
