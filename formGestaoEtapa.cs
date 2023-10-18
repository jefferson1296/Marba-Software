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
    public partial class formGestaoEtapa : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int ordem;
        int id_projeto;
        public formGestaoEtapa()
        {
            InitializeComponent();
        }
        public formGestaoEtapa(int Ordem, int ID_Projeto)
        {
            InitializeComponent();
            ordem = Ordem;
            id_projeto = ID_Projeto;
            new Sombra().ApplyShadows(this);
        }

        private void formGestaoEtapa_Load(object sender, EventArgs e)
        {
            Etapa Etapa = comandos.TrazerEtapa(id_projeto, ordem);
            textBoxProjeto.Text = Etapa.Projeto;
            textBoxEtapa.Text = Etapa.Descricao;
            textBoxDetalhes.Text = Etapa.Detalhes;
            textBoxStatus.Text = Etapa.Status;
            textBoxOrdem.Text = "N° " + ordem.ToString();

            if (Etapa.Status == "Concluído")
            {
                textBoxInicio.Text = Etapa.Inicio.ToShortDateString() + " " + Etapa.Inicio.ToShortTimeString();
                textBoxConclusao.Text = Etapa.Termino.ToShortDateString() + " " + Etapa.Termino.ToShortTimeString();
            }
            else if (Etapa.Status == "Em andamento")
            {
                textBoxInicio.Text = Etapa.Inicio.ToShortDateString() + " " + Etapa.Inicio.ToShortTimeString();
                textBoxConclusao.Text = "- - -";
            }
            else
            {
                textBoxInicio.Text = "- - -";
                textBoxConclusao.Text = "- - -";
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

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            if (textBoxEtapa.Text == string.Empty)
            {
                MessageBox.Show("Informe a etapa para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Etapa etapa = new Etapa();
                etapa.Descricao = textBoxEtapa.Text;
                etapa.Detalhes = textBoxDetalhes.Text;
                etapa.ID_Projeto = id_projeto;
                etapa.Ordem = ordem;
                comandos.EditarEtapa(etapa);
                Dispose();
            }
        }
    }
}
