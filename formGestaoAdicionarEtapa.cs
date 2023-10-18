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
    public partial class formGestaoAdicionarEtapa : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formGestao pai = new formGestao();
        Projeto projeto;
        public formGestaoAdicionarEtapa()
        {
            InitializeComponent();
        }
        public formGestaoAdicionarEtapa(formGestao Pai)
        {
            InitializeComponent();
            pai = Pai;
        }

        public formGestaoAdicionarEtapa(formGestao Pai, Projeto Projeto)
        {
            InitializeComponent();
            pai = Pai;
            projeto = Projeto;
        }
        private void formGestaoAdicionarEtapa_Load(object sender, EventArgs e)
        {
            string colaborador = Program.colaborador.Nome_Colaborador;
            List<string> projetos = comandos.PreencherComboProjetos(colaborador);
            foreach (string x in projetos) { projetoComboBox.Items.Add(x); }

            if (projeto.ID_Projeto != 0)
            {
                projetoComboBox.SelectedItem = projeto.ID_Projeto.ToString() + " - " + projeto.Descricao;
            }
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void avancarButton_Click(object sender, EventArgs e)
        {
            string[] partir = projetoComboBox.Text.Split(' ');
            int id_projeto = Convert.ToInt32(partir[0]);
            string etapa = etapaTextBox.Text;
            string detalhes = detalhesTextBox.Text;

            if (projetoComboBox.Text == string.Empty)
            {
                MessageBox.Show("Informe o projeto para adicionar a etapa!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (etapa == string.Empty)
            {
                MessageBox.Show("Informe a etapa para prosseguir!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Etapa Etapa = new Etapa() { ID_Projeto = id_projeto, Descricao = etapa, Detalhes = detalhes};
                comandos.AdicionarEtapaAoProjeto(Etapa);
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
