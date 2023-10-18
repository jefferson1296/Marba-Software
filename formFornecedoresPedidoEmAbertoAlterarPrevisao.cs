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
    public partial class formFornecedoresPedidoEmAbertoAlterarPrevisao : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id_pedido;
        public formFornecedoresPedidoEmAbertoAlterarPrevisao()
        {
            InitializeComponent();
        }
        public formFornecedoresPedidoEmAbertoAlterarPrevisao(int ID_Pedido)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            id_pedido = ID_Pedido;
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

        private void salvarButton_Click(object sender, EventArgs e)
        {
            DateTime data = new DateTime();
            bool permitir;
            try
            {
                DateTime Hora = Convert.ToDateTime(horaMaskedBox.Text);
                data = Convert.ToDateTime(dateTimePicker.Text + " " + horaMaskedBox.Text);
                permitir = true;
            }
            catch { permitir = false; }

            if (permitir)
            {
                if (data < DateTime.Now)
                {
                    MessageBox.Show("Escolha uma data do futuro para definir a previsão de entrega!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    comandos.AlterarPrevisaoDeEntrega(data, id_pedido);
                    Dispose();
                }
            }
            else
            {
                MessageBox.Show("Informe corretamente a data e a hora!");
            }
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }


}
