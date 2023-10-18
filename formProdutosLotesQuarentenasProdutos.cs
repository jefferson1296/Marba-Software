using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarbaSoftware
{    
    public partial class formProdutosLotesQuarentenasProdutos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        string codigo_barras;

        public List<Produto_Quarentena> Produtos = new List<Produto_Quarentena>();

        int id_quarentena;

        string atual;

        bool permissao;


        public formProdutosLotesQuarentenasProdutos()
        {
            InitializeComponent();
        }

        public formProdutosLotesQuarentenasProdutos(int ID_Quarentena)
        {
            InitializeComponent();
            id_quarentena = ID_Quarentena;
        }

        private void formProdutosLotesQuarentenasQuarentena_Load(object sender, EventArgs e)
        {
            Produtos = comandos.ListaDeProdutosParaQuarentena(id_quarentena);

            List<string> status = new List<string>();
            status.Add("Pendente");
            status.Add("Realizado");
            status.Add("Pronto");

            ColumnEtiqueta.DataSource = status;
            ColumnAcabamento.DataSource = status;

            List<string> condicionamentos = new List<string>();
            condicionamentos.Add("Avariado");
            condicionamentos.Add("Faltando");
            condicionamentos.Add("Intacto");
            condicionamentos.Add("Pendente");
    

            ColumnCondicionamento.DataSource = condicionamentos;

            foreach (DataGridViewColumn Coluna in dataGridViewLista.Columns)
            {
                if (Coluna.Index != 3 && Coluna.Index != 4 && Coluna.Index != 5 && Coluna.Index != 6)
                {
                    dataGridViewLista.Columns[Coluna.Index].ReadOnly = true;
                }
            }

            AtualizarDataGrid();
            permissao = true;
        }

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            var lista = Produtos.GroupBy(x => (x.Nome, x.Cod_Barras, x.Etiqueta, x.Acabamento, x.Condicionamento, x.Confirmacao)).Select(g => (g.Key.Nome, g.Key.Cod_Barras, g.Key.Etiqueta, g.Key.Acabamento, g.Key.Condicionamento, g.Key.Confirmacao, Total: g.Sum(x => x.Quantidade)));

            dataGridViewLista.Rows.Clear();

            foreach (var produto in lista)
            {
                dataGridViewLista.Rows.Add(produto.Nome, produto.Cod_Barras, produto.Total, produto.Etiqueta, produto.Acabamento, produto.Condicionamento, produto.Confirmacao);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;

            Font minhafonte = new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Point);
            Font minhafonte2 = new Font("Arial", 10, FontStyle.Strikeout, GraphicsUnit.Point);

            foreach (DataGridViewRow Linha in dataGridViewLista.Rows)
            {
                string condicionamento = dataGridViewLista.Rows[Linha.Index].Cells[5].Value.ToString();

                if (condicionamento == "Avariado")
                {
                    DataGridViewRow linhaestilizada = dataGridViewLista.Rows[Linha.Index];
                    linhaestilizada.DefaultCellStyle.Font = minhafonte;
                    linhaestilizada.DefaultCellStyle.ForeColor = Color.Red;
                    linhaestilizada.DefaultCellStyle.SelectionForeColor = Color.Red;
                }
                //else if (situacao == "Pago")
                //{
                //    DataGridViewRow linhaestilizada = dataGridViewLista.Rows[Linha.Index];
                //    linhaestilizada.DefaultCellStyle.Font = minhafonte2;
                //    linhaestilizada.DefaultCellStyle.ForeColor = Color.Gray;
                //    linhaestilizada.DefaultCellStyle.SelectionForeColor = Color.Gray;
                //}
            }
        }

        private void dataGridViewLista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                if (permissao)
                {
                    DataGridViewRow linha_atual = dataGridViewLista.Rows[e.RowIndex];

                    Produto_Quarentena produto = new Produto_Quarentena
                    {
                        Nome = linha_atual.Cells[0].Value.ToString(),
                        Cod_Barras = linha_atual.Cells[1].Value.ToString(),
                        Quantidade = Convert.ToInt32(linha_atual.Cells[2].Value),
                        Etiqueta = linha_atual.Cells[3].Value.ToString(),
                        Acabamento = linha_atual.Cells[4].Value.ToString(),
                        Condicionamento = linha_atual.Cells[5].Value.ToString()
                    };

                    string edicao = string.Empty;

                    if (e.ColumnIndex == 3) { edicao = "Etiqueta"; }
                    else if (e.ColumnIndex == 4) { edicao = "Acabamento"; }
                    else if (e.ColumnIndex == 5) { edicao = "Condicionamento"; }

                    if (edicao == "Condicionamento" && produto.Condicionamento == "Intacto")
                    {
                        foreach (Produto_Quarentena Produto in Produtos)
                        {
                            if (Produto.Nome == produto.Nome && Produto.Cod_Barras == produto.Cod_Barras && Produto.Condicionamento == atual && Produto.Acabamento == produto.Acabamento && Produto.Etiqueta == produto.Etiqueta)
                            {
                                Produto.Condicionamento = "Intacto";
                            }
                        }
                    }
                    else
                    {
                        formProdutosLotesQuarentenasProdutosEditar editar = new formProdutosLotesQuarentenasProdutosEditar(this, produto, edicao, atual);
                        editar.ShowDialog();
                    }

                    AtualizarDataGrid();
                }                
            }
        }

        private void dataGridViewLista_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewLista.IsCurrentCellDirty)
            {
                dataGridViewLista.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                atual = dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            else if (e.ColumnIndex == 6)
            {
                bool confirmacao = !Convert.ToBoolean(dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                string produto = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                string codigo = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();
                string etiqueta = dataGridViewLista.Rows[e.RowIndex].Cells[3].Value.ToString();
                string acabamento = dataGridViewLista.Rows[e.RowIndex].Cells[4].Value.ToString();
                string condicionamento = dataGridViewLista.Rows[e.RowIndex].Cells[5].Value.ToString();

                if ((etiqueta == "Pendente" || acabamento == "Pendente" || condicionamento == "Pendente") && condicionamento != "Faltando" && condicionamento != "Avariado")
                {
                    MessageBox.Show("Não é possível confirmar produtos com alguma pendência!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (Produto_Quarentena Produto in Produtos)
                    {
                        if (Produto.Nome == produto && Produto.Cod_Barras == codigo && Produto.Etiqueta == etiqueta && Produto.Acabamento == acabamento && Produto.Condicionamento == condicionamento)
                        {
                            Produto.Confirmacao = confirmacao;

                            //if ()
                        }
                    }
                }

                AtualizarDataGrid();
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            bool permissao;
            bool todos;

            int confirmados = Produtos.Where(x => x.Confirmacao).Count();
            int total = Produtos.Count();

            if (confirmados == 0)
            {
                MessageBox.Show("Nenhum produto foi confirmado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                permissao = false;
                todos = false;
            }
            else
            {
                if (total != confirmados)
                {
                    if (DialogResult.Yes == MessageBox.Show("O sistema identificou que alguns produtos não foram confirmados.\r\nDeseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        permissao = true;
                        todos = false;
                    }
                    else
                    {
                        permissao = false;
                        todos = false;
                    }
                }
                else
                {
                    permissao = true;
                    todos = true;
                }

            }

            if (permissao)
            {
                comandos.AtualizarProdutosDaQuarentena(Produtos);

                if (todos)
                {
                    comandos.ConcluirQuarentena(id_quarentena);
                }

                MessageBox.Show("Quarentena lançada!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
        }

        private void buttonEtiquetas_Click(object sender, EventArgs e)
        {
            List<ProdutoEtiqueta> Lista_etiquetas = new List<ProdutoEtiqueta>();            

            foreach (Produto_Quarentena Produto in Produtos)
            {
                bool imprimir;
                if (Produto.Etiqueta == "Pendente") { imprimir = true; }
                else { imprimir = false; }
                Lista_etiquetas.Add(new ProdutoEtiqueta
                {
                    Produto = Produto.Nome,
                    Codigo = Produto.Cod_Barras,
                    Imprimir = imprimir
                });
            }

            formProdutosLotesQuarentenasProdutosEtiquetas etiquetas = new formProdutosLotesQuarentenasProdutosEtiquetas(Lista_etiquetas);
            etiquetas.ShowDialog();
        }

        private void buttonLista_Click(object sender, EventArgs e)
        {
            formRepQuarentena quarentena = new formRepQuarentena(id_quarentena);
            quarentena.ShowDialog();
        }

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    etiquetasToolStripMenuItem.Enabled = true;
                    acabamentoToolStripMenuItem.Enabled = true;
                    condicionamentoToolStripMenuItem.Enabled = true;

                    try
                    {
                        codigo_barras = dataGridViewLista[1, e.RowIndex].Value.ToString();
                    }
                    catch
                    {
                        codigo_barras = string.Empty;
                    }
                }
                else
                {
                    etiquetasToolStripMenuItem.Enabled = false;
                    acabamentoToolStripMenuItem.Enabled = false;
                    condicionamentoToolStripMenuItem.Enabled = false;
                }
            }
        }

        private void etiquetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (codigo_barras != string.Empty)
            {
                foreach (Produto_Quarentena Produto in Produtos)
                {
                    if (Produto.Cod_Barras == codigo_barras)
                    {
                        Produto.Etiqueta = "Pronto";
                    }
                }
            }

            AtualizarDataGrid();
        }

        private void acabamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (codigo_barras != string.Empty)
            {
                foreach (Produto_Quarentena Produto in Produtos)
                {
                    if (Produto.Cod_Barras == codigo_barras)
                    {
                        Produto.Acabamento = "Pronto";
                    }
                }
            }


            AtualizarDataGrid();
        }

        private void condicionamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (codigo_barras != string.Empty)
            {
                foreach (Produto_Quarentena Produto in Produtos)
                {
                    if (Produto.Cod_Barras == codigo_barras)
                    {
                        Produto.Condicionamento = "Intacto";
                    }
                }
            }


            AtualizarDataGrid();
        }
    }
}
