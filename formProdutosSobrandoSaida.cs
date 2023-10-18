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
    public partial class formProdutosSobrandoSaida : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formProdutosSobrando pai = new formProdutosSobrando();
        ProdutoReposicao Produto = new ProdutoReposicao();
        public formProdutosSobrandoSaida()
        {
            InitializeComponent();
        }
        public formProdutosSobrandoSaida(formProdutosSobrando Pai, ProdutoReposicao Produto)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            pai = Pai;
            this.Produto = Produto;
        }

        private void formProdutosSobrandoSaida_Load(object sender, EventArgs e)
        {
            textBoxItem.Text = Produto.Nome_Produto;
            textBoxAtual.Text = Produto.Quantidade.ToString();
        }

        #region Movimentacao do Formulario
        bool clique;
        Point clickedAt;
        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique)
            {
                this.Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
            }
        }
        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            clique = true;
            clickedAt = e.Location;
        }
        private void panelSuperior_MouseUp(object sender, MouseEventArgs e)
        {
            clique = false;
        }
        #endregion

        private void caixaTextBox_Enter(object sender, EventArgs e)
        {
            if (caixaTextBox.Text == "0")
                caixaTextBox.Text = string.Empty;
        }

        private void caixaTextBox_Leave(object sender, EventArgs e)
        {
            if (caixaTextBox.Text == string.Empty)
                caixaTextBox.Text = "0";
        }

        private void caixaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void carregarButton_Click(object sender, EventArgs e)
        {
            int quantidade = Convert.ToInt32(caixaTextBox.Text);
            if (quantidade > Produto.Quantidade)
            {
                MessageBox.Show("Não é possível registrar uma saída superior a quantidade atual!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                comandos.RegistrarSaidaDoProdutoSobrando(Produto.ID_Produto, quantidade);
                pai.alteracao = true;
                Dispose();
            }
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
