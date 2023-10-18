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
    public partial class formColaboradoresAcessos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Acesso> Acessos = new List<Acesso>();
        public formColaboradoresAcessos()
        {
            InitializeComponent();
        }

        private void formColaboradoresAcessos_Load(object sender, EventArgs e)
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

            Acessos = comandos.ListaDeAcessos();

            dataGridViewLista.Rows.Clear();

            foreach (Acesso Acesso in Acessos)
            {
                int id = Acesso.ID_Acesso;
                string descricao = Acesso.Descricao;


                dataGridViewLista.Rows.Add(id, descricao, Acesso.Categoria);
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
            formColaboradoresAcessosAdicionar adicionar = new formColaboradoresAcessosAdicionar();
            adicionar.ShowDialog();
            AtualizarDataGrid();
        }
    }
}
