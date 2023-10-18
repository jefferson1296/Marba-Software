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
    public partial class formGestaoEstabelecimentosReposicoes : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Reposicao> Reposicoes = new List<Reposicao>();
        int id_reposicao;

        public formGestaoEstabelecimentosReposicoes()
        {
            InitializeComponent();
        }

        private void formGestaoEstabelecimentosReposicoes_Load(object sender, EventArgs e)
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

            Reposicoes = comandos.ListaDeReposicoes();
            dataGridViewLista.Rows.Clear();

            foreach (Reposicao Reposicao in Reposicoes)
            {
                dataGridViewLista.Rows.Add(Reposicao.ID_Reposicao, Reposicao.Tipo, Reposicao.Descricao, Reposicao.Registro.ToShortDateString(), Reposicao.Status);
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

        private void buttonAbastecimentos_Click(object sender, EventArgs e)
        {
            formGestaoEstabelecimentosReparticoesAbastecimento abastecimento = new formGestaoEstabelecimentosReparticoesAbastecimento();
            abastecimento.ShowDialog();
            AtualizarDataGrid();
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Reposicao reposicao = new Reposicao();
                id_reposicao = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                
                reposicao.Tipo = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();
                reposicao.Descricao = dataGridViewLista.Rows[e.RowIndex].Cells[2].Value.ToString();
                reposicao.ID_Reposicao = id_reposicao;

                if (id_reposicao != 0)
                {
                    formGestaoEstabelecimentosReposicoesConfirmar alterar = new formGestaoEstabelecimentosReposicoesConfirmar(reposicao);
                    alterar.ShowDialog();
                    AtualizarDataGrid();
                }
            }
            catch { }
        }
    }
}
