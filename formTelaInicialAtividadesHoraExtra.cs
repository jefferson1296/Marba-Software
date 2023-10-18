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
    public partial class formTelaInicialAtividadesHoraExtra : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formTelaInicialAtividadesHoraExtra()
        {
            InitializeComponent();
        }

        private void formTelaInicialAtividadesHoraExtra_Load(object sender, EventArgs e)
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

        private void salvarButton_Click(object sender, EventArgs e)
        {
            string colaborador = colaboradorComboBox.Text;
            int id_colaborador = (int)colaboradorComboBox.SelectedValue;

            string hora = horaMaskedTextBox.Text;
            string periodo = periodoComboBox.Text;
            string data = dateTimePicker.Text;

            if (hora.Length < 5)
            {
                MessageBox.Show("Preencha as horas extras corretamente.\r\nEx: 01:00", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(colaborador == string.Empty)
            {
                MessageBox.Show("Informe o colaborador!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (periodo == string.Empty)
            {
                MessageBox.Show("Informe o período!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dateTimePicker.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Não é possível atribuir horas extras a uma data que já passou!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comandos.VerificarSeColaboradorEstaDeFolga(id_colaborador, data))
            {
                MessageBox.Show("Não é possível atribuir horas extras na folga do colaborador!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Hora_Extra hora_extra = new Hora_Extra();
                hora_extra.Data = dateTimePicker.Value;
                hora_extra.Tempo = Convert.ToInt32((Convert.ToDateTime("01/01/2000" + " " + horaMaskedTextBox.Text) - Convert.ToDateTime("01/01/2000" + " 00:00")).TotalMinutes);
                hora_extra.ID_Colaborador = id_colaborador;
                hora_extra.Periodo = periodo;
                hora_extra.Data_Registro = DateTime.Now;

                comandos.AdicionarHorasExtras(hora_extra);
                Dispose();
            }
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
