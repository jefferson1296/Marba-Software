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
    public partial class formProdutosAlmoxarifadoApetrechosCadastrar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formProdutosAlmoxarifadoApetrechos pai = new formProdutosAlmoxarifadoApetrechos();
        public formProdutosAlmoxarifadoApetrechosCadastrar()
        {
            InitializeComponent();
        }
        public formProdutosAlmoxarifadoApetrechosCadastrar(formProdutosAlmoxarifadoApetrechos Pai)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            pai = Pai;
        }

        private void formProdutosAlmoxarifadoApetrechosCadastrar_Load(object sender, EventArgs e)
        {
            List<string> lista_atividades = comandos.PreencherComboEquipamentos();
            foreach (string x in lista_atividades) { comboBoxEquipamentos.Items.Add(x); }
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonFinalizar_Click(object sender, EventArgs e)
        {
            string apetrecho = textBoxApetrecho.Text;
            string tipo = comboBoxTipo.Text;
            string equipamento = comboBoxEquipamentos.Text;

            if (apetrecho == string.Empty)
            {
                MessageBox.Show("Informe o nome do apetrecho para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tipo == string.Empty)
            {
                MessageBox.Show("Informe o tipo do apetrecho para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (equipamento == string.Empty)
            {
                MessageBox.Show("Informe o equipamento para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Apetrecho Apetrecho = new Apetrecho();
                Apetrecho.Nome_Apetrecho = apetrecho;
                Apetrecho.Tipo = tipo;
                Apetrecho.Equipamento = equipamento;

                comandos.CadastrarApetrecho(Apetrecho);
                pai.alteracao = true;
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
                this.Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
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
