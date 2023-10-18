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
    public partial class formColaboradoresPermissoes : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Acesso> Acessos = new List<Acesso>();
        List<int> Permissoes = new List<int>();

        int id_colaborador;
        string colaborador;
        string matricula;

        public formColaboradoresPermissoes()
        {
            InitializeComponent();
        }
        public formColaboradoresPermissoes(int ID, string Colaborador, string Matricula)
        {
            InitializeComponent();
            id_colaborador = ID;
            matricula = Matricula;
            colaborador = Colaborador;
        }

        private void formColaboradoresPermissoes_Load(object sender, EventArgs e)
        {
            Acessos = comandos.ListaDeAcessos();
            Permissoes = comandos.ListaDeAcessosDoColaborador(id_colaborador);

            textBoxColaborador.Text = colaborador + " (" + matricula + ")";
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

            foreach (Acesso Acesso in Acessos)
            {
                int id = Acesso.ID_Acesso;
                string descricao = Acesso.Descricao;
                bool permissao = Permissoes.Contains(id);

                dataGridViewLista.Rows.Add(id, descricao, permissao);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }



        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            comandos.AlterarAcessosDoColaborador(id_colaborador, Permissoes);
            Dispose();
        }

        private void dataGridViewLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);

                if (Convert.ToBoolean(dataGridViewLista.Rows[e.RowIndex].Cells[2].Value) == true)
                {
                    dataGridViewLista.Rows[e.RowIndex].Cells[2].Value = false;
                    Permissoes.Remove(id);
                }
                else
                {
                    dataGridViewLista.Rows[e.RowIndex].Cells[2].Value = true;
                    Permissoes.Add(id);
                }
            }
        }
    }
}
