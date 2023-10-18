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
    public partial class formGestaoCursosAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Materia> disponiveis = new List<Materia>();
        List<Materia> relacionadas = new List<Materia>();

        bool cadastramento;

        int id_curso;
        Curso curso = new Curso();

        int ordem;

        bool arrastar;
        bool permissao;

        Materia materia = new Materia();

        public formGestaoCursosAdicionar()
        {
            InitializeComponent();
            cadastramento = true;
        }

        public formGestaoCursosAdicionar(int ID_Curso)
        {
            InitializeComponent();
            cadastramento = false;
            id_curso = ID_Curso;
        }

        private void formGestaoTreinamentosAdicionar_Load(object sender, EventArgs e)
        {
            List<string> Cargos = comandos.preencherComboCargos();
            comboBoxCargo.DataSource = Cargos;
            comboBoxCargo.SelectedIndex = -1;
            comboBoxCargo.DropDownHeight = 150;

            List<Sessao> sessoes = comandos.ListaDeSessoes();

            ColumnSessao.ValueMember = "Descricao";
            ColumnSessao.DisplayMember = "Descricao";
            ColumnSessao.DataSource = sessoes;

            ColumnSessao.DropDownWidth = 230;

            if (!cadastramento)
            {
                curso = comandos.TrazerInformacoesDoCurso(id_curso);
                textBoxCurso.Text = curso.Descricao;
                comboBoxCargo.Enabled = false;
                comboBoxCargo.SelectedItem = curso.Cargo;
                comboBoxNivel.SelectedItem = curso.Nivel;
                AtualizarListaDeMateriasDisponiveis();
                AtualizarListaDeMateriasRelacionadas();
            }
            else
            {
                comboBoxNivel.SelectedIndex = 0;
            }

            foreach (DataGridViewColumn coluna in dataGridViewRelacionadas.Columns)
            {
                if (coluna.Index == 0 || coluna.Index == 1 || coluna.Index == 2)
                {
                    coluna.ReadOnly = true;
                }
            }

            permissao = true;
        }

        private void comboBoxCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cadastramento)
            {
                disponiveis.Clear();
                relacionadas.Clear();

                string cargo = comboBoxCargo.Text;

                if (cargo == string.Empty)
                {
                    disponiveis = comandos.MateriasDisponiveisParaCursoGenerico();
                }
                else
                {
                    disponiveis = comandos.MateriasDisponiveis(cargo);
                }

                AtualizarListaDeMateriasDisponiveis();
            }
        }

        private void AtualizarListaDeMateriasDisponiveis()
        {
            int linha_selecionada = 0, primeira_linha = 0;

            if (dataGridViewRelacionadas.CurrentRow != null)
            {
                primeira_linha = dataGridViewRelacionadas.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewRelacionadas.CurrentRow.Index;
            }

            dataGridViewDisponiveis.Rows.Clear();

            if (!cadastramento)
            {
                string cargo = comboBoxCargo.Text;

                if (cargo == string.Empty)
                {
                    disponiveis = comandos.MateriasDisponiveisParaCursoGenerico();
                }
                else
                {
                    disponiveis = comandos.MateriasDisponiveis(cargo);
                }
            }

            foreach (Materia materia in disponiveis)
            {
                dataGridViewDisponiveis.Rows.Add(materia.Descricao, materia.Tipo);
            }

            try
            {
                dataGridViewRelacionadas.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewRelacionadas.CurrentCell = dataGridViewRelacionadas.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewRelacionadas.CurrentRow != null)
                dataGridViewRelacionadas.CurrentRow.Selected = false;
        }

        private void AtualizarListaDeMateriasRelacionadas()
        {
            int linha_selecionada = 0, primeira_linha = 0;

            if (dataGridViewRelacionadas.CurrentRow != null)
            {
                primeira_linha = dataGridViewRelacionadas.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewRelacionadas.CurrentRow.Index;
            }

            if (cadastramento)
            {
                if (relacionadas.Count > 0) { comboBoxCargo.Enabled = false; } else { comboBoxCargo.Enabled = true; }
                relacionadas = relacionadas.OrderBy(x => x.Ordem).ToList();
            }


            dataGridViewRelacionadas.Rows.Clear();

            if (!cadastramento)
            {
                relacionadas = comandos.MateriasAtreladasAoCurso(curso.ID_Curso);
            }

            foreach (Materia materia in relacionadas)
            {
                dataGridViewRelacionadas.Rows.Add(materia.Ordem, materia.Descricao, materia.Tipo, materia.Sessao, materia.Horas.ToString("F"));
            }

            try
            {
                dataGridViewRelacionadas.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewRelacionadas.CurrentCell = dataGridViewRelacionadas.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewRelacionadas.CurrentRow != null)
                dataGridViewRelacionadas.CurrentRow.Selected = false;

            AtualizarInformacoes();
        }

        private void AtualizarInformacoes()
        {
            int materias = relacionadas.Count;
            decimal horas = relacionadas.Sum(x => x.Horas);

            textBoxMaterias.Text = materias.ToString();
            textBoxHoras.Text = horas.ToString("F");
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

                    materia.Descricao = dataGridViewDisponiveis.Rows[e.RowIndex].Cells[0].Value.ToString();
                    materia.Tipo = dataGridViewDisponiveis.Rows[e.RowIndex].Cells[1].Value.ToString();
                    materia.Sessao = "FORMATO DE PALESTRA";
                    materia.Ordem = relacionadas.Count + 1;
                    materia.Horas = 1;

                    label.DoDragDrop(materia.Descricao, DragDropEffects.Copy);
                    arrastar = false;
                }
            }
            catch { }
        }

        private void dataGridViewRelacionadas_DragDrop(object sender, DragEventArgs e)
        {
            if (!cadastramento)
            {
                comandos.AdicionarMateriaAoCurso(materia, curso.ID_Curso);
            }
            else
            {
                Materia nova_materia = new Materia { Descricao = materia.Descricao, Tipo = materia.Tipo, Horas = materia.Horas, Sessao = materia.Sessao, Ordem = materia.Ordem };
                relacionadas.Add(nova_materia);
            }

            AtualizarListaDeMateriasRelacionadas();
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
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridViewRelacionadas.CurrentCell = dataGridViewRelacionadas.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dataGridViewRelacionadas.Rows[e.RowIndex].Selected = true;
                    dataGridViewRelacionadas.Focus();
                    ordem = Convert.ToInt32(dataGridViewRelacionadas.Rows[e.RowIndex].Cells[0].Value);
                }
                else
                {
                    ordem = 0;
                }
            }
            catch { }
        }

        private void dataGridViewRelacionadas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            //try
            //{
            //    dataGridViewRelacionadas.CurrentCell = dataGridViewRelacionadas.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //}
            //catch { }

            //try
            //{
            //    if (arrastar)
            //    {
            //        Label label = new Label();
            //        materia.Descricao = dataGridViewRelacionadas.Rows[e.RowIndex].Cells[0].Value.ToString();
            //        materia.Tipo = dataGridViewRelacionadas.Rows[e.RowIndex].Cells[1].Value.ToString();

            //        label.DoDragDrop(materia.Descricao, DragDropEffects.Copy);
            //        arrastar = false;
            //    }
            //}
            //catch { }
        }

        private void dataGridViewDisponiveis_DragDrop(object sender, DragEventArgs e)
        {
            //if (relacionadas.Any(x => x.Descricao == materia.Descricao && x.Tipo == materia.Tipo))
            //{

            //}
        }

        private void dataGridViewDisponiveis_DragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.Text))
            //{
            //    e.Effect = DragDropEffects.Copy;
            //}
            //else
            //{
            //    e.Effect = DragDropEffects.None;
            //}
        }

        private void dataGridViewRelacionadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                //materia.Descricao = dataGridViewRelacionadas.Rows[0].Cells[0].Value.ToString();
                //materia.Tipo = dataGridViewRelacionadas.Rows[0].Cells[1].Value.ToString();
            }
        }

        private void dataGridViewRelacionadas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (permissao)
            {
                if (e.ColumnIndex == 3)
                {
                    Materia Materia = new Materia();
                    Materia.Descricao = dataGridViewRelacionadas.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Materia.Tipo = dataGridViewRelacionadas.Rows[e.RowIndex].Cells[2].Value.ToString();

                    Materia.Sessao = dataGridViewRelacionadas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(); 

                    if (cadastramento)
                    {
                        foreach (Materia materia in relacionadas)
                        {
                            if (materia.Descricao == Materia.Descricao && materia.Tipo == Materia.Tipo)
                            {
                                materia.Sessao = Materia.Sessao;
                                break;
                            }
                        }
                    }
                    else
                    {
                        comandos.AlterarSessaoDaMateria(Materia);
                    }
                }
                if (e.ColumnIndex == 4)
                {
                    Materia Materia = new Materia();
                    Materia.Descricao = dataGridViewRelacionadas.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Materia.Tipo = dataGridViewRelacionadas.Rows[e.RowIndex].Cells[2].Value.ToString();

                    try { Materia.Horas = Convert.ToDecimal(dataGridViewRelacionadas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value); }
                    catch { Materia.Horas = 0; }

                    if (cadastramento)
                    {
                        foreach (Materia materia in relacionadas)
                        {
                            if (materia.Descricao == Materia.Descricao && materia.Tipo == Materia.Tipo)
                            {
                                materia.Horas = Materia.Horas;
                                break;
                            }
                        }
                    }
                    else
                    {
                        comandos.AlterarHorasDaMateria(Materia);
                    }
                }

                AtualizarInformacoes();
            }
        }

        private void dataGridViewRelacionadas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewRelacionadas.IsCurrentCellDirty)
            {
                dataGridViewRelacionadas.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string descricao = textBoxCurso.Text;
            string cargo = comboBoxCargo.Text;
            string nivel = comboBoxNivel.Text;

            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe a descrição do curso para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                curso.Descricao = descricao;
                curso.Cargo = cargo;
                curso.Nivel = nivel;

                if (cadastramento)
                {
                    comandos.CadastrarCurso(curso);
                    comandos.CadastrarMateriasDoCurso(relacionadas);
                }
                else
                {
                    comandos.EditarCurso(curso);
                }

                Dispose();
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ordem != 0)
            {
                materia = relacionadas.Where(x => x.Ordem == ordem).FirstOrDefault();

                if (!cadastramento)
                {
                    comandos.RemoverMateriaDoCurso(materia, curso.ID_Curso);

                    int i = 1;
                    int ordem = 0;

                    foreach (Materia materia in relacionadas)
                    {
                        if (materia.Ordem != this.ordem)
                        {
                            ordem = i;
                            i++;

                            comandos.EditarOrdemDaMateria(materia, id_curso, ordem);
                        }
                    }
                }
                else
                {
                    relacionadas.RemoveAll(x => x.Descricao == materia.Descricao && x.Tipo == materia.Tipo && x.Ordem == ordem);

                    int i = 1;

                    foreach (Materia materia in relacionadas)
                    {
                        materia.Ordem = i;
                        i++;
                    }
                }

                AtualizarListaDeMateriasRelacionadas();
            }
        }

        private void buttonSubir_Click(object sender, EventArgs e)
        {
            if (ordem == 0) { }
            else if (ordem == 1) { }
            else if (relacionadas.Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewRelacionadas.CurrentRow != null)
                {
                    primeira_linha = dataGridViewRelacionadas.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewRelacionadas.CurrentRow.Index;
                }

                string descricao_cima = relacionadas.Where(x => x.Ordem == ordem - 1).Select(i => i.Descricao).FirstOrDefault();
                string tipo_cima = relacionadas.Where(x => x.Ordem == ordem - 1).Select(i => i.Tipo).FirstOrDefault();
                string descricao_baixo = relacionadas.Where(x => x.Ordem == ordem).Select(i => i.Descricao).FirstOrDefault();
                string tipo_baixo = relacionadas.Where(x => x.Ordem == ordem).Select(i => i.Tipo).FirstOrDefault();

                int nova_ordem;

                if (cadastramento)
                {
                    foreach (Materia materia in relacionadas)
                    {
                        if (materia.Descricao == descricao_baixo && materia.Tipo == tipo_baixo && materia.Ordem == ordem)
                        {   
                            materia.Ordem = ordem - 1;
                        }
                        else if (materia.Descricao == descricao_cima && materia.Tipo == tipo_cima && materia.Ordem == ordem - 1)
                        { 
                            materia.Ordem = ordem;
                        }
                    }
                }
                else
                {
                    foreach (Materia materia in relacionadas)
                    {
                        if (materia.Descricao == descricao_baixo && materia.Tipo == tipo_baixo && materia.Ordem == ordem)
                        {
                            nova_ordem = ordem - 1;
                            comandos.AlterarOrdemDaMateria(materia, nova_ordem);
                        }
                        else if (materia.Descricao == descricao_cima && materia.Tipo == tipo_cima && materia.Ordem == ordem - 1)
                        {
                            nova_ordem = ordem;
                            comandos.AlterarOrdemDaMateria(materia, nova_ordem);
                        }
                    }
                }

                AtualizarListaDeMateriasRelacionadas();

                dataGridViewRelacionadas.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewRelacionadas.CurrentCell = dataGridViewRelacionadas.Rows[linha_selecionada - 1].Cells[0];
                ordem = ordem - 1;
            }
        }

        private void buttonDescer_Click(object sender, EventArgs e)
        {
            if (ordem == 0) { }
            else if (ordem == relacionadas.Count) { }
            else if (relacionadas.Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewRelacionadas.CurrentRow != null)
                {
                    primeira_linha = dataGridViewRelacionadas.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewRelacionadas.CurrentRow.Index;
                }

                string descricao_cima = relacionadas.Where(x => x.Ordem == ordem).Select(i => i.Descricao).FirstOrDefault();
                string tipo_cima = relacionadas.Where(x => x.Ordem == ordem).Select(i => i.Tipo).FirstOrDefault();
                string descricao_baixo = relacionadas.Where(x => x.Ordem == ordem + 1).Select(i => i.Descricao).FirstOrDefault();
                string tipo_baixo = relacionadas.Where(x => x.Ordem == ordem + 1).Select(i => i.Tipo).FirstOrDefault();

                int nova_ordem;

                if (cadastramento)
                {
                    foreach (Materia materia in relacionadas)
                    {
                        if (materia.Descricao == descricao_baixo && materia.Tipo == tipo_baixo && materia.Ordem == ordem + 1)
                        {
                            materia.Ordem = ordem;
                        }
                        else if (materia.Descricao == descricao_cima && materia.Tipo == tipo_cima && materia.Ordem == ordem)
                        {
                            materia.Ordem = ordem + 1;
                        }
                    }
                }
                else
                {
                    foreach (Materia materia in relacionadas)
                    {
                        if (materia.Descricao == descricao_baixo && materia.Tipo == tipo_baixo && materia.Ordem == ordem + 1)
                        {
                            nova_ordem = ordem;
                            comandos.AlterarOrdemDaMateria(materia, nova_ordem);
                        }
                        else if (materia.Descricao == descricao_cima && materia.Tipo == tipo_cima && materia.Ordem == ordem)
                        {
                            nova_ordem = ordem + 1;
                            comandos.AlterarOrdemDaMateria(materia, nova_ordem);
                        }
                    }
                }

                AtualizarListaDeMateriasRelacionadas();

                try
                {
                    dataGridViewRelacionadas.FirstDisplayedScrollingRowIndex = primeira_linha;
                    dataGridViewRelacionadas.CurrentCell = dataGridViewRelacionadas.Rows[linha_selecionada + 1].Cells[0];
                }
                catch { }

                ordem = ordem + 1;
            }
        }

    }
}
