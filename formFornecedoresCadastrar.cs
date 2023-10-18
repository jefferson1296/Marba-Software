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
    public partial class formFornecedoresCadastrar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formFornecedoresCadastrar()
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
            Fornecedor Fornecedor = new Fornecedor();
            ValidadorClientes validacao = new ValidadorClientes();
            string fornecedor = fornecedorTextBox.Text;
            int reposicao = Convert.ToInt32(reposicaoTextBox.Text);
            string frete = freteComboBox.Text;
            string forma_pgmt = pagamentoComboBox.Text;
            int entrega = Convert.ToInt32(entregaTextBox.Text);
            bool disponibilidade = disponibilidadeCheckBox.Checked;
            string representante = representanteTextBox.Text;
            string telefone = telefoneMaskedTextBox.Text;
            if (telefone == "(  )      -") { telefone = string.Empty; }
            string endereco = enderecoTextBox.Text;
            string[] partir = textBoxMinimo.Text.Split('$');
            decimal minimo = Convert.ToDecimal(partir[1]);
            string[] partir1 = ipiTextBox.Text.Split('%');
            decimal ipi = Convert.ToDecimal(partir1[0]);
            string[] partir2 = icmsTextBox.Text.Split('%');
            decimal icms = Convert.ToDecimal(partir2[0]);
            string email = emailTextBox.Text;
            if (email == "exemplo@exemplo.com") { email = string.Empty; }
            bool ativacao = ativacaoCheckBox.Checked;
            string troca;
            if (trocaCheckBox.Checked) { troca = "Sim"; }
            else { troca = "Não"; }

            if (fornecedor == string.Empty) { MessageBox.Show("Informe o fornecedor para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else if (comandos.VerificarSeFornecedorJaExiste(fornecedor)) { MessageBox.Show("Já existe um outro fornecedor cadastrado com esse nome!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else if (reposicao == 0) { MessageBox.Show("Informe o período de reposição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else if (frete == string.Empty) { MessageBox.Show("Informe o frete para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else if (forma_pgmt == string.Empty) { MessageBox.Show("Informe a forma de pagamento para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else if (telefone != string.Empty && !validacao.Telefone(telefone)) { MessageBox.Show("Informe um telefone do representante válido ou deixe o campo em branco para continuar!", "Telefone inválido!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else if (entrega == 0) { MessageBox.Show("Informe o prazo de entrega para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else
            {
                Fornecedor.Nome_Fornecedor = fornecedor;
                Fornecedor.Reposicao = reposicao;
                Fornecedor.Frete = frete;
                Fornecedor.Forma_Pagamento = forma_pgmt;
                Fornecedor.Entrega = entrega;
                Fornecedor.Disponibilidade = disponibilidade;
                Fornecedor.Representante = representante;
                Fornecedor.Fone_Representante = telefone;
                Fornecedor.Endereco = endereco;
                Fornecedor.Ativacao = ativacao;
                Fornecedor.Troca = troca;
                Fornecedor.Email = email;
                Fornecedor.IPI = ipi;
                Fornecedor.ICMS = icms;
                Fornecedor.Pedido_Minimo = minimo;

                comandos.CadastrarFornecedor(Fornecedor);
                Dispose();
            }
        }

        #region Movimentacao do Formulario
        bool clique;
        Point clickedAt;
        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique)
            {
                Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
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

        private void reposicaoTextBox_Enter(object sender, EventArgs e)
        {
            if (reposicaoTextBox.Text == "0")
                reposicaoTextBox.Text = string.Empty;
        }

        private void reposicaoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void reposicaoTextBox_Leave(object sender, EventArgs e)
        {
            if (reposicaoTextBox.Text == string.Empty)
                reposicaoTextBox.Text = "0";
        }

        private void entregaTextBox_Enter(object sender, EventArgs e)
        {
            if (entregaTextBox.Text == "0")
                entregaTextBox.Text = string.Empty;
        }

        private void entregaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void entregaTextBox_Leave(object sender, EventArgs e)
        {
            if (entregaTextBox.Text == string.Empty)
                entregaTextBox.Text = "0";
        }

        private void textBoxMinimo_Enter(object sender, EventArgs e)
        {
            if (textBoxMinimo.Text == "R$0,00")
            {
                textBoxMinimo.Text = string.Empty;
            }
            else
            {
                string[] partir = textBoxMinimo.Text.Split('$');
                textBoxMinimo.Text = partir[1];
            }
        }

        private void textBoxMinimo_Leave(object sender, EventArgs e)
        {
            if (textBoxMinimo.Text == string.Empty)
            {
                textBoxMinimo.Text = "R$0,00";
            }
            else
            {
                textBoxMinimo.Text = Convert.ToDouble(textBoxMinimo.Text).ToString("C");
            }
        }

        private void textBoxMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
             (e.KeyChar != ',' && e.KeyChar != '.' &&
              e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!textBoxMinimo.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (Char)0;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void ipiTextBox_Enter(object sender, EventArgs e)
        {
            ipiTextBox.ForeColor = Color.Black;
            if (ipiTextBox.Text == "0,00%")
            {
                ipiTextBox.Text = string.Empty;
            }
            else
            {
                string[] partir = ipiTextBox.Text.Split('%');
                ipiTextBox.Text = partir[0];
            }
        }
        private void ipiTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
            (e.KeyChar != ',' && e.KeyChar != '.' &&
            e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!ipiTextBox.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (Char)0;
                    }
                }
            }
        }
        private void ipiTextBox_Leave(object sender, EventArgs e)
        {
            if (ipiTextBox.Text == string.Empty)
            {
                ipiTextBox.Text = "0,00%";
                icmsTextBox.ForeColor = Color.Gray;
            }
            else
            {
                decimal aliquota_ipi = Convert.ToDecimal(ipiTextBox.Text);
                ipiTextBox.Text = aliquota_ipi.ToString("F") + "%";
            }
        }
        private void icmsTextBox_Enter(object sender, EventArgs e)
        {
            icmsTextBox.ForeColor = Color.Black;
            if (icmsTextBox.Text == "0,00%")
            {
                icmsTextBox.Text = string.Empty;
            }
            else
            {
                string[] partir = icmsTextBox.Text.Split('%');
                icmsTextBox.Text = partir[0];
            }
        }
        private void icmsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
            (e.KeyChar != ',' && e.KeyChar != '.' &&
            e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!icmsTextBox.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (Char)0;
                    }
                }
            }
        }
        private void icmsTextBox_Leave(object sender, EventArgs e)
        {
            if (icmsTextBox.Text == string.Empty)
            {
                icmsTextBox.Text = "0,00%";
                icmsTextBox.ForeColor = Color.Gray;
            }
            else
            {
                decimal aliquota_icms = Convert.ToDecimal(icmsTextBox.Text);
                icmsTextBox.Text = aliquota_icms.ToString("F") + "%";
            }
        }

        private void emailTextBox_Enter(object sender, EventArgs e)
        {
            if (emailTextBox.Text == "exemplo@exemplo.com")
            {
                emailTextBox.Text = string.Empty;
                emailTextBox.ForeColor = Color.Black;
            }
        }
        private void emailTextBox_Leave(object sender, EventArgs e)
        {
            if (emailTextBox.Text == string.Empty)
            {
                emailTextBox.Text = "exemplo@exemplo.com";
                emailTextBox.ForeColor = Color.DarkGray;
            }
            else
            {
                emailTextBox.ForeColor = Color.Black;
            }
        }
    }
}
