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
    public partial class formProdutosConjuntosCadastrar : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        bool cadastrar_produto;
        int id_produto;

        public decimal base_custo = 0;
        decimal aliquota_ipi = 0;
        decimal aliquota_icms = 0;

        public formProdutosConjuntosCadastrar()
        {
            InitializeComponent();
            cadastrar_produto = true;
        }

        public formProdutosConjuntosCadastrar(int ID_Produto)
        {
            InitializeComponent();
            cadastrar_produto = false;
            id_produto = ID_Produto;
        }

        private void formProdutosCadastrarConjuntoIdentico_Load(object sender, EventArgs e)
        {
            List<string> Fabricantes = comandos.TrazerFabricantes();
            foreach (string x in Fabricantes) { comboBoxFabricante.Items.Add(x); }
            comboBoxFabricante.Update();
            comboBoxFabricante.DropDownHeight = 120;

            if (!cadastrar_produto)
            {
                Produto produto = comandos.TrazerTodasInformacoesDoProduto(id_produto);

                conjuntoTextBox.Text = produto.Nome_Produto;
                comboBoxFabricante.SelectedItem = produto.Fabricante;
                codExtraTextBox.Text = produto.Cod_Extra;

                base_custo = produto.Preco_Base;
                aliquota_icms = produto.Aliquota_ICMS;
                aliquota_ipi = produto.Aliquota_IPI;

                CalcularPrecoDeCusto();
            }
        }

        #region Formatação
        private void baseTextBox_Leave(object sender, EventArgs e)
        {
            if (baseTextBox.Text == string.Empty)
            {
                base_custo = 0;
                baseTextBox.ForeColor = Color.Gray;
            }
            else
            {
                base_custo = Convert.ToDecimal(baseTextBox.Text);
            }

            CalcularPrecoDeCusto();
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
        private void baseTextBox_Enter(object sender, EventArgs e)
        {
            baseTextBox.ForeColor = Color.Black;
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
        private void marcaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fornecedor = comboBoxFabricante.Text;
            Fornecedor Fornecedor = comandos.TrazerImpostoPeloFornecedor(fornecedor);

            aliquota_ipi = Fornecedor.IPI;
            aliquota_icms = Fornecedor.ICMS;

            CalcularPrecoDeCusto();
        }
        private void qtdTextBox_Leave(object sender, EventArgs e)
        {
            if (qtdTextBox.Text == string.Empty)
                qtdTextBox.Text = "0";
        }
        private void qtdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
        private void qtdTextBox_Enter(object sender, EventArgs e)
        {
            if (qtdTextBox.Text == "0")
                qtdTextBox.Text = string.Empty;
        }
        #endregion

        private void avancarButton_Click(object sender, EventArgs e)
        {
            string tipo_conjunto;

            if (radioButtonIdenticos.Checked)
            {
                tipo_conjunto = "IDÊNTICOS";
            }
            else
            {
                tipo_conjunto = "DISTINTOS";
            }

            string nome_conjunto = conjuntoTextBox.Text;
            string fabricante = comboBoxFabricante.Text;
            int qtd_produtos = Convert.ToInt32(qtdTextBox.Text);
            string cod_extra = codExtraTextBox.Text;

            string[] partir = baseTextBox.Text.Split('$');
            decimal base_custo = Convert.ToDecimal(partir[1]);

            if (nome_conjunto == string.Empty)
            {
                MessageBox.Show("É necessário informar o nome do conjunto para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comandos.VerificarNome(nome_conjunto))
            {
                MessageBox.Show("Esse nome já está sendo utilizado por um Conjunto.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (base_custo == 0)
            {
                MessageBox.Show("Informe a base de cálculo do preço de custo para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (qtd_produtos == 0)
            {
                MessageBox.Show("Informe quantos produtos compõe o conjunto para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                string tipo_venda;
                if (conjuntoCheckBox.Checked)
                {
                    tipo_venda = "CONJUNTO";
                }
                else
                {
                    tipo_venda = "UNIDADE";
                }

                Conjunto Conjunto = new Conjunto
                {
                    Nome_Conjunto = nome_conjunto,
                    Tipo_Conjunto = tipo_conjunto,
                    Tipo_Venda = tipo_venda,
                    Fabricante = fabricante,
                    Qtd_Produtos = qtd_produtos,
                    Aliquota_ICMS = aliquota_icms,
                    Aliquota_IPI = aliquota_ipi,
                    Custo_Base = base_custo,
                    Cod_Extra = cod_extra
                };

                if (cadastrar_produto)
                {
                    if (tipo_conjunto == "DISTINTOS" && tipo_venda == "UNIDADE")
                    {
                        formProdutosCadastrarConjuntoDistinto distintos = new formProdutosCadastrarConjuntoDistinto(Conjunto);
                        distintos.ShowDialog();
                    }
                    else
                    {
                        formProdutosCadastrar avancar = new formProdutosCadastrar(Conjunto);
                        avancar.ShowDialog();
                    }
                }
                else
                {
                    comandos.CadastrarConjunto(Conjunto);
                    comandos.AtribuirConjuntoAoProduto(id_produto);
                    MessageBox.Show("Conjunto cadastrado!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Dispose();
            }            
        }

        private void ipiTextBox_Leave(object sender, EventArgs e)
        {
            if (ipiTextBox.Text == string.Empty)
            {
                aliquota_ipi = 0;
                ipiTextBox.ForeColor = Color.Gray;
            }
            else
            {
                aliquota_ipi = Convert.ToDecimal(ipiTextBox.Text);
            }

            CalcularPrecoDeCusto();
        }

        private void CalcularPrecoDeCusto()
        {
            decimal ipi = (aliquota_ipi * base_custo / 100);
            decimal icms = (aliquota_icms * base_custo / 100);
            decimal custo = base_custo + ipi + icms;

            baseTextBox.Text = base_custo.ToString("C");
            ipiTextBox.Text = aliquota_ipi.ToString("F") + "%";
            icmsTextBox.Text = aliquota_icms.ToString("F") + "%";
            custoTextBox.Text = custo.ToString("C");
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
        private void icmsTextBox_Leave(object sender, EventArgs e)
        {
            if (icmsTextBox.Text == string.Empty)
            {
                aliquota_icms = 0;
                icmsTextBox.ForeColor = Color.Gray;
            }
            else
            {
                aliquota_icms = Convert.ToDecimal(icmsTextBox.Text);
            }

            CalcularPrecoDeCusto();
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

        private void fecharPictureBox_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #region Movimentacao do Formulário
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
    }
}