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
    public partial class formColaboradoresLicencasAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formColaboradoresLicencasAdicionar()
        {
            InitializeComponent();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void formColaboradoresLicencasAdicionar_Load(object sender, EventArgs e)
        {
            List<Colaborador> colaboradores = comandos.PreencherComboColaboradores();
            comboBoxColaboradores.ValueMember = "ID_Colaborador";
            comboBoxColaboradores.DisplayMember = "Nome_Colaborador";
            comboBoxColaboradores.DataSource = colaboradores;

            comboBoxColaboradores.SelectedIndex = -1;

            List<string> licencas = comandos.TiposDeLicencas();
            foreach (string x in licencas) { comboBoxLicencas.Items.Add(x); }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string colaborador = comboBoxColaboradores.Text;

            string licenca = comboBoxLicencas.Text;
            DateTime inicio = dateTimeInicio.Value;
            DateTime termino = dateTimeTermino.Value;

            if (colaborador == string.Empty)
            {
                MessageBox.Show("Informe o colaborador para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (licenca == string.Empty)
            {
                MessageBox.Show("Informe o tipo de licença para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (termino.Date < inicio.Date)
            {
                MessageBox.Show("Informe um intervalo válido para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id_colaborador = Convert.ToInt32(comboBoxColaboradores.SelectedValue);

                Licenca Licenca = new Licenca { ID_Colaborador = id_colaborador, Tipo = licenca, Inicio = inicio, Termino = termino };
                comandos.RegistrarLicenca(Licenca);
                Dispose();
            }
        }
    }
}
