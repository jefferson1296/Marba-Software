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
    public partial class formProdutosEscolherEntradaManual : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formProdutoEscolherFornecedor pai;
        public formProdutosEscolherEntradaManual(formProdutoEscolherFornecedor Pai)
        {
            InitializeComponent();
            pai = Pai;
        }

        private void formProdutosEscolherEntradaManual_Load(object sender, EventArgs e)
        {
            fornecedorComboBox.DropDownHeight = 120;
            fornecedorComboBox.DropDownWidth = 250;
            pedidoComboBox.DropDownHeight = 120;
            pedidoComboBox.DropDownWidth = 250;

            List<string> Fornecedores = comandos.TrazerFornecedores();
            foreach (string x in Fornecedores) { fornecedorComboBox.Items.Add(x); }
            fornecedorComboBox.Update();
            fornecedorComboBox.SelectedIndex = -1;
        }

        private void fornecedorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fornecedor = fornecedorComboBox.Text;
            pedidoComboBox.DataSource = comandos.TrazerListaDePedidos(fornecedor, false);
            pedidoComboBox.Update();
        }

        private void buttonFinalizar_Click(object sender, EventArgs e)
        {
            if (fornecedorComboBox.Text == string.Empty)
            {
                MessageBox.Show("Informe o fornecedor para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string fornecedor = fornecedorComboBox.Text;
                string[] partir = pedidoComboBox.Text.Split(' ');
                int id_pedido = 0;
                try
                {
                    id_pedido = Convert.ToInt32(partir[0]);
                }
                catch { }

                if (id_pedido == 0)
                {
                    formProdutosEntradaDarEntrada entrada = new formProdutosEntradaDarEntrada(fornecedor);
                    entrada.ShowDialog();
                    pai.Dispose();
                }
                else
                {
                    formProdutosEntradaDarEntrada entrada = new formProdutosEntradaDarEntrada(fornecedor, id_pedido);
                    entrada.ShowDialog();
                    pai.Dispose();
                }
            }
        }
    }
}
