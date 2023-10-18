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
    public partial class formProdutosAlmoxarifadoConfirmarReposicao : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public List<Almoxarifado> Itens = new List<Almoxarifado>();
        int id_reposicao;
        public formProdutosAlmoxarifadoConfirmarReposicao()
        {
            InitializeComponent();
        }
        public formProdutosAlmoxarifadoConfirmarReposicao(int ID_Reposicao)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            id_reposicao = ID_Reposicao;
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void formProdutosAlmoxarifadoConfirmarReposicao_Load(object sender, EventArgs e)
        {
            Itens = comandos.ListaDeConfirmacaoDaReposicaoDoAlmoxarifado(id_reposicao);
            AtualizarDataGrid();
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

            foreach (Almoxarifado Item in Itens)
            {
                dataGridViewLista.Rows.Add(Item.ID_Almoxarifado, Item.Item, Item.Custo.ToString("F"), Item.Estoque_Ideal, (Item.Custo * Item.Estoque_Ideal).ToString("F"));
            }

            decimal total = Itens.Sum(x => x.Custo * x.Estoque_Ideal);
            textBoxTotal.Text = total.ToString("C");

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
                int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                Almoxarifado item = Itens.Where(x => x.ID_Almoxarifado == id).FirstOrDefault();

                formProdutosAlmoxarifadoConfirmarInformacoes confirmar = new formProdutosAlmoxarifadoConfirmarInformacoes(item, this);
                confirmar.ShowDialog();
                AtualizarDataGrid();
            }
            catch { }
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            comandos.ConfirmarReposicaoDoAlmoxarifado(Itens, id_reposicao);
            Dispose();
        }
    }
}
