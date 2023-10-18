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
    public partial class formFinanceiroLancamentosDia : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formFinanceiroLancamentosDia()
        {
            InitializeComponent();
        }

        private void formFinanceiroFluxoMovimentacoesDoDia_Load(object sender, EventArgs e)
        {
            Calcular();
        }

        private void Calcular()
        {
            DateTime data = dateTimePicker.Value;

            decimal sangria = comandos.MovimentacoesDoDia("Sangria", data);
            decimal suprimento = comandos.MovimentacoesDoDia("Suprimento", data);
            decimal especie = comandos.SaldoEmDinheiroDoDia(data);
            decimal saldo = comandos.SaldoDoDia(data);
            decimal receitas = comandos.ReceitasDoDia(data);
            decimal despesas = comandos.DespesasDoDia(data);

            if (saldo != receitas + despesas)
                MessageBox.Show("O saldo do dia pode estar sendo alterado por\r\nrecebíveis que estão ocultos na lista de movimentações.\r\nCaso queira apagar tais movimentações, acesse a lista detalhada.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            labelSan.Text = sangria.ToString("C");
            labelSup.Text = suprimento.ToString("C");
            labelEspecie.Text = especie.ToString("C");
            labelDia.Text = saldo.ToString("C");
            labelReceitas.Text = receitas.ToString("C");
            labelDespesas.Text = despesas.ToString("C");
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Calcular();
        }
    }
}
