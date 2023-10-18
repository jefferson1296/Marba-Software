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
    public partial class formVendasPDVTrocas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        string operador;
        public formVendasPDVTrocas()
        {
            InitializeComponent();
        }
        public formVendasPDVTrocas(string Operador)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            operador = Operador;
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonAgendar_Click(object sender, EventArgs e)
        {
            string venda = textBoxVenda.Text;
            if (venda == string.Empty)
            {
                MessageBox.Show("Informe o Número da Venda!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id_venda = Convert.ToInt32(venda);
                bool permitir = comandos.VerificarPrazoParaTroca(id_venda);
                if (permitir)
                {
                    formVendasPDVTrocasProdutos avancar = new formVendasPDVTrocasProdutos(operador, id_venda, this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    this.Width = avancar.Width + 6;
                    this.Height = avancar.Height + 27;
                    this.CenterToScreen();
                    this.panelForm.Controls.Clear();
                    this.panelForm.Controls.Add(avancar);
                    avancar.Show();
                }
            }
        }

        private void textBoxVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        #region Movimentacao do Formulario
        bool clique;
        Point clickedAt;
        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique)
            {
                Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
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
