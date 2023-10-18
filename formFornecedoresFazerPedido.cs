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
    public partial class formFornecedoresFazerPedido : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        string operador;
        string fornecedor;

        public formFornecedoresFazerPedido()
        {
            InitializeComponent();
        }
        public formFornecedoresFazerPedido(string Operador, string Fornecedor)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            operador = Operador;
            fornecedor = Fornecedor;
        }
        private void formFornecedoresFazerPedido_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            comandos.VisualizarPedido(operador, fornecedor, true);
        }

        private void FinalizarButton_Click(object sender, EventArgs e)
        {
            comandos.FazerPedido(operador, fornecedor);
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
