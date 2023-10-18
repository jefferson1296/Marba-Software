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
    public partial class formColaboradoresEscala : Form
    {
        ComandosSQL comando = new ComandosSQL();
        List<Horario> Horarios = new List<Horario>();
        List<string> folgas = new List<string>();
        int id_colaborador;
        string colaborador;

        public List<DateTime> Datas = new List<DateTime>();
        public bool definir_horarios;

        bool verificar_turnos_automaticos;

        public formColaboradoresEscala()
        {
            InitializeComponent();
        }

        public formColaboradoresEscala(int ID_Colaborador, string Colaborador)
        {
            InitializeComponent();
            id_colaborador = ID_Colaborador;
            colaborador = Colaborador;
        }

        private void formColaboradoresEscala_Load(object sender, EventArgs e)
        {
            List<Turno> turnos = comando.TrazerTurnos();
            comboBoxTurno.DataSource = turnos;
            comboBoxTurno.DisplayMember = "Descricao";
            comboBoxTurno.ValueMember = "ID_Turno";
            comboBoxTurno.SelectedIndex = -1;

            string turno = comando.TrazerRodizioDeTurno(id_colaborador);

            if (turno != string.Empty)
            {
                comboBoxTurno.SelectedItem = turno;
                checkBoxRodizio.Checked = true;
            }
            else
            {
                checkBoxRodizio.Enabled = false;
            }

            verificar_turnos_automaticos = true;

            textBoxColaborador.Text = colaborador;
            Horarios = comando.InformacoesDaEscala(id_colaborador);
            folgas = comando.DiasDeFolga(id_colaborador);

            foreach (string folga in folgas)
            {
                foreach (Horario horario in Horarios) { if (horario.Dia == folga) { horario.Folga = true; } }
            }

            CalcularFolga();
            HorasSemanais();

            string dia = labelDia.Text;
            AtualizarHorarios(dia);
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            Datas = comando.ListaDeExpedientesJaDefinidos();

            formColaboradoresEscalaRedefinir redefinir = new formColaboradoresEscalaRedefinir(this);
            redefinir.ShowDialog();

            comando.EditarHorariosIndividuais(Horarios, id_colaborador);

            if (definir_horarios)
            {
                comando.EditarHorariosAtuais(Horarios, Datas, id_colaborador);
            }

            Dispose();
        }

        private void AtualizarHorarios(string dia)
        {
            checkBoxFolga.Checked = folgas.Contains(dia);
            ServicoInicio.Text = Horarios.Where(x => x.ID_Colaborador == id_colaborador && x.Dia == dia && x.Descricao == "Serviço").Select(x => x.Inicio).FirstOrDefault();
            ServicoTermino.Text = Horarios.Where(x => x.ID_Colaborador == id_colaborador && x.Dia == dia && x.Descricao == "Serviço").Select(x => x.Termino).FirstOrDefault();
            LancheInicio.Text = Horarios.Where(x => x.ID_Colaborador == id_colaborador && x.Dia == dia && x.Descricao == "Lanche").Select(x => x.Inicio).FirstOrDefault();
            LancheTermino.Text = Horarios.Where(x => x.ID_Colaborador == id_colaborador && x.Dia == dia && x.Descricao == "Lanche").Select(x => x.Termino).FirstOrDefault();
            AlmocoInicio.Text = Horarios.Where(x => x.ID_Colaborador == id_colaborador && x.Dia == dia && x.Descricao == "Almoço").Select(x => x.Inicio).FirstOrDefault();
            AlmocoTermino.Text = Horarios.Where(x => x.ID_Colaborador == id_colaborador && x.Dia == dia && x.Descricao == "Almoço").Select(x => x.Termino).FirstOrDefault();
        }
        private void HorasSemanais()
        {
            double servico = 0;
            double lanche = 0;
            double almoco = 0;

            double extra_50 = 0;
            double extra_100 = 0;

            foreach (Horario horario in Horarios)
            {
                if (!horario.Folga)
                {
                    if (horario.Descricao == "Serviço")
                    {
                        try
                        {
                            DateTime inicio = Convert.ToDateTime("01/01/2020 " + horario.Inicio + ":00");
                            DateTime termino = Convert.ToDateTime("01/01/2020 " + horario.Termino + ":00");

                            servico = servico + termino.Subtract(inicio).TotalHours;
                            if (horario.Dia == "Domingo") { extra_100 = extra_100 + termino.Subtract(inicio).TotalHours; }
                        }
                        catch { }
                    }
                    else if (horario.Descricao == "Lanche")
                    {
                        try
                        {
                            DateTime inicio = Convert.ToDateTime("01/01/2020 " + horario.Inicio + ":00");
                            DateTime termino = Convert.ToDateTime("01/01/2020 " + horario.Termino + ":00");

                            lanche = lanche + termino.Subtract(inicio).TotalHours;
                            if (horario.Dia == "Domingo") { extra_100 = extra_100 + termino.Subtract(inicio).TotalHours; }
                        }
                        catch { }
                    }
                    else if (horario.Descricao == "Almoço")
                    {
                        try
                        {
                            DateTime inicio = Convert.ToDateTime("01/01/2020 " + horario.Inicio + ":00");
                            DateTime termino = Convert.ToDateTime("01/01/2020 " + horario.Termino + ":00");

                            almoco = almoco + termino.Subtract(inicio).TotalHours;
                            if (horario.Dia == "Domingo") { extra_100 = extra_100 + termino.Subtract(inicio).TotalHours; }
                        }
                        catch { }
                    }
                }
            }

            servico = servico - lanche - almoco;
            if (servico - extra_100 > 44) { extra_50 = servico - extra_100 - 44; }

            textBoxHoras.Text = servico.ToString("F");
            textBoxExtra50.Text = extra_50.ToString("F");
            textBoxExtra100.Text = extra_100.ToString("F");
        }
        private void CalcularFolga()
        {
            int dias_de_folga = folgas.Count;
            textBoxFolga.Clear();

            if (dias_de_folga == 0)
            {
                textBoxFolga.Text = "Não tem.";
            }
            else
            {
                string texto = string.Empty;
                int i = 0;

                foreach (string folga in folgas)
                {
                    i++;
                    if (i == dias_de_folga)
                    {
                        texto = texto + folga;
                    }
                    else
                    {
                        texto = texto + folga + ", ";
                    }
                }

                textBoxFolga.Text = texto;

                bool Folga = checkBoxFolga.Checked;


                if (Folga)
                {
                    Color cor = Color.Silver;
                    ServicoInicio.ForeColor = cor;
                    ServicoTermino.ForeColor = cor;
                    LancheInicio.ForeColor = cor;
                    LancheTermino.ForeColor = cor;
                    AlmocoInicio.ForeColor = cor;
                    AlmocoTermino.ForeColor = cor;
                }
                else
                {
                    Color cor = Color.Black;
                    ServicoInicio.ForeColor = cor;
                    ServicoTermino.ForeColor = cor;
                    LancheInicio.ForeColor = cor;
                    LancheTermino.ForeColor = cor;
                    AlmocoInicio.ForeColor = cor;
                    AlmocoTermino.ForeColor = cor;
                }
            }
        }

        private void pbDiaProximo_Click(object sender, EventArgs e)
        {
            pbDiaProximo.Focus();
            string dia = labelDia.Text;
            string proximo_dia = string.Empty;

            if (dia == "Segunda-feira") { proximo_dia = "Terça-feira"; }
            else if (dia == "Terça-feira") { proximo_dia = "Quarta-feira"; }
            else if (dia == "Quarta-feira") { proximo_dia = "Quinta-feira"; }
            else if (dia == "Quinta-feira") { proximo_dia = "Sexta-feira"; }
            else if (dia == "Sexta-feira") { proximo_dia = "Sábado"; }
            else if (dia == "Sábado") { proximo_dia = "Domingo"; }
            else if (dia == "Domingo") { proximo_dia = "Segunda-feira"; }

            labelDia.Text = proximo_dia;
            AtualizarHorarios(proximo_dia);
        }
        private void pbDiaAnterior_Click(object sender, EventArgs e)
        {
            pbDiaAnterior.Focus();
            string dia = labelDia.Text;
            string proximo_dia = string.Empty;

            if (dia == "Segunda-feira") { proximo_dia = "Domingo"; }
            else if (dia == "Terça-feira") { proximo_dia = "Segunda-feira"; }
            else if (dia == "Quarta-feira") { proximo_dia = "Terça-feira"; }
            else if (dia == "Quinta-feira") { proximo_dia = "Quarta-feira"; }
            else if (dia == "Sexta-feira") { proximo_dia = "Quinta-feira"; }
            else if (dia == "Sábado") { proximo_dia = "Sexta-feira"; }
            else if (dia == "Domingo") { proximo_dia = "Sábado"; }

            labelDia.Text = proximo_dia;
            AtualizarHorarios(proximo_dia);
        }
        private void checkBoxFolga_CheckedChanged(object sender, EventArgs e)
        {
            string dia = labelDia.Text;
            bool Folga = checkBoxFolga.Checked;

            if (Folga)
            {
                if (!folgas.Contains(dia))
                {
                    folgas.Add(dia);
                }
            }
            else { folgas.Remove(dia); }

            foreach (Horario Horario in Horarios)
            {
                if (Horario.Dia == dia)
                {
                    Horario.Folga = Folga;
                }
            }

            CalcularFolga();
            HorasSemanais();
        }
        private void ServicoInicio_Leave(object sender, EventArgs e)
        {
            string horario = ServicoInicio.Text;
            string dia = labelDia.Text;
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

            if (horario.Length != 5 && horario != "  :" || horas > 23 || minutos > 59)
            {
                MessageBox.Show("Formato de hora incorreto.\r\nInforme a hora novamente.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ServicoInicio.Text = Horarios.Where(x => x.Dia == dia && x.Descricao == "Serviço").Select(x => x.Inicio).FirstOrDefault();
                ServicoInicio.Focus();
            }
            else
            {
                foreach (Horario Horario in Horarios)
                {
                    if (Horario.Descricao == "Serviço" && Horario.Dia == dia)
                    {
                        if (horario == "  :") { Horario.Inicio = string.Empty; }
                        else { Horario.Inicio = horario; }
                    }
                }
                HorasSemanais();
            }
        }
        private void ServicoTermino_Leave(object sender, EventArgs e)
        {
            string horario = ServicoTermino.Text;
            string dia = labelDia.Text;
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

            if (horario.Length != 5 && horario != "  :" || horas > 23 || minutos > 59)
            {
                MessageBox.Show("Formato de hora incorreto.\r\nInforme a hora novamente.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ServicoTermino.Text = Horarios.Where(x => x.Dia == dia && x.Descricao == "Serviço").Select(x => x.Termino).FirstOrDefault();
                ServicoTermino.Focus();
            }
            else
            {
                foreach (Horario Horario in Horarios)
                {
                    if (Horario.Descricao == "Serviço" && Horario.Dia == dia)
                    {
                        if (horario == "  :") { Horario.Termino = string.Empty; }
                        else { Horario.Termino = horario; }
                    }
                }
                HorasSemanais();
            }
        }
        private void LancheInicio_Leave(object sender, EventArgs e)
        {
            string horario = LancheInicio.Text;
            string dia = labelDia.Text;
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

            if (horario.Length != 5 && horario != "  :" || horas > 23 || minutos > 59)
            {
                MessageBox.Show("Formato de hora incorreto.\r\nInforme a hora novamente.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LancheInicio.Text = Horarios.Where(x => x.Dia == dia && x.Descricao == "Lanche").Select(x => x.Inicio).FirstOrDefault();
                LancheInicio.Focus();
            }
            else
            {
                foreach (Horario Horario in Horarios)
                {
                    if (Horario.Descricao == "Lanche" && Horario.Dia == dia)
                    {
                        if (horario == "  :") { Horario.Inicio = string.Empty; }
                        else { Horario.Inicio = horario; }
                    }
                }
                HorasSemanais();
            }
        }
        private void LancheTermino_Leave(object sender, EventArgs e)
        {
            string horario = LancheTermino.Text;
            string dia = labelDia.Text;
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

            if (horario.Length != 5 && horario != "  :" || horas > 23 || minutos > 59)
            {
                MessageBox.Show("Formato de hora incorreto.\r\nInforme a hora novamente.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LancheTermino.Text = Horarios.Where(x => x.Dia == dia && x.Descricao == "Lanche").Select(x => x.Termino).FirstOrDefault();
                LancheTermino.Focus();
            }
            else
            {
                foreach (Horario Horario in Horarios)
                {
                    if (Horario.Descricao == "Lanche" && Horario.Dia == dia)
                    {
                        if (horario == "  :") { Horario.Termino = string.Empty; }
                        else { Horario.Termino = horario; }
                    }
                }
                HorasSemanais();
            }
        }
        private void AlmocoInicio_Leave(object sender, EventArgs e)
        {
            string horario = AlmocoInicio.Text;
            string dia = labelDia.Text;
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

            if (horario.Length != 5 && horario != "  :" || horas > 23 || minutos > 59)
            {
                MessageBox.Show("Formato de hora incorreto.\r\nInforme a hora novamente.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AlmocoInicio.Text = Horarios.Where(x => x.Dia == dia && x.Descricao == "Almoço").Select(x => x.Inicio).FirstOrDefault();
                AlmocoInicio.Focus();
            }
            else
            {
                foreach (Horario Horario in Horarios)
                {
                    if (Horario.Descricao == "Almoço" && Horario.Dia == dia)
                    {
                        if (horario == "  :") { Horario.Inicio = string.Empty; }
                        else { Horario.Inicio = horario; }
                    }
                }
                HorasSemanais();
            }
        }
        private void AlmocoTermino_Leave(object sender, EventArgs e)
        {
            string horario = AlmocoTermino.Text;
            string dia = labelDia.Text;
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

            if (horario.Length != 5 && horario != "  :" || horas > 23 || minutos > 59)
            {
                MessageBox.Show("Formato de hora incorreto.\r\nInforme a hora novamente.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AlmocoTermino.Text = Horarios.Where(x => x.Dia == dia && x.Descricao == "Almoço").Select(x => x.Termino).FirstOrDefault();
                AlmocoTermino.Focus();
            }
            else
            {
                foreach (Horario Horario in Horarios)
                {
                    if (Horario.Descricao == "Almoço" && Horario.Dia == dia)
                    {
                        if (horario == "  :") { Horario.Termino = string.Empty; }
                        else { Horario.Termino = horario; }
                    }
                }
                HorasSemanais();
            }
        }

        private void buttonHorarios_Click(object sender, EventArgs e)
        {
            formColaboradoresEscalaCalendario calendario = new formColaboradoresEscalaCalendario(id_colaborador, colaborador);
            calendario.ShowDialog();
        }

        private void buttonAplicar_Click(object sender, EventArgs e)
        {
            string turno = comboBoxTurno.Text;

            if (turno == string.Empty)
            {
                MessageBox.Show("É necessário informar o turno para atribuir um horário pré-definido", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                comando.AtribuirTurnoParaOColaborador(turno, id_colaborador);

                Horarios = comando.InformacoesDaEscala(id_colaborador);
                folgas = comando.DiasDeFolga(id_colaborador);

                foreach (string folga in folgas)
                {
                    foreach (Horario horario in Horarios) { if (horario.Dia == folga) { horario.Folga = true; } }
                }

                CalcularFolga();
                HorasSemanais();

                string dia = labelDia.Text;
                AtualizarHorarios(dia);

                MessageBox.Show("O horário do colaborador foi definido de acordo com o turno \"" + turno + "\".", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void AtribuirMesmoHorario()
        {
            string dia = labelDia.Text;

            string servico_inicio = ServicoInicio.Text;
            string servico_termino = ServicoTermino.Text;
            string lanche_inicio = LancheInicio.Text;
            string lanche_termino = LancheTermino.Text;
            string almoco_inicio = AlmocoInicio.Text;
            string almoco_termino = AlmocoTermino.Text;

            string[] partir_servico_inicio = servico_inicio.Split(':');
            string[] partir_servico_termino = servico_termino.Split(':');
            string[] partir_lanche_inicio = lanche_inicio.Split(':');
            string[] partir_lanche_termino = lanche_termino.Split(':');
            string[] partir_almoco_inicio = almoco_inicio.Split(':');
            string[] partir_almoco_termino = almoco_termino.Split(':');

            int horas_servico_inicio;
            int minutos_servico_inicio;
            int horas_servico_termino;
            int minutos_servico_termino;
            int horas_lanche_inicio;
            int minutos_lanche_inicio;
            int horas_lanche_termino;
            int minutos_lanche_termino;
            int horas_almoco_inicio;
            int minutos_almoco_inicio;
            int horas_almoco_termino;
            int minutos_almoco_termino;

            try
            {
                if (servico_inicio == "  :") { horas_servico_inicio = 0; minutos_servico_inicio = 0; }
                else { horas_servico_inicio = Convert.ToInt32(partir_servico_inicio[0]); minutos_servico_inicio = Convert.ToInt32(partir_servico_inicio[1]); }
            }
            catch
            {
                horas_servico_inicio = 100;
                minutos_servico_inicio = 100;
            }
            try
            {
                if (servico_termino == "  :") { horas_servico_termino = 0; minutos_servico_termino = 0; }
                else { horas_servico_termino = Convert.ToInt32(partir_servico_termino[0]); minutos_servico_termino = Convert.ToInt32(partir_servico_termino[1]); }
            }
            catch
            {
                horas_servico_termino = 100;
                minutos_servico_termino = 100;
            }
            try
            {
                if (lanche_inicio == "  :") { horas_lanche_inicio = 0; minutos_lanche_inicio = 0; }
                else { horas_lanche_inicio = Convert.ToInt32(partir_servico_inicio[0]); minutos_lanche_inicio = Convert.ToInt32(partir_lanche_inicio[1]); }
            }
            catch
            {
                horas_lanche_inicio = 100;
                minutos_lanche_inicio = 100;
            }
            try
            {
                if (lanche_termino == "  :") { horas_lanche_termino = 0; minutos_lanche_termino = 0; }
                else { horas_lanche_termino = Convert.ToInt32(partir_lanche_termino[0]); minutos_lanche_termino = Convert.ToInt32(partir_lanche_termino[1]); }
            }
            catch
            {
                horas_lanche_termino = 100;
                minutos_lanche_termino = 100;
            }
            try
            {
                if (almoco_inicio == "  :") { horas_almoco_inicio = 0; minutos_almoco_inicio = 0; }
                else { horas_almoco_inicio = Convert.ToInt32(partir_almoco_inicio[0]); minutos_almoco_inicio = Convert.ToInt32(partir_almoco_inicio[1]); }
            }
            catch
            {
                horas_almoco_inicio = 100;
                minutos_almoco_inicio = 100;
            }
            try
            {
                if (almoco_termino == "  :") { horas_almoco_termino = 0; minutos_almoco_termino = 0; }
                else { horas_almoco_termino = Convert.ToInt32(partir_almoco_termino[0]); minutos_almoco_termino = Convert.ToInt32(partir_almoco_termino[1]); }
            }
            catch
            {
                horas_almoco_termino = 100;
                minutos_almoco_termino = 100;
            }

            bool permitir = true;

            if (servico_inicio.Length != 5 && servico_inicio != "  :" || horas_servico_inicio > 23 || minutos_servico_inicio > 59)
            {
                MessageBox.Show("Formato de hora incorreto.\r\nInforme o início do serviço novamente.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ServicoInicio.Text = Horarios.Where(x => x.Dia == dia && x.Descricao == "Serviço").Select(x => x.Inicio).FirstOrDefault();
                ServicoInicio.Focus();
                permitir = false;
            }

            if (servico_termino.Length != 5 && servico_termino != "  :" || horas_servico_termino > 23 || minutos_servico_termino > 59)
            {
                MessageBox.Show("Formato de hora incorreto.\r\nInforme o término do serviço novamente.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ServicoTermino.Text = Horarios.Where(x => x.Dia == dia && x.Descricao == "Serviço").Select(x => x.Termino).FirstOrDefault();
                ServicoTermino.Focus();
                permitir = false;
            }

            if (lanche_inicio.Length != 5 && lanche_inicio != "  :" || horas_lanche_inicio > 23 || minutos_lanche_inicio > 59)
            {
                MessageBox.Show("Formato de hora incorreto.\r\nInforme o início do lanche novamente.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LancheInicio.Text = Horarios.Where(x => x.Dia == dia && x.Descricao == "Lanche").Select(x => x.Inicio).FirstOrDefault();
                LancheInicio.Focus();
                permitir = false;
            }

            if (lanche_termino.Length != 5 && lanche_termino != "  :" || horas_lanche_termino > 23 || minutos_lanche_termino > 59)
            {
                MessageBox.Show("Formato de hora incorreto.\r\nInforme o término do lanche novamente.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LancheTermino.Text = Horarios.Where(x => x.Dia == dia && x.Descricao == "Lanche").Select(x => x.Termino).FirstOrDefault();
                LancheTermino.Focus();
                permitir = false;
            }

            if (almoco_inicio.Length != 5 && almoco_inicio != "  :" || horas_almoco_inicio > 23 || minutos_almoco_inicio > 59)
            {
                MessageBox.Show("Formato de hora incorreto.\r\nInforme o início do almoço novamente.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AlmocoInicio.Text = Horarios.Where(x => x.Dia == dia && x.Descricao == "Almoço").Select(x => x.Inicio).FirstOrDefault();
                AlmocoInicio.Focus();
                permitir = false;
            }

            if (almoco_termino.Length != 5 && almoco_termino != "  :" || horas_almoco_termino > 23 || minutos_almoco_termino > 59)
            {
                MessageBox.Show("Formato de hora incorreto.\r\nInforme o término do almoço novamente.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AlmocoTermino.Text = Horarios.Where(x => x.Dia == dia && x.Descricao == "Almoço").Select(x => x.Termino).FirstOrDefault();
                AlmocoTermino.Focus();
                permitir = false;
            }

            if (permitir)
            {
                foreach (Horario Horario in Horarios)
                {
                    if (Horario.Descricao == "Serviço")
                    {
                        if (servico_inicio == "  :") { Horario.Inicio = string.Empty; }
                        else { Horario.Inicio = servico_inicio; }

                        if (servico_termino == "  :") { Horario.Termino = string.Empty; }
                        else { Horario.Termino = servico_termino; }
                    }
                    else if (Horario.Descricao == "Lanche")
                    {
                        if (lanche_inicio == "  :") { Horario.Inicio = string.Empty; }
                        else { Horario.Inicio = lanche_inicio; }

                        if (lanche_termino == "  :") { Horario.Termino = string.Empty; }
                        else { Horario.Termino = lanche_termino; }
                    }
                    else if (Horario.Descricao == "Almoço")
                    {
                        if (almoco_inicio == "  :") { Horario.Inicio = string.Empty; }
                        else { Horario.Inicio = almoco_inicio; }

                        if (almoco_termino == "  :") { Horario.Termino = string.Empty; }
                        else { Horario.Termino = almoco_termino; }
                    }
                }

                HorasSemanais();
            }
        }

        private void buttonDias_Click(object sender, EventArgs e)
        {
            AtribuirMesmoHorario();
        }

        private void checkBoxRodizio_CheckedChanged(object sender, EventArgs e)
        {
            string turno = comboBoxTurno.Text;

            if (verificar_turnos_automaticos)
            {
                if (checkBoxRodizio.Checked)
                {
                    if (turno == "Turno A - Abertura" || turno == "Turno A - Fechamento"
                        || turno == "Turno B - Abertura" || turno == "Turno B - Fechamento")
                    {
                        if (DialogResult.Yes == MessageBox.Show("O colaborador entrará no rodízio de turnos dos domingos.\r\nDeseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                        {
                            comando.AdicionarRodizioDeTurnos(id_colaborador, turno);
                            comboBoxTurno.Enabled = false;
                        }
                    }
                }
                else
                {
                    if (turno == "Turno A - Abertura" || turno == "Turno A - Fechamento"
                        || turno == "Turno B - Abertura" || turno == "Turno B - Fechamento")
                    {
                        if (DialogResult.Yes == MessageBox.Show("O colaborador será removido do rodízio de turnos dos domingos.\r\nDeseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                        {
                            comando.RemoverRodizioDeTurnos(id_colaborador, turno);
                            comboBoxTurno.Enabled = true;
                        }
                    }
                }
            }
        }

        private void comboBoxTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            string turno = comboBoxTurno.Text;
            if (turno == "Turno A - Abertura" || turno == "Turno A - Fechamento"
                || turno == "Turno B - Abertura" || turno == "Turno B - Fechamento")
            {
                checkBoxRodizio.Enabled = true;                
            }
            else
            {
                checkBoxRodizio.Enabled = false;
            }
        }
    }
}
