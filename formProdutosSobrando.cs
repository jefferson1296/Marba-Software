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
    public partial class formProdutosSobrando : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<ProdutoReposicao> Produtos = new List<ProdutoReposicao>();
        public bool alteracao;
        public formProdutosSobrando()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void formProdutosSobrando_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            Produtos = comandos.ListaDeProdutosSobrando();
            dataGridViewLista.Rows.Clear();
            foreach (ProdutoReposicao Produto in Produtos)
            {
                dataGridViewLista.Rows.Add(Produto.ID_Produto, Produto.Nome_Produto, Produto.Quantidade);
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

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id_produto = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                ProdutoReposicao produto = Produtos.Where(x => x.ID_Produto == id_produto).FirstOrDefault();
                formProdutosSobrandoSaida saida = new formProdutosSobrandoSaida(this, produto);
                saida.ShowDialog();
                if (alteracao) { AtualizarDataGrid(); }
            }
            catch { }
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            formProdutosSobrandoRegistrar registrar = new formProdutosSobrandoRegistrar(this);
            registrar.ShowDialog();
            if (alteracao)
            {
                AtualizarDataGrid();
            }
        }
    }
}
