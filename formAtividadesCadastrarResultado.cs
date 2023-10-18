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
    public partial class formAtividadesCadastrarResultado : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        formAtividadesCadastrar form_cadastrar = new formAtividadesCadastrar();
        formAtividadesEditar form_editar = new formAtividadesEditar();

        string correcao;
        bool cadastramento;

        public formAtividadesCadastrarResultado()
        {
            InitializeComponent();
        }

        public formAtividadesCadastrarResultado(formAtividadesCadastrar Form_cadastrar)
        {
            InitializeComponent();
            form_cadastrar = Form_cadastrar;
            cadastramento = true;
        }

        public formAtividadesCadastrarResultado(formAtividadesEditar Form_editar)
        {
            InitializeComponent();
            form_editar = Form_editar;
            cadastramento = false;
        }

        private void formAtividadesCadastrarResultado_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                AtualizarDataGrid();
                textBoxResultado.Text = form_editar.Atividade.Resultado;
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            string correcao = textBoxCorrecao.Text;
            
            if (correcao == string.Empty)
            {
                MessageBox.Show("Informe a correção para adicionar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (cadastramento)
                {
                    form_cadastrar.Correcoes.Add(correcao);
                    textBoxCorrecao.Clear();
                    AtualizarDataGrid();
                }
                else
                {
                    comandos.CadastrarAcaoCorretiva(correcao, form_editar.descricao);
                    form_editar.AtualizarAcoesCorretivas();
                    textBoxCorrecao.Clear();
                    AtualizarDataGrid();
                }
            }
        }

        private void dataGridCorrecoes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    correcao = dataGridCorrecoes.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
            }
            catch 
            {
                correcao = string.Empty;
            }
        }

        private void toolStripMenuItemExcluir_Click(object sender, EventArgs e)
        {
            if (correcao != string.Empty)
            {
                if (cadastramento)
                {
                    form_cadastrar.Correcoes.Remove(correcao);
                }
                else
                {
                    comandos.ApagarAcaoCorretiva(correcao, form_editar.descricao);
                    form_editar.AtualizarAcoesCorretivas();
                    AtualizarDataGrid();
                }

                AtualizarDataGrid();
            }
        }

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridCorrecoes.CurrentRow != null)
            {
                primeira_linha = dataGridCorrecoes.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridCorrecoes.CurrentRow.Index;
            }

            dataGridCorrecoes.Rows.Clear();

            if (cadastramento)
            {
                foreach (string correcao in form_cadastrar.Correcoes)
                {
                    dataGridCorrecoes.Rows.Add(correcao);
                }
            }
            else
            {
                foreach (Acao_Corretiva correcao in form_editar.Correcoes)
                {
                    dataGridCorrecoes.Rows.Add(correcao.Correcao);
                }
            }

            try
            {
                dataGridCorrecoes.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridCorrecoes.CurrentCell = dataGridCorrecoes.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridCorrecoes.CurrentRow != null)
                dataGridCorrecoes.CurrentRow.Selected = false;
        }

        private void textBoxResultado_Leave(object sender, EventArgs e)
        {
            string resultado = textBoxResultado.Text;

            if (cadastramento)
            {
                form_cadastrar.Atividade.Resultado = resultado;
            }
            else
            {
                form_editar.Atividade.Resultado = resultado;
            }
        }
    }
}
