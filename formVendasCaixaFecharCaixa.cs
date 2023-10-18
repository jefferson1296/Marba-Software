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
    public partial class formVendasCaixaFecharCaixa : Form
    {
        formVendasCaixaAtual caixaAtual = new formVendasCaixaAtual();
        ComandosSQL comandos = new ComandosSQL();
        bool fechar_pelo_id;
        int id_caixa;

        decimal Total;
        decimal Registrado;
        decimal Quebra;
        decimal Abertura;
        decimal Dinheiro;
        decimal Debito;
        decimal Credito;
        decimal Picpay;
        decimal Vale;
        decimal Pix;
        public formVendasCaixaFecharCaixa()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }
        public formVendasCaixaFecharCaixa(formVendasCaixaAtual Caixa)
        {
            InitializeComponent();
            caixaAtual = Caixa;
            new Sombra().ApplyShadows(this);
        }

        public formVendasCaixaFecharCaixa(int ID_Caixa)
        {
            InitializeComponent();
            id_caixa = ID_Caixa;
            fechar_pelo_id = true;
            new Sombra().ApplyShadows(this);
        }

        private void formVendasFecharCaixa_Load(object sender, EventArgs e)
        {
            decimal sangria = 0;
            decimal suprimento = 0;
            decimal sobrando = 0;
            decimal dinheiro = 0;
            decimal debito = 0;
            decimal credito = 0;
            decimal picpay = 0;
            decimal vale = 0;
            decimal pix = 0;
            decimal abertura = 0;

            List<InformacoesFechamento> lista = new List<InformacoesFechamento>();

            if (fechar_pelo_id)
            {
                lista = comandos.InformacoesDoFechamentoDeCaixaPeloID(id_caixa);
            }
            else
            {
                lista = comandos.InformacoesDoFechamentoDeCaixa();
            }

            foreach (InformacoesFechamento info in lista)
            {
                dinheiro = info.Dinheiro;
                debito = info.Debito;
                credito = info.Credito;
                pix = info.Pix;
                picpay = info.PICPAY;
                vale = info.Vale;
                sangria = info.Sangrias;
                suprimento = info.Suprimentos;
                sobrando = info.Sobrando;
                abertura = info.Abertura;
            }

            dinheiro = dinheiro + abertura + suprimento - sangria;
            decimal registrado = dinheiro + debito + credito + picpay + pix + vale;
            Registrado = registrado;
            Abertura = abertura;

            label12.Text = dinheiro.ToString("C");
            label13.Text = debito.ToString("C");
            label14.Text = credito.ToString("C");
            label16.Text = pix.ToString("C");
            label17.Text = vale.ToString("C");
            label9.Text = picpay.ToString("C");

            textBoxRegistrado.Text = Registrado.ToString("C");
            CalcularTotal();
        }
        public void CalcularTotal()
        {
            Total = Dinheiro + Debito + Credito + Picpay + Vale + Pix;
            textBoxTotal.Text = Total.ToString("C");

            Quebra = Registrado - Total;
            if (Quebra >= 0)
            {
                labelDiferenca.Text = "Está faltando:";
                textBoxQuebra.ForeColor = Color.Firebrick;
                textBoxQuebra.Text = Quebra.ToString("C");
            }
            else
            {
                labelDiferenca.Text = "Está sobrando:";
                textBoxQuebra.ForeColor = Color.LimeGreen;
                textBoxQuebra.Text = (-Quebra).ToString("C");
            }
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void buttonFechar_Click(object sender, EventArgs e)
        {
            bool continuar;

            decimal sangria = 0;
            decimal suprimento = 0;
            decimal sobrando = 0;
            decimal dinheiro = 0;
            decimal debito = 0;
            decimal credito = 0;
            decimal vale = 0;
            decimal pix = 0;
            decimal picpay = 0;
            decimal abertura = 0;

            List<InformacoesFechamento> list = comandos.InformacoesDoFechamentoDeCaixa();
            foreach (InformacoesFechamento info in list)
            {
                dinheiro = info.Dinheiro;
                debito = info.Debito;
                credito = info.Credito;
                pix = info.Pix;
                vale = info.Vale;
                sangria = info.Sangrias;
                suprimento = info.Suprimentos;
                picpay = info.PICPAY;
                sobrando = info.Sobrando;
                abertura = info.Abertura;
            }
            dinheiro = dinheiro + abertura + suprimento - sangria;

            InformacoesFechamento informacoes = new InformacoesFechamento()
            {
                Dinheiro = Dinheiro,
                Debito = Debito,
                Credito = Credito,
                Pix = Pix,
                Vale = Vale,
                PICPAY = Picpay,
                Quebra = Quebra,
                Total = Total
            };

            if (comandos.VerificarMovimentacoesPendentes())
            {
                MessageBox.Show("O sistema identificou que há movimentações em aberto.\r\nVerifique as sangrias e suprimentos e conclua as movimentação para continuar.\r\nCaso a dúvida permaneça, informe imediatamente à gestão.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (Quebra > 0)
                {
                    if (DialogResult.Yes == MessageBox.Show("Está faltando " + Quebra.ToString("C") + ".\r\nSe você  continuar, uma notificação será enviada à gestão.\r\nDeseja fechar o caixa mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        continuar = true;
                        //comandos.GerarNotificacao()
                    }
                    else { continuar = false; }
                }
                else if (Quebra < 0)
                {
                    if (DialogResult.Yes == MessageBox.Show("Está sobrando " + Quebra.ToString("C") + ".\r\nSe você  continuar, uma notificação será enviada à gestão.\r\nDeseja fechar o caixa mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
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

                decimal valor_abertura = comandos.ObterValorDoParametro("Valor de abertura do caixa");

                if (Dinheiro < valor_abertura)
                {
                    if (DialogResult.Yes == MessageBox.Show("O sistema identificou que o valor em espécie\r\ninformado é inferior ao valor padrão de abertura.\r\nSe você  continuar, uma notificação será enviada à gestão.\r\nDeseja fechar o caixa mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        continuar = true;
                        //comandos.GerarNotificacao()
                    }
                    else { continuar = false; }
                }
                else if (Dinheiro > valor_abertura)
                {
                    if (DialogResult.Yes == MessageBox.Show("O sistema identificou que o valor em espécie\r\ninformado é superior ao valor padrão de abertura.\r\nSe você  continuar, uma notificação será enviada à gestão.\r\nDeseja fechar o caixa mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        continuar = true;
                        //comandos.GerarNotificacao()
                    }
                    else { continuar = false; }
                }

                if (continuar)
                {
                    if (informacoes.Dinheiro != dinheiro)
                    {
                        //comandos.GerarNotificacao()
                    }
                    if (informacoes.Debito != debito)
                    {
                        //comandos.GerarNotificacao()
                    }
                    if (informacoes.Credito != credito)
                    {
                        //comandos.GerarNotificacao()
                    }

                    if (informacoes.Pix != pix)
                    {
                        //comandos.GerarNotificacao()
                    }
                    if (informacoes.Vale != vale)
                    {
                        //comandos.GerarNotificacao()
                    }
                    if (informacoes.PICPAY != picpay)
                    {
                        //comandos.GerarNotificacao()
                    }

                    int caixa = comandos.TrazerIdDoCaixa();
                    Movimentacao vendas_stone = new Movimentacao() 
                    { 
                        Descricao = "VENDAS STONE - " + caixa.ToString(),
                        Valor = Debito + Credito
                    };

                    Movimentacao transferencias = new Movimentacao()
                    {
                        Descricao = "PAGAMENTOS POR TRANSFERÊNCIA - " + caixa.ToString(),
                        Valor = Pix
                    };

                    Movimentacao quebra = new Movimentacao()
                    {
                        Descricao = "QUEBRA DE CAIXA - " + caixa.ToString(),
                        Valor = Quebra
                    };

                    Recebivel deb = new Recebivel()
                    {
                        Descricao = "VENDAS DÉBITO - " + caixa.ToString(),
                        Valor = debito
                    };

                    Recebivel cred = new Recebivel()
                    {
                        Descricao = "VENDAS CRÉDITO - " + caixa.ToString(),
                        Valor = credito
                    };

                    comandos.FecharTerminal(Dinheiro);

                    //comandos.RegistrarRecebiveis(deb, cred);
                    //comandos.RegistrarJurosDaMaquineta(caixa);
                    //comandos.RegistrarMovimentacoesDoFechamento(vendas_stone, quebra, transferencias);
                    //comandos.RegistrarSaldoDeReposicao(caixa);
                    comandos.FecharCaixa(informacoes);

                    MessageBox.Show("Caixa encerrado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Dispose();
                }
            }            
        }

        #region Formatação de Texto
        private void txbEspecie1_TextChanged(object sender, EventArgs e)
        {
            if (txbEspecie.Text == string.Empty)
            {
                Dinheiro = 0;
            }
            else
            {
                try
                {
                    Dinheiro = Convert.ToDecimal(txbEspecie.Text);
                }
                catch
                {
                    string[] partir = txbEspecie.Text.Split('$');
                    Dinheiro = Convert.ToDecimal(partir[1]);
                }
            }
            CalcularTotal();
        }

        private void txbEspecie1_Enter(object sender, EventArgs e)
        {
            if (txbEspecie.Text == "R$0,00")
            {
                txbEspecie.Text = string.Empty;
            }
            else
            {
                string[] partir = txbEspecie.Text.Split('$');
                txbEspecie.Text = partir[1];
            }
        }

        private void txbEspecie1_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!txbEspecie.Text.Contains(','))
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

        private void txbEspecie1_Leave(object sender, EventArgs e)
        {
            if (txbEspecie.Text == string.Empty)
            {
                txbEspecie.Text = 0.ToString("C");
            }
            else
            {
                txbEspecie.Text = Convert.ToDouble(txbEspecie.Text).ToString("C");
            }
        }

        private void txbDebito1_TextChanged(object sender, EventArgs e)
        {
            if (txbDebito.Text == string.Empty)
            {
                Debito = 0;
            }
            else
            {
                try
                {
                    Debito = Convert.ToDecimal(txbDebito.Text);
                }
                catch
                {
                    string[] partir = txbDebito.Text.Split('$');
                    Debito = Convert.ToDecimal(partir[1]);
                }
            }
            CalcularTotal();
        }

        private void txbDebito1_Enter(object sender, EventArgs e)
        {
            if (txbDebito.Text == "R$0,00")
            {
                txbDebito.Text = string.Empty;
            }
            else
            {
                string[] partir = txbDebito.Text.Split('$');
                txbDebito.Text = partir[1];
            }
        }

        private void txbDebito1_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!txbDebito.Text.Contains(','))
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

        private void txbDebito1_Leave(object sender, EventArgs e)
        {
            if (txbDebito.Text == string.Empty)
            {
                txbDebito.Text = 0.ToString("C");
            }
            else
            {
                txbDebito.Text = Convert.ToDouble(txbDebito.Text).ToString("C");
            }
        }

        private void txbCredito1_TextChanged(object sender, EventArgs e)
        {
            if (txbCredito.Text == string.Empty)
            {
                Credito = 0;
            }
            else
            {
                try
                {
                    Credito = Convert.ToDecimal(txbCredito.Text);
                }
                catch
                {
                    string[] partir = txbCredito.Text.Split('$');
                    Credito = Convert.ToDecimal(partir[1]);
                }
            }
            CalcularTotal();
        }

        private void txbCredito1_Enter(object sender, EventArgs e)
        {
            if (txbCredito.Text == "R$0,00")
            {
                txbCredito.Text = string.Empty;
            }
            else
            {
                string[] partir = txbCredito.Text.Split('$');
                txbCredito.Text = partir[1];
            }
        }

        private void txbCredito1_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!txbCredito.Text.Contains(','))
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

        private void txbCredito1_Leave(object sender, EventArgs e)
        {
            if (txbCredito.Text == string.Empty)
            {
                txbCredito.Text = 0.ToString("C");
            }
            else
            {
                txbCredito.Text = Convert.ToDouble(txbCredito.Text).ToString("C");
            }
        }

        private void txbPix1_TextChanged(object sender, EventArgs e)
        {
            if (txbPix.Text == string.Empty)
            {
                Pix = 0;
            }
            else
            {
                try
                {
                    Pix = Convert.ToDecimal(txbPix.Text);
                }
                catch
                {
                    string[] partir = txbPix.Text.Split('$');
                    Pix = Convert.ToDecimal(partir[1]);
                }
            }
            CalcularTotal();
        }

        private void txbPix1_Enter(object sender, EventArgs e)
        {
            if (txbPix.Text == "R$0,00")
            {
                txbPix.Text = string.Empty;
            }
            else
            {
                string[] partir = txbPix.Text.Split('$');
                txbPix.Text = partir[1];
            }
        }

        private void txbPix1_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!txbPix.Text.Contains(','))
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

        private void txbPix1_Leave(object sender, EventArgs e)
        {
            if (txbPix.Text == string.Empty)
            {
                txbPix.Text = 0.ToString("C");
            }
            else
            {
                txbPix.Text = Convert.ToDouble(txbPix.Text).ToString("C");
            }
        }
        private void txbVale_TextChanged(object sender, EventArgs e)
        {
            if (txbVale.Text == string.Empty)
            {
                Vale = 0;
            }
            else
            {
                try
                {
                    Vale = Convert.ToDecimal(txbVale.Text);
                }
                catch
                {
                    string[] partir = txbVale.Text.Split('$');
                    Vale = Convert.ToDecimal(partir[1]);
                }
            }
            CalcularTotal();
        }

        private void txbVale_Enter(object sender, EventArgs e)
        {
            if (txbVale.Text == "R$0,00")
            {
                txbVale.Text = string.Empty;
            }
            else
            {
                string[] partir = txbVale.Text.Split('$');
                txbVale.Text = partir[1];
            }
        }

        private void txbVale_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!txbVale.Text.Contains(','))
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

        private void txbVale_Leave(object sender, EventArgs e)
        {
            if (txbVale.Text == string.Empty)
            {
                txbVale.Text = 0.ToString("C");
            }
            else
            {
                txbVale.Text = Convert.ToDouble(txbVale.Text).ToString("C");
            }
        }
        #endregion

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

        private void txbPicPay_TextChanged(object sender, EventArgs e)
        {
            if (txbPicPay.Text == string.Empty)
            {
                Picpay = 0;
            }
            else
            {
                try
                {
                    Picpay = Convert.ToDecimal(txbPicPay.Text);
                }
                catch
                {
                    string[] partir = txbPicPay.Text.Split('$');
                    Picpay = Convert.ToDecimal(partir[1]);
                }
            }
            CalcularTotal();
        }

        private void txbPicPay_Enter(object sender, EventArgs e)
        {
            if (txbPicPay.Text == "R$0,00")
            {
                txbPicPay.Text = string.Empty;
            }
            else
            {
                string[] partir = txbPicPay.Text.Split('$');
                txbPicPay.Text = partir[1];
            }
        }

        private void txbPicPay_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!txbPicPay.Text.Contains(','))
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

        private void txbPicPay_Leave(object sender, EventArgs e)
        {
            if (txbPicPay.Text == string.Empty)
            {
                txbPicPay.Text = 0.ToString("C");
            }
            else
            {
                txbPicPay.Text = Convert.ToDouble(txbPicPay.Text).ToString("C");
            }
        }

        private void pictureBoxMoedas_Click(object sender, EventArgs e)
        {
            formVendasCaixaContadorDeMoedas moedas = new formVendasCaixaContadorDeMoedas();
            moedas.Show();
        }

        private void formVendasFecharCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void formVendasFecharCaixa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (buttonFechar.Focused == true)
                {
                    buttonFechar_Click(sender, e);
                    e.Handled = true;
                }
                else
                {
                    ProcessTabKey(true);
                    e.Handled = true;
                }
            }
        }
    }
}
