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
    public partial class formGestaoEstabelecimentosReparticoesAtividades : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        int id_reparticao;

        string atividade;
        string colaborador;

        bool arrastar;
        bool permissao;

        List<string> relacionadas = new List<string>();
        List<string> disponiveis = new List<string>();

        public formGestaoEstabelecimentosReparticoesAtividades()
        {
            InitializeComponent();
        }

        public formGestaoEstabelecimentosReparticoesAtividades(int ID_Reparticao)
        {
            InitializeComponent();
            id_reparticao = ID_Reparticao;
        }

        private void formGestaoEstabelecimentosReparticoesAtividades_Load(object sender, EventArgs e)
        {
            Colaborador colaborador = new Colaborador { Nome_Colaborador = string.Empty };

            List<Colaborador> colaboradores = new List<Colaborador>();

            colaboradores.Add(colaborador);
            colaboradores.AddRange(comandos.ListaDeColaboradoresPorReparticaoComMatricula(id_reparticao));

            ColumnColaborador.ValueMember = "Nome_Colaborador";
            ColumnColaborador.DisplayMember = "Nome_Colaborador";
            ColumnColaborador.DataSource = colaboradores;

            AtualizarListas();
            permissao = true;

            foreach (DataGridViewColumn coluna in dataGridViewRelacionadas.Columns)
            {
                if (coluna.Index != 1)
                {
                    coluna.ReadOnly = true;
                }
            }
        }

        private void AtualizarListas()
        {
            dataGridViewDisponiveis.Rows.Clear();
            dataGridViewRelacionadas.Rows.Clear();

            this.relacionadas.Clear();
            this.disponiveis.Clear();

            List<string> disponiveis = comandos.AtividadesDisponiveisParaReparticao(id_reparticao);
            List<Atividade> relacionadas = comandos.AtividadesAtreladasAReparticao(id_reparticao);

            foreach (string atividade in disponiveis)
            {
                dataGridViewDisponiveis.Rows.Add(atividade);
                this.disponiveis.Add(atividade);
            }

            foreach (Atividade atividade in relacionadas)
            {
                dataGridViewRelacionadas.Rows.Add(atividade.Descricao, atividade.Nome_Colaborador);
                this.relacionadas.Add(atividade.Descricao);
            }
        }

        private void dataGridViewDisponiveis_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            arrastar = true;
        }

        private void dataGridViewDisponiveis_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                dataGridViewDisponiveis.CurrentCell = dataGridViewDisponiveis.Rows[e.RowIndex].Cells[0];
            }
            catch { }

            try
            {
                if (arrastar)
                {
                    Label label = new Label();
                    atividade = dataGridViewDisponiveis.Rows[e.RowIndex].Cells[0].Value.ToString();
                    label.DoDragDrop(atividade, DragDropEffects.Copy);
                    arrastar = false;
                }
            }
            catch { }
        }

        private void dataGridViewRelacionadas_DragDrop(object sender, DragEventArgs e)
        {
            if (!relacionadas.Contains(atividade))
            {
                comandos.AdicionarVinculoEntreAtividadeEReparticao(id_reparticao, atividade);
                
                if (comandos.VerificarSeAtividadeERotina(atividade))
                {
                    comandos.AdicionarInformacoesDaRotina(atividade, id_reparticao);
                }

                AtualizarListas();
            }
        }

        private void dataGridViewRelacionadas_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dataGridViewRelacionadas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    arrastar = true;
                }
                else
                {
                    try
                    {
                        atividade = dataGridViewRelacionadas.Rows[e.RowIndex].Cells[0].Value.ToString();
                        bool rotina = comandos.VerificarSeAtividadeERotina(atividade);

                        if (rotina)
                        {
                            intervalosToolStripMenuItem.Enabled = true;     
                        }
                        else
                        {
                            intervalosToolStripMenuItem.Enabled = false;
                        }
                    }
                    catch
                    {
                        atividade = string.Empty;
                    }
                }
            }
        }

        private void dataGridViewRelacionadas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                dataGridViewRelacionadas.CurrentCell = dataGridViewRelacionadas.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
            catch { }

            try
            {
                if (arrastar)
                {
                    Label label = new Label();
                    atividade = dataGridViewRelacionadas.Rows[e.RowIndex].Cells[0].Value.ToString();
                    label.DoDragDrop(atividade, DragDropEffects.Copy);
                    arrastar = false;
                }
            }
            catch { }
        }

        private void dataGridViewDisponiveis_DragDrop(object sender, DragEventArgs e)
        {
            if (!disponiveis.Contains(atividade))
            {
                comandos.RemoverVinculoEntreAtividadeEReparticao(id_reparticao, atividade);
                AtualizarListas();
            }
        }

        private void dataGridViewDisponiveis_DragEnter(object sender, DragEventArgs e)
        {            
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }


        private void dataGridViewDisponiveis_MouseLeave(object sender, EventArgs e)
        {
            if (dataGridViewDisponiveis.CurrentRow != null)
                dataGridViewDisponiveis.CurrentRow.Selected = false;
        }

        private void dataGridViewRelacionadas_MouseLeave(object sender, EventArgs e)
        {
            if (dataGridViewRelacionadas.CurrentRow != null)
                dataGridViewRelacionadas.CurrentRow.Selected = false;
        }


        private void dataGridViewRelacionadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                try
                {
                    atividade = dataGridViewRelacionadas.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
                catch { }
            }
        }

        private void dataGridViewRelacionadas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (permissao)
            {
                if (e.ColumnIndex == 1)
                {
                    try
                    {
                        atividade = dataGridViewRelacionadas.Rows[e.RowIndex].Cells[0].Value.ToString();
                        try { colaborador = dataGridViewRelacionadas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(); }
                        catch { colaborador = string.Empty; }


                        string[] partir = colaborador.Split('(');
                        string matricula;
                        try { matricula = partir[1].Substring(0, 11); }
                        catch { matricula = string.Empty; }

                        comandos.ColaboradorPadraoDaAtividadeDaReparticao(id_reparticao, atividade, matricula);
                    }
                    catch { }

                }
            }
        }

        private void dataGridViewRelacionadas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewRelacionadas.IsCurrentCellDirty)
            {
                dataGridViewRelacionadas.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void intervalosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (atividade != string.Empty)
            {
                formGestaoEstabelecimentosReparticoesAtividadesIntervalos intervalos = new formGestaoEstabelecimentosReparticoesAtividadesIntervalos(atividade, id_reparticao);
                intervalos.ShowDialog();
            }
        }
    }
}
