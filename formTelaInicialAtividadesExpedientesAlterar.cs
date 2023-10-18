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
    public partial class formTelaInicialAtividadesExpedientesAlterar : Form
    {
        public int id;
        public DateTime data;
        ComandosSQL comandos = new ComandosSQL();

        bool registros;
        public formTelaInicialAtividadesExpedientesAlterar()
        {
            InitializeComponent();
        }
        public formTelaInicialAtividadesExpedientesAlterar(int ID, DateTime Data, bool Registros)
        {
            InitializeComponent();
            id = ID;
            data = Data;
            registros = Registros;
        }

        private void formTelaInicialAtividadesExpedientesAlterar_Load(object sender, EventArgs e)
        {
            if (registros)
            {
                radioButtonExpediente.Visible = false;
                radioButtonFolga.Visible = false;

                Expediente expediente = comandos.TrazerRegistrosDoExpediente(id, data);

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
            else
            {
                Expediente expediente = comandos.TrazerPrevisoesDoExpediente(id, data);

                if (expediente.Status == "Folga") { radioButtonFolga.Checked = true; }
                else { radioButtonExpediente.Checked = true; }


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

        private void radioButtonFolga_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFolga.Checked)
            {
                Color cor = Color.DarkGray;
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

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string data = this.data.ToShortDateString();

            Expediente expediente = new Expediente();

            if (radioButtonExpediente.Checked) { expediente.Status = "Serviço"; } else { expediente.Status = "Folga"; }

            if (ServicoInicio.Text != "  :") { expediente.Previsao_Inicio = Convert.ToDateTime(data + " " + ServicoInicio.Text + ":00"); }
            if (ServicoTermino.Text != "  :") { expediente.Previsao_Termino = Convert.ToDateTime(data + " " + ServicoTermino.Text + ":00"); }
            if (LancheInicio.Text != "  :") { expediente.Previsao_Lanche_Inicio = Convert.ToDateTime(data + " " + LancheInicio.Text + ":00"); }
            if (LancheTermino.Text != "  :") { expediente.Previsao_Lanche_Termino = Convert.ToDateTime(data + " " + LancheTermino.Text + ":00"); }
            if (AlmocoInicio.Text != "  :") { expediente.Previsao_Almoco_Inicio = Convert.ToDateTime(data + " " + AlmocoInicio.Text + ":00"); }
            if (AlmocoTermino.Text != "  :") { expediente.Previsao_Almoco_Termino = Convert.ToDateTime(data + " " + AlmocoTermino.Text + ":00"); }

            if (registros)
            {
                comandos.AlterarRegistros(id, data, expediente);
            }
            else
            {
                comandos.AlterarExpediente(id, data, expediente);
            }

            Dispose();
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
