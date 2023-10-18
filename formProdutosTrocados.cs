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
    public partial class formProdutosTrocados : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formProdutosTrocados()
        {
            InitializeComponent();
        }

        private void formProdutosTrocados_Load(object sender, EventArgs e)
        {
            comandos.PreencherDataGridProdutosTrocados(dataGridViewLista);
            foreach (DataGridViewColumn coluna in dataGridViewLista.Columns)
            {
                if (coluna.Index != 2)
                {
                    coluna.ReadOnly = true;
                }
            }            
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            bool alteracao = false;
            bool pendente = false;
            foreach(DataGridViewRow row in dataGridViewLista.Rows)
            {
                if (dataGridViewLista.Rows[row.Index].Cells[2].Value.ToString() != "Devolvido")
                {
                    alteracao = true;
                }
                else
                {
                    pendente = true;
                }
            }
            if (alteracao)
            {
                if (pendente)
                {
                    if (DialogResult.Yes == MessageBox.Show("Alguns produtos ainda constam como pendentes\r\nDeseja continuar mesmo assim?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    {
                        comandos.AlterarStatusProdutosTrocados(dataGridViewLista);
                    }
                }
                else
                {
                    comandos.AlterarStatusProdutosTrocados(dataGridViewLista);
                }                
            }
            else
            {
                MessageBox.Show("Nenhuma alteração constatada!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewLista.Rows[e.RowIndex].Cells[2].Value.ToString() == "Devolvido")
            {
                dataGridViewLista.Rows[e.RowIndex].Cells[2].Style.SelectionForeColor = Color.Firebrick;
                dataGridViewLista.Rows[e.RowIndex].Cells[2].Style.ForeColor = Color.Firebrick;
            }
            else
            {
                dataGridViewLista.Rows[e.RowIndex].Cells[2].Style.SelectionForeColor = Color.Black;
                dataGridViewLista.Rows[e.RowIndex].Cells[2].Style.ForeColor = Color.Black;
            }
        }
    }
}
