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
    public partial class formVendasCaixaContadorDeMoedas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<ContadorDeMoeda> quantidades = new List<ContadorDeMoeda>();
        bool caixa;
        decimal abertura;
        public formVendasCaixaContadorDeMoedas()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }
        private void formVendasContadorDeMoedas_Load(object sender, EventArgs e)
        {
            caixa = comandos.VerificarCaixaAberto(); 
            if (caixa) { labelSangria.Visible = true; labelValor.Visible = true; abertura = comandos.ValorDeAbertura(); }

            quantidades = comandos.TrazerQuantidadePeloValor();
            foreach(ContadorDeMoeda valor in quantidades)
            {
                if (valor.Valor == "0,05") { textBox005.Text = valor.Quantidade.ToString(); }
                else if (valor.Valor == "0,10") { textBox010.Text = valor.Quantidade.ToString(); }
                else if (valor.Valor == "0,25") { textBox025.Text = valor.Quantidade.ToString(); }
                else if (valor.Valor == "0,50") { textBox050.Text = valor.Quantidade.ToString(); }
                else if (valor.Valor == "1,00") { textBox100.Text = valor.Quantidade.ToString(); }
                else if (valor.Valor == "2,00") { textBox200.Text = valor.Quantidade.ToString(); }
                else if (valor.Valor == "5,00") { textBox500.Text = valor.Quantidade.ToString(); }
                else if (valor.Valor == "10,00") { textBox1000.Text = valor.Quantidade.ToString(); }
                else if (valor.Valor == "20,00") { textBox2000.Text = valor.Quantidade.ToString(); }
                else if (valor.Valor == "50,00") { textBox5000.Text = valor.Quantidade.ToString(); }
                else if (valor.Valor == "100,00") { textBox10000.Text = valor.Quantidade.ToString(); }
                else if (valor.Valor == "200,00") { textBox20000.Text = valor.Quantidade.ToString(); }
            }
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void PreencherTotal()
        {
            string[] partir = textBox13.Text.Split('$');
            string[] partir1 = textBox14.Text.Split('$');
            string[] partir2 = textBox15.Text.Split('$');
            string[] partir3 = textBox16.Text.Split('$');
            string[] partir4 = textBox17.Text.Split('$');
            string[] partir5 = textBox22.Text.Split('$');
            string[] partir6 = textBox21.Text.Split('$');
            string[] partir7 = textBox20.Text.Split('$');
            string[] partir8 = textBox19.Text.Split('$');
            string[] partir9 = textBox18.Text.Split('$');
            string[] partir10 = textBox24.Text.Split('$');
            string[] partir11 = textBox23.Text.Split('$');

            decimal cent5 = Convert.ToDecimal(partir[1]);
            decimal cent10 = Convert.ToDecimal(partir1[1]);
            decimal cent25 = Convert.ToDecimal(partir2[1]);
            decimal cent50 = Convert.ToDecimal(partir3[1]);
            decimal real1 = Convert.ToDecimal(partir4[1]);
            decimal real2 = Convert.ToDecimal(partir5[1]);
            decimal real5 = Convert.ToDecimal(partir6[1]);
            decimal real10 = Convert.ToDecimal(partir7[1]);
            decimal real20 = Convert.ToDecimal(partir8[1]);
            decimal real50 = Convert.ToDecimal(partir9[1]);
            decimal real100 = Convert.ToDecimal(partir10[1]);
            decimal real200 = Convert.ToDecimal(partir11[1]);

            decimal total = cent5 + cent10 + cent25 + cent50 + real1 + real2 + real5 + real10 + real20 + real50 + real100 + real200;
            textBoxValorTotal.Text = total.ToString("C");

            decimal sangria;

            if (caixa) 
            {                 
                sangria = total - abertura;
                labelValor.Text = sangria.ToString("C");

                if (sangria > 0) { labelSangria.Text = "Sangria:"; labelValor.ForeColor = Color.Green; }
                else if (sangria < 0) { labelSangria.Text = "Suprimento:"; labelValor.ForeColor = Color.Red; }
                else { labelSangria.Text = "Bateu!"; labelValor.Visible = false; }
            }
        }
        #region Formatação de Texto
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
            
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox005.Text == string.Empty)
            {
                textBox13.Text = 0.ToString("C");
            }
            else
            {
                int quantidade = Convert.ToInt32(textBox005.Text);
                double total = 0.05 * quantidade;
                textBox13.Text = total.ToString("C");
            }
            PreencherTotal();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox010.Text == string.Empty)
            {
                textBox14.Text = 0.ToString("C");
            }
            else
            {
                int quantidade = Convert.ToInt32(textBox010.Text);
                double total = 0.10 * quantidade;
                textBox14.Text = total.ToString("C");
            }
            PreencherTotal();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox025.Text == string.Empty)
            {
                textBox15.Text = 0.ToString("C");
            }
            else
            {
                int quantidade = Convert.ToInt32(textBox025.Text);
                double total = 0.25 * quantidade;
                textBox15.Text = total.ToString("C");
            }
            PreencherTotal();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox050.Text == string.Empty)
            {
                textBox16.Text = 0.ToString("C");
            }
            else
            {
                int quantidade = Convert.ToInt32(textBox050.Text);
                double total = 0.50 * quantidade;
                textBox16.Text = total.ToString("C");
            }
            PreencherTotal();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox100.Text == string.Empty)
            {
                textBox17.Text = 0.ToString("C");
            }
            else
            {
                int quantidade = Convert.ToInt32(textBox100.Text);
                double total = 1.00 * quantidade;
                textBox17.Text = total.ToString("C");
            }
            PreencherTotal();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox200.Text == string.Empty)
            {
                textBox22.Text = 0.ToString("C");
            }
            else
            {
                int quantidade = Convert.ToInt32(textBox200.Text);
                double total = 2.00 * quantidade;
                textBox22.Text = total.ToString("C");
            }
            PreencherTotal();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox500.Text == string.Empty)
            {
                textBox21.Text = 0.ToString("C");
            }
            else
            {
                int quantidade = Convert.ToInt32(textBox500.Text);
                double total = 5.00 * quantidade;
                textBox21.Text = total.ToString("C");
            }
            PreencherTotal();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox1000.Text == string.Empty)
            {
                textBox20.Text = 0.ToString("C");
            }
            else
            {
                int quantidade = Convert.ToInt32(textBox1000.Text);
                double total = 10.00 * quantidade;
                textBox20.Text = total.ToString("C");
            }
            PreencherTotal();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox2000.Text == string.Empty)
            {
                textBox19.Text = 0.ToString("C");
            }
            else
            {
                int quantidade = Convert.ToInt32(textBox2000.Text);
                double total = 20 * quantidade;
                textBox19.Text = total.ToString("C");
            }
            PreencherTotal();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (textBox5000.Text == string.Empty)
            {
                textBox18.Text = 0.ToString("C");
            }
            else
            {
                int quantidade = Convert.ToInt32(textBox5000.Text);
                double total = 50 * quantidade;
                textBox18.Text = total.ToString("C");
            }
            PreencherTotal();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox10000.Text == string.Empty)
            {
                textBox24.Text = 0.ToString("C");
            }
            else
            {
                int quantidade = Convert.ToInt32(textBox10000.Text);
                double total = 100 * quantidade;
                textBox24.Text = total.ToString("C");
            }
            PreencherTotal();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox20000.Text == string.Empty)
            {
                textBox23.Text = 0.ToString("C");
            }
            else
            {
                int quantidade = Convert.ToInt32(textBox20000.Text);
                double total = 200 * quantidade;
                textBox23.Text = total.ToString("C");
            }
            PreencherTotal();
        }



        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox005.Text == "0")
            {
                textBox005.Text = string.Empty;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox010.Text == "0")
            {
                textBox010.Text = string.Empty;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox025.Text == "0")
            {
                textBox025.Text = string.Empty;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox050.Text == "0")
            {
                textBox050.Text = string.Empty;
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox100.Text == "0")
            {
                textBox100.Text = string.Empty;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox200.Text == "0")
            {
                textBox200.Text = string.Empty;
            }
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            if (textBox500.Text == "0")
            {
                textBox500.Text = string.Empty;
            }
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            if (textBox1000.Text == "0")
            {
                textBox1000.Text = string.Empty;
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox2000.Text == "0")
            {
                textBox2000.Text = string.Empty;
            }
        }

        private void textBox12_Enter(object sender, EventArgs e)
        {
            if (textBox5000.Text == "0")
            {
                textBox5000.Text = string.Empty;
            }
        }

        private void textBox11_Enter(object sender, EventArgs e)
        {
            if (textBox10000.Text == "0")
            {
                textBox10000.Text = string.Empty;
            }
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            if (textBox20000.Text == "0")
            {
                textBox20000.Text = string.Empty;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox005.Text == string.Empty)
            {
                textBox005.Text = "0";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox010.Text == string.Empty)
            {
                textBox010.Text = "0";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox025.Text == string.Empty)
            {
                textBox025.Text = "0";
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox050.Text == string.Empty)
            {
                textBox050.Text = "0";
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox100.Text == string.Empty)
            {
                textBox100.Text = "0";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox200.Text == string.Empty)
            {
                textBox200.Text = "0";
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (textBox500.Text == string.Empty)
            {
                textBox500.Text = "0";
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox1000.Text == string.Empty)
            {
                textBox1000.Text = "0";
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox2000.Text == string.Empty)
            {
                textBox2000.Text = "0";
            }
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            if (textBox5000.Text == string.Empty)
            {
                textBox5000.Text = "0";
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (textBox10000.Text == string.Empty)
            {
                textBox10000.Text = "0";
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (textBox20000.Text == string.Empty)
            {
                textBox20000.Text = "0";
            }
        }
        #endregion
        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            textBox005.Text = "0";
            textBox010.Text = "0";
            textBox025.Text = "0";
            textBox050.Text = "0";
            textBox100.Text = "0";
            textBox200.Text = "0";
            textBox500.Text = "0";
            textBox1000.Text = "0";
            textBox2000.Text = "0";
            textBox5000.Text = "0";
            textBox10000.Text = "0";
            textBox20000.Text = "0";
        }

        private void buttonFinalizar_Click(object sender, EventArgs e)
        {
            SalvarQuantidades();
        }

        private void SalvarQuantidades()
        {
            comandos.EditarQuantidadeDeMoedas("0,05", Convert.ToInt32(textBox005.Text));
            comandos.EditarQuantidadeDeMoedas("0,10", Convert.ToInt32(textBox010.Text));
            comandos.EditarQuantidadeDeMoedas("0,25", Convert.ToInt32(textBox025.Text));
            comandos.EditarQuantidadeDeMoedas("0,50", Convert.ToInt32(textBox050.Text));
            comandos.EditarQuantidadeDeMoedas("1,00", Convert.ToInt32(textBox100.Text));
            comandos.EditarQuantidadeDeMoedas("2,00", Convert.ToInt32(textBox200.Text));
            comandos.EditarQuantidadeDeMoedas("5,00", Convert.ToInt32(textBox500.Text));
            comandos.EditarQuantidadeDeMoedas("10,00", Convert.ToInt32(textBox1000.Text));
            comandos.EditarQuantidadeDeMoedas("20,00", Convert.ToInt32(textBox2000.Text));
            comandos.EditarQuantidadeDeMoedas("50,00", Convert.ToInt32(textBox5000.Text));
            comandos.EditarQuantidadeDeMoedas("100,00", Convert.ToInt32(textBox10000.Text));
            comandos.EditarQuantidadeDeMoedas("200,00", Convert.ToInt32(textBox20000.Text));
            Dispose();
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

        private void formVendasContadorDeMoedas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);
            }
        }
    }
}
