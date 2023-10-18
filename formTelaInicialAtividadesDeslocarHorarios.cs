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
    public partial class formTelaInicialAtividadesDeslocarHorarios : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        bool folga;
        public formTelaInicialAtividadesDeslocarHorarios()
        {
            InitializeComponent();
        }

        private void formTelaInicialAtividadesDeslocarHorarios_Load(object sender, EventArgs e)
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

            List<Colaborador> colaboradores = comandos.PreencherComboColaboradores();
            colaboradorComboBox.ValueMember = "ID_Colaborador";
            colaboradorComboBox.DisplayMember = "Nome_Colaborador";
            colaboradorComboBox.DataSource = colaboradores;

            colaboradorComboBox.SelectedIndex = -1;

            DateTime data = DateTime.Now;
            CultureInfo cultura = new CultureInfo("pt-BR");
            DateTimeFormatInfo formato = cultura.DateTimeFormat;
            string dia_da_semana = formato.GetDayName(data.DayOfWeek).PrimeiraLetraMaiuscula();
            labelData.Text = data.ToShortDateString() + ", " + dia_da_semana;
        }

        private void verificarButton_Click(object sender, EventArgs e)
        {
            string[] partir = labelData.Text.Split(',');
            string data = partir[0];
            string colaborador = colaboradorComboBox.Text;

            if (colaborador == string.Empty)
            {
                MessageBox.Show("Informe o colaborador!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string[] partir1 = colaborador.Split(' ');
                int id_colaborador = Convert.ToInt32(partir1[0]);

                if (comandos.VerificarSeColaboradorEstaDeFolga(id_colaborador, data))
                {
                    folga = true;
                    labelFolga.Visible = true;
                }
                else
                {
                    folga = false;
                    labelFolga.Visible = false;
                    Expediente expediente = comandos.HorariosDoDia(id_colaborador, data);

                    string servico_inicio;
                    if (expediente.Previsao_Inicio.ToString() == "01/01/0001 00:00:00") { servico_inicio = string.Empty; }
                    else { servico_inicio = expediente.Previsao_Inicio.ToShortTimeString(); }

                    string servico_termino;
                    if (expediente.Previsao_Termino.ToString() == "01/01/0001 00:00:00") { servico_termino = string.Empty; }
                    else { servico_termino = expediente.Previsao_Termino.ToShortTimeString(); }                    

                    string lanche_inicio;
                    if (expediente.Previsao_Lanche_Inicio.ToString() == "01/01/0001 00:00:00") { lanche_inicio = string.Empty; }
                    else { lanche_inicio = expediente.Previsao_Lanche_Inicio.ToShortTimeString(); }                    

                    string lanche_termino;
                    if (expediente.Previsao_Lanche_Termino.ToString() == "01/01/0001 00:00:00") { lanche_termino = string.Empty; }
                    else { lanche_termino = expediente.Previsao_Lanche_Termino.ToShortTimeString(); }                    

                    string almoco_inicio;
                    if (expediente.Previsao_Almoco_Inicio.ToString() == "01/01/0001 00:00:00") { almoco_inicio = string.Empty; }
                    else { almoco_inicio = expediente.Previsao_Almoco_Inicio.ToShortTimeString(); }                    

                    string almoco_termino;
                    if (expediente.Previsao_Almoco_Termino.ToString() == "01/01/0001 00:00:00") { almoco_termino = string.Empty; }
                    else { almoco_termino = expediente.Previsao_Almoco_Termino.ToShortTimeString(); }                    

                    ServicoInicio.Text = servico_inicio;
                    ServicoTermino.Text = servico_termino;
                    LancheInicio.Text = lanche_inicio;
                    LancheTermino.Text = lanche_termino;
                    AlmocoInicio.Text = almoco_inicio;
                    AlmocoTermino.Text = almoco_termino;
                }
            }
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (folga)
            {
                MessageBox.Show("O funcionário estará de folga nessa data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string colaborador = colaboradorComboBox.Text;
                int id_colaborador;
                try { string[] partir1 = colaborador.Split(' '); id_colaborador = Convert.ToInt32(partir1[0]); }
                catch { id_colaborador = 0; }

                string[] partir = labelData.Text.Split(',');
                string data = partir[0];
                Expediente expediente = new Expediente();
                if (ServicoInicio.Text != "  :") { expediente.Previsao_Inicio = Convert.ToDateTime(data + " " + ServicoInicio.Text + ":00"); }
                if (ServicoTermino.Text != "  :") { expediente.Previsao_Termino = Convert.ToDateTime(data + " " + ServicoTermino.Text + ":00"); }                
                if (LancheInicio.Text != "  :") { expediente.Previsao_Lanche_Inicio = Convert.ToDateTime(data + " " + LancheInicio.Text + ":00"); }                
                if (LancheTermino.Text != "  :") { expediente.Previsao_Lanche_Termino = Convert.ToDateTime(data + " " + LancheTermino.Text + ":00"); }                
                if (AlmocoInicio.Text != "  :") { expediente.Previsao_Almoco_Inicio = Convert.ToDateTime(data + " " + AlmocoInicio.Text + ":00"); }                
                if (AlmocoTermino.Text != "  :") { expediente.Previsao_Almoco_Termino = Convert.ToDateTime(data + " " + AlmocoTermino.Text + ":00"); }                

                comandos.DeslocarHorarios(id_colaborador, data, expediente);
                Dispose();
            }
        }

        private void pbProximo_Click(object sender, EventArgs e)
        {
            string colaborador = colaboradorComboBox.Text;
            string[] partir = labelData.Text.Split(',');
            string data_anterior = partir[0];
            DateTime Data = Convert.ToDateTime(data_anterior).AddDays(1);
            string data = Data.ToShortDateString();
            CultureInfo cultura = new CultureInfo("pt-BR");
            DateTimeFormatInfo formato = cultura.DateTimeFormat;
            string dia_da_semana = formato.GetDayName(Data.DayOfWeek).PrimeiraLetraMaiuscula();
            int id_colaborador;
            try { string[] partir1 = colaborador.Split(' '); id_colaborador = Convert.ToInt32(partir1[0]); }
            catch { id_colaborador = 0; }

            if (comandos.VerificarSeExpedienteFoiPreenchido(id_colaborador, data))
            {
                labelData.Text = data + ", " + dia_da_semana;

                if (comandos.VerificarSeColaboradorEstaDeFolga(id_colaborador, data))
                {
                    folga = true;
                    labelFolga.Visible = true;
                }
                else
                {
                    folga = false;
                    labelFolga.Visible = false;
                    Expediente expediente = comandos.HorariosDoDia(id_colaborador, data);

                    string servico_inicio;
                    if (expediente.Previsao_Inicio.ToString() == "01/01/0001 00:00:00") { servico_inicio = string.Empty; }
                    else { servico_inicio = expediente.Previsao_Inicio.ToShortTimeString(); }

                    string servico_termino;
                    if (expediente.Previsao_Termino.ToString() == "01/01/0001 00:00:00") { servico_termino = string.Empty; }
                    else { servico_termino = expediente.Previsao_Termino.ToShortTimeString(); }

                    string lanche_inicio;
                    if (expediente.Previsao_Lanche_Inicio.ToString() == "01/01/0001 00:00:00") { lanche_inicio = string.Empty; }
                    else { lanche_inicio = expediente.Previsao_Lanche_Inicio.ToShortTimeString(); }

                    string lanche_termino;
                    if (expediente.Previsao_Lanche_Termino.ToString() == "01/01/0001 00:00:00") { lanche_termino = string.Empty; }
                    else { lanche_termino = expediente.Previsao_Lanche_Termino.ToShortTimeString(); }

                    string almoco_inicio;
                    if (expediente.Previsao_Almoco_Inicio.ToString() == "01/01/0001 00:00:00") { almoco_inicio = string.Empty; }
                    else { almoco_inicio = expediente.Previsao_Almoco_Inicio.ToShortTimeString(); }

                    string almoco_termino;
                    if (expediente.Previsao_Almoco_Termino.ToString() == "01/01/0001 00:00:00") { almoco_termino = string.Empty; }
                    else { almoco_termino = expediente.Previsao_Almoco_Termino.ToShortTimeString(); }

                    ServicoInicio.Text = servico_inicio;
                    ServicoTermino.Text = servico_termino;
                    LancheInicio.Text = lanche_inicio;
                    LancheTermino.Text = lanche_termino;
                    AlmocoInicio.Text = almoco_inicio;
                    AlmocoTermino.Text = almoco_termino;
                }
            }
            else
            {
                MessageBox.Show("Essa data ainda não teve os horários definidos.\r\nCaso necessário, entre em contato com o responsável pelo preenchimento da escala.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pbAnterior_Click(object sender, EventArgs e)
        {
            string colaborador = colaboradorComboBox.Text;
            string[] partir = labelData.Text.Split(',');
            string data_anterior = partir[0];
            DateTime Data = Convert.ToDateTime(data_anterior).AddDays(-1);
            string data = Data.ToShortDateString();
            CultureInfo cultura = new CultureInfo("pt-BR");
            DateTimeFormatInfo formato = cultura.DateTimeFormat;
            string dia_da_semana = formato.GetDayName(Data.DayOfWeek).PrimeiraLetraMaiuscula();

            if (data == DateTime.Now.AddDays(-1).ToShortDateString())
            {
                MessageBox.Show("Não é possível alterar os horários de uma data que já passou!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                labelData.Text = data + ", " + dia_da_semana;
                string[] partir1 = colaborador.Split(' ');
                int id_colaborador = Convert.ToInt32(partir1[0]);

                if (comandos.VerificarSeColaboradorEstaDeFolga(id_colaborador, data))
                {
                    folga = true;
                    labelFolga.Visible = true;
                }
                else
                {
                    folga = false;
                    labelFolga.Visible = false;
                    Expediente expediente = comandos.HorariosDoDia(id_colaborador, data);

                    string servico_inicio;
                    if (expediente.Previsao_Inicio.ToString() == "01/01/0001 00:00:00") { servico_inicio = string.Empty; }
                    else { servico_inicio = expediente.Previsao_Inicio.ToShortTimeString(); }

                    string servico_termino;
                    if (expediente.Previsao_Termino.ToString() == "01/01/0001 00:00:00") { servico_termino = string.Empty; }
                    else { servico_termino = expediente.Previsao_Termino.ToShortTimeString(); }

                    string lanche_inicio;
                    if (expediente.Previsao_Lanche_Inicio.ToString() == "01/01/0001 00:00:00") { lanche_inicio = string.Empty; }
                    else { lanche_inicio = expediente.Previsao_Lanche_Inicio.ToShortTimeString(); }

                    string lanche_termino;
                    if (expediente.Previsao_Lanche_Termino.ToString() == "01/01/0001 00:00:00") { lanche_termino = string.Empty; }
                    else { lanche_termino = expediente.Previsao_Lanche_Termino.ToShortTimeString(); }

                    string almoco_inicio;
                    if (expediente.Previsao_Almoco_Inicio.ToString() == "01/01/0001 00:00:00") { almoco_inicio = string.Empty; }
                    else { almoco_inicio = expediente.Previsao_Almoco_Inicio.ToShortTimeString(); }

                    string almoco_termino;
                    if (expediente.Previsao_Almoco_Termino.ToString() == "01/01/0001 00:00:00") { almoco_termino = string.Empty; }
                    else { almoco_termino = expediente.Previsao_Almoco_Termino.ToShortTimeString(); }

                    ServicoInicio.Text = servico_inicio;
                    ServicoTermino.Text = servico_termino;
                    LancheInicio.Text = lanche_inicio;
                    LancheTermino.Text = lanche_termino;
                    AlmocoInicio.Text = almoco_inicio;
                    AlmocoTermino.Text = almoco_termino;
                }
            }
        }

        private void ServicoInicio_Leave(object sender, EventArgs e)
        {
            string horario = ServicoInicio.Text;
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
                ServicoInicio.Clear();
                ServicoInicio.Focus();
            }
        }

        private void ServicoTermino_Leave(object sender, EventArgs e)
        {
            string horario = ServicoTermino.Text;
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
                ServicoTermino.Clear();
                ServicoTermino.Focus();
            }
        }

        private void LancheInicio_Leave(object sender, EventArgs e)
        {
            string horario = LancheInicio.Text;
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
                LancheInicio.Clear();
                LancheInicio.Focus();
            }
        }

        private void LancheTermino_Leave(object sender, EventArgs e)
        {
            string horario = LancheTermino.Text;
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
                LancheTermino.Clear();
                LancheTermino.Focus();
            }
        }

        private void AlmocoInicio_Leave(object sender, EventArgs e)
        {
            string horario = AlmocoInicio.Text;
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
                AlmocoInicio.Clear();
                AlmocoInicio.Focus();
            }

        }

        private void AlmocoTermino_Leave(object sender, EventArgs e)
        {
            string horario = AlmocoTermino.Text;
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
                AlmocoTermino.Clear();
                AlmocoTermino.Focus();
            }
        }
    }
}
