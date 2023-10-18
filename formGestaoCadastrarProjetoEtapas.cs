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
    public partial class formGestaoCadastrarProjetoEtapas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        Projeto projeto = new Projeto();
        List<Etapa> etapas = new List<Etapa>();
        formGestaoCadastrarProjeto pai = new formGestaoCadastrarProjeto();
        public formGestaoCadastrarProjetoEtapas(formGestaoCadastrarProjeto Pai, Projeto Projeto)
        {
            InitializeComponent();
            pai = Pai;
            projeto = Projeto;
        }

        private void formGestaoCadastrarProjetoEtapas_Load(object sender, EventArgs e)
        {
            projetoTextBox.Text = projeto.Descricao;
        }

        private void AtualizarDataGrid()
        {
            dataGridViewLista.Rows.Clear();
            foreach (Etapa Etapa in etapas)
            {
                dataGridViewLista.Rows.Add(Etapa.Ordem, Etapa.Descricao);
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            string etapa = etapaTextBox.Text;
            string detalhes = detalhesTextBox.Text;
            int ordem = Convert.ToInt32(ordemTextBox.Text);

            if (etapa == string.Empty)
            {
                MessageBox.Show("Informe a descrição da etapa para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Etapa Etapa = new Etapa() { Descricao = etapa, Detalhes = detalhes, Ordem = ordem };
                etapas.Add(Etapa);
                AtualizarDataGrid();
                ordem++;
                ordemTextBox.Text = ordem.ToString();
                etapaTextBox.Clear();
                detalhesTextBox.Clear();
                etapaTextBox.Focus();
            }
        }

        private void avancarButton_Click(object sender, EventArgs e)
        {
            if (etapas.Count == 0)
            {
                MessageBox.Show("Nenhuma etapa inserida.\r\nAdicione ao menos 1 para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string colaborador = Program.colaborador.Nome_Colaborador;
                comandos.CadastrarProjeto(projeto, etapas, colaborador);
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
