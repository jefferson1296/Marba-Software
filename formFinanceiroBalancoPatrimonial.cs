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
    public partial class formFinanceiroBalancoPatrimonial : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        public formFinanceiroBalancoPatrimonial()
        {
            InitializeComponent();
        }

        private void formFinanceiroBalancoPatrimonial_Load(object sender, EventArgs e)
        {

        }

        private void PreencherBalancoPatrimonial()
        {
            //Ativo
            decimal especie = comandos.SaldoEmEspecie();
            decimal custo_estoque = comandos.SaldoDeEstoqueFisico();
            decimal saldo_mercadoria = comandos.SaldoFinanceiroDeEstoque();
            decimal ativos_imobilizados = comandos.ValorDosAtivosImobilizados();

            decimal ativos = especie + custo_estoque + saldo_mercadoria + ativos_imobilizados;

            caixaTextBox.Text = especie.ToString("C");
            custoTextBox.Text = custo_estoque.ToString("C");
            saldoMercadoriaTextBox.Text = saldo_mercadoria.ToString("C");
            ativosTextBox.Text = ativos.ToString("C");

            //Passivo
            decimal fornecedores = comandos.ExigivelACurtoPrazoFornecedores();
            decimal cartoes = comandos.ExigivelACurtoPrazoCartoes();
            decimal longo_prazo = comandos.EmprestimosParceladoRestante();

            decimal passivos = fornecedores + cartoes + longo_prazo;

            fornecedoresTextBox.Text = fornecedores.ToString("C");
            cartoesTextBox.Text = cartoes.ToString("C");
            longoPrazoTextBox.Text = longo_prazo.ToString("C");

            passivosTextBox.Text = passivos.ToString("C");
        }
    }
}
