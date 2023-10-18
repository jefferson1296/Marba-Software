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
    public partial class formProdutosAlmoxarifadoNovaReposicao : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Almoxarifado> Itens = new List<Almoxarifado>();

        public formProdutosAlmoxarifadoNovaReposicao()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void formProdutosAlmoxarifadoNovaReposicao_Load(object sender, EventArgs e)
        {
            Itens = comandos.ReposicaoDoAlmoxarifado();

            foreach (Almoxarifado Item in Itens)
            {
                dataGridViewLista.Rows.Add(Item.ID_Almoxarifado, Item.Item, Item.Custo.ToString("F"), Item.Estoque_Ideal, (Item.Custo * Item.Estoque_Ideal).ToString("F"), Item.Comprar);
            }

            decimal total = Itens.Where(x => x.Comprar == true).Sum(x => x.Custo * x.Estoque_Ideal);
            textBoxTotal.Text = total.ToString("C");
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            if (Itens.Where(x => x.Comprar).Sum(x => x.Estoque_Ideal) < 1)
            {
                MessageBox.Show("Informe ao menos 1 item para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                comandos.RegistrarReposicaoDoAlmoxarifado(Itens);
                Dispose();
            }
        }

        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);

                if (!Convert.ToBoolean(dataGridViewLista.Rows[e.RowIndex].Cells[5].Value))
                {
                    dataGridViewLista.Rows[e.RowIndex].Cells[5].Value = true;
                    foreach(Almoxarifado Item in Itens) { if (Item.ID_Almoxarifado == id) { Item.Comprar = true; } }
                }
                else
                {
                    dataGridViewLista.Rows[e.RowIndex].Cells[5].Value = false;
                    foreach (Almoxarifado Item in Itens) { if (Item.ID_Almoxarifado == id) { Item.Comprar = false; } }
                }

                decimal total = Itens.Where(x => x.Comprar == true).Sum(x => x.Custo * x.Estoque_Ideal);
                textBoxTotal.Text = total.ToString("C");
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
    }
}
