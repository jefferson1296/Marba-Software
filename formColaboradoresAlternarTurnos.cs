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
    public partial class formColaboradoresAlternarTurnos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Colaborador> colaboradores_C1 = new List<Colaborador>();
        List<Colaborador> colaboradores_C2 = new List<Colaborador>();

        List<Turno> turnos_T1 = new List<Turno>();
        List<Turno> turnos_T2 = new List<Turno>();

        public formColaboradoresAlternarTurnos()
        {
            InitializeComponent();
        }        

        private void formColaboradoresAlternarTurnos_Load(object sender, EventArgs e)
        {
            colaboradores_C1 = comandos.PreencherComboColaboradores();
            turnos_T1 = comandos.TrazerTurnosDoRodizio();

            comboBoxC1.DataSource = colaboradores_C1;
            comboBoxC1.DisplayMember = "Nome_Colaborador";
            comboBoxC1.ValueMember = "ID_Colaborador";
            comboBoxC1.SelectedIndex = -1;

            comboBoxT1.DataSource = turnos_T1;
            comboBoxT1.DisplayMember = "Descricao";
            comboBoxT1.ValueMember = "ID_Turno";
            comboBoxT1.SelectedIndex = -1;
        }

        private void comboBoxC1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (colaboradores_C1.Contains(comboBoxC1.SelectedItem))
            {
                comboBoxC1.Enabled = false;
                comboBoxT1.Enabled = true;

                colaboradores_C2 = comandos.PreencherComboColaboradores();
                colaboradores_C2.RemoveAll(x => x.Nome_Colaborador == comboBoxC1.Text);

                comboBoxC2.DataSource = colaboradores_C2;
                comboBoxC2.DisplayMember = "Nome_Colaborador";
                comboBoxC2.ValueMember = "ID_Colaborador";
                comboBoxC2.SelectedIndex = -1;
            }
            else
            {
                colaboradores_C2 = colaboradores_C1;
                comboBoxC2.DataSource = null;

                comboBoxC1.Enabled = true;
                comboBoxC1.SelectedIndex = - 1;
                comboBoxT1.Enabled = false;
            }
        }

        private void comboBoxT1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (turnos_T1.Contains(comboBoxT1.SelectedItem))
            {
                comboBoxT1.Enabled = false;
                comboBoxC2.Enabled = true;

                turnos_T2 = comandos.TrazerTurnosDoRodizio();
                turnos_T2.RemoveAll(x => x.Descricao == comboBoxT1.Text);

                comboBoxT2.DataSource = turnos_T2;
                comboBoxT2.DisplayMember = "Descricao";
                comboBoxT2.ValueMember = "ID_Turno";
                comboBoxT2.SelectedIndex = -1;
            }
            else
            {
                comboBoxT2.DataSource = null;

                comboBoxT1.Enabled = true;
                comboBoxC2.Enabled = false;
            }
        }

        private void comboBoxC2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (colaboradores_C2.Contains(comboBoxC2.SelectedItem))
            {
                comboBoxT2.Enabled = true;
                comboBoxC2.Enabled = false;
            }
            else
            {
                comboBoxT2.Enabled = false;
                comboBoxC2.Enabled = true;
            }            
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            int id_colaborador1 = (int)comboBoxC1.SelectedValue;
            int turno1 = (int)comboBoxT1.SelectedValue;

            AlterarTurnoDoColaborador(id_colaborador1, turno1);

            int id_colaborador2 = (int)comboBoxC2.SelectedValue;
            int turno2 = (int)comboBoxT2.SelectedValue;

            AlterarTurnoDoColaborador(id_colaborador2, turno2);

            Dispose();
        }

        private void AlterarTurnoDoColaborador(int id_colaborador, int turno)
        {
            CultureInfo cultura = new CultureInfo("pt-BR");
            DateTimeFormatInfo formato = cultura.DateTimeFormat;



            DateTime data_inicial = dateTimePicker1.Value.Date;
            DateTime data_final = dateTimePicker2.Value.Date;

            List<DateTime> Datas = new List<DateTime>();


            //Adiciona os dias de domingo ao sábado subsequente à lista, para alterar o turno da próxima semana
            for (int i = 0; i < 1; data_inicial = data_inicial.AddDays(1))
            {
                string dia_da_semana = formato.GetDayName(data_inicial.DayOfWeek).PrimeiraLetraMaiuscula();

                Datas.Add(data_inicial);

                if (data_inicial == data_final)
                {
                    i++;
                }

                if (dia_da_semana == "Sábado")
                {
                    List<Turno> Horarios = comandos.EscalaDoTurno(turno);
                    comandos.EditarHorariosDeColaboradoresDoRodizioDeTurnos(Horarios, id_colaborador, turno, Datas);

                    Datas = new List<DateTime>();

                    //Estáticos...
                    if (turno == 6) { turno = 8; }
                    else if (turno == 8) { turno = 6; }
                    else if (turno == 7) { turno = 9; }
                    else if (turno == 9) { turno = 7; }
                }

                if (i == 1)
                {
                    break;
                }
            }
        }
    }
}
