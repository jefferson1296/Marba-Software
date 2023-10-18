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
    public partial class formColaboradoresDefinirFeriados : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public List<Data> Feriados = new List<Data>();
        public bool alteracao;
        int ano;

        public formColaboradoresDefinirFeriados()
        {
            InitializeComponent();
        }

        public formColaboradoresDefinirFeriados(int Ano)
        {
            InitializeComponent();
            ano = Ano;
        }

        private void formTelaInicialDefinirFeriados_Load(object sender, EventArgs e)
        {
            labelAno.Text = ano.ToString();
            Feriados = comandos.FeriadosQueFaltamDefinir(ano);
            AtualizarDataGrid();

            if (ano == DateTime.Now.Year)
            {
                MessageBox.Show("Alguns feriados desse ano (" + ano + ") ainda não foram definidos. Defina-os para garantir o pleno funcionamento do sistema.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (ano == DateTime.Now.AddYears(1).Year)
            {
                MessageBox.Show("Alguns feriados do próximo ano (" + ano + ") ainda não foram definidos. Defina-os para garantir o pleno funcionamento do sistema.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

            foreach (Data Data in Feriados)
            {
                string dia;
                if (Data.Dia == "") { dia = string.Empty; }
                else { dia = Convert.ToDateTime(Data.Dia).ToShortDateString().Substring(0, 5); }

                dataGridViewLista.Rows.Add(Data.ID_Data, dia, Data.Descricao, Data.Loja, Data.Tipo);
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

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                Data Feriado = Feriados.Where(x => x.ID_Data == id).FirstOrDefault();

                formColaboradoresDefinirFeriadosEditar editar = new formColaboradoresDefinirFeriadosEditar(Feriado, ano, this);
                editar.ShowDialog();
                AtualizarDataGrid();
            }
            catch { }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            int editados = Feriados.Where(x => x.Dia != string.Empty).Count();

            if (editados == 0)
            {
                MessageBox.Show("Nenhum registro teve sua data definida. Defina as datas de cada feriado para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                comandos.DefinirFeriados(Feriados, ano);
                Dispose();
            }
        }
    }
}
