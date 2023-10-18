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
    public partial class formTelaInicialAtividadesOrdenarPorHorario : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<AtividadeRealizada> lista = new List<AtividadeRealizada>();
        string data;
        string Previsao_Inicio = string.Empty;

        public formTelaInicialAtividadesOrdenarPorHorario()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void formTelaInicialAtividadesOrdenar_Load(object sender, EventArgs e)
        {
            List<Colaborador> lista_colaboradores;
            if (comandos.VerificarDiretorExecutivo())
            {
                lista_colaboradores = comandos.PreencherComboColaboradores();
            }
            else
            {
                lista_colaboradores = comandos.PreencherComboColaboradoresPorSetor();
            }
;
            colaboradorComboBox.ValueMember = "ID_Colaborador";
            colaboradorComboBox.DisplayMember = "Nome_Colaborador";
            colaboradorComboBox.DataSource = lista_colaboradores;

            colaboradorComboBox.SelectedIndex = -1;
        }
        private void AtualizarDataGrid()
        {
            dataGridViewLista.Rows.Clear();
            foreach(AtividadeRealizada Atividade in lista)
            {
                string descricao = Atividade.Descricao;
                string inicio;
                string termino;
                if (descricao == "Início do Serviço") 
                {
                    inicio = Atividade.Previsao_Inicio.ToLongTimeString();
                    termino = string.Empty;
                }
                else if (descricao == "Fim do Serviço")
                {
                    inicio = string.Empty;
                    termino = Atividade.Previsao_Termino.ToLongTimeString();
                }
                else
                {
                    inicio = Atividade.Previsao_Inicio.ToLongTimeString();
                    termino = Atividade.Previsao_Termino.ToLongTimeString();
                }

                string tempo;
                if (Atividade.Tempo == 0) { tempo = string.Empty; } else { tempo =  Convert.ToDateTime("00:00:00").AddMinutes(Atividade.Tempo).ToShortTimeString(); }
                string prioridade;
                if (Atividade.Prioridade == 0) { prioridade = string.Empty; } else { prioridade = Atividade.Prioridade.ToString(); }                

                dataGridViewLista.Rows.Add(descricao, inicio, termino, tempo, prioridade);
            }
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void buttonSubir_Click(object sender, EventArgs e)
        {
            int index;
            try { index = lista.Where(x => x.Previsao_Inicio == Convert.ToDateTime(Previsao_Inicio)).Select(i => i.Index).FirstOrDefault(); } catch { index = 0; }
            if (Previsao_Inicio == string.Empty) { }
            else if (index == 1) { }
            else if (lista.Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewLista.CurrentRow != null)
                {
                    primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewLista.CurrentRow.Index;
                }

                string descricao_cima = lista.Where(x => x.Index == index - 1).Select(i => i.Descricao).FirstOrDefault();
                int id_atividade_cima = lista.Where(x => x.Index == index - 1).Select(i => i.ID_Atividade).FirstOrDefault();
                DateTime previsao_inicio_cima = lista.Where(x => x.Index == index - 1).Select(i => i.Previsao_Inicio).FirstOrDefault();
                int tempo_cima = lista.Where(x => x.Index == index - 1).Select(i => i.Tempo).FirstOrDefault();
                DateTime previsao_termino_cima = lista.Where(x => x.Index == index - 1).Select(i => i.Previsao_Termino).FirstOrDefault();
                int prioridade_cima = lista.Where(x => x.Index == index - 1).Select(i => i.Prioridade).FirstOrDefault();


                string descricao_baixo = lista.Where(x => x.Index == index).Select(i => i.Descricao).FirstOrDefault();
                int id_atividade_baixo = lista.Where(x => x.Index == index).Select(i => i.ID_Atividade).FirstOrDefault();
                DateTime previsao_inicio_baixo = lista.Where(x => x.Index == index).Select(i => i.Previsao_Inicio).FirstOrDefault();
                int tempo_baixo = lista.Where(x => x.Index == index).Select(i => i.Tempo).FirstOrDefault();
                DateTime previsao_termino_baixo = lista.Where(x => x.Index == index).Select(i => i.Previsao_Termino).FirstOrDefault();
                int prioridade_baixo = lista.Where(x => x.Index == index).Select(i => i.Prioridade).FirstOrDefault();


                foreach(AtividadeRealizada atividade in lista)
                {
                    if (atividade.Index == index - 1)
                    {
                        atividade.Descricao = descricao_baixo;
                        atividade.ID_Atividade = id_atividade_baixo;
                        atividade.Previsao_Inicio = previsao_inicio_cima;
                        atividade.Previsao_Termino = previsao_inicio_cima.AddMinutes(tempo_baixo).AddSeconds(-1);
                        atividade.Tempo = tempo_baixo;
                        atividade.Prioridade = prioridade_baixo;
                    }
                    else if (atividade.Index == index)
                    {
                        atividade.Descricao = descricao_cima;
                        atividade.ID_Atividade = id_atividade_cima;
                        atividade.Previsao_Inicio = previsao_inicio_cima.AddMinutes(tempo_baixo);
                        atividade.Previsao_Termino = previsao_inicio_cima.AddMinutes(tempo_baixo).AddMinutes(tempo_cima).AddSeconds(-1);
                        atividade.Tempo = tempo_cima;
                        atividade.Prioridade = prioridade_cima;
                    }
                }
                AtualizarDataGrid();
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada - 1].Cells[0];
                Previsao_Inicio = previsao_inicio_cima.ToString();
            }
        }
        private void buttonDescer_Click(object sender, EventArgs e)
        {
            int index;
            try { index = lista.Where(x => x.Previsao_Inicio == Convert.ToDateTime(Previsao_Inicio)).Select(i => i.Index).FirstOrDefault(); } catch { index = 0; }
            if (Previsao_Inicio == string.Empty) { }
            else if (index == lista.Count) { }
            else if (lista.Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewLista.CurrentRow != null)
                {
                    primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewLista.CurrentRow.Index;
                }

                string descricao_cima = lista.Where(x => x.Index == index).Select(i => i.Descricao).FirstOrDefault();
                int id_atividade_cima = lista.Where(x => x.Index == index).Select(i => i.ID_Atividade).FirstOrDefault();
                DateTime previsao_inicio_cima = lista.Where(x => x.Index == index).Select(i => i.Previsao_Inicio).FirstOrDefault();
                int tempo_cima = lista.Where(x => x.Index == index).Select(i => i.Tempo).FirstOrDefault();
                DateTime previsao_termino_cima = lista.Where(x => x.Index == index).Select(i => i.Previsao_Termino).FirstOrDefault();
                int prioridade_cima = lista.Where(x => x.Index == index).Select(i => i.Prioridade).FirstOrDefault();


                string descricao_baixo = lista.Where(x => x.Index == index + 1).Select(i => i.Descricao).FirstOrDefault();
                int id_atividade_baixo = lista.Where(x => x.Index == index + 1).Select(i => i.ID_Atividade).FirstOrDefault();
                DateTime previsao_inicio_baixo = lista.Where(x => x.Index == index + 1).Select(i => i.Previsao_Inicio).FirstOrDefault();
                int tempo_baixo = lista.Where(x => x.Index == index + 1).Select(i => i.Tempo).FirstOrDefault();
                DateTime previsao_termino_baixo = lista.Where(x => x.Index == index + 1).Select(i => i.Previsao_Termino).FirstOrDefault();
                int prioridade_baixo = lista.Where(x => x.Index == index + 1).Select(i => i.Prioridade).FirstOrDefault();


                foreach (AtividadeRealizada atividade in lista)
                {
                    if (atividade.Index == index)
                    {
                        atividade.Descricao = descricao_baixo;
                        atividade.ID_Atividade = id_atividade_baixo;
                        atividade.Previsao_Inicio = previsao_inicio_cima;
                        atividade.Previsao_Termino = previsao_inicio_cima.AddMinutes(tempo_baixo).AddSeconds(-1);
                        atividade.Tempo = tempo_baixo;
                        atividade.Prioridade = prioridade_baixo;
                    }
                    else if(atividade.Index == index + 1)
                    {
                        atividade.Descricao = descricao_cima;
                        atividade.ID_Atividade = id_atividade_cima;
                        atividade.Previsao_Inicio = previsao_inicio_cima.AddMinutes(tempo_baixo);
                        atividade.Previsao_Termino = previsao_inicio_cima.AddMinutes(tempo_baixo).AddMinutes(tempo_cima).AddSeconds(-1);
                        atividade.Tempo = tempo_cima;
                        atividade.Prioridade = prioridade_cima;
                    } 
                }
                AtualizarDataGrid();
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada + 1].Cells[0];
                Previsao_Inicio = previsao_inicio_cima.AddMinutes(tempo_baixo).ToString();
            }
        }
        private void buttonPrioridade_Click(object sender, EventArgs e)
        {
            List<AtividadeRealizada> lista_prioridade = lista.OrderBy(x => x.Prioridade).OrderByDescending(x => x.Prioridade).ToList();
            DateTime primeira_atividade = lista.Where(x => x.Index == 2).Select(x => x.Previsao_Inicio).FirstOrDefault();

            lista.Clear();
            int index = 1;

            foreach(AtividadeRealizada Atividade in lista_prioridade)
            {
                if (Atividade.Descricao != "Início do Serviço" && Atividade.Descricao != "Fim do Serviço")
                {
                    lista.Add(new AtividadeRealizada()
                    {
                        Index = index,
                        ID_Atividade = Atividade.ID_Atividade,
                        Descricao = Atividade.Descricao,
                        Previsao_Inicio = primeira_atividade,
                        Tempo = Atividade.Tempo,
                        Previsao_Termino = primeira_atividade.AddMinutes(Atividade.Tempo).AddSeconds(-1),
                        Prioridade = Atividade.Prioridade
                    });
                    index++;
                }
                primeira_atividade = primeira_atividade.AddMinutes(Atividade.Tempo);
            }
            Previsao_Inicio = lista.Where(x => x.Index == 1).Select(x => x.Previsao_Inicio).FirstOrDefault().ToString();
            AtualizarDataGrid();
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
                    Previsao_Inicio = data + " " + hora;
                }
                else
                {
                    Previsao_Inicio = string.Empty;
                }
            }
            catch { }
        }
        private void verificarButton_Click(object sender, EventArgs e)
        {
            bool permitir = false;
            string colaborador = colaboradorComboBox.Text;
            int id_colaborador;
            try { string[] partir = colaborador.Split(' '); id_colaborador = Convert.ToInt32(partir[0]); }
            catch { id_colaborador = 0; }

            data = dateTimePicker.Text;

            bool folga = comandos.VerificarSeColaboradorEstaDeFolga(id_colaborador, data);
            if (dateTimePicker.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Não é possível reordenar atividades de uma data que já passou!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (folga)
            {
                MessageBox.Show("O colaborador está de folga na data selecionada!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lista = comandos.ListaParaOrdenarAtividadesPorHorario(colaborador, data);
                Previsao_Inicio = lista.Where(x => x.Index == 1).Select(x => x.Previsao_Inicio).FirstOrDefault().ToString();
                permitir = true;
            }

            if (permitir)
            {
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
        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            comandos.ReordenarHorarioDasAtividades(lista);
            Dispose();
        }
        private void dataGridViewLista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up || e.KeyData == Keys.Down)
            {
                e.Handled = true;
            }
        }
    }
}
