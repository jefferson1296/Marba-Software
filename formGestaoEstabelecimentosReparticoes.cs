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
    public partial class formGestaoEstabelecimentosReparticoes : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Reparticao> Reparticoes = new List<Reparticao>();

        bool multi_setores;

        int id_estabelecimento;
        int id;
        public formGestaoEstabelecimentosReparticoes()
        {
            InitializeComponent();
        }
        public formGestaoEstabelecimentosReparticoes(int ID_Estabelecimento)
        {
            InitializeComponent();
            id_estabelecimento = ID_Estabelecimento;
        }

        private void formGestaoEstabelecimentosReparticoes_Load(object sender, EventArgs e)
        {
            multi_setores = Program.Acessos.Where(x => x.Descricao == "Multi-setores").Select(x => x.Permissao).FirstOrDefault();
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

            if (multi_setores)
            {
                Reparticoes = comandos.ListaDeRepartições();
            }
            else
            {
                Reparticoes = comandos.ListaDeRepartiçõesPorGerente();
            }

            dataGridViewLista.Rows.Clear();

            if (id_estabelecimento != 0)
            {
                Reparticoes = Reparticoes.Where(x => x.ID_Estabelecimento == id_estabelecimento).ToList();
            }

            foreach (Reparticao Reparticao in Reparticoes)
            {
                dataGridViewLista.Rows.Add(Reparticao.ID_Reparticao, Reparticao.Descricao, Reparticao.Metros.ToString() + "m²", Reparticao.Estabelecimento, Reparticao.Setor);
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
            formGestaoEstabelecimentosReparticoesAdicionar adicionar;

            if (id_estabelecimento == 0)
            {
                adicionar = new formGestaoEstabelecimentosReparticoesAdicionar(0);
            }
            else
            {
                adicionar = new formGestaoEstabelecimentosReparticoesAdicionar(id_estabelecimento);
            }

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

                        if (multi_setores) 
                            apagarToolStripMenuItem.Visible = true; 
                        else
                            apagarToolStripMenuItem.Visible = false;
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
            if (multi_setores)
            {
                try
                {
                    id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);

                    if (id != 0)
                    {
                        formGestaoEstabelecimentosReparticoesAdicionar alterar;
                        Reparticao reparticao = Reparticoes.Where(x => x.ID_Reparticao == id).FirstOrDefault();

                        if (id_estabelecimento == 0)
                        {
                            alterar = new formGestaoEstabelecimentosReparticoesAdicionar(0, reparticao);
                        }
                        else
                        {
                            alterar = new formGestaoEstabelecimentosReparticoesAdicionar(id_estabelecimento, reparticao);
                        }

                        alterar.ShowDialog();
                        AtualizarDataGrid();
                    }
                }
                catch { }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar a repartição?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarReparticao(id);
                    AtualizarDataGrid();
                }
            }
        }

        private void colaboradoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                formGestaoEstabelecimentosReparticoesColaboradores colaboradores = new formGestaoEstabelecimentosReparticoesColaboradores(id);
                colaboradores.ShowDialog();
            }
        }

        private void atividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                formGestaoEstabelecimentosReparticoesAtividades atividades = new formGestaoEstabelecimentosReparticoesAtividades(id);
                atividades.ShowDialog();
            }            
        }

        private void dataGridViewLista_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[e.RowIndex].Cells[0];
            }
            catch { }
        }

        private void abastecimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {

            }
        }
    }
}
