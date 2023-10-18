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
    public partial class formGestaoAtividadesDelegaveisDelegavel : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        
        public formGestaoAtividadesDelegaveisDelegavel()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void formGestaoAtividadesDelegaveis_Load(object sender, EventArgs e)
        {
            List<Colaborador> colaboradores = comandos.ListaDeColaboradoresTaticos();
            colaboradorComboBox.ValueMember = "ID_Colaborador";
            colaboradorComboBox.DisplayMember = "Nome_Colaborador";
            colaboradorComboBox.DataSource = colaboradores;

            colaboradorComboBox.SelectedIndex = -1;
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void colaboradorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string colaborador = colaboradorComboBox.Text;

            if (colaborador != string.Empty)
            {
                int id_colaborador = Convert.ToInt32(colaboradorComboBox.SelectedValue);
                List<string> atividades = comandos.PreencherComboAtividadesPeloColaboradorTatico(id_colaborador);
                atividadeComboBox.DataSource = atividades;
                atividadeComboBox.Enabled = true;
            }
            else
            {
                atividadeComboBox.SelectedIndex = -1;
                atividadeComboBox.Enabled = false;
            }
        }

        private void atividadeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            string atividade = atividadeComboBox.Text;
            string colaborador = colaboradorComboBox.Text;
            bool delegavel = checkBoxDelegavel.Checked;

            if (colaborador == string.Empty)
            {
                MessageBox.Show("Informe o colaborador!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (atividade == string.Empty)
            {
                MessageBox.Show("Informe a atividade!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id_colaborador = Convert.ToInt32(colaboradorComboBox.SelectedValue);

                AtividadeLancada Atividade = new AtividadeLancada() { ID_Colaborador = id_colaborador, Descricao = atividade, Delegavel = delegavel };
                comandos.RegistrarAtividadeDelegavel(Atividade);
                Dispose();
            }
        }

        #region Movimentacao do Formulario
        bool clique;
        Point clickedAt;
        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique)
            {
                Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
            }
        }
        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            clique = true;
            clickedAt = e.Location;
        }
        private void panelSuperior_MouseUp(object sender, MouseEventArgs e)
        {
            clique = false;
        }
        #endregion
    }
}
