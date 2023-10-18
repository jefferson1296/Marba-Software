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
    public partial class formGestaoRegulamentosAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        public List<Topico_Regulamento> topicos = new List<Topico_Regulamento>();
        public bool cadastramento;

        Regulamento regulamento;
        int ordem;

        public bool alteracao;

        public formGestaoRegulamentosAdicionar()
        {
            InitializeComponent();
            cadastramento = true;
        }

        public formGestaoRegulamentosAdicionar(Regulamento Regulamento)
        {
            InitializeComponent();
            regulamento = Regulamento;
            cadastramento = false;
        }

        private void formGestaoRegulamentosAdicionar_Load(object sender, EventArgs e)
        {
            List<string> tipos = comandos.ListaDeTiposDeRegulamento();
            comboBoxTipo.DataSource = tipos;
            comboBoxTipo.SelectedIndex = -1;

            if (!cadastramento)
            {
                textBoxDescricao.Text = regulamento.Descricao;
                comboBoxTipo.SelectedItem = regulamento.Tipo;

                topicos = comandos.ListaDeTopicosDoRegulamento(regulamento.ID_Regulamento);
                AtualizarDataGrid();
            }
        }

        private void buttonSubir_Click(object sender, EventArgs e)
        {
            if (ordem == 0) { }
            else if (ordem == 1) { }
            else if (topicos.Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewLista.CurrentRow != null)
                {
                    primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewLista.CurrentRow.Index;
                }

                string descricao_cima = topicos.Where(x => x.Ordem == ordem - 1).Select(i => i.Topico).FirstOrDefault();
                string descricao_baixo = topicos.Where(x => x.Ordem == ordem).Select(i => i.Topico).FirstOrDefault();

                foreach (Topico_Regulamento topico in topicos)
                {
                    if (topico.Topico == descricao_baixo)
                    {
                        topico.Ordem = ordem - 1;                                               
                    }
                    else if (topico.Topico == descricao_cima)
                    {
                        topico.Ordem = ordem;
                    }
                }
                AtualizarDataGrid();

                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada - 1].Cells[0];
                ordem = ordem - 1;

                alteracao = true;
            }
        }

        private void buttonDescer_Click(object sender, EventArgs e)
        {
            if (ordem == 0) { }
            else if (ordem == topicos.Count) { }
            else if (topicos.Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewLista.CurrentRow != null)
                {
                    primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewLista.CurrentRow.Index;
                }

                string descricao_cima = topicos.Where(x => x.Ordem == ordem).Select(i => i.Topico).FirstOrDefault();
                string descricao_baixo = topicos.Where(x => x.Ordem == ordem + 1).Select(i => i.Topico).FirstOrDefault();

                foreach (Topico_Regulamento topico in topicos)
                {
                    if (topico.Topico == descricao_baixo)
                    {
                        topico.Ordem = ordem;                        
                    }
                    else if (topico.Topico == descricao_cima)
                    {
                        topico.Ordem = ordem + 1;                                               
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

                alteracao = true;
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string descricao = textBoxDescricao.Text;
            string tipo = comboBoxTipo.Text.ToUpper();

            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe a descrição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tipo == string.Empty)
            {
                MessageBox.Show("Informe o tipo para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (topicos.Count == 0)
            {
                MessageBox.Show("É necessário adicionar ao menos 1 tópico para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (cadastramento)
                {
                    if (comandos.VerificarSeRegulamentoJaExiste(descricao))
                    {
                        MessageBox.Show("Já existe um regulamento cadastrado com esse nome!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Regulamento Regulamento = new Regulamento { Descricao = descricao, Tipo = tipo };
                        comandos.CadastrarRegulamento(Regulamento, topicos);
                        Dispose();
                    }
                }
                else
                {
                    if (comandos.VerificarSeRegulamentoJaExiste(descricao) && descricao != regulamento.Descricao)
                    {
                        MessageBox.Show("Já existe um regulamento cadastrado com esse nome!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        regulamento.Descricao = descricao;
                        regulamento.Tipo = tipo;

                        comandos.EditarRegulamento(regulamento);

                        if (alteracao)
                        {
                            comandos.EditarTopicosDoRegulamento(topicos, regulamento.ID_Regulamento);
                        }

                        Dispose();
                    }
                }
            }
        }

        private void pictureBoxTopico_Click(object sender, EventArgs e)
        {
            formGestaoRegulamentosAdicionarTopicos topicos = new formGestaoRegulamentosAdicionarTopicos(this);
            topicos.ShowDialog();
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

            topicos = topicos.OrderBy(x => x.Ordem).ToList();

            foreach (Topico_Regulamento topico in topicos)
            {
                dataGridViewLista.Rows.Add(topico.Ordem, topico.Topico);
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

        private void dataGridViewLista_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int ordem = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                Topico_Regulamento topico = topicos.Where(x => x.Ordem == ordem).FirstOrDefault();
                formGestaoRegulamentosAdicionarTopicos editar = new formGestaoRegulamentosAdicionarTopicos(this, topico);
                editar.ShowDialog();
                AtualizarDataGrid();
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
                    ordem = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                }
                else
                {
                    ordem = 0;
                }
            }
            catch { }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            topicos.RemoveAll(x => x.Ordem == ordem);
            int i = 1;

            foreach (Topico_Regulamento topico in topicos)
            {
                topico.Ordem = i;
                i++;
            }

            alteracao = true;
            AtualizarDataGrid();
        }
    }
}
