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
    public partial class formLogin : Form
    {
        Login acesso = new Login();
        formMarbaSoftware acessando = new formMarbaSoftware();
        ComandosSQL comandos = new ComandosSQL();
        string id_computador;
        string usuario;
        public formLogin(string ID_computador, string Usuario)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            id_computador = ID_computador;
            usuario = Usuario;
        }
        private void buttonFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #region Definições de Entrada
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
            else { buttonAcessar.Focus(); }
        }
        private void label2_MouseEnter(object sender, EventArgs e)
        {
            labelEsqueceuSenha.ForeColor = Color.DarkGoldenrod;
        }

        private void labelEsqueceuSenha_MouseLeave(object sender, EventArgs e)
        {
            labelEsqueceuSenha.ForeColor = Color.White;
        }
        #endregion

        private void buttonAcessar_Click(object sender, EventArgs e)
        {
            Acessar();
        }

        private void Acessar()
        {
            string login = textBoxUsuario.Text;
            string senha = textBoxSenha.Text;

            bool acessou = false;

            acesso.AcessarComMatricula(login, senha);

            if (acesso.mensagem.Equals(""))
            {
                if (acesso.confirmacao)
                {
                    acessou = true;
                    Program.colaborador = comandos.TrazerColaboradorPelaMatricula(login);
                    Program.matricula = login;
                    timerTransparente.Enabled = true;
                }                
                else
                {
                    acessou = false;
                }
            }

            if (!acessou)
            {
                acesso.AcessarComLogin(login, senha);

                if (acesso.mensagem.Equals(""))
                {
                    if (acesso.confirmacao)
                    {
                        Program.colaborador = comandos.TrazerColaboradorPeloLogin(login);
                        Program.matricula = Program.colaborador.Matricula;

                        timerTransparente.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Matrícula ou Senha incorretas!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(acesso.mensagem);
                }                
            }
        }

        private void timerTransparente_Tick(object sender, EventArgs e)
        {
            if (Opacity == 0)
            {
                timerTransparente.Stop();
                Hide();
                acessando.Show();
                timerTransparente.Stop();
            }
            else
            {
                Opacity = Opacity - 0.03;
            }
        }

        private void labelEsqueceuSenha_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se você esqueceu sua senha, informe imediatamente a gestão.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void labelRedefinir_Click(object sender, EventArgs e)
        {
            formNovaSenha senha = new formNovaSenha();
            senha.ShowDialog();
        }

        #region Movimentacao do Formulario
        bool clique;
        Point clickedAt;
        private void formLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            clique = true;
            clickedAt = e.Location;
        }

        private void formLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique)
            {
                this.Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
            }
        }

        private void formLogin_MouseUp(object sender, MouseEventArgs e)
        {
            clique = false;
        }
        #endregion

        private void formLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void formLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (buttonAcessar.Focused == true)
                {
                    buttonAcessar_Click(sender, e);
                    e.Handled = true;
                }
                else
                {
                    ProcessTabKey(true);
                    e.Handled = true;
                }
            }
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            Program.Computador = comandos.TrazerInformacoesDoComputador(id_computador, usuario);
            Program.Computador.ID = id_computador;
            Program.Computador.Usuario = usuario;
        }
    }
}
