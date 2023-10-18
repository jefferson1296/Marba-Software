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
    public partial class formGestaoCadastrarProjeto : Form
    {
        public bool alteracao;
        public formGestaoCadastrarProjeto()
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
            if (descricaoTextBox.Text == string.Empty)
            {
                MessageBox.Show("É necessário informar o nome do projeto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (esperadoTextBox.Text == string.Empty)
            {
                MessageBox.Show("É necessário informar o resultado esperado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Projeto projeto = new Projeto();
                projeto.Descricao = descricaoTextBox.Text;
                projeto.Detalhes = detalhesTextBox.Text;
                projeto.Resultado_Esperado = esperadoTextBox.Text;

                formGestaoCadastrarProjetoEtapas etapas = new formGestaoCadastrarProjetoEtapas(this, projeto);
                etapas.ShowDialog();
                if (alteracao)
                {
                    Dispose();
                }
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
