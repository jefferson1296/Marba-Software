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
    public partial class formGestaoEstabelecimentos : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        List<Estabelecimento> Estabelecimentos = new List<Estabelecimento>();
        int id;
        public formGestaoEstabelecimentos()
        {
            InitializeComponent();
        }

        private void formGestaoEstabelecimentos_Load(object sender, EventArgs e)
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

            Estabelecimentos = comandos.ListaDeEstabelecimentos();
            dataGridViewLista.Rows.Clear();

            foreach (Estabelecimento Estabelecimento in Estabelecimentos)
            {
                dataGridViewLista.Rows.Add(Estabelecimento.ID_Estabelecimento, Estabelecimento.Descricao, Estabelecimento.Categoria, Estabelecimento.Endereco, Estabelecimento.Metros.ToString() + "m²", Estabelecimento.Equipamentos, Estabelecimento.Colaboradores, Estabelecimento.Status);
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

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formGestaoEstabelecimentosAdicionar adicionar = new formGestaoEstabelecimentosAdicionar();
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

                        id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    }
                    else
                    {
                        id = 0;
                    }
                }
                catch { }
            }
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);

                if (id != 0)
                {
                    formGestaoEstabelecimentosAdicionar alterar = new formGestaoEstabelecimentosAdicionar(id);
                    alterar.ShowDialog();
                    AtualizarDataGrid();
                }
            }
            catch { }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o estabelecimento?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarEstabelecimento(id);
                    AtualizarDataGrid();
                }
            }
        }

        private void buttonEquipamentos_Click(object sender, EventArgs e)
        {
            formGestaoEstabelecimentosEquipamentos equipamentos = new formGestaoEstabelecimentosEquipamentos();
            equipamentos.ShowDialog();
            AtualizarDataGrid();
        }

        private void buttonDepreciacoes_Click(object sender, EventArgs e)
        {
            formGestaoEstabelecimentosDepreciacoes depreciacoes = new formGestaoEstabelecimentosDepreciacoes();
            depreciacoes.ShowDialog();
        }

        private void repartiçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                formGestaoEstabelecimentosReparticoes reparticoes = new formGestaoEstabelecimentosReparticoes(id);
                reparticoes.ShowDialog();
            }
        }

        private void buttonReparticoes_Click(object sender, EventArgs e)
        {
            formGestaoEstabelecimentosReparticoes reparticoes = new formGestaoEstabelecimentosReparticoes();
            reparticoes.ShowDialog();
        }

        private void dataGridViewLista_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[e.RowIndex].Cells[0];
            }
            catch { }
        }

        private void buttonReposicoes_Click(object sender, EventArgs e)
        {
            formGestaoEstabelecimentosReposicoes reposicoes = new formGestaoEstabelecimentosReposicoes();
            reposicoes.ShowDialog();
        }
    }
}
