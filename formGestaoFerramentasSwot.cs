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
    public partial class formGestaoFerramentasSwot : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<SWOT> matriz_swot = new List<SWOT>();
        public formGestaoFerramentasSwot()
        {
            InitializeComponent();
        }

        private void formGestaoFerramentasSwot_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void AtualizarDataGrid()
        {
            int forca_selecionada = 0, primeira_forca = 0;
            int fraqueza_selecionada = 0, primeira_fraqueza = 0;
            int oportunidade_selecionada = 0, primeira_oportunidade = 0;
            int ameaca_selecionada = 0, primeira_ameaca = 0;

            if (dataGridViewForcas.CurrentRow != null)
            {
                primeira_forca = dataGridViewForcas.FirstDisplayedScrollingRowIndex;
                forca_selecionada = dataGridViewForcas.CurrentRow.Index;
            }

            if (dataGridViewFraquezas.CurrentRow != null)
            {
                primeira_fraqueza = dataGridViewFraquezas.FirstDisplayedScrollingRowIndex;
                fraqueza_selecionada = dataGridViewFraquezas.CurrentRow.Index;
            }

            if (dataGridViewOportunidades.CurrentRow != null)
            {
                primeira_oportunidade = dataGridViewOportunidades.FirstDisplayedScrollingRowIndex;
                oportunidade_selecionada = dataGridViewOportunidades.CurrentRow.Index;
            }

            if (dataGridViewAmeacas.CurrentRow != null)
            {
                primeira_ameaca = dataGridViewAmeacas.FirstDisplayedScrollingRowIndex;
                ameaca_selecionada = dataGridViewAmeacas.CurrentRow.Index;
            }

            matriz_swot = comandos.MatrizSwot();

            dataGridViewForcas.Rows.Clear();
            dataGridViewFraquezas.Rows.Clear();
            dataGridViewOportunidades.Rows.Clear();
            dataGridViewAmeacas.Rows.Clear();

            foreach (SWOT swot in matriz_swot)
            {
                if (swot.Categoria == "Força")
                {
                    dataGridViewForcas.Rows.Add(swot.Descricao);
                }
                else if (swot.Categoria == "Fraqueza")
                {
                    dataGridViewFraquezas.Rows.Add(swot.Descricao);
                }
                else if(swot.Categoria == "Oportunidade")
                {
                    dataGridViewOportunidades.Rows.Add(swot.Descricao);
                }
                else if(swot.Categoria == "Ameaça")
                {
                    dataGridViewAmeacas.Rows.Add(swot.Descricao);
                }
            }

            try
            {
                dataGridViewForcas.FirstDisplayedScrollingRowIndex = primeira_forca;
                dataGridViewForcas.CurrentCell = dataGridViewForcas.Rows[forca_selecionada].Cells[0];
            }
            catch { }

            try
            {
                dataGridViewFraquezas.FirstDisplayedScrollingRowIndex = primeira_fraqueza;
                dataGridViewFraquezas.CurrentCell = dataGridViewForcas.Rows[fraqueza_selecionada].Cells[0];
            }
            catch { }

            try
            {
                dataGridViewOportunidades.FirstDisplayedScrollingRowIndex = primeira_oportunidade;
                dataGridViewOportunidades.CurrentCell = dataGridViewForcas.Rows[oportunidade_selecionada].Cells[0];
            }
            catch { }

            try
            {
                dataGridViewAmeacas.FirstDisplayedScrollingRowIndex = primeira_ameaca;
                dataGridViewAmeacas.CurrentCell = dataGridViewForcas.Rows[ameaca_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewForcas.CurrentRow != null)
                dataGridViewForcas.CurrentRow.Selected = false;

            if (dataGridViewFraquezas.CurrentRow != null)
                dataGridViewFraquezas.CurrentRow.Selected = false;

            if (dataGridViewOportunidades.CurrentRow != null)
                dataGridViewOportunidades.CurrentRow.Selected = false;

            if (dataGridViewAmeacas.CurrentRow != null)
                dataGridViewAmeacas.CurrentRow.Selected = false;
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formGestaoFerramentasSwotAdicionar adicionar = new formGestaoFerramentasSwotAdicionar();
            adicionar.ShowDialog();
            AtualizarDataGrid();
        }
    }
}
