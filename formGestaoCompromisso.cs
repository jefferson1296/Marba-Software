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
    public partial class formGestaoCompromisso : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formGestaoCompromisso()
        {
            InitializeComponent();
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            string descricao = descricaoTextBox.Text;
            string detalhes = detalheTextBox.Text;
            DateTime hora = Convert.ToDateTime(dateTimePicker.Value.ToShortDateString() + " " + horaMaskedTextBox.Text);

            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe a descrição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (horaMaskedTextBox.Text.Length < 5)
            {
                MessageBox.Show("Preencha a hora corretamente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (hora <= DateTime.Now)
            {
                MessageBox.Show("Não é possível atribuir uma data que já passou!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Notificacao notificacao = new Notificacao();
                notificacao.Descricao = descricao;
                notificacao.Detalhes = detalhes;
                notificacao.Hora = hora;
                comandos.NovoCompromisso(notificacao, Program.colaborador.Nome_Colaborador);
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
