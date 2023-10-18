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
    public partial class formTelaInicialPrincipalEstoque : Form
    {
        public formTelaInicialPrincipalEstoque()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void buttonListas_Click(object sender, EventArgs e)
        {
            formProdutosListas listas = new formProdutosListas();
            listas.ShowDialog();
        }

        private void buttonEtiquetas_Click(object sender, EventArgs e)
        {
            formProdutosEtiquetas etiquetas = new formProdutosEtiquetas();
            etiquetas.ShowDialog();
        }

        private void buttonSobrando_Click(object sender, EventArgs e)
        {
            formProdutosSobrando sobrando = new formProdutosSobrando();
            sobrando.ShowDialog();
        }

        private void buttonPrevisoes_Click(object sender, EventArgs e)
        {
            formFornecedoresPedidoRecebimentos previsoes = new formFornecedoresPedidoRecebimentos();
            previsoes.ShowDialog();
        }
        private void buttonAlmoxarifado_Click(object sender, EventArgs e)
        {
            formProdutosAlmoxarifado almoxarifado = new formProdutosAlmoxarifado();
            almoxarifado.ShowDialog();
        }

        private void buttonTransferencia_Click(object sender, EventArgs e)
        {
            formProdutosLotesTransferenciasTransferir transferencia = new formProdutosLotesTransferenciasTransferir();
            transferencia.ShowDialog();
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

        private void buttonAvarias_Click(object sender, EventArgs e)
        {
            formProdutosAjustesAvarias avarias = new formProdutosAjustesAvarias();
            avarias.ShowDialog();
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonLocalizacoes_Click(object sender, EventArgs e)
        {
            formGestaoControleLocalizacoes localizacoes = new formGestaoControleLocalizacoes();
            localizacoes.ShowDialog();
        }
    }
}
