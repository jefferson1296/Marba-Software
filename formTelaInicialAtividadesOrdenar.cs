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
    public partial class formTelaInicialAtividadesOrdenar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<AtividadeDelegada> lista = new List<AtividadeDelegada>();
        int ordem;
        public formTelaInicialAtividadesOrdenar()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void formTelaInicialAtividadesOrdenar_Load(object sender, EventArgs e)
        {
            List<Colaborador> lista_colaboradores;
            bool multi_setores = Program.Acessos.Where(x => x.Descricao == "Multi-setores").Select(x => x.Permissao).FirstOrDefault();

            if (multi_setores)
            {
                lista_colaboradores = comandos.PreencherComboColaboradores();
            }
            else
            {
                lista_colaboradores = comandos.PreencherComboColaboradoresPorSetor();
            }

            colaboradorComboBox.ValueMember = "ID_Colaborador";
            colaboradorComboBox.DisplayMember = "Nome_Colaborador";
            colaboradorComboBox.DataSource = lista_colaboradores;

            colaboradorComboBox.SelectedIndex = -1;
        }

        private void verificarButton_Click(object sender, EventArgs e)
        {            
            string colaborador = colaboradorComboBox.Text;

            if (colaborador == string.Empty)
            {
                MessageBox.Show("Informe o colaborador para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id_colaborador = (int)colaboradorComboBox.SelectedValue;

                lista = comandos.ListaParaOrdenarAtividades(id_colaborador);

                if (lista.Count == 0)
                {
                    labelAviso.Visible = true;
                    dataGridViewLista.Rows.Clear();
                }
                else
                {
                    labelAviso.Visible = false;
                    AtualizarDataGrid();
                }
            }
        }

        private void AtualizarDataGrid()
        {
            dataGridViewLista.Rows.Clear();
            foreach (AtividadeDelegada Atividade in lista)
            {
                string descricao = Atividade.Descricao;
                int ordem = Atividade.Ordem;
                string prioridade;
                if (Atividade.Prioridade == 0) { prioridade = string.Empty; } else { prioridade = Atividade.Prioridade.ToString(); }

                dataGridViewLista.Rows.Add(ordem, descricao, prioridade);
            }
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonSubir_Click(object sender, EventArgs e)
        {
            if (ordem == 0) { }
            else if (ordem == 1) { }
            else if (lista.Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewLista.CurrentRow != null)
                {
                    primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewLista.CurrentRow.Index;
                }

                string descricao_cima = lista.Where(x => x.Ordem == ordem - 1).Select(i => i.Descricao).FirstOrDefault();
                int id_atividade_cima = lista.Where(x => x.Ordem == ordem - 1).Select(i => i.ID_AtividadeDelegada).FirstOrDefault();
                int prioridade_cima = lista.Where(x => x.Ordem == ordem - 1).Select(i => i.Prioridade).FirstOrDefault();


                string descricao_baixo = lista.Where(x => x.Ordem == ordem).Select(i => i.Descricao).FirstOrDefault();
                int id_atividade_baixo = lista.Where(x => x.Ordem == ordem).Select(i => i.ID_AtividadeDelegada).FirstOrDefault();
                int prioridade_baixo = lista.Where(x => x.Ordem == ordem).Select(i => i.Prioridade).FirstOrDefault();


                foreach (AtividadeDelegada atividade in lista)
                {
                    if (atividade.Ordem == ordem - 1)
                    {
                        atividade.Descricao = descricao_baixo;
                        atividade.ID_AtividadeDelegada = id_atividade_baixo;
                        atividade.Prioridade = prioridade_baixo;
                    }
                    else if (atividade.Ordem == ordem)
                    {
                        atividade.Descricao = descricao_cima;
                        atividade.ID_AtividadeDelegada = id_atividade_cima;
                        atividade.Prioridade = prioridade_cima;
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
            else if (ordem == lista.Count) { }
            else if (lista.Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewLista.CurrentRow != null)
                {
                    primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewLista.CurrentRow.Index;
                }

                string descricao_cima = lista.Where(x => x.Ordem == ordem).Select(i => i.Descricao).FirstOrDefault();
                int id_atividade_cima = lista.Where(x => x.Ordem == ordem).Select(i => i.ID_AtividadeDelegada).FirstOrDefault();
                int prioridade_cima = lista.Where(x => x.Ordem == ordem).Select(i => i.Prioridade).FirstOrDefault();


                string descricao_baixo = lista.Where(x => x.Ordem == ordem + 1).Select(i => i.Descricao).FirstOrDefault();
                int id_atividade_baixo = lista.Where(x => x.Ordem == ordem + 1).Select(i => i.ID_AtividadeDelegada).FirstOrDefault();
                int prioridade_baixo = lista.Where(x => x.Ordem == ordem + 1).Select(i => i.Prioridade).FirstOrDefault();


                foreach (AtividadeDelegada atividade in lista)
                {
                    if (atividade.Ordem == ordem)
                    {
                        atividade.Descricao = descricao_baixo;
                        atividade.ID_AtividadeDelegada = id_atividade_baixo;
                        atividade.Prioridade = prioridade_baixo;
                    }
                    else if (atividade.Ordem == ordem + 1)
                    {
                        atividade.Descricao = descricao_cima;
                        atividade.ID_AtividadeDelegada = id_atividade_cima;
                        atividade.Prioridade = prioridade_cima;
                    }
                }
                AtualizarDataGrid();
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada + 1].Cells[0];
                ordem = ordem + 1;
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
                    ordem = 0;
                }
            }
            catch { }
        }

        private void dataGridViewLista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up || e.KeyData == Keys.Down)
            {
                e.Handled = true;
            }
        }

        private void buttonPrioridade_Click(object sender, EventArgs e)
        {
            List<AtividadeDelegada> lista_prioridade = lista.OrderBy(x => x.Prioridade).OrderByDescending(x => x.Prioridade).ToList();
            //DateTime primeira_atividade = lista.Where(x => x.Index == 2).Select(x => x.Previsao_Inicio).FirstOrDefault();

            lista.Clear();

            int Ordem = 1;
            foreach (AtividadeDelegada Atividade in lista_prioridade)
            {
                lista.Add(new AtividadeDelegada()
                {
                    Ordem = Ordem,
                    ID_Atividade = Atividade.ID_Atividade,
                    Descricao = Atividade.Descricao,
                    Prioridade = Atividade.Prioridade
                });

                Ordem++;
            }
            
            ordem = 1;
            AtualizarDataGrid();
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            comandos.ReordenarAtividades(lista);
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
    }
}
