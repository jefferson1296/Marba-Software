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
    public partial class formGestaoConfiguracoesParametros : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formGestaoConfiguracoes pai = new formGestaoConfiguracoes();
        Parametro parametro;
        bool excluir;
        public formGestaoConfiguracoesParametros()
        {
            InitializeComponent();
        }
        public formGestaoConfiguracoesParametros(formGestaoConfiguracoes Pai)
        {   
            InitializeComponent();
            pai = Pai;
        }
        private void formGestaoConfiguracoesParametros_Load(object sender, EventArgs e)
        {
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

            foreach (Parametro Parametro in pai.Parametros)
            {
                dataGridViewLista.Rows.Add(Parametro.Descricao, Parametro.Valor);
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

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string descricao = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                parametro = pai.Parametros.Where(x => x.Descricao == descricao).FirstOrDefault();
                formGestaoConfiguracoesParametrosEditar editar = new formGestaoConfiguracoesParametrosEditar(pai, parametro);
                editar.ShowDialog();
                AtualizarDataGrid();
            }
            catch { }
        }

        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Font minhafonte = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);

            if (e.ColumnIndex == 1)
            {
                dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font = minhafonte;
            }
        }

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        dataGridViewLista.CurrentCell = dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dataGridViewLista.Rows[e.RowIndex].Selected = true;
                        dataGridViewLista.Focus();

                        string descricao = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                        parametro = pai.Parametros.Where(x => x.Descricao == descricao).FirstOrDefault();
                        excluir = true;
                    }
                    else
                    {
                        excluir = false;
                    }
                }
                catch { }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (excluir)
            {
                if (DialogResult.Yes == MessageBox.Show("O parâmetro \"" + parametro.Descricao + "\" será excluído permanentemente.\r\nTem certeza que deseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarParametro(parametro);
                    pai.AtualizarInformacoes();
                    AtualizarDataGrid();
                }
            }
        }
    }
}
