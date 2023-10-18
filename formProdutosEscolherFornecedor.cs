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
    public partial class formProdutoEscolherFornecedor : Form
    {
        bool analise = false;
        bool manual = false;

        public formProdutoEscolherFornecedor()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void formProdutoEscolherFornecedor_Load(object sender, EventArgs e)
        {
            if (radioButtonAnalise.Checked) { analise = true; manual = false; }
            else { analise = false; manual = true; }
            Atualizar();
        }

        private void Atualizar()
        {
            if (analise)
            {
                formProdutosEscolherAnaliseAvancada analise_avancada = new formProdutosEscolherAnaliseAvancada(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panelCentral.Controls.Clear();
                this.panelCentral.Controls.Add(analise_avancada);
                analise_avancada.Show();
            }
            else if (manual)
            {
                formProdutosEscolherEntradaManual entrada_manual = new formProdutosEscolherEntradaManual(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panelCentral.Controls.Clear();
                this.panelCentral.Controls.Add(entrada_manual);
                entrada_manual.Show();
            }
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void radioButtonAnalise_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAnalise.Checked) { analise = true; manual = false; }
            else { analise = false; manual = true; }
            Atualizar();
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
