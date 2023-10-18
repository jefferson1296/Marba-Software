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
    public partial class formProdutosAjustes : Form
    {        
        //
        public formProdutosAjustes()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
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

        private void btnTransferencia1_Click(object sender, EventArgs e)
        {
            formProdutosLotesTransferenciasTransferir transferencia = new formProdutosLotesTransferenciasTransferir();
            transferencia.ShowDialog();
            Dispose();
        }
        private void btnBalanco1_Click(object sender, EventArgs e)
        {
            formAjustesBalancoSetor balanco = new formAjustesBalancoSetor();
            balanco.ShowDialog();
            Dispose();
        }
        private void btnAvarias1_Click(object sender, EventArgs e)
        {
            formProdutosAvarias avarias = new formProdutosAvarias();
            avarias.ShowDialog();
            Dispose();
        }
        private void btnReposicao1_Click(object sender, EventArgs e)
        {
            formProdutosAjustesReposicao reposicao = new formProdutosAjustesReposicao();
            reposicao.ShowDialog();
            Dispose();
        }

        private void btnArmazenamento_Click(object sender, EventArgs e)
        {
            //formProdutosAjustesArmazenamento armazenamento = new formProdutosAjustesArmazenamento();
            //armazenamento.ShowDialog();
            Dispose();
        }

        private void btnPrateleiras_Click(object sender, EventArgs e)
        {

        }
    }
}
