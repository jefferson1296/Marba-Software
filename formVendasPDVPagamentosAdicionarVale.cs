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
    public partial class formVendasPDVPagamentosAdicionarVale : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formVendasPDVPagamentosAdicionar pai = new formVendasPDVPagamentosAdicionar();

        decimal valor;
        public formVendasPDVPagamentosAdicionarVale()
        {
            InitializeComponent();
        }
        public formVendasPDVPagamentosAdicionarVale(decimal Valor, formVendasPDVPagamentosAdicionar Pai)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            pai = Pai;
            valor = Valor;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void buttonFinalizar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Informe o número do Vale-troca!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = Convert.ToInt32(textBox1.Text);
                Vale_Troca vale = comandos.InformacoesDoValeTroca(id);

                if (vale.ID_Troca == 0)
                {
                    MessageBox.Show("Número do Vale-troca inválido!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (vale.Validade.Date < DateTime.Now.Date)
                {
                    MessageBox.Show("Vale-troca vencido!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (vale.Status == "Concluído")
                {
                    MessageBox.Show("Esse vale-troca já foi utilizado como pagamento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    bool valor_superior = false;

                    if (vale.Valor > 0)
                    {
                        bool continuar = false;

                        if (pai.pai.pdv.pai.Vales.Contains(id))
                        {
                            MessageBox.Show("Não é possível utilizar o mesmo vale duas vezes!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (vale.Valor > valor)
                        {
                            if (DialogResult.Yes == MessageBox.Show("O Vale-troca tem valor superior ao valor da compra.\r\nNosso sistema não permite troco para Vale-troca.\r\nOriente o cliente a completar o valor com produtos\r\nou o saldo restante será extinto.\r\nO cliente deseja continuar mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                            {
                                continuar = true;
                                valor_superior = true;
                            }
                        }
                        else
                        {
                            continuar = true;
                        }

                        if (continuar)
                        {
                            pai.vale = true;
                            if (valor_superior)
                            {
                                pai.textBoxPagamento.Text = valor.ToString("C");
                                pai.textBoxPago.Text = valor.ToString("C");
                            }
                            else
                            {
                                pai.textBoxPagamento.Text = vale.Valor.ToString("C");
                                pai.textBoxPago.Text = vale.Valor.ToString("C");
                            }
                            pai.textBoxPagamento.ReadOnly = true;
                            pai.textBoxPago.ReadOnly = true;
                            pai.pai.pdv.pai.Vales.Add(id);
                            Dispose();
                        }
                    }
                }
            }                        
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            pai.textBoxPago.Text = "R$0,00";
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
