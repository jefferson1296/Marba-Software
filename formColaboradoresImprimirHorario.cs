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
    public partial class formColaboradoresImprimirHorario : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Colaborador> colaboradores = new List<Colaborador>();

        public formColaboradoresImprimirHorario()
        {
            InitializeComponent();
        }

        public formColaboradoresImprimirHorario(List<Colaborador> Colaboradores)
        {
            InitializeComponent();
            colaboradores = Colaboradores;
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            DateTime inicio = dateTimeInicio.Value.Date;
            DateTime termino = dateTimeFinal.Value.Date;

            foreach (Colaborador colaborador in colaboradores)
            {
                if (colaborador.Ativacao)
                {
                    comandos.ImprimirHorariosDoExpediente(colaborador.ID_Colaborador, inicio, termino, false);
                }
            }

            Dispose();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
