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
    public partial class formVendasPDVPagamentosEntregas : Form
    {
        List<ProdutoVenda> lista = new List<ProdutoVenda>();
        public string informacoesEntrega;
        formVendasPDVPagamentosEntregasInformacoes form = new formVendasPDVPagamentosEntregasInformacoes();

        public formVendasPDVPagamentosEntregas()
        {
            InitializeComponent();
        }
        public formVendasPDVPagamentosEntregas(List<ProdutoVenda> Lista, formVendasPDVPagamentosEntregasInformacoes Form)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            lista = Lista;
            form = Form;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridViewLista.Rows)
            {
                if (Convert.ToBoolean(dataGridViewLista.Rows[row.Index].Cells[1].Value) == true)
                {
                    string produto = dataGridViewLista.Rows[row.Index].Cells[0].Value.ToString();
                    form.list.Add(produto);
                }
            }

            if (form.list.Count <= 0)
            {
                MessageBox.Show("Escolha os produtos que serão entregues!");
            }
            else
            {
                form.confirmar = true;
                Dispose();
            }
        }

        private void formVendasPgmtEntregas_Load(object sender, EventArgs e)
        {
            foreach (ProdutoVenda row in lista)
            {
                string produto = row.Produto;
                dataGridViewLista.Rows.Add(produto);
            }
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void checkBoxTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTodos.Checked)
            {
                foreach (DataGridViewRow row in dataGridViewLista.Rows)
                {
                    dataGridViewLista.Rows[row.Index].Cells[1].Value = true;
                }
            }
        }
        private void dataGridViewLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (Convert.ToBoolean(dataGridViewLista.Rows[e.RowIndex].Cells[1].Value) == true)
                {
                    dataGridViewLista.Rows[e.RowIndex].Cells[1].Value = false;
                }
                else
                {
                    dataGridViewLista.Rows[e.RowIndex].Cells[1].Value = true;
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
    }
}
