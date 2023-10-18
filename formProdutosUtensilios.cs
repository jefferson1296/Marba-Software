using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MarbaSoftware
{
    public partial class formProdutosUtensilios : Form
    {
        List<AtualizarProduto> atualizarProdutos = new List<AtualizarProduto>();
        string utens;
        string prod;
        int cliqueLinha;
        public formProdutosUtensilios()
        {
            InitializeComponent();
        }
        private void formProdutosUtensilios_Load(object sender, EventArgs e)
        {
            timerAtualizar.Enabled = true;
            formProdutosSplash splash = new formProdutosSplash(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panelCentral.Controls.Clear();
            this.panelCentral.Controls.Add(splash);
            splash.Show();
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void dataGridViewUtensilios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            utens = dataGridViewUtensilios.Rows[e.RowIndex].Cells[0].Value.ToString();
            ComandosSQL comando = new ComandosSQL();
            string produto = dataGridViewUtensilios.Rows[e.RowIndex].Cells[1].Value.ToString();
            prod = produto;
            int ColunaAtivacao = 3;
            int ColunaValidacao = 4;
            int ColunaDisponibilidade = 5;
            cliqueLinha = e.RowIndex;
            int clique = e.ColumnIndex;

            string ativacao1 = "";
            string validacao1 = "";
            string disponibilidade1 = "";

            List<Validacao> tabela = new List<Validacao>();
            tabela = comando.AtualizarStatusDoUtensilio(utens);
            foreach (Validacao linha in tabela)
            {
                foreach (DataGridViewRow row in dataGridViewUtensilios.Rows)
                {
                    if (linha.Produto == dataGridViewUtensilios.Rows[row.Index].Cells[1].Value.ToString())
                    {
                        linha.Ativacao = Convert.ToString(dataGridViewUtensilios.Rows[row.Index].Cells[3].Value);
                        linha._Validacao = Convert.ToString(dataGridViewUtensilios.Rows[row.Index].Cells[4].Value);
                        linha.Disponibilidade = Convert.ToString(dataGridViewUtensilios.Rows[row.Index].Cells[5].Value);
                        linha.Status = Convert.ToString(dataGridViewUtensilios.Rows[row.Index].Cells[6].Value);
                    }
                }
            }

            if (clique == ColunaAtivacao)
            {
                if (Convert.ToString(dataGridViewUtensilios.Rows[cliqueLinha].Cells[clique].Value) == "Ativo")
                {
                    ativacao1 = "Inativo";
                    dataGridViewUtensilios.Rows[cliqueLinha].Cells[clique].Value = ativacao1;

                }
                else
                {
                    ativacao1 = "Ativo";
                    dataGridViewUtensilios.Rows[cliqueLinha].Cells[clique].Value = ativacao1;
                }
            }
            else if (clique == ColunaValidacao)
            {
                if (Convert.ToString(dataGridViewUtensilios.Rows[e.RowIndex].Cells[clique].Value) == "Sim")
                {
                    validacao1 = "Não";
                    dataGridViewUtensilios.Rows[cliqueLinha].Cells[clique].Value = validacao1;
                }
                else
                {
                    validacao1 = "Sim";
                    dataGridViewUtensilios.Rows[cliqueLinha].Cells[clique].Value = validacao1;
                }
            }
            else if (clique == ColunaDisponibilidade)
            {
                if (Convert.ToString(dataGridViewUtensilios.Rows[cliqueLinha].Cells[clique].Value) == "Sim")
                {
                    disponibilidade1 = "Não";
                    dataGridViewUtensilios.Rows[cliqueLinha].Cells[clique].Value = disponibilidade1;
                }
                else
                {
                    disponibilidade1 = "Sim";
                    dataGridViewUtensilios.Rows[cliqueLinha].Cells[clique].Value = disponibilidade1;
                }
            }
            foreach (Validacao linha in tabela)
            {
                string product = dataGridViewUtensilios.Rows[e.RowIndex].Cells[1].Value.ToString();
                int indexatual = tabela.Where(x => x.Produto == product).Select(x => x.Index).FirstOrDefault();
                foreach (DataGridViewRow row in dataGridViewUtensilios.Rows)
                {
                    if (linha.Produto == dataGridViewUtensilios.Rows[row.Index].Cells[1].Value.ToString() && linha.Index == indexatual)
                    {
                        linha.Ativacao = Convert.ToString(dataGridViewUtensilios.Rows[cliqueLinha].Cells[3].Value);
                        linha._Validacao = Convert.ToString(dataGridViewUtensilios.Rows[cliqueLinha].Cells[4].Value);
                        linha.Disponibilidade = Convert.ToString(dataGridViewUtensilios.Rows[cliqueLinha].Cells[5].Value);
                        linha.Status = Convert.ToString(dataGridViewUtensilios.Rows[cliqueLinha].Cells[6].Value); //
                        cliqueLinha++;
                    }
                }
            }          

            int qtd_Ativos = comando.ConsultarQtdAtivos(utens);
            int qtd_Produtos = comando.ConsultarQtdProdutos(utens);

            int index;
            int ativosAcima = 0;
            int validadosAbaixo = 0;
            int validadosAcima = 0;
            int statusAtivosAcima = 0;
            string sim = "Sim";
            string ativo = "Ativo";
            string status = "";

            foreach (Validacao validacao in tabela)
            {
                string ativacao = validacao.Ativacao;
                string disponibilidade = validacao.Disponibilidade;
                string _validacao = validacao._Validacao;
                index = validacao.Index;
                string nome_produto = validacao.Produto;
                string utensilio = validacao.Utensilio;

                ativosAcima = tabela.Where(x => x.Index >= 1 && x.Index < index).Where(x => x.Status == ativo).Where(x => x.Disponibilidade == sim).Count();
                validadosAbaixo = tabela.Where(x => x.Index > index && x.Index <= qtd_Produtos).Where(x => x._Validacao == sim).Where(x => x.Disponibilidade == sim).Where(x => x.Ativacao == ativo).Count();
                validadosAcima = tabela.Where(x => x.Index >= 1 && x.Index < index).Where(x => x._Validacao == sim).Where(x => x.Disponibilidade == sim).Where(x => x.Ativacao == ativo).Count();
                statusAtivosAcima = tabela.Where(x => x.Index >= 1 && x.Index < index).Where(x => x.Disponibilidade == sim).Where(x => x.Status == ativo).Count();

                if (ativacao == "Inativo")
                {
                    status = "Inativo";
                }
                else if (ativacao == "Ativo" && disponibilidade == "Não")
                {
                    status = "Indisponível";
                }
                else if (ativacao == "Ativo" && disponibilidade == "Sim" && _validacao == "Sim" && index == 1)
                {
                    status = "Ativo";
                }
                else if (ativacao == "Ativo" && disponibilidade == "Sim" && _validacao == "Sim" && index <= qtd_Ativos)
                {
                    status = "Ativo";
                }
                else if (ativacao == "Ativo" && disponibilidade == "Sim" && _validacao == "Sim" && index > qtd_Ativos && ativosAcima < qtd_Ativos)
                {
                    status = "Ativo";
                }
                else if (ativacao == "Ativo" && disponibilidade == "Sim" && _validacao == "Sim" && index > qtd_Ativos && ativosAcima >= qtd_Ativos)
                {
                    status = "Desabilitado";
                }
                else if (ativacao == "Ativo" && disponibilidade == "Sim" && _validacao == "Não" && index == 1 && validadosAbaixo >= qtd_Ativos)
                {
                    status = "Desabilitado";
                }
                else if (ativacao == "Ativo" && disponibilidade == "Sim" && _validacao == "Não" && index == 1 && validadosAbaixo < qtd_Ativos)
                {
                    status = "Ativo";
                }
                else if (ativacao == "Ativo" && disponibilidade == "Sim" && _validacao == "Não" && index > 1 && (ativosAcima + validadosAbaixo) < qtd_Ativos)
                {
                    status = "Ativo";
                }
                else if (ativacao == "Ativo" && disponibilidade == "Sim" && _validacao == "Não" && index > 1 && (ativosAcima + validadosAbaixo) >= qtd_Ativos)
                {
                    status = "Desabilitado";
                }
                validacao.Status = status;
                foreach (DataGridViewRow row in dataGridViewUtensilios.Rows)
                {
                    if (validacao.Produto == dataGridViewUtensilios.Rows[row.Index].Cells[1].Value.ToString())
                    {
                        dataGridViewUtensilios.Rows[row.Index].Cells[6].Value = validacao.Status; //
                    }
                }
            }
            if (dataGridViewUtensilios.CurrentRow != null)
                dataGridViewUtensilios.CurrentRow.Selected = false;
            ////DATAGRIDVIEW PARA EXIBIR A TABELA IMAGINÁRIA
            //dataGridView1.Rows.Clear();
            //foreach (Validacao validacao in tabela)
            //{
            //    dataGridView1.Rows.Add(validacao.Index, validacao.Utensilio, validacao.Produto, validacao.Custo, validacao.Status, validacao.Ativacao, validacao.Disponibilidade, validacao._Validacao);
            //}
        }
        private void timerAtualizar_Tick(object sender, EventArgs e)
        {
            ComandosSQL select = new ComandosSQL();
            select.PreencherDataGridViewUtensilios(dataGridViewUtensilios, bindingSourceUtensilios);
            if (dataGridViewUtensilios.CurrentRow != null)
                dataGridViewUtensilios.CurrentRow.Selected = false;

            timerAtualizar.Enabled = false;
        }
        private void buttonSalvar_Click(object sender, EventArgs e)
        {            
            if (DialogResult.Yes == MessageBox.Show("Alterações realizadas nos Utensílios podem alterar os próximos pedidos automáticos. \n Tem certeza que deseja salvar as Alterações?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                ComandosSQL comandos = new ComandosSQL();
                foreach (DataGridViewRow linha in dataGridViewUtensilios.Rows)
                {
                    string produto = dataGridViewUtensilios.Rows[linha.Index].Cells[1].Value.ToString();
                    string status = dataGridViewUtensilios.Rows[linha.Index].Cells[6].Value.ToString();
                    string ativacao = dataGridViewUtensilios.Rows[linha.Index].Cells[3].Value.ToString();
                    string disponibilidade = dataGridViewUtensilios.Rows[linha.Index].Cells[5].Value.ToString();
                    string validacao = dataGridViewUtensilios.Rows[linha.Index].Cells[4].Value.ToString();
                    comandos.SalvarAlteracoesDoUtensilio(produto, ativacao, disponibilidade, validacao, status);
                }
                MessageBox.Show("Alterações salvas com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewUtensilios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Font minhafonte = new Font("Microsoft Sans Serif", 10, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewUtensilios.Rows[e.RowIndex].Cells[1].Style.Font = minhafonte;

            if (dataGridViewUtensilios.Rows[e.RowIndex].Cells[3].Value.ToString() == "Ativo")
            {
                dataGridViewUtensilios.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.LightGreen;
                dataGridViewUtensilios.Rows[e.RowIndex].Cells[3].Style.ForeColor = Color.Black;
            }
            else
            {
                dataGridViewUtensilios.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.LightCoral;
                dataGridViewUtensilios.Rows[e.RowIndex].Cells[3].Style.ForeColor = Color.Black;
            }
            if (dataGridViewUtensilios.Rows[e.RowIndex].Cells[4].Value.ToString() == "Sim")
            {
                dataGridViewUtensilios.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.LightGreen;
                dataGridViewUtensilios.Rows[e.RowIndex].Cells[4].Style.ForeColor = Color.Black;
            }
            else
            {
                dataGridViewUtensilios.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.LightCoral;
                dataGridViewUtensilios.Rows[e.RowIndex].Cells[4].Style.ForeColor = Color.Black;
            }
            if (dataGridViewUtensilios.Rows[e.RowIndex].Cells[5].Value.ToString() == "Sim")
            {
                dataGridViewUtensilios.Rows[e.RowIndex].Cells[5].Style.BackColor = Color.LightGreen;
                dataGridViewUtensilios.Rows[e.RowIndex].Cells[5].Style.ForeColor = Color.Black;
            }
            else
            {
                dataGridViewUtensilios.Rows[e.RowIndex].Cells[5].Style.BackColor = Color.LightCoral;
                dataGridViewUtensilios.Rows[e.RowIndex].Cells[5].Style.ForeColor = Color.Black;
            }
            if (dataGridViewUtensilios.Rows[e.RowIndex].Cells[6].Value.ToString() == "Ativo")
            {
                dataGridViewUtensilios.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.ForestGreen;
            }
            else
            {
                dataGridViewUtensilios.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.Crimson;
            }
        }
        private void pictureBoxPesquisar_Click(object sender, EventArgs e)
        {
        }

        private void dataGridViewUtensilios_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewUtensilios.Rows[e.RowIndex].Cells[3] == dataGridViewUtensilios.Rows[e.RowIndex].Cells[e.ColumnIndex] || dataGridViewUtensilios.Rows[e.RowIndex].Cells[4] == dataGridViewUtensilios.Rows[e.RowIndex].Cells[e.ColumnIndex] || dataGridViewUtensilios.Rows[e.RowIndex].Cells[5] == dataGridViewUtensilios.Rows[e.RowIndex].Cells[e.ColumnIndex])
                {
                    dataGridViewUtensilios.Cursor = Cursors.Hand;
                }
                else
                {
                    dataGridViewUtensilios.Cursor = Cursors.Default;
                }
            }
            catch{}           
        }

        private void dataGridViewUtensilios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridview;
            gridview = (DataGridView)sender;
            gridview.ClearSelection();
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            formProdutosUtensiliosCadastrar cadastrar = new formProdutosUtensiliosCadastrar();
            cadastrar.ShowDialog();
        }
    }
}
