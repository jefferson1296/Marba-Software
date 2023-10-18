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
    public partial class formGestaoAfazeres : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public List<Afazer> afazeres = new List<Afazer>();
        int ordem;
        int id_afazer;
        DateTime data;

        public formGestaoAfazeres()
        {
            InitializeComponent();
        }

        private void formTelaInicialPrincipalGestaoAfazeres_Load(object sender, EventArgs e)
        {
            data = dateTimePicker.Value;
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

            afazeres = comandos.ListaDeAfazeres(data);
            dataGridViewLista.Rows.Clear();

            foreach (Afazer afazer in afazeres)
            {
                DateTime tempo = Convert.ToDateTime("00:00");
                tempo = tempo.AddMinutes(afazer.Minutos);

                string Tempo = tempo.ToShortTimeString();
                
                if (Tempo == "00:00") { Tempo = string.Empty; }

                dataGridViewLista.Rows.Add(afazer.Ordem, afazer.Descricao, Tempo, afazer.Conclusao);
            }

            if (afazeres.Count == 0) { labelRegistros.Visible = true; }
            else { labelRegistros.Visible = false; }

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
            formGestaoAfazeresAdicionar adicionar = new formGestaoAfazeresAdicionar(data);
            adicionar.ShowDialog();
            AtualizarDataGrid();
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    ordem = Convert.ToInt32(dataGridViewLista[0, e.RowIndex].Value);
                    id_afazer = afazeres.Where(x => x.Ordem == ordem).Select(x => x.ID_Afazer).FirstOrDefault();
                    formGestaoAfazeresAdicionar editar = new formGestaoAfazeresAdicionar(id_afazer, this);
                    editar.ShowDialog();
                    AtualizarDataGrid();
                }
            }
            catch { }
        }

        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    ordem = Convert.ToInt32(dataGridViewLista[0, e.RowIndex].Value);

                    if (e.ColumnIndex == 3)
                    {
                        bool conclusao = !Convert.ToBoolean(dataGridViewLista[e.ColumnIndex, e.RowIndex].Value);
                        id_afazer = afazeres.Where(x => x.Ordem == ordem).Select(x =>x.ID_Afazer).FirstOrDefault();

                        comandos.AlterarConclusaoDoAfazer(id_afazer, conclusao);

                        if (conclusao)
                        {
                            int id_etapa = comandos.IdDaEtapaRelacionadaAoAfazer(id_afazer);
                            
                            if (id_etapa != 0)
                            {
                                if (DialogResult.Yes == MessageBox.Show("Deseja concluir a etapa relacionada a essa tarefa?", "Etapa do projeto", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                                {
                                    comandos.ConcluirEtapaAPartirDoAfazer(id_etapa);
                                }
                                else if (DialogResult.Yes == MessageBox.Show("Deseja continuar a etapa no próximo dia de trabalho?", "Etapa do projeto", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                                {
                                    comandos.AgendarAfazerParaAmanha(id_afazer);
                                }
                            }
                        }

                        AtualizarDataGrid();
                    }
                }
            }
            catch { }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            data = dateTimePicker.Value;
            AtualizarDataGrid();
        }

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    ordem = Convert.ToInt32(dataGridViewLista[0, e.RowIndex].Value);
                    id_afazer = afazeres.Where(x => x.Ordem == ordem).Select(x => x.ID_Afazer).FirstOrDefault();
                }
            }
            catch 
            {
                ordem = 0;
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ordem != 0)
            {
                this.id_afazer = afazeres.Where(x => x.Ordem == ordem).Select(x => x.ID_Afazer).FirstOrDefault();
                comandos.ApagarAfazer(this.id_afazer);

                int i = ordem;
                int id_afazer;
                int nova_ordem;

                foreach (Afazer afazer in afazeres)
                {
                    if (afazer.Ordem > ordem)
                    {                       
                        nova_ordem = i;
                        i++;
                        id_afazer = afazeres.Where(x => x.Ordem == afazer.Ordem).Select(x => x.ID_Afazer).FirstOrDefault();

                        comandos.AlterarOrdemDoAfazer(id_afazer, nova_ordem);
                    }
                }

                AtualizarDataGrid();
            }
        }

        private void buttonSubir_Click(object sender, EventArgs e)
        {

            if (ordem == 0) { }
            else if (ordem == 1) { }
            else if (afazeres.Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewLista.CurrentRow != null)
                {
                    primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewLista.CurrentRow.Index;
                }

                int nova_ordem;
                int id_afazer;

                foreach (Afazer afazer in afazeres)
                {
                    if (afazer.Ordem == ordem - 1)
                    {
                        id_afazer = afazeres.Where(x => x.Ordem == ordem - 1).Select(x => x.ID_Afazer).FirstOrDefault();
                        nova_ordem = ordem;
                        comandos.AlterarOrdemDoAfazer(id_afazer, nova_ordem);
                    }
                    else if (afazer.Ordem == ordem)
                    {
                        id_afazer = afazeres.Where(x => x.Ordem == ordem).Select(x => x.ID_Afazer).FirstOrDefault();
                        nova_ordem = ordem - 1;
                        comandos.AlterarOrdemDoAfazer(id_afazer, nova_ordem);
                    }
                }

                AtualizarDataGrid();

                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada - 1].Cells[0];
                ordem = ordem - 1;
            }

        }

        private void buttonDescer_Click(object sender, EventArgs e)
        {
            if (ordem == 0) { }
            else if (ordem == afazeres.Count) { }
            else if (afazeres.Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewLista.CurrentRow != null)
                {
                    primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewLista.CurrentRow.Index;
                }

                int id_afazer;
                int nova_ordem;

                foreach (Afazer afazer in afazeres)
                {
                    if (afazer.Ordem == ordem)
                    {
                        nova_ordem = ordem + 1;
                        id_afazer = afazeres.Where(x => x.Ordem == ordem).Select(x => x.ID_Afazer).FirstOrDefault();
                        comandos.AlterarOrdemDoAfazer(id_afazer, nova_ordem);
                    }
                    else if (afazer.Ordem == ordem + 1)
                    {
                        id_afazer = afazeres.Where(x => x.Ordem == ordem + 1).Select(x => x.ID_Afazer).FirstOrDefault();
                        nova_ordem = ordem;
                        comandos.AlterarOrdemDoAfazer(id_afazer, nova_ordem);
                    }
                }

                AtualizarDataGrid();

                try
                {
                    dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                    dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada + 1].Cells[0];
                }
                catch { }
                ordem = ordem + 1;
            }
        }

        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow linha = dataGridViewLista.Rows[e.RowIndex];

            if (e.ColumnIndex == 0)
            {
                int ordem = Convert.ToInt32(dataGridViewLista[e.ColumnIndex, e.RowIndex].Value);

                if (ordem > 6)
                {
                    linha.DefaultCellStyle.SelectionForeColor = Color.DarkGray;
                    linha.DefaultCellStyle.ForeColor = Color.DarkGray;
                }
            }

            if (e.ColumnIndex == 3)
            {
                Font fonte = new Font("Arial", 9, FontStyle.Strikeout, GraphicsUnit.Point);

                bool conclusao = Convert.ToBoolean(dataGridViewLista[e.ColumnIndex, e.RowIndex].Value);
                
                if (conclusao)
                {
                    linha.DefaultCellStyle.Font = fonte;
                }
            }
        }

        private void pbProximo_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddDays(1);
        }

        private void pbAnterior_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddDays(-1);
        }

        private void agendarParaAmanhãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ordem != 0)
            {
                comandos.AgendarAfazerParaAmanha(id_afazer);
            }
        }
    }
}
