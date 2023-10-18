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
    public partial class formTelaInicialAtividadesLancamentos : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        AtividadeLancada lancada = new AtividadeLancada();

        List<AtividadeDelegada> atividades_delegadas = new List<AtividadeDelegada>();
        List<AtividadeStatus> lista_status = new List<AtividadeStatus>();
        int id;

        public formTelaInicialAtividadesLancamentos()
        {
            InitializeComponent();
        }

        public formTelaInicialAtividadesLancamentos(AtividadeLancada Lancada)
        {
            InitializeComponent();
            lancada = Lancada;
        }

        private void formTelaInicialAtividadesLancamentos_Load(object sender, EventArgs e)
        {
            textBoxID.Text = lancada.ID_AtividadeLancada.ToString();
            textBoxAtividade.Text = lancada.Descricao;
            textBoxStatus.Text = lancada.Status;

            AtualizarDataGridColaboradores();
            AtualizarDataGridLancamentos();
        }

        private void AtualizarDataGridColaboradores()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewColaboradores.CurrentRow != null)
            {
                primeira_linha = dataGridViewColaboradores.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewColaboradores.CurrentRow.Index;
            }

            dataGridViewColaboradores.Rows.Clear();
            atividades_delegadas = comandos.ListaDeAtividadesDelegadas(lancada.ID_AtividadeLancada);

            foreach (AtividadeDelegada atividade in atividades_delegadas)
            {
                dataGridViewColaboradores.Rows.Add(atividade.ID_AtividadeDelegada, atividade.Responsavel, atividade.Status);
            }

            try
            {
                dataGridViewColaboradores.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewColaboradores.CurrentCell = dataGridViewColaboradores.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewColaboradores.CurrentRow != null)
                dataGridViewColaboradores.CurrentRow.Selected = false;
        }

        private void AtualizarDataGridLancamentos()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            dataGridViewLista.Rows.Clear();
            lista_status = comandos.ListaDeStatusDaAtividade(lancada.ID_AtividadeLancada);

            foreach (AtividadeStatus status in lista_status)
            {
                dataGridViewLista.Rows.Add(status.ID_AtividadeLancada, status.Inicio, status.Termino, status.Responsavel, status.Status, status.Lancamento);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;

            textBoxStatus.Text = comandos.StatusDaAtividade(lancada.ID_AtividadeLancada);
        }

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridViewColaboradores_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    try
                    {
                        id = Convert.ToInt32(dataGridViewColaboradores.Rows[e.RowIndex].Cells[0].Value);
                        string status = dataGridViewColaboradores.Rows[e.RowIndex].Cells[2].Value.ToString();

                        if (status == "Em aberto")
                        {
                            iniciarToolStripMenuItem.Visible = false;
                            concluirToolStripMenuItem.Visible = false;
                            pausarToolStripMenuItem.Visible = false;
                            retomarToolStripMenuItem.Visible = false;
                            cancelarToolStripMenuItem.Visible = true;
                        }
                        if (status == "Pendente")
                        {
                            iniciarToolStripMenuItem.Visible = true;
                            concluirToolStripMenuItem.Visible = false;
                            pausarToolStripMenuItem.Visible = false;
                            retomarToolStripMenuItem.Visible = false;
                            cancelarToolStripMenuItem.Visible = true;
                        }
                        else if (status == "Em andamento")
                        {
                            iniciarToolStripMenuItem.Visible = false;
                            concluirToolStripMenuItem.Visible = true;
                            pausarToolStripMenuItem.Visible = true;
                            retomarToolStripMenuItem.Visible = false;
                            cancelarToolStripMenuItem.Visible = true;
                        }
                        else if (status == "Pausado")
                        {
                            iniciarToolStripMenuItem.Visible = false;
                            concluirToolStripMenuItem.Visible = true;
                            pausarToolStripMenuItem.Visible = false;
                            retomarToolStripMenuItem.Visible = true;
                            cancelarToolStripMenuItem.Visible = true;
                        }
                        else if (status == "Concluído")
                        {
                            iniciarToolStripMenuItem.Visible = false;
                            concluirToolStripMenuItem.Visible = false;
                            pausarToolStripMenuItem.Visible = false;
                            retomarToolStripMenuItem.Visible = false;
                            cancelarToolStripMenuItem.Visible = false;
                        }
                        else if (status == "Cancelado")
                        {
                            iniciarToolStripMenuItem.Visible = false;
                            concluirToolStripMenuItem.Visible = false;
                            pausarToolStripMenuItem.Visible = false;
                            retomarToolStripMenuItem.Visible = false;
                            cancelarToolStripMenuItem.Visible = false;
                        }
                    }
                    catch
                    {
                        id = 0;

                        iniciarToolStripMenuItem.Visible = false;
                        concluirToolStripMenuItem.Visible = false;
                        pausarToolStripMenuItem.Visible = false;
                        retomarToolStripMenuItem.Visible = false;
                        cancelarToolStripMenuItem.Visible = false;
                    }
                }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.ApagarAtividadeDelegada(id);
                AtualizarDataGridColaboradores();
                AtualizarDataGridLancamentos();
            }
        }

        private void iniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.IniciarAtividade(id);
                AtualizarDataGridColaboradores();
                AtualizarDataGridLancamentos();
            }
        }

        private void retomarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.IniciarAtividade(id);
                AtualizarDataGridColaboradores();
                AtualizarDataGridLancamentos();
            }
        }

        private void concluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.ConcluirAtividade(id);
                AtualizarDataGridColaboradores();
                AtualizarDataGridLancamentos();
            }
        }

        private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.CancelarAtividade(id);
                AtualizarDataGridColaboradores();
                AtualizarDataGridLancamentos();
            }
        }

        private void pausarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.PausarAtividade(id);
                AtualizarDataGridColaboradores();
                AtualizarDataGridLancamentos();
            }
        }

        private void pictureBoxDelegar_Click(object sender, EventArgs e)
        {
            if (lancada.Responsaveis != "Sem lançamentos")
            {
                if (DialogResult.Yes == MessageBox.Show("Essa atividade já foi empenhada. Deseja delegá-la novamente?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    formTelaInicialAtividadesDelegar delegar = new formTelaInicialAtividadesDelegar(lancada);
                    delegar.ShowDialog();
                    AtualizarDataGridColaboradores();
                    AtualizarDataGridLancamentos();
                }
            }
            else
            {
                formTelaInicialAtividadesDelegar delegar = new formTelaInicialAtividadesDelegar(lancada);
                delegar.ShowDialog();
                AtualizarDataGridColaboradores();
                AtualizarDataGridLancamentos();
            }
        }
    }
}
