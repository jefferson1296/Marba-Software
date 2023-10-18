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
    public partial class formRepHorarioIndividual : Form
    {
        public formRepHorarioIndividual()
        {
            InitializeComponent();
        }

        private void formRepHorarioIndividual_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'dataSetHorariosIndividuais.HorariosIndividuais'. Você pode movê-la ou removê-la conforme necessário.
            this.reportViewer1.RefreshReport();
        }
    }
}
