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
    public partial class formProdutosLotesExtravios : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        Produto_Lote produto = new Produto_Lote();
        public formProdutosLotesExtravios()
        {
            InitializeComponent();
        }

        public formProdutosLotesExtravios(Produto_Lote Produto)
        {
            InitializeComponent();
            produto = Produto;
        }
        private void formProdutosLotesExtravios_Load(object sender, EventArgs e)
        {
            textBoxProduto.Text = produto.Nome;
            labelAtual.Text = "/ " + produto.Quantidade.ToString();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            int quantidade = Convert.ToInt32(textBoxQuantidade.Text);

            if (quantidade == 0)
            {
                MessageBox.Show("Informe a quantidade para concluir o registro!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (quantidade > produto.Quantidade)
            {
                MessageBox.Show("A quantidade informada é maior que a quantidade de produtos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                produto.Quantidade = quantidade;
                comandos.RegistrarExtravio(produto);
                Dispose();

                MessageBox.Show("Extravio registrado.", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBoxQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
    }
}
