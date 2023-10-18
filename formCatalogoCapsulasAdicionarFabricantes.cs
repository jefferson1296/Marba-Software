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
    public partial class formCatalogoCapsulasAdicionarFabricantes : Form
    {
        formCatalogoCapsulasAdicionar pai = new formCatalogoCapsulasAdicionar();
        List<string> Fabricantes = new List<string>();
        bool alteracao = false;
        
        public formCatalogoCapsulasAdicionarFabricantes()
        {
            InitializeComponent();
        }
        public formCatalogoCapsulasAdicionarFabricantes(formCatalogoCapsulasAdicionar Pai)
        {
            InitializeComponent();
            pai = Pai;
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void formUtensilioAdicionarEncapsularFornecedores_Load(object sender, EventArgs e)
        {
            //Traz uma lista com todos os fabricantes (distintos) da lista de produtos.

            Fabricantes = pai.Produtos_disponiveis.OrderBy(x => x.Fabricante).Select(x => x.Fabricante).Distinct().ToList();

            foreach(string Fabricante in Fabricantes)
            {
                //Verifica cada fornecedor: Se não contém esse fornecedor na lista de fornecedores excluídos (Fornecedores que não devem aparecer no filtro), "contem" será True.
                bool contem = !pai.Fabricantes_excluidos.Contains(Fabricante);
                dataGridViewLista.Rows.Add(Fabricante, contem);
            }
        }

        private void dataGridViewLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string fornecedor = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
            bool contem = Convert.ToBoolean(dataGridViewLista.Rows[e.RowIndex].Cells[1].Value);

            if (contem)
            {
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Value = false;
                pai.Fabricantes_excluidos.Add(fornecedor);
            }
            else 
            { 
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Value = true;
                pai.Fabricantes_excluidos.Remove(fornecedor);
            }

            alteracao = true;
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            if (alteracao)
            {
                pai.alteracao = true;
            }
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
