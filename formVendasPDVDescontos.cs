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
    public partial class formVendasPDVDescontos : Form
    {
        formVendasPDV pdv = new formVendasPDV();
        ComandosSQL comandos = new ComandosSQL();

        decimal subtotal;
        decimal percentual;
        decimal total;

        public formVendasPDVDescontos()
        {
            InitializeComponent();
        }
        public formVendasPDVDescontos(formVendasPDV Pai)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            pdv = Pai;
        }

        private void formVendasPDVDescontos_Load(object sender, EventArgs e)
        {
            total = pdv.pai.Produtos.Sum(x => x.Total);
            subtotal = pdv.pai.Produtos.Sum(x => x.Subtotal);

            CalcularPercentualAPartirDoDesconto();

            textBoxSubtotal.Text = subtotal.ToString("C");
            textBoxFinal.Text = total.ToString("C");

            textBoxDesconto.SelectionStart = textBoxDesconto.Text.Length;
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal desconto = subtotal - total;
                int produtos = pdv.pai.Produtos.Count();

                decimal desconto_por_produto = desconto / produtos;

                foreach (ProdutoVenda produto in pdv.pai.Produtos)
                {
                    produto.Desconto = desconto_por_produto;
                    produto.Total = produto.Subtotal - produto.Desconto;
                }

                pdv.AtualizarDataGrid();
                Dispose();
            }
            catch { }
        }
        private void textBoxDesconto_Enter(object sender, EventArgs e)
        {
            if (percentual == 0)
            {
                textBoxDesconto.Text = string.Empty;
            }
            else
            {
                textBoxDesconto.Text = percentual.ToString("F");
            }
        }

        private void textBoxDesconto_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!textBoxDesconto.Text.Contains(','))
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

        private void textBoxDesconto_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxDesconto_Leave(object sender, EventArgs e)
        {
            try
            {
                percentual = Convert.ToDecimal(textBoxDesconto.Text);
            }
            catch
            {
                percentual = 0;
            }

            if (percentual > 100)
            {
                MessageBox.Show("Não é possível conceder um desconto maior do que o valor da venda!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                percentual = 0;
            }

            textBoxDesconto.Text = comandos.ConverterDecimalEmPercentual(percentual);
            CalcularDescontoAPartirDoPercentual();
        }

        private void textBoxFinal_Leave(object sender, EventArgs e)
        {
            try
            {
                total = Convert.ToDecimal(textBoxFinal.Text);
            }
            catch
            {
                total = 0;
            }

            if (total > subtotal)
            {
                MessageBox.Show("Não é possível aplicar um valor final maior do que o valor da venda!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                total = subtotal;
            }

            textBoxFinal.Text = comandos.ConverterDecimalEmDinheiro(total);
            CalcularPercentualAPartirDoDesconto();
        }

        private void textBoxFinal_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!textBoxFinal.Text.Contains(','))
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

        private void textBoxFinal_Enter(object sender, EventArgs e)
        {
            if (percentual == 0)
            {
                textBoxFinal.Text = string.Empty;
            }
            else
            {
                textBoxFinal.Text = total.ToString("F");
            }
        }

        private void textBoxFinal_TextChanged(object sender, EventArgs e)
        {

        }

        private void CalcularDescontoAPartirDoPercentual()
        {
            total = subtotal - (percentual * (subtotal / 100));

            textBoxFinal.Text = total.ToString("C");
        }

        private void CalcularPercentualAPartirDoDesconto()
        {
            decimal desconto = subtotal - total;
            percentual = desconto / (subtotal / 100);

            textBoxDesconto.Text = comandos.ConverterDecimalEmPercentual(percentual);
        }
    }
}
