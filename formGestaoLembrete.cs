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
    public partial class formGestaoLembrete : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formGestaoLembrete()
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
                comandos.NovoLembrete(notificacao, Program.colaborador.Nome_Colaborador);
            }
        }
    }
}
