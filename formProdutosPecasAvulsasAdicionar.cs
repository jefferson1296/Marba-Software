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
    public partial class formProdutosPecasAvulsasAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id_produto;
        public formProdutosPecasAvulsasAdicionar()
        {
            InitializeComponent();
        }
        public formProdutosPecasAvulsasAdicionar(int ID_Produto)
        {
            InitializeComponent();
            id_produto = ID_Produto;
        }
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void textBoxQuantidade_Enter(object sender, EventArgs e)
        {
            if (textBoxQuantidade.Text == "0")
                textBoxQuantidade.Text = string.Empty;
        }

        private void textBoxQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void textBoxQuantidade_Leave(object sender, EventArgs e)
        {
            if (textBoxQuantidade.Text == string.Empty)
                textBoxQuantidade.Text = "0";
        }

        private void formProdutosPecasAvulsasAdicionar_Load(object sender, EventArgs e)
        {
            textBoxProduto.Text = comandos.TrazerNomeDoProdutoPeloID(id_produto);
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            string peca = comboBoxPeca.Text;
            int quantidade = Convert.ToInt32(textBoxQuantidade.Text);
            string setor = comboBoxSetor.Text;
            string obs = textBoxObs.Text;

            if (peca == string.Empty)
            {
                MessageBox.Show("Informe a peça para continuar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!comandos.VerificarSePecaDoProdutoExiste(peca))
            {
                MessageBox.Show("Informe uma peça desse produto para continuar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (quantidade == 0)
            {
                MessageBox.Show("Informe a quantidade.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (setor == string.Empty)
            {
                MessageBox.Show("Informe o setor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                PecaAvulsa Peca = new PecaAvulsa
                {
                    Nome_Peca = peca,
                    Quantidade = quantidade,
                    Setor = setor,
                    Observacao = obs,
                    ID_Produto = id_produto
                };

                comandos.AdicionarPecaAvulsa(Peca);
                Dispose();
            }
        }
    }
}
