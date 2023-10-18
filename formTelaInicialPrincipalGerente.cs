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
    public partial class formTelaInicialPrincipalGerente : Form
    {
        public formTelaInicialPrincipalGerente()
        {
            InitializeComponent();
        }

        private void buttonExpedientes_Click(object sender, EventArgs e)
        {
            formGestaoExpedientes expedientes = new formGestaoExpedientes();
            expedientes.ShowDialog();
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

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonPlano_Click(object sender, EventArgs e)
        {
            formGestaoFerramentasPlanos planos = new formGestaoFerramentasPlanos();
            planos.ShowDialog();
        }

        private void buttonPrecos_Click(object sender, EventArgs e)
        {
            formProdutosEtiquetas etiquetas = new formProdutosEtiquetas();
            etiquetas.ShowDialog();
        }

        private void formTelaInicialPrincipalGerente_Load(object sender, EventArgs e)
        {
            bool botao_expediente = Program.Acessos.Where(x => x.Descricao == "Botão de expedientes na tela de gerente").Select(x => x.Permissao).FirstOrDefault();
            bool botao_planos = Program.Acessos.Where(x => x.Descricao == "Botão de planos de ação na tela de gerente").Select(x => x.Permissao).FirstOrDefault();
            bool botao_financeiro = Program.Acessos.Where(x => x.Descricao == "Botão de finanças na tela de gerente").Select(x => x.Permissao).FirstOrDefault();

            if (botao_expediente) { buttonExpedientes.Enabled = true; }
            else { buttonExpedientes.Enabled = false; }

            if (botao_planos) { buttonPlano.Enabled = true; }
            else { buttonPlano.Enabled = false; }

            if (botao_financeiro) { buttonFinanceiro.Enabled = true; }
            else { buttonFinanceiro.Enabled = false; }
        }

        private void buttonFinanceiro_Click(object sender, EventArgs e)
        {
            formTelaInicialPrincipalGerenteFinanceiro financeiro = new formTelaInicialPrincipalGerenteFinanceiro();
            financeiro.ShowDialog();
        }
    }
}
