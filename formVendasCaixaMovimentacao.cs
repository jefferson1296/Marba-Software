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
    public partial class formVendasCaixaMovimentacao : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        string movimentacao;
        string operador;
        public bool alteracao;
        formVendasCaixaSangriasSuprimentos form;
        decimal valor;
        int id;
        public formVendasCaixaMovimentacao()
        {
            InitializeComponent();
        }
        public formVendasCaixaMovimentacao(formVendasCaixaSangriasSuprimentos Form, string Movimentacao)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            movimentacao = Movimentacao;
            form = Form;
        }
        public formVendasCaixaMovimentacao(int ID, formVendasCaixaSangriasSuprimentos Form, string Movimentacao, decimal Valor)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            movimentacao = Movimentacao;
            form = Form;
            valor = Valor;
            id = ID;
        }

        private void formVendasMovimentacao_Load(object sender, EventArgs e)
        {
            comboBox1.Text = movimentacao;
            if (movimentacao == "Suprimento")
            {
                textBox1.Text = valor.ToString("C");
                textBox1.Enabled = false;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                textBox1.Text = 0.ToString("C");
                textBox1.ForeColor = Color.DimGray;
            }
            else
            {
                textBox1.Text = Convert.ToDouble(textBox1.Text).ToString("C");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!textBox1.Text.Contains(','))
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

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            if (textBox1.Text == "R$0,00")
            {
                textBox1.Text = string.Empty;
            }
            else
            {
                string[] partir = textBox1.Text.Split('$');
                textBox1.Text = partir[1];
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string[] partir = textBox1.Text.Split('$');
            decimal valor = Convert.ToDecimal(partir[1]);

            if (valor == 0)
            {
                MessageBox.Show("É necessário informar o valor para concluir a movimentação!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (movimentacao == "Sangria" || movimentacao == "Sobrando")
                {
                    form.valor = textBox1.Text;
                    comandos.SalvarMovimentacaoDoCaixaSemDigital(movimentacao, valor);
                    MessageBox.Show("Sangria de caixa registrada.", "Registro.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    form.permitir = true;
                    Dispose();
                }
                else if (movimentacao == "Suprimento")
                {
                    if (comandos.VerificarSeHaSuprimentoEmAberto())
                    {
                        form.valor = textBox1.Text;
                        comandos.SalvarSuprimentoSemDigital(id);
                        MessageBox.Show("Suprimento registrado.", "Registro.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        form.permitir = true;
                        Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Não há nenhum suprimento registrado.\r\n É necessário registrar o suprimento na esfera administrativa antes de registrar no caixa.\r\nEm caso de dúvidas, informe à gestão.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


                //formVendasMovimentacaoDigital digital;
                //if (movimentacao == "Suprimento")
                //{
                //    digital = new formVendasMovimentacaoDigital(id, movimentacao, valor, this);
                //}
                //else
                //{
                //    digital = new formVendasMovimentacaoDigital(movimentacao, valor, this);
                //}

                //digital.ShowDialog();
                //if (alteracao)
                //{
                //    form.permitir = true;
                //    form.valor = textBox1.Text;
                //    Dispose();
                //}
            }
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
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
    }
}
