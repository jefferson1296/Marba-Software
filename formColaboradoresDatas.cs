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
    public partial class formColaboradoresDatas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Data> Datas = new List<Data>();
        public bool alteracao;

        public formColaboradoresDatas()
        {
            InitializeComponent();
        }

        private void formTelaInicialEscalaDatas_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void buttonDatas_Click(object sender, EventArgs e)
        {
            formColaboradoresDatasCadastrar cadastrar = new formColaboradoresDatasCadastrar(this);
            cadastrar.ShowDialog();
            if (alteracao)
            {
                AtualizarDataGrid();
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

            Datas = comandos.ListaDeFeriados();
            dataGridViewLista.Rows.Clear();

            foreach (Data Data in Datas)
            {
                dataGridViewLista.Rows.Add(Data.ID_Data, Data.Descricao, Data.Dia, Data.Loja);
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

        private void buttonAno_Click(object sender, EventArgs e)
        {
            formColaboradoresEscalaDatasDefinir ano = new formColaboradoresEscalaDatasDefinir();
            ano.ShowDialog();
        }
    }
}
