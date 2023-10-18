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
    public partial class formTelaInicialAtividadesApagar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formTelaInicialAtividadesApagar()
        {
            InitializeComponent();
        }

        private void formTelaInicialAtividadesApagar_Load(object sender, EventArgs e)
        {
            List<Colaborador> colaboradores = comandos.PreencherComboColaboradores();
            colaboradorComboBox.ValueMember = "ID_Colaborador";
            colaboradorComboBox.DisplayMember = "Nome_Colaborador";
            colaboradorComboBox.DataSource = colaboradores;

            colaboradorComboBox.SelectedIndex = -1;
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string colaborador = colaboradorComboBox.Text;
            DateTime data = dateTimePicker1.Value;

            if (colaborador == string.Empty)
            {
                MessageBox.Show("Informe o colaborador para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (data.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Só é possível alterar a data atual ou futura!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id_colaborador;
                try { string[] partir1 = colaborador.Split(' '); id_colaborador = Convert.ToInt32(partir1[0]); }
                catch { id_colaborador = 0; }
                bool alterado = false;

                string coluna;

                if (ServicoInicio.Checked)
                {
                    coluna = "Inicio = NULL";
                    comandos.ApagarRegistrosDePonto(id_colaborador, data, coluna);
                    MessageBox.Show("Registro do início do serviço do dia " + data.ToShortDateString() + " apagado com sucesso!" , "Apagado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    alterado = true;
                }
                if (ServicoTermino.Checked)
                {
                    coluna = "Termino = NULL";
                    comandos.ApagarRegistrosDePonto(id_colaborador, data, coluna);
                    MessageBox.Show("Registro do término do serviço do dia " + data.ToShortDateString() + " apagado com sucesso!", "Apagado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    alterado = true;
                }
                if (LancheInicio.Checked)
                {
                    coluna = "Lanche_inicio = NULL";
                    comandos.ApagarRegistrosDePonto(id_colaborador, data, coluna);
                    MessageBox.Show("Registro do início do lanche do dia " + data.ToShortDateString() + " apagado com sucesso!", "Apagado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    alterado = true;
                }
                if (LancheTermino.Checked)
                {
                    coluna = "Lanche_Termino = NULL";
                    comandos.ApagarRegistrosDePonto(id_colaborador, data, coluna);
                    MessageBox.Show("Registro do término do lanche do dia " + data.ToShortDateString() + " apagado com sucesso!", "Apagado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    alterado = true;
                }
                if (AlmocoInicio.Checked)
                {
                    coluna = "Almoco_Inicio = NULL";
                    comandos.ApagarRegistrosDePonto(id_colaborador, data, coluna);
                    MessageBox.Show("Registro do início do almoço do dia " + data.ToShortDateString() + " apagado com sucesso!", "Apagado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    alterado = true;
                }
                if (AlmocoTermino.Checked)
                {
                    coluna = "Almoco_Termino = NULL";
                    comandos.ApagarRegistrosDePonto(id_colaborador, data, coluna);
                    MessageBox.Show("Registro do término do almoço do dia " + data.ToShortDateString() + " apagado com sucesso!", "Apagado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    alterado = true;
                }
                if (checkBoxAtividade.Checked)
                {
                    comandos.AlterarStatusDasAtividadesEmAndamento(id_colaborador);
                    MessageBox.Show("O status das atividades que estavam em andamento foram alterados para \"Pendentes\".", "Alterado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    alterado = true;
                }

                if (alterado)
                {
                    Dispose();
                }
            }
        }
    }
}
