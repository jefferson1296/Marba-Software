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
    public partial class formProdutosAlmoxarifadoConfirmarInformacoes : Form
    {
        Almoxarifado item = new Almoxarifado();
        formProdutosAlmoxarifadoConfirmarReposicao pai = new formProdutosAlmoxarifadoConfirmarReposicao();
        public formProdutosAlmoxarifadoConfirmarInformacoes()
        {
            InitializeComponent();
        }
        public formProdutosAlmoxarifadoConfirmarInformacoes(Almoxarifado Item, formProdutosAlmoxarifadoConfirmarReposicao Pai)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            item = Item;
            pai = Pai;
        }

        private void formProdutosAlmoxarifadoConfirmarInformacoes_Load(object sender, EventArgs e)
        {
            textBoxItem.Text = item.Item;
            baseTextBox.Text = item.Custo.ToString("C");
            caixaTextBox.Text = item.Estoque_Ideal.ToString();
        }

        private void carregarButton_Click(object sender, EventArgs e)
        {
            int quantidade = Convert.ToInt32(caixaTextBox.Text);
            string[] partir = baseTextBox.Text.Split('$');
            decimal custo = Convert.ToDecimal(partir[1]);

            foreach (Almoxarifado item in pai.Itens)
            {
                if (item.ID_Almoxarifado == this.item.ID_Almoxarifado)
                {
                    item.Estoque_Ideal = quantidade;
                    item.Custo = custo;
                }
            }

            Dispose();
        }

        #region Formatação de Texto
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
        private void baseTextBox_Enter(object sender, EventArgs e)
        {
            if (baseTextBox.Text == "R$0,00")
            {
                baseTextBox.Text = string.Empty;
            }
            else
            {
                string[] partir = baseTextBox.Text.Split('$');
                baseTextBox.Text = partir[1];
            }
        }
        private void baseTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
            (e.KeyChar != ',' && e.KeyChar != '.' &&
            e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!baseTextBox.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (Char)0;
                    }
                }
            }
        }
        private void baseTextBox_Leave(object sender, EventArgs e)
        {
            if (baseTextBox.Text == string.Empty)
            {
                baseTextBox.Text = "R$0,00";
            }
            else
            {
                baseTextBox.Text = Convert.ToDouble(baseTextBox.Text).ToString("C");
            }
        }
        #endregion
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

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
