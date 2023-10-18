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
    public partial class formPromocoesCriarPromocao : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Produto> lista = new List<Produto>();
        public formPromocoesCriarPromocao()
        {
            InitializeComponent();
        }
        private void formCriarPromocao_Load(object sender, EventArgs e)
        {
            textBoxProduto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxProduto.AutoCompleteCustomSource = comandos.AutoCompleteVendas();
        }
        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            string produto = textBoxProduto.Text;

            if (produto == string.Empty)
            {
                MessageBox.Show("Informe o nome do Produto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!comandos.VerificarNomeDoSistema(produto))
            {
                MessageBox.Show("Informe um Produto Ativo \r\npara adicionar à promoção!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    decimal custo = comandos.PesquisarPrecoDeCustoPeloNomeDoSistema(produto);
                    decimal venda = comandos.PesquisarPrecoDeVendaPeloNomeDoSistema(produto);

                    textBoxProduto.Clear();
                    lista.Add(new Produto()
                    {
                        ID_Produto = comandos.TrazerIdDoProdutoPeloNomeDoSistema(produto),
                        Nome_Produto = produto,
                        //Preco_Custo = custo,
                        //Preco_Venda = venda
                    }) ;

                    int qtd_produtos = lista.Count;
                    textBoxProdutos.Text = qtd_produtos.ToString();
                    AtualizarDataGrid();
                }

            }
        }
        private void AtualizarDataGrid()
        {
            dataGridViewLista.Rows.Clear();
            foreach (Produto produto in lista)
            {
                //dataGridViewLista.Rows.Add(produto.Nome_Produto, produto.Preco_Venda);
            }
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void buttonAvancar_Click(object sender, EventArgs e)
        {
            string nome_promocao = textBoxPromocao.Text;
            if (textBoxPromocao.Text == string.Empty)
            {
                MessageBox.Show("Insira um nome para a promoção.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
            else if (!comandos.VerificarNomeDaPromocao(nome_promocao))
            {
                MessageBox.Show("Já existe uma promoção com o mesmo nome.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (lista.Count <= 0)
            {
                MessageBox.Show("Não há nenhum produto na lista!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                bool continuar = true;
                foreach (Produto Row in lista)
                {
                    string produto = Row.Nome_Produto;
                    int id_produto = Row.ID_Produto;

                    bool verificar = comandos.VerificarSeProdutoEstaNaPromocao(id_produto);
                    if (verificar)
                    {
                        MessageBox.Show("O produto '" + produto + "'\r\njá está em promoção!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        continuar = false;
                    }
                }
                if (continuar)
                {
                    string inicio = dateTimePicker1.Text;
                    string termino = dateTimePicker2.Text;

                    string[] data1 = dateTimePicker1.Text.Split('/');
                    string[] data2 = dateTimePicker2.Text.Split('/');

                    DateTime tempo1 = new DateTime(Convert.ToInt32(data1[2]), Convert.ToInt32(data1[1]), Convert.ToInt32(data1[0]));
                    DateTime tempo2 = new DateTime(Convert.ToInt32(data2[2]), Convert.ToInt32(data2[1]), Convert.ToInt32(data2[0]));

                    double intervalo = tempo2.Subtract(tempo1).TotalDays;

                    if (intervalo < 0)
                    {
                        MessageBox.Show("A promoção não pode acabar antes mesmo de começar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (inicio == termino)
                    {
                        if (DialogResult.Yes == MessageBox.Show("As datas de início e fim da promoção estão programadas para o mesmo dia.\r\n" +
                            "Desse modo, a promoção terá duração máxima de um dia.\r\nTem certeza que deseja continuar mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            formPromocoesCriarPromocao2 avancar = new formPromocoesCriarPromocao2(nome_promocao, inicio, termino, lista) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                            this.Width = avancar.Width + 6;
                            this.CenterToScreen();
                            this.panelForm.Controls.Clear();
                            this.panelForm.Controls.Add(avancar);
                            avancar.Show();
                        }
                    }
                    else
                    {
                        formPromocoesCriarPromocao2 avancar = new formPromocoesCriarPromocao2(nome_promocao, inicio, termino, lista) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                        this.Width = avancar.Width + 6;
                        this.CenterToScreen();
                        this.panelForm.Controls.Clear();
                        this.panelForm.Controls.Add(avancar);
                        avancar.Show();
                    }
                }                
            }
        }
        private void dataGridViewLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                string produto = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                lista.RemoveAll(x => x.Nome_Produto == produto);
                int qtd_produtos = lista.Count;
                textBoxProdutos.Text = qtd_produtos.ToString();
                AtualizarDataGrid();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
