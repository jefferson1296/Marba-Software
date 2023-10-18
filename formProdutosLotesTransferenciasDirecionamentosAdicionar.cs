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
    public partial class formProdutosLotesTransferenciasDirecionamentosAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id_lote;
        string prateleira;

        List<Produto_Direcionamento> Produtos = new List<Produto_Direcionamento>();
        List<Produto_Direcionamento> Lista_paralela = new List<Produto_Direcionamento>();

        public formProdutosLotesTransferenciasDirecionamentosAdicionar()
        {
            InitializeComponent();
        }

        private void formProdutosLotesTransferenciasDirecionamento_Load(object sender, EventArgs e)
        {
            TrazerPrateleiras();
            TrazerLotes();            
        }

        private void TrazerLotes()
        {
            List<string> lotes = comandos.LotesComProdutosParaDirecionamento();
            foreach (string lote in lotes)
            {
                comboBoxLote.Items.Add(lote);
            }

            comboBoxLote.DropDownHeight = 120;
        }

        private void TrazerPrateleiras()
        {
            List<string> prateleiras = comandos.PrateleirasComProdutosParaDirecionamento();
            foreach (string prateleira in prateleiras)
            {
                comboBoxPrateleira.Items.Add(prateleira);
            }

            comboBoxPrateleira.DropDownHeight = 120;
        }

        private void comboBoxLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id_lote = Convert.ToInt32(comboBoxLote.Text);
                AtualizarListas();
                AtualizarDataGrid();
            }
            catch { id_lote = 0; }
        }

        private void comboBoxPrateleira_SelectedIndexChanged(object sender, EventArgs e)
        {
            prateleira = comboBoxPrateleira.Text;
            AtualizarListas();
            AtualizarDataGrid();
        }

        public void AtualizarListas()
        {
            Produtos.Clear();

            if (id_lote != 0 || prateleira != string.Empty)
            {
                Produtos = comandos.ProdutosParaDirecionamento(id_lote, prateleira);
                Lista_paralela = comandos.ListaParalelaParaDirecionamento(id_lote, prateleira);
            }
        }

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            dataGridViewLista.Rows.Clear();

            foreach (Produto_Direcionamento produto in Produtos)
            {
                dataGridViewLista.Rows.Add(produto.Nome, produto.Cod_Barras, produto.Quantidade, produto.Origem, produto.Destino, produto.Confirmacao);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }

        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                string destino = dataGridViewLista.Rows[e.RowIndex].Cells[4].Value.ToString();

                if (destino != string.Empty)
                {
                    bool confirmacao = !Convert.ToBoolean(dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                    string produto = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string codigo = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string origem = dataGridViewLista.Rows[e.RowIndex].Cells[3].Value.ToString();


                    foreach (Produto_Direcionamento Produto in Produtos)
                    {
                        if (Produto.Nome == produto && Produto.Cod_Barras == codigo && Produto.Origem == origem && Produto.Destino == destino)
                        {
                            Produto.Confirmacao = confirmacao;
                        }
                    }

                    foreach (Produto_Direcionamento Produto in Lista_paralela)
                    {
                        if (Produto.Nome == produto && Produto.Cod_Barras == codigo && Produto.Origem == origem && Produto.Destino == destino)
                        {
                            Produto.Confirmacao = confirmacao;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Não é possível direcionar um produto sem prateleira definida.\r\nInforme imediatamente à gestão.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            AtualizarDataGrid();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            int confirmados = Lista_paralela.Where(x => x.Confirmacao).Count();
            int total = Lista_paralela.Count();

            if (total == 0)
            {
                MessageBox.Show("Selecione os produtos para salvar o direcionamento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                comandos.RegistrarDirecionamento();
                comandos.RegistrarProdutosDoDirecionamento(Lista_paralela);

                if (DialogResult.Yes == MessageBox.Show("Deseja imprimir a lista do direcionamento agora mesmo?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    int id = comandos.UltimoDirecionamentoRegistrado();
                    comandos.ImprimirListaDeDirecionamento(id);
                }

                Dispose();
            }
        }
    }
}
