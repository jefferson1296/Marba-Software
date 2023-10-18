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
    public partial class formVendasPDVRetiradas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formVendasPDV pdv = new formVendasPDV();
        string operador;
        public formVendasPDVRetiradas()
        {
            InitializeComponent();
        }
        public formVendasPDVRetiradas(string Operador)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            operador = Operador;
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void formVendasPDVRetiradas_Load(object sender, EventArgs e)
        {
            comandos.PreencherDataGridRetiradas(dataGridViewLista, bindingSourceRetiradas);
            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }
        private void pictureBoxHistorico_Click(object sender, EventArgs e)
        {
            formHistoricoRetiradas historico = new formHistoricoRetiradas();
            historico.ShowDialog();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
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

        private void pictureBoxPesquisar_Click(object sender, EventArgs e)
        {

        }

        private void buttonFinalizar_Click(object sender, EventArgs e)
        {
            int id;
            try { id = Convert.ToInt32(textBoxPesquisa.Text); } catch { id = 0; }
            if (id != 0)
            {
                bool verificar = comandos.VerificarIdRetirada(id);

                if (verificar)
                {
                    if (DialogResult.Yes == MessageBox.Show("Ao continuar você estará confirmando a\r\nretirada dos produtos por parte do cliente.\r\nDeseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        comandos.RegistrarRetirada(operador, id);
                        Dispose();
                    }
                }
            }
        }

        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { textBoxPesquisa.Text = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString(); }
            catch { }
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
            formRetiradaDetalhes detalhes = new formRetiradaDetalhes(id);
            detalhes.ShowDialog();
        }

        private void dataGridViewLista_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSourceRetiradas.Filter = dataGridViewLista.FilterString;
        }

        private void dataGridViewLista_SortStringChanged(object sender, EventArgs e)
        {
            bindingSourceRetiradas.Sort = dataGridViewLista.SortString;
        }

        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            bindingSourceRetiradas.Filter = "Nome_Produto like '%" + textBoxPesquisa.Text + "%'";
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
