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
    public partial class formTelaInicialPrincipalAssuntosAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formTelaInicialPrincipalAssuntosAdicionar()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            string descricao = textBoxDescricao.Text;
            string tipo;

            if (radioButtonSugestao.Checked) { tipo = "Sugestão"; } 
            else if (radioButtonAssunto.Checked) { tipo = "Assunto"; } 
            else { tipo = "Reclamação"; }

            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe a descrição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);        
            }
            else
            {
                if (tipo == "Assunto") { comandos.RegistrarAssunto(descricao); }
                else if (tipo == "Reclamação") { comandos.RegistrarReclamacao(descricao); }
                else if (tipo == "Sugestão") { comandos.RegistrarSugestao(descricao); }

                MessageBox.Show("Registro realizado.", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

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

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
