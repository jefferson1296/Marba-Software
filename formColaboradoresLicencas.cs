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
    public partial class formColaboradoresLicencas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Licenca> Licencas = new List<Licenca>();
        int id;

        public formColaboradoresLicencas()
        {
            InitializeComponent();
        }

        private void formColaboradoresLicencas_Load(object sender, EventArgs e)
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

            Licencas = comandos.ListaDeLicencas();

            dataGridViewLista.Rows.Clear();

            foreach (Licenca Licenca in Licencas)
            {
                string[] nomes = Licenca.Colaborador.Split(' ');
                int vetores = nomes.Length;
                string colaborador = string.Empty;

                for (int i = 0; i < vetores; i++)
                {
                    string nome;
                    if (nomes[i] == "DA" || nomes[i] == "DE" || nomes[i] == "DO" || nomes[i] == "DOS" || nomes[i] == "DAS")
                    {
                        nome = nomes[i].ToLower();
                    }
                    else
                    {
                        nome = nomes[i].ToLower().PrimeiraLetraMaiuscula();
                    }

                    colaborador = colaborador + " " + nome;
                }

                dataGridViewLista.Rows.Add(Licenca.ID_Licenca, Licenca.Matricula, colaborador, Licenca.Tipo, Licenca.Inicio.ToShortDateString(), Licenca.Termino.ToShortDateString());
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formColaboradoresLicencasAdicionar adicionar = new formColaboradoresLicencasAdicionar();
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

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.ApagarLicenca(id);
            }
        }
    }
}
