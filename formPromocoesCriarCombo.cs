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
    public partial class formPromocoesCriarCombo : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Catalogo> lista = new List<Catalogo>();

        string produto_informado;
        string cod_barras;

        public formPromocoesCriarCombo()
        {
            InitializeComponent();
        }


        #region Formatação de Texto
        private void textBoxValor_Enter(object sender, EventArgs e)
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

        private void textBoxValor_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!textBoxValor.Text.Contains(','))
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

        private void textBoxValor_Leave(object sender, EventArgs e)
        {
            if (textBoxValor.Text == string.Empty)
            {
                textBoxValor.Text = "R$0,00";
            }
            else
            {
                textBoxValor.Text = Convert.ToDouble(textBoxValor.Text).ToString("C");
            }
        }

        private void textBoxQuantidade_Enter(object sender, EventArgs e)
        {
            if (textBoxQuantidade.Text == "0")
                textBoxQuantidade.Text = string.Empty;
        }

        private void textBoxQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void textBoxQuantidade_Leave(object sender, EventArgs e)
        {
            if (textBoxQuantidade.Text == string.Empty)
                textBoxQuantidade.Text = "0";
        }
        #endregion

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {

            string produto = textBoxProduto.Text;

            if (produto_informado == string.Empty || cod_barras == string.Empty)
            {
                MessageBox.Show("Informe um produto válido para continuar!", "Produto não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool contem = false;
                foreach (Produto row in lista)
                {
                    if (row.Nome_Produto == produto)
                    {
                        MessageBox.Show("Este produto já está na lista!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        contem = true;
                    }
                }

                if (!contem)
                {
                    decimal venda = comandos.PesquisarPrecoDeVendaPeloNomeDoCatalogo(produto);


                    lista.Add(new Catalogo()
                    {
                        Nome = produto,
                        Preco_Venda = venda
                    });

                    int qtd_produtos = lista.Count;
                    textBoxProdutos.Text = qtd_produtos.ToString();
                    AtualizarDataGrid();

                    textBoxProduto.Clear();
                    textBoxProduto.Focus();
                }

            }
        }
        private void AtualizarDataGrid()
        {
            dataGridViewLista.Rows.Clear();

            foreach (Catalogo produto in lista)
            {
                dataGridViewLista.Rows.Add(produto.Nome, produto.Preco_Venda);
            }
        }

        private void formPromocoesCriarCombo_Load(object sender, EventArgs e)
        {
            textBoxProduto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxProduto.AutoCompleteCustomSource = comandos.AutoCompleteVendas();
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonAvancar_Click(object sender, EventArgs e)
        {
            string combo = textBoxCombo.Text;
            if (combo == string.Empty)
            {
                MessageBox.Show("Insira um nome para o combo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!comandos.VerificarNomeDoCombo(combo))
            {
                MessageBox.Show("Já existe um combo com o mesmo nome.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (lista.Count <= 0)
            {
                MessageBox.Show("Não há nenhum produto na lista!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (dateTimePicker1.Value.Date < DateTime.Now.Date || dateTimePicker2.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("A data não pode se referir ao passado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (dateTimePicker2.Value.Date < dateTimePicker1.Value.Date)
            {
                MessageBox.Show("A data de término não pode ser inferior a data de início!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DateTime inicio = dateTimePicker1.Value.Date;
                DateTime termino = dateTimePicker2.Value.Date;
                int quantidade = Convert.ToInt32(textBoxQuantidade.Text);
                string[] partir = textBoxValor.Text.Split('$');
                decimal valor = Convert.ToDecimal(partir[1]);

                Combo Combo = new Combo { Descricao = combo, Inicio = inicio, Termino = termino, Preco = valor, Multiplicador = quantidade };
                comandos.AdicionarCombo(Combo, lista);
                Dispose();
            }
        }

        private void textBoxProduto_Leave(object sender, EventArgs e)
        {
            string produto = textBoxProduto.Text;

            if (produto != produto_informado && produto != cod_barras) //Verifica se não é o produto informado anteriormente
            {
                bool codigo;
                try
                {
                    long x = 0; x = Convert.ToInt64(produto);
                    if (x != 0) { codigo = true; }
                    else { codigo = false; }
                }
                catch { codigo = false; }

                if (codigo)
                {
                    cod_barras = produto;

                    produto_informado = comandos.pesquisarProdutoPeloCodigo(cod_barras);

                    if (produto_informado == string.Empty)
                        produto_informado = comandos.pesquisarProdutoPorCodigoAvulso(cod_barras);

                    if (produto_informado == string.Empty)
                        cod_barras = string.Empty;
                    else
                        textBoxProduto.Text = produto_informado;
                }
                else
                {
                    produto_informado = produto;

                    cod_barras = comandos.pesquisarCodigoPeloProduto(produto_informado);
                    if (cod_barras == string.Empty)
                        produto_informado = string.Empty;
                }

                if (produto_informado == string.Empty)
                    panelLinhaVermelha.Visible = true;
                else
                    panelLinhaVermelha.Visible = false;
            }
        }

        private void formPromocoesCriarCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);
            }
        }
    }
}
