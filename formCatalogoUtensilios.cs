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
    public partial class formCatalogoUtensilios : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Utensilio> Utensilios = new List<Utensilio>();
        int id_utensilio;
        public bool alteracao;
        public formCatalogoUtensilios()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void formUtensilios_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }
        private void AtualizarDataGrid()
        {
            dataGridViewLista.Rows.Clear();
            Utensilios = comandos.TrazerListaDeUtensilios();
            foreach (Utensilio Utensilio in Utensilios)
            {
                int id_utensilio = Utensilio.ID_Utensilio;
                string utensilio = Utensilio.Nome_Utensilio;
                int produtos = Utensilio.qtd_Produtos;
                int ativos = Utensilio.qtd_Ativos;
                string categoria = Utensilio.Categoria;

                dataGridViewLista.Rows.Add(id_utensilio, utensilio, produtos, ativos, categoria);
            }
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id_utensilio = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
            formCatalogoUtensiliosEditar editar = new formCatalogoUtensiliosEditar(id_utensilio, this);
            editar.ShowDialog();
            if (alteracao)
            {
                AtualizarDataGrid();
                alteracao = false;
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formCatalogoUtensiliosCadastrar cadastrar = new formCatalogoUtensiliosCadastrar(this);
            cadastrar.ShowDialog();
            if (alteracao)
            {
                AtualizarDataGrid();
                alteracao = false;
            }
        }

        #region Movimentacao do Formulario
        bool clique;
        Point clickedAt;
        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique)
            {
                Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
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
            id_utensilio = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
        }

        private void buttonGrupos_Click(object sender, EventArgs e)
        {
            formCatalogoUtensiliosGrupos grupos = new formCatalogoUtensiliosGrupos();
            grupos.ShowDialog();
        }
    }
}
