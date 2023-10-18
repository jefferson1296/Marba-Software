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
    public partial class formProdutosSobrandoRegistrar : Form
    {
        formProdutosSobrando pai = new formProdutosSobrando();
        ComandosSQL comandos = new ComandosSQL();
        public formProdutosSobrandoRegistrar(formProdutosSobrando Pai)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            pai = Pai;
        }

        #region Formatação
        private void textBoxPesquisa_Enter(object sender, EventArgs e)
        {
            textBoxPesquisa.Text = string.Empty;
            textBoxPesquisa.ForeColor = Color.Black;
            textBoxPesquisa.CharacterCasing = CharacterCasing.Upper;
        }
        private void textBoxPesquisa_Leave(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text == string.Empty)
            {
                textBoxPesquisa.CharacterCasing = CharacterCasing.Normal;
                textBoxPesquisa.Text = "Digite aqui para pesquisar";
                textBoxPesquisa.ForeColor = Color.Gray;
            }

        }
        private void formProdutosSobrandoRegistrar_Load(object sender, EventArgs e)
        {
            textBoxPesquisa.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxPesquisa.AutoCompleteCustomSource = comandos.AutoCompleteVendas();
        }
        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string produto = textBoxPesquisa.Text;
                int quantidade = comandos.TrazerQuantidadeDoEstoque(produto);
                textBoxAtual.Text = quantidade.ToString();
            }
            catch { }
        }
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
        #endregion

        private void carregarButton_Click(object sender, EventArgs e)
        {
            string produto = textBoxPesquisa.Text;
            int atual = Convert.ToInt32(textBoxAtual.Text);
            int quantidade = Convert.ToInt32(caixaTextBox.Text);

            if (produto == string.Empty) { MessageBox.Show("Informe o nome do produto para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else if (!comandos.VerificarProdutoPeloNomeDoSistema(produto))
            { MessageBox.Show("Informe um produto ativo para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else if (quantidade > atual) { MessageBox.Show("Não é possível registrar o produto pois a quantidade informada é maior que a quantidade atual.\r\nInforme imediatamente à gestão.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else { comandos.RegistrarProdutoSobrando(produto, quantidade); Dispose(); pai.alteracao = true; }
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
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
    }
}
