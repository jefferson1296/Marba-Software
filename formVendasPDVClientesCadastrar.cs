using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MarbaSoftware
{
    public partial class formVendasPDVClientesCadastrar : Form
    {
        ValidadorClientes validacao = new ValidadorClientes();
        ComandosSQL comandos = new ComandosSQL();
        bool naoPossuiCelular = false;
        public formVendasPDVClientesCadastrar()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            if (!validacao.CPF(maskedTextBoxCPF.Text))
            {
                MessageBox.Show("CPF Inválido!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!naoPossuiCelular && !validacao.Telefone(maskedTextBoxCelular.Text))
            {
                MessageBox.Show("Celular Inválido!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txbNome.Text == string.Empty || maskedTextBoxCPF.Text == string.Empty)
            {
                MessageBox.Show("É obrigatório informar nome e CPF\r\n para concluir o cadastro.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Conexao conexao = new Conexao();

                string[] mascara = maskedTextBoxCPF.Text.Split('.');
                string[] dig = mascara[2].Split('-');
                string nome = txbNome.Text;
                string cpf = mascara[0] + mascara[1] + dig[0] + dig[1];
                string nascimento = dateTimePicker.Text;
                string cep = maskedTextBoxCEP.Text;
                string telefone;
                string celular;
                string email;


                if (maskedTextBoxTelefone.Text == "(  )      -")
                {
                    telefone = string.Empty;
                }
                else
                {
                    telefone = maskedTextBoxTelefone.Text;
                }

                if (maskedTextBoxCelular.Text == "(  )      -")
                {
                    celular = string.Empty;
                }
                else
                {
                    celular = maskedTextBoxCelular.Text;
                }

                if (txbEmail.Text == "exemplo@exemplo.com")
                {
                    email = string.Empty;
                }
                else
                {
                    email = txbEmail.Text;
                }
               

                if (checkBoxRevendedor.Checked)
                {
                    //tabela = "Revendedor";
                }
                else
                {
                    //tabela = "Cliente";
                }

                Cliente Cliente = new Cliente()
                {
                    Nome = nome,
                    CPF = cpf,
                    Telefone = telefone,        
                    Email = email,          
                    Nascimento = nascimento,
                    CEP = cep
                };

                comandos.CadastrarCliente(Cliente);
                Dispose();
            }
        }
        private void checkBoxCelular_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCelular.Checked)
            {
                naoPossuiCelular = true;
            }
            else
            {
                naoPossuiCelular = false;
            }
        }

        private void txbEmail_Enter(object sender, EventArgs e)
        {
            if (txbEmail.Text == "exemplo@exemplo.com")
            {
                txbEmail.Text = string.Empty;
                txbEmail.ForeColor = Color.Black;
            }
        }

        private void txbEmail_Leave(object sender, EventArgs e)
        {
            if (txbEmail.Text == string.Empty)
            {
                txbEmail.Text = "exemplo@exemplo.com";
                txbEmail.ForeColor = Color.DarkGray;
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
