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
    public partial class formNovaSenha : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formNovaSenha()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string matricula = textBoxMatricula.Text;
            string senha_atual = textBoxAtual.Text;
            string nova_senha = textBoxNova.Text;
            string confirmar = textBoxConfirmar.Text;

            if (nova_senha == string.Empty)
            {
                MessageBox.Show("Informe a nova senha para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!comandos.VerificarMatricula(matricula))
            {
                MessageBox.Show("Matrícula não cadastrada.\r\nInforme uma matrícula válida para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comandos.VerificarSenhaAtual(matricula) != senha_atual)
            {
                MessageBox.Show("Senha atual incorreta.\r\nTente novamente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (nova_senha == senha_atual)
            {
                MessageBox.Show("A nova senha não pode ser igual a senha atual!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (nova_senha.Length < 4 || nova_senha.Length > 12)
            {
                MessageBox.Show("A nova senha deve ter entre 4 e 12 caracteres.", "Senha inválida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (nova_senha != confirmar)
            {
                MessageBox.Show("Confirmação de senha incorreta.\r\nTente novamente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                comandos.AlterarSenha(nova_senha, matricula);
            }
        }
    }
}
