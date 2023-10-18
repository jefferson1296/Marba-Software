using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarbaSoftware
{
    public partial class formGestaoCursosTreinamentosAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id_curso;

        List<string> dias_da_semana = new List<string>();
        List<Aula> aulas = new List<Aula>();

        public List<int> colaboradores = new List<int>();

        bool aulas_definidas;
        bool permissao;

        public formGestaoCursosTreinamentosAdicionar()
        {
            InitializeComponent();
        }

        public formGestaoCursosTreinamentosAdicionar(int ID_Curso)
        {
            InitializeComponent();
            id_curso = ID_Curso;
        }

        private void formGestaoCursosTreinamentosAdicionar_Load(object sender, EventArgs e)
        {
            List<Colaborador> instrutores = comandos.ListaDeInstrutores();
            comboBoxInstrutor.ValueMember = "ID_Colaborador";
            comboBoxInstrutor.DisplayMember = "Nome_Colaborador";
            comboBoxInstrutor.DataSource = instrutores;
            comboBoxInstrutor.SelectedIndex = -1;
            comboBoxInstrutor.DropDownHeight = 120;

            aulas = comandos.AulasDoTreinamento(id_curso);
            AtualizarListaDeMateriasRelacionadas();

            foreach (DataGridViewColumn coluna in dataGridViewRelacionadas.Columns)
            {
                if (coluna.Index != 5)
                {
                    dataGridViewRelacionadas.Columns[coluna.Index].ReadOnly = true;
                }
            }

            permissao = true;
        }

        private void AtualizarListaDeMateriasRelacionadas()
        {
            int linha_selecionada = 0, primeira_linha = 0;

            if (dataGridViewRelacionadas.CurrentRow != null)
            {
                primeira_linha = dataGridViewRelacionadas.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewRelacionadas.CurrentRow.Index;
            }

            dataGridViewRelacionadas.Rows.Clear();            

            foreach (Aula aula in aulas)
            {
                string data;

                if (aula.Data.ToShortDateString() == "01/01/0001") { data = " - - - "; }
                else { data = aula.Data.ToShortDateString() + " " + aula.Data.ToShortTimeString(); }

                dataGridViewRelacionadas.Rows.Add(aula.Ordem, aula.Descricao, aula.Tipo, aula.Sessao, aula.Horas.ToString("F"), data);
            }

            try
            {
                dataGridViewRelacionadas.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewRelacionadas.CurrentCell = dataGridViewRelacionadas.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewRelacionadas.CurrentRow != null)
                dataGridViewRelacionadas.CurrentRow.Selected = false;

            //AtualizarInformacoes();
        }

        private void checkBoxDomingo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDomingo.Checked) { dias_da_semana.Add("Domingo"); }
            else { dias_da_semana.Remove("Domingo"); }
        }

        private void checkBoxSegunda_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSegunda.Checked) { dias_da_semana.Add("Segunda-feira"); }
            else { dias_da_semana.Remove("Segunda-feira"); }
        }

        private void checkBoxTerca_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTerca.Checked) { dias_da_semana.Add("Terça-feira"); }
            else { dias_da_semana.Remove("Terça-feira"); }
        }

        private void checkBoxQuarta_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxQuarta.Checked) { dias_da_semana.Add("Quarta-feira"); }
            else { dias_da_semana.Remove("Quarta-feira"); }
        }

        private void checkBoxQuinta_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxQuinta.Checked) { dias_da_semana.Add("Quinta-feira"); }
            else { dias_da_semana.Remove("Quinta-feira"); }
        }

        private void checkBoxSexta_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSexta.Checked) { dias_da_semana.Add("Sexta-feira"); }
            else { dias_da_semana.Remove("Sexta-feira"); }
        }

        private void checkBoxSabado_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSabado.Checked) { dias_da_semana.Add("Sábado"); }
            else { dias_da_semana.Remove("Sábado"); }
        }

        private void buttonAplicar_Click(object sender, EventArgs e)
        {
            int horas_por_dia = Convert.ToInt32(textBoxHoras.Text);

            DateTime data_inicial = dateTimePicker.Value.Date;
            CultureInfo cultura = new CultureInfo("pt-BR");
            DateTimeFormatInfo formato = cultura.DateTimeFormat;

            string dia_da_semana = formato.GetDayName(data_inicial.DayOfWeek).PrimeiraLetraMaiuscula();

            string horario = maskedTextInicio.Text;
            string[] partir = horario.Split(':');
            int horas;
            int minutos;

            try
            {
                if (horario == "  :") { horas = 0; minutos = 0; }
                else { horas = Convert.ToInt32(partir[0]); minutos = Convert.ToInt32(partir[1]); }
            }
            catch
            {
                horas = 100;
                minutos = 100;
            }

            if (horario.Length != 5 || horas > 23 || minutos > 59)
            {
                MessageBox.Show("Formato de hora incorreto.\r\nInforme a hora novamente.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maskedTextInicio.Focus();
            }
            else if (dias_da_semana.Count == 0)
            {
                MessageBox.Show("Selecione os dias da semana que devem ocorrer os treinamentos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (horas_por_dia == 0)
            {
                MessageBox.Show("Informe quantas horas teremos por dia!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!dias_da_semana.Contains(dia_da_semana))
            {
                MessageBox.Show("O início do curso deve ocorrer em um dia da semana selecionado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LimparInformacoes();

                decimal total_horas = aulas.Sum(x => x.Horas); // Aulas do curso
                int total_dias = Convert.ToInt32(total_horas / horas_por_dia); // Dias de curso =  Aulas do curso / horas por dia

                if (total_horas % horas_por_dia > 0)
                {
                    total_dias++;
                }

                List<DateTime> datas = new List<DateTime>();

                for (int i = 0; datas.Count < total_dias; i++)
                {
                    dia_da_semana = formato.GetDayName(data_inicial.DayOfWeek).PrimeiraLetraMaiuscula();
                    
                    if (dias_da_semana.Contains(dia_da_semana) && !comandos.VerificarFeriadoComLojaFechada(data_inicial))
                    {
                        datas.Add(data_inicial);
                    }

                    data_inicial = data_inicial.AddDays(1);
                }

                decimal hora_aula = comandos.ObterValorDoParametro("Hora-aula");

                foreach (DateTime data in datas)
                {
                    decimal horas_aplicadas = 0;
                    int aula_do_dia = 1;

                    foreach (Aula aula in aulas)
                    {
                        if (aula.Data.ToShortDateString() == "01/01/0001" && horas_aplicadas + aula.Horas <= horas_por_dia)
                        {
                            if (aula_do_dia == 1)
                            {
                                aula.Data = Convert.ToDateTime( data.ToShortDateString() + " " + horario);
                            }
                            else
                            {
                                aula.Data = Convert.ToDateTime(data.ToShortDateString() + " " + horario).AddMinutes((double)(hora_aula * aula_do_dia - hora_aula));
                            }
                            
                            horas_aplicadas = horas_aplicadas + aula.Horas;

                            if (aula_do_dia == horas_por_dia)
                            {
                                aula_do_dia = 1;
                            }
                            else { aula_do_dia++; }
                        }
                    }
                }

                aulas_definidas = true;
                AtualizarListaDeMateriasRelacionadas();
            }
        }

        private void buttonColaboradores_Click(object sender, EventArgs e)
        {
            formGestaoCursosTreinamentosAdicionarColaboradores colaboradores = new formGestaoCursosTreinamentosAdicionarColaboradores(id_curso, this);
            colaboradores.ShowDialog();
            labelColaboradores.Text = this.colaboradores.Count.ToString();
        }

        public void LimparInformacoes()
        {
            foreach (Aula aula in aulas)
            {
                aula.Data = Convert.ToDateTime("01/01/0001");                
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string instrutor = comboBoxInstrutor.Text;

            if (!aulas_definidas)
            {
                MessageBox.Show("Define os dias e horários das aulas para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (colaboradores.Count == 0)
            {
                MessageBox.Show("Informe os colaboradores que participarão do treinamento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (instrutor == string.Empty)
            {
                MessageBox.Show("Informe o instrutor para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id_colaborador = (int)comboBoxInstrutor.SelectedValue;
                comandos.CadastrarTreinamento(id_curso, id_colaborador);
                comandos.CadastrarAulasDoTreinamento(aulas, colaboradores);
                Dispose();
            }
        }

        private void textBoxHoras_Enter(object sender, EventArgs e)
        {
            if (textBoxHoras.Text == "0")
                textBoxHoras.Text = string.Empty;
        }

        private void textBoxHoras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void textBoxHoras_Leave(object sender, EventArgs e)
        {
            if (textBoxHoras.Text == string.Empty)
                textBoxHoras.Text = "0";
        }

        private void dataGridViewRelacionadas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewRelacionadas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

        }
    }
}
