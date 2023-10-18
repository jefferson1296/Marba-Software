using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clModelo.funcoes;

namespace MarbaSoftware
{
    public partial class formVendasPDVTrocasProdutos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id_venda;
        string operador;
        formVendasPDVTrocas troca = new formVendasPDVTrocas();
        public formVendasPDVTrocasProdutos()
        {
            InitializeComponent();
        }
        public formVendasPDVTrocasProdutos(string Operador, int id, formVendasPDVTrocas Troca)
        {
            InitializeComponent();
            id_venda = id;
            operador = Operador;
            troca = Troca;
        }

        private void formVendasPDVTrocas2_Load(object sender, EventArgs e)
        {
            comandos.PreencherDataGridTrocas(id_venda, dataGridViewLista);
            string dados = comandos.PreencherDadosTroca(id_venda);
            string[] separar = dados.Split(';');
            string nome = separar[1];
            string data = separar[0];
            labelCliente.Text = nome;
            labelData.Text = data;
        }

        private void dataGridViewLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (Convert.ToBoolean(dataGridViewLista.Rows[e.RowIndex].Cells[3].Value) == true)
                {
                    dataGridViewLista.Rows[e.RowIndex].Cells[3].Value = false;
                }
                else
                {
                    dataGridViewLista.Rows[e.RowIndex].Cells[3].Value = true;
                }
            }
            SomarValor();
        }
        private void SomarValor()
        {
            decimal x = 0;

            foreach(DataGridViewRow linha in dataGridViewLista.Rows)
            {
                if (Convert.ToBoolean(dataGridViewLista.Rows[linha.Index].Cells[3].Value) == true)
                {
                    x = x + Convert.ToDecimal(dataGridViewLista.Rows[linha.Index].Cells[2].Value);
                }
            }
            labelTotal.Text = x.ToString("C");
        }
        private void buttonFinalizar_Click(object sender, EventArgs e)
        {
            string[] partir = labelTotal.Text.Split('$');
            decimal valor = Convert.ToDecimal(partir[1]);
            if (valor == 0)
            {
                MessageBox.Show("Não é possível gerar um vale troca sem valor!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                bool valetroca;
                string valor_total = labelTotal.Text;
                if (radioButtonVale.Checked)
                {
                    if (DialogResult.Yes == MessageBox.Show("A opção 'Gerar Vale' está marcada.\r\nIsso significa que o cliente devolveu o produto\r\ne ficará com um saldo para compras futuras.\r\nDeseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        valetroca = true;
                        comandos.RegistrarTroca(valor_total, operador, valetroca, id_venda);
                        comandos.RegistrarProdutoTrocado(operador, dataGridViewLista);
                        MessageBox.Show("Troca registrada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        troca.Dispose();
                    }
                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show("A opção 'Trocar agora' está marcada.\r\nIsso significa que o cliente devolveu\r\n e já está levando outro produto.\r\nDeseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        valetroca = false;
                        comandos.RegistrarTroca(valor_total, operador, valetroca, id_venda);
                        comandos.RegistrarProdutoTrocado(operador, dataGridViewLista);
                        troca.Dispose();
                    }
                }
            }
        }
    }
}
