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
    public partial class formCatalogoUtensiliosGrupos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<GrupoBooleano> Grupos = new List<GrupoBooleano>();
        int grupo;
        public formCatalogoUtensiliosGrupos()
        {
            InitializeComponent();
        }

        private void formUtensiliosGrupos_Load(object sender, EventArgs e)
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

            Grupos = comandos.ListaDeGrupos();

            foreach (GrupoBooleano Grupo in Grupos)
            {
                string nome = "Utensílio";

                if (Grupo.Especificacao) { nome = nome + ", Especificação"; }
                if (Grupo.Material) { nome = nome + ", Material"; }
                if (Grupo.Capacidade) { nome = nome + ", Capacidade"; }
                if (Grupo.Altura) { nome = nome + ", Altura"; }
                if (Grupo.Largura) { nome = nome + ", Largura"; }
                if (Grupo.Comprimento) { nome = nome + ", Comprimento"; }
                if (Grupo.Diametro) { nome = nome + ", Diâmetro"; }
                if (Grupo.Cor) { nome = nome + ", Cor"; }
                if (Grupo.Estampa) { nome = nome + ", Estampa"; }

                dataGridViewLista.Rows.Add(Grupo.Grupo, nome);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formCatalogoUtensiliosGruposAdicionar adicionar = new formCatalogoUtensiliosGruposAdicionar();
            adicionar.ShowDialog();
            AtualizarDataGrid();
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

                        grupo = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    }
                    else
                    {
                        grupo = 0;
                    }
                }
                catch { }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grupo != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o grupo?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarGrupo(grupo);
                    AtualizarDataGrid();
                }
            }
        }
    }
}
