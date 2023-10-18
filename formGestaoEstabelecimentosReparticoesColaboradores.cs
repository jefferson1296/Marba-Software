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
    public partial class formGestaoEstabelecimentosReparticoesColaboradores : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        List<Colaborador> colaboradores_da_reparticao = new List<Colaborador>();
        int id_reparticao;
        int id_colaborador;

        public formGestaoEstabelecimentosReparticoesColaboradores()
        {
            InitializeComponent();
        }

        public formGestaoEstabelecimentosReparticoesColaboradores(int ID_Reparticao)
        {
            InitializeComponent();
            id_reparticao = ID_Reparticao;
        }

        private void formGestaoEstabelecimentosReparticoesColaboradores_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
            AtualizarComboBox();
        }

        private void AtualizarComboBox()
        {
            colaboradorComboBox.AutoCompleteCustomSource = null;
            colaboradorComboBox.DataSource = null;

            List<Colaborador> colaboradores_sugeridos = comandos.PreencherComboColaboradoresParaReparticao(); ;

            AutoCompleteStringCollection sugestao = new AutoCompleteStringCollection();

            foreach (Colaborador colaborador in colaboradores_sugeridos)
            {
                sugestao.Add(colaborador.Nome_Colaborador);
            }

            colaboradorComboBox.AutoCompleteCustomSource = sugestao;

            colaboradorComboBox.ValueMember = "ID_Colaborador";
            colaboradorComboBox.DisplayMember = "Nome_Colaborador";
            colaboradorComboBox.DataSource = colaboradores_sugeridos;
            colaboradorComboBox.SelectedIndex = -1;
        }

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }


            colaboradores_da_reparticao = comandos.ListaDeColaboradoresPorReparticao(id_reparticao);            

            dataGridViewLista.Rows.Clear();

            foreach (Colaborador colaborador in colaboradores_da_reparticao)
            {
                dataGridViewLista.Rows.Add(colaborador.ID_Colaborador, colaborador.Nome_Colaborador, colaborador.Matricula);
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
            string colaborador = colaboradorComboBox.Text;

            if (colaborador == string.Empty)
            {
                MessageBox.Show("Informe o colaborador para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id_colaborador = (int)colaboradorComboBox.SelectedValue;
                comandos.AtribuirColaboradorAReparticao(id_colaborador, id_reparticao);

                AtualizarDataGrid();
                AtualizarComboBox();
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

                        id_colaborador = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    }
                    else
                    {
                        id_colaborador = 0;
                    }
                }
                catch { }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_colaborador != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja retirar o colaborador dessa repartição?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.RemoverColaboradorDaReparticao(id_colaborador, id_reparticao);
                    AtualizarDataGrid();
                    AtualizarComboBox();
                }
            }
        }

        private void dataGridViewLista_MouseLeave(object sender, EventArgs e)
        {
            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }

        private void dataGridViewLista_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[e.RowIndex].Cells[0];
            }
            catch { }
        }
    }
}
