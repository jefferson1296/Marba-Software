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
    public partial class formAtividadesCadastrarProcedimentos : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        formAtividadesCadastrar form_cadastrar = new formAtividadesCadastrar();
        formAtividadesEditar form_editar = new formAtividadesEditar();

        bool cadastramento;
        int ordem;

        public formAtividadesCadastrarProcedimentos()
        {
            InitializeComponent();
        }

        public formAtividadesCadastrarProcedimentos(formAtividadesCadastrar Form_cadastrar)
        {
            InitializeComponent();
            form_cadastrar = Form_cadastrar;
            cadastramento = true;
        }

        public formAtividadesCadastrarProcedimentos(formAtividadesEditar Form_editar)
        {
            InitializeComponent();
            form_editar = Form_editar;
            cadastramento = false;
        }

        private void formAtividadesCadastrarProcedimentos_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                ordemTextBox.Text = (form_editar.Procedimentos.Count + 1).ToString();
                AtualizarDataGrid();
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            string titulo = textBoxResumo.Text;
            string descricao = textBoxProcedimento.Text;
            int ordem = Convert.ToInt32(ordemTextBox.Text);

            if (titulo == string.Empty)
            {
                MessageBox.Show("Informe o título do procedimento para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Procedimento procedimento = new Procedimento() { Descricao = descricao, Resumo = titulo, Ordem = ordem };

                if (cadastramento)
                {
                    form_cadastrar.Procedimentos.Add(procedimento);
                }
                else
                {
                    comandos.CadastrarProcedimento(procedimento, form_editar.descricao);
                    form_editar.AtualizarProcedimentos();
                }

                AtualizarDataGrid();
                ordem++;
                ordemTextBox.Text = ordem.ToString();
                textBoxProcedimento.Clear();
                textBoxResumo.Clear();
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

            if (cadastramento)
            {
                foreach (Procedimento procedimento in form_cadastrar.Procedimentos)
                {
                    dataGridViewLista.Rows.Add(procedimento.Ordem, procedimento.Resumo);
                }
            }
            else
            {
                foreach (Procedimento procedimento in form_editar.Procedimentos)
                {
                    dataGridViewLista.Rows.Add(procedimento.Ordem, procedimento.Resumo);
                }
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

        private void buttonSubir_Click(object sender, EventArgs e)
        {
            if (cadastramento)
            {
                if (ordem == 0) { }
                else if (ordem == 1) { }
                else if (form_cadastrar.Procedimentos.Count == 0) { }
                else
                {
                    int linha_selecionada = 0, primeira_linha = 0;
                    if (dataGridViewLista.CurrentRow != null)
                    {
                        primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                        linha_selecionada = dataGridViewLista.CurrentRow.Index;
                    }

                    string descricao_cima = form_cadastrar.Procedimentos.Where(x => x.Ordem == ordem - 1).Select(i => i.Descricao).FirstOrDefault();
                    string resumo_cima = form_cadastrar.Procedimentos.Where(x => x.Ordem == ordem - 1).Select(i => i.Resumo).FirstOrDefault();


                    string descricao_baixo = form_cadastrar.Procedimentos.Where(x => x.Ordem == ordem).Select(i => i.Descricao).FirstOrDefault();
                    string resumo_baixo = form_cadastrar.Procedimentos.Where(x => x.Ordem == ordem).Select(i => i.Resumo).FirstOrDefault();


                    foreach (Procedimento procedimento in form_cadastrar.Procedimentos)
                    {
                        if (procedimento.Ordem == ordem - 1)
                        {
                            procedimento.Descricao = descricao_baixo;
                            procedimento.Resumo = resumo_baixo;
                        }
                        else if (procedimento.Ordem == ordem)
                        {
                            procedimento.Descricao = descricao_cima;
                            procedimento.Resumo = resumo_cima;
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
                else if (form_editar.Procedimentos.Count == 0) { }
                else
                {
                    int linha_selecionada = 0, primeira_linha = 0;
                    if (dataGridViewLista.CurrentRow != null)
                    {
                        primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                        linha_selecionada = dataGridViewLista.CurrentRow.Index;
                    }

                    //string descricao_cima = form_editar.Procedimentos.Where(x => x.Ordem == ordem - 1).Select(i => i.Descricao).FirstOrDefault();
                    //string resumo_cima = form_editar.Procedimentos.Where(x => x.Ordem == ordem - 1).Select(i => i.Resumo).FirstOrDefault();


                    //string descricao_baixo = form_editar.Procedimentos.Where(x => x.Ordem == ordem).Select(i => i.Descricao).FirstOrDefault();
                    //string resumo_baixo = form_editar.Procedimentos.Where(x => x.Ordem == ordem).Select(i => i.Resumo).FirstOrDefault();

                    int nova_ordem;

                    foreach (Procedimento procedimento in form_editar.Procedimentos)
                    {
                        if (procedimento.Ordem == ordem - 1)
                        {
                            nova_ordem = ordem;
                            int id_procedimento = form_editar.Procedimentos.Where(x => x.Ordem == ordem -1).Select(x => x.ID_Procedimento).FirstOrDefault();
                            comandos.AlterarOrdemDoProcedimento(id_procedimento, nova_ordem);
                        }
                        else if (procedimento.Ordem == ordem)
                        {
                            nova_ordem = ordem - 1;
                            int id_procedimento = form_editar.Procedimentos.Where(x => x.Ordem == ordem).Select(x => x.ID_Procedimento).FirstOrDefault();
                            comandos.AlterarOrdemDoProcedimento(id_procedimento, nova_ordem);
                        }
                    }

                    form_editar.AtualizarProcedimentos();
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
                else if (ordem == form_cadastrar.Procedimentos.Count) { }
                else if (form_cadastrar.Procedimentos.Count == 0) { }
                else
                {
                    int linha_selecionada = 0, primeira_linha = 0;
                    if (dataGridViewLista.CurrentRow != null)
                    {
                        primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                        linha_selecionada = dataGridViewLista.CurrentRow.Index;
                    }

                    string descricao_cima = form_cadastrar.Procedimentos.Where(x => x.Ordem == ordem).Select(i => i.Descricao).FirstOrDefault();
                    string resumo_cima = form_cadastrar.Procedimentos.Where(x => x.Ordem == ordem).Select(i => i.Resumo).FirstOrDefault();

                    string descricao_baixo = form_cadastrar.Procedimentos.Where(x => x.Ordem == ordem + 1).Select(i => i.Descricao).FirstOrDefault();
                    string resumo_baixo = form_cadastrar.Procedimentos.Where(x => x.Ordem == ordem + 1).Select(i => i.Resumo).FirstOrDefault();

                    foreach (Procedimento procedimento in form_cadastrar.Procedimentos)
                    {
                        if (procedimento.Ordem == ordem)
                        {
                            procedimento.Descricao = descricao_baixo;
                            procedimento.Resumo = resumo_baixo;
                        }
                        else if (procedimento.Ordem == ordem + 1)
                        {
                            procedimento.Descricao = descricao_cima;
                            procedimento.Resumo = resumo_cima;
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
                else if (ordem == form_editar.Procedimentos.Count) { }
                else if (form_editar.Procedimentos.Count == 0) { }
                else
                {
                    int linha_selecionada = 0, primeira_linha = 0;
                    if (dataGridViewLista.CurrentRow != null)
                    {
                        primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                        linha_selecionada = dataGridViewLista.CurrentRow.Index;
                    }

                    string descricao_cima = form_editar.Procedimentos.Where(x => x.Ordem == ordem).Select(i => i.Descricao).FirstOrDefault();
                    string resumo_cima = form_editar.Procedimentos.Where(x => x.Ordem == ordem).Select(i => i.Resumo).FirstOrDefault();

                    string descricao_baixo = form_editar.Procedimentos.Where(x => x.Ordem == ordem + 1).Select(i => i.Descricao).FirstOrDefault();
                    string resumo_baixo = form_editar.Procedimentos.Where(x => x.Ordem == ordem + 1).Select(i => i.Resumo).FirstOrDefault();


                    int nova_ordem;

                    foreach (Procedimento procedimento in form_editar.Procedimentos)
                    {
                        if (procedimento.Ordem == ordem)
                        {
                            nova_ordem = ordem + 1;
                            int id_procedimento = form_editar.Procedimentos.Where(x => x.Ordem == ordem).Select(x => x.ID_Procedimento).FirstOrDefault();
                            comandos.AlterarOrdemDoProcedimento(id_procedimento, nova_ordem);
                        }
                        else if (procedimento.Ordem == ordem + 1)
                        {
                            nova_ordem = ordem;
                            int id_procedimento = form_editar.Procedimentos.Where(x => x.Ordem == ordem + 1).Select(x => x.ID_Procedimento).FirstOrDefault();
                            comandos.AlterarOrdemDoProcedimento(id_procedimento, nova_ordem);
                        }
                    }

                    form_editar.AtualizarProcedimentos();
                    AtualizarDataGrid();


                    //foreach (Procedimento procedimento in form_editar.Procedimentos)
                    //{
                    //    if (procedimento.Ordem == ordem)
                    //    {
                    //        procedimento.Descricao = descricao_baixo;
                    //        procedimento.Resumo = resumo_baixo;
                    //    }
                    //    else if (procedimento.Ordem == ordem + 1)
                    //    {
                    //        procedimento.Descricao = descricao_cima;
                    //        procedimento.Resumo = resumo_cima;
                    //    }
                    //}
                    //AtualizarDataGrid();

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

        private void toolStripMenuItemExcluir_Click(object sender, EventArgs e)
        {
            if (cadastramento)
            {
                form_cadastrar.Procedimentos.RemoveAll(x => x.Ordem == ordem);
                int i = 1;

                foreach (Procedimento procedimento in form_cadastrar.Procedimentos)
                {
                    procedimento.Ordem = i;
                    i++;
                }

                AtualizarDataGrid();
                ordemTextBox.Text = (form_cadastrar.Procedimentos.Count + 1).ToString();
            }
            else
            {
                if (form_editar.Procedimentos.Count == 1)
                {
                    MessageBox.Show("Não foi possível apagar o procedimento.\r\nA atividade precisa de pelo menos 1 procedimento registrado.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int id_procedimento = form_editar.Procedimentos.Where(x => x.Ordem == this.ordem).Select(x => x.ID_Procedimento).FirstOrDefault();
                    comandos.ApagarProcedimento(id_procedimento);

                    int i = this.ordem;
                    int ordem = 0;

                    foreach (Procedimento Procedimento in form_editar.Procedimentos)
                    {
                        if (Procedimento.Ordem > this.ordem)
                        {
                            ordem = i;
                            i++;

                            comandos.AlterarOrdemDoProcedimento(Procedimento.ID_Procedimento, ordem);
                        }
                    }

                    form_editar.AtualizarProcedimentos();

                    AtualizarDataGrid();
                    ordemTextBox.Text = (form_editar.Procedimentos.Count + 1).ToString();
                }
            }

        }

        private void dataGridViewLista_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    int ordem = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);

                    if (cadastramento)
                    {
                        textBoxDetalhes.Text = form_cadastrar.Procedimentos.Where(x => x.Ordem == ordem).Select(x => x.Descricao).FirstOrDefault();
                    }
                    else
                    {
                        textBoxDetalhes.Text = form_editar.Procedimentos.Where(x => x.Ordem == ordem).Select(x => x.Descricao).FirstOrDefault();
                    }


                    if (!textBoxDetalhes.Visible)
                    {
                        textBoxDetalhes.Top = Cursor.Position.Y - 30;
                        textBoxDetalhes.Left = Cursor.Position.X - 160;
                        int comprimento = textBoxDetalhes.Text.Length;
                        textBoxDetalhes.Height = 20 * (comprimento / 33 + 1);
                    }
                    textBoxDetalhes.Visible = true;
                }
            }
            catch { }
        }

        private void dataGridViewLista_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            textBoxDetalhes.Visible = false;
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    ordem = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);

                    if (cadastramento)
                    {
                        formAtividadesCadastrarProcedimentosEditar editar = new formAtividadesCadastrarProcedimentosEditar(form_cadastrar, ordem);
                        editar.ShowDialog();
                    }
                    else
                    {
                        formAtividadesCadastrarProcedimentosEditar editar = new formAtividadesCadastrarProcedimentosEditar(form_editar, ordem);
                        editar.ShowDialog();
                    }

                    AtualizarDataGrid();
                }
            }
            catch
            {

            }
        }
    }
}
