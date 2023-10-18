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
    public partial class formProdutosCadastrarConjuntoDistinto : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        Conjunto conjunto = new Conjunto();
        List<Produto> lista_produto = new List<Produto>();
        int qtd_produtos;

        public formProdutosCadastrarConjuntoDistinto()
        {
            InitializeComponent();
        }
        public formProdutosCadastrarConjuntoDistinto(Conjunto Conjunto)
        {
            InitializeComponent();
            conjunto = Conjunto;
        }

        private void formProdutosCadastrarConjuntoDistinto_Load(object sender, EventArgs e)
        {
            utensilioComboBox.DropDownHeight = 120;
            comboBoxMateriaPrima.DropDownHeight = 120;
            comboBoxMateriaPrima.DropDownWidth = 180;

            ComandosSQL comandos = new ComandosSQL();
            //Carregar Itens do Combobox Categoria            

            utensilioComboBox.DataSource = comandos.TrazerUtensilios();
            utensilioComboBox.ValueMember = "ID_Utensilio";
            utensilioComboBox.DisplayMember = "Nome_utensilio";
            utensilioComboBox.Update();

            comboBoxMateriaPrima.Items.Clear();
            List<string> Materiais = comandos.TrazerMateriaPrima();
            foreach (string x in Materiais) { comboBoxMateriaPrima.Items.Add(x); }
            comboBoxMateriaPrima.Update();


            utensilioComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            utensilioComboBox.AutoCompleteCustomSource = comandos.AutoCompleteUtensilios();

            utensilioComboBox.Text = string.Empty;

            string fabricante;

            qtd_produtos = conjunto.Qtd_Produtos;
            fabricante = conjunto.Fabricante;
            string nome_conjunto = conjunto.Nome_Conjunto;
            decimal custo_base = conjunto.Custo_Base;
            string cod_extra = conjunto.Cod_Extra;

            icmsTextBox.Text = conjunto.Aliquota_ICMS.ToString("F") + "%";
            ipiTextBox.Text = conjunto.Aliquota_IPI.ToString("F") + "%";
            labelFornecedor.Text = fabricante;
            labelConjunto.Text = nome_conjunto;
            textBoxCustoConjunto.Text = custo_base.ToString("C");
            textBoxCustoRestante.Text = custo_base.ToString("C");
            codExtraTextBox.Text = cod_extra;

            decimal base_unitario = custo_base / qtd_produtos;
            custoTextBox.Text = (custo_base + (custo_base / 100 * conjunto.Aliquota_ICMS) + (custo_base / 100 * conjunto.Aliquota_IPI)).ToString("C");

            baseTextBox.Text = base_unitario.ToString("C");

            labelProdutos.Text = qtd_produtos.ToString() + " Produtos";
            textBoxRestante.Text = qtd_produtos.ToString();
        }
        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            decimal custo_parcial = lista_produto.Cast<Produto>().Sum(i => i.Preco_Base);
            string[] partir = textBoxCustoConjunto.Text.Split('$');
            decimal custo_total = Convert.ToDecimal(partir[1]);
            //double diferenca = Convert.ToDouble((Convert.ToDouble(custo_total) - Convert.ToDouble(custo_parcial) - Convert.ToDouble(base_custo)).ToString("F"));


            string produto = nomeTextBox.Text;
            string utensilio = utensilioComboBox.Text;
            string materiaprima = comboBoxMateriaPrima.Text;
            string fornecedor = labelFornecedor.Text;

            bool permitir = true;
            if (produto == string.Empty)
            {
                MessageBox.Show("Informe o nome do produto para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (utensilio == string.Empty)
            {
                MessageBox.Show("Informe o utensílio do produto para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (materiaprima == string.Empty)
            {
                MessageBox.Show("Informe a matéria-prima do produto para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (fornecedor == string.Empty)
            {
                MessageBox.Show("Informe o fornecedor do produto para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //else if (qtd_produtos - lista_produto.Count == 1)
            //{
            //    if (diferenca > 0)
            //    {
            //        MessageBox.Show("A soma do custo dos produtos não pode ser inferior\r\nao preço de custo total do conjunto informado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        permitir = false;
            //    }
            //    else if (diferenca < 0)
            //    {
            //        MessageBox.Show("A soma do custo dos produtos não pode ser superior\r\nao preço de custo total do conjunto informado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        permitir = false;
            //    }
            //}
            //else if (qtd_produtos - lista_produto.Count > 1)
            //{
            //    if (diferenca < 0)
            //    {
            //        MessageBox.Show("A soma do custo dos produtos não pode ser superior\r\nao preço de custo total do conjunto informado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        permitir = false;
            //    }
            //    else if (diferenca == 0)
            //    {
            //        MessageBox.Show("A soma do custo dos produtos não pode ser igual ao preço de custo total do conjunto informado antes de cadastrar o último produto", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        permitir = false;
            //    }
            //}

            if (permitir)
            {  
                string especificacao = especificacaoComboBox.Text;
                string altura = altTextBox.Text + " " + altComboBox.Text;
                string largura = larTextBox.Text + " " + larComboBox.Text;
                string comprimento = comTextBox.Text + " " + comComboBox.Text;
                string capacidade = medidaTextBox.Text + " " + medidaComboBox.Text;
                string diametro = diTextBox.Text + " " + diComboBox.Text;

                if (!comandos.VerificarSeEspecificacaoJaExiste(utensilio, especificacao) && especificacao != string.Empty)
                {
                    MessageBox.Show("Essa especificação não está cadastrada!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (altTextBox.Text == string.Empty && altComboBox.Text != string.Empty || altTextBox.Text != string.Empty && altComboBox.Text == string.Empty)
                {
                    MessageBox.Show("É necessário informar o valor e a unidade de medida da Altura!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (larTextBox.Text == string.Empty && larComboBox.Text != string.Empty || larTextBox.Text != string.Empty && larComboBox.Text == string.Empty)
                {
                    MessageBox.Show("É necessário informar o valor e a unidade de medida da Largura!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (comTextBox.Text == string.Empty && comComboBox.Text != string.Empty || comTextBox.Text != string.Empty && comComboBox.Text == string.Empty)
                {
                    MessageBox.Show("É necessário informar o valor e a unidade de medida do Cumprimento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (diTextBox.Text == string.Empty && diComboBox.Text != string.Empty || diTextBox.Text != string.Empty && diComboBox.Text == string.Empty)
                {
                    MessageBox.Show("É necessário informar o valor e a unidade de medida do Diâmetro!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (medidaTextBox.Text == string.Empty && medidaComboBox.Text != string.Empty || medidaTextBox.Text != string.Empty && medidaComboBox.Text == string.Empty)
                {
                    MessageBox.Show("É necessário informar o valor e a unidade de medida da Capacidade!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    lista_produto.Add(new Produto()
                    {
                        Nome_Produto = produto,
                        //Cod_Extra = codextra,
                        Utensilio = utensilio,
                        MateriaPrima = materiaprima,
                        //Preco_Base = base_custo,
                        //Aliquota_ICMS = aliquota_icms,
                        //Aliquota_IPI = aliquota_ipi,
                        Especificacao = especificacao,
                        Altura = altura,
                        Largura = largura,
                        Diametro = diametro,
                        Comprimento = comprimento,
                    });

                    AtualizarDataGrid();
                    string[] partir2 = textBoxCustoRestante.Text.Split('$');
                    //textBoxCustoRestante.Text = (Convert.ToDouble(custo_total) - Convert.ToDouble(custo_parcial) - Convert.ToDouble(base_custo)).ToString("C");
                    textBoxRestante.Text = (qtd_produtos - lista_produto.Count).ToString();


                    nomeTextBox.Clear();
                    caixaTextBox.Clear();
                    codExtraTextBox.Clear();

                    utensilioComboBox.DataSource = comandos.TrazerUtensilios();
                    utensilioComboBox.ValueMember = "ID_Utensilio";
                    utensilioComboBox.DisplayMember = "Nome_utensilio";
                    utensilioComboBox.Update();

                    comboBoxMateriaPrima.Items.Clear();
                    List<string> Materiais = comandos.TrazerMateriaPrima();
                    foreach (string x in Materiais) { comboBoxMateriaPrima.Items.Add(x); }
                    comboBoxMateriaPrima.Update();

                    if (lista_produto.Count() == qtd_produtos)
                    {
                        buttonAdicionar.Enabled = false;
                        buttonAdicionar.FlatStyle = FlatStyle.Standard;
                        buttonAdicionar.UseVisualStyleBackColor = false;
                    }
                }
            }
        }

        #region Formatação
        private void caixaTextBox_Leave(object sender, EventArgs e)
        {
            if (caixaTextBox.Text == string.Empty)
                caixaTextBox.Text = "0";
        }
        private void caixaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }
        private void caixaTextBox_Enter(object sender, EventArgs e)
        {
            if (caixaTextBox.Text == "0")
                caixaTextBox.Text = string.Empty;
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
                icmsTextBox.Text = "0,00%";
                icmsTextBox.ForeColor = Color.Gray;
            }
            else
            {
                decimal aliquota_icms = Convert.ToDecimal(icmsTextBox.Text);
                icmsTextBox.Text = aliquota_icms.ToString("F") + "%";
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
        private void baseTextBox_Leave(object sender, EventArgs e)
        {
            if (baseTextBox.Text == string.Empty)
            {
                baseTextBox.Text = "R$0,00";
                baseTextBox.ForeColor = Color.Gray;
            }
            else
            {
                decimal base_custo = Convert.ToDecimal(baseTextBox.Text);
                baseTextBox.Text = base_custo.ToString("C");
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

        private void utensilioComboBox_Leave(object sender, EventArgs e)
        {
        }
        #endregion
        #region Métodos
        public void AtualizarDataGrid()
        {
            dataGridViewLista.Rows.Clear();
            foreach (Produto row in lista_produto)
            {
                //string produto = row.Nome_Produto;
                //dataGridViewLista.Rows.Add(codbar, produto, custo.ToString("C"), venda.ToString("C"), caixa);
            }
        }
        public decimal CalcularPrecoDeVenda(decimal custo)
        {
            decimal margem = comandos.ObterValorDoParametro("Margem de Lucro em Relação ao Custo");
            decimal venda = custo + (custo * margem / 100);
            decimal significancia = comandos.ObterValorDoParametro("Arredondar Preço de Venda");
            decimal preco_venda = comandos.ArredondarDecimal(venda, significancia);
            return preco_venda;
        }
        #endregion

        private void buttonConcluir_Click(object sender, EventArgs e)
        {
            if (qtd_produtos > lista_produto.Count())
            {
                int contagem = lista_produto.Count();
                int restante = qtd_produtos - contagem;
                string produtx;
                if (restante == 1) { produtx = " produto."; }
                else { produtx = " produtos."; }
                MessageBox.Show("A quantidade de produtos (" + qtd_produtos.ToString() + ") informada é superior\r\na quantidade de produtos cadastrados.\r\nFalta cadastrar " + restante.ToString() + produtx, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //comandos.CadastrarProdutos(true, lista_produto, conjunto);
                Dispose();
            }
        }
        private void dataGridViewLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                string produto = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();
                decimal base_preco = lista_produto.Where(x => x.Nome_Produto == produto).Select(x => x.Preco_Base).FirstOrDefault();
                lista_produto.RemoveAll(x => x.Nome_Produto == produto);
                AtualizarDataGrid();
                string[] partir = textBoxCustoRestante.Text.Split('$');
                textBoxCustoRestante.Text = (Convert.ToDecimal(partir[1]) + base_preco).ToString("C");
                textBoxRestante.Text = (qtd_produtos - lista_produto.Count).ToString();
            }
        }

        private void utensilioComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            especificacaoComboBox.Text = string.Empty;
            string utensilio = utensilioComboBox.Text;
            AtualizarComboEspecificacoes();
        }
        private void AtualizarComboEspecificacoes()
        {
            especificacaoComboBox.Items.Clear();
            string utensilio = utensilioComboBox.Text;
            try
            {
                List<string> lista = comandos.PreencherComboEspecificacao(utensilio);
                foreach (string x in lista) { especificacaoComboBox.Items.Add(x); }
                especificacaoComboBox.AutoCompleteCustomSource = comandos.AutoCompleteEspecificacao(utensilio);
            }
            catch { }
        }
        private void altTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!altTextBox.Text.Contains(','))
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

        private void larTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!larTextBox.Text.Contains(','))
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

        private void comTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!comTextBox.Text.Contains(','))
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

        private void diTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!diTextBox.Text.Contains(','))
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

        private void medidaTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!medidaTextBox.Text.Contains(','))
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

        private void altTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal valor = Convert.ToDecimal(altTextBox.Text);
                altTextBox.Text = valor.ToString();
            }
            catch { }
        }

        private void larTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal valor = Convert.ToDecimal(larTextBox.Text);
                larTextBox.Text = valor.ToString();
            }
            catch { }
        }

        private void comTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal valor = Convert.ToDecimal(comTextBox.Text);
                comTextBox.Text = valor.ToString();
            }
            catch { }
        }

        private void diTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal valor = Convert.ToDecimal(diTextBox.Text);
                diTextBox.Text = valor.ToString();
            }
            catch { }
        }

        private void medidaTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal valor = Convert.ToDecimal(medidaTextBox.Text);
                medidaTextBox.Text = valor.ToString();
            }
            catch { }
        }
    }
}
