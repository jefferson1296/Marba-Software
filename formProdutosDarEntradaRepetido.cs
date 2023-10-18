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
    public partial class formProdutosDarEntradaRepetido : Form
    {
        string produto;
        List<ProdutoEntrada> lista = new List<ProdutoEntrada>();
        formProdutosEntradaDarEntrada pai = new formProdutosEntradaDarEntrada();
        public formProdutosDarEntradaRepetido()
        {
            InitializeComponent();
        }
        public formProdutosDarEntradaRepetido(string Produto, List<ProdutoEntrada> Lista, formProdutosEntradaDarEntrada Pai)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            produto = Produto;
            lista = Lista;
            pai = Pai;
        }
        private void formProdutosDarEntradaRepetido_Load(object sender, EventArgs e)
        {
            MessageBox.Show("O sistema identificou mais de um produto com o mesmo nome.\r\nSelecione o produto que deseja inserir a partir do código de barras.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            foreach(ProdutoEntrada Produto in lista)
            {
                if (Produto.Nome_Produto == produto)
                {
                    dataGridViewLista.Rows.Add(Produto.Nome_Produto, Produto.Cod_Barras);
                }
            }
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string codigo = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();
                pai.codigo = codigo;
                pai.alteracao = true;
                Dispose();
            }
            catch { }
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
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
    }
}
