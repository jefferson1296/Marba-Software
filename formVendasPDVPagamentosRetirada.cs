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
    public partial class formVendasPDVPagamentosRetirada : Form
    {
        formVendasPDVPagamentos pai = new formVendasPDVPagamentos();
        List<ProdutoVenda> lista = new List<ProdutoVenda>();
        public formVendasPDVPagamentosRetirada()
        {
            InitializeComponent();
        }
        public formVendasPDVPagamentosRetirada(formVendasPDVPagamentos Pai, List<ProdutoVenda> Lista)
        {
            InitializeComponent();
            pai = Pai;
            lista = Lista;
        }
        private void buttonAgendar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewLista.Rows)
            {
                if (Convert.ToBoolean(dataGridViewLista.Rows[row.Index].Cells[1].Value) == true)
                {
                    string produto = dataGridViewLista.Rows[row.Index].Cells[0].Value.ToString();
                    pai.listaRetirada.Add(produto);
                }
            }

            if (pai.listaRetirada.Count <= 0)
            {
                MessageBox.Show("Escolha os produtos que serão entregues!");
            }
            else
            {
                pai.ConfirmarRetirada = true;
                pai.DataRetirada = dateTimePicker1.Text;
                Dispose();
            }
        }

        private void formVendasPgmtRetirada_Load(object sender, EventArgs e)
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
                foreach(DataGridViewRow row in dataGridViewLista.Rows)
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
    }
}
