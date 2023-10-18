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
    public partial class formTelaInicialAtividadesFolga : Form
    {
        List<string> lista_folgas = new List<string>();
        ComandosSQL comandos = new ComandosSQL();
        public formTelaInicialAtividadesFolga()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void formTelaInicialAtividadesFolga_Load(object sender, EventArgs e)
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

        private void colaboradorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string colaborador = colaboradorComboBox.Text;
            folgaComboBox.Items.Clear();
            if (colaborador != string.Empty)
            {
                int id_colaborador = (int)colaboradorComboBox.SelectedValue;
                lista_folgas = comandos.PreenhcerComboFolgas(id_colaborador);
                foreach (string x in lista_folgas) { folgaComboBox.Items.Add(x); }
            }

        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            if (colaboradorComboBox.Text == string.Empty)
            {
                MessageBox.Show("Informe o colaborador!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (folgaComboBox.Text == string.Empty)
            {
                MessageBox.Show("Escolha a folga que deseja trocar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dateTimePicker.Value < DateTime.Now.Date.AddDays(3) || Convert.ToDateTime(folgaComboBox.Text) < DateTime.Now.Date.AddDays(3))
            {
                MessageBox.Show("Só é possível trocar ou atribuir folgas com 3 dias de antecedência!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string colaborador = colaboradorComboBox.Text;
                string[] partir = colaborador.Split(' ');
                int id_colaborador = Convert.ToInt32(partir[0]);

                DateTime antiga_folga = Convert.ToDateTime(folgaComboBox.Text);
                DateTime folga = dateTimePicker.Value;
                string data = dateTimePicker.Text;
                if (lista_folgas.Contains(data))
                {
                    MessageBox.Show("A data selecionada já está registrada como folga do colaborador!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    comandos.AlterarFolgas(antiga_folga, folga, id_colaborador);
                }
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
