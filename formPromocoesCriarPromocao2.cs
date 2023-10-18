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
    public partial class formPromocoesCriarPromocao2 : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        string nome_promocao;
        string inicio;
        string termino;
        List<Produto> lista = new List<Produto>();

        public formPromocoesCriarPromocao2()
        {
            InitializeComponent();
        }
        public formPromocoesCriarPromocao2(string Nome,string Inicio, string Termino, List<Produto> Lista)
        {
            InitializeComponent();
            nome_promocao = Nome;
            inicio = Inicio;
            termino = Termino;
            lista = Lista;
        }
        private void formCriarPromocao2_Load(object sender, EventArgs e)
        {
            decimal percentual = 0;
            textBoxDesconto.Text = percentual.ToString() + "%";
            labelPromocao.Text = nome_promocao;
            textBoxProdutos.Text = lista.Count.ToString();

            foreach (Produto row in lista)
            {
                //decimal custo = Convert.ToDecimal(row.Preco_Custo);
                //decimal venda = Convert.ToDecimal(row.Preco_Venda);
                //decimal desconto = (venda * percentual) / 100;
                //decimal subtotal = venda - desconto;
                //decimal lucro = subtotal - custo;
                //decimal margem = (lucro / subtotal) * 100;


                //dataGridViewLista.Rows.Add(row.Nome_Produto, custo.ToString("F"), venda.ToString("F"), percentual, desconto.ToString("F"), subtotal.ToString("F"), margem.ToString("F"));
            }

            foreach (DataGridViewColumn coluna in dataGridViewLista.Columns)
            {
                if (coluna.Index == 0 || coluna.Index == 1 || coluna.Index == 2 || coluna.Index == 6 || coluna.Index == 7)
                {
                    coluna.ReadOnly = true;
                }
            }
        }
        #region Formatação
        private void dataGridViewLista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
            catch { }

            try
            {
                string texto = dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                int contar = texto.Split(',').Length;
                int resultado = contar - 1;

                if (resultado > 1)
                {
                    dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0.ToString("F");
                }
            }
            catch { }

            try
            {
                //dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Convert.ToDecimal(dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value).ToString("F");
            }
            catch { }

            try
            {
                decimal custo = Convert.ToDecimal(dataGridViewLista.Rows[e.RowIndex].Cells[1].Value);
                decimal venda = Convert.ToDecimal(dataGridViewLista.Rows[e.RowIndex].Cells[2].Value);

                if (dataGridViewLista.Columns[e.ColumnIndex] == dataGridViewLista.Columns[3])
                {
                    decimal percentual = Convert.ToDecimal(dataGridViewLista.Rows[e.RowIndex].Cells[3].Value);
                    decimal desconto = (venda * percentual) / 100;
                    decimal subtotal = venda - desconto;
                    decimal lucro = subtotal - custo;
                    decimal margem = (lucro / subtotal) * 100;
                    dataGridViewLista.Rows[e.RowIndex].Cells[4].Value = desconto.ToString("F");
                    dataGridViewLista.Rows[e.RowIndex].Cells[5].Value = subtotal.ToString("F");
                    dataGridViewLista.Rows[e.RowIndex].Cells[6].Value = margem.ToString("F");
                }
                else if (dataGridViewLista.Columns[e.ColumnIndex] == dataGridViewLista.Columns[4])
                {
                    decimal desconto = Convert.ToDecimal(dataGridViewLista.Rows[e.RowIndex].Cells[4].Value);
                    decimal percentual = (desconto / venda) * 100;
                    decimal subtotal = venda - desconto;
                    decimal lucro = subtotal - custo;
                    decimal margem = (lucro / subtotal) * 100;
                    dataGridViewLista.Rows[e.RowIndex].Cells[3].Value = percentual.ToString("F");
                    dataGridViewLista.Rows[e.RowIndex].Cells[5].Value = subtotal.ToString("F");
                    dataGridViewLista.Rows[e.RowIndex].Cells[6].Value = margem.ToString("F");

                }
                else if (dataGridViewLista.Columns[e.ColumnIndex] == dataGridViewLista.Columns[5])
                {
                    decimal subtotal = Convert.ToDecimal(dataGridViewLista.Rows[e.RowIndex].Cells[5].Value);
                    if (subtotal > venda)
                    {
                        MessageBox.Show("Não é permitido atribuir um\r\npreço maior que o preço de venda\r\n no programa de Promoções!");
                        dataGridViewLista.Rows[e.RowIndex].Cells[5].Value = Convert.ToDecimal(dataGridViewLista.Rows[e.RowIndex].Cells[2].Value).ToString();
                    }
                    else
                    {
                        decimal desconto = venda - subtotal;
                        decimal percentual = (desconto / venda) * 100;
                        decimal lucro = subtotal - custo;
                        decimal margem = (lucro / subtotal) * 100;
                        dataGridViewLista.Rows[e.RowIndex].Cells[3].Value = percentual.ToString("F");
                        dataGridViewLista.Rows[e.RowIndex].Cells[4].Value = desconto.ToString("F");
                        dataGridViewLista.Rows[e.RowIndex].Cells[6].Value = margem.ToString("F");
                    }
                }
            }
            catch { }
        }
        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewLista.Columns[e.ColumnIndex] == dataGridViewLista.Columns[0] || dataGridViewLista.Columns[e.ColumnIndex] == dataGridViewLista.Columns[1]
                || dataGridViewLista.Columns[e.ColumnIndex] == dataGridViewLista.Columns[2] || dataGridViewLista.Columns[e.ColumnIndex] == dataGridViewLista.Columns[6]
                 || dataGridViewLista.Columns[e.ColumnIndex] == dataGridViewLista.Columns[7])
            {
                dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGray;
            }
        }
        private void dataGridViewLista_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }
        }
        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
               (e.KeyChar != ',' && e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
        }
        private void textBoxDesconto_Enter(object sender, EventArgs e)
        {
            string[] partir = textBoxDesconto.Text.Split('%');
            if (partir[0] == "0,00")
            {
                textBoxDesconto.Text = string.Empty;
            }
            else
            {
                textBoxDesconto.Text = partir[0];
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
        private void textBoxDesconto_Leave(object sender, EventArgs e)
        {
            decimal desconto = Convert.ToDecimal(textBoxDesconto.Text);
            string desc = desconto.ToString("F") + "%";
        }
        #endregion
        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            string[] partir = textBoxDesconto.Text.Split('%');
            decimal desconto = Convert.ToDecimal(partir[0]);
            foreach (DataGridViewRow linha in dataGridViewLista.Rows)
            {
                dataGridViewLista.Rows[linha.Index].Cells[3].Value = desconto.ToString();
            }
        }
        private void dataGridViewLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                string produto = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                lista.RemoveAll(x => x.Nome_Produto == produto);
                int qtd_produtos = lista.Count;
                textBoxProdutos.Text = qtd_produtos.ToString();

                dataGridViewLista.Rows.Remove(dataGridViewLista.Rows[e.RowIndex]);
            }
        } //Apagar Linha

        private void buttonConcluir_Click(object sender, EventArgs e)
        {
            ComandosSQL comando = new ComandosSQL();
            int qtd_produtos = lista.Count;
            bool continuar = true;

            if (qtd_produtos <= 0)
            {
                MessageBox.Show("Não há nenhum produto na lista.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string parametro = "Margem Mínima Para Promoção";
                decimal parameter = comandos.ObterValorDoParametro(parametro);
                foreach (DataGridViewRow lin in dataGridViewLista.Rows)
                {
                    string produto = dataGridViewLista.Rows[lin.Index].Cells[0].Value.ToString();
                    decimal margem = Convert.ToDecimal(dataGridViewLista.Rows[lin.Index].Cells[6].Value);
                    if (margem < parameter)
                    {
                        MessageBox.Show("A margem de lucro não pode ser inferior a " + 
                            Convert.ToString(parameter) + "%.\r\n Altere o desconto do produto '"
                            + produto + "' para continuar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        continuar = false;
                    }
                }
                if (continuar)
                {
                    foreach (Produto row in lista)
                    {
                        string produto = row.Nome_Produto;
                        foreach (DataGridViewRow linha in dataGridViewLista.Rows)
                        {
                            string Produto = dataGridViewLista.Rows[linha.Index].Cells[0].Value.ToString();
                            if (produto == Produto)
                            {
                                decimal preco_promocional = Convert.ToDecimal(dataGridViewLista.Rows[linha.Index].Cells[5].Value);
                                //row.Preco_Promocao = preco_promocional;
                            }
                        }
                    }
                    comando.AdicionarPromocao(nome_promocao, inicio, termino, lista);
                }
            }            
        }
    }
}
