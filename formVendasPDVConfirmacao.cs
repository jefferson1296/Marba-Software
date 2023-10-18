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
    public partial class formVendasPDVConfirmacao : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formVendasPDV pai = new formVendasPDV();
        formVendasCaixaAtual father = new formVendasCaixaAtual();
        string permissao;

        bool pdv;

        public formVendasPDVConfirmacao()
        {
            InitializeComponent();
        }
        public formVendasPDVConfirmacao(formVendasPDV Pai, string Permissao)
        {
            InitializeComponent();
            pai = Pai;
            pdv = true;
            permissao = Permissao;
        }
        public formVendasPDVConfirmacao(formVendasCaixaAtual Father, string Permissao)
        {
            InitializeComponent();
            father = Father;
            pdv = false;
            permissao = Permissao;
        }

        private void textBoxSenha_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxSenha.Clear();
            textBoxSenha.ForeColor = Color.Red;
            textBoxSenha.UseSystemPasswordChar = true;
        }
        private void textBoxSenha_Enter(object sender, EventArgs e)
        {
            textBoxSenha.Clear();
            textBoxSenha.ForeColor = Color.Red;
            textBoxSenha.UseSystemPasswordChar = true;
        }
        private void textBoxSenha_Leave(object sender, EventArgs e)
        {
            if (textBoxSenha.Text == string.Empty)
            {
                textBoxSenha.Text = "SENHA";
                textBoxSenha.ForeColor = Color.IndianRed;
                textBoxSenha.UseSystemPasswordChar = false;
            }
            else { buttonConfirmar.Focus(); }
        }

        private void formVendasConfirmacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void formVendasConfirmacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (buttonConfirmar.Focused == true)
                {
                    buttonConfirmar_Click(sender, e);
                    e.Handled = true;
                }
                else
                {
                    ProcessTabKey(true);
                    e.Handled = true;
                }
            }
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            Acessar();
        }

        private void textBoxUsuario_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBoxUsuario.Text == "MATRÍCULA")
            {
                textBoxUsuario.Clear();
                textBoxUsuario.ForeColor = Color.Red;
            }
        }

        private void textBoxUsuario_Enter(object sender, EventArgs e)
        {
            if (textBoxUsuario.Text == "MATRÍCULA")
            {
                textBoxUsuario.Clear();
                textBoxUsuario.ForeColor = Color.Red;
            }
        }
        private void textBoxUsuario_Leave(object sender, EventArgs e)
        {
            if (textBoxUsuario.Text == string.Empty)
            {
                textBoxUsuario.Text = "MATRÍCULA";
                textBoxUsuario.ForeColor = Color.IndianRed;
                textBoxUsuario.TabStop = true;
            }
            else
            {
                textBoxUsuario.TabStop = false;
            }
        }

        private void Acessar()
        {
            string login = textBoxUsuario.Text;
            string senha = textBoxSenha.Text;

            bool acesso_matricula = comandos.verificarMatricula(login, senha);
            bool acesso_login = false;
            bool acesso = false;

            if (acesso_matricula)
            {

                acesso = comandos.verificarPermissaoAtravesDaMatricula(login, permissao);
            }
            else
            {
                acesso_login = comandos.verificarLogin(login, senha); 
            }

            if (!acesso_matricula)
            {
                if (acesso_login)
                {
                    acesso = comandos.verificarPermissaoAtravesDoLogin(login, permissao);
                }
            }

            if (acesso && acesso_matricula || acesso && acesso_login)
            {
                if (pdv) { pai.concessao = true; }
                else { father.concessao = true; }
                Dispose();
            }
            else
            {
                MessageBox.Show("Acesso negado!\r\nVerifique as informações fornecidas ou certifique-se\r\nde que você tem permissão para acessar essa área.", "Negado!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
