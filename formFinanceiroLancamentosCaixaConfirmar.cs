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
    public partial class formFinanceiroLancamentosCaixaConfirmar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        MovimentacaoCaixa sangria = new MovimentacaoCaixa();
        formFinanceiroLancamentosCaixa pai = new formFinanceiroLancamentosCaixa();
        public formFinanceiroLancamentosCaixaConfirmar()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }
        public formFinanceiroLancamentosCaixaConfirmar(MovimentacaoCaixa Sangria, formFinanceiroLancamentosCaixa Pai)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            sangria = Sangria;
            pai = Pai;
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void formFinanceiroFluxoConfirmarSangria_Load(object sender, EventArgs e)
        {
            string tipo = sangria.Tipo;
            decimal valor = sangria.Valor;
            string hora = sangria.Hora;
            string operador = sangria.Operador;
            string intermediario = sangria.Intermedio;

            comboBoxMovimentacao.Text = tipo;
            textBoxValor.Text = valor.ToString("C");
            textBoxData.Text = hora;
            textBoxOperador.Text = operador;
            textBoxIntermediario.Text = intermediario;
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

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            comandos.ConfirmarRecebimentoDaSangria(sangria);
            pai.Alteracao = true;
            Dispose();
        }
    }
}
