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
    public partial class formVendasPDVReservas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formVendasPDV pdv = new formVendasPDV();
        public formVendasPDVReservas()
        {
            InitializeComponent();
        }
        public formVendasPDVReservas(formVendasPDV PDV)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            pdv = PDV;
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formVendasPDVReservas_Load(object sender, EventArgs e)
        {
            comandos.PreencherDataGridReservas(dataGridViewLista, bindingSourceReservas);
            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }


        private void buttonFinalizar_Click(object sender, EventArgs e)
        {
            int id;
            try
            {
                id = Convert.ToInt32(textBoxPesquisa.Text);
            }
            catch
            { id = 0; }

            if (id == 0)
            {
                MessageBox.Show("Selecione a reserva!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                bool verificar = comandos.VerificarIdReserva(id);

                if (verificar)
                {
                    if (DialogResult.Yes == MessageBox.Show("Ao clicar em finalizar os produtos da reserva serão\r\ncarregados e a reserva será retirada do sistema.\r\nDeseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    {
                        List<ProdutoVenda> lista = comandos.TrazerProdutosReservados(id);
                        pdv.pai.Produtos.Clear();
                        foreach (ProdutoVenda row in lista)
                        {
                            string produto = row.Produto;
                            int id_produto = row.ID_Produto;
                            decimal preco = row.Preco;
                            bool verificar_promocao = comandos.VerificarSeProdutoEstaNaPromocao(comandos.TrazerIdDoProdutoPeloNomeDoSistema(produto));
                            decimal custo = comandos.PesquisarPrecoDeCustoPeloNomeDoSistema(produto);

                            if (verificar_promocao)
                            {
                                decimal preco_promocao = comandos.pesquisarPrecoPromocionalPeloID(id_produto);
                                //pdv.AdicionarProdutoALista(id_produto, produto, 1, preco, preco_promocao, 0, "Promoção", custo);
                            }
                            else
                            {
                                //pdv.AdicionarProdutoALista(id_produto, produto, 1, preco, preco, 0, "Produto", custo);
                            }
                        }
                        string partir = comandos.TrazerInformacoesDoClienteParaReserva(id);
                        string[] dados = partir.Split(';');
                        pdv.textBoxCliente.Text = dados[0];
                        //pdv.cpf = dados[1];
                        //pdv.tabela = dados[2];

                        //decimal total = pdv.VerificarValorTotal();
                        //pdv.VerificarCombos();
                        //pdv.PreencherDataGridView(total);
                        comandos.AlterarStatusDaReserva(id);
                        this.Dispose();
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

        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBoxPesquisa.Text = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch { }
        }

        private void dataGridViewLista_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSourceReservas.Filter = dataGridViewLista.FilterString;
        }

        private void dataGridViewLista_SortStringChanged(object sender, EventArgs e)
        {
            bindingSourceReservas.Sort = dataGridViewLista.SortString;
        }

        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            bindingSourceReservas.Filter = "ID like '%" + textBoxPesquisa.Text + "%'";

            string texto = textBoxPesquisa.Text;

            bool nao_encontrado = true;
            int linha_selecionada = 0;

            foreach (DataGridViewRow linha in dataGridViewLista.Rows)
            {

                if (dataGridViewLista.Rows[linha.Index].Cells[0].Value.ToString() == texto)
                {
                    linha_selecionada = linha.Index;
                    nao_encontrado = false;
                }
            }

            if (!nao_encontrado)
            {
                try
                {
                    dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
                    dataGridViewLista.Rows[linha_selecionada].Selected = true;
                    buttonFinalizar.Focus();
                }
                catch { }
            }
            else
            {
                if (dataGridViewLista.CurrentRow != null)
                    dataGridViewLista.CurrentRow.Selected = false;
            }
        }
    }
}
