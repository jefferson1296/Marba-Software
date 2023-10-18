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
    public partial class formVendasPDVClientesHabitos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id_cliente;
        string cliente;
        public formVendasPDVClientesHabitos()
        {
            InitializeComponent();
        }
        public formVendasPDVClientesHabitos(int ID_Cliente, string Cliente)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            id_cliente = ID_Cliente;
            cliente = Cliente;
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

        private void formVendasPDVClientesHabitos_Load(object sender, EventArgs e)
        {
            clienteTextBox.Text = cliente;

        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxHabito.Items.Clear();
            string categoria = comboBoxCategoria.Text;
            List<string> Habitos = comandos.TrazerListaDeHabitos(categoria);
            foreach (string x in Habitos) { comboBoxHabito.Items.Add(x); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void salvarButton_Click(object sender, EventArgs e)
        {
            string habito = comboBoxHabito.Text;

            if (habito == string.Empty)
            {
                MessageBox.Show("Informe o interesse do cliente para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                HabitoDoCliente Habito = new HabitoDoCliente();
                Habito.ID_Cliente = id_cliente;
                Habito.Habito = habito;
                comandos.RegistrarHabitoDoCliente(Habito);
                Dispose();
            }

        }
    }
}
