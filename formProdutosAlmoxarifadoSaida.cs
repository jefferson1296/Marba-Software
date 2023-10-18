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
    public partial class formProdutosAlmoxarifadoSaida : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        Almoxarifado Item = new Almoxarifado();
        formProdutosAlmoxarifado pai = new formProdutosAlmoxarifado();
        public formProdutosAlmoxarifadoSaida()
        {
            InitializeComponent();
        }
        public formProdutosAlmoxarifadoSaida(Almoxarifado Item, formProdutosAlmoxarifado Pai)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            pai = Pai;
            this.Item = Item;
        }

        private void formProdutosAlmoxarifadoSaida_Load(object sender, EventArgs e)
        {
            textBoxItem.Text = Item.Item;
            textBoxAtual.Text = Item.Estoque_Atual.ToString();
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

        private void formProdutosAlmoxarifadoSaida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void carregarButton_Click(object sender, EventArgs e)
        {
            int quantidade = Convert.ToInt32(caixaTextBox.Text);
            if (quantidade > Item.Estoque_Atual)
            {
                MessageBox.Show("Não é possível registrar uma saída superior a quantidade atual!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Item.Estoque_Ideal = quantidade;
                comandos.RegistrarSaidaDoAlmoxarifado(Item);
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
