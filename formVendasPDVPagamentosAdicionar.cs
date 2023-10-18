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
    public partial class formVendasPDVPagamentosAdicionar : Form
    {
        #region Inicialização

        decimal restante;

        decimal subtotal;
        decimal pagamento;
        decimal troco;
        decimal pago;

        string forma;
        string bandeira;
        int parcelas;
        public bool vale;
        decimal juros;

        public formVendasPDVPagamentos pai = new formVendasPDVPagamentos();
        Pagamento Pagamento = new Pagamento();
        ComandosSQL comandos = new ComandosSQL();
        public formVendasPDVPagamentosAdicionar()
        {
            InitializeComponent();
        }
        public formVendasPDVPagamentosAdicionar(decimal Restante, formVendasPDVPagamentos Pai)
        {
            try
            {
                InitializeComponent();
                new Sombra().ApplyShadows(this);
                restante = Restante;
                pai = Pai;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void formVendasPDVPagamentosAdicionar_Load(object sender, EventArgs e)
        {
            try
            {
                forma = "DINHEIRO";
                comboBoxForma.Text = forma;
                textBoxRestante.Text = restante.ToString("C");
                textBoxPagamento.Text = textBoxRestante.Text;

                textBoxPago.Focus();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        #endregion

        #region Métodos
        private void CalcularTroco()
        {
            troco = pago - pagamento;

            if (forma == "DINHEIRO")
            {
                if (troco == 0)
                {
                    labelTroco.Text = "Troco:";
                    textBoxTroco.Text = "R$0,00";
                    textBoxTroco.ForeColor = Color.LimeGreen;
                }
                else if (troco < 0)
                {
                    labelTroco.Text = "Falta pagar:";
                    textBoxTroco.Text = (-troco).ToString("C");
                    textBoxTroco.ForeColor = Color.Red;
                }
                else if (troco > 0)
                {
                    labelTroco.Text = "Troco:";
                    textBoxTroco.Text = troco.ToString("C");
                    textBoxTroco.ForeColor = Color.LimeGreen;
                }
            }
            else
            {
                textBoxTroco.Text = "R$0,00";
                textBoxTroco.ForeColor = Color.Gray;
            }


        }

        #endregion

        private void buttonFinalizar_Click(object sender, EventArgs e)
        {
            bool continuar = true;

            if (pagamento == 0)
            {
                MessageBox.Show("Informe o valor do pagamento para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxPago.Focus();
            }
            else if (troco < 0)
            {
                string valor = (-troco).ToString("C");
                MessageBox.Show("Não é possível completar a transação porque\r\no valor pago é inferior ao valor do pagamento.\r\nEstá faltando " + valor + ".", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxPago.Focus();
            }
            else if (pagamento > restante + juros)
            {
                MessageBox.Show("O pagamento não pode ser superior ao valor\r\nnecessário para concluir a venda!\r\nNecessário para concluir a venda: " + (restante + juros).ToString("C"), "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxPago.Focus();
            }
            else
            {
                Pagamento.Forma = forma;
                Pagamento.Valor = pagamento;
                Pagamento.Troco = troco;

                if (forma == "DÉBITO")
                {
                    if (comboBoxBandeira.Text == string.Empty)
                    {
                        continuar = false;
                        MessageBox.Show("Informe a bandeira do cartão para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else { Pagamento.Bandeira = bandeira; }
                }

                else if (forma == "CRÉDITO")
                {
                    if (comboBoxBandeira.Text == string.Empty)
                    {
                        continuar = false;
                        MessageBox.Show("Informe a bandeira do cartão para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (comboBoxParcelas.Text == string.Empty)
                    {
                        continuar = false;
                        MessageBox.Show("Informe a quantidade de parcelas para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        Pagamento.Bandeira = bandeira;
                        Pagamento.Parcelas = parcelas;
                        Pagamento.Juros = juros;
                    }
                }
                else if (forma == "PICPAY")
                {
                    if (comboBoxParcelas.Text == string.Empty)
                    {
                        continuar = false;
                        MessageBox.Show("Informe a quantidade de parcelas para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        Pagamento.Forma = "PICPAY";
                        Pagamento.Bandeira = "PICPAY";
                        Pagamento.Parcelas = parcelas;
                        Pagamento.Juros = juros;
                    }
                }

                if (continuar)
                {
                    pai.pdv.pai.Pagamentos.Add(Pagamento);
                    pai.Atualizar = true;
                    Dispose();
                }
            }
        }

        private void comboBoxForma_SelectedIndexChanged(object sender, EventArgs e)
        {
            forma = comboBoxForma.Text;
            textBoxPagamento.ReadOnly = false;
            comboBoxParcelas.SelectedIndex = -1;
            comboBoxParcelas.Enabled = false;

            if (forma == "DINHEIRO")
            {
                labelBandeira.Visible = false;
                labelParcelas.Visible = false;
                comboBoxBandeira.Visible = false;
                comboBoxParcelas.Visible = false;
                textBoxPago.ReadOnly = false;
                Height = 390;

                textBoxPago.Text = "R$0,00";
            }
            else if (forma == "DÉBITO")
            {
                labelBandeira.Visible = true;
                labelParcelas.Visible = false;
                comboBoxBandeira.Visible = true;
                comboBoxParcelas.Visible = false;
                textBoxPago.ReadOnly = true;
                textBoxPago.Text = textBoxPagamento.Text;

                List<string> bandeiras = comandos.BandeirasDosCartoes("Débito");
                comboBoxBandeira.Items.Clear();
                foreach (string bandeira in bandeiras) { comboBoxBandeira.Items.Add(bandeira); }
                Height = 430;
            }
            else if (forma == "CRÉDITO")
            {
                labelBandeira.Visible = true;
                labelParcelas.Visible = true;
                comboBoxBandeira.Visible = true;
                comboBoxParcelas.Visible = true;
                textBoxPago.ReadOnly = true;
                textBoxPago.Text = textBoxPagamento.Text;

                List<string> bandeiras = comandos.BandeirasDosCartoes("Crédito");
                comboBoxBandeira.Items.Clear();
                foreach (string bandeira in bandeiras) { comboBoxBandeira.Items.Add(bandeira); }
                Height = 466;
            }
            else if (forma == "PICPAY")
            {
                bandeira = "PICPAY";
                labelBandeira.Visible = false;
                labelParcelas.Visible = true;
                comboBoxBandeira.Visible = false;
                comboBoxParcelas.Visible = true;
                comboBoxParcelas.Enabled = true;
                textBoxPago.ReadOnly = true;
                textBoxPago.Text = textBoxPagamento.Text;

                List<string> parcelas = comandos.ParcelasDosCartoes("PICPAY", "Crédito");
                comboBoxParcelas.Items.Clear();
                foreach (string parcela in parcelas) { comboBoxParcelas.Items.Add(parcela); }
                Height = 430;
            }
            else if (forma == "PIX")
            {
                labelBandeira.Visible = false;
                labelParcelas.Visible = false;
                comboBoxBandeira.Visible = false;
                comboBoxParcelas.Visible = false;
                textBoxPago.ReadOnly = true;
                textBoxPago.Text = textBoxPagamento.Text;

                Height = 390;
            }
            else if (forma == "VALE-TROCA")
            {
                labelBandeira.Visible = false;
                labelParcelas.Visible = false;
                comboBoxBandeira.Visible = false;
                comboBoxParcelas.Visible = false;
                textBoxPago.ReadOnly = true;

                Height = 390;

                formVendasPDVPagamentosAdicionarVale valetroca = new formVendasPDVPagamentosAdicionarVale(restante, this);
                valetroca.ShowDialog();
                if (vale)
                {
                    pai.Atualizar = true;
                }
            }
        }

        private void comboBoxBandeira_SelectedIndexChanged(object sender, EventArgs e)
        {
            bandeira = comboBoxBandeira.Text;
            List<string> parcelas = new List<string>();
            if (forma == "CRÉDITO")
            {
                parcelas = comandos.ParcelasDosCartoes(bandeira, "Crédito");
            }

            comboBoxParcelas.Items.Clear();
            foreach (string parcela in parcelas) { comboBoxParcelas.Items.Add(parcela); }
            comboBoxParcelas.Enabled = true;
        }

        private void comboBoxParcelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = 70;

            int parcelas_sem_juros = Convert.ToInt32(comandos.ObterValorDoParametro("Limite de Parcelas sem Juros"));

            try { parcelas = Convert.ToInt32(comboBoxParcelas.Text); } catch { }

            if (forma == "CRÉDITO" || forma == "PICPAY")
            {
                if (parcelas > parcelas_sem_juros)
                {
                    comboBoxForma.Enabled = false;
                    comboBoxBandeira.Enabled = false;
                    comboBoxParcelas.Enabled = false;
                    textBoxPagamento.Text = "R$0,00";
                    textBoxPago.Text = "R$0,00";
                    labelJuros.Visible = true;
                    labelPagar.Visible = true;
                    textBoxJuros.Visible = true;
                    textBoxPagar.Visible = true;
                    textBoxPagamento.ReadOnly = true;
                    textBoxPagar.Text = textBoxRestante.Text;
                }

                if (parcelas > parcelas_sem_juros)
                {
                    if (forma == "PICPAY")
                    {
                        textBoxPagar.Top = textBoxPagar.Top - 35;
                        labelPagar.Top = labelPagar.Top - 35;
                        textBoxJuros.Top = textBoxJuros.Top - 35;
                        labelJuros.Top = labelJuros.Top - 35;
                    }

                    Height = Height + n;
                    labelParcelas.Top = labelParcelas.Top - n;
                    comboBoxParcelas.Top = comboBoxParcelas.Top - n;
                    label3.Top = label3.Top - n;
                    textBoxRestante.Top = textBoxRestante.Top - n;
                    linha.Top = linha.Top - n;

                    //if (forma == "PICPAY") { n = 35; }
                    //else { n = 70; }
                }
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
        #region Formatação de Texto
        private void textBoxPagamento_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPagamento.Text == string.Empty)
            {
                pagamento = 0;
            }
            else
            {
                try { pagamento = Convert.ToDecimal(textBoxPagamento.Text); }
                catch
                {
                    string[] partir = textBoxPagamento.Text.Split('$');
                    pagamento = Convert.ToDecimal(partir[1]); 
                }
            }

            if (forma == "DINHEIRO") 
            { 
                if (pagamento > 0) { textBoxPago.ReadOnly = false; }
                else 
                { 
                    textBoxPago.ReadOnly = true;
                    textBoxPago.Text = 0.ToString("C");
                }
                CalcularTroco();
            }
            else 
            {

                textBoxPago.Text = pagamento.ToString("C"); 
            }                
        }
        private void textBoxPago_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPago.Text == string.Empty)
            {
                pago = 0;
            }
            else
            {
                try { pago = Convert.ToDecimal(textBoxPago.Text); }
                catch 
                {
                    string[] partir2 = textBoxPago.Text.Split('$');
                    pago = Convert.ToDecimal(partir2[1]); 
                }
            }

            CalcularTroco();
        }
        private void textBoxPagamento_Enter(object sender, EventArgs e)
        {
            if (!textBoxPagamento.ReadOnly)
            {
                if (textBoxPagamento.Text == "R$0,00")
                {
                    textBoxPagamento.Text = string.Empty;
                }
                else
                {
                    string[] partir = textBoxPagamento.Text.Split('$');
                    textBoxPagamento.Text = partir[1];
                }

                //if (comboBoxForma.Text == "DINHEIRO")
                //{
                //    buttonFinalizar.TabStop = false;
                //}
            }
        }
        private void textBoxPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
            (e.KeyChar != ',' && e.KeyChar != '.' &&
            e.KeyChar != (char)13 && e.KeyChar != (char)8))
            {
                e.KeyChar = (char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!textBoxPagamento.Text.Contains(','))
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
        private void textBoxPagamento_Leave(object sender, EventArgs e)
        {
            if (!textBoxPagamento.ReadOnly)
            {
                if (textBoxPagamento.Text == string.Empty)
                {
                    textBoxPagamento.Text = 0.ToString("C");
                }
                else
                {
                    textBoxPagamento.Text = Convert.ToDecimal(textBoxPagamento.Text).ToString("C");
                }
                CalcularTroco();

                //if (comboBoxForma.Text == "DINHEIRO") { textBoxPago.Focus(); }
            }
        }
        private void textBoxPago_Enter(object sender, EventArgs e)
        {
            if (!textBoxPago.ReadOnly)
            {
                if (textBoxPago.Text == "R$0,00")
                {
                    textBoxPago.Text = string.Empty;
                }
                else if (textBoxPago.Text == string.Empty)
                {

                }
                else
                {
                    string[] partir = textBoxPago.Text.Split('$');
                    textBoxPago.Text = partir[1];
                }

                //buttonFinalizar.TabStop = true;
            }
        }
        private void textBoxPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
            (e.KeyChar != ',' && e.KeyChar != '.' &&
            e.KeyChar != (char)13 && e.KeyChar != (char)8))
            {
                e.KeyChar = (char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!textBoxPago.Text.Contains(','))
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
        private void textBoxPago_Leave(object sender, EventArgs e)
        {
            if (!textBoxPago.ReadOnly)
            {
                if (textBoxPago.Text == string.Empty)
                {
                    textBoxPago.Text = 0.ToString("C");
                }
                else
                {
                    textBoxPago.Text = Convert.ToDecimal(textBoxPago.Text).ToString("C");
                }
                CalcularTroco();
            }
        }
        private void textBoxPagar_Enter(object sender, EventArgs e)
        {
            if (!textBoxPagar.ReadOnly)
            {
                if (textBoxPagar.Text == "R$0,00")
                {
                    textBoxPagar.Text = string.Empty;
                }
                else
                {
                    string[] partir = textBoxPagar.Text.Split('$');
                    textBoxPagar.Text = partir[1];
                }
            }
        }
        private void textBoxPagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
            (e.KeyChar != ',' && e.KeyChar != '.' &&
            e.KeyChar != (char)13 && e.KeyChar != (char)8))
            {
                e.KeyChar = (char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!textBoxPagar.Text.Contains(','))
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
        private void textBoxPagar_Leave(object sender, EventArgs e)
        {
            if (!textBoxPagar.ReadOnly)
            {
                if (textBoxPagar.Text == string.Empty)
                {
                    textBoxPagar.Text = 0.ToString("C");
                }
                else
                {
                    textBoxPagar.Text = Convert.ToDecimal(textBoxPagar.Text).ToString("C");
                }
            }
        }
        private void textBoxPagar_TextChanged(object sender, EventArgs e)
        {
            if (forma == "DÉBITO" || forma == "CRÉDITO" || forma == "PICPAY")
            {
                if (textBoxPagar.Text == string.Empty)
                {
                    subtotal = 0;
                }
                else
                {
                    try { subtotal = Convert.ToDecimal(textBoxPagar.Text); }
                    catch
                    {
                        subtotal = comandos.ConverterDinheiroEmDecimal(textBoxPagar.Text);
                    }
                }

                pagamento = subtotal + juros;
                textBoxPagamento.Text = pagamento.ToString("C");
            }
        }
        #endregion

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void formVendasPDVPagamentosAdicionar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void formVendasPDVPagamentosAdicionar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (buttonFinalizar.Focused == true)
                {
                    buttonFinalizar_Click(sender, e);
                    e.Handled = true;
                }
                else
                {
                    ProcessTabKey(true);
                    e.Handled = true;
                }
            }
        }

        private void formVendasPDVPagamentosAdicionar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                formConsultaRapida consultaRapida = new formConsultaRapida();
                consultaRapida.ShowDialog();
            }
        }

        private void textBoxJuros_Enter(object sender, EventArgs e)
        {
            if (textBoxJuros.Text == "R$0,00")
            {
                textBoxJuros.Text = string.Empty;
            }
            else
            {
                string[] partir = textBoxJuros.Text.Split('$');
                textBoxJuros.Text = partir[1];
            }
        }

        private void textBoxJuros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
            (e.KeyChar != ',' && e.KeyChar != '.' &&
            e.KeyChar != (char)13 && e.KeyChar != (char)8))
            {
                e.KeyChar = (char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!textBoxJuros.Text.Contains(','))
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

        private void textBoxJuros_Leave(object sender, EventArgs e)
        {
            try { juros = Convert.ToDecimal(textBoxJuros.Text); }
            catch { juros = 0; }

            textBoxJuros.Text = juros.ToString("C");
        }

        private void textBoxJuros_TextChanged(object sender, EventArgs e)
        {

            try { juros = Convert.ToDecimal(textBoxJuros.Text); }
            catch
            {
                juros = comandos.ConverterDinheiroEmDecimal(textBoxJuros.Text);
            }


            pagamento = subtotal + juros;
            textBoxPagamento.Text = pagamento.ToString("C");
        }
    }
}
