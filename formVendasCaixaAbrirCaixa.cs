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
    public partial class formVendasCaixaAbrirCaixa : Form
    {
        formVendasCaixaAtual caixaAtual = new formVendasCaixaAtual();
        ComandosSQL comandos = new ComandosSQL();
        public formVendasCaixaAbrirCaixa()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }
        public formVendasCaixaAbrirCaixa(formVendasCaixaAtual Caixa)
        {
            InitializeComponent();
            caixaAtual = Caixa;
            new Sombra().ApplyShadows(this);
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBoxValor.Text == "R$0,00")
            {
                textBoxValor.Text = string.Empty;
            }
            else
            {
                string[] partir = textBoxValor.Text.Split('$');
                textBoxValor.Text = partir[1];
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBoxValor.Text == string.Empty)
            {
                textBoxValor.Text = "R$0,00";
            }
            else
            {
                textBoxValor.Text = Convert.ToDecimal(textBoxValor.Text).ToString("C");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
                e.KeyChar != ',' && e.KeyChar != '.' &&
                e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.KeyChar = (char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!textBoxValor.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (char)0;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] partir = textBoxValor.Text.Split('$');
            decimal valor = Convert.ToDecimal(partir[1]);
            int terminal;
            try { terminal = Convert.ToInt32(comboBoxTerminal.Text); }
            catch { terminal = 0; }

            bool continuar;
            decimal abertura = comandos.ObterValorDoParametro("Valor de abertura do caixa");

            if (terminal == 0)
            {
                MessageBox.Show("Informe o terminal para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                continuar = false;
            }
            else if (!comandos.VerificarTerminal(terminal) && !Program.Acessos.Where(x => x.Descricao == "Sobrepor terminal aberto").Select(x => x.Permissao).FirstOrDefault())
            {
                MessageBox.Show("Esse terminal consta como \"Aberto\".\r\nIsso significa que alguém está operando nele ou que \r\n o útltimo operador a utilizá-lo não fechou o caixa corretamente.\r\nCaso necessário, informe à gestão.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                continuar = false;
            }
            else if (abertura > valor)
            {
                if (DialogResult.Yes == MessageBox.Show("O valor informado é inferior ao valor padrão de abertura do caixa.\r\nSe você  continuar, uma notificação será enviada à gestão.\r\nTem certeza que deseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    continuar = true;
                    //comandos.GerarNotificacao()
                }
                else { continuar = false; }
            }
            else if (abertura < valor)
            {
                if (DialogResult.Yes == MessageBox.Show("O valor informado é superior ao valor padrão de abertura do caixa.\r\nSe você  continuar, uma notificação será enviada à gestão.\r\nTem certeza que deseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    continuar = true;
                    //comandos.GerarNotificacao()
                }
                else { continuar = false; }
            }
            else
            {
                continuar = true;
            }



            if (continuar)
            {
                comandos.AbrirTerminal(terminal, valor);
                comandos.AbrirCaixa(terminal, valor);

                caixaAtual.labelCaixaFechado.Visible = false;
                caixaAtual.labelNenhumaVenda.Visible = true;
                caixaAtual.buttonAbrir.Visible = false;
                caixaAtual.buttonFecharCaixa.Visible = true;
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

        private void formVendasAbrirCaixa_Load(object sender, EventArgs e)
        {
            List<string> terminais = comandos.ListaDeTerminais();
            comboBoxTerminal.Items.Clear();
            foreach (string terminal in terminais) { comboBoxTerminal.Items.Add(terminal); }
        }
    }
}
