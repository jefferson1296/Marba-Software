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
    public partial class formProdutosEntradaReajustar : Form
    {
        formProdutosEntradaDarEntrada entrada = new formProdutosEntradaDarEntrada();
        formProdutosEntradaAnaliseAvancada analise = new formProdutosEntradaAnaliseAvancada();
        int id_produto;

        decimal base_novo;
        decimal aliquota_ipi_novo;
        decimal aliquota_icms_novo;

        bool analise_avancada = false;

        public formProdutosEntradaReajustar()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }
        public formProdutosEntradaReajustar(formProdutosEntradaDarEntrada Entrada, int ID_Produto)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            entrada = Entrada;
            id_produto = ID_Produto;
        }
        public formProdutosEntradaReajustar(formProdutosEntradaAnaliseAvancada Analise, int ID_Produto)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            analise_avancada = true;
            analise = Analise;
            id_produto = ID_Produto;
        }
        private void formProdutosEntradaReajustar_Load(object sender, EventArgs e)
        {
            if (analise_avancada)
            {
                string produto = analise.Produtos_Entrada.Where(x => x.ID_Produto == id_produto).Select(x => x.Nome_Produto).FirstOrDefault();
                produtoTextBox.Text = produto;

                base_novo = analise.Produtos_Entrada.Where(x => x.ID_Produto == id_produto).Select(x => x.Preco_Base).FirstOrDefault();
                aliquota_icms_novo = analise.Produtos_Entrada.Where(x => x.ID_Produto == id_produto).Select(x => x.Aliquota_ICMS).FirstOrDefault();
                aliquota_ipi_novo = analise.Produtos_Entrada.Where(x => x.ID_Produto == id_produto).Select(x => x.Aliquota_IPI).FirstOrDefault();
            }
            else
            {
                string produto = entrada.Produtos_Entrada.Where(x => x.ID_Produto == id_produto).Select(x => x.Nome_Produto).FirstOrDefault();
                produtoTextBox.Text = produto;

                base_novo = entrada.Produtos_Entrada.Where(x => x.ID_Produto == id_produto).Select(x => x.Preco_Base).FirstOrDefault();
                aliquota_icms_novo = entrada.Produtos_Entrada.Where(x => x.ID_Produto == id_produto).Select(x => x.Aliquota_ICMS).FirstOrDefault();
                aliquota_ipi_novo = entrada.Produtos_Entrada.Where(x => x.ID_Produto == id_produto).Select(x => x.Aliquota_IPI).FirstOrDefault();
            }

            CalcularInformacoesFinanceiras();
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void CalcularInformacoesFinanceiras()
        {
            decimal base_antigo;
            decimal aliquota_ipi_antigo;
            decimal aliquota_icms_antigo;
            decimal ipi_antigo;
            decimal ipi_novo;
            decimal icms_antigo;
            decimal icms_novo;
            decimal custo_antigo;
            decimal custo_novo;


            if (analise_avancada)
            {
                base_antigo = analise.Produtos_Fornecedor.Where(x => x.ID_Produto == id_produto).Select(x => x.Preco_Base).FirstOrDefault();
                aliquota_ipi_antigo = analise.Produtos_Fornecedor.Where(x => x.ID_Produto == id_produto).Select(x => x.Aliquota_IPI).FirstOrDefault();
                aliquota_icms_antigo = analise.Produtos_Fornecedor.Where(x => x.ID_Produto == id_produto).Select(x => x.Aliquota_ICMS).FirstOrDefault();
            }
            else
            {
                base_antigo = entrada.Produtos_Fornecedor.Where(x => x.ID_Produto == id_produto).Select(x => x.Preco_Base).FirstOrDefault();
                aliquota_ipi_antigo = entrada.Produtos_Fornecedor.Where(x => x.ID_Produto == id_produto).Select(x => x.Aliquota_IPI).FirstOrDefault();
                aliquota_icms_antigo = entrada.Produtos_Fornecedor.Where(x => x.ID_Produto == id_produto).Select(x => x.Aliquota_ICMS).FirstOrDefault();
            }

            ipi_antigo = base_antigo / 100 * aliquota_ipi_antigo;
            ipi_novo = base_novo / 100 * aliquota_ipi_novo;

            icms_antigo = base_antigo / 100 * aliquota_icms_antigo;
            icms_novo = base_novo / 100 * aliquota_icms_novo;

            custo_antigo = base_antigo + ipi_antigo + icms_antigo;
            custo_novo = base_novo + ipi_novo + icms_novo;

            baseTextBox.Text = base_novo.ToString("C");
            AliquotaICMSTextBox.Text = aliquota_icms_novo.ToString("F") + "%";
            AliquotaIPITextBox.Text = aliquota_ipi_novo.ToString("F") + "%";
            ipiTextBox.Text = ipi_novo.ToString("C");
            icmsTextBox.Text = icms_novo.ToString("C");
            custoAntigoTextBox.Text = custo_antigo.ToString("C");
            custoNovoTextBox.Text = custo_novo.ToString("C");
        }
        private void baseTextBox_Enter(object sender, EventArgs e)
        {
            if (baseTextBox.Text == "R$0,00")
            {
                baseTextBox.Text = string.Empty;
            }
            else
            {
                string[] partir = baseTextBox.Text.Split('$');
                baseTextBox.Text = partir[1];
            }
        }
        private void baseTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!baseTextBox.Text.Contains(','))
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
        private void baseTextBox_Leave(object sender, EventArgs e)
        {
            if (baseTextBox.Text == string.Empty)
            {
                base_novo = 0;

            }
            else
            {
                base_novo = Convert.ToDecimal(baseTextBox.Text);
            }

            baseTextBox.Text = base_novo.ToString("C");

            CalcularInformacoesFinanceiras();
        }
        private void AliquotaIPITextBox_Enter(object sender, EventArgs e)
        {
            if (AliquotaIPITextBox.Text == "0,00%")
            {
                AliquotaIPITextBox.Text = string.Empty;
            }
            else
            {
                string[] partir = AliquotaIPITextBox.Text.Split('%');
                AliquotaIPITextBox.Text = partir[0];
            }
        }
        private void AliquotaIPITextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!AliquotaIPITextBox.Text.Contains(','))
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
        private void AliquotaIPITextBox_Leave(object sender, EventArgs e)
        {
            if (AliquotaIPITextBox.Text == string.Empty)
            {
                aliquota_ipi_novo = 0;
                AliquotaIPITextBox.ForeColor = Color.Gray;
            }
            else
            {
                aliquota_ipi_novo = Convert.ToDecimal(AliquotaIPITextBox.Text);  
                AliquotaIPITextBox.ForeColor = Color.Black;
            }

            AliquotaIPITextBox.Text = aliquota_ipi_novo.ToString("F") + "%";

            CalcularInformacoesFinanceiras();
        }
        private void AliquotaICMSTextBox_Enter(object sender, EventArgs e)
        {
            if (AliquotaICMSTextBox.Text == "0,00%")
            {
                AliquotaICMSTextBox.Text = string.Empty;
            }
            else
            {
                string[] partir = AliquotaICMSTextBox.Text.Split('%');
                AliquotaICMSTextBox.Text = partir[0];
            }
        }
        private void AliquotaICMSTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!AliquotaICMSTextBox.Text.Contains(','))
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
        private void AliquotaICMSTextBox_Leave(object sender, EventArgs e)
        {
            if (AliquotaICMSTextBox.Text == string.Empty)
            {
                aliquota_icms_novo = 0;
                AliquotaICMSTextBox.ForeColor = Color.Gray;
            }
            else
            {
                aliquota_icms_novo = Convert.ToDecimal(AliquotaICMSTextBox.Text);
                AliquotaICMSTextBox.ForeColor = Color.Black;
            }

            AliquotaICMSTextBox.Text = aliquota_icms_novo.ToString("F") + "%";

            CalcularInformacoesFinanceiras();
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


        private void buttonReajustar_Click(object sender, EventArgs e)
        {
            if (analise_avancada)
            {
                foreach (ProdutoEntrada Produto in analise.Produtos_Entrada)
                {
                    if (Produto.ID_Produto == id_produto)
                    {
                        Produto.Preco_Base = base_novo;
                        Produto.Aliquota_ICMS = aliquota_icms_novo;
                        Produto.Aliquota_IPI = aliquota_ipi_novo;
                    }
                }

                foreach (Produto_Lote Variacao in analise.Lote)
                {
                    if (Variacao.ID_Produto == id_produto)
                    {
                        Variacao.Preco_Base = base_novo;
                        Variacao.Aliquota_ICMS = aliquota_icms_novo;
                        Variacao.Aliquota_IPI = aliquota_ipi_novo;
                    }
                }
            }
            else
            {
                foreach (ProdutoEntrada Produto in entrada.Produtos_Entrada)
                {
                    if (Produto.ID_Produto == id_produto)
                    {
                        Produto.Preco_Base = base_novo;
                        Produto.Aliquota_ICMS = aliquota_icms_novo;
                        Produto.Aliquota_IPI = aliquota_ipi_novo;
                    }
                }

                foreach (Produto_Lote Variacao in entrada.Lote)
                {
                    if (Variacao.ID_Produto == id_produto)
                    {
                        Variacao.Preco_Base = base_novo;
                        Variacao.Aliquota_ICMS = aliquota_icms_novo;
                        Variacao.Aliquota_IPI = aliquota_ipi_novo;
                    }
                }
            }

            Dispose();
        }
    }
}
