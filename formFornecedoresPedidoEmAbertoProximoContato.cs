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
    public partial class formFornecedoresPedidoEmAbertoProximoContato : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id_pedido;
        public formFornecedoresPedidoEmAbertoProximoContato()
        {
            InitializeComponent();
        }
        public formFornecedoresPedidoEmAbertoProximoContato(int ID_pedido)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            id_pedido = ID_pedido;
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            DateTime data = dateTimePicker.Value;
            if (data.Date <= DateTime.Now.Date)
            {
                MessageBox.Show("Escolha uma data do futuro para reagendar a confirmação.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                comandos.ReagendarPedido(data, id_pedido);
                Dispose();
            }
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
