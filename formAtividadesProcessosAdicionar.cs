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
    public partial class formAtividadesProcessosAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id_processo;
        bool cadastramento;

        string atividade;
        string processo;

        int ordem;

        List<Atividade> atividades = new List<Atividade>();

        public formAtividadesProcessosAdicionar()
        {
            InitializeComponent();
            cadastramento = true;
        }

        public formAtividadesProcessosAdicionar(int ID_Processo, string Processo)
        {
            InitializeComponent();
            id_processo = ID_Processo;
            processo = Processo;
            cadastramento = false;
        }

        private void formAtividadesProcessosAdicionar_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                textBoxDescricao.Text = processo;
                atividades = comandos.ListaDeAtividadesDoProcesso(id_processo);
            }

            comboBoxAtividades.DropDownHeight = 150;
            AtualizarComboBoxAtividades();

            AtualizarDataGrid();
        }

        private void AtualizarComboBoxAtividades()
        {

            List<string> atividades_disponiveis = comandos.PreencherComboAtividades();
            AutoCompleteStringCollection colecao = new AutoCompleteStringCollection();

            foreach (Atividade atividade in atividades)
            {
                if (atividades_disponiveis.Contains(atividade.Descricao))
                {
                    atividades_disponiveis.Remove(atividade.Descricao);
                }
            }

            comboBoxAtividades.DataSource = atividades_disponiveis;

            foreach (string atividade in atividades_disponiveis)
            {
                colecao.Add(atividade);
            }

            comboBoxAtividades.AutoCompleteCustomSource = colecao;
            comboBoxAtividades.SelectedIndex = -1;
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

            if (atividades.Count == 0) { labelRegistros.Visible = true; }
            else { labelRegistros.Visible = false; }

            foreach (Atividade atividade in atividades.OrderBy(x => x.Ordem).ToList())
            {
                dataGridViewLista.Rows.Add(atividade.Ordem, atividade.Descricao);
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
            string atividade = comboBoxAtividades.Text;

            if (atividade == string.Empty || !comandos.VerificarNomeDaAtividade(atividade))
            {
                MessageBox.Show("Informe uma atividade válida!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int ordem = atividades.Count + 1;

                atividades.Add(new Atividade { Ordem = ordem, Descricao = atividade });

                if (!cadastramento)
                {
                    Atividade Atividade = new Atividade { Ordem = ordem, Descricao = atividade, ID_Processo = id_processo };
                    comandos.AdicionarAtividadeAoProcesso(Atividade);
                }

                AtualizarComboBoxAtividades();
                AtualizarDataGrid();

                comboBoxAtividades.Text = string.Empty;
                comboBoxAtividades.Focus();
            }
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

                        atividade = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();
                    }
                    else
                    {
                        atividade = string.Empty;
                    }
                }
                catch { }
                            }

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
            if (atividade != string.Empty)
            {
                atividades.RemoveAll(x => x.Descricao == atividade);

                if (!cadastramento)
                {
                    comandos.ApagarAtividadeDoProcesso(id_processo, atividade);
                    comandos.ReordenarAtividadesDoProcesso(id_processo);
                    atividades = comandos.ListaDeAtividadesDoProcesso(id_processo);
                }

                AtualizarComboBoxAtividades();
                AtualizarDataGrid();
            }
        }



        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            string processo = textBoxDescricao.Text;

            if (processo == string.Empty)
            {
                MessageBox.Show("Informe a descrição do processo para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comandos.VerificarNomeDoProcesso(processo) && processo != this.processo)
            {
                MessageBox.Show("Já existe um processo com essa descrição.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (cadastramento)
                {
                    comandos.CadastrarProcesso(processo, atividades);
                }
                else
                {
                    comandos.AlterarDescricaoDoProcesso(id_processo, processo);
                }

                Dispose();
            }
        }

        private void buttonSubir_Click(object sender, EventArgs e)
        {
            if (cadastramento)
            {
                if (ordem == 0) { }
                else if (ordem == 1) { }
                else if (atividades.Count == 0) { }
                else
                {
                    int linha_selecionada = 0, primeira_linha = 0;
                    if (dataGridViewLista.CurrentRow != null)
                    {
                        primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                        linha_selecionada = dataGridViewLista.CurrentRow.Index;
                    }

                    string descricao_cima = atividades.Where(x => x.Ordem == ordem - 1).Select(i => i.Descricao).FirstOrDefault();

                    string descricao_baixo = atividades.Where(x => x.Ordem == ordem).Select(i => i.Descricao).FirstOrDefault();



                    foreach (Atividade atividade in atividades)
                    {
                        if (atividade.Ordem == ordem - 1)
                        {
                            atividade.Descricao = descricao_baixo;
                        }
                        else if (atividade.Ordem == ordem)
                        {
                            atividade.Descricao = descricao_cima;
                        }
                    }

                    AtualizarDataGrid();

                    dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                    dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada - 1].Cells[0];
                    ordem = ordem - 1;
                }
            }
            else
            {
                if (ordem == 0) { }
                else if (ordem == 1) { }
                else if (atividades.Count == 0) { }
                else
                {
                    int linha_selecionada = 0, primeira_linha = 0;
                    if (dataGridViewLista.CurrentRow != null)
                    {
                        primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                        linha_selecionada = dataGridViewLista.CurrentRow.Index;
                    }


                    foreach (Atividade atividade in atividades)
                    {
                        if (atividade.Ordem == ordem - 1)
                        {
                            atividade.Ordem = ordem;
                            comandos.AlterarOrdemDaAtividadeNoProcesso(atividade);
                        }
                        else if (atividade.Ordem == ordem)
                        {
                            atividade.Ordem = ordem - 1;
                            comandos.AlterarOrdemDaAtividadeNoProcesso(atividade);
                        }
                    }

                    AtualizarDataGrid();

                    dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                    dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada - 1].Cells[0];
                    ordem = ordem - 1;
                }
            }
        }

        private void buttonDescer_Click(object sender, EventArgs e)
        {
            if (cadastramento)
            {
                if (ordem == 0) { }
                else if (ordem == atividades.Count) { }
                else if (atividades.Count == 0) { }
                else
                {
                    int linha_selecionada = 0, primeira_linha = 0;
                    if (dataGridViewLista.CurrentRow != null)
                    {
                        primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                        linha_selecionada = dataGridViewLista.CurrentRow.Index;
                    }

                    string descricao_cima = atividades.Where(x => x.Ordem == ordem).Select(i => i.Descricao).FirstOrDefault();

                    string descricao_baixo = atividades.Where(x => x.Ordem == ordem + 1).Select(i => i.Descricao).FirstOrDefault();


                    foreach (Atividade atividade in atividades)
                    {
                        if (atividade.Ordem == ordem)
                        {
                            atividade.Descricao = descricao_baixo;
                        }
                        else if (atividade.Ordem == ordem + 1)
                        {
                            atividade.Descricao = descricao_cima;
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
            else
            {
                if (ordem == 0) { }
                else if (ordem == atividades.Count) { }
                else if (atividades.Count == 0) { }
                else
                {
                    int linha_selecionada = 0, primeira_linha = 0;
                    if (dataGridViewLista.CurrentRow != null)
                    {
                        primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                        linha_selecionada = dataGridViewLista.CurrentRow.Index;
                    }

                    foreach (Atividade atividade in atividades)
                    {
                        if (atividade.Ordem == ordem)
                        {
                            atividade.Ordem = ordem + 1;
                            comandos.AlterarOrdemDaAtividadeNoProcesso(atividade);
                        }
                        else if (atividade.Ordem == ordem + 1)
                        {
                            atividade.Ordem = ordem;
                            comandos.AlterarOrdemDaAtividadeNoProcesso(atividade);
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
        }
    }
}
