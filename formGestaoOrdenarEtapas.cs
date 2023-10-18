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
    public partial class formGestaoOrdenarEtapas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Etapa> Etapas = new List<Etapa>();
        int id_projeto;
        int ordem;
        bool automatico;
        bool alteracao;
        public formGestaoOrdenarEtapas()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }
        public formGestaoOrdenarEtapas(int ID_Projeto, bool Automatico)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            id_projeto = ID_Projeto;
            automatico = Automatico;
        }

        private void formGestaoOrdenarEtapas_Load(object sender, EventArgs e)
        {
            List<Projeto> lista = comandos.ListaDeProjetos();
            foreach (Projeto projeto in lista) { projetoComboBox.Items.Add(projeto.ID_Projeto.ToString() + " - " + projeto.Descricao); }

            if (automatico)
            {
                string projeto = lista.Where(x => x.ID_Projeto == id_projeto).Select(x => x.Descricao).FirstOrDefault();
                projetoComboBox.Text = id_projeto.ToString() + " - " + projeto;
                Etapas = comandos.ListaDeEtapas(id_projeto);
                ordem = Etapas.Where(x => x.Ordem == 1).Select(x => x.Ordem).First();
                AtualizarDataGrid();
            }
        }

        private void verificarButton_Click(object sender, EventArgs e)
        {
            alteracao = false;
            if (projetoComboBox.Text == string.Empty)
            {
                MessageBox.Show("Informe o projeto para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string[] partir = projetoComboBox.Text.Split(' ');
                id_projeto = Convert.ToInt32(partir[0]);
                Etapas = comandos.ListaDeEtapas(id_projeto);
                ordem = Etapas.Where(x => x.Ordem == 1).Select(x => x.Ordem).First();
                AtualizarDataGrid();
            }
        }

        private void AtualizarDataGrid()
        {
            dataGridViewLista.Rows.Clear();

            foreach(Etapa Etapa in Etapas)
            {
                int ordem = Etapa.Ordem;
                string descricao = Etapa.Descricao;

                dataGridViewLista.Rows.Add(ordem, descricao);
            }
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #region Movimentacao do Formulario
        bool clique;
        Point clickedAt;
        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique)
            {
                this.Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
            }
        }
        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            clique = true;
            clickedAt = e.Location;
        }
        private void panelSuperior_MouseUp(object sender, MouseEventArgs e)
        {
            clique = false;
        }
        #endregion

        private void buttonSubir_Click(object sender, EventArgs e)
        {
            alteracao = true;
            if (ordem == 1) { }
            else if (Etapas.Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewLista.CurrentRow != null)
                {
                    primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewLista.CurrentRow.Index;
                }

                int ordem_atual = ordem;
                string etapa_atual = Etapas.Where(x => x.Ordem == ordem_atual).Select(x => x.Descricao).First();
                int id_atual = Etapas.Where(x => x.Ordem == ordem_atual).Select(x => x.ID_Etapa).First();

                int ordem_cima = ordem - 1;
                string etapa_cima = Etapas.Where(x => x.Ordem == ordem_cima).Select(x => x.Descricao).First();
                int id_cima = Etapas.Where(x => x.Ordem == ordem_cima).Select(x => x.ID_Etapa).First();

                foreach (Etapa Etapa in Etapas)
                {
                    if (Etapa.Ordem == ordem - 1)
                    {
                        Etapa.Descricao = etapa_atual;
                        Etapa.ID_Etapa = id_atual;
                    }
                    else if (Etapa.Ordem == ordem)
                    {
                        Etapa.Descricao = etapa_cima;
                        Etapa.ID_Etapa = id_cima;
                    }
                }

                AtualizarDataGrid();
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada - 1].Cells[0];
                ordem = ordem_cima;
            }
        }

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridViewLista.CurrentCell = dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dataGridViewLista.Rows[e.RowIndex].Selected = true;
                    dataGridViewLista.Focus();
                    string hora = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();
                    ordem = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                }
                else
                {
                    ordem  = 0;
                }
            }
            catch { }
        }

        private void buttonDescer_Click(object sender, EventArgs e)
        {
            alteracao = true;
            if (ordem == Etapas.Count) { }
            else if (Etapas.Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewLista.CurrentRow != null)
                {
                    primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewLista.CurrentRow.Index;
                }

                int ordem_atual = ordem;
                string etapa_atual = Etapas.Where(x => x.Ordem == ordem_atual).Select(x => x.Descricao).First();
                int id_atual = Etapas.Where(x => x.Ordem == ordem_atual).Select(x => x.ID_Etapa).First();

                int ordem_baixo = ordem + 1;
                string etapa_baixo = Etapas.Where(x => x.Ordem == ordem_baixo).Select(x => x.Descricao).First();
                int id_baixo = Etapas.Where(x => x.Ordem == ordem_baixo).Select(x => x.ID_Etapa).First();

                foreach (Etapa Etapa in Etapas)
                {
                    if (Etapa.Ordem == ordem + 1)
                    {
                        Etapa.Descricao = etapa_atual;
                        Etapa.ID_Etapa = id_atual;
                    }
                    else if (Etapa.Ordem == ordem)
                    {
                        Etapa.Descricao = etapa_baixo;
                        Etapa.ID_Etapa = id_baixo;
                    }
                }

                AtualizarDataGrid();
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada + 1].Cells[0];
                ordem = ordem_baixo;
            }
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            if (Etapas.Count == 0) { MessageBox.Show("Não há etapas para serem reoordenadas!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else if (!alteracao) { Dispose(); }
            else
            {
                comandos.ReordenarEtapas(Etapas);
                Dispose();
            }
        }
    }
}
