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
    public partial class formGestaoAtividadesDelegaveisEmAberto : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formGestaoAtividadesDelegaveisEmAberto()
        {
            InitializeComponent();
        }

        private void formGestaoAtividadesDelegaveisEmAberto_Load(object sender, EventArgs e)
        {
            List<string> atividades = comandos.PreencherComboAtividadesPeloColaboradorTatico();
            AutoCompleteStringCollection sugestao = new AutoCompleteStringCollection();

            foreach (string x in atividades)
            {
                atividadeComboBox.Items.Add(x);
                sugestao.Add(x);
            }

            atividadeComboBox.AutoCompleteCustomSource = sugestao;
            atividadeComboBox.Enabled = true;

            atividadeComboBox.SelectedIndex = -1;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            string atividade = atividadeComboBox.Text;

            if (atividade == string.Empty)
            {
                MessageBox.Show("Informe a atividade para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                comandos.RegistrarAtividadeEmAberto(atividade);
                Dispose();
            }
        }
    }
}
