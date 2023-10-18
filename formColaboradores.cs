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
    public partial class formColaboradores : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Colaborador> Colaboradores = new List<Colaborador>();
        public bool alteracao;
        int id;
        string matricula;
        string colaborador;

        public formColaboradores()
        {
            InitializeComponent();
        }

        private void formColaboradores_Load(object sender, EventArgs e)
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

            bool inativos = checkBoxInativo.Checked;

            Colaboradores = comandos.ListaDeColaboradores(inativos);

            foreach (Colaborador Colaborador in Colaboradores)
            {
                dataGridViewLista.Rows.Add(Colaborador.ID_Colaborador, Colaborador.Nome_Colaborador, Colaborador.Cargo, Colaborador.Setor, Colaborador.Matricula);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (inativos)
            {
                foreach (DataGridViewRow Linha in dataGridViewLista.Rows)
                {
                    int id = Convert.ToInt32(dataGridViewLista.Rows[Linha.Index].Cells[0].Value);
                    bool ativacao = Colaboradores.Where(x => x.ID_Colaborador == id).Select(x => x.Ativacao).FirstOrDefault();

                    Font minhafonte = new Font("Arial", 10, FontStyle.Strikeout, GraphicsUnit.Point);

                    if (!ativacao)
                    {
                        DataGridViewRow linhaestilizada = dataGridViewLista.Rows[Linha.Index];
                        linhaestilizada.DefaultCellStyle.Font = minhafonte;
                        linhaestilizada.DefaultCellStyle.ForeColor = Color.DimGray;
                        linhaestilizada.DefaultCellStyle.SelectionForeColor = Color.DimGray;
                    }
                }
            }
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            formColaboradoresEditar cadastrar = new formColaboradoresEditar(this);
            cadastrar.ShowDialog();
            if (alteracao)
            {
                alteracao = false;
                AtualizarDataGrid();
            }
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                formColaboradoresEditar editar = new formColaboradoresEditar(this, id);
                editar.ShowDialog();

                if (alteracao)
                {
                    alteracao = false;
                    AtualizarDataGrid();
                }
            }
            catch
            {

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

                        id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                        colaborador = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();
                        matricula = dataGridViewLista.Rows[e.RowIndex].Cells[4].Value.ToString();

                        bool ativacao = Colaboradores.Where(x => x.ID_Colaborador == id).Select(x => x.Ativacao).FirstOrDefault();

                        if (ativacao) { demitirToolStripMenuItem.Enabled = true; }
                        else { demitirToolStripMenuItem.Enabled = false; }
                    }
                    else
                    {
                        id = 0;
                    }
                }
                catch { }
            }
        }

        private void imprimirHorárioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void permissõesDeAcessoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                formColaboradoresPermissoes permissoes = new formColaboradoresPermissoes(id, colaborador, matricula);
                permissoes.ShowDialog();
            }
        }

        private void buttonAcessos_Click(object sender, EventArgs e)
        {
            formColaboradoresAcessos acessos = new formColaboradoresAcessos();
            acessos.ShowDialog();
        }

        private void buttonTurnos_Click(object sender, EventArgs e)
        {
            formColaboradoresTurnos turnos = new formColaboradoresTurnos();
            turnos.ShowDialog();
        }

        private void buttonFeriados_Click(object sender, EventArgs e)
        {
            formColaboradoresDatas datas = new formColaboradoresDatas();
            datas.ShowDialog();
        }

        private void buttonLicencas_Click(object sender, EventArgs e)
        {
            formColaboradoresLicencas licencas = new formColaboradoresLicencas();
            licencas.ShowDialog();
        }

        private void labelDigital_Click(object sender, EventArgs e)
        {
            formCadastrarDigital digital = new formCadastrarDigital();
            digital.ShowDialog();
        }

        private void checkBoxInativo_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void demitirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("A demissão implica em custos adicionais e demandas de desligamento.\r\nTem certeza que deseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.AlterarAtivacaoDoColaborador(id, false);
                    AtualizarDataGrid();
                }
            }
        }

        private void pontoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                formColaboradoresFolhaDePonto ponto = new formColaboradoresFolhaDePonto(id);
                ponto.ShowDialog();
            }
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                int ano = DateTime.Now.Year;
                int mes = DateTime.Now.Month;

                int dias = DateTime.DaysInMonth(ano, mes);

                DateTime inicio = new DateTime(ano, mes, 1);
                DateTime termino = new DateTime(ano, mes, dias);

                comandos.ImprimirHorariosDoExpediente(id, inicio, termino, true);
            }
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                int ano = DateTime.Now.Year;
                int mes = DateTime.Now.Month;

                int dias = DateTime.DaysInMonth(ano, mes);

                DateTime inicio = new DateTime(ano, mes, 1);
                DateTime termino = new DateTime(ano, mes, dias);

                comandos.ImprimirHorariosDoExpediente(id, inicio, termino, false);
            }
        }

        private void buttonExportar_Click(object sender, EventArgs e)
        {
            formColaboradoresImprimirHorario horarios = new formColaboradoresImprimirHorario(Colaboradores);
            horarios.ShowDialog();
        }

        private void definirEscalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                formColaboradoresEscala permissoes = new formColaboradoresEscala(id, colaborador);
                permissoes.ShowDialog();
            }
        }

        private void definirTurnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                formColaboradoresAlternarTurnos permissoes = new formColaboradoresAlternarTurnos();
                permissoes.ShowDialog();
            }
        }

        private void imprimirEscalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Colaborador> colaboradores = new List<Colaborador>();
            int id;

            foreach (DataGridViewRow linha in dataGridViewLista.SelectedRows)
            {
                id = Convert.ToInt32(dataGridViewLista[0, linha.Index].Value);
                colaboradores.Add(Colaboradores.Where(x => x.ID_Colaborador == id).FirstOrDefault());
            }

            if (colaboradores.Count > 0)
            {
                formColaboradoresImprimirHorario horarios = new formColaboradoresImprimirHorario(colaboradores);
                horarios.ShowDialog();
            }
        }
    }
}
